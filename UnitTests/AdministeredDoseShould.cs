using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vaxplan;
using System.Linq;
using Vaxplan.Model;

namespace Vaxplan.UnitTests
{
    /// <summary>
    /// Summary description for AdministeredDoseShould
    /// </summary>
    [TestClass]
    public class AdministeredDoseShould
    {
        public AdministeredDoseShould()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            var series = CaseLibrary.Testcases["2013-0010"].PatientProfile.Series;
            var a = series.Select(x => new Series { Cvx = x.Cvx, DateAdministered = x.DateAdministered, Mvx = x.Mvx, VaccineName = x.VaccineName });
           // var b = AdministeredAntigenFactory.Prepare(a);
        }
    }
}
