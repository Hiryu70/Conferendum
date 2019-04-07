using Newtonsoft.Json;

namespace Conferendum.Models
{
    public sealed class Info
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}