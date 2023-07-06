using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using FreshMeat.Models.App;
using FreshMeat.Models.GGG;
using FreshMeat.Services;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace FreshMeat;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    internal static SettingsModel? Settings { get; set; } = new();
    internal static List<League> Leagues { get; set; } = new();
    internal new static MainWindow MainWindow { get; set; } = new();

    private async void App_Startup(object sender, StartupEventArgs e)
    {
        //setup serilog
        var statusMessages = new InMemorySink();
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Sink(statusMessages)
            .CreateLogger();


        // Load settings, and other startup operations
        await LoadSettings();
        await LoadLeagues();
        MainWindow.Show();

        //Get app version and set title with version
        MainWindow.AppTitle.Content = $"FreshMeat v0.1.0";
    }

    private async void App_Exit(object sender, ExitEventArgs e)
    {
        // Save settings, and other cleanup
        Log.Information("FreshMeat is exiting.");
        await Log.CloseAndFlushAsync();
    }

    internal static Task SaveSettings() => FreshMeatServices.SaveUserSettings(Settings);

    private static async Task LoadSettings()
    {
        Settings = await FreshMeatServices.LoadUserSettings();
    }

    private static async Task LoadLeagues()
    {
        Leagues = await PoEApiService.AcquireGGGLeagueData();

        if (Leagues.Count == 0)
        {
            Log.Error("Failed to load leagues from GGG API.");
        }
    }

    public class InMemorySink : ILogEventSink
    {
        public static event EventHandler? NewLogHandler;
        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            NewLogHandler?.Invoke(typeof(InMemorySink), new LogEventArgs() { Log = logEvent });
        }
    }

    public class LogEventArgs : EventArgs
    {
        public LogEvent Log { get; set; }
    }
}
