using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalGoldInvestment
{
    public class GoldTransaction : DigitalGoldTransaction
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///  CheckTodaysGoldProfit is used to check selling gold is profitable or not, if profitable then how much percantage
        /// </summary>
        /// <param name="todaysGoldPrice"></param>
        /// <param name="previousInvestment"></param>
        /// <param name="accumalatedGoldPerGrams"></param>
        /// <param name="sellGoldGrams"></param>
        /// <param name="profit"></param>
        /// <param name="profitPercentage"></param>
        public override void CheckCurrentGoldProfit(int todaysGoldPrice, int previousInvestment, double accumalatedGold, double sellGold, out bool profit,out double profitPercentage)
        {
            try
            {
                log.Info("Entering into the Function CheckTodaysGoldProfit");

                double remainingGram = accumalatedGold - sellGold;
                double calculatedSellingCommission = sellingPricePerGram * remainingGram;
                double netCalculatedAmount = previousInvestment - calculatedSellingCommission;

                log.Debug("In CheckTodaysGoldProfit , netCalculatedAmount is {0}" + netCalculatedAmount);

                profit = (todaysGoldPrice > netCalculatedAmount) ? true : false;
                profitPercentage = (todaysGoldPrice -  netCalculatedAmount) /100;              

            }
            catch (Exception ex)
            {
                log.Error("Error in the function CheckTodaysGoldProfit"+ ex.Message.ToString(),ex);
                throw ex;
            }
            
            

        }

        /// <summary>
        /// CurrentSell method is used to sell the Gold today with todays gold price
        /// </summary>
        /// <param name="accumlatedGold"></param>
        /// <param name="goldPrice"></param>
        /// <param name="sellGoldGrams"></param>
        /// <returns></returns>
        public override double CurrentSellingTransaction(double accumlatedGold, int goldPrice, double sellGoldGrams)
        {
            try
            {
                log.Info("Entering into the fuction CurrentInvestment");
                
                double calculatedAmount = goldPrice * sellGoldGrams;

                log.Debug("In CurrentSell function {0}" + calculatedAmount);

                double sellingCommission = sellGoldGrams * sellingPricePerGram;
                double netcalculatedAmount = calculatedAmount - sellingCommission;                               
                return netcalculatedAmount;
            }
            catch(Exception ex)
            {
                log.Info("Error in the function CurrentInvestment"+ ex.Message.ToString(), ex);
                throw ex;
            }

        }

        /// <summary>
        /// PreviousInvestment is the method to invest the money in Gold
        /// </summary>
        /// <param name="perGramPrice"></param>
        /// <param name="purchaseGoldAmount"></param>
        /// <returns></returns>
        public override double PreviousInvestment(int perGramPrice, int purchaseGoldAmount)
        {
            try
            {
                log.Info("Entering into the fuction PreviousInvestment");

                double calculatedGST = purchaseGoldAmount * gst / 100;
                double amountInvested =  purchaseGoldAmount - calculatedGST;

                log.Debug("In PreviousInvestment function {0}" + amountInvested);

                double goldCredited = amountInvested / perGramPrice;
                double goldinvestedCredited = double.Parse(goldCredited.ToString("0.00"));                
                return goldinvestedCredited;
                
            }
            catch(Exception ex)
            {
                log.Info("Error in the function PreviousInvestment"+ ex.Message.ToString(), ex);
                throw ex;
            }
        }


    }
}
