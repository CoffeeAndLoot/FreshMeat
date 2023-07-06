using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using fmUI.Services;
using Microsoft.Win32;

namespace fmUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.InMemorySink.NewLogHandler += InMemorySink_Events;
        }

        private void InMemorySink_Events(object sender, EventArgs e)
        {
            var l = (App.LogEventArgs)e;
            var message = $"{l.Log.Timestamp:HH:mm:ss} [{l.Log.Level}] {l.Log.MessageTemplate.Text}";
            LogMessages.Items.Insert(0, message);
        }

        private void BtnSync_OnClick(object sender, RoutedEventArgs e)
        {
            var awakenedPoeTradeConfig = APoeTService.LoadAwakenedPoeTradeConfig(App.Settings);

            if (awakenedPoeTradeConfig == null) return;

            var beastWidget = APoeTService.AwakenedPoeTradeBeastSectionFindAndClear(awakenedPoeTradeConfig);

            var root = NinjaService.AcquireNinjaData(App.Settings);

            if (beastWidget != null)
            {
                APoeTService.ApplyNinjaBeastDataToAwakenedPoeTradeConfig(root, App.Settings, beastWidget);
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtAPoeTPath.Text = App.Settings.AwakenedPoeTrade.UserConfigPath;
            txtAPoeTAppPath.Text = App.Settings.AwakenedPoeTrade.AppPath;

            var settingsLeague = App.Settings.FreshMeatSettings.League;

            foreach (var league in App.Leagues.Where(w => w.id.Contains("SSF") == false))
            {
                CmbServerSelection.Items.Add(new ComboBoxItem
                {
                    Content = league.id, IsSelected = league.id == settingsLeague
                });
            }
        }

        private void btnAPoeTAppPath_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialogAPoeTAppPath = new OpenFileDialog()
            {
                InitialDirectory =
                    $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Programs\\Awakened PoE Trade\\",
                Filter = "EXE files (*.exe)|*.exe|All files (*.*)|*.*"
            };

            if (openFileDialogAPoeTAppPath.ShowDialog() == true)
            {
                txtAPoeTAppPath.Text = openFileDialogAPoeTAppPath.FileName;
            }
        }

        private void btnAPoeTPath_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialogAPoeTPath = new OpenFileDialog()
            {
                InitialDirectory =
                    $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\awakened-poe-trade\\apt-data\\",
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialogAPoeTPath.ShowDialog() == true)
            {
                txtAPoeTPath.Text = openFileDialogAPoeTPath.FileName;
            }
        }


        private async void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            App.Settings.FreshMeatSettings.League = ((ComboBoxItem)CmbServerSelection.SelectedItem).Content.ToString()!;
            await App.SaveSettings();
        }
    }
}
