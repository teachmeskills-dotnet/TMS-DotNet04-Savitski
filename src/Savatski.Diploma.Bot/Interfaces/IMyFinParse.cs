using Savatski.Diploma.Bot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Savatski.Diploma.Bot.Interfaces
{
    public interface IMyFinParse
    {
        Task<List<BankCurrencesOnMyfin>> RatesMinskParse();

        Task<List<BankCurrencesOnMyfin>> RatesSvetlogorskParse();
    }
}