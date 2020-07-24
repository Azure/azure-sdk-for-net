// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task CreateDeleteEntitiesAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies2p2";
            string partitionKey = "somePartition";
            string rowKey = "A1";
            string rowKeyStrong = "B1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            await serviceClient.CreateTableAsync(tableName);

            try
            {
                // Get a reference to the <see cref="TableClient" /> of the table.
                var client = serviceClient.GetTableClient(tableName);

                #region Snippet:TablesSample2CreateEntityAsync
                // Make an entity by defining a <see cref="Dictionary"> that includes the partition and row key.
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };

                // Insert the newly created entity.
                await client.CreateEntityAsync(entity);
                #endregion

                #region Snippet:TablesSample2CreateStronglyTypedEntityAsync
                // Make a strongly typed entity by defining a custom class that extends <see cref="TableEntity">.
                var strongEntity = new OfficeSupplyEntity
                {
                    PartitionKey = partitionKey,
                    RowKey = rowKeyStrong,
                    Product = "Notebook",
                    Price = 3.00
                };

                // Insert the newly created entity.
                await client.CreateEntityAsync(strongEntity);
                #endregion

                #region Snippet:TablesSample2DeleteEntityAsync
                // Delete the entity given the partition and row key.
                await client.DeleteAsync(partitionKey, rowKey);
                #endregion

            }
            finally
            {
                await serviceClient.DeleteTableAsync(tableName);
            }
        }
    }
}
