// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task QueryEntitiesAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies4p2";
            string partitionKey = "somePartition";
            string rowKey = "1";
            string rowKey2 = "2";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            await serviceClient.CreateTableAsync(tableName);
            var tableClient = serviceClient.GetTableClient(tableName);

            var entity = new TableEntity(partitionKey, rowKey)
            {
                {"Product", "Markers" },
                {"Price", 5.00 },
            };
            await tableClient.CreateEntityAsync(entity);

            var entity2 = new TableEntity(partitionKey, rowKey2)
            {
                {"Product", "Chair" },
                {"Price", 7.00 },
            };
            await tableClient.CreateEntityAsync(entity2);

            #region Snippet:TablesSample4QueryEntitiesAsync
            // Use the <see cref="TableClient"> to query the table. Passing in OData filter strings is optional.
            AsyncPageable<TableEntity> queryResults = tableClient.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");
            int count = 0;

            // Iterate the list in order to access individual queried entities.
            await foreach (TableEntity qEntity in queryResults)
            {
                Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
                count++;
            }

            Console.WriteLine($"The query returned {count} entities.");
            #endregion

            #region Snippet:TablesSample4QueryEntitiesExpressionAsync
            // Use the <see cref="TableClient"> to query the table using a filter expression.
            double priceCutOff = 6.00;
            AsyncPageable<OfficeSupplyEntity> queryResultsLINQ = tableClient.QueryAsync<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);
            #endregion

            #region Snippet:TablesSample4QueryEntitiesSelectAsync
            AsyncPageable<TableEntity> queryResultsSelect = tableClient.QueryAsync<TableEntity>(select: new List<string>() { "Product", "Price" });
            #endregion

            #region Snippet:TablesSample4QueryEntitiesMaxPerPageAsync
            AsyncPageable<TableEntity> queryResultsMaxPerPage = tableClient.QueryAsync<TableEntity>(maxPerPage: 10);

            // Iterate the <see cref="Pageable"> by page.
            await foreach (Page<TableEntity> page in queryResultsMaxPerPage.AsPages())
            {
                Console.WriteLine("This is a new page!");
                foreach (TableEntity qEntity in page.Values)
                {
                    Console.WriteLine($"# of {qEntity.GetString("Product")} inventoried: {qEntity.GetInt32("Quantity")}");
                }
            }
            #endregion

            await serviceClient.DeleteTableAsync(tableName);
        }
    }
}
