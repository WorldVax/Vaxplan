using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refdata.SupportingData;
using Vaxplan.Model;

namespace Vaxplan.Services
{
    public class PatientSeriesService
    {
        public bool IsValidSeries(DateTime assessmentDate, PatientProfile profile, antigenSupportingDataSeries series)
        {
            switch (series.seriesType)
            {
                case "Standard":
                    var seriesGender = series.requiredGender[0];
                    seriesGender = string.IsNullOrWhiteSpace(seriesGender) ? "F" : seriesGender;
                    return seriesGender == profile.Gender;
                case "Risk":
                    // TODO Add date checks to the select call.
                    return series.indication
                        .Select(x => x.observationCode.code == profile.MedHistoryCode)
                        .Aggregate(false, (x, y) => x || y);
                default:
                    throw new ArgumentException("Invalid series type.", "series");
            }
        }
    }

}
