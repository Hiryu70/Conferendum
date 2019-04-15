using Newtonsoft.Json;

namespace Conferendum.Models
{
    public sealed class SectionEntry
    {
        public string Section { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }

        public Info GetInfo()
        {
            return new Info()
            {
                Name = Name,
                City = City,
                Location = Location
            };
        }
    }
}
