namespace BeerhallIIEF.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? AlcoholByVolume { get; set; }
        public bool AlcoholKnown => AlcoholByVolume.HasValue;
        public decimal Price { get; set; }
        

        public Beer()
        {
            
        }

        public Beer(string name) : this()
        {
            Name = name;
        }
    }

   
}
