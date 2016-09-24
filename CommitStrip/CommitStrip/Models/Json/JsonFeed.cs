using Newtonsoft.Json;

namespace CommitStrip.Core.Model.JsonModel
{
    public class JsonFeed
    {
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("author")]
        public string author { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }
    }
}