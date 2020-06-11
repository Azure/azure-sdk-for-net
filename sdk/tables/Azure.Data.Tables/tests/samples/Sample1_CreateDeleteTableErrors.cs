// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void TableCreateError()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies2";

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
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
