using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using fmUI.Models.GGG;
using Newtonsoft.Json;
using Serilog;

namespace fmUI.Services;

public static class PoEApiService
{
    public static async Task<List<League>> AcquireGGGLeagueData()
    {
        try
        {
            using var client = new HttpClient();
            var response = client.GetAsync("https://api.pathofexile.com/leagues").Result;
            var content = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<List<League>>(content);
            if (root != null)
            {
                return root;
            }

            Log.Error("GGG api data could not be acquired.");
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return new List<League>();
        }

        return new List<League>();
    }
}
