using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommitStrip.Core.Models.JsonModel
{
    public class JsonItem
    {
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("guid")]
        public string guid { get; set; }

        [JsonProperty("pubdate")]
        public string pubDate { get; set; }

        [JsonProperty("categories")]
        public List<string> categories { get; set; }

        [JsonProperty("author")]
        public string author { get; set; }

        [JsonProperty("thumbnail")]
        public string thumbnail { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("content")]
        public string content { get; set; }
    }
}