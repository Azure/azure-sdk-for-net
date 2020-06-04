// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : SamplesBase<TablesTestEnvironment>
    {
        [Test]
        public void CreateTable()
        {
            string storageUri = TestEnvironment.StorageUri;
            string accountName = TestEnvironment.AccountName;
            string storageAccountKey = TestEnvironment.PrimaryStorageAccountKey;
            string tableName = "mytesttable";

            #region Snippet:TablesSample1CreateClient

            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            #endregion

            #region Snippet:CreateTable

            serviceClient.CreateTable(tableName);

            #endregion

            serviceClient.DeleteTable(tableName);
        }
    }
}
