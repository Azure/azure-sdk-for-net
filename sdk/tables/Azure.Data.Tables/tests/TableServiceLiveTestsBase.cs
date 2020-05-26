// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TableServiceLiveTestsBase : RecordedTestBase<TablesTestEnvironment>
    {

        public TableServiceLiveTestsBase(bool isAsync, RecordedTestMode recordedTestMode) : base(isAsync, recordedTestMode)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
        }

        public TableServiceLiveTestsBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
        }

        protected TableServiceClient service { get; private set; }
        protected TableClient client { get; private set; }
        protected string tableName { get; private set; }
        protected const string PartitionKeyValue = "somPartition";
        protected const string StringTypePropertyName = "SomeStringProperty";
        protected const string DateTypePropertyName = "SomeDateProperty";
        protected const string GuidTypePropertyName = "SomeGuidProperty";
        protected const string BinaryTypePropertyName = "SomeBinaryProperty";
        protected const string Int64TypePropertyName = "SomeInt64Property";
        protected const string DoubleTypePropertyName = "SomeDoubleProperty0";
        protected const string DoubleDecimalTypePropertyName = "SomeDoubleProperty1";
        protected const string IntTypePropertyName = "SomeIntProperty";

        /// <summary>
        /// Creates a <see cref="TableServiceClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        [SetUp]
        public async Task TablesTestSetup()
        {
            service = InstrumentClient(new TableServiceClient(new Uri(TestEnvironment.StorageUri),
                                                              new TableSharedKeyCredential(TestEnvironment.AccountName, TestEnvironment.PrimaryStorageAccountKey),
                                                              Recording.InstrumentClientOptions(new TableClientOptions())));
            tableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            await service.CreateTableAsync(tableName).ConfigureAwait(false);
            client = service.GetTableClient(tableName);
        }

        [TearDown]
        public async Task TablesTeardown()
        {
            try
            {
                await service.DeleteTableAsync(tableName);
            }
            catch { }
        }

        /// <summary>
        /// Creates a list of table entities.
        /// </summary>
        /// <param name="partitionKeyValue">The partition key to create for the entity.</param>
        /// <param name="count">The number of entities to create</param>
        /// <returns></returns>
        protected static List<Dictionary<string, object>> CreateTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.
            return Enumerable.Range(1, count).Select(n =>
            {
                string number = n.ToString();
                return new Dictionary<string, object>
                    {
                        {"PartitionKey", partitionKeyValue},
                        {"RowKey", n.ToString("D2")},
                        {StringTypePropertyName, $"This is table entity number {n:D2}"},
                        {DateTypePropertyName, new DateTime(2020, 1,1,1,1,0,DateTimeKind.Utc).AddMinutes(n) },
                        {GuidTypePropertyName, new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}")},
                        {BinaryTypePropertyName, new byte[]{ 0x01, 0x02, 0x03, 0x04, 0x05 }},
                        {Int64TypePropertyName, long.Parse(number)},
                        {DoubleTypePropertyName, (double)n},
                        {DoubleDecimalTypePropertyName, n + 0.1},
                        {IntTypePropertyName, n},
                    };
            }).ToList();
        }

        /// <summary>
        /// Creates a list of strongly typed table entities.
        /// </summary>
        /// <param name="partitionKeyValue">The partition key to create for the entity.</param>
        /// <param name="count">The number of entities to create</param>
        /// <returns></returns>
        protected static List<TestEntity> CreateCustomTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.
            return Enumerable.Range(1, count).Select(n =>
            {
                string number = n.ToString();
                return new TestEntity
                {
                    PartitionKey = partitionKeyValue,
                    RowKey = n.ToString("D2"),
                    StringTypeProperty = $"This is table entity number {n:D2}",
                    DatetimeTypeProperty = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    DatetimeOffsetTypeProperty = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    GuidTypeProperty = new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}"),
                    BinaryTypeProperty = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 },
                    Int64TypeProperty = long.Parse(number),
                    DoubleTypeProperty = (double)n,
                    IntTypeProperty = n,
                };
            }).ToList();
        }

        public class TestEntity : TableEntity
        {
            public string StringTypeProperty { get; set; }

            public DateTime DatetimeTypeProperty { get; set; }

            public DateTimeOffset DatetimeOffsetTypeProperty { get; set; }

            public Guid GuidTypeProperty { get; set; }

            public byte[] BinaryTypeProperty { get; set; }

            public long Int64TypeProperty { get; set; }

            public double DoubleTypeProperty { get; set; }

            public int IntTypeProperty { get; set; }
        }

        public class SimpleTestEntity : TableEntity
        {
            public string StringTypeProperty { get; set; }
        }
    }
}
