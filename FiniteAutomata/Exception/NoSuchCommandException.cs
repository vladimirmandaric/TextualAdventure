using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Exceptions
{
    public class NoSuchCommandException : ArgumentException
    {
        public NoSuchCommandException(object command) : base(string.Format("No such command {0}", command)) { }
    }
}
