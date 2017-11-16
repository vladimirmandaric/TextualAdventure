using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Exceptions
{
    public class NonReachableStateException : ArgumentException
    {
        public NonReachableStateException(object state) : base(string.Format("Non reachable state detected {0}", state)) { }
    }
}
