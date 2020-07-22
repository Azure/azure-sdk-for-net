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

            await serviceClient.CreateTableAsync(tableName).ConfigureAwait(false);

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
                await client.CreateEntityAsync(entity).ConfigureAwait(false);

                var entity2 = new Dictionary<string, object>
                {
                    {"PartitionKey", "another" },
                    {"RowKey", rowKey2 },
                    {"Product", "Chair" },
                    {"Price", 7.00 },
                };
                await client.CreateEntityAsync(entity2).ConfigureAwait(false);

                #region Snippet:TablesSample4QueryEntitiesAsync
                // Use the <see cref="TableClient"> to query the table. Passing in OData filter strings is optional.
                List<IDictionary<string, object>> queryResults = await client.QueryAsync(filter: $"PartitionKey eq '{partitionKey}'").ToEnumerableAsync().ConfigureAwait(false);

                // Iterate the list in order to access individual queried entities.
                foreach (IDictionary<string, object> qEntity in queryResults)
                {
                    Console.WriteLine(qEntity["Product"]);
                }

                Console.WriteLine($"The results total {queryResults.Count} that matched the query requirements.");
                #endregion

                #region Snippet:TablesSample4QueryEntitiesExpressionTreeAsync
                // Define an expression tree for filtering entities.
                double priceCutOff = 6.00;
                Expression<Func<OfficeSupplyEntity, bool>> gtPrice = ent => ent.Price >= priceCutOff;

                // Use the <see cref="TableClient"> to query the table and pass in expression tree.
                List<OfficeSupplyEntity> queryResultsLINQ = await client.QueryAsync(gtPrice).ToEnumerableAsync().ConfigureAwait(false);

                // Iterate the <see cref="Pageable"> in order to access individual queried entities.
                foreach (OfficeSupplyEntity qEntity in queryResultsLINQ)
                {
                    Console.WriteLine($"{qEntity.Product}: ${qEntity.Price}");
                }
                #endregion
            }
            finally
            {
                await serviceClient.DeleteTableAsync(tableName).ConfigureAwait(false);
            }
        }
    }
}
