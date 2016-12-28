using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerhallIIEF.Models
{
    public class OnsiteCourse : Course
    {
        private DateTime _startDate;

        public TimeSpan? From { get; set; }
        public int NumberOfDays { get; set; }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (value <= DateTime.Today)
                    throw new ArgumentException("startdate must be in the future");
                _startDate = value;
            }
        }
        public TimeSpan? Till { get; set; }

        protected OnsiteCourse() { }

        public OnsiteCourse(string title, Language language, Brewer brewer, int numberOfDays, DateTime startDate)
            : this()
        {
            Title = title;
            Language = language;
            Brewer = brewer;
            NumberOfDays = numberOfDays;
            StartDate = startDate;
        }
    }
}
