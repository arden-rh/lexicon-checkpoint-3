/* Helper methods */

namespace Checkpoint_3
{
    internal class Helper
    {
        public static decimal GetPriceInLocalCurrency(decimal PriceInUSD, decimal ExchangeRate)
        {
            decimal PriceInLocalCurrency = PriceInUSD * ExchangeRate;
            return Math.Round(PriceInLocalCurrency, 2);
        }

        // Format string input
        public static string FormatStringInput(string Input)
        {
            Input = Input.ToLower();
            return char.ToUpper(Input[0]) + Input.Substring(1);
        }

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
                return "Red";
            }
            else if (IsLessThanSixMonthsAway)
            {
                return "Yellow";
            }
            else
            {
                return "White";
            }
        }
    }
}
