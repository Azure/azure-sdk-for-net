// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using Azure.Data.Tables.Models;
using System.Threading.Tasks;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task QueryTablesAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies3p2";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            await serviceClient.CreateTableAsync(tableName);

            #region Snippet:TablesSample3QueryTablesAsync
            // Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.
            AsyncPageable<TableItem> queryTableResults = serviceClient.GetTablesAsync(filter: $"TableName eq '{tableName}'");

            Console.WriteLine("The following are the names of the tables in the query result:");
            // Iterate the <see cref="Pageable"> in order to access individual queried tables.
            await foreach (TableItem table in queryTableResults)
            {
                Console.WriteLine(table.TableName);
            }
            #endregion

            await serviceClient.DeleteTableAsync(tableName);
        }
    }
}
