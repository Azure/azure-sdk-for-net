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
            // Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.
            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            #region Snippet:TablesSample1CreateTable
            // Create a new table. The <see cref="TableItem" /> class stores properties of the created table.
            TableItem table = serviceClient.CreateTable(tableName);
            Console.WriteLine($"The created table's name is {table.TableName}.");
            #endregion

            #region Snippet:TablesSample1DeleteTable
            // Deletes the table made previously.
            serviceClient.DeleteTable(tableName);
            #endregion

            #region Snippet:TablesSample1GetTableClient
            tableName = "OfficeSupplies1p2";
            var tableClient = serviceClient.GetTableClient(tableName);
            #endregion

            #region Snippet:TablesSample1CreateTableClient
            tableClient = new TableClient(
                tableName,
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            #region Snippet:TablesSample1TableClientCreateTable
            tableClient.Create();
            #endregion

            #region Snippet:TablesSample1TableClientDeleteTable
            tableClient.Delete();
            #endregion
        }
    }
}
