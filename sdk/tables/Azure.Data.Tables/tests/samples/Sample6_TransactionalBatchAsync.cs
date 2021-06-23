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
                new TableEntity(partitionKey, "01")
                {
                    { "Product", "Marker" },
                    { "Price", 5.00 },
                    { "Brand", "Premium" }
                },
                new TableEntity(partitionKey, "02")
                {
                    { "Product", "Pen" },
                    { "Price", 3.00 },
                    { "Brand", "Premium" }
                },
                new TableEntity(partitionKey, "03")
                {
                    { "Product", "Paper" },
                    { "Price", 0.10 },
                    { "Brand", "Premium" }
                },
                new TableEntity(partitionKey, "04")
                {
                    { "Product", "Glue" },
                    { "Price", 1.00 },
                    { "Brand", "Generic" }
                },
            };

            // Create the batch.
            List<TableTransactionAction> addEntitiesBatch = new List<TableTransactionAction>();

            // Add the entities to be added to the batch.
            addEntitiesBatch.AddRange(entityList.Select(e => new TableTransactionAction(TableTransactionActionType.Add, e)));

            // Submit the batch.
            Response<IReadOnlyList<Response>> response = await client.SubmitTransactionAsync(addEntitiesBatch).ConfigureAwait(false);

            for (int i = 0; i < entityList.Count; i++)
            {
                Console.WriteLine($"The ETag for the entity with RowKey: '{entityList[i].RowKey}' is {response.Value[i].Headers.ETag}");
            }

            #endregion

            var entity = entityList[0];
            var tableClient = client;

            #region Snippet:MigrationBatchAdd
            // Create a collection of TableTransactionActions and populate it with the actions for each entity.
            List<TableTransactionAction> batch = new List<TableTransactionAction>
            {
                new TableTransactionAction(TableTransactionActionType.UpdateMerge, entity)
            };

            // Execute the transaction.
            Response<IReadOnlyList<Response>> batchResult = tableClient.SubmitTransaction(batch);

            // Display the ETags for each item in the result.
            // Note that the ordering between the entties in the batch and the responses in the batch responses will always be conssitent.
            for (int i = 0; i < batch.Count; i++)
            {
                Console.WriteLine($"The ETag for the entity with RowKey: '{batch[i].Entity.RowKey}' is {batchResult.Value[i].Headers.ETag}");
            }
            #endregion

            #region Snippet:BatchMixed

            // Create a new batch.
            List<TableTransactionAction> mixedBatch = new List<TableTransactionAction>();

            // Add an entity for deletion to the batch.
            mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.Delete, entityList[0]));

            // Remove this entity from our list so that we can track that it will no longer be in the table.
            entityList.RemoveAt(0);

            // Change only the price of the entity with a RoyKey equal to "02".
            TableEntity mergeEntity = new TableEntity(partitionKey, "02") { { "Price", 3.50 }, };

            // Add a merge operation to the batch.
            // We specify an ETag value of ETag.All to indicate that this merge should be unconditional.
            mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.UpdateMerge, mergeEntity, ETag.All));

            // Update a property on an entity.
            TableEntity updateEntity = entityList[2];
            updateEntity["Brand"] = "Generic";

            // Add an upsert operation to the batch.
            // Using the UpsertEntity method allows us to implicitly ignore the ETag value.
            mixedBatch.Add(new TableTransactionAction(TableTransactionActionType.UpsertReplace, updateEntity));

            // Submit the batch.
            await client.SubmitTransactionAsync(mixedBatch).ConfigureAwait(false);

            #endregion

            #region Snippet:BatchDelete

            // Create a new batch.
            List<TableTransactionAction> deleteEntitiesBatch = new List<TableTransactionAction>();

            // Add the entities for deletion to the batch.
            foreach (TableEntity entityToDelete in entityList)
            {
                deleteEntitiesBatch.Add(new TableTransactionAction(TableTransactionActionType.Delete, entityToDelete));
            }

            // Submit the batch.
            await client.SubmitTransactionAsync(deleteEntitiesBatch).ConfigureAwait(false);

            #endregion

            // Delete the table.
            await client.DeleteAsync();
        }
    }
}
