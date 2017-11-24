using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata.Interfaces
{

    /// <summary>
    /// The IState is modeled in this manner having partial states in mind.
    /// Recognize means that class itself is responsible for recognizing the state
    ///      and applying chanages to current state.
    /// Doing this way it can cover variety of finite automatas
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public interface IState<TState>
    {
        /// <summary>
        /// Recognize param state as this state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        bool Recognize(TState state);

        /// <summary>
        /// Apply this state to param state and return applied state
        /// </summary>
        /// <param name="state"></param>
        TState Apply(TState state);
    }
}
