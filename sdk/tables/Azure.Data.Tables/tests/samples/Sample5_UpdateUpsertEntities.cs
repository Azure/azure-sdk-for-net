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

            #region Snippet:TablesSample5UpsertEntity
            // Get the <see cref="TableClient" /> of the table.
            var client = serviceClient.GetTableClient(tableName);

            // Make an entity.
            var entity = new TableEntity(partitionKey, rowKey)
            {
                {"Product", "Markers" },
                {"Price", 5.00 },
                {"Brand", "myCompany" }
            };

            // Entity doesn't exist in table, so invoking UpsertEntity will simply insert the entity.
            client.UpsertEntity(entity);

            // Delete an entity property.
            entity.Remove("Brand");

            // Entity does exist in the table, so invoking UpsertEntity will update using the given UpdateMode (which defaults to Merge if not given).
            // Since UpdateMode.Replace was passed, the existing entity will be replaced and delete the "Brand" property.
            client.UpsertEntity(entity, TableUpdateMode.Replace);
            #endregion

            #region Snippet:TablesSample5UpdateEntity
            // Query for entities to update.
            Pageable<TableEntity> queryResultsBefore = client.Query<TableEntity>();

            foreach (TableEntity qEntity in queryResultsBefore)
            {
                // Changing property of entity.
                qEntity["Price"] = 7.00;

                // Updating to changed entity using its generated eTag.
                // Since no UpdateMode was passed, the request will default to Merge.
                client.UpdateEntity(qEntity, qEntity.ETag);
            }
            #endregion

            Pageable<TableEntity> queryResultsAfter = client.Query<TableEntity>();
            foreach (TableEntity qEntity in queryResultsAfter)
            {
                Console.WriteLine($"'Price' before updating: ${entity.GetDouble("Price")}");
                Console.WriteLine($"'Price' after updating: ${qEntity.GetDouble("Price")}");
            }

            serviceClient.DeleteTable(tableName);
        }
    }
}
