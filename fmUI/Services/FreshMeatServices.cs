using System;
using System.IO;
using System.Threading.Tasks;
using fmUI.Models.App;
using Newtonsoft.Json;
using Serilog;

namespace fmUI.Services;

public static class FreshMeatServices
{
    private static readonly string FreshMeatSettingsPath =
        $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\FreshMeat";

    public static async Task<SettingsModel?> LoadUserSettings()
    {
        try
        {
            var settings = new SettingsModel();
            //check if settings file exists, if not create it
            if (!File.Exists(FreshMeatSettingsPath + "\\settings.json"))
            {
                var newSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
                //create settings file
                Directory.CreateDirectory(FreshMeatSettingsPath);
                await File.WriteAllTextAsync(FreshMeatSettingsPath + "\\settings.json", newSettings);
                Log.Information("FreshMeat settings file created.");
            }

            //read settings file
            var settingsJson = FreshMeatSettingsPath + "\\settings.json";
            var settingsJsonText = await File.ReadAllTextAsync(settingsJson);
            Log.Debug("FreshMeat settings file read.");
            settings = JsonConvert.DeserializeObject<SettingsModel>(settingsJsonText);
            return settings;
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return null;
        }
    }

    public static void ResetFreshMeatSettings()
    {
        try
        {
            if (!File.Exists(FreshMeatSettingsPath + "\\settings.json")) return;
            File.Delete(FreshMeatSettingsPath + "\\settings.json");
            Log.Information("FreshMeat settings file deleted.");
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    public static async Task SaveUserSettings(SettingsModel? settings)
    {
        try
        {
            var newSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
            await File.WriteAllTextAsync(FreshMeatSettingsPath + "\\settings.json", newSettings);
            Log.Information("FreshMeat settings file saved.");
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }
}
