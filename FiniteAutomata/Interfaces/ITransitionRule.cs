using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Interfaces
{
    public interface ITransitionRule<TState> where TState : IState<TState>
    {
        TState InState { get; }

        TState OutState { get; }

        bool Recognize(TState state, object command);
    }
}
