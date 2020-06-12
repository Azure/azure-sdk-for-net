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
        public void QueryEntities()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies6";
            string partitionKey = "somePartition";
            string rowKey = "A1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            try
            {

                serviceClient.CreateTable(tableName);
                var client = serviceClient.GetTableClient(tableName);

                #region Snippet:TablesSample2InsertEntity
                // making an entity
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };
                client.Insert(entity);
                #endregion
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
