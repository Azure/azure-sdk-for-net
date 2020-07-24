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

            await serviceClient.CreateTableAsync(tableName);

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

                // Entity doesn't exist in table, so invoking UpsertEntity will simply insert the entity.
                await client.UpsertEntityAsync(entity);

                // Delete an entity property.
                entity.Remove("Brand");

                // Entity does exist in the table, so invoking UpsertEntity will update using the given UpdateMode (which defaults to Merge if not given).
                // Since UpdateMode.Replace was passed, the existing entity will be replaced and delete the "Brand" property.
                await client.UpsertEntityAsync(entity, UpdateMode.Replace);
                #endregion


                #region Snippet:TablesSample5UpdateEntityAsync
                // Query for entities to update.
                AsyncPageable<IDictionary<string, object>> queryResultsBefore = client.QueryAsync();

                await foreach (IDictionary<string, object> qEntity in queryResultsBefore)
                {
                    // Changing property of entity.
                    qEntity["Price"] = 7.00;

                    // Extract ETag from the entity.
                    string eTag = qEntity["odata.etag"] as string;

                    // Updating to changed entity using its generated eTag.
                    // Since no UpdateMode was passed, the request will default to Merge.
                    await client.UpdateEntityAsync(qEntity, eTag);
                }
                #endregion

                AsyncPageable<IDictionary<string, object>> queryResultsAfter = client.QueryAsync();
                await foreach (IDictionary<string, object> qEntity in queryResultsAfter)
                {
                    Console.WriteLine($"'Price' before updating: ${entity["Price"]}");
                    Console.WriteLine($"'Price' after updating: ${qEntity["Price"]}");
                }
            }
            finally
            {
                await serviceClient.DeleteTableAsync(tableName);
            }
        }
    }
}
