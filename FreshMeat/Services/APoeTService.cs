using System.Diagnostics;

namespace FreshMeat.Services;

public static class APoeTService
{
    //load AwakenedPoE Trade config file
    public static async Task<APoeTConfig?> LoadAwakenedPoeTradeConfig(SettingsModel? userSettings)
    {
        try
        {
            if (userSettings == null)
            {
                Log.Error("User settings are null and could not be applied to Awakened PoE Trade config.");
                return null;
            }

            CloseAwakenedPoeTrade();
            var aPoeTConfigJsonText = await File.ReadAllTextAsync(userSettings.AwakenedPoeTrade.UserConfigPath);
            var aPoeTConfig = JsonConvert.DeserializeObject<APoeTConfig>(aPoeTConfigJsonText);
            return aPoeTConfig;
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return new APoeTConfig();
        }
    }

    public static APoeTConfig? AwakenedPoeTradeBeastSectionFindAndClear(APoeTConfig awakenedPoeTradeConfig)
    {
        try
        {
            var beastWidget = awakenedPoeTradeConfig.Widgets.Find(x => x.WmTitle == "Beast");
            if (beastWidget == null)
            {
                //todo: add creating a new beast section
                Log.Error("Awakened PoE Trade Beast section not found.");
                return null;
            }

            beastWidget.Entries.Clear();
            Log.Debug("Awakened PoE Trade Beast section cleared.");
            return awakenedPoeTradeConfig;
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return null;
        }
    }

    private static async Task SaveAwakenedPoeTradeConfig(SettingsModel? userSettings, APoeTConfig aPoeTConfig)
    {
        try
        {
            if (userSettings == null)
            {
                Log.Error("User settings are null and could not be applied to Awakened PoE Trade config.");
                return;
            }

            var serializeObject = JsonConvert.SerializeObject(aPoeTConfig, Formatting.Indented);
            await File.WriteAllTextAsync(userSettings.AwakenedPoeTrade.UserConfigPath, serializeObject);
            var process = StartAwakenedPoeTrade(userSettings);
            if (process == null) Log.Error("Awakened PoE Trade process is null and could not be started.");
            Log.Debug("Awakened PoE Trade process started: {processId}.", process?.Id);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    public static async Task ApplyNinjaBeastDataToAwakenedPoeTradeConfig(NinjaResponse? ninjaResponse, SettingsModel? userSettings,
        APoeTConfig aPoeTConfig)
    {
        try
        {
            if (userSettings == null)
            {
                Log.Error("User settings are null and could not be applied to Awakened PoE Trade config.");
                return;
            }

            var lines = ninjaResponse.Lines;
            var initLineId = 1;
            foreach (var line in lines.Where(line => line.ChaosValue > userSettings.FreshMeatSettings.LowerLimit))
            {
                var beastWidget = aPoeTConfig.Widgets.Find(x => x.WmTitle == "Beast");
                beastWidget?.Entries.Add(new Entry
                {
                    Id = initLineId++,
                    Text = line.Name,
                    Name = line.Name + " " + (int)line.ChaosValue + "c",
                    Hotkey = null!
                });
            }

            await SaveAwakenedPoeTradeConfig(userSettings, aPoeTConfig);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    private static Process? StartAwakenedPoeTrade(SettingsModel? userSettings)
    {
        //start "Awakened PoE Trade.exe"
        try
        {
            return userSettings == null ? null : Process.Start(userSettings.AwakenedPoeTrade.AppPath);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return null;
        }
    }

    private static void CloseAwakenedPoeTrade()
    {
        //close all running processes of "Awakened PoE Trade.exe"
        try
        {
            Log.Debug("Closing Awakened PoE Trade.");
            foreach (var process in Process.GetProcessesByName("Awakened PoE Trade"))
            {
                Log.Debug("Closing Awakened PoE Trade process: {processId}.", process.Id);
                process.Kill();
            }
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }
}
