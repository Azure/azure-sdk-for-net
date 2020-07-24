// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

            try
            {
                var client = serviceClient.GetTableClient(tableName);

                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };
                client.CreateEntity(entity);

                var entity2 = new Dictionary<string, object>
                {
                    {"PartitionKey", "another" },
                    {"RowKey", rowKey2 },
                    {"Product", "Chair" },
                    {"Price", 7.00 },
                };
                client.CreateEntity(entity2);

                #region Snippet:TablesSample4QueryEntities
                // Use the <see cref="TableClient"> to query the table. Passing in OData filter strings is optional.
                Pageable<IDictionary<string, object>> queryResults = client.Query(filter: $"PartitionKey eq '{partitionKey}'");

                // Iterate the <see cref="Pageable"> in order to access individual queried entities.
                foreach (IDictionary<string, object> qEntity in queryResults)
                {
                    Console.WriteLine(qEntity["Product"]);
                }

                Console.WriteLine($"The query returned {queryResults.Count()} entities.");
                #endregion

                #region Snippet:TablesSample4QueryEntitiesExpressionTree
                // Use the <see cref="TableClient"> to query the table using a filter expression.
                double priceCutOff = 6.00;
                Pageable<OfficeSupplyEntity> queryResultsLINQ = client.Query<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);

                // Iterate the <see cref="Pageable"> in order to access individual queried entities.
                foreach (OfficeSupplyEntity qEntity in queryResultsLINQ)
                {
                    Console.WriteLine($"{qEntity.Product}: ${qEntity.Price}");
                }

                Console.WriteLine($"The LINQ query returned {queryResultsLINQ.Count()} entities.");
                #endregion
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
