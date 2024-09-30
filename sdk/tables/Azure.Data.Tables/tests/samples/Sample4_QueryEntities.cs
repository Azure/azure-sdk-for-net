// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Tests;
using NUnit.Framework;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void QueryEntities()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies4p1" + _random.Next();
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
            var queryResultsFilter2 = tableClient.Query<TableEntity>(filter: TableClient.CreateQueryFilter($"PartitionKey eq {partitionKey}"));
            // Iterate the <see cref="Pageable"> to access all queried entities.
            foreach (TableEntity qEntity in queryResultsFilter2)
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

            #region Snippet:TablesSample4QueryPagination

            string continuationToken = null;
            bool moreResultsAvailable = true;
            while (moreResultsAvailable)
            {
                Page<TableEntity> page = tableClient
                    .Query<TableEntity>()
                    .AsPages(continuationToken, pageSizeHint: 10)
                    .FirstOrDefault(); // Note: Since the pageSizeHint only limits the number of results in a single page, we explicitly only enumerate the first page.

                if (page == null)
                    break;

                // Get the continuation token from the page.
                // Note: This value can be stored so that the next page query can be executed later.
                continuationToken = page.ContinuationToken;

                IReadOnlyList<TableEntity> pageResults = page.Values;
                moreResultsAvailable = continuationToken != null;

                // Print out the results for this page.
                foreach (TableEntity result in pageResults)
                {
                    Console.WriteLine($"{result.PartitionKey}-{result.RowKey}");
                }
            }
            #endregion

            serviceClient.DeleteTable(tableName);
        }
    }
}
