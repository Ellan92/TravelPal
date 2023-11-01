using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class TravelDocument : PackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }

        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;
        }

        public TravelDocument()
        {

        }
        //public override string GetInfo()
        //{

        //}
    }
}
