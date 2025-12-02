

namespace Checkpoint_3
{
    abstract class CompanyAsset
    {

        protected CompanyAsset(string ModelName, decimal PriceInUSD, DateTime PurchaseDate, CompanyOffice Office)
        {
            this.ModelName = ModelName;
            this.PriceInUSD = PriceInUSD;
            this.PurchaseDate = PurchaseDate;
            this.Office = Office;
        }
        public string ModelName { get; set; }
        public decimal PriceInUSD { get; set; }

        public CompanyOffice Office { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PriceInLocalCurrency { get; } = 0;

        public decimal GetPriceInLocalCurrency(decimal ExchangeRate)
        {
            return PriceInLocalCurrency * ExchangeRate;
        }
    }
}
