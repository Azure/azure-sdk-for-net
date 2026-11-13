// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Tests;
using NUnit.Framework;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task CreateDeleteTableAsync()
        {
            string storageUri = StorageUri;
            string accountName = StorageAccountName;
            string storageAccountKey = PrimaryStorageAccountKey;
            string tableName = "OfficeSupplies1p2a" + _random.Next();

            // Construct a new <see cref="TableServiceClient" /> using a <see cref="TableSharedKeyCredential" />.
            var serviceClient = new TableServiceClient(
                new Uri(storageUri),
                new TableSharedKeyCredential(accountName, storageAccountKey));

            // Create a new table. The <see cref="TableItem" /> class stores properties of the created table.
            TableItem table = await serviceClient.CreateTableAsync(tableName);
            Console.WriteLine($"The created table's name is {table.Name}.");

            // Deletes the table made previously.
            await serviceClient.DeleteTableAsync(tableName);
        }
    }
}
