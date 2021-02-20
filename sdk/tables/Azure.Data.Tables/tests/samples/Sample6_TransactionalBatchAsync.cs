// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Threading.Tasks;
using System.Collections.Generic;
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
            //@@string partitionKey = "BatchInsertSample";
            List<TableEntity> entityList = new List<TableEntity>{
                new TableEntity(partitionKey, "01")
                {
                    {"Product", "Marker" },
                    {"Price", 5.00 },
                    {"Brand", "Premium" }
                },
                new TableEntity(partitionKey, "02")
                {
                    {"Product", "Pen" },
                    {"Price", 3.00 },
                    {"Brand", "Premium" }
                },
                new TableEntity(partitionKey, "03")
                {
                    {"Product", "Paper" },
                    {"Price", 0.10 },
                    {"Brand", "Premium" }
                },
                new TableEntity(partitionKey, "04")
                {
                    {"Product", "Glue" },
                    {"Price", 1.00 },
                    {"Brand", "Generic" }
                },
            };

            // Create the batch.
            TableTransactionalBatch addEntitiesBatch = client.CreateTransactionalBatch(partitionKey);

            // Add the entities to be added to the batch.
            addEntitiesBatch.AddEntities(entityList);

            // Submit the batch.
            TableBatchResponse response = await addEntitiesBatch.SubmitBatchAsync().ConfigureAwait(false);

            foreach (TableEntity entity in entityList)
            {
                Console.WriteLine($"The ETag for the entity with RowKey: '{entity.RowKey}' is {response.GetResponseForEntity(entity.RowKey).Headers.ETag}");
            }
            #endregion

            #region Snippet:BatchMixed
            // Create a new batch.
            TableTransactionalBatch mixedBatch = client.CreateTransactionalBatch(partitionKey);

            // Add an entity for deletion to the batch.
            mixedBatch.DeleteEntity(entityList[0].RowKey);

            // Remove this entity from our list so that we can track that it will no longer be in the table.
            entityList.RemoveAt(0);

            // Change only the price of the entity with a RoyKey equal to "02".
            TableEntity mergeEntity = new TableEntity(partitionKey, "02")
            {
                {"Price", 3.50 },
            };

            // Add a merge operation to the batch.
            // We specify an ETag value of ETag.All to indicate that this merge should be unconditional.
            mixedBatch.UpdateEntity(mergeEntity, ETag.All, TableUpdateMode.Merge);

            // Update a property on an entity.
            TableEntity updateEntity = entityList[2];
            updateEntity["Brand"] = "Generic";

            // Add an update operation to the batch.
            // Using the UpsertEntity method allows us to implicitly ignore the ETag value.
            mixedBatch.UpsertEntity(updateEntity, TableUpdateMode.Replace);

             // Submit the batch.
            await mixedBatch.SubmitBatchAsync().ConfigureAwait(false);
            #endregion

            #region Snippet:BatchDelete
            // Create a new batch.
            TableTransactionalBatch deleteEntitiesBatch = client.CreateTransactionalBatch(partitionKey);

            // Add the entities for deletion to the batch.
            foreach (TableEntity entity in entityList)
            {
                deleteEntitiesBatch.DeleteEntity(entity.RowKey);
            }

            // Submit the batch.
            await deleteEntitiesBatch.SubmitBatchAsync().ConfigureAwait(false);
            #endregion

            // Delete the table.
            await client.DeleteAsync();
        }
    }
}
