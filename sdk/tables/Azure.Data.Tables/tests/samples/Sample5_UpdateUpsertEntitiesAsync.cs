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
        public async Task UpdateUpsertEntitiesAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies5p2";
            string partitionKey = "somePartition";
            string rowKey = "A1";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            await serviceClient.CreateTableAsync(tableName).ConfigureAwait(false);

            try
            {
                #region Snippet:TablesSample5UpsertEntityAsync
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
                await client.UpsertEntityAsync(entity).ConfigureAwait(false);

                // Delete an entity property.
                entity.Remove("Brand");

                // Entity does exist in the table, so invoking Upsert will replace it with the changed entity and delete the "Brand" property.
                await client.UpsertEntityAsync(entity, UpdateMode.Replace).ConfigureAwait(false);
                #endregion

                #region Snippet:TablesSample5UpdateEntityAsync
                // Query for entities to update.
                AsyncPageable<IDictionary<string, object>> queryResultsBefore = client.QueryAsync(filter: $"PartitionKey eq '{partitionKey}'");

                await foreach (IDictionary<string, object> qEntity in queryResultsBefore)
                {
                    Console.WriteLine($"The price of {qEntity["Product"]} before updating: ${qEntity["Price"]}");
                    // Changing property of entity.
                    qEntity["Price"] = 7.00;

                    // Extract ETag from the entity.
                    string eTag = qEntity["odata.etag"] as string;

                    // Updating to changed entity using its generated eTag.
                    client.UpdateEntity(qEntity, eTag, UpdateMode.Merge);
                }
                #endregion

                AsyncPageable<IDictionary<string, object>> queryResultsAfter = client.QueryAsync(filter: $"PartitionKey eq '{partitionKey}'");
                await foreach (IDictionary<string, object> qEntity in queryResultsAfter)
                {
                    Console.WriteLine($"The price of {qEntity["Product"]} after updating: ${qEntity["Price"]}");
                }
            }
            finally
            {
                await serviceClient.DeleteTableAsync(tableName).ConfigureAwait(false);
            }
        }
    }
}
