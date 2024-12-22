using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private ITradeDataProvider originalProvider;
        public AdjustTradeDataProvider(ITradeDataProvider originalProvider) 
        {
            this.originalProvider = originalProvider;
        }



        //public IEnumerable<string> GetTradeData()
        //{
        //    //throw new NotImplementedException();

        //    IEnumerable<string> lines = originalProvider.GetTradeDataAsync();

        //    List<string> result = new List<string>();

        //    foreach (string line in lines)
        //    {
        //        string newLine = line.Replace("GBP", "EUR");
        //        result.Add(newLine);
        //    }
        //    return lines;
        //}

        public async Task<IEnumerable<string>> GetTradeDataAsync()
        {
            IEnumerable<string> lines = await originalProvider.GetTradeDataAsync();

            // Adjust the trade data as needed
            List<string> result = new List<string>();

            foreach (string line in lines)
            {
                string newLine = line.Replace("GBP", "EUR");
                result.Add(newLine);
            }

            return result;
        }
    }
}
