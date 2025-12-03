/*
 * Checkpoint 3: Company Assets
 */

using Checkpoint_3;

List<CompanyAsset> ListOfAssets = new List<CompanyAsset>();

// Initializing the client to get exchange rates
ExchangeRateClient Client = new ExchangeRateClient();

SpecificRates Rates = await Client.GetExchangeRatesWithBaseRateUSD();

// Creatin a list of Company Offices and populate it with the fetched exchange rates
List<CompanyOffice> ListOfOffices = new List<CompanyOffice>()
{
    new CompanyOffice("New York", "USD", 1.0m),
    new CompanyOffice("London", "GBP", Rates.GBPExchangeRate),
    new CompanyOffice("Stockholm", "SEK", Rates.SEKExchangeRate)
};

Console.WriteLine("Welcome to the Company Asset Management System");
Console.WriteLine("=============================================");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To enter a new Company Asset - follow the steps | To quit - enter: \"Q\"");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nStart by choosing which Company Office inventory you would like to add the new product to:");
Console.WriteLine("Office 1: New York | Office 2: London | Office 3: Stockholm");
Console.Write("Choose by typing the number of the office (1, 2, 3): ");
string UserInput = Console.ReadLine();

if (UserInput == "Q")
{
    Console.WriteLine("Exiting application, no Company Assets added.");
}

if (UserInput == "1")
{
    Console.WriteLine("\nCompany Office New York");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("\nYou can quit at any point by entering \"Q\"");
    Console.WriteLine("Which kind of Company Asset would you like to add?");
    Console.WriteLine("1. Computer | 2. Mobile ");
    Console.Write("\nChoose by typing the number OR entering the category: ");
    UserInput = Console.ReadLine();
    if (UserInput == "Q")
    {
        Console.WriteLine("Exiting application, no Company Assets added.");
    }

}