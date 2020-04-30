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
    public class TableServiceClientLiveTests : RecordedTestBase<TablesTestEnvironment>
    {

        public TableServiceClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
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
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task GetTablesReturnsTablesWithAndWithoutPagination(int? pageCount)
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);

                Assert.That(() => createdTable.TableName, Is.EqualTo(tableName), $"Created table should be '{tableName}'");
                doCleanup = true;

                var tableResponses = (await service.GetTablesAsync(top: pageCount).ToEnumerableAsync().ConfigureAwait(false)).ToList();

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
        public async Task GetTablesReturnsTablesWithFilter()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);

                Assert.That(() => createdTable.TableName, Is.EqualTo(tableName), $"Created table should be '{tableName}'");
                doCleanup = true;

                // Query with a filter.

                var tableResponses = (await service.GetTablesAsync(filter: $"TableName eq '{tableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

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
