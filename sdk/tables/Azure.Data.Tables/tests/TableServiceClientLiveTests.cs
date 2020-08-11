// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;
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
    public class TableServiceClientLiveTests : TableServiceLiveTestsBase
    {

        public TableServiceClientLiveTests(bool isAsync, TableEndpointType endpointType) : base(isAsync, endpointType /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [Test]
        public void ValidateAccountSasCredentialsWithPermissions()
        {
            // Create a SharedKeyCredential that we can use to sign the SAS token

            var credential = new TableSharedKeyCredential(TestEnvironment.StorageAccountName, TestEnvironment.PrimaryStorageAccountKey);

            // Build a shared access signature with only Delete permissions and access to all service resource types.

            TableAccountSasBuilder sasDelete = service.GetSasBuilder(TableAccountSasPermissions.Delete, TableAccountSasResourceTypes.All, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            string tokenDelete = sasDelete.Sign(credential);

            // Build a shared access signature with the Write and Delete permissions and access to all service resource types.

            TableAccountSasBuilder sasWriteDelete = service.GetSasBuilder(TableAccountSasPermissions.Write, TableAccountSasResourceTypes.All, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            string tokenWriteDelete = sasWriteDelete.Sign(credential);

            // Build SAS URIs.

            UriBuilder sasUriDelete = new UriBuilder(TestEnvironment.StorageUri)
            {
                Query = tokenDelete
            };

            UriBuilder sasUriWriteDelete = new UriBuilder(TestEnvironment.StorageUri)
            {
                Query = tokenWriteDelete
            };

            // Create the TableServiceClients using the SAS URIs.

            var sasAuthedServiceDelete = InstrumentClient(new TableServiceClient(sasUriDelete.Uri, Recording.InstrumentClientOptions(new TableClientOptions())));
            var sasAuthedServiceWriteDelete = InstrumentClient(new TableServiceClient(sasUriWriteDelete.Uri, Recording.InstrumentClientOptions(new TableClientOptions())));

            // Validate that we are unable to create a table using the SAS URI with only Delete permissions.

            var sasTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            Assert.That(async () => await sasAuthedServiceDelete.CreateTableAsync(sasTableName).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>().And.Property("Status").EqualTo((int)HttpStatusCode.Forbidden));

            // Validate that we are able to create a table using the SAS URI with Write and Delete permissions.

            Assert.That(async () => await sasAuthedServiceWriteDelete.CreateTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);

            // Validate that we are able to delete a table using the SAS URI with only Delete permissions.

            Assert.That(async () => await sasAuthedServiceDelete.DeleteTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);
        }

        [Test]
        public void ValidateAccountSasCredentialsWithResourceTypes()
        {
            // Create a SharedKeyCredential that we can use to sign the SAS token

            var credential = new TableSharedKeyCredential(TestEnvironment.StorageAccountName, TestEnvironment.PrimaryStorageAccountKey);

            // Build a shared access signature with all permissions and access to only Service resource types.

            TableAccountSasBuilder sasService = service.GetSasBuilder(TableAccountSasPermissions.All, TableAccountSasResourceTypes.Service, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            string tokenService = sasService.Sign(credential);

            // Build a shared access signature with all permissions and access to Service and Container resource types.

            TableAccountSasBuilder sasServiceContainer = service.GetSasBuilder(TableAccountSasPermissions.All, TableAccountSasResourceTypes.Service | TableAccountSasResourceTypes.Container, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            string tokenServiceContainer = sasServiceContainer.Sign(credential);

            // Build SAS URIs.

            UriBuilder sasUriService = new UriBuilder(TestEnvironment.StorageUri)
            {
                Query = tokenService
            };

            UriBuilder sasUriServiceContainer = new UriBuilder(TestEnvironment.StorageUri)
            {
                Query = tokenServiceContainer
            };

            // Create the TableServiceClients using the SAS URIs.

            var sasAuthedServiceClientService = InstrumentClient(new TableServiceClient(sasUriService.Uri, Recording.InstrumentClientOptions(new TableClientOptions())));
            var sasAuthedServiceClientServiceContainer = InstrumentClient(new TableServiceClient(sasUriServiceContainer.Uri, Recording.InstrumentClientOptions(new TableClientOptions())));

            // Validate that we are unable to create a table using the SAS URI with access to Service resource types.

            var sasTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            Assert.That(async () => await sasAuthedServiceClientService.CreateTableAsync(sasTableName).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>().And.Property("Status").EqualTo((int)HttpStatusCode.Forbidden));

            // Validate that we are able to create a table using the SAS URI with access to Service and Container resource types.

            Assert.That(async () => await sasAuthedServiceClientServiceContainer.CreateTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);

            // Validate that we are able to get table service properties using the SAS URI with access to Service resource types.

            Assert.That(async () => await sasAuthedServiceClientService.GetPropertiesAsync().ConfigureAwait(false), Throws.Nothing);

            // Validate that we are able to get table service properties using the SAS URI with access to Service and Container resource types.

            Assert.That(async () => await sasAuthedServiceClientService.GetPropertiesAsync().ConfigureAwait(false), Throws.Nothing);

            // Validate that we are able to delete a table using the SAS URI with access to Service and Container resource types.

            Assert.That(async () => await sasAuthedServiceClientServiceContainer.DeleteTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task GetTablesReturnsTablesWithAndWithoutPagination(int? pageCount)
        {
            var createdTables = new List<string>();

            try
            {
                // Create some extra tables.

                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
                    await CosmosThrottleWrapper(async () => await service.CreateTableAsync(table).ConfigureAwait(false));
                    createdTables.Add(table);
                }

                // Get the table list.

                var tableResponses = (await service.GetTablesAsync(maxPerPage: pageCount).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public async Task GetTablesReturnsTablesWithFilter()
        {
            var createdTables = new List<string>();

            try
            {
                // Create some extra tables.

                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
                    await CosmosThrottleWrapper(async () => await service.CreateTableAsync(table).ConfigureAwait(false));
                    createdTables.Add(table);
                }

                // Query with a filter.

                var tableResponses = (await service.GetTablesAsync(filter: $"TableName eq '{tableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        [Test]
        public async Task GetPropertiesReturnsProperties()
        {
            if (_endpointType == TableEndpointType.CosmosTable)
            {
                Assert.Ignore("GetProperties is currently not supported by Cosmos endpoints.");
            }

            // Get current properties

            TableServiceProperties responseToChange = await service.GetPropertiesAsync().ConfigureAwait(false);

            // Change a property

            responseToChange.Logging.Read = !responseToChange.Logging.Read;

            // Set properties to the changed one

            await service.SetPropertiesAsync(responseToChange).ConfigureAwait(false);

            // Wait 20 sec if on Live mode to ensure properties are updated in the service
            // Minimum time: Sync - 20 sec; Async - 12 sec

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }

            // Get configured properties

            TableServiceProperties changedResponse = await service.GetPropertiesAsync().ConfigureAwait(false);

            // Test each property

            CompareTableServiceProperties(responseToChange, changedResponse);
        }

        [Test]
        public async Task GetTableServiceStatsReturnsStats()
        {
            if (_endpointType == TableEndpointType.CosmosTable)
            {
                Assert.Ignore("GetProperties is currently not supported by Cosmos endpoints.");
            }

            // Get statistics

            TableServiceStatistics stats = await service.GetStatisticsAsync().ConfigureAwait(false);

            // Test that the secondary location is live

            Assert.AreEqual(new TableGeoReplicationStatus("live"), stats.GeoReplication.Status);
        }

        private void CompareTableServiceProperties(TableServiceProperties expected, TableServiceProperties actual)
        {
            Assert.AreEqual(expected.Logging.Read, actual.Logging.Read);
            Assert.AreEqual(expected.Logging.Version, actual.Logging.Version);
            Assert.AreEqual(expected.Logging.Write, actual.Logging.Write);
            Assert.AreEqual(expected.Logging.Delete, actual.Logging.Delete);
            Assert.AreEqual(expected.Logging.RetentionPolicy.Enabled, actual.Logging.RetentionPolicy.Enabled);
            Assert.AreEqual(expected.Logging.RetentionPolicy.Days, actual.Logging.RetentionPolicy.Days);

            Assert.AreEqual(expected.HourMetrics.Enabled, actual.HourMetrics.Enabled);
            Assert.AreEqual(expected.HourMetrics.Version, actual.HourMetrics.Version);
            Assert.AreEqual(expected.HourMetrics.IncludeApis, actual.HourMetrics.IncludeApis);
            Assert.AreEqual(expected.HourMetrics.RetentionPolicy.Enabled, actual.HourMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(expected.HourMetrics.RetentionPolicy.Days, actual.HourMetrics.RetentionPolicy.Days);

            Assert.AreEqual(expected.MinuteMetrics.Enabled, actual.MinuteMetrics.Enabled);
            Assert.AreEqual(expected.MinuteMetrics.Version, actual.MinuteMetrics.Version);
            Assert.AreEqual(expected.MinuteMetrics.IncludeApis, actual.MinuteMetrics.IncludeApis);
            Assert.AreEqual(expected.MinuteMetrics.RetentionPolicy.Enabled, actual.MinuteMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(expected.MinuteMetrics.RetentionPolicy.Days, actual.MinuteMetrics.RetentionPolicy.Days);

            Assert.AreEqual(expected.Cors.Count, actual.Cors.Count);
            for (int i = 0; i < expected.Cors.Count; i++)
            {
                TableCorsRule expectedRule = expected.Cors[i];
                TableCorsRule actualRule = actual.Cors[i];
                Assert.AreEqual(expectedRule.AllowedHeaders, actualRule.AllowedHeaders);
                Assert.AreEqual(expectedRule.AllowedMethods, actualRule.AllowedMethods);
                Assert.AreEqual(expectedRule.AllowedOrigins, actualRule.AllowedOrigins);
                Assert.AreEqual(expectedRule.MaxAgeInSeconds, actualRule.MaxAgeInSeconds);
                Assert.AreEqual(expectedRule.ExposedHeaders, actualRule.ExposedHeaders);
            }
        }
    }
}
