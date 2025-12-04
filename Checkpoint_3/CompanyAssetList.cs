

namespace Checkpoint_3
{
    public class CompanyAssetList
    {
        // Variable declarations
        public List<CompanyAsset> Assets { get; private set; } = new List<CompanyAsset>();
        public List<CompanyAsset> SortedAssets { get; private set; } = new List<CompanyAsset>();

        // LINQ query to sort the assets by office location and purchase date
        //    SortedAssets = allAssets
        //        .OrderBy(asset => asset.Office)
        //        .ThenBy(asset => asset.PurchaseDate)
        //        .ToList();

        // Method to add a product to the list
        public string AskForUserInput(List<CompanyOffice> Offices)
        {
            while (true)
            {
                /* Start of Enter a new asset loop */
                Console.WriteLine("\nStart by choosing which Company Office inventory you would like to add the new product to:");
                Console.WriteLine("Office 1: New York | Office 2: London | Office 3: Stockholm");

                string UserInput = InputHelper.GetValidatedStringInput("Office Number", new List<string> { "1", "2", "3" }, out bool isQuit);

                var SelectedOffice = Offices.Find(o => o.OfficeId == UserInput);

                if (isQuit)
                {
                    DisplayListOfAssets();
                    Console.WriteLine("Exiting application, no Company Assets added.");
                    return "Q";
                }

                if (UserInput == "1") AddCompanyAsset(Offices[0]);
                if (UserInput == "2") AddCompanyAsset(Offices[1]);
                if (UserInput == "3") AddCompanyAsset(Offices[2]);

            }
        }

        public void AddCompanyAsset(CompanyOffice Office)
        {

            CompanyAsset NewAsset;

            Console.WriteLine($"\nCompany Office {Office.Location}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("You can quit at any point by entering \"Q\"");
            Console.WriteLine("\nWhich kind of Company Asset would you like to add?");
            Console.WriteLine("1. Computer | 2. Mobile ");

            string Category = InputHelper.GetValidatedStringInput("Category", new List<string> { "Computer", "Mobile", "1", "2" }, out bool isQuit);
            if (isQuit) return;
            string BrandName = InputHelper.GetValidatedStringInput("Brand Name", out isQuit);
            if (isQuit) return;
            string ModelName = InputHelper.GetValidatedStringInput("Model Name", out isQuit);
            if (isQuit) return;
            DateTime PurchaseDate = InputHelper.GetValidatedDateTimeInput("Purchase Date", out isQuit);
            if (isQuit) return;

            // Get and validate product price
            decimal PriceInUSD = 0;
            decimal PriceInLocalCurrency = 0;
            bool isValidPrice = false;

            do
            {
                string PriceInUSDInput = InputHelper.GetValidatedStringInput("Price in USD", out isQuit);
                // Check for quit command
                if (isQuit)
                {
                    break;
                }
                isValidPrice = InputHelper.TryParseDecimal(PriceInUSDInput, out PriceInUSD);
                if (isValidPrice)
                {
                    PriceInLocalCurrency = Helper.GetPriceInLocalCurrency(PriceInUSD, Office.ExchangeRate);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid price entered. Please enter a valid decimal number.");
                    Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine("\nNew Company Asset added successfully:");
                Console.WriteLine($"{NewAsset.ModelName} {NewAsset.PriceInUSD}, {NewAsset.PriceInLocalCurrency}");
                Assets.Add(NewAsset);
            }


            //else // Mobile
            //{
            //    NewAsset = new Mobile
            //    {
            //        Office = 
            //        BrandName = BrandName,
            //        ModelName = ModelName,
            //        PurchaseDate = PurchaseDate,
            //        PriceInUSD = PriceInUSD
            //    };
            //}

            if (isQuit)
            {
                if (Assets.Count > 0)
                {
                    Console.WriteLine("\nExiting application, here is the list of Company Assets added:");
                    //foreach (var asset in Assets)
                    //{
                    //    Console.WriteLine(asset.GetAssetInfo());
                    //}
                }
                else
                {
                    Console.WriteLine("Exiting application, no Company Assets added.");
                }
                return;

            }

        }

        public static List<CompanyAsset> SortAssets(List<CompanyAsset> assets)
        {
            return assets
                .OrderBy(asset => asset.Office.Location)
                .ThenBy(asset => asset.PurchaseDate)
                .ToList();
        }

        public void DisplayListOfAssets()
        {
            SortedAssets = SortAssets(Assets);

            Console.WriteLine("\nList of Company Assets:");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"{"Type",-15}{"Brand",-15}{"Model",-12} {"Office",-12}{"Purchase Date",-15}{"Price in USD",-15}{"Currency",-15}{"Local price today",-15}");


            foreach (CompanyAsset asset in SortedAssets)
            {
                if (Helper.CalculateEndOfLife(asset.PurchaseDate) == "Red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{asset.GetType().Name,-15}{asset.BrandName,-15}{asset.ModelName,-12}{asset.Office.Location,-15}{asset.PurchaseDate.ToString("yyyy-MM-dd"),-15}{asset.PriceInUSD,-15}{asset.Office.CurrencyCode,-15}{asset.PriceInLocalCurrency,-15}");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (Helper.CalculateEndOfLife(asset.PurchaseDate) == "Yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{asset.GetType().Name,-15}{asset.BrandName,-15}{asset.ModelName,-12}{asset.Office.Location,-15}{asset.PurchaseDate.ToString("yyyy-MM-dd"),-15}{asset.PriceInUSD,-15}{asset.Office.CurrencyCode,-15}{asset.PriceInLocalCurrency,-15}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else Console.WriteLine($"{asset.GetType().Name,-15}{asset.BrandName,-15}{asset.ModelName,-12}{asset.Office.Location,-15}{asset.PurchaseDate.ToString("yyyy-MM-dd"),-15}{asset.PriceInUSD,-15}{asset.Office.CurrencyCode,-15}{asset.PriceInLocalCurrency,-15}");
            }
        }
    }
}
