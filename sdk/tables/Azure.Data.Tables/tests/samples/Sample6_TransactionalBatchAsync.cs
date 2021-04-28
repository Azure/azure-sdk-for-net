// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task TransactionalBatchAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSuppliesBatch";
            string partitionKey = "BatchInsertSample";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            await serviceClient.CreateTableAsync(tableName);
            TableClient client = serviceClient.GetTableClient(tableName);

            #region Snippet:BatchAdd

            // Create a list of 5 entities with the same partition key.
#if SNIPPET
            string partitionKey = "BatchInsertSample";
#endif
            List<TableEntity> entityList = new List<TableEntity>
            {
                new TableEntity(partitionKey, "01") { { "Product", "Marker" }, { "Price", 5.00 }, { "Brand", "Premium" } },
                new TableEntity(partitionKey, "02") { { "Product", "Pen" }, { "Price", 3.00 }, { "Brand", "Premium" } },
                new TableEntity(partitionKey, "03") { { "Product", "Paper" }, { "Price", 0.10 }, { "Brand", "Premium" } },
                new TableEntity(partitionKey, "04") { { "Product", "Glue" }, { "Price", 1.00 }, { "Brand", "Generic" } },
            };

            // Create the batch.
            List<BatchItem> addEntitiesBatch = new();

            // Add the entities to be added to the batch.
            addEntitiesBatch.AddRange(entityList.Select(e => new BatchItem(BatchOperation.Add, e)));

            // Submit the batch.
            TableBatchResponse response = await client.SubmitTransactionAsync(addEntitiesBatch).ConfigureAwait(false);

            foreach (TableEntity entity in entityList)
            {
                Console.WriteLine($"The ETag for the entity with RowKey: '{entity.RowKey}' is {response.GetResponseForEntity(entity.RowKey).Headers.ETag}");
            }

            #endregion

            #region Snippet:BatchMixed

            // Create a new batch.
            List<BatchItem> mixedBatch = new();

            // Add an entity for deletion to the batch.
            mixedBatch.Add(new BatchItem(BatchOperation.Delete, entityList[0]));

            // Remove this entity from our list so that we can track that it will no longer be in the table.
            entityList.RemoveAt(0);

            // Change only the price of the entity with a RoyKey equal to "02".
            TableEntity mergeEntity = new TableEntity(partitionKey, "02") { { "Price", 3.50 }, };

            // Add a merge operation to the batch.
            // We specify an ETag value of ETag.All to indicate that this merge should be unconditional.
            mixedBatch.Add(new BatchItem(BatchOperation.UpdateMerge, mergeEntity, ETag.All));

            // Update a property on an entity.
            TableEntity updateEntity = entityList[2];
            updateEntity["Brand"] = "Generic";

            // Add an upsert operation to the batch.
            // Using the UpsertEntity method allows us to implicitly ignore the ETag value.
            mixedBatch.Add(new BatchItem(BatchOperation.UpsertReplace, updateEntity));

            // Submit the batch.
            await client.SubmitTransactionAsync(mixedBatch).ConfigureAwait(false);

            #endregion

            #region Snippet:BatchDelete

            // Create a new batch.
            List<BatchItem> deleteEntitiesBatch = new();

            // Add the entities for deletion to the batch.
            foreach (TableEntity entity in entityList)
            {
                deleteEntitiesBatch.Add(new BatchItem(BatchOperation.Delete, entity));
            }

            // Submit the batch.
            await client.SubmitTransactionAsync(deleteEntitiesBatch).ConfigureAwait(false);

            #endregion

            // Delete the table.
            await client.DeleteAsync();
        }
    }
}
