global using Serilog;
global using FreshMeat.Models;
global using FreshMeat.Services;
global using Newtonsoft.Json;
using Serilog.Exceptions;


namespace FreshMeat;

public class Program
{
    private static async Task Main(string[] args)
    {
        if (args.Any(w => w == "-debug"))
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug().Enrich.WithExceptionDetails().Enrich.FromLogContext().WriteTo.Console()
                .WriteTo.File(FreshMeatServices.FreshMeatSettingsPath + "\\logs\\FreshMeat.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit:30)
                .CreateLogger();

            Log.Debug("Debug mode enabled.");
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning().Enrich.WithExceptionDetails().Enrich.FromLogContext().WriteTo.Console()
            .WriteTo.File(FreshMeatServices.FreshMeatSettingsPath + "\\logs\\FreshMeat.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("FreshMeat is starting up...");


        if(args.Any(w=> w == "-reset"))
        {
            Log.Information("Resetting FreshMeat settings...");
            FreshMeatServices.ResetFreshMeatSettings();
        }

        //uninstall the settings and directory
        if(args.Any(w=> w == "-uninstall"))
        {
            Log.Information("Uninstalling FreshMeat...");
            FreshMeatServices.ResetFreshMeatSettings();
            Directory.Delete(FreshMeatServices.FreshMeatSettingsPath, true);
        }

        var userSettings = await FreshMeatServices.LoadUserSettings();

        var awakenedPoeTradeConfig = await APoeTService.LoadAwakenedPoeTradeConfig(userSettings);

        if (awakenedPoeTradeConfig != null)
        {
            var beastWidget = APoeTService.AwakenedPoeTradeBeastSectionFindAndClear(awakenedPoeTradeConfig);

            var root = await NinjaService.AcquireNinjaBeastData(userSettings);

            if (beastWidget != null)
            {
                await APoeTService.ApplyNinjaBeastDataToAwakenedPoeTradeConfig(root, userSettings, beastWidget);
            }
        }

        Console.ReadKey();

        Log.Information("FreshMeat is shutting down...");
        await Log.CloseAndFlushAsync();
    }
}
