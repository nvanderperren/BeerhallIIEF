using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerhallIIEF.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<BrewerCategory> BCategory { get; private set; }

        public IEnumerable<Brewer> Brewers
        {
            get { return BCategory.Select(b => b.Brewer); }
        } 

        protected Category()
        {
            BCategory = new HashSet<BrewerCategory>();
        }

        public Category(string name) : this()
        {
            Name = name;
        }

        public void Add(Brewer b)
        {
            BCategory.Add(new BrewerCategory(b, this));
        }
    }


}
