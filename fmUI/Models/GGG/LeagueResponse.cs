using System;
using Newtonsoft.Json;

namespace fmUI.Models.GGG;

public class League
{
    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("realm")]
    public string realm { get; set; }

    [JsonProperty("url")]
    public string url { get; set; }

    [JsonProperty("startAt")]
    public DateTime? startAt { get; set; }

    [JsonProperty("endAt")]
    public DateTime? endAt { get; set; }

    [JsonProperty("description")]
    public string description { get; set; }

    [JsonProperty("registerAt")]
    public DateTime registerAt { get; set; }

    [JsonProperty("delveEvent")]
    public bool delveEvent { get; set; }

    // [JsonProperty("rules")]
    // public List<Rule> rules { get; set; }

    [JsonProperty("timedEvent")]
    public bool? timedEvent { get; set; }
}


// public class Rule
// {
//     [JsonProperty("id")]
//     public string id { get; set; }
//
//     [JsonProperty("name")]
//     public string name { get; set; }
//
//     [JsonProperty("description")]
//     public string description { get; set; }
// }
