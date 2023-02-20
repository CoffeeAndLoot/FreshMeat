global using Serilog;
global using FreshMeat.Models;
global using FreshMeat.Services;
global using Newtonsoft.Json;

namespace FreshMeat;

public static class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        Log.Information("FreshMeat is starting up...");

        var userSettings = FreshMeatServices.LoadUserSettings();

        var awakenedPoeTradeConfig = APoeTService.LoadAwakenedPoeTradeConfig(userSettings);

        if (awakenedPoeTradeConfig != null && userSettings != null)
        {
            userSettings.FreshMeatSettings.League = awakenedPoeTradeConfig.LeagueId;

            var beastWidget = APoeTService.AwakenedPoeTradeBeastSectionFindAndClear(awakenedPoeTradeConfig);

            var root = NinjaService.AcquireNinjaData(userSettings);

            if (beastWidget != null)
            {
                APoeTService.ApplyNinjaBeastDataToAwakenedPoeTradeConfig(root, userSettings, beastWidget);
            }
        }

        Log.Information("FreshMeat is shutting down...");
        Log.CloseAndFlush();
    }
}
