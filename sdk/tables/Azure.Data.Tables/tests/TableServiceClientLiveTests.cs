// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
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
    public class TableServiceClientLiveTests : RecordedTestBase<TablesTestEnvironment>
    {

        public TableServiceClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, add this argument, RecordedTestMode.Record */)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
            Matcher = new TablesRecordMatcher(Sanitizer);
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
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task GetTablesReturnsTables(int? pageCount)
        {
            string tableName = $"testtable{(IsAsync ? "async" : "sync")}{Recording.GenerateId()}";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);

                Assert.That(() => createdTable.TableName, Is.EqualTo(tableName), $"Created table should be '{tableName}'");
                doCleanup = true;

                List<TableResponseProperties> tableResponses = new List<TableResponseProperties>();

                await foreach (var table in service.GetTablesAsync(top: pageCount))
                {
                    tableResponses.Add(table);
                }

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));

                // Query again with a filter.

                tableResponses.Clear();
                await foreach (var table in service.GetTablesAsync(top: pageCount, filter: $"TableName eq '{tableName}'"))
                {
                    tableResponses.Add(table);
                }

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
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
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public async Task InsertedEntitiesCanBeQueried()
        {
            string tableName = $"testtable{(IsAsync ? "async" : "sync")}{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = service.GetTableClient(tableName);

                // Create some entities.

                var entitiesToInsert = Enumerable.Range(0, 20).Select(n => {
                    return new Dictionary<string, object>
                    {
                        {"PartitionKey", partitionKeyValue},
                        {"RowKey", n.ToString("D2")},
                        {"SomeProperty", $"This is table entity number {n:D2}"}
                    };
                }).ToList();

                // Insert the new entities.

                foreach (var entity in entitiesToInsert)
                {
                    await client.InsertAsync(entity).ConfigureAwait(false);
                }

                // Query the entities with no options.

                entityResults = (await client.QueryAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => entityResults.Count, Is.EqualTo(entitiesToInsert.Count), "The entity result count should match the inserted count");
                entityResults.Clear();

                // Query the entities with a top option.

                entityResults = (await client.QueryAsync(top: 4).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => entityResults.Count, Is.EqualTo(entitiesToInsert.Count), "The entity result count should match the inserted count");

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
    }
}
