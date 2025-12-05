/* Mobile Asset */

namespace Checkpoint_3
{
    internal class Mobile : CompanyAsset
    {
        public Mobile(string BrandName, string ModelName, DateTime PurchaseDate, decimal PriceInUSD, decimal PriceInLocalCurrency, CompanyOffice Office) : base(BrandName, ModelName, PurchaseDate, PriceInUSD, PriceInLocalCurrency, Office)
        {
        }
    }
}
