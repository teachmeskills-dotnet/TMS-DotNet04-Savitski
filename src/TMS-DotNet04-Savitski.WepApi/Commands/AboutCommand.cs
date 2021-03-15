using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Resources;

namespace TMS_DotNet04_Savitski.WepApi.Commands
{
    public class AboutCommand : ITelegramCommand
    {
        public string Name => About.Link;

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, About.Message);
        }

        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}