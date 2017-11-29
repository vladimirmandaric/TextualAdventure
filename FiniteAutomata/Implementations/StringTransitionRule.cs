using FiniteAutomata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FiniteAutomata.Implementation
{
    public class StringTransitionRule : ITransitionRule<StringState>
    {
        protected StringState InState { get; set; }

        public StringState OutState { get; protected set; }

        

        protected string Command { get; set; }

        public StringTransitionRule(StringState inState,  StringState outState, string command)
        {
            InState = inState;
            Command = command;
            OutState = outState;
        }        

        public bool Recognize(StringState state, object command)
        {
            return InState.Recognize(state) && Regex.IsMatch(command.ToString(), "^" + this.Command + "$", RegexOptions.IgnoreCase);
        }
        
    }
}
