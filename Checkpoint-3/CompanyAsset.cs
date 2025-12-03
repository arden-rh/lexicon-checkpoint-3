

namespace Checkpoint_3
{
    public abstract class CompanyAsset
    {

        protected CompanyAsset(string modelName, decimal priceInUSD, DateTime purchaseDate, CompanyOffice office)
        {
            this.ModelName = modelName;
            this.PriceInUSD = priceInUSD;
            this.PurchaseDate = purchaseDate;
            this.Office = office;
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
