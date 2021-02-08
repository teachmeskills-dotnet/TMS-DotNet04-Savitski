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
    }
}
