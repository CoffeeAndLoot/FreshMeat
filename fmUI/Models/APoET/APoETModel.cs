using System.Collections.Generic;
using Newtonsoft.Json;

namespace fmUI.Models.APoET;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Anchor
    {
        [JsonProperty("pos")]
        public string Pos { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public class Entry
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hotkey")]
        public object Hotkey { get; set; }
    }

    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Maps
    {
        [JsonProperty("showNewStats")]
        public bool ShowNewStats { get; set; }

        [JsonProperty("selectedStats")]
        public List<SelectedStat> SelectedStats { get; set; }
    }

    public class APoeTConfig
    {
        [JsonProperty("configVersion")]
        public int ConfigVersion { get; set; }

        [JsonProperty("wikiKey")]
        public string WikiKey { get; set; }

        [JsonProperty("craftOfExileKey")]
        public string CraftOfExileKey { get; set; }

        [JsonProperty("overlayKey")]
        public string OverlayKey { get; set; }

        [JsonProperty("overlayBackground")]
        public string OverlayBackground { get; set; }

        [JsonProperty("overlayBackgroundExclusive")]
        public bool OverlayBackgroundExclusive { get; set; }

        [JsonProperty("overlayBackgroundClose")]
        public bool OverlayBackgroundClose { get; set; }

        [JsonProperty("itemCheckKey")]
        public string ItemCheckKey { get; set; }

        [JsonProperty("delveGridKey")]
        public object DelveGridKey { get; set; }

        [JsonProperty("restoreClipboard")]
        public bool RestoreClipboard { get; set; }

        [JsonProperty("showAttachNotification")]
        public bool ShowAttachNotification { get; set; }

        [JsonProperty("commands")]
        public List<object> Commands { get; set; }

        [JsonProperty("clientLog")]
        public string ClientLog { get; set; }

        [JsonProperty("gameConfig")]
        public string GameConfig { get; set; }

        [JsonProperty("windowTitle")]
        public string WindowTitle { get; set; }

        [JsonProperty("logLevel")]
        public string LogLevel { get; set; }

        [JsonProperty("hardwareAcceleration")]
        public bool HardwareAcceleration { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("stashScroll")]
        public bool StashScroll { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("realm")]
        public string Realm { get; set; }

        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("disableUpdateDownload")]
        public bool DisableUpdateDownload { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }

        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }
    }

    public class SelectedStat
    {
        [JsonProperty("matcher")]
        public string Matcher { get; set; }

        [JsonProperty("decision")]
        public string Decision { get; set; }
    }

    public class Widget
    {
        [JsonProperty("wmId")]
        public int WmId { get; set; }

        [JsonProperty("wmType")]
        public string WmType { get; set; }

        [JsonProperty("wmTitle")]
        public string WmTitle { get; set; }

        [JsonProperty("wmWants")]
        public string WmWants { get; set; }

        [JsonProperty("wmZorder")]
        public object WmZorder { get; set; }

        [JsonProperty("wmFlags")]
        public List<string> WmFlags { get; set; }

        [JsonProperty("anchor")]
        public Anchor Anchor { get; set; }

        [JsonProperty("alwaysShow")]
        public bool AlwaysShow { get; set; }

        [JsonProperty("chaosPriceThreshold")]
        public int? ChaosPriceThreshold { get; set; }

        [JsonProperty("showRateLimitState")]
        public bool? ShowRateLimitState { get; set; }

        [JsonProperty("apiLatencySeconds")]
        public int? ApiLatencySeconds { get; set; }

        [JsonProperty("collapseListings")]
        public string CollapseListings { get; set; }

        [JsonProperty("smartInitialSearch")]
        public bool? SmartInitialSearch { get; set; }

        [JsonProperty("lockedInitialSearch")]
        public bool? LockedInitialSearch { get; set; }

        [JsonProperty("activateStockFilter")]
        public bool? ActivateStockFilter { get; set; }

        [JsonProperty("hotkey")]
        public string Hotkey { get; set; }

        [JsonProperty("hotkeyHold")]
        public string HotkeyHold { get; set; }

        [JsonProperty("hotkeyLocked")]
        public string HotkeyLocked { get; set; }

        [JsonProperty("showSeller")]
        public string ShowSeller { get; set; }

        [JsonProperty("searchStatRange")]
        public int? SearchStatRange { get; set; }

        [JsonProperty("showCursor")]
        public bool? ShowCursor { get; set; }

        [JsonProperty("requestPricePrediction")]
        public bool? RequestPricePrediction { get; set; }

        [JsonProperty("maps")]
        public Maps Maps { get; set; }

        [JsonProperty("wikiKey")]
        public string WikiKey { get; set; }

        [JsonProperty("poedbKey")]
        public object PoedbKey { get; set; }

        [JsonProperty("craftOfExileKey")]
        public string CraftOfExileKey { get; set; }

        [JsonProperty("stashSearchKey")]
        public object StashSearchKey { get; set; }

        [JsonProperty("entries")]
        public List<Entry> Entries { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }
