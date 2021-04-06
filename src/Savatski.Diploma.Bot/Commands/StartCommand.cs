using Savatski.Diploma.Bot.Interfaces;
using Savatski.Diploma.Bot.Resources;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Savatski.Diploma.Bot.Commands
{
    public class StartCommand : ITelegramCommand
    {
        public string Name => Start.Link;

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, Start.Message);
        }

        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}