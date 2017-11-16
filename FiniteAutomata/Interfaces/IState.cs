using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Interfaces
{
    public interface IState<TState>
    {
        /// <summary>
        /// Recognize param state as this state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        bool Recognize(TState state);

        /// <summary>
        /// Apply this state to param state
        /// </summary>
        /// <param name="state"></param>
        void Apply(ref TState state);
    }
}
