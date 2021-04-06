using Savatski.Diploma.Bot.Interfaces;
using Savatski.Diploma.Bot.Resources;
using Savatski.Diploma.Bot.Services;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Savatski.Diploma.Bot.Commands
{
    public class NbRateCommand : ITelegramCommand
    {
        public string Name => NbRates.Link;

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            INbrbRates nbrbRates = new NbrbRates();
            var chatId = message.Chat.Id;

            var rates = await nbrbRates.Rates();

            foreach (var rate in rates)
            {
                await client.SendTextMessageAsync(chatId, $"{rate.Cur_Name} - {rate.Cur_OfficialRate} белорусских рублей");
            }
        }

        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}