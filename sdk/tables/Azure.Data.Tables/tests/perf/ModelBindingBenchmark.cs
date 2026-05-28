// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Azure.Data.Tables.Performance
{
    [MemoryDiagnoser]
    public class ModelBindingBenchmark
    {
        private static readonly TestEntity FullEntity = new TestEntity
                {
                    PartitionKey = "partitionKeyValue",
                    RowKey = 7.ToString("D2"),
                    StringTypeProperty = $"This is table entity number 9",
                    DatetimeTypeProperty = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc),
                    DatetimeOffsetTypeProperty = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc),
                    GuidTypeProperty = new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{983:D4}"),
                    BinaryTypeProperty = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 },
                    Int64TypeProperty = 999,
                    DoubleTypeProperty = double.Parse($"{121323}.0"),
                    IntTypeProperty = 3,
                };
        private static readonly IDictionary<string, object> Serialized = new Dictionary<string, object>()
        {
            { "StringTypeProperty", "This is table entity number 01"},
            { "DatetimeTypeProperty", "2020-01-01T01:02:00.0000000Z"},
            { "DatetimeTypeProperty@odata.type", "Edm.DateTime"},
            { "DatetimeOffsetTypeProperty", "2020-01-01T01:02:00.0000000Z"},
            { "DatetimeOffsetTypeProperty@odata.type", "Edm.DateTime"},
            { "GuidTypeProperty", "0d391d16-97f1-4b9a-be68-4cc871f90001"},
            { "GuidTypeProperty@odata.type", "Edm.Guid"},
            { "BinaryTypeProperty", "AQIDBAU="},
            { "BinaryTypeProperty@odata.type", "Edm.Binary"},
            { "Int64TypeProperty", "1"},
            { "Int64TypeProperty@odata.type", "Edm.Int64"},
            { "DoubleTypeProperty", 1.4},
            { "DoubleTypeProperty@odata.type", "Edm.Double"},
            { "IntTypeProperty", 1},
            { "PartitionKey", "somPartition"},
            { "RowKey", "01" }
        };

        [Benchmark]
        public void Serialize()
        {
            FullEntity.ToOdataAnnotatedDictionary();
        }

        [Benchmark]
        public void Deserialize()
        {
            Serialized.ToTableEntity<TestEntity>();
        }

        public class TestEntity : ITableEntity
        {
            public string StringTypeProperty { get; set; }

            public DateTime DatetimeTypeProperty { get; set; }

            public DateTimeOffset DatetimeOffsetTypeProperty { get; set; }

            public Guid GuidTypeProperty { get; set; }

            public byte[] BinaryTypeProperty { get; set; }

            public long Int64TypeProperty { get; set; }

            public double DoubleTypeProperty { get; set; }

            public int IntTypeProperty { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }
    }
}