// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Cosmos.Table;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityWriterTests
    {
        [Test]
        [Ignore("TODO")]
        public void FlushAfterAdd_PersistsEntity()
        {
            // Arrange
            var account = new FakeStorageAccount();
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("Table");
            TableEntityWriter<ITableEntity> product = new TableEntityWriter<ITableEntity>(table);
            const string partitionKey = "PK";
            const string rowKey = "RK";
            DynamicTableEntity entity = new DynamicTableEntity(partitionKey, rowKey);
            product.Add(entity);
            // Act
            product.FlushAsync().GetAwaiter().GetResult();
            // Assert
            DynamicTableEntity persisted = table.Retrieve<DynamicTableEntity>(partitionKey, rowKey);
            Assert.NotNull(persisted);
        }
    }
}