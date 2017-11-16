using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Exceptions
{
    public class InitialStateNotSetException : ArgumentException
    {
        public InitialStateNotSetException() : base("Initial state not set") { }
    }
}
