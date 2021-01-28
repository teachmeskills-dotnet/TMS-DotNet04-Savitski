using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_DotNet04_Savitski.WepApi.Models;

namespace TMS_DotNet04_Savitski.WepApi.Interfaces
{
    public interface IMyfinParse
    {
        Task<List<BankCurrencesOnMyfin>> RatesMinskParse();
        Task<List<BankCurrencesOnMyfin>> RatesSvetlogorskParse();
    }
}
