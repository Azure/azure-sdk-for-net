// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Azure.Monitor.Ingestion.Tests
{
    public class BatchingTest
    {
        [Test]
        public void ValidateBatchingOneChunkNoGzip()
        {
            var entries = new List<IEnumerable>();
            for (int i = 0; i < 10; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            IEnumerable<LogsIngestionClient.BatchedLogs> x = LogsIngestionClient.Batch(entries);
            Assert.AreEqual(1, x.Count());
            Assert.AreEqual(10, x.First().Logs.Count);
        }

        [Test]
        public void ValidateBatchingMultiChunkNoGzip()
        {
            var entries = new List<IEnumerable>();
            for (int i = 0; i < 20000; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = i + "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            IEnumerable<LogsIngestionClient.BatchedLogs> x = LogsIngestionClient.Batch(entries);
            int count = x.Count();
            Assert.Greater(count, 1); //ideally should be 2 batches
            Assert.Less(count, 3);
            Assert.Greater(x.First().Logs.Count, 10000);
            Assert.Less(x.ToList()[1].Logs.Count, 10000);
        }
    }
}
