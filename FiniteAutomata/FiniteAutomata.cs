using FiniteAutomata.Exceptions;
using FiniteAutomata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteAutomata
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TTransitionRule"></typeparam>
    public class FiniteAutomata<TState, TTransitionRule> where TTransitionRule : ITransitionRule<TState> where TState : IState<TState>
    {
        protected TState _state=default(TState);

        /// <summary>
        /// </summary>
        public IEnumerable<TTransitionRule> Rules { get; set; }        

        /// <summary>
        /// List of acceptable states
        /// </summary>
        public IEnumerable<TState> AcceptableStates { get; set; }

        /// <summary>
        /// List of non acceptable states
        /// </summary>
        public IEnumerable<TState> NonAcceptableStates { get; set; }

        /// <summary>
        /// Initial state
        /// </summary>
        public TState InitialState { get; set; }

        /// <summary>
        /// Current state. On init it is the same as InitialState
        /// </summary>
        public TState State { get { return _state; } protected set { _state = value; } }



        public FiniteAutomata()
        {

        }

        public FiniteAutomata(TState initialState, IEnumerable<TTransitionRule> machine, IEnumerable<TState> acceptableStates, IEnumerable<TState> nonAcceptableStates)
        {
            Rules = machine;
            InitialState = initialState;
            AcceptableStates = acceptableStates;
            NonAcceptableStates = nonAcceptableStates;
            Compile();
        }

        /// <summary>
        /// Check is everything ok; do initial settings
        /// </summary>
        public virtual void Compile()
        {
            if (Rules == null)
                throw new ArgumentException("Rules not set");

            if (InitialState == null)
                throw new ArgumentException("No initial state");

            if (_state==null)
                _state = InitialState.Apply(_state);            
        }



        public TTransitionRule Execute(object command)
        {
            var recognizedRule = Rules.FirstOrDefault(r => r.Recognize(State,command));
            if (recognizedRule!=null)
            {
                _state = recognizedRule.OutState.Apply(_state);
                var action = (recognizedRule as IAction);
                if (action != null)
                    action.Execute();
                return recognizedRule;
            }
            else
                throw new NoSuchCommandException(command);
        }


        public bool IsFinal()
        {
            return CheckStates(AcceptableStates, State) || CheckStates(NonAcceptableStates, State);            
        }


        public bool IsAcceptable()
        {
            return CheckStates(AcceptableStates, State);
        }

        private static bool CheckStates(IEnumerable<TState> states, TState state)
        {
            if (states == null)
                return false;
            return states.Any(s => s.Recognize(state));
        }
    }
}
