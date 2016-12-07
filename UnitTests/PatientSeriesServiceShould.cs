using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vaxplan.Services;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class PatientSeriesServiceShould
    {
        private const string TESTCASE_ID = "2013-0531";
        private const string ANTIGEN_ID = "Measles";

        [TestMethod]
        public void ValidateStandardAntigenSeries()
        {
            var data = IsValid(0);
            Assert.IsTrue(data);
        }


        [TestMethod]
        public void ValidateAntigenRiskSeries()
        {
            var data = IsValid(1);
            Assert.IsTrue(data);
        }

        public bool IsValid(int seriesIndex)
        {
            var @case = CaseLibrary.Testcases[TESTCASE_ID];
            var profile = @case.PatientProfile.ToModel();
            profile.MedHistoryCode = "048";
            var series = Refdata.Antigens[ANTIGEN_ID].series[seriesIndex];
            var assessmentDate = DateTime.Parse(@case.ExpectedForecast.AssessmentDate);
            var service = new PatientSeriesService();
            return service.IsValidSeries(assessmentDate, profile, series);
        }
    }
}
