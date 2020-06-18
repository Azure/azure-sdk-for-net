// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void QueryTables()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies3.11";
            string table2Name = "OfficeSupplies3.12";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            try
            {
                serviceClient.CreateTable(tableName);
                serviceClient.CreateTable(table2Name);

                var queryTableResults = serviceClient.GetTables();
                Console.WriteLine("The following are the names of the tables in the query results:");
                foreach (TableItem table in queryTableResults)
                {
                    Console.WriteLine(table.TableName);
                }
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
                serviceClient.DeleteTable(table2Name);
            }
        }
    }
}
