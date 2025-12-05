/* Company Asset List */

namespace Checkpoint_3
{
    public class CompanyAssetList
    {
        // Variable declarations
        public List<CompanyAsset> Assets { get; private set; } = new List<CompanyAsset>();
        public List<CompanyAsset> SortedAssets { get; private set; } = new List<CompanyAsset>();

        // I want to show additional text if the user is returning to the start of the loop,
        // which is why I have a bool to check if it's the user's First time seeing the message
        private bool _IsFirstTimeRunning = true;

        // Method to add a product to the list
        public void AskForUserInput(List<CompanyOffice> Offices)
        {

            while (true)
            {
                /* Start of Enter a new asset loop */
                Console.WriteLine($"\nChoose which Company Office inventory you would like to add the new product to {(!_IsFirstTimeRunning ? "or enter \"Q\" to quit (show list)" : "")}");
                Console.WriteLine($"-------------------------------------------------------------------------------{(!_IsFirstTimeRunning ? "---------------------------------" : "")}");
                Console.WriteLine("Office 1: New York | Office 2: London | Office 3: Stockholm");

                string UserInput = InputHelper.GetValidatedStringInputForField("Company Office", new List<string> { "1", "New York", "2", "London", "3", "Stockholm" }, out bool isQuit);

                if (isQuit)
                {
                    break;
                }

                // Depending on the user's input they start adding a new CompanyAsset to one of the three offices
                if (UserInput == "1" || UserInput == "New York") AddCompanyAsset(Offices[0]);
                if (UserInput == "2" || UserInput == "London") AddCompanyAsset(Offices[1]);
                if (UserInput == "3" || UserInput == "Stockholm") AddCompanyAsset(Offices[2]);

                _IsFirstTimeRunning = false;

            }
        }

        public void AddCompanyAsset(CompanyOffice Office)
        {

            CompanyAsset NewAsset;

            Console.WriteLine($"\nCompany Office {Office.Location}");
            Console.WriteLine("-------------------------");
            Helper.PrintStatementInColor("You can quit at any point by entering \"Q\"", ConsoleColor.DarkYellow);
            Console.WriteLine("\nWhich kind of Company Asset would you like to add?");
            Console.WriteLine("1. Computer | 2. Mobile ");

            string Category = InputHelper.GetValidatedStringInputForField("Category", new List<string> { "1", "Computer", "2", "Mobile" }, out bool isQuit);
            if (isQuit)
            {
                Helper.PrintStatementInColor("\nReturning to Company Office selection", ConsoleColor.DarkCyan);
                return;
            }

            string BrandName = InputHelper.GetValidatedStringInputForField("Brand Name", out isQuit);
            if (isQuit)
            {
                Helper.PrintStatementInColor("\nReturning to Company Office selection", ConsoleColor.DarkCyan);
                return;
            }

            string ModelName = InputHelper.GetValidatedStringInputForField("Model Name", out isQuit);
            if (isQuit)
            {
                Helper.PrintStatementInColor("\nReturning to Company Office selection", ConsoleColor.DarkCyan);
                return;
            }

            DateTime PurchaseDate = InputHelper.GetValidatedDateTimeInput("Purchase Date", out isQuit);
            if (isQuit)
            {
                Helper.PrintStatementInColor("\nReturning to Company Office selection", ConsoleColor.DarkCyan);
                return;
            }

            // Get and validate product price
            decimal PriceInUSD = 0;
            decimal PriceInLocalCurrency = 0;
            bool isValidPrice = false;

            do
            {
                string PriceInUSDInput = InputHelper.GetValidatedStringInputForField("Price in USD", out isQuit);
                // Check for quit command
                if (isQuit)
                {
                    break;
                }
                // Check if input is a valid decimal
                isValidPrice = InputHelper.TryParseDecimal(PriceInUSDInput, out PriceInUSD);
                if (isValidPrice)
                {
                    PriceInLocalCurrency = Helper.GetPriceInLocalCurrency(PriceInUSD, Office.ExchangeRate);
                }
                else
                {
                    Helper.PrintStatementInColor("Invalid price entered. Please enter a valid decimal number.", ConsoleColor.Red);
                }

            } while (!isValidPrice);

            if (isQuit) return;

            if (Category == "Computer" || Category == "1")
            {
                NewAsset = new Computer(
                    BrandName = Helper.FormatStringInput(BrandName),
                    ModelName = Helper.FormatStringInput(ModelName),
                    PurchaseDate,
                    PriceInUSD,
                    PriceInLocalCurrency,
                    Office
                );
                Helper.PrintStatementInColor("\nNew Company Asset added successfully.", ConsoleColor.Green);
                Assets.Add(NewAsset);
            }

            if (Category == "Mobile" || Category == "2")
            {
                NewAsset = new Mobile(
                    BrandName = Helper.FormatStringInput(BrandName),
                    ModelName = Helper.FormatStringInput(ModelName),
                    PurchaseDate,
                    PriceInUSD,
                    PriceInLocalCurrency,
                    Office
                );

                Helper.PrintStatementInColor("\nNew Company Asset added successfully.", ConsoleColor.Green);
                Assets.Add(NewAsset);
            }
        }

        // LINQ query to sort the assets by office location and purchase date
        public static List<CompanyAsset> SortAssets(List<CompanyAsset> assets)
        {
            return assets
                .OrderBy(asset => asset.Office.Location)
                .ThenBy(asset => asset.PurchaseDate)
                .ToList();
        }

        public void DisplayListOfAssets()
        {
            // Sort assets before presenting the list
            SortedAssets = SortAssets(Assets);

            Console.WriteLine("\nList of Company Assets:");
            Console.WriteLine("------------------------");
            Console.WriteLine($"{"Type",-15}{"Brand",-15}{"Model",-11} {"Office",-15}{"Purchase Date",-15}{"Price in USD",-15}{"Currency",-15}{"Local price today",-15}");
            Console.WriteLine($"{"----",-15}{"-----",-15}{"-----",-12}{"------",-15}{"-------------",-15}{"------------",-15}{"--------",-15}{"-----------------",-15}");

            // Loop through list, checking EndOfLife date and applying color as appropiate
            foreach (CompanyAsset asset in SortedAssets)
            {
                if (Helper.CalculateEndOfLife(asset.PurchaseDate) == "ThreeMonths")
                {
                    Helper.PrintStatementInColor($"{asset.GetType().Name,-15}{asset.BrandName,-15}{asset.ModelName,-12}{asset.Office.Location,-15}{asset.PurchaseDate.ToString("yyyy-MM-dd"),-15}{asset.PriceInUSD,-15}{asset.Office.CurrencyCode,-15}{asset.PriceInLocalCurrency,-15}", ConsoleColor.Red);
                }
                else if (Helper.CalculateEndOfLife(asset.PurchaseDate) == "SixMonths")
                {
                    Helper.PrintStatementInColor($"{asset.GetType().Name,-15}{asset.BrandName,-15}{asset.ModelName,-12}{asset.Office.Location,-15}{asset.PurchaseDate.ToString("yyyy-MM-dd"),-15}{asset.PriceInUSD,-15}{asset.Office.CurrencyCode,-15}{asset.PriceInLocalCurrency,-15}", ConsoleColor.Yellow);
                }
                else Console.WriteLine($"{asset.GetType().Name,-15}{asset.BrandName,-15}{asset.ModelName,-12}{asset.Office.Location,-15}{asset.PurchaseDate.ToString("yyyy-MM-dd"),-15}{asset.PriceInUSD,-15}{asset.Office.CurrencyCode,-15}{asset.PriceInLocalCurrency,-15}");
            }
        }
    }
}
