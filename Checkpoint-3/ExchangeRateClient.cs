/* Exchange Rate Client
 * Class to fetch exchange rates from an external API and provide specific rates.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Checkpoint_3
{
    public record class PartialRateResponse(
        [property: JsonPropertyName("base_code")] string BaseCode,
        [property: JsonPropertyName("rates")] Dictionary<string, decimal> Rates
    );

    public record SpecificRates(
        string BaseCurrency,
        decimal GBPExchangeRate,
        decimal SEKExchangeRate
    );

    public class ExchangeRateClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<SpecificRates> GetExchangeRatesWithBaseRateUSD()
        {
            try
            {
                var response = await client.GetAsync("https://open.er-api.com/v6/latest/USD");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    PartialRateResponse Result = JsonSerializer.Deserialize<PartialRateResponse>(jsonResponse);

                    decimal GBPRate = 0.0m;
                    decimal SEKRate = 0.0m;

                    if (Result.Rates.TryGetValue("GBP", out decimal GBPExchangeRate))
                    {

                        GBPRate = GBPExchangeRate;
                    }

                    if (Result.Rates.TryGetValue("SEK", out decimal SEKExchangeRate))
                    {

                        SEKRate = SEKExchangeRate;
                    }

                    return new SpecificRates(Result.BaseCode, GBPRate, SEKRate);
                }
                else
                {
                    Console.WriteLine("Failed to retrieve exchange rate data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return new SpecificRates("ERROR", 0.0m, 0.0m);
        }

    }
}

