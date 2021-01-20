// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Net;

namespace Azure.Data.Tables.Samples
{
    [LiveOnly]
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public void CreateTableConflict()
        {
            string tableName = "OfficeSupplies";
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={PrimaryStorageAccountKey};EndpointSuffix={StorageEndpointSuffix ?? DefaultStorageSuffix}";

            #region Snippet:CreateDuplicateTable
            // Construct a new TableClient using a connection string.

            var client = new TableClient(
                connectionString,
                tableName);

            // Create the table if it doesn't already exist.

            client.CreateIfNotExists();

            // Now attempt to create the same table unconditionally.

            try
            {
                client.Create();
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
