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
        public void UpdateUpsert()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies5.1";
            string partitionKey = "somePartition";
            string rowKey = "A1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            serviceClient.CreateTable(tableName);

            try
            {
                var client = serviceClient.GetTableClient(tableName);

                #region Snippet:TablesSample5UpsertEntity
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

                #region Snippet:TablesSample5UpdateEntity
                Pageable<IDictionary<string, object>> queryResultsBefore = client.Query(filter: $"PartitionKey eq '{partitionKey}'");

                foreach (IDictionary<string, object> qEntity in queryResultsBefore)
                {
                    Console.WriteLine($"The price before updating: ${qEntity["Price"]}");
                    qEntity["Price"] = 7.00;
                    client.Update(qEntity, qEntity["odata.etag"] as string);
                }

                Pageable<IDictionary<string, object>> queryResultsAfter = client.Query(filter: $"PartitionKey eq '{partitionKey}'");
                foreach (IDictionary<string, object> qEntity in queryResultsAfter)
                {
                    Console.WriteLine($"The price after updating: ${qEntity["Price"]}");
                }
                #endregion
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
