using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FiniteAutomata;
using FiniteAutomata.Interfaces;

namespace TextualAdventureConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            var rules = new List<StringTransitionRule>
            {
                new StringTransitionRule("1","dva","2"),
                new StringTransitionRule("2","tri","3"),
                new StringTransitionRule("3","pobedi","pobeda")
            };

            var fs = new FiniteAutomata<StringState, StringTransitionRule>(new StringState("1"),rules, new[] { new StringState("pobeda") },null);


            var a = JsonConvert.SerializeObject(fs,Formatting.Indented);
            */

            /*


            var rules = new List<MyRule>
            {
                new MyRule(new MyState { { "sef" , "zatvoren" } }, "ukucaj 123 u sef", new MyState { { "sef" , "otvoren" } }),
                new MyRule(new MyState { { "sef", "otvoren" } }, "uzmi kljuc", new MyState { { "kljuc", "u ruci" } }),
                new MyRule(new MyState { { "kljuc", "u ruci" } }, "otkljucaj vrata", new MyState { { "vrata", "otkljucana" } }),
            };

            var init = new MyState
            {
                { "sef","zatvoren" }
            };

            var fs = new FiniteAutomata.FiniteAutomata<MyState, MyRule>(init, rules,new[] { new MyState { { "vrata", "otkljucana" } } }, new MyState[] {  });
            fs.Compile();*/


            var fs = new FiniteAutomata<MyState, MyRule>(new MyState(1), new List<MyRule> { new MyRule() }, new MyState[] { new MyAcceptableState() }, null);
            fs.Compile();

            Console.WriteLine("Current state {0}", fs.State);
            while (!fs.IsFinal())
            {
                
                var command = Console.ReadLine();
                try
                {
                    var cmd = fs.Execute(command);
                    Console.WriteLine("Current state {0}", fs.State);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            }
            Console.WriteLine(" End, {0} state = {1}", fs.IsAcceptable() ? "acceptable" : "non acceptable", fs.State);
            Console.ReadKey();            
        }
    }


    public class MyState : IState<MyState>
    {
        public int I { get; protected set; }

        public MyState(int i)
        {
            I = i;
        }

        public MyState Apply(MyState state)
        {
            if (state == null)
                state = new MyState(this.I);
            else
                state.I = this.I;
            return state;
        }

        public virtual bool Recognize(MyState state)
        {
            return state.I == this.I;
        }

        public override string ToString()
        {
            return I.ToString();
        }


    }

    public class MyAcceptableState : MyState
    {
        public MyAcceptableState() : base(0)
        {
        }

        public override bool Recognize(MyState state)
        {
            return state.I%3==0;
        }
    }


    public class MyRule : ITransitionRule<MyState>, IAction
    {

        public MyState InState { get; protected set; }

        public MyState OutState { get; protected set; }

        public bool Recognize(MyState state, object command)
        {
            OutState = new MyState(state.I + Convert.ToInt32(command));
            return true;
        }

        public void Execute()
        {
            if (OutState.I % 10 == 0) Console.Beep();
        }
    }

}
