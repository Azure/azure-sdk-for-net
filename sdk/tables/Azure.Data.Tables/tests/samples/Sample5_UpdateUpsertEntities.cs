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
        public void UpdateUpsertEntities()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies5p1";
            string partitionKey = "somePartition";
            string rowKey = "A1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            serviceClient.CreateTable(tableName);

            try
            {
                #region Snippet:TablesSample5UpsertEntity
                // Get a reference to the <see cref="TableClient" /> of the table.
                var client = serviceClient.GetTableClient(tableName);

                // Make an entity.
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                    {"Brand", "myCompany" }
                };

                // Entity doesn't exist in table, so invoking Upsert will simply insert the entity.
                client.UpsertEntity(entity);

                // Delete an entity property.
                entity.Remove("Brand");

                // Entity does exist in the table, so invoking Upsert will replace it with the changed entity and delete the "Brand" property.
                client.UpsertEntity(entity, UpdateMode.Replace);
                #endregion

                #region Snippet:TablesSample5UpdateEntity
                // Query for entities to update.
                Pageable<IDictionary<string, object>> queryResultsBefore = client.Query(filter: $"PartitionKey eq '{partitionKey}'");

                foreach (IDictionary<string, object> qEntity in queryResultsBefore)
                {
                    Console.WriteLine($"The price of {qEntity["Product"]} before updating: ${qEntity["Price"]}");
                    // Changing property of entity.
                    qEntity["Price"] = 7.00;

                    // Extract ETag from the entity.
                    string eTag = qEntity["odata.etag"] as string;

                    // Updating to changed entity using its generated eTag.
                    client.UpdateEntity(qEntity, qEntity["odata.etag"] as string);
                }
                #endregion

                Pageable<IDictionary<string, object>> queryResultsAfter = client.Query(filter: $"PartitionKey eq '{partitionKey}'");
                foreach (IDictionary<string, object> qEntity in queryResultsAfter)
                {
                    Console.WriteLine($"The price of {qEntity["Product"]} after updating: ${qEntity["Price"]}");
                }
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
