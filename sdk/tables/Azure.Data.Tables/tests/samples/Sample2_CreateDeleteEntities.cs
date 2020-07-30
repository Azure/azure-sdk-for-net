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
            string partitionKey = "somePartition";
            string rowKey = "A1";
            string rowKeyStrong = "B1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            try
            {
                #region Snippet:TablesSample2GetTableClient
                // Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
                var client = new TableClient(
                    tableName,
                    new Uri(storageUri),
                    new TableSharedKeyCredential(accountName, storageAccountKey));
                #endregion

                #region Snippet:TablesSample2CreateEntity
                // Make an entity by defining a <see cref="Dictionary"> that includes the partition and row key.
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };

                // Insert the newly created entity.
                client.CreateEntity(entity);
                #endregion

                #region Snippet:TablesSample2CreateStronglyTypedEntity
                // Make a strongly typed entity by defining a custom class that extends <see cref="TableEntity">.
                var strongEntity = new OfficeSupplyEntity
                {
                    PartitionKey = partitionKey,
                    RowKey = rowKeyStrong,
                    Product = "Notebook",
                    Price = 3.00
                };

                // Insert the newly created entity.
                client.CreateEntity(strongEntity);
                #endregion

                #region Snippet:TablesSample2DeleteEntity
                // Delete the entity given the partition and row key.
                client.DeleteEntity(partitionKey, rowKey);
                #endregion

            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }

        #region Snippet:TablesSample2DefineStronglyTypedEntity
        // Define a strongly typed entity by extending the <see cref="TableEntity"> class.
        public class OfficeSupplyEntity : ITableEntity
        {
            public string Product { get; set; }
            public double Price { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public string ETag { get; set; }
        }
        #endregion
    }
}
