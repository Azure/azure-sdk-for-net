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
                        Time = i + "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }

            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(entries).ToArray();
            Assert.AreEqual(1, x.Length);
            Assert.AreEqual(10, x[0].Logs.Count);
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

            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(entries).ToArray();
            Assert.AreEqual(2, x.Length);
            Assert.Greater(x[0].Logs.Count, 10000);
            Assert.Less(x[1].Logs.Count, 10000);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ValidateBatchingWithLargeItemNoGzip(bool hasItemAfterLargeItem)
        {
            var entries = new List<IEnumerable>()
            {
                new Object[] {
                    new {
                        Time = "02021",
                        Computer = "Computer0",
                        AdditionalContext = 0
                    }
                },
                    new Object[] {
                    new {
                        Time = "12021",
                        Computer = "Computer1",
                        AdditionalContext = 1
                    }
                },
                new Object[]
                {
                    new
                    {
                        Time = "22021",
                        Computer = "Computer2",
                        AdditionalContext = new string('2', LogsIngestionClient.SingleUploadThreshold + 1)
                    }
                }
            };

            if (hasItemAfterLargeItem)
            {
                entries.Add(new Object[]
                {
                    new
                    {
                        Time = "32021",
                        Computer = "Computer3",
                        AdditionalContext = 3
                    }
                });
            };

            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(entries).ToArray();
            Assert.AreEqual(2, x.Length);
            Assert.AreEqual(1, x[0].Logs.Count);
            Assert.AreEqual(hasItemAfterLargeItem ? 3 : 2, x[1].Logs.Count);
        }
    }
}
