// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
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
    public class TableClientLiveTests : RecordedTestBase<TablesTestEnvironment>
    {

        public TableClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
        }

        /// <summary>
        /// Creates a <see cref="TableServiceClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="TableServiceClient" />.</returns>
        private TableServiceClient CreateTableServiceClient()
        {
            return InstrumentClient(new TableServiceClient(new Uri(TestEnvironment.StorageUri),
                                                               new TablesSharedKeyCredential(
                                                                   TestEnvironment.AccountName,
                                                                   TestEnvironment.PrimaryStorageAccountKey
                                                               ), Recording.InstrumentClientOptions(new TableClientOptions())));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task InsertedEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = service.GetTableClient(tableName);
                List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(partitionKeyValue, 20);

                // Insert the new entities.

                foreach (var entity in entitiesToInsert)
                {
                    await client.InsertAsync(entity).ConfigureAwait(false);
                }

                // Query the entities.

                entityResults = (await client.QueryAsync(top: pageCount).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => entityResults.Count, Is.EqualTo(entitiesToInsert.Count), "The entity result count should match the inserted count");
                entityResults.Clear();
            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedEntitiesCanBeQueriedWithFilters()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = service.GetTableClient(tableName);
                List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(partitionKeyValue, 20);

                // Insert the new entities.

                foreach (var entity in entitiesToInsert)
                {
                    await client.InsertAsync(entity).ConfigureAwait(false);
                }

                // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

                entityResults = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey ge '10'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        private static List<Dictionary<string, object>> CreateTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.

            return Enumerable.Range(1, count - 1).Select(n =>
            {
                return new Dictionary<string, object>
                    {
                        {"PartitionKey", partitionKeyValue},
                        {"RowKey", n.ToString("D2")},
                        {"SomeProperty", $"This is table entity number {n:D2}"}
                    };
            }).ToList();
        }
    }
}
