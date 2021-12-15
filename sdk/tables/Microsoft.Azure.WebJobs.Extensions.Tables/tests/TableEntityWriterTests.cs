// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Azure.Data.Tables;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityWriterTests
    {
        [Test]
        [Ignore("TODO")]
        public async Task FlushAfterAdd_PersistsEntity()
        {
            // Arrange
            var table = Mock.Of<TableClient>();
            TableEntityWriter<ITableEntity> product = new TableEntityWriter<ITableEntity>(table);
            const string partitionKey = "PK";
            const string rowKey = "RK";
            TableEntity entity = new TableEntity(partitionKey, rowKey);
            product.Add(entity);
            // Act
            product.FlushAsync().GetAwaiter().GetResult();
            // Assert
            TableEntity persisted = await table.GetEntityAsync<TableEntity>(partitionKey, rowKey);
            Assert.NotNull(persisted);
        }
    }
}