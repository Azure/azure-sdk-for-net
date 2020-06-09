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
        public void CreateTable()
        {
            string storageUri = StorageUri;
            string accountName = AccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies";

            #region Snippet:TablesSample1CreateClient
            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));
            #endregion

            try
            {
                #region Snippet:TablesSample1CreateTable
                serviceClient.CreateTable(tableName);
                var client = serviceClient.GetTableClient(tableName);
                #endregion
            }
            catch
            {
                Console.WriteLine("Shouldn't throw an error.");
            }
            finally
            {
                #region Snippet:TablesSample1DeleteTable
                serviceClient.DeleteTable(tableName);
                #endregion
            }
        }
    }
}
