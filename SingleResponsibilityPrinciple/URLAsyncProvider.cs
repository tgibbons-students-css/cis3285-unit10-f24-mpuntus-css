using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider : ITradeDataProvider
    {
        private ITradeDataProvider originalProvider;
        public URLAsyncProvider(ITradeDataProvider originalProvider)
        {
            this.originalProvider = originalProvider;
        }

        //public Task<IEnumerable<string>> GetTradeAsync()
        //{
        //    Task<IEnumerable<string>> task = Task.Run(() => originalProvider.GetTradeDataAsync());
        //    return task;
        //}


        //public IEnumerable<string> GetTradeData()
        //{
        //    Task<IEnumerable<string>> task = Task.Run(() => GetTradeAsync());
        //    //task.Wait();

        //    IEnumerable<string> tradeList = task.Result;
        //    return tradeList;
        //}

        public async Task<IEnumerable<string>> GetTradeDataAsync()
        {
            var tradeData = await originalProvider.GetTradeDataAsync();
            return tradeData;
        }
    }
}
