using System;
using System.Collections.Generic;

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
        public ICollection<Beer> Beers { get; private set; }
        public ICollection<Course> Courses { get; private set; } 
        #endregion

        public int NrOfBeers => Beers.Count;

        public Brewer()
        {
            Beers = new HashSet<Beer>();
            Courses = new HashSet<Course>();
        }

        public Brewer(string name) : this()
        {
            Name = name;
        }

    }
}
