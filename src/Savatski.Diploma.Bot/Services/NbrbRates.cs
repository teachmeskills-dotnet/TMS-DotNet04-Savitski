using Savatski.Diploma.Bot.Interfaces;
using Savatski.Diploma.Bot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Savatski.Diploma.Bot.Services
{
    public class NbrbRates : INbrbRates
    {
        public async Task<List<Rates>> Rates()
        {
            IRequestService requestService = new RequestService();
            List<Rates> rates = new()
            {
                await requestService.RatesNow("USD"),
                await requestService.RatesNow("EUR"),
                await requestService.RatesNow("RUB")
            };

            return rates;
        }
    }
}