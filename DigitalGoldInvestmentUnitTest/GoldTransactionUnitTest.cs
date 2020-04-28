using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalGoldInvestment;

namespace DigitalGoldInvestmentUnitTest
{
    [TestClass]
    public class GoldTransactionUnitTest
    {


        [TestMethod]
        public void DigitalPreviousInvestmentTest()
        {
             DigitalGoldTransaction digitalGoldInvestment = new GoldTransaction();
             double previousInvest =  digitalGoldInvestment.PreviousInvestment(3200, 3000);

            Assert.AreEqual(previousInvest, 0.89);
        }

        [TestMethod]
        public void DigitalCurrentSellingTransactionTest()
        {
            DigitalGoldTransaction digitalGoldInvestment = new GoldTransaction();
            double CurrentSellInvest = digitalGoldInvestment.CurrentSellingTransaction(22.5, 3250,15.75);
            Assert.AreEqual(CurrentSellInvest, 49612.50);
        }

        [TestMethod]
        public void CheckTodaysGoldProfitTest()
        {
            DigitalGoldTransaction digitalGoldInvestment = new GoldTransaction();
            digitalGoldInvestment.CheckCurrentGoldProfit(3250, 2850, 22.5,15.75,out bool profit,out double profitPercentage);
            string checkMsg = profit == true ? "Selling Gold Today is profitable" : "Selling Gold Today is not profitable";
            string percentageMsg = profit == true ? string.Format("The percentage of profit is {0}",profitPercentage)  : string.Format("The percentage of loss is {0} ",profitPercentage);
            Assert.AreEqual(profit,true, checkMsg);
            Assert.AreEqual(profitPercentage, 10.75,percentageMsg );
        }
    }
}
