/* Computer Asset */

namespace Checkpoint_3
{
    internal class Computer : CompanyAsset
    {
        public Computer(string BrandName, string ModelName, DateTime PurchaseDate, decimal PriceInUSD, decimal PriceInLocalCurrency,  CompanyOffice Office) : base(BrandName, ModelName, PurchaseDate, PriceInUSD, PriceInLocalCurrency, Office)
        {
        }
    }
}
