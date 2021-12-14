// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityLiveTests: TablesLiveTestBase
    {
        [Test]
        public async Task TableEntity_IfBoundToExistingTableEntity_Binds()
        {
            // Arrange
            const string expectedKey = "abc";
            const int expectedValue = 123;

            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { expectedKey, (expectedValue) }
            });
            // Act
            var function = await CallAsync<BindToTableEntityProgram>();
            var result = function.Entity;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(PartitionKey, result.PartitionKey);
            Assert.AreEqual(RowKey, result.RowKey);
            Assert.AreEqual(expectedValue, result[expectedKey]);
        }

        [Test]
        public async Task TableEntity_IfBoundToExistingPoco_Binds()
        {
            // Arrange
            const string expectedValue = "abc";

            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { "Value", (expectedValue) }
            });

            // Act
            var function = await CallAsync<BindToPocoProgram>(arguments: new
            {
                newValue = expectedValue
            });
            var result = function.Entity;
            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [Test]
        public async Task TableEntity_IfUpdatesPoco_Persists()
        {
            // Arrange
            const string originalValue = "abc";
            const string expectedValue = "def";

            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { "Value", (originalValue) }
            });

            // Act
            await CallAsync<UpdatePocoProgram>(arguments: new
            {
                newValue = expectedValue
            });

            // Assert
            TableEntity entity = await TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual(expectedValue, entity["Value"]);
        }

        [Test]
        public async Task TableEntity_IfBoundToExistingPoco_BindsUsingNativeTableTypes()
        {
            // Arrange
            byte[] expectedValue = new byte[] { 0x12, 0x34 };

            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { "Value", (expectedValue) }
            });
            // Act
            var function = await CallAsync<BindToPocoWithByteArrayValueProgram>();
            var result = function.Entity;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [Test]
        public async Task TableEntity_IfUpdatesPoco_PersistsUsingNativeTableTypes()
        {
            // Arrange
            byte[] originalValue = new byte[] { 0x12, 0x34 };
            byte[] expectedValue = new byte[] { 0x56, 0x78 };

            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { "Value", (originalValue) }
            });

            // Act
            await CallAsync<UpdatePocoWithByteArrayValueProgram>(arguments: new
            {
                expectedValue
            });

            // Assert
            TableEntity entity = await TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual(expectedValue, entity["Value"]);
        }

        [Test]
        public async Task TableEntity_IfUpdatesPartitionKey_Throws()
        {
            // Arrange
            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey));

            // Act
            var functionException = Assert.CatchAsync<FunctionInvocationException>(async () => await CallAsync<UpdatePocoPartitionKeyProgram>());
            Exception exception = functionException.InnerException;

            // Assert
            Assert.NotNull(exception);
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Error while handling parameter entity after function returned:", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.NotNull(innerException);
            Assert.IsInstanceOf<InvalidOperationException>(innerException);
            Assert.AreEqual("When binding to a table entity, the partition key must not be changed.",
                innerException.Message);
        }

        [Test]
        public async Task TableEntity_IfUpdatesRowKey_Throws()
        {
            // Arrange
            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey));

            // Act
            var functionException = Assert.CatchAsync<FunctionInvocationException>(async () => await CallAsync<UpdatePocoRowKeyProgram>());
            Exception exception = functionException.InnerException;

            // Assert
            Assert.NotNull(exception);
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Error while handling parameter entity after function returned:", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.NotNull(innerException);
            Assert.IsInstanceOf<InvalidOperationException>(innerException);
            Assert.AreEqual("When binding to a table entity, the row key must not be changed.", innerException.Message);
        }

        [Test]
        public async Task TableEntity_IfBoundUsingRouteParameters_Binds()
        {
            // Arrange

            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { "Value", (123) }
            });

            // Act
            await CallAsync<BindUsingRouteParametersProgram>(arguments: new
            {
                TableName = TableName,
                PartitionKey = PartitionKey,
                RowKey = RowKey
            });

            // Assert
            TableEntity entity = await TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual(456, entity["Value"]);
        }

        private class BindToTableEntityProgram
        {
            public void Run([Table(TableNameExpression, PartitionKey, RowKey)] TableEntity entity)
            {
                Entity = entity;
            }

            public TableEntity Entity { get; set; }
        }

        private class BindToPocoProgram
        {
            public void Run([Table(TableNameExpression, PartitionKey, RowKey)] Poco entity)
            {
                Entity = entity;
            }

            public Poco Entity { get; set; }
        }

        private class UpdatePocoProgram
        {
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] Poco entity, string newValue)
            {
                entity.Value = newValue;
            }
        }

        private class BindToPocoWithByteArrayValueProgram
        {
            public void Run([Table(TableNameExpression, PartitionKey, RowKey)] PocoWithByteArrayValue entity)
            {
                Entity = entity;
            }

            public PocoWithByteArrayValue Entity { get; set; }
        }

        private class UpdatePocoWithByteArrayValueProgram
        {
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] PocoWithByteArrayValue entity, byte[] expectedValue)
            {
                entity.Value = expectedValue;
            }
        }

        private class UpdatePocoPartitionKeyProgram
        {
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] PocoWithKeys entity)
            {
                entity.PartitionKey = Guid.NewGuid().ToString();
            }
        }

        private class UpdatePocoRowKeyProgram
        {
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] PocoWithKeys entity)
            {
                entity.RowKey = Guid.NewGuid().ToString();
            }
        }

        private class BindUsingRouteParametersProgram
        {
            public static void Run([Table("{TableName}", "{PartitionKey}", "{RowKey}")] SdkTableEntity entity)
            {
                entity.Value = 456;
            }
        }

        private class Poco
        {
            public string Value { get; set; }
        }

        private class PocoWithByteArrayValue
        {
            public byte[] Value { get; set; }
        }

        private class PocoWithKeys
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
        }

        private class TableEntityMessage
        {
            public string TableName { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
        }

        private class SdkTableEntity : ITableEntity
        {
            public int Value { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }
    }
}