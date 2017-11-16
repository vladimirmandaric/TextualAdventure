using FiniteAutomata;
using FiniteAutomata.Implementation;
using FiniteAutomata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextualAdventure
{

    public class TextualAdventureTransitionRule : StringTransitionRule
    {
        public TextualAdventureTransitionRule(StringState inState, StringState outState, string command, string sentenceSuccess) : base(inState,  outState, command)
        {
            SentenceSuccess = sentenceSuccess;
        }

        public string SentenceSuccess { get; set; }
                
    }
}
