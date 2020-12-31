// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using Azure.Data.Tables.Models;
using System.Threading.Tasks;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task CreateDeleteTableAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies1p2a";

            // Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.
            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            #region Snippet:TablesSample1CreateTableAsync
            // Create a new table. The <see cref="TableItem" /> class stores properties of the created table.
            TableItem table = await serviceClient.CreateTableAsync(tableName);
            Console.WriteLine($"The created table's name is {table.TableName}.");
            #endregion

            #region Snippet:TablesSample1DeleteTableAsync
            // Deletes the table made previously.
            await serviceClient.DeleteTableAsync(tableName);
            #endregion
        }
    }
}
