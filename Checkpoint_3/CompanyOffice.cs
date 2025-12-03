
namespace Checkpoint_3
{
    public class CompanyOffice(string location, string currency, decimal exchangeRate)
    {

        public string Location { get; set; } = location;
        public string Currency { get; set; } = currency;
        public decimal ExchangeRate { get; } = exchangeRate;

    }
}
