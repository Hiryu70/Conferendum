using Newtonsoft.Json;

namespace Conferendum.Models
{
    public sealed class SectionEntry
    {
        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }
    }
}
