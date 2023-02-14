namespace FreshMeat.Models;

public class SettingsModel
{
    public AwakenedPoeTrade AwakenedPoeTrade { get; set; } = new();
    public Ninja Ninja { get; set; } = new();
    public FreshMeatSettings FreshMeatSettings { get; set; } = new();
}

public class AwakenedPoeTrade
{
    [JsonProperty("appPath")]
    public string AppPath { get; set; } =
        $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Programs\\Awakened PoE Trade\\Awakened PoE Trade.exe";

    [JsonProperty("userConfigPath")]
    public string UserConfigPath { get; set; } =
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\awakened-poe-trade\\apt-data\\config.json";
}

public class Ninja
{
    [JsonProperty("beastApiUrl")]
    public string BeastApiUrl { get; set; } = "https://poe.ninja/api/data/itemoverview?league=Sanctum&type=Beast";
}

public class FreshMeatSettings
{
    [JsonProperty("currency")]
    public Currency Currency { get; set; } = Currency.Chaos;

    [JsonProperty("lowerLimit")]
    public int LowerLimit { get; set; } = 10;

    [JsonProperty("upperLimit")]
    public int UpperLimit { get; set; } = 0;

    [JsonProperty("maxResults")]
    public int MaxResults { get; set; } = 0;
}

public enum Currency { Chaos, Exalted, Divine }
