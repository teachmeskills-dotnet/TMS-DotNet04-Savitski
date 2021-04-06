using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Savatski.Diploma.Bot.Interfaces
{
    public interface ITelegramCommand
    {
        string Name { get; }

        Task Execute(Message message, ITelegramBotClient client);

        bool Contains(Message message);
    }
}