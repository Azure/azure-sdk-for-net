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
        public void CreateTable()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies";

            #region Snippet:TablesSample1CreateClient
            // Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.
            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            try
            {
                #region Snippet:TablesSample1CreateTable
                // Create a new table. The <see cref="TableItem" /> class stores properties of the created table.
                TableItem table = serviceClient.CreateTable(tableName);
                Console.WriteLine($"The created table's name is {table.TableName}.");
                #endregion
            }
            finally
            {
                #region Snippet:TablesSample1DeleteTable
                // Deletes the table made previously.
                serviceClient.DeleteTable(tableName);
                #endregion
            }
        }
    }
}
