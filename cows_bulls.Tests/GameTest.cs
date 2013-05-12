using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;
using System.Reflection;

namespace cows_bulls.Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestInitialize()
        {
            Type staticType = typeof(Game);
            ConstructorInfo ci = staticType.TypeInitializer;
            object[] parameters = new object[0];
            ci.Invoke(null, parameters);
        }
    }
}
