using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vaxplan.Services;
using System.Linq;
using Vaxplan.Model;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class AdministeredDoseServiceShould
    {
        [TestMethod]
        public void CreateAdministeredAntigenRecords()
        {
            var testcase = CaseLibrary.Testcases["2013-0100"];
            var series = testcase.PatientProfile.Series.Select(x => x.ToModel());
            var doses = AdministeredDoseService.Prepare(series).ToList();
            Assert.AreEqual(20, doses.Count);
        }
    }
}
