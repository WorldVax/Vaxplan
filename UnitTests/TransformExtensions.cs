using System;
using System.Linq;
using Vaxplan.Model;
using Tests = Vaxplan.Testcases;

namespace Vaxplan.UnitTests
{
    public static class TransformExtensions
    {
        public static AdministeredDose ToModel(this Tests.AdministeredDose entity)
        {
            return new AdministeredDose
            {
                Cvx = entity.Cvx,
                DateAdministered = DateTime.Parse(entity.DateAdministered),
                Mvx = entity.Mvx,
                VaccineName = entity.VaccineName
            };
        }

        public static PatientProfile ToModel(this Tests.PatientProfile entity)
        {
            return new PatientProfile
            {
                Dob = DateTime.Parse(entity.Dob),
                Gender = entity.Gender,
                MedHistoryCode = entity.MedHistoryCode,
                MedHistoryCodeSys = entity.MedHistoryCodeSys,
                MedHistoryText = entity.MedHistoryText,
                Series = entity.Series.Select(x => x.ToModel()).ToList()
            };
        }
    }
}
