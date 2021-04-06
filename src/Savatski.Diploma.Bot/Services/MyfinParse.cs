using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Savatski.Diploma.Bot.Helper;
using Savatski.Diploma.Bot.Interfaces;
using Savatski.Diploma.Bot.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Savatski.Diploma.Bot.Services
{
    public class MyFinParse : IMyFinParse
    {
        public async Task<List<BankCurrencesOnMyfin>> RatesMinskParse()
        {
            var rates = new List<BankCurrencesOnMyfin>();
            var web = new HtmlWeb();

            try
            {
                var doc = await web.LoadFromWebAsync(Constans.UrlToMinskParse);
                var page = doc.DocumentNode.QuerySelectorAll(Constans.tableSelector);

                foreach (var item in page)
                {
                    var values = new List<string>();

                    foreach (var node in item.ChildNodes)
                    {
                        if (node.Name == "td")
                        {
                            values.Add(node.InnerText.Replace("\n", "").Trim());
                        }
                    }

                    rates.Add(new BankCurrencesOnMyfin
                    {
                        BankName = values[0],
                        BankBuyUSD = double.Parse(values[1]),
                        BankSellUSD = double.Parse(values[2]),
                        BankBuyEUR = double.Parse(values[3]),
                        BankSellEUR = double.Parse(values[4]),
                        BankBuyRUS = double.Parse(values[5]),
                        BankSellRUS = double.Parse(values[6]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rates;
        }

        public async Task<List<BankCurrencesOnMyfin>> RatesSvetlogorskParse()
        {
            var rates = new List<BankCurrencesOnMyfin>();
            var web = new HtmlWeb();

            try
            {
                var doc = await web.LoadFromWebAsync(Constans.UrlToSvetlogorskParse);
                var page = doc.DocumentNode.QuerySelectorAll(Constans.tableSelector);

                foreach (var item in page)
                {
                    var values = new List<string>();

                    foreach (var node in item.ChildNodes)
                    {
                        if (node.Name == "td")
                        {
                            values.Add(node.InnerText.Replace("\n", "").Trim());
                        }
                    }
                    rates.Add(new BankCurrencesOnMyfin
                    {
                        BankName = values[0],
                        BankBuyUSD = double.Parse(values[1]),
                        BankSellUSD = double.Parse(values[2]),
                        BankBuyEUR = double.Parse(values[3]),
                        BankSellEUR = double.Parse(values[4]),
                        BankBuyRUS = double.Parse(values[5]),
                        BankSellRUS = double.Parse(values[6]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rates;
        }
    }
}