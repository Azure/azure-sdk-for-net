// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Data.Tables;
using NUnit.Framework;

namespace Microsoft.Azure.Storage.Tables.Tests
{
    public class TableClientTests
    {
        /// <summary>
        /// Failing test to validate CI
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ClientCanGetTables()
        {
            var accountName = "chrissscratch";
            var url = new Uri($"https://{accountName}.table.core.windows.net");
            var key = "";

            TableServiceClient service = new TableServiceClient(url, new TablesSharedKeyCredential(accountName, key));
            await foreach (var table in service.GetTablesAsync())
            {
                Assert.AreEqual("test", table.TableName);
            }
        }
    }
}
