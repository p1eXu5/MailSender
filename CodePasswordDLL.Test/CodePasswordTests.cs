using CodePasswordDLL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            // arrange
            string strln = "abc";
            string strExpected = "bcd";

            // act
            string strActual = CodePassword.getCodePassword(strln);

            // assert
            Assert.AreEqual(strExpected, strActual);
        }

        [TestMethod()]
        public void getCodePassword_empty_empty()
        {
            // arrange
            string strln = "";
            string strExpected = "";

            // act
            string strActual = CodePassword.getCodePassword(strln);

            // assert
            Assert.AreEqual(strExpected, strActual);
        }
    }
}
