
namespace Checkpoint_3
{
    public class CompanyOffice(string officeId, string location, string currencyCode, decimal exchangeRate)
    {

        public string OfficeId { get; set; } = officeId;
        public string Location { get; set; } = location;
        public string CurrencyCode { get; set; } = currencyCode;
        public decimal ExchangeRate { get; } = exchangeRate;

    }
}
