// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using Azure.Data.Tables.Sas;
using System.Threading.Tasks;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task ConnStringAuth()
        {
            string tableName = "OfficeSupplies";
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={PrimaryStorageAccountKey};EndpointSuffix={StorageEndpointSuffix ?? DefaultStorageSuffix}";

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
            string tableName = "OfficeSupplies";

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
            string tableName = "OfficeSupplies";

            #region Snippet:TablesAuthSas
            // Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.

            var credential = new TableSharedKeyCredential(accountName, accountKey);

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                credential);

            // Build a shared access signature with the Write and Delete permissions and access to all service resource types.

            TableAccountSasBuilder sasWriteDelete = serviceClient.GetSasBuilder(TableAccountSasPermissions.Write | TableAccountSasPermissions.Delete, TableAccountSasResourceTypes.All, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            string tokenWriteDelete = sasWriteDelete.Sign(credential);

            // Create the TableServiceClients using the SAS URIs.

            var serviceClientWithSas = new TableServiceClient(new Uri(storageUri), new AzureSasCredential(tokenWriteDelete));

            // Validate that we are able to create a table using the SAS URI with Write and Delete permissions.

            await serviceClientWithSas.CreateTableIfNotExistsAsync(tableName);

            // Validate that we are able to delete a table using the SAS URI with Write and Delete permissions.

            await serviceClientWithSas.DeleteTableAsync(tableName);
            #endregion
        }
    }
}
