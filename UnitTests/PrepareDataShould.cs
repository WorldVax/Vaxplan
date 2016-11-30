using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vaxplan.Services;
using System.Linq;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class PrepareDataShould
    {
        [TestMethod]
        public void CreateAdministeredAntigenRecords()
        {
            var testcase = CaseLibrary.Testcases["2013-0100"];
            var series = testcase.PatientProfile.Series;
            var doses = AdministeredAntigenFactory.Prepare(series).ToList();
            Assert.AreEqual(20, doses.Count);
        }
    }
}
