using System.Net.Http.Headers;
using System.Web;

namespace FreshMeat.Services;

public static class NinjaService
{
    public static NinjaResponse? AcquireNinjaData(SettingsModel? userSettings)
    {
        try
        {
            using var client = new HttpClient();
            if (userSettings?.Ninja is { BaseUrl: { }, League: { }, Type: { } })

            {
                var uriBuilder = new UriBuilder(userSettings.Ninja.BaseUrl);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["league"] = userSettings.Ninja.League;
                query["type"] = userSettings.Ninja.Type;
                uriBuilder.Query = query.ToString();
                var response = client.GetAsync(uriBuilder.ToString()).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var root = JsonConvert.DeserializeObject<NinjaResponse>(content);
                if (root != null)
                {
                    return root;
                }

                Log.Error($"Ninja ${userSettings.Ninja.League} - ${userSettings.Ninja.Type} api data could not be acquired.");
                return null;
            }

            Log.Error("User settings are null and could not be applied to Ninja api request.");
            return null;
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return null;
        }
    }
}
