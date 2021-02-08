using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Resources;
using TMS_DotNet04_Savitski.WepApi.Services;

namespace TMS_DotNet04_Savitski.WepApi.Commands
{
    public class Myfin_MinskCommand : ITelegramCommand
    {
        public string Name => Myfin_Minsk.Link;

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IMyfinParse parseService = new MyfinParse();
            var rates = await parseService.RatesMinskParse();
            var chatId = message.Chat.Id;

            foreach (var rate in rates)
            {
                await client.SendTextMessageAsync(chatId, $"{rate.BankName}\n Покупка доллара: {rate.BankBuyUSD}\n Продажа доллара: {rate.BankSellUSD}\n Покупка евро: {rate.BankBuyEUR}\n Продажа евро: {rate.BankSellEUR}\n Покупка российских рублей (за 100 рублей): {rate.BankBuyRUS}\n Продажа российских рублей (за 100 рублей): {rate.BankSellRUS}");
            }
        }
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);

    }
}
