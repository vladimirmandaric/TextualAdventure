using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Interfaces
{


    public interface ITransitionRule<TState> where TState : IState<TState>
    {
        /// <summary>
        /// Out state, if Recognize returns true
        /// </summary>
        TState OutState { get; }

        /// <summary>
        /// Given the input state and the command Recognize should return true if FA can make transition
        /// </summary>
        /// <param name="state"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        bool Recognize(TState state, object command);
    }
}
