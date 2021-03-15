using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Models;
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
                await client.SendTextMessageAsync(chatId, $"Имя банка: {rate.BankName}\nEUR : Продажа - {rate.BankSellEUR} Покупка - {rate.BankBuyEUR}\n" +
                    $"USD: Продажа - {rate.BankSellUSD} Покупка - {rate.BankBuyUSD}\nRUB : Продажа - {rate.BankSellRUS} Покупка - {rate.BankBuyRUS}\n");
            }
            //var keybord = InlineKeyboard.GenerateKeybord();
            //await client.SendTextMessageAsync(chatId, "Выберите, что именно вам нужно показать", ParseMode.Default, false, false, 0, keybord);
            //client.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
            //{
            //    var message = ev.CallbackQuery.Message;
            //    if (ev.CallbackQuery.Message.Text == "myCommand1")
            //    {
            //        foreach (var rate in rates)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{rate.BankName}\n Покупка | Продажа \nДоллар: {rate.BankBuyUSD} | {rate.BankSellUSD}\n Евро: {rate.BankBuyEUR} | {rate.BankSellEUR}\n Российский рубль (за 100 рублей): {rate.BankBuyRUS} | {rate.BankSellRUS}");
            //        }
            //    }
            //    else if (ev.CallbackQuery.Data == "myCommand2")
            //    {
            //        var rate = ratesBuyUSD(rates);
            //        foreach (var item in rate)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{item.BankName}\n Покупка: {item.BankBuyUSD}");
            //        }
            //    }
            //    else if (ev.CallbackQuery.Data == "myCommand3")
            //    {
            //        var rate = ratesSellUSD(rates);
            //        foreach (var item in rate)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{ item.BankName}\n Продажа: {item.BankSellUSD}");
            //        }
            //    }
            //    else if (ev.CallbackQuery.Data == "myCommand4")
            //    {
            //        var rate = ratesBuyEUR(rates);
            //        foreach (var item in rate)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{ item.BankName}\n Покупка: {item.BankBuyEUR}");
            //        }
            //    }
            //    else if (ev.CallbackQuery.Data == "myCommand5")
            //    {
            //        var rate = ratesSellEUR(rates);
            //        foreach (var item in rate)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{ item.BankName}\n Продажа: {item.BankSellEUR}");
            //        }
            //    }
            //    else if (ev.CallbackQuery.Data == "myCommand6")
            //    {
            //        var rate = ratesBuyRUS(rates);
            //        foreach (var item in rate)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{ item.BankName}\n Покупка: {item.BankBuyRUS}");
            //        }
            //    }
            //    else if (ev.CallbackQuery.Data == "myCommand7")
            //    {
            //        var rate = ratesSellRUS(rates);
            //        foreach (var item in rate)
            //        {
            //            await client.SendTextMessageAsync(message.Chat.Id, $"{ item.BankName}\n Продажа: {item.BankSellRUS}");
            //        }
            //    }
            //};
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