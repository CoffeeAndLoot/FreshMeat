namespace FreshMeatTest;

public class APoeTServiceTests : IDisposable
{

    [Fact]
    public void Test_LoadAwakenedPoeTradeConfig()
    {
        var userSettings = new SettingsModel { AwakenedPoeTrade = { UserConfigPath = Path.GetTempPath() } };
        var aPoeTConfig = APoeTService.LoadAwakenedPoeTradeConfig(userSettings);
        Assert.NotNull(aPoeTConfig);
    }

    public void Dispose() { throw new NotImplementedException(); }
}
