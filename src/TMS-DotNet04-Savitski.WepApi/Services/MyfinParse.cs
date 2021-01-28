using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Helper;
using Fizzler.Systems.HtmlAgilityPack;
using TMS_DotNet04_Savitski.WepApi.Models;

namespace TMS_DotNet04_Savitski.WepApi.Services
{
    public class MyfinParse : IMyfinParse
    {
        public async Task<List<BankCurrencesOnMyfin>> RatesMinskParse()
        {
            var rates = new List<BankCurrencesOnMyfin>();
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(Constans.UrlToMinskParse);
            var page = doc.DocumentNode.QuerySelectorAll(Constans.tableSelector);

            foreach (var item in page)
            {
                var values = new List<string>();

                foreach (var node in item.ChildNodes)
                {
                    if(node.Name == "td")
                    {
                        values.Add(node.InnerText.Replace("\n", "").Replace(".", ","));
                    }
                }
                var rate = new BankCurrencesOnMyfin();
                rate.AddCurrences(values);
                rates.Add(rate);
            }
            return rates;
        }

        public async Task<List<BankCurrencesOnMyfin>> RatesSvetlogorskParse()
        {
            var rates = new List<BankCurrencesOnMyfin>();
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(Constans.UrlToSvetlogorskParse);
            var page = doc.DocumentNode.QuerySelectorAll(Constans.tableSelector);

            foreach (var item in page)
            {
                var values = new List<string>();

                foreach (var node in item.ChildNodes)
                {
                    if(node.Name == "tr")
                    {
                        values.Add(node.InnerText.Replace("\n", "").Replace(".", ","));
                    }
                }
                var rate = new BankCurrencesOnMyfin();
                rate.AddCurrences(values);
                rates.Add(rate);
            }
            return rates;
        }
    }
}
