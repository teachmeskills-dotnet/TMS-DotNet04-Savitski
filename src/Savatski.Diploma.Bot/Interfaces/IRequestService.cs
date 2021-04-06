using Savatski.Diploma.Bot.Models;
using System.Threading.Tasks;

namespace Savatski.Diploma.Bot.Interfaces
{
    public interface IRequestService
    {
        Task<Rates> RatesNow(string name);
    }
}