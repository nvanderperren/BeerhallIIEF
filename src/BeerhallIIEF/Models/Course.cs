using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerhallIIEF.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int? Credits { get; set; }
        public string Title { get; set; }
        public Language Language { get; set; }

        public Course() { }

        public Course(string title, Language language) : this()
        {
            Title = title;
            Language = language;
        }
    }
    


}
