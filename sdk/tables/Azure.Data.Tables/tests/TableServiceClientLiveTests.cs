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

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public void ThrowsWithTableNameInUri()
        {
            var badService = CreateService(ServiceUri + "/" + tableName, InstrumentClientOptions(new TableClientOptions()));

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await badService.CreateTableIfNotExistsAsync(tableName));

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));

            ex = Assert.ThrowsAsync<RequestFailedException>(async () => await badService.DeleteTableAsync(tableName));

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));

            ex = Assert.ThrowsAsync<RequestFailedException>(async () => await badService.QueryAsync().ToEnumerableAsync());

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));

            ex = Assert.ThrowsAsync<RequestFailedException>(async () => await badService.CreateTableAsync(tableName));

            Assert.That(ex.Message, Does.Contain("The configured endpoint Uri appears to contain the table name"));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreateTableIfNotExists()
        {
            // Call CreateTableIfNotExists when the table already exists.
            Assert.That(async () => await CosmosThrottleWrapper(async () => await service.CreateTableIfNotExistsAsync(tableName).ConfigureAwait(false)), Throws.Nothing);

            // Call CreateTableIfNotExists when the table does not already exists.
            var newTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            try
            {
                TableItem table = await CosmosThrottleWrapper(async () => await service.CreateTableIfNotExistsAsync(newTableName).ConfigureAwait(false));
                Assert.That(table.Name, Is.EqualTo(newTableName));
            }
            finally
            {
                // Delete the table using the TableClient method.
                await CosmosThrottleWrapper(async () => await service.DeleteTableAsync(newTableName).ConfigureAwait(false));
            }
        }

        [RecordedTest]
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

            // Create the TableServiceClients using the SAS URIs.
            // Intentionally double add the Sas to the endpoint and the cred to validate de-duping
            var sasAuthedServiceDelete = InstrumentClient(new TableServiceClient(new Uri(ServiceUri), new AzureSasCredential(tokenDelete), InstrumentClientOptions(new TableClientOptions())));
            var sasAuthedServiceWriteDelete = InstrumentClient(new TableServiceClient(new Uri(ServiceUri), new AzureSasCredential(tokenWriteDelete), InstrumentClientOptions(new TableClientOptions())));

            // Validate that we are unable to create a table using the SAS URI with only Delete permissions.

            var sasTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sasAuthedServiceDelete.CreateTableAsync(sasTableName).ConfigureAwait(false));
            Assert.That(ex.Status, Is.EqualTo((int)HttpStatusCode.Forbidden));
            Assert.That(ex.ErrorCode, Is.EqualTo(TableErrorCode.AuthorizationPermissionMismatch.ToString()));

            // Validate that we are able to create a table using the SAS URI with Write and Delete permissions.

            Assert.That(async () => await sasAuthedServiceWriteDelete.CreateTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);

            // Validate that we are able to delete a table using the SAS URI with only Delete permissions.

            Assert.That(async () => await sasAuthedServiceDelete.DeleteTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);
        }

        [RecordedTest]
        public void ValidateAccountSasCredentialsWithPermissionsWithSasDuplicatedInUri()
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

            UriBuilder sasUriDelete = new UriBuilder(ServiceUri)
            {
                Query = tokenDelete
            };

            UriBuilder sasUriWriteDelete = new UriBuilder(ServiceUri)
            {
                Query = tokenWriteDelete
            };

            // Create the TableServiceClients using the SAS URIs.
            // Intentionally double add the Sas to the endpoint and the cred to validate de-duping
            var sasAuthedServiceDelete = InstrumentClient(new TableServiceClient(sasUriDelete.Uri, new AzureSasCredential(tokenDelete), InstrumentClientOptions(new TableClientOptions())));
            var sasAuthedServiceWriteDelete = InstrumentClient(new TableServiceClient(sasUriWriteDelete.Uri, new AzureSasCredential(tokenWriteDelete), InstrumentClientOptions(new TableClientOptions())));

            // Validate that we are unable to create a table using the SAS URI with only Delete permissions.

            var sasTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sasAuthedServiceDelete.CreateTableAsync(sasTableName).ConfigureAwait(false));
            Assert.That(ex.Status, Is.EqualTo((int)HttpStatusCode.Forbidden));
            Assert.That(ex.ErrorCode, Is.EqualTo(TableErrorCode.AuthorizationPermissionMismatch.ToString()));

            // Validate that we are able to create a table using the SAS URI with Write and Delete permissions.

            Assert.That(async () => await sasAuthedServiceWriteDelete.CreateTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);

            // Validate that we are able to delete a table using the SAS URI with only Delete permissions.

            Assert.That(async () => await sasAuthedServiceDelete.DeleteTableAsync(sasTableName).ConfigureAwait(false), Throws.Nothing);
        }

        [RecordedTest]
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

            UriBuilder sasUriService = new UriBuilder(ServiceUri)
            {
                Query = tokenService
            };

            UriBuilder sasUriServiceContainer = new UriBuilder(ServiceUri)
            {
                Query = tokenServiceContainer
            };

            // Create the TableServiceClients using the SAS URIs.

            var sasAuthedServiceClientService = InstrumentClient(new TableServiceClient(new Uri(ServiceUri), new AzureSasCredential(tokenService), InstrumentClientOptions(new TableClientOptions())));
            var sasAuthedServiceClientServiceContainer = InstrumentClient(new TableServiceClient(new Uri(ServiceUri), new AzureSasCredential(tokenServiceContainer), InstrumentClientOptions(new TableClientOptions())));

            // Validate that we are unable to create a table using the SAS URI with access to Service resource types.

            var sasTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await sasAuthedServiceClientService.CreateTableAsync(sasTableName).ConfigureAwait(false));
            Assert.That(ex.Status, Is.EqualTo((int)HttpStatusCode.Forbidden));
            Assert.That(ex.ErrorCode, Is.EqualTo(TableErrorCode.AuthorizationResourceTypeMismatch.ToString()));

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
        [RecordedTest]
        [TestCase(null)]
        [TestCase(5)]
        public async Task GetTablesReturnsTablesWithAndWithoutPagination(int? pageCount)
        {
            var createdTables = new List<string> { tableName };

            try
            {
                // Create some extra tables.
                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
                    createdTables.Add(table);
                    await CosmosThrottleWrapper(async () => await service.CreateTableAsync(table).ConfigureAwait(false));
                }

                // Get the table list.
                await foreach (var page in service.QueryAsync().AsPages(pageSizeHint: pageCount))
                {
                    Assert.That(page.Values, Is.Not.Empty);
                    if (pageCount.HasValue)
                    {
                        Assert.That(page.Values.Count, Is.LessThanOrEqualTo(pageCount.Value));
                    }
                    else
                    {
                        Assert.That(page.Values.Count, Is.GreaterThanOrEqualTo(createdTables.Count));
                    }
                }
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
        [RecordedTest]
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

                var tableResponses = (await service.QueryAsync(filter: $"TableName eq '{tableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(tableResponses.Select(r => r.Name).SingleOrDefault(), Is.EqualTo(tableName));

                // Query with a filter.

                tableResponses = (await service.QueryAsync(filter: t => t.Name == tableName).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(tableResponses.Select(r => r.Name).SingleOrDefault(), Is.EqualTo(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        [RecordedTest]
        public async Task GetPropertiesReturnsProperties()
        {
            // Get current properties

            TableServiceProperties responseToChange = await service.GetPropertiesAsync().ConfigureAwait(false);

            // Change a property

            responseToChange.Logging.Read = !responseToChange.Logging.Read;

            // Set properties to the changed one

            await service.SetPropertiesAsync(responseToChange).ConfigureAwait(false);

            // Get configured properties
            // A delay is required to ensure properties are updated in the service

            TableServiceProperties changedResponse = await RetryUntilExpectedResponse(
                async () => await service.GetPropertiesAsync().ConfigureAwait(false),
                result => result.Value.Logging.Read == responseToChange.Logging.Read,
                15000).ConfigureAwait(false);

            // Test each property

            CompareServiceProperties(responseToChange, changedResponse);
        }

        [RecordedTest]
        public async Task GetTableServiceStatsReturnsStats()
        {
            // Get statistics
            TableServiceStatistics stats = await service.GetStatisticsAsync().ConfigureAwait(false);

            Assert.That(stats.GeoReplication.Status, Is.AnyOf(new TableGeoReplicationStatus("live"), new TableGeoReplicationStatus("unavailable")));
        }

        private void CompareServiceProperties(TableServiceProperties expected, TableServiceProperties actual)
        {
            Assert.That(actual.Logging.Read, Is.EqualTo(expected.Logging.Read));
            Assert.That(actual.Logging.Version, Is.EqualTo(expected.Logging.Version));
            Assert.That(actual.Logging.Write, Is.EqualTo(expected.Logging.Write));
            Assert.That(actual.Logging.Delete, Is.EqualTo(expected.Logging.Delete));
            Assert.That(actual.Logging.RetentionPolicy.Enabled, Is.EqualTo(expected.Logging.RetentionPolicy.Enabled));
            Assert.That(actual.Logging.RetentionPolicy.Days, Is.EqualTo(expected.Logging.RetentionPolicy.Days));

            Assert.That(actual.HourMetrics.Enabled, Is.EqualTo(expected.HourMetrics.Enabled));
            Assert.That(actual.HourMetrics.Version, Is.EqualTo(expected.HourMetrics.Version));
            Assert.That(actual.HourMetrics.IncludeApis, Is.EqualTo(expected.HourMetrics.IncludeApis));
            Assert.That(actual.HourMetrics.RetentionPolicy.Enabled, Is.EqualTo(expected.HourMetrics.RetentionPolicy.Enabled));
            Assert.That(actual.HourMetrics.RetentionPolicy.Days, Is.EqualTo(expected.HourMetrics.RetentionPolicy.Days));

            Assert.That(actual.MinuteMetrics.Enabled, Is.EqualTo(expected.MinuteMetrics.Enabled));
            Assert.That(actual.MinuteMetrics.Version, Is.EqualTo(expected.MinuteMetrics.Version));
            Assert.That(actual.MinuteMetrics.IncludeApis, Is.EqualTo(expected.MinuteMetrics.IncludeApis));
            Assert.That(actual.MinuteMetrics.RetentionPolicy.Enabled, Is.EqualTo(expected.MinuteMetrics.RetentionPolicy.Enabled));
            Assert.That(actual.MinuteMetrics.RetentionPolicy.Days, Is.EqualTo(expected.MinuteMetrics.RetentionPolicy.Days));

            Assert.That(actual.Cors.Count, Is.EqualTo(expected.Cors.Count));
            for (int i = 0; i < expected.Cors.Count; i++)
            {
                TableCorsRule expectedRule = expected.Cors[i];
                TableCorsRule actualRule = actual.Cors[i];
                Assert.That(actualRule.AllowedHeaders, Is.EqualTo(expectedRule.AllowedHeaders));
                Assert.That(actualRule.AllowedMethods, Is.EqualTo(expectedRule.AllowedMethods));
                Assert.That(actualRule.AllowedOrigins, Is.EqualTo(expectedRule.AllowedOrigins));
                Assert.That(actualRule.MaxAgeInSeconds, Is.EqualTo(expectedRule.MaxAgeInSeconds));
                Assert.That(actualRule.ExposedHeaders, Is.EqualTo(expectedRule.ExposedHeaders));
            }
        }
    }
}
