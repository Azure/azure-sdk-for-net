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
            string partitionKey = "Stationery";
            string rowKey = "A1";
            string rowKeyStrong = "B1";

            #region Snippet:TablesSample2CreateTableClientAsync
            // Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
            var client = new TableClient(
                tableName,
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            // Create the table in the service.
            await client.CreateAsync();
            #endregion

            #region Snippet:TablesSample2CreateEntityAsync
            // Make a dictionary entity by defining a <see cref="TableEntity">.
            var entity = new TableEntity(partitionKey, rowKey)
            {
                { "Product", "Marker Set" },
                { "Price", 5.00 },
                { "Quantity", 21 }
            };

            Console.WriteLine($"{entity.RowKey}: {entity["Product"]} costs ${entity.GetDouble("Price")}.");
            #endregion

            #region Snippet:TablesSample2AddEntityAsync
            // Insert the newly created entity.
            await client.CreateEntityAsync(entity);
            #endregion

            #region Snippet:TablesSample2CreateStronglyTypedEntityAsync
            // Create an instance of the strongly-typed entity and set their properties.
            var strongEntity = new OfficeSupplyEntity
            {
                PartitionKey = partitionKey,
                RowKey = rowKeyStrong,
                Product = "Notebook",
                Price = 3.00,
                Quantity = 50
            };

            Console.WriteLine($"{entity.RowKey}: {strongEntity.Product} costs ${strongEntity.Price}.");
            #endregion

            // Add the newly created entity.
            await client.CreateEntityAsync(strongEntity);

            #region Snippet:TablesSample2DeleteEntityAsync
            // Delete the entity given the partition and row key.
            await client.DeleteEntityAsync(partitionKey, rowKey);
            #endregion

            #region Snippet:TablesSample2DeleteTableWithTableClientAsync
            await client.DeleteAsync();
            #endregion
        }
    }
}
