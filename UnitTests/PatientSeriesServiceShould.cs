using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class PatientSeriesServiceShould
    {
        private const string TESTCASE_ID = "2013-0102";
        private const string ANTIGEN_ID = "Diphtheria";

        [TestMethod]
        public void PickValidAntigenSeries()
        {
            var testcase = CaseLibrary.Testcases[TESTCASE_ID];
            var antigen = Refdata.Antigens[ANTIGEN_ID];

        }

        [TestMethod]
        public void SkipInvalidAntigenSeries()
        {
        }
    }
}
