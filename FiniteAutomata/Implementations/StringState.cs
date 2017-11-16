using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Implementation
{
    public class StringState : Interfaces.IState<StringState>
    {
        public string State { get; set; }

        public StringState(string state)
        {
            State = state;
        }

        public void Apply(ref StringState state)
        {
            state = new StringState(State);
        }

        public bool Recognize(StringState state)
        {
            return state.State == this.State;
        }

        public static implicit operator string(StringState s)
        {
            return s.State;
        }

        public static implicit operator StringState(string s)
        {
            return new StringState(s);
        }

        public override string ToString()
        {
            return State;
        }

        public override bool Equals(object obj)
        {
            var s = obj as StringState;
            if (s == null)
                return false;
            return s.State == this.State;
        }

        public override int GetHashCode()
        {
            return State.GetHashCode();
        }
    }
}
