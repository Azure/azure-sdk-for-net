// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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

        protected TableServiceClient service;
        protected TableClient client;
        protected string tableName;
        protected const string partitionKeyValue = "somPartition";

        /// <summary>
        /// Creates a <see cref="TableServiceClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        [SetUp]
        public async Task TablesTestSetup()
        {
            service = InstrumentClient(new TableServiceClient(new Uri(TestEnvironment.StorageUri),
                                                               new TablesSharedKeyCredential(
                                                                   TestEnvironment.AccountName,
                                                                   TestEnvironment.PrimaryStorageAccountKey
                                                               ), Recording.InstrumentClientOptions(new TableClientOptions())));
            tableName = Recording.GenerateId("testtable", 15);
            await service.CreateTableAsync(tableName).ConfigureAwait(false);
            client = InstrumentClient(service.GetTableClient(tableName));
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
                        {"SomeStringProperty", $"This is table entity number {n:D2}"},
                        {"SomeDateProperty", new DateTime(2020, 1,1,1,1,0,DateTimeKind.Utc).AddMinutes(n) },
                        {"SomeGuidProperty", new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}")},
                        {"SomeBinaryProperty", new byte[]{ 0x01, 0x02, 0x03, 0x04, 0x05 }},
                        {"SomeInt64Property", long.Parse(number)},
                        {"SomeDoubleProperty0", (double)n},
                        {"SomeDoubleProperty1", n + 0.1},
                        {"SomeIntProperty", int.Parse(number)},
                    };
            }).ToList();
        }
    }
}
