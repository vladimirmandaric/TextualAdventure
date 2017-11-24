using FiniteAutomata;
using FiniteAutomata.Exceptions;
using FiniteAutomata.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FiniteAutomata.Tests
{
    [TestFixture]
    public class FiniteAutomataTests
    {

        [SetUp]
        public void FiniteAutomataTestsSetup()
        {
        }

        [Test]
        public void FiniteAutomataStringTest()
        {
            var fssRules = new List<StringTransitionRule>
            {
                new StringTransitionRule("1","1","one"),    // on 'one' stay in 1
                new StringTransitionRule("1","2","two"),    // on 'two' 1 transits to 2
                new StringTransitionRule("2","3","three"),  // on 'three' 2 transits to 3
                new StringTransitionRule("3","won","win"),  // on 'won' 3 transits to 'win' state
                new StringTransitionRule("3","lose","lost"),// on 'lose' 3 transits to 'lost' state
            };

            var fss = new FiniteAutomata<StringState, StringTransitionRule>("1", fssRules, new StringState[] { "won" }, new StringState[] { "lost" });

            try
            {
                fss.Execute("three");
                Assert.Fail("Exception NoSuchCommandException not thrown!");
            }
            catch (NoSuchCommandException) { }

            fss.Execute("one");
            Assert.AreEqual(fss.State, new StringState("1"));
            fss.Execute("two");
            Assert.AreEqual(fss.State, new StringState("2"));
            fss.Execute("three");
            Assert.AreEqual(fss.State, new StringState("3"));
            fss.Execute("win");
            Assert.AreEqual(fss.State, new StringState("won"));
            Assert.IsTrue(fss.IsAcceptable());
            Assert.IsTrue(fss.IsFinal());
        }

        [Test]
        public void FiniteAutomataPartialStateTest()
        {
            var rules = new List<PartialTransitionRule>
            {
                new PartialTransitionRule(new PartialState(),"enter code 123 into the safe", new PartialState { { "safe", "open" } }),
                new PartialTransitionRule(new PartialState {  { "safe", "open" } }, "take the key from safe", new PartialState { { "key", "taken" } }),
                new PartialTransitionRule(new PartialState {  { "key", "taken" } }, "unlock the door using key", new PartialState { { "door", "open" } }),
            };

            var fss = new FiniteAutomata<PartialState, PartialTransitionRule>(new PartialState(), rules, new PartialState[] { new PartialState { { "door", "open" } } }, null);

            try
            {
                fss.Execute("take the key from safe");
                Assert.Fail("Exception NoSuchCommandException not thrown!");
            }
            catch (NoSuchCommandException) { }

            fss.Execute("enter code 123 into the safe");
            Assert.AreEqual(fss.State, new PartialState { { "safe", "open" } });
            fss.Execute("take the key from safe");
            Assert.AreEqual(fss.State, new PartialState { { "safe", "open" },  { "key", "taken" } });
            fss.Execute("unlock the door using key");
            Assert.AreEqual(fss.State, new PartialState { { "safe", "open" }, { "key", "taken" }, { "door", "open" } });
            Assert.IsTrue(fss.IsAcceptable());
            Assert.IsTrue(fss.IsFinal());
        }

        public void FiniteAutomata1()
        {

        }
    }


}
