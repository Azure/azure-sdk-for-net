// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using Azure.Data.Tables.Sas;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        private static Random _random = new Random();

        [Test]
        public async Task ConnStringAuth()
        {
            string tableName = "OfficeSuppliesConnStringAuth" + _random.Next();
            string connectionString =
                $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={PrimaryStorageAccountKey};EndpointSuffix={StorageEndpointSuffix ?? DefaultStorageSuffix}";

            #region Snippet:TablesAuthConnString

            // Construct a new TableClient using a connection string.
            var client = new TableClient(
                connectionString,
                tableName);

            // Create the table if it doesn't already exist to verify we've successfully authenticated.
            await client.CreateIfNotExistsAsync();

            #endregion
        }

        [Test]
        public async Task SharedKeyAuth()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string accountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSuppliesSharedKeyAuth" + _random.Next();

            #region Snippet:TablesAuthSharedKey

            // Construct a new TableClient using a TableSharedKeyCredential.
            var client = new TableClient(
                new Uri(storageUri),
                tableName,
                new TableSharedKeyCredential(accountName, accountKey));

            // Create the table if it doesn't already exist to verify we've successfully authenticated.
            await client.CreateIfNotExistsAsync();

            #endregion
        }

        [Test]
        public async Task SasAuth()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string accountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSuppliesSasAuth" + _random.Next();

            #region Snippet:TablesAuthSas

            // Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.
            var credential = new TableSharedKeyCredential(accountName, accountKey);

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                credential);

            // Build a shared access signature with the Write and Delete permissions and access to all service resource types.
            var sasUri = serviceClient.GenerateSasUri(
                TableAccountSasPermissions.Write | TableAccountSasPermissions.Delete,
                TableAccountSasResourceTypes.All,
                new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));

            // Create the TableServiceClients using the SAS URI.
            var serviceClientWithSas = new TableServiceClient(sasUri);

            // Validate that we are able to create a table using the SAS URI with Write and Delete permissions.
            await serviceClientWithSas.CreateTableIfNotExistsAsync(tableName);

            // Validate that we are able to delete a table using the SAS URI with Write and Delete permissions.
            await serviceClientWithSas.DeleteTableAsync(tableName);

            #endregion
        }

        [Test]
        public async Task TokenCredentialAuth()
        {
            string storageUri = StorageUri;
            string tableName = "OfficeSuppliesTokenAuth" + _random.Next();

            #region Snippet:TablesAuthTokenCredential

            // Construct a new TableClient using a TokenCredential.
            var client = new TableClient(
                new Uri(storageUri),
                tableName,
#if SNIPPET
                new DefaultAzureCredential());
#else
                Credential);
#endif

            // Create the table if it doesn't already exist to verify we've successfully authenticated.
            await client.CreateIfNotExistsAsync();

            #endregion
        }
    }
}
