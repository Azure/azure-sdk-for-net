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
                await client.CreateEntityAsync(entity);

                var entity2 = new Dictionary<string, object>
                {
                    {"PartitionKey", "another" },
                    {"RowKey", rowKey2 },
                    {"Product", "Chair" },
                    {"Price", 7.00 },
                };
                await client.CreateEntityAsync(entity2);

                #region Snippet:TablesSample4QueryEntitiesAsync
                // Use the <see cref="TableClient"> to query the table. Passing in OData filter strings is optional.
                AsyncPageable<IDictionary<string, object>> queryResults = client.QueryAsync(filter: $"PartitionKey eq '{partitionKey}'");
                int count = 0;

                // Iterate the list in order to access individual queried entities.
                await foreach (IDictionary<string, object> qEntity in queryResults)
                {
                    Console.WriteLine(qEntity["Product"]);
                    count++;
                }

                Console.WriteLine($"The query returned {count} entities.");
                #endregion

                #region Snippet:TablesSample4QueryEntitiesExpressionTreeAsync
                // Use the <see cref="TableClient"> to query the table and pass in expression tree.
                double priceCutOff = 6.00;
                AsyncPageable<OfficeSupplyEntity> queryResultsLINQ = client.QueryAsync<OfficeSupplyEntity>(ent => ent.Price >= priceCutOff);
                count = 0;

                // Iterate the <see cref="Pageable"> in order to access individual queried entities.
                await foreach (OfficeSupplyEntity qEntity in queryResultsLINQ)
                {
                    Console.WriteLine($"{qEntity.Product}: ${qEntity.Price}");
                    count++;
                }

                Console.WriteLine($"The LINQ query returned {count} entities.");
                #endregion
            }
            finally
            {
                await serviceClient.DeleteTableAsync(tableName);
            }
        }
    }
}
