using FiniteAutomata;
using FiniteAutomata.Implementation;

namespace TextualAdventure
{
    public class TextualAdventure : FiniteAutomata<StringState,TextualAdventureTransitionRule>
    {
        public string InitialDescription { get; set; }
    }

}
