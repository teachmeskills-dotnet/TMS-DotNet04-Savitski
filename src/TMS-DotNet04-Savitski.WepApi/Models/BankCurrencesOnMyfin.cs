using System.Collections.Generic;


namespace TMS_DotNet04_Savitski.WepApi.Models
{
    public class BankCurrencesOnMyfin
    {
        public string BankName { get; set; }
        public double BankBuyUSD { get; set; }
        public double BankSellUSD { get; set; }
        public double BankBuyEUR { get; set; }
        public double BankSellEUR { get; set; }
        public double BankBuyRUS { get; set; }
        public double BankSellRUS { get; set; }

        public BankCurrencesOnMyfin AddCurrences(List<string> values)
        {
            BankCurrencesOnMyfin rates = new BankCurrencesOnMyfin();

            rates.BankName = values[0];
            rates.BankBuyUSD = double.Parse(values[1]);
            rates.BankSellUSD = double.Parse(values[2]);
            rates.BankBuyEUR = double.Parse(values[3]);
            rates.BankSellEUR = double.Parse(values[4]);
            rates.BankBuyRUS = double.Parse(values[5]);
            rates.BankSellRUS = double.Parse(values[6]);
            return rates;
        }
    }
}
