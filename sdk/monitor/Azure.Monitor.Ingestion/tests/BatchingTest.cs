// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Castle.Core.Resource;

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

        [TestCaseSource(nameof(GetValidateBatchThresholdCases))]
        public void ValidateBatchThresholds((int MiddleItemSize, string[] BatchDefinitions, int MaxSerializedItem) testCase)
        {
            var (middleItemSize, expectedBatchIds, maxSerializedItem) = testCase;

            middleItemSize += LogsIngestionClient.SingleUploadThreshold;
            maxSerializedItem += LogsIngestionClient.SingleUploadThreshold;

            // when calculating length of serialized object, we subtract "{\"X\":""\}".Length = 8 from the intended item size
            var entries = new[]
            {
                new Dictionary<char, string>{ { 'A', new string('a', 20 - 8)} },
                new Dictionary<char, string>{ { 'B', new string('b', middleItemSize - 8)} },
                new Dictionary<char, string>{ { 'C', new string('c', 10 - 8)} },
            };

            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(entries).ToArray();
            Assert.AreEqual(expectedBatchIds.Length, x.Length);
            foreach (var (expectedBatch, batch) in expectedBatchIds.Zip(x, ValueTuple.Create))
            {
                CollectionAssert.AreEqual(
                    expectedBatch.AsEnumerable(),
                    batch.Logs.Cast<Dictionary<char, string>>().Select(x => x.Single().Key));
            }

            Assert.AreEqual(maxSerializedItem, x.Max(b => b.LogsData.ToMemory().Length));
        }

        public static IEnumerable<(int MiddleItemSizeOffset, string[] BatchDefinitions, int MaxSerializedItemOffset)> GetValidateBatchThresholdCases()
        {
            const int ItemASize = 20;
            const int ItemBSize = 10;

            // An array of items to serialize has the cumulative size of the sum of each item's serialized size plus:
            // - two chars for brackets
            // - one char for each element but the first, for the comma

            // the size of A+B is three less than the max, so serialized as an array it meets the exact upper bound
            yield return (-(ItemASize + 3), new[] { "AB", "C" }, 0); // Items 1+2, 3

            // even one more character in them forces A to be yielded before B is added, so B and C are together
            yield return (-(ItemASize + 2), new[] { "A", "BC" }, -ItemASize + ItemBSize + 1);

            // This tests the special case where a single item, serialized as an array, reaches the max size.
            // It is then yielded immediately by itself, without also yielding the previous items.
            yield return (-2, new[] { "B", "AC" }, 0); // Items 2, 1+3

            // This serves as a control on the previous case, that only when the item reaches the max size is it yielded
            // "Out of turn"
            yield return (-3, new[] { "A", "B", "C" }, -1); // Items 1, 2, 3
        }

        public class ValidateBatchThresholdCase
        {
            public Dictionary<char, string>[] ItemsToSerialize { get; }

            public List<string>[] ExpectedBatchIds { get; }

            public int ExpectedMaxSerializedItemSize { get; }


            public ValidateBatchThresholdCase(Dictionary<char, string>[] itemsToSerialize, List<string>[] expectedBatchIds, int expectedMaxSerializedItemSize)
            {
                ItemsToSerialize = itemsToSerialize;
                ExpectedBatchIds = expectedBatchIds;
                ExpectedMaxSerializedItemSize = expectedMaxSerializedItemSize;
            }

        }

        /*
         Size tests:
          21, 1000, 12 -> 1024, 14
          21, 1001, 12 -> 23, 1016
          21, 1021, 12 -> 23, 1023, 14
          21, 1022, 12 -> 1024, 36
         */
    }
}
