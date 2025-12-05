/* Exchange Rate Client
 * Class to fetch exchange rates from an external API and provide specific rates.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Checkpoint_3
{

    // Record to hold partial rate response from the API
    public record PartialRateResponse(
        [property: JsonPropertyName("base_code")] string BaseCode,
        [property: JsonPropertyName("rates")] Dictionary<string, decimal> Rates
    );

    // Record to hold specific exchange rates
    public record SpecificRates(
        string BaseCurrency,
        decimal GBPExchangeRate,
        decimal SEKExchangeRate
    );

    public class ExchangeRateClient
    {
        private static readonly HttpClient client = new HttpClient();

        // Default rates in case of API failure
        public static readonly SpecificRates DefaultRates = new SpecificRates("USD", 0.75m, 9.41m);

        public async Task<SpecificRates> GetExchangeRatesWithBaseRateUSD()
        {
            try
            {
                var response = await client.GetAsync("https://open.er-api.com/v6/latest/USD");

                if (response.IsSuccessStatusCode)
                {
                    string JsonResponse = await response.Content.ReadAsStringAsync();
                    PartialRateResponse Result = JsonSerializer.Deserialize<PartialRateResponse>(JsonResponse);

                    Result.Rates.TryGetValue("GBP", out decimal GBPRate);
                    Result.Rates.TryGetValue("SEK", out decimal SEKRate);

                    // Return the successfully fetched rates
                    return new SpecificRates(Result.BaseCode, GBPRate, SEKRate);

                }
                else
                {
                    // Log the unsuccessful response HTTP status code
                    Console.WriteLine($"API Request failed with status code: {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the API call
                Console.WriteLine($"An error occurred while fetching rates: {ex.Message}");
            }

            // Return default rates in case of failure
            return DefaultRates;
        }

    }
}

