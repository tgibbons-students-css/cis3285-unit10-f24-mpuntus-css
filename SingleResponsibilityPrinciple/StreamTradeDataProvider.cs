﻿using System.Collections.Generic;
using System.IO;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        public StreamTradeDataProvider(Stream stream, ILogger logger)
        {
            this.stream = stream;
            this.logger = logger;
        }

        /*
        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            logger.LogInfo("Reading trades from file stream.");
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }
        */

        public Task<IEnumerable<string>> GetTradeDataAsync()
        {
            var tradeData = new List<string>();
            logger.LogInfo("Reading trades from file stream.");
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return Task.FromResult<IEnumerable<string>>(tradeData);
        }

        private readonly Stream stream;
        private readonly ILogger logger;
    }
}
