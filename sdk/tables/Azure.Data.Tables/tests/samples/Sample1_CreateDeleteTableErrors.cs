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

            try
            {
                #region Snippet:TablesSample1CreateExistingTable
                serviceClient.CreateTable(tableName);
                serviceClient.CreateTable(tableName); // second create request
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine($"TableErrors threw an exception.");
                Console.WriteLine(e.Message);
            }
            finally
            {
                serviceClient.DeleteTable(tableName);
            }
        }
    }
}
