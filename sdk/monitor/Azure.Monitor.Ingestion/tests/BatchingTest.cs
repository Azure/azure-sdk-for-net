// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    public class BatchingTest
    {
        [Test]
        public void ValidateBatchingOneChunkNoGzip()
        {
            var entries = new List<BinaryData>();
            for (int i = 0; i < 10; i++)
            {
                entries.Add(BinaryData.FromObjectAsJson(new object[] {
                   new {
                        Time = i + "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                }));
            }

            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(entries).ToArray();
            Assert.AreEqual(1, x.Length);
            Assert.AreEqual(10, x[0].Logs.Count);
        }

        [Test]
        public void ValidateBatchingMultiChunkNoGzip()
        {
            var entries = new List<BinaryData>();
            for (int i = 0; i < 20000; i++)
            {
                entries.Add(BinaryData.FromObjectAsJson(new object[] {
                    new {
                        Time = i + "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                }));
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
            var entries = new List<BinaryData>()
            {
                BinaryData.FromObjectAsJson(new object[] {
                    new {
                        Time = "02021",
                        Computer = "Computer0",
                        AdditionalContext = 0
                    }
                }),
                BinaryData.FromObjectAsJson(new object[] {
                    new {
                        Time = "12021",
                        Computer = "Computer1",
                        AdditionalContext = 1
                    }
                }),
                BinaryData.FromObjectAsJson(new object[] {
                    new
                    {
                        Time = "22021",
                        Computer = "Computer2",
                        AdditionalContext = new string('2', LogsIngestionClient.SingleUploadThreshold + 1)
                    }
                })
            };

            if (hasItemAfterLargeItem)
            {
                entries.Add(BinaryData.FromObjectAsJson(new object[]
                {
                    new
                    {
                        Time = "32021",
                        Computer = "Computer3",
                        AdditionalContext = 3
                    }
                }));
            };

            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(entries).ToArray();
            Assert.AreEqual(2, x.Length);
            Assert.AreEqual(1, x[0].Logs.Count);
            Assert.AreEqual(hasItemAfterLargeItem ? 3 : 2, x[1].Logs.Count);
        }

        [TestCaseSource(nameof(GetValidateBatchThresholdCases))]
        public void ValidateBatchThreshold(ValidateBatchThresholdCase testCase)
        {
            LogsIngestionClient.BatchedLogs[] x = LogsIngestionClient.Batch(testCase.ItemsToExport).ToArray();
            Assert.AreEqual(testCase.ExpectedBatchIds.Length, x.Length);
            foreach (var (expectedBatch, batch) in testCase.ExpectedBatchIds.Zip(x, ValueTuple.Create))
            {
                CollectionAssert.AreEqual(
                    expectedBatch,
                    batch.Logs
                        .Select(log => ((BinaryData)log).ToObjectFromJson<Dictionary<string, string>>())
                        .Select(dict => dict.Single().Key));
            }

            Assert.AreEqual(testCase.ExpectedMaxSerializedItemSize, x.Max(b => b.LogsData.ToMemory().Length));
        }

        public static IEnumerable<ValidateBatchThresholdCase> GetValidateBatchThresholdCases()
        {
            // An array of items to serialize has the cumulative size of the sum of each item's serialized size plus:
            // - two chars for brackets
            // - one char for each element but the first, for the comma

            // the size of A+B is three less than the max, so serialized as an array it meets the exact upper bound
            yield return ValidateBatchThresholdCase.Generate(
                middleItemSizeOffset: -(ValidateBatchThresholdCase.ItemASize + 3),
                expectedBatchDefinitions: "AB|C",
                maxSerializedItemSizeOffset: 0);

            // even one more character in them forces A to be yielded before B is added, so B and C are together
            yield return ValidateBatchThresholdCase.Generate(
                middleItemSizeOffset: -(ValidateBatchThresholdCase.ItemASize + 2),
                expectedBatchDefinitions: "A|BC",
                maxSerializedItemSizeOffset: -ValidateBatchThresholdCase.ItemASize + ValidateBatchThresholdCase.ItemCSize + 1);

            // This tests the special case where a single item, serialized as an array, reaches the max size.
            // It is then yielded immediately by itself, without also yielding the previous items.
            yield return ValidateBatchThresholdCase.Generate(
                middleItemSizeOffset: -2,
                expectedBatchDefinitions: "B|AC",
                maxSerializedItemSizeOffset: 0); // Items 2, 1+3

            // This serves as a control on the previous case, that only when the item reaches the max size is it yielded
            // "Out of turn"
            yield return ValidateBatchThresholdCase.Generate(
                middleItemSizeOffset: -3,
                expectedBatchDefinitions: "A|B|C",
                maxSerializedItemSizeOffset: -1); // Items 1, 2, 3
        }

        public class ValidateBatchThresholdCase
        {
            public const int ItemASize = 20;
            public const int ItemCSize = 12;

            //write a string that reflects the builder parameters for easier debugging
            private string _testCaseStringRepresentation;

            public BinaryData[] ItemsToExport { get; private set; }

            public List<string>[] ExpectedBatchIds { get; private set; }

            public int ExpectedMaxSerializedItemSize { get; private set; }

            public override string ToString() => _testCaseStringRepresentation ?? base.ToString();

            public static ValidateBatchThresholdCase Generate(int middleItemSizeOffset, string expectedBatchDefinitions, int maxSerializedItemSizeOffset)
            {
                // when calculating length of serialized object, we subtract "{\"X\":""\}".Length = 8 from the intended item size
                // to determine the length of the string to generate
                int middleItemSize = LogsIngestionClient.SingleUploadThreshold + middleItemSizeOffset;
                var itemsToExport = new[]
                {
                    BinaryData.FromObjectAsJson(new Dictionary<string, string>{ { "A", new string('a', ItemASize - 8)} }),
                    BinaryData.FromObjectAsJson(new Dictionary<string, string>{ { "B", new string('b', middleItemSize - 8)} }),
                    BinaryData.FromObjectAsJson(new Dictionary<string, string>{ { "C", new string('c', ItemCSize - 8)} }),
                };

                // break apart the shorthand batch definitions into the dictionary keys expected in each batch
                var expectedBatchIds = expectedBatchDefinitions
                    .Split('|')
                    .Select(batchDefinition => batchDefinition.Select(c => c.ToString()).ToList())
                    .ToArray();

                var maxSerializedItemSize = LogsIngestionClient.SingleUploadThreshold + maxSerializedItemSizeOffset;

                return new ValidateBatchThresholdCase()
                {
                    ItemsToExport = itemsToExport,
                    ExpectedBatchIds = expectedBatchIds,
                    ExpectedMaxSerializedItemSize = maxSerializedItemSize,
                    _testCaseStringRepresentation = $"{nameof(ValidateBatchThresholdCase)}.{nameof(Generate)}({middleItemSizeOffset}, {expectedBatchDefinitions}, {maxSerializedItemSizeOffset})"
                };
            }
        }
    }
}
