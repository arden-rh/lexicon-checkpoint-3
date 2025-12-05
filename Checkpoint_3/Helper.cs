/* Helper */

/* This static class provides helper methods for formatting and displaying information. */


namespace Checkpoint_3
{
    public static class Helper
    {
        // Convert price from USD to local currency
        public static decimal GetPriceInLocalCurrency(decimal PriceInUSD, decimal ExchangeRate)
        {
            if (ExchangeRate == 1.0m)
            {
                return PriceInUSD;
            }
            else
            {
                decimal PriceInLocalCurrency = PriceInUSD * ExchangeRate;
                return Math.Round(PriceInLocalCurrency, 2);
            }
        }

        // Format string input
        public static string FormatStringInput(string Input)
        {
            Input = Input.ToLower();
            return char.ToUpper(Input[0]) + Input.Substring(1);
        }

        // Calculate end of life status
        public static string CalculateEndOfLife(DateTime AssetPurchaseDate)
        {
            DateTime EndOfLifeDate = AssetPurchaseDate.AddYears(3);
            DateTime Now = DateTime.Now;
            TimeSpan TimeUntilEndOfLife = EndOfLifeDate - Now;

            // Determine if EndOfLifeDate is within the next 3 or 6 months
            bool IsLessThanThreeMonthsAway = EndOfLifeDate <= Now.AddMonths(3);
            bool IsLessThanSixMonthsAway = EndOfLifeDate <= Now.AddMonths(6);

            if (IsLessThanThreeMonthsAway)
            {
                return "ThreeMonths";
            }
            else if (IsLessThanSixMonthsAway)
            {
                return "SixMonths";
            }
            else
            {
                return null;
            }
        }

        // Print statement in color
        public static void PrintStatementInColor(string Statement, ConsoleColor Color, bool NewLine = true)
        {
            Console.ForegroundColor = Color;
            if (NewLine)
            {
                Console.WriteLine(Statement);
            }
            else
            {
                Console.Write(Statement);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
