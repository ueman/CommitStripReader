using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommitStrip.Core.Model.JsonModel
{
    public class JsonRoot
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("feed")]
        public JsonFeed feed { get; set; }

        [JsonProperty("items")]
        public List<JsonItem> items { get; set; }
    }
}