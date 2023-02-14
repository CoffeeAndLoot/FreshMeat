namespace FreshMeat.Services;

public static class NinjaService
{
    public static async Task<NinjaResponse?> AcquireNinjaBeastData(SettingsModel? userSettings)
    {
        try
        {
            using var client = new HttpClient();
            if (userSettings != null)
            {
                var response = await client.GetAsync(userSettings.Ninja.BeastApiUrl);
                var content = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<NinjaResponse>(content);
                if (root != null)
                {
                    return root;
                }

                Log.Error("Ninja Beast data could not be acquired.");
                return null;
            }

            Log.Error("User settings are null and could not be applied to Ninja Beast data.");
            return null;
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return null;
        }
    }
}
