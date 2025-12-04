/*
 * Checkpoint 3: Company Assets
 */

using Checkpoint_3;

CompanyAssetList ListOfAssets = new CompanyAssetList();
string UserInput;

// Initializing the client to get exchange rates
ExchangeRateClient Client = new ExchangeRateClient();

SpecificRates Rates = await Client.GetExchangeRatesWithBaseRateUSD();

// Creating a list of Company Offices and populate it with the fetched exchange rates
List<CompanyOffice> ListOfOffices = new List<CompanyOffice>()
{
    new CompanyOffice("1", "New York", "USD", 1.0m),
    new CompanyOffice("2", "London", "GBP", Rates.GBPExchangeRate),
    new CompanyOffice("3", "Stockholm", "SEK", Rates.SEKExchangeRate)
};

Console.WriteLine("Welcome to the Company Asset Management System");
Console.WriteLine("=======================================================");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To enter a new Company Asset - follow the steps | To quit - enter: \"Q\"");
Console.ForegroundColor = ConsoleColor.White;

while (true)
{

    UserInput = ListOfAssets.AskForUserInput(ListOfOffices);

    if (ListOfAssets.Assets.Count > 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The application was closed before any products were added.");
        Console.ForegroundColor = ConsoleColor.White;
        break;
    }

    /* Process user commands */
    // Check for quit command
    if (InputHelper.IsQuitCommand(UserInput))
    {
        break;
    }

}