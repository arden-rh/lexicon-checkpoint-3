/*
 * Checkpoint 3: Company Assets
 */

using Checkpoint_3;

List<CompanyAsset> ListOfAssets = new List<CompanyAsset>();
List<CompanyOffice> ListOfOffices = new List<CompanyOffice>()
{
    new CompanyOffice("New York", "USD", 1.0m),
    new CompanyOffice("London", "GBP", 0.75m),
    new CompanyOffice("Stockholm", "SEK", 10.0m)
};

foreach(var office in ListOfOffices)
{
    Console.WriteLine($"Office Location: {office.Location}, Currency: {office.Currency}, Exchange Rate to USD: {office.ExchangeRate}");
}