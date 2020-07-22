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
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies3p1A";
            string table2Name = "OfficeSupplies3p1B";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            serviceClient.CreateTable(tableName);
            serviceClient.CreateTable(table2Name);

            try
            {
                #region Snippet:TablesSample4QueryEntities
                // Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.
                Pageable<TableItem> queryTableResults = serviceClient.GetTables();

                Console.WriteLine("The following are the names of the tables in the query results:");

                // Iterate the <see cref="Pageable"> in order to access individual queried tables.
                foreach (TableItem table in queryTableResults)
                {
                    Console.WriteLine(table.TableName);
                }
                #endregion
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
                serviceClient.DeleteTable(table2Name);
            }
        }
    }
}
