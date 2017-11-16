using FiniteAutomata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Implementation
{
    public class PartialTransitionRule : ITransitionRule<PartialState>
    {
        public PartialTransitionRule(PartialState state, string command, PartialState outState)
        {
            InState = state;
            Command = command;
            OutState = outState;
        }

        protected string Command { get; set; }

        public PartialState OutState { get; protected set; }

        public PartialState InState { get; protected set; }


        public bool Recognize(PartialState state, object command)
        {
            return InState.Recognize(state) && command.ToString() == Command;
        }


        public void Apply(ref Dictionary<string, string> state)
        {
            if (state == null)
                state = new Dictionary<string, string>();
            foreach (var a in InState)
                state[a.Key] = a.Value;
        }

    }
}
