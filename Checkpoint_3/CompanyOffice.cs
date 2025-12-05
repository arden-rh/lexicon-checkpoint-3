/* Company Office */

namespace Checkpoint_3
{
    public class CompanyOffice(string officeId, string location, string currencyCode, decimal exchangeRate)
    {

        public string OfficeId { get; } = officeId;
        public string Location { get; } = location;
        public string CurrencyCode { get; } = currencyCode;
        public decimal ExchangeRate { get; } = exchangeRate;

    }
}
