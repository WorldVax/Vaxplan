using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vaxplan.Date;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class DateShould
    {
        [TestMethod]
        public void ParseAPositiveInterval()
        {
            var i = Interval.Parse("1 Week").FirstOrDefault();
            Assert.AreEqual(1, i.Value);
            Assert.AreEqual(Intervals.Week, i.Unit);
        }

        [TestMethod]
        public void ParseANegativeInterval()
        {
            var i = Interval.Parse("- 1 Week").FirstOrDefault();
            Assert.AreEqual(-1, i.Value);
            Assert.AreEqual(Intervals.Week, i.Unit);
        }


        [TestMethod]
        public void ParseALowercaseInterval()
        {
            var i = Interval.Parse("1 week").FirstOrDefault();
            Assert.AreEqual(1, i.Value);
            Assert.AreEqual(Intervals.Week, i.Unit);
        }

        [TestMethod]
        public void ParseAPluralInterval()
        {
            var i = Interval.Parse("1 weeks").FirstOrDefault();
            Assert.AreEqual(1, i.Value);
            Assert.AreEqual(Intervals.Week, i.Unit);
        }

        [TestMethod]
        public void ParseAMultipleIntervals()
        {
            var intervals = Interval.Parse("3 months - 1 week").ToList();
            Assert.AreEqual(2, intervals.Count);
            Assert.AreEqual(Intervals.Week, intervals[1].Unit);
        }

        [TestMethod]
        public void AddIntervalsToADate()
        {
            var target = new DateTime(2000, 3, 25);
            var startDt = new DateTime(2000, 1, 1);
            var intervals = Interval.Parse("3 months - 1 week");
            var endDate = startDt.Adjust(intervals);
            Assert.AreEqual(target, endDate);
        }
    }
}
