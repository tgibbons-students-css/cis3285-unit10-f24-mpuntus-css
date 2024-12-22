using Microsoft.Data.SqlClient;
using SingleResponsibilityPrinciple.Contracts;
using SingleResponsibilityPrinciple;
using System.Reflection;

namespace SingleResponsibilityPrinciple.Tests
{
    [TestClass()]
    public class StreamTradeDataProviderTests
    {
        /*
        private int countStrings(IEnumerable<string> collectionOfStrings)
        {
            // count the trades
            int count = 0;
            foreach (var trade in collectionOfStrings)
            {
                count++;
            }
            return count;
        }
        */
        private async Task<int> CountStringsAsync(Task<IEnumerable<string>> collectionOfStrings)
        {
            // Count the trades asynchronously
            int count = 0;
            foreach (var trade in await collectionOfStrings)
            {
                count++;
            }
            return count;
        }

        /*
        [TestMethod()]
        public TestSize1()
        {
            //Arrange
            ILogger logger = new ConsoleLogger();
            String fileName = "SingleResponsibilityPrincipleTests.trades_1good.txt";
            Stream tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

            ITradeDataProvider tradeProvider = new StreamTradeDataProvider(tradeStream, logger);

            //Act
            IEnumerable<string> trades = tradeProvider.GetTradeDataAsync();

            //Assert
 
            Assert.AreEqual(countStrings(trades), 1);
        }
        */


        [TestMethod()]
        public async Task TestSize1Async()
        {
            // Arrange
            ILogger logger = new ConsoleLogger();
            string fileName = "SingleResponsibilityPrincipleTests.trades_1good.txt";
            Stream tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

            ITradeDataProvider tradeProvider = new StreamTradeDataProvider(tradeStream, logger);

            // Act
            Task<IEnumerable<string>> trades = tradeProvider.GetTradeDataAsync();

            // Assert
            Assert.AreEqual(await CountStringsAsync(trades), 1);
        }

        /*
        [TestMethod()]
        public void TestSize5()
        {
            //Arrange
            ILogger logger = new ConsoleLogger();
            String fileName = "SingleResponsibilityPrincipleTests.trades_5good.txt";
            Stream tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

            ITradeDataProvider tradeProvider = new StreamTradeDataProvider(tradeStream, logger);

            //Act
            IEnumerable<string> trades = tradeProvider.GetTradeDataAsync();

            //Assert

            Assert.AreEqual(countStrings(trades), 5);
        }
        */

        [TestMethod()]
        public async Task TestSize5Async()
        {
            // Arrange
            ILogger logger = new ConsoleLogger();
            string fileName = "SingleResponsibilityPrincipleTests.trades_5good.txt";
            Stream tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

            ITradeDataProvider tradeProvider = new StreamTradeDataProvider(tradeStream, logger);

            // Act
            Task <IEnumerable<string>> trades = tradeProvider.GetTradeDataAsync();

            // Assert
            Assert.AreEqual(await CountStringsAsync(trades), 5);
        }


    }
}