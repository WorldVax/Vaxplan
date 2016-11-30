using System.Collections.Generic;

namespace Vaxplan.Testcases
{
    public class ExpectedForecast
    {
        public string AssessmentDate { get; set; }
        public string DateAdded { get; set; }
        public string DateUpdated { get; set; }
        public string EarliestDate { get; set; }
        public string EvaluationTestType { get; set; }
        public int ForecastNumber { get; set; }
        public string ForecastTestType { get; set; }
        public string PastDueDate { get; set; }
        public string RecommendedDate { get; set; }
        public string VaccineGroup { get; set; }
    }

    public class AdministeredDose
    {
        public string Cvx { get; set; }
        public string DateAdministered { get; set; }
        public string EvaluationReason { get; set; }
        public string EvaluationStatus { get; set; }
        public string Mvx { get; set; }
        public string VaccineName { get; set; }
    }

    public class PatientProfile
    {
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string MedHistoryCode { get; set; }
        public string MedHistoryCodeSys { get; set; }
        public string MedHistoryText { get; set; }
        public List<AdministeredDose> Series { get; set; }
    }


    public class Testcase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ExpectedForecast ExpectedForecast { get; set; }
        public PatientProfile PatientProfile { get; set; }
    }
}
