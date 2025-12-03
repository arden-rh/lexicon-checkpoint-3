

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
        public void AddCompanyAsset()
        {
            while (true)
            {
                /* Start of Enter a new asset loop */
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

            }
        }
    }
}
