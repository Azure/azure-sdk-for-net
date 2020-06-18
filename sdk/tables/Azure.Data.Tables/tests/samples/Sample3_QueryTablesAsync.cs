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
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies3p2p1";
            string table2Name = "OfficeSupplies3p2p2";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            try
            {
                await serviceClient.CreateTableAsync(tableName).ConfigureAwait(false);
                await serviceClient.CreateTableAsync(table2Name).ConfigureAwait(false);

                AsyncPageable<TableItem> queryTableResults = serviceClient.GetTablesAsync();
                Console.WriteLine("The following are the names of the tables in the query results:");
                await foreach (TableItem table in queryTableResults)
                {
                    Console.WriteLine(table.TableName);
                }
            }
            finally
            {
                await serviceClient.DeleteTableAsync(tableName).ConfigureAwait(false);
                await serviceClient.DeleteTableAsync(table2Name).ConfigureAwait(false);
            }
        }
    }
}
