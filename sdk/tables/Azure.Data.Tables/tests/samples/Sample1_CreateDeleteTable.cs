// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void CreateDeleteTable()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies1p1" + _random.Next();

            #region Snippet:TablesSample1CreateClient
            // Construct a new "TableServiceClient using a TableSharedKeyCredential.

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            #region Snippet:TablesSample1CreateTable
            // Create a new table. The TableItem class stores properties of the created table.
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
            serviceClient.DeleteTable(tableName);
            #endregion

            #region Snippet:TablesSample1GetTableClient
#if !SNIPPET
            tableName = "OfficeSupplies1p2" + _random.Next();
#endif
            var tableClient2 = serviceClient.GetTableClient(tableName);
            #endregion

            #region Snippet:TablesSample1CreateTableClient
            var tableClient3 = new TableClient(
                new Uri(storageUri),
                tableName,
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            #region Snippet:TablesSample1TableClientCreateTable
            tableClient3.CreateIfNotExists();
            #endregion

            #region Snippet:TablesSample1TableClientDeleteTable
            tableClient3.Delete();
            #endregion
        }
    }
}
