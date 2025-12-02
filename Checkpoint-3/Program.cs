/*
 * Checkpoint 3: Company Assets
 */

using Checkpoint_3;

List<CompanyAsset> ListOfAssets = new List<CompanyAsset>();
decimal ExchangeRateGBP = 0.0m;
decimal ExchangeRateSEK = 0.0m;

ExchangeRateClient Client = new ExchangeRateClient();

SpecificRates Rates = await Client.GetExchangeRatesWithBaseRateUSD();

List<CompanyOffice> ListOfOffices = new List<CompanyOffice>()
{
    new CompanyOffice("New York", "USD", 1.0m),
    new CompanyOffice("London", "GBP", Rates.GBPExchangeRate),
    new CompanyOffice("Stockholm", "SEK", Rates.SEKExchangeRate)
};

Console.WriteLine($"Base Currency: {Rates.BaseCurrency}");

foreach (var office in ListOfOffices)
{
    Console.WriteLine($"Office Location: {office.Location}, Currency: {office.Currency}, Exchange Rate to USD: {office.ExchangeRate}");
}