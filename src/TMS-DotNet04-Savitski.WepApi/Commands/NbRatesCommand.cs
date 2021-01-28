using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Resources;
using TMS_DotNet04_Savitski.WepApi.Services;

namespace TMS_DotNet04_Savitski.WepApi.Commands
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
                await client.SendTextMessageAsync(chatId,$"{rate.Cur_Name} - {rate.Cur_OfficialRate} белорусских рублей");
            }
        }

        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);

    }
}
