using FiniteAutomata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Implementation
{
    public class PartialState : Dictionary<string, string>, IState<PartialState>
    {
        public PartialState Apply(PartialState state)
        {
            if (state == null)
                state = new PartialState();
            foreach (var a in this)
                state[a.Key] = a.Value;
            return state;
        }

        public bool Recognize(PartialState state)
        {
            if (state == null && (Count == 0))
                return true;
            if (state == null)
                return false;
            foreach (var s in this)
                if (!state.ContainsKey(s.Key) || state[s.Key] != s.Value)
                    return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var a in this)
                sb.AppendFormat("{0} : {1}, ", a.Key, a.Value);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var obj1 = obj as PartialState;
            if (obj1 == null)
                return false;
            return obj1.Count==this.Count && !obj1.Except(this).Any();            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
