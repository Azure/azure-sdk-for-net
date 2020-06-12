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
        public void TableOperations()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies4";
            string partitionKey = "somePartition";
            string rowKey = "A1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            serviceClient.CreateTable(tableName);

            try
            {
                var client = serviceClient.GetTableClient(tableName);

                #region Snippet:TablesSample2UpsertEntity
                // making an entity
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };
                client.Upsert(entity); // inserts entity

                entity["Price"] = 6.00;
                client.Upsert(entity); // updates entity because it exists
                #endregion

                entity.Add("Price", 7.00);
                #region Snippet:TablesSample2UpdateEntityOptimistic
                // client.Update(entity);
                #endregion
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
