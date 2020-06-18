// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task QueryEntitiesAsync()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies4p2";
            string partitionKey = "somePartition";
            string rowKey = "1";
            string rowKey2 = "2";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            try
            {

                await serviceClient.CreateTableAsync(tableName).ConfigureAwait(false);
                var client = serviceClient.GetTableClient(tableName);

                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKey },
                    {"RowKey", rowKey },
                    {"Product", "Markers" },
                    {"Price", 5.00 },
                };
                await client.InsertAsync(entity).ConfigureAwait(false);

                var entity2 = new Dictionary<string, object>
                {
                    {"PartitionKey", "another" },
                    {"RowKey", rowKey2 },
                    {"Product", "Chair" },
                    {"Price", 7.00 },
                };
                await client.InsertAsync(entity2).ConfigureAwait(false);

                AsyncPageable<IDictionary<string, object>> queryResults = client.QueryAsync(filter: $"PartitionKey eq '{partitionKey}'");
                int count = 0;

                await foreach (IDictionary<string, object> qEntity in queryResults)
                {
                    Console.WriteLine(qEntity["Product"]);
                    count++;
                }

                Console.WriteLine($"The results total {count} that matched the query requirements.");
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
