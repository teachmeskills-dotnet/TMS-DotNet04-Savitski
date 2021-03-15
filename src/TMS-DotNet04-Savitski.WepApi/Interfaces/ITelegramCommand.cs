using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TMS_DotNet04_Savitski.WepApi.Interfaces
{
    public interface ITelegramCommand
    {
        string Name { get; }

        Task Execute(Message message, ITelegramBotClient client);

        bool Contains(Message message);
    }
}