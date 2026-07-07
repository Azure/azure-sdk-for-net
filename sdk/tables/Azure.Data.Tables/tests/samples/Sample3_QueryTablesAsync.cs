// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Tests;
using NUnit.Framework;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task QueryTablesAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies3p2" + _random.Next();

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            await serviceClient.CreateTableAsync(tableName);

            // Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.
            AsyncPageable<TableItem> queryTableResults = serviceClient.QueryAsync(filter: $"TableName eq '{tableName}'");

            Console.WriteLine("The following are the names of the tables in the query result:");
            // Iterate the <see cref="Pageable"> in order to access individual queried tables.
            await foreach (TableItem table in queryTableResults)
            {
                Console.WriteLine(table.Name);
            }

            await serviceClient.DeleteTableAsync(tableName);
        }
    }
}
