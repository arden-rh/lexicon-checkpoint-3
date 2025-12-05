/*
 * Checkpoint 3: Company Assets
 */

using Checkpoint_3;

// Variable declarations
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

// Welcome message
Console.WriteLine("Welcome to the Company Asset Management System");
Console.WriteLine("===============================================");
Helper.PrintStatementInColor("To enter a new Company Asset - follow the steps | To quit - enter: \"Q\"", ConsoleColor.DarkYellow);

/* Main loop */
while (true)
{
    // Ask the user to name which office they want to add assets to and gather the asset information
    ListOfAssets.AskForUserInput(ListOfOffices);

    // Quit if no assets were added
    if (ListOfAssets.Assets.Count <= 0)
    {
        Console.WriteLine("----------------------------------------------------------");
        Helper.PrintStatementInColor("The application was closed before any products were added.", ConsoleColor.Red);
        break;
    }

    // Display the list of added assets
    ListOfAssets.DisplayListOfAssets();

    // Ask the user if they want to add more assets
    Helper.PrintStatementInColor("\nWould you like to add more Company Assets? (Y/N): ", ConsoleColor.DarkYellow, false);
    UserInput = Console.ReadLine().Trim();

    // Define boolean variables for clarity in the validation loop
    bool isInputEmpty = string.IsNullOrWhiteSpace(UserInput);
    bool isInputY = UserInput.Equals("Y", StringComparison.OrdinalIgnoreCase);
    bool isInputN = UserInput.Equals("N", StringComparison.OrdinalIgnoreCase);
    bool isInputQuit = InputHelper.IsQuitCommand(UserInput);

    bool isInputValid = isInputY || isInputN || isInputQuit;

    // Input validation loop
    while (isInputEmpty || !isInputValid)
    {
        if (isInputEmpty) Helper.PrintStatementInColor("Input cannot be empty. Please enter Y/N: ", ConsoleColor.Red, false);
        else Helper.PrintStatementInColor("Invalid input. Please enter Y/N: ", ConsoleColor.Red, false);

        UserInput = Console.ReadLine().Trim();

        isInputEmpty = string.IsNullOrWhiteSpace(UserInput);
        isInputValid = UserInput.Equals("Y", StringComparison.OrdinalIgnoreCase) ||
                       UserInput.Equals("N", StringComparison.OrdinalIgnoreCase) ||
                       InputHelper.IsQuitCommand(UserInput);
    }

    // Exit the application if the user inputs 'N' or 'Q'
    if (InputHelper.IsQuitCommand(UserInput) || UserInput.Equals("N", StringComparison.OrdinalIgnoreCase))
    {
        Helper.PrintStatementInColor("\nExiting the application. Thank you for using the Company Asset Management System!", ConsoleColor.DarkCyan);
        break;
    }

    // Explicitly state that the loop should continue for readability
    if (UserInput.Equals("Y", StringComparison.OrdinalIgnoreCase)) continue;
}