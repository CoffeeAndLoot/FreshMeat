namespace FreshMeat.Models;

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("translations")]
        public Translations Translations { get; set; }
    }

    public class Line
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("baseType")]
        public string BaseType { get; set; }

        [JsonProperty("itemClass")]
        public int ItemClass { get; set; }

        [JsonProperty("sparkline")]
        public Sparkline Sparkline { get; set; }

        [JsonProperty("lowConfidenceSparkline")]
        public LowConfidenceSparkline LowConfidenceSparkline { get; set; }

        [JsonProperty("implicitModifiers")]
        public List<object> ImplicitModifiers { get; set; }

        [JsonProperty("explicitModifiers")]
        public List<object> ExplicitModifiers { get; set; }

        [JsonProperty("flavourText")]
        public string FlavourText { get; set; }

        [JsonProperty("chaosValue")]
        public double ChaosValue { get; set; }

        [JsonProperty("exaltedValue")]
        public double ExaltedValue { get; set; }

        [JsonProperty("divineValue")]
        public double DivineValue { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("detailsId")]
        public string DetailsId { get; set; }

        [JsonProperty("listingCount")]
        public int ListingCount { get; set; }
    }

    public class LowConfidenceSparkline
    {
        [JsonProperty("data")]
        public List<object> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

public class NinjaResponse
    {
        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }
    }

    public class Sparkline
    {
        [JsonProperty("data")]
        public List<object> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }

    public class Translations
    {
    }
