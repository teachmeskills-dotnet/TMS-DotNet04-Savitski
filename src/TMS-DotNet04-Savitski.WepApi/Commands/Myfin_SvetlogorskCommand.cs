using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Resources;
using TMS_DotNet04_Savitski.WepApi.Services;

namespace TMS_DotNet04_Savitski.WepApi.Commands
{
    public class Myfin_SvetlogorskCommand : ITelegramCommand
    {
        public string Name => Myfin_Svetlogorsk.Link;

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IMyfinParse parseService = new MyfinParse();
            var rates = await parseService.RatesSvetlogorskParse();
            var chatId = message.Chat.Id;
            foreach (var rate in rates)
            {
                await client.SendTextMessageAsync(chatId, $"Имя банка: {rate.BankName}, Покупка доллара: {rate.BankBuyUSD}, Продажа доллара: {rate.BankSellUSD}, Покупка евро: {rate.BankBuyEUR}, Продажа евро: {rate.BankSellEUR}, Покупка российских рублей (за 100 рублей): {rate.BankBuyRUS}, Продажа российских рублей (за 100 рублей): {rate.BankSellRUS}");
            }
        }
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);

    }
}
