using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NLPDataPreparation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String line = "The Quality Report in the <START:company> LDRA <END> tool suite presents both a summary and detailed breakdown of quality metrics which are deduced during static analysis.";
            line = line.Replace(" <END>", "");
            Assert.AreEqual(false, line.Contains(" <END>"));
        }
    }
}
