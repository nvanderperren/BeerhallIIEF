using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerhallIIEF.Models
{
    public class BrewerCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrewerId { get; set; }
        public Brewer Brewer { get; set; }

        protected BrewerCategory() { }

        public BrewerCategory(Brewer brewer, Category category) : this()
        {
            Brewer = brewer;
            BrewerId = brewer.BrewerId;

            Category = category;
            CategoryId = category.CategoryId;
        }
    }

    
}
