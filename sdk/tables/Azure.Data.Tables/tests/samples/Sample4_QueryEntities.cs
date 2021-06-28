// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void QueryEntities()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies4p1";
            string partitionKey = "somePartition";
            string rowKey = "1";
            string rowKey2 = "2";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            serviceClient.CreateTable(tableName);
            var tableClient = serviceClient.GetTableClient(tableName);

            var entity = new TableEntity(partitionKey, rowKey)
            {
                { "Product", "Markers" },
                { "Price", 5.00 },
                { "Quantity", 34 }
            };
            tableClient.AddEntity(entity);

            var entity2 = new TableEntity(partitionKey, rowKey2)
            {
                { "Product", "Planner" },
                { "Price", 7.00 },
                { "Quantity", 34 }
            };
            tableClient.AddEntity(entity2);

            #region Snippet:TablesSample4QueryEntitiesFilter
            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{partitionKey}'");

            // Iterate the <see cref="Pageable"> to access all queried entities.
            foreach (TableEntity qEntity in queryResultsFilter)
            {
                Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
            }

            Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");
            #endregion

            #region Snippet:TablesSample4QueryEntitiesFilterWithQueryFilter
            // The CreateQueryFilter method is also available to assist with properly formatting and escaping OData queries.
#if SNIPPET
            Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: TableClient.CreateQueryFilter($"PartitionKey eq {partitionKey}"));
#else
            queryResultsFilter = tableClient.Query<TableEntity>(filter: TableClient.CreateQueryFilter($"PartitionKey eq {partitionKey}"));
#endif
            // Iterate the <see cref="Pageable"> to access all queried entities.
            foreach (TableEntity qEntity in queryResultsFilter)
            {
                Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
            }

            Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");

            #endregion
            #region Snippet:TablesSample4QueryEntitiesExpression
            double priceCutOff = 6.00;
            Pageable<OfficeSupplyEntity> queryResultsLINQ = tableClient.Query<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);
            #endregion

            #region Snippet:TablesMigrationQuery
            // Execute the query.
            Pageable<OfficeSupplyEntity> queryResults = tableClient.Query<OfficeSupplyEntity>(e => e.PartitionKey == partitionKey && e.RowKey == rowKey);

            // Display the results
            foreach (var item in queryResults.ToList())
            {
                Console.WriteLine($"{item.PartitionKey}, {item.RowKey}, {item.Product}, {item.Price}, {item.Quantity}");
            }
            #endregion

            #region Snippet:TablesSample4QueryEntitiesSelect
            Pageable<TableEntity> queryResultsSelect = tableClient.Query<TableEntity>(select: new List<string>() { "Product", "Price" });
            #endregion

            #region Snippet:TablesSample4QueryEntitiesMaxPerPage
            Pageable<TableEntity> queryResultsMaxPerPage = tableClient.Query<TableEntity>(maxPerPage: 10);

            // Iterate the <see cref="Pageable"> by page.

            foreach (Page<TableEntity> page in queryResultsMaxPerPage.AsPages())
            {
                Console.WriteLine("This is a new page!");
                foreach (TableEntity qEntity in page.Values)
                {
                    Console.WriteLine($"# of {qEntity.GetString("Product")} inventoried: {qEntity.GetInt32("Quantity")}");
                }
            }
            #endregion

            serviceClient.DeleteTable(tableName);
        }
    }
}
