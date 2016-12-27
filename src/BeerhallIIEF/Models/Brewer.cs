using System;

namespace BeerhallIIEF.Models
{
    public class Brewer
    {
        #region Properties
        public int BrewerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public DateTime? DateEstablished { get; set; }
        public string Street { get; set; }
        public int? Turnover { get; set; } 
        #endregion


    }
}
