using System;

namespace Vaxplan.Model
{
    public class AdministeredAntigen
    {
        public DateTime AdministeredDate {get;set;}
        public string Antigen { get; set; }
        public string Cvx { get; set; }
        public string Mvx { get; set; }
        public float Amount { get; set; }
        public string Tradename { get; set; }
        public DateTime LotExpirationDate { get; set; }
        public string DoseCondition { get; set; }
    }
}