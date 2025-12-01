

namespace Checkpoint_3
{
    abstract class CompanyAsset(string ModelName, decimal Price, DateOnly PurchaseDate, string Currency)
    {
        public string ModelName { get; set; } = ModelName;
        public decimal Price { get; set; } = Price;

        public string Currency { get; set; } = Currency;
        public decimal PriceInUSD { get; set; } = 0;
        public DateOnly PurchaseDate { get; set; } = PurchaseDate;

        public decimal GetPriceInUSD(decimal ExchangeRate)
        {
            return Price * ExchangeRate;
        }
    }
}
