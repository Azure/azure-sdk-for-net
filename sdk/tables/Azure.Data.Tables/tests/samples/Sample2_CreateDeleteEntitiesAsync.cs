// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Threading.Tasks;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task CreateDeleteEntitiesAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies2p2" + _random.Next();
            string partitionKey = "Stationery";
            string rowKey = "A1";
            string rowKeyStrong = "B1";

            // Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
            var client = new TableClient(
                new Uri(storageUri),
                tableName,
                new TableSharedKeyCredential(accountName, storageAccountKey));

            // Create the table in the service.
            await client.CreateAsync();

            // Make a dictionary entity by defining a <see cref="TableEntity">.
            var entity = new TableEntity(partitionKey, rowKey)
            {
                { "Product", "Marker Set" },
                { "Price", 5.00 },
                { "Quantity", 21 }
            };

            Console.WriteLine($"{entity.RowKey}: {entity["Product"]} costs ${entity.GetDouble("Price")}.");

            // Insert the newly created entity.
            await client.AddEntityAsync(entity);

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

            // Add the newly created entity.
            await client.AddEntityAsync(strongEntity);

            // Delete the entity given the partition and row key.
            await client.DeleteEntityAsync(partitionKey, rowKey);

            // Delete the strong entity given the entity object.
            await client.DeleteEntityAsync(strongEntity);

            await client.DeleteAsync();
        }
    }
}
