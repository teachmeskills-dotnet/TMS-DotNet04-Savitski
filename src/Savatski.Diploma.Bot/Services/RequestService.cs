using Flurl;
using Flurl.Http;
using Savatski.Diploma.Bot.Helper;
using Savatski.Diploma.Bot.Interfaces;
using Savatski.Diploma.Bot.Models;
using System;
using System.Threading.Tasks;

namespace Savatski.Diploma.Bot.Services
{
    public class RequestService : IRequestService
    {
        public async Task<Rates> RatesNow(string name)
        {
            try
            {
                return await Constans.UrlToNBRB
                    .AppendPathSegments("exrates", "rates", name)
                    .SetQueryParams(new
                    {
                        parammode = 2
                    })
                    .GetJsonAsync<Rates>();
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Время ожидания запроса истекло");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}