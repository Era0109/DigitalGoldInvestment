using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGoldInvestment
{
    public abstract class DigitalGoldTransaction
    {
        protected  const int gst = 5;
        protected int minimumPrice = Convert.ToInt32(ConfigurationManager.AppSettings["MinimumPrice"]);
        protected int maximumPrice = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumPrice"]);

        protected const int sellingPricePerGram = 100;



        public abstract double PreviousInvestment(int perGramPrice,int purchaseGoldAmount);
        public abstract double CurrentSellingTransaction(double accumlatedGold, int goldPrice, double sellGoldGrams);
        public abstract void CheckCurrentGoldProfit(int todaysGoldPrice, int previousInvestment, double accumalatedGold, double sellGold,out bool profit,out double profitPercentage);

    }
}
