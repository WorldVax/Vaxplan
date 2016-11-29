using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class CaseLibraryShould
    {
        [TestMethod]
        public void GetTestcase_0001()
        {
            var sut = CaseLibrary.Testcases["2013-0001"];
            Assert.IsInstanceOfType(sut, typeof(Testcase));
        }
    }
}
