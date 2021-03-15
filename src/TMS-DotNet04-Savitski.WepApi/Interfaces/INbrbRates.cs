using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet04_Savitski.WepApi.Models;

namespace TMS_DotNet04_Savitski.WepApi.Interfaces
{
    public interface INbrbRates
    {
        public Task<List<Rates>> Rates();
    }
}