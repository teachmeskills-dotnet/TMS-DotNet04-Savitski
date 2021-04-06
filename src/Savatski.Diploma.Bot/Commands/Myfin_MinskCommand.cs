using Savatski.Diploma.Bot.Interfaces;
using Savatski.Diploma.Bot.Models;
using Savatski.Diploma.Bot.Resources;
using Savatski.Diploma.Bot.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Savatski.Diploma.Bot.Commands
{
    public class Myfin_MinskCommand : ITelegramCommand
    {
        public string Name => Myfin_Minsk.Link;

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            IMyFinParse parseService = new MyFinParse();
            var rates = await parseService.RatesMinskParse();
            var chatId = message.Chat.Id;
            foreach (var rate in rates)
            {
                await client.SendTextMessageAsync(chatId, $"Имя банка: {rate.BankName}\nEUR : Продажа - {rate.BankSellEUR} Покупка - {rate.BankBuyEUR}\n" +
                    $"USD: Продажа - {rate.BankSellUSD} Покупка - {rate.BankBuyUSD}\nRUB : Продажа - {rate.BankSellRUS} Покупка - {rate.BankBuyRUS}\n");
            }
        }

        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);

        public IEnumerable<BankCurrencesOnMyfin> ratesBuyUSD(List<BankCurrencesOnMyfin> rates)
        {
            yield return rates.OrderByDescending(x => x.BankBuyUSD).FirstOrDefault();
        }

        public IEnumerable<BankCurrencesOnMyfin> ratesSellUSD(List<BankCurrencesOnMyfin> rates)
        {
            yield return rates.OrderBy(x => x.BankSellUSD).FirstOrDefault();
        }

        public IEnumerable<BankCurrencesOnMyfin> ratesBuyEUR(List<BankCurrencesOnMyfin> rates)
        {
            yield return rates.OrderBy(x => x.BankBuyEUR).FirstOrDefault();
        }

        public IEnumerable<BankCurrencesOnMyfin> ratesSellEUR(List<BankCurrencesOnMyfin> rates)
        {
            yield return rates.OrderBy(x => x.BankSellEUR).FirstOrDefault();
        }

        public IEnumerable<BankCurrencesOnMyfin> ratesBuyRUS(List<BankCurrencesOnMyfin> rates)
        {
            yield return rates.OrderBy(x => x.BankBuyRUS).FirstOrDefault();
        }

        public IEnumerable<BankCurrencesOnMyfin> ratesSellRUS(List<BankCurrencesOnMyfin> rates)
        {
            yield return rates.OrderBy(x => x.BankSellRUS).FirstOrDefault();
        }
    }
}