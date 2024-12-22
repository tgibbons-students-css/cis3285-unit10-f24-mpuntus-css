using Microsoft.Data.SqlClient;
using SingleResponsibilityPrinciple.Contracts;
using SingleResponsibilityPrinciple;
using System.Diagnostics;

namespace SingleResponsibilityPrinciple.Tests
{
    [TestClass()]
    public class URLTradeDataProviderTests
    {
        //private int countStrings(IEnumerable<string> collectionOfStrings)
        //{
        //    // count the trades
        //    int count = 0;
        //    foreach (var trade in collectionOfStrings)
        //    {
        //        count++;
        //    }
        //    return count;
        //}

        private async Task<int> CountStringsAsync(Task<IEnumerable<string>> collectionOfStrings)
        {
            // Count the trades asynchronously
            //IEnumerable<string> collectionOfStrings = await collectionOfStrings;
            int count = 0;
            foreach (var trade in await collectionOfStrings)
            {
                count++;
            }
            return count;
        }


        //[TestMethod()]
        //public void TestSize1()
        //{
        //    //Arrange
        //    ILogger logger = new ConsoleLogger();
        //    string tradeURL = "http://raw.githubusercontent.com/tgibbons-css/CIS3285_Unit9_F24/refs/heads/master/SingleResponsibilityPrinciple/trades.txt";

        //    ITradeDataProvider tradeProvider = new URLTradeDataProvider(tradeURL, logger);

        //    //Act
        //    IEnumerable<string> trades = tradeProvider.GetTradeDataAsync();

        //    //Assert

        //    Assert.AreEqual(countStrings(trades), 4);
        //}


        [TestMethod()]
        public async Task TestSize1()
        {
            //Arrange
            ILogger logger = new ConsoleLogger();
            string tradeURL = "http://raw.githubusercontent.com/tgibbons-css/CIS3285_Unit9_F24/refs/heads/master/SingleResponsibilityPrinciple/trades.txt";

            ITradeDataProvider tradeProvider = new URLTradeDataProvider(tradeURL, logger);

            //Act
            Task <IEnumerable<string> > trades = tradeProvider.GetTradeDataAsync();

            //Assert

            Assert.AreEqual(await CountStringsAsync(trades), 4);
        }

    }
}
