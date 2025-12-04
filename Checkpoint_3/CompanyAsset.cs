

namespace Checkpoint_3
{
    public abstract class CompanyAsset
    {

        protected CompanyAsset(string brandName, string modelName, DateTime purchaseDate, decimal priceInUSD, decimal priceInLocalCurrency, CompanyOffice office)
        {
            this.BrandName = brandName;
            this.ModelName = modelName;
            this.PurchaseDate = purchaseDate;
            this.PriceInUSD = priceInUSD;
            this.PriceInLocalCurrency = priceInLocalCurrency;
            this.Office = office;
        }

        public CompanyOffice Office { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PriceInUSD { get; set; }
        public decimal PriceInLocalCurrency { get; set; }

    }
}
