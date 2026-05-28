// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void CreateDeleteTableError()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies1p3";

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            #region Snippet:TablesSample1CreateExistingTable
            try
            {
                // Creates a table.
                serviceClient.CreateTable(tableName);

                // Second attempt to create table with the same name should throw exception.
                serviceClient.CreateTable(tableName);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("Create existing table throws the following exception:");
                Console.WriteLine(e.Message);
            }
            #endregion

            try
            {
                // Deletes the table.
                serviceClient.DeleteTable(tableName);

                // Second attempt to delete table with the same name should throw exception.
                serviceClient.DeleteTable(tableName);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("Deleting a nonexistent table throws the following exception:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
