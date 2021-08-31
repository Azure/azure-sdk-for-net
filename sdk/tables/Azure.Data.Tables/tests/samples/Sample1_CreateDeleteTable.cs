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
        public void CreateDeleteTable()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies1p1";

            #region Snippet:TablesSample1CreateClient
            // Construct a new "TableServiceClient using a TableSharedKeyCredential.

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            #region Snippet:TablesSample1CreateTable
            // Create a new table. The TableItem class stores properties of the created table.
#if SNIPPET
            string tableName = "OfficeSupplies1p1";
#endif
            TableItem table = serviceClient.CreateTableIfNotExists(tableName);
            Console.WriteLine($"The created table's name is {table.Name}.");
            #endregion

            #region Snippet:TablesMigrationCreateTableWithClient
            // Get a reference to the TableClient from the service client instance.
            var tableClient = serviceClient.GetTableClient(tableName);

            // Create the table if it doesn't exist.
            tableClient.CreateIfNotExists();
            #endregion

            #region Snippet:TablesSample1DeleteTable
            // Deletes the table made previously.
#if SNIPPET
            string tableName = "OfficeSupplies1p1";
#endif
            serviceClient.DeleteTable(tableName);
            #endregion

            #region Snippet:TablesSample1GetTableClient
#if SNIPPET
            string tableName = "OfficeSupplies1p2";
            var tableClient = serviceClient.GetTableClient(tableName);
#else
            tableName = "OfficeSupplies1p2";
            tableClient = serviceClient.GetTableClient(tableName);
#endif
            #endregion

            #region Snippet:TablesSample1CreateTableClient
#if SNIPPET
            var tableClient = new TableClient(
#else
            tableClient = new TableClient(
#endif
                new Uri(storageUri),
                tableName,
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            #region Snippet:TablesSample1TableClientCreateTable
            tableClient.CreateIfNotExists();
            #endregion

            #region Snippet:TablesSample1TableClientDeleteTable
            tableClient.Delete();
            #endregion
        }
    }
}
