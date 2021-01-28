using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Models;

namespace TMS_DotNet04_Savitski.WepApi.Services
{
    public class NbrbRates : INbrbRates
    {
        public async Task<List<Rates>> Rates()
        {
            IRequestService requestService = new RequestService();
            List<Rates> rates = new List<Rates>
            {
                await requestService.RatesNow("USD"),
                await requestService.RatesNow("EUR"),
                await requestService.RatesNow("RUB")
            };
            return rates;
        }
    }
}
