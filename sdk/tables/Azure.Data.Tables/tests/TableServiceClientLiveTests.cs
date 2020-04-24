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
    //[LiveOnly]
    public class TableServiceClientLiveTests : RecordedTestBase<TablesTestEnvironment>
    {
        /// <summary>
        /// The table endpoint.
        /// </summary>
        private readonly Uri _tableEndpoint;

        public TableServiceClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        {
            _tableEndpoint = new Uri(TestEnvironment.StorageUri);
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
            TableServiceClient client = new TableServiceClient(_tableEndpoint,
                                                               new TablesSharedKeyCredential(
                                                                   TestEnvironment.AccountName,
                                                                   string.Empty /* To record new tests, replace this value with TestEnvironment.PrimaryStorageAccountKey */
                                                               ), Recording.InstrumentClientOptions(new TableClientOptions()));

            return InstrumentClient(client);
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public async Task GetTablesReturnsTables()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);

                Assert.That(() => createdTable.TableName, Is.EqualTo(tableName), $"Created table should be {tableName}");
                doCleanup = true;

                List<TableResponseProperties> tableResponses = new List<TableResponseProperties>();

                await foreach (var table in service.GetTablesAsync())
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
    }
}
