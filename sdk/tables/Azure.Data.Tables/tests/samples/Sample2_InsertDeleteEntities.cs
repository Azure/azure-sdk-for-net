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
        public void InsertDelete()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies3";
            string partitionKey = "somePartition";
            string rowKey = "A1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            serviceClient.CreateTable(tableName);

            try
            {
                #region Snippet:TablesSample2GetTableClient
                // Get a reference to the <see cref="TableClient" /> of the table.
                var client = serviceClient.GetTableClient(tableName);
                #endregion

                #region Snippet:TablesSample2InsertEntity
                // Make an entity by defining a <see cref="Dictionary"> that includes the partition and row key.
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };

                // Insert the newly created entity.
                client.Insert(entity);
                #endregion

                #region Snippet:TablesSample2DeleteEntity
                // Delete the entity given the partition and row key.
                client.Delete(partitionKey, rowKey);
                #endregion

            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
