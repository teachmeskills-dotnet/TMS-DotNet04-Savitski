using Flurl;
using Flurl.Http;

using System.Threading.Tasks;
using TMS_DotNet04_Savitski.WepApi.Helper;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Models;

namespace TMS_DotNet04_Savitski.WepApi.Services
{
    public class RequestService : IRequestService
    {
        public async Task<Rates> RatesNow(string name)
        {
            return await Constans.UrlToNBRB
              .AppendPathSegments("exrates", "rates", name)
              .SetQueryParams(new
              {
                  parammode = 2
              })
           .GetJsonAsync<Rates>();
        }
    }
}
