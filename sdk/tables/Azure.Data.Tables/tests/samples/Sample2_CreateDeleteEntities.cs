// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Collections.Generic;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void CreateDeleteEntity()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies2p1";
            string partitionKey = "Stationery";
            string rowKey = "A1";
            string rowKeyStrong = "B1";

            #region Snippet:TablesSample2CreateTableWithTableClient
            // Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
            var tableClient = new TableClient(
                tableName,
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            // Create the table in the service.
            tableClient.Create();
            #endregion

            #region Snippet:TablesSample2CreateDictionaryEntity
            // Make a dictionary entity by defining a <see cref="TableEntity">.
            var entity = new TableEntity(partitionKey, rowKey)
            {
                { "Product", "Marker Set" },
                { "Price", 5.00 },
                { "Quantity", 21 }
            };

            Console.WriteLine($"{entity.RowKey}: {entity["Product"]} costs ${entity.GetDouble("Price")}.");
            #endregion

            #region Snippet:TablesSample2AddEntity
            // Add the newly created entity.
            tableClient.AddEntity(entity);
            #endregion

            #region Snippet:TablesSample2CreateStronglyTypedEntity
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
            tableClient.AddEntity(strongEntity);

            #region Snippet:TablesSample2DeleteEntity
            // Delete the entity given the partition and row key.
            tableClient.DeleteEntity(partitionKey, rowKey);
            #endregion

            #region Snippet:TablesSample2DeleteTableWithTableClient
            tableClient.Delete();
            #endregion
        }

        #region Snippet:TablesSample2DefineStronglyTypedEntity
        // Define a strongly typed entity by extending the <see cref="ITableEntity"> class.
        public class OfficeSupplyEntity : ITableEntity
        {
            public string Product { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }
        #endregion
    }
}
