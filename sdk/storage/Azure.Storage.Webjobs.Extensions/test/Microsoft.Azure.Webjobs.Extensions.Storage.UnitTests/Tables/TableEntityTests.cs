// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class TableEntityTests
    {
        private const string TriggerQueueName = "input";
        private const string TableName = "Table";
        private const string PartitionKey = "PK";
        private const string RowKey = "RK";

        [Fact]
        public async Task TableEntity_IfBoundToExistingDynamicTableEntity_Binds()
        {
            // Arrange
            const string expectedKey = "abc";
            const int expectedValue = 123;
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage("ignore"));

            CloudTable table = await account.CreateTableAsync(TableName);
            Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>
            {
                { expectedKey, new EntityProperty(expectedValue) }
            };
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: properties));

            // Act
            DynamicTableEntity result = await RunTriggerAsync<DynamicTableEntity>(account, typeof(BindToDynamicTableEntityProgram),
                (s) => BindToDynamicTableEntityProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(PartitionKey, result.PartitionKey);
            Assert.Equal(RowKey, result.RowKey);
            Assert.NotNull(result.Properties);
            Assert.True(result.Properties.ContainsKey(expectedKey));
            EntityProperty property = result.Properties[expectedKey];
            Assert.NotNull(property);
            Assert.Equal(EdmType.Int32, property.PropertyType);
            Assert.Equal(expectedValue, property.Int32Value);
        }

        [Fact]
        public async Task TableEntity_IfBoundToExistingPoco_Binds()
        {
            // Arrange
            const string expectedValue = "abc";
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage("ignore"));

            CloudTable table = await account.CreateTableAsync(TableName);
            Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>
            {
                { "Value", new EntityProperty(expectedValue) }
            };
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: properties));

            // Act
            Poco result = await RunTriggerAsync<Poco>(account, typeof(BindToPocoProgram),
                (s) => BindToPocoProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedValue, result.Value);
        }

        [Fact]
        public async Task TableEntity_IfUpdatesPoco_Persists()
        {
            // Arrange
            const string originalValue = "abc";
            const string expectedValue = "def";
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(expectedValue));

            CloudTable table = await account.CreateTableAsync(TableName);
            Dictionary<string, EntityProperty> originalProperties = new Dictionary<string, EntityProperty>
            {
                { "Value", new EntityProperty(originalValue) }
            };
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: originalProperties));

            // Act
            await RunTriggerAsync(account, typeof(UpdatePocoProgram));

            // Assert
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            IDictionary<string, EntityProperty> properties = entity.Properties;
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey("Value"));
            EntityProperty property = properties["Value"];
            Assert.NotNull(property);
            Assert.Equal(EdmType.String, property.PropertyType);
            Assert.Equal(expectedValue, property.StringValue);
        }

        [Fact]
        public async Task TableEntity_IfBoundToExistingPoco_BindsUsingNativeTableTypes()
        {
            // Arrange
            byte[] expectedValue = new byte[] { 0x12, 0x34 };
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage("ignore"));

            CloudTable table = await account.CreateTableAsync(TableName);
            Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>
            {
                { "Value", new EntityProperty(expectedValue) }
            };
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: properties));

            // Act
            PocoWithByteArrayValue result = await RunTriggerAsync<PocoWithByteArrayValue>(account,
                typeof(BindToPocoWithByteArrayValueProgram), (s) => BindToPocoWithByteArrayValueProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedValue, result.Value);
        }

        [Fact]
        public async Task TableEntity_IfUpdatesPoco_PersistsUsingNativeTableTypes()
        {
            // Arrange
            byte[] originalValue = new byte[] { 0x12, 0x34 };
            byte[] expectedValue = new byte[] { 0x56, 0x78 };
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(expectedValue));

            CloudTable table = await account.CreateTableAsync(TableName);
            Dictionary<string, EntityProperty> originalProperties = new Dictionary<string, EntityProperty>
            {
                { "Value", new EntityProperty(originalValue) }
            };
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: originalProperties));

            // Act
            await RunTriggerAsync(account, typeof(UpdatePocoWithByteArrayValueProgram));

            // Assert
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            IDictionary<string, EntityProperty> properties = entity.Properties;
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey("Value"));
            EntityProperty property = properties["Value"];
            Assert.NotNull(property);
            Assert.Equal(EdmType.Binary, property.PropertyType);
            Assert.Equal(expectedValue, property.BinaryValue);
        }

        [Fact]
        public async Task TableEntity_IfUpdatesPartitionKey_Throws()
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage("ignore"));

            CloudTable table = await account.CreateTableAsync(TableName);
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey));

            // Act
            Exception exception = await RunTriggerFailureAsync(account, typeof(UpdatePocoPartitionKeyProgram));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Error while handling parameter entity after function returned:", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.NotNull(innerException);
            Assert.IsType<InvalidOperationException>(innerException);
            Assert.Equal("When binding to a table entity, the partition key must not be changed.",
                innerException.Message);
        }

        [Fact]
        public async Task TableEntity_IfUpdatesRowKey_Throws()
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage("ignore"));

            CloudTable table = await account.CreateTableAsync(TableName);
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey));

            // Act
            Exception exception = await RunTriggerFailureAsync(account, typeof(UpdatePocoRowKeyProgram));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Error while handling parameter entity after function returned:", exception.Message);
            Exception innerException = exception.InnerException;
            Assert.NotNull(innerException);
            Assert.IsType<InvalidOperationException>(innerException);
            Assert.Equal("When binding to a table entity, the row key must not be changed.", innerException.Message);
        }

        [Fact]
        public async Task TableEntity_IfBoundUsingRouteParameters_Binds()
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            const string tableName = TableName + "B";
            const string partitionKey = PartitionKey + "B";
            const string rowKey = RowKey + "B";
            TableEntityMessage message = new TableEntityMessage
            {
                TableName = tableName,
                PartitionKey = partitionKey,
                RowKey = rowKey
            };
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(JsonConvert.SerializeObject(message)));

            CloudTable table = await account.CreateTableAsync(tableName);
            Dictionary<string, EntityProperty> originalProperties = new Dictionary<string, EntityProperty>
            {
                { "Value", new EntityProperty(123) }
            };
            table.Insert(new DynamicTableEntity(partitionKey, rowKey, etag: null, properties: originalProperties));

            // Act
            await RunTriggerAsync(account, typeof(BindUsingRouteParametersProgram));

            // Assert
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(partitionKey, rowKey);
            Assert.NotNull(entity);
            IDictionary<string, EntityProperty> properties = entity.Properties;
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey("Value"));
            EntityProperty property = properties["Value"];
            Assert.NotNull(property);
            Assert.Equal(EdmType.Int32, property.PropertyType);
            Assert.True(property.Int32Value.HasValue);
            Assert.Equal(456, property.Int32Value.Value);
        }

        private static StorageAccount CreateFakeStorageAccount()
        {
            return new FakeStorageAccount();
        }

        private static async Task RunTriggerAsync(StorageAccount account, Type programType)
        {
            await FunctionalTest.RunTriggerAsync(account, programType);
        }

        private static async Task<TResult> RunTriggerAsync<TResult>(StorageAccount account, Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(account, programType, setTaskSource);
        }

        private static async Task<Exception> RunTriggerFailureAsync(StorageAccount account, Type programType)
        {
            return await FunctionalTest.RunTriggerFailureAsync<bool>(account, programType, (tcs) => {/* do nothing */});
        }

        private class BindToDynamicTableEntityProgram
        {
            public static TaskCompletionSource<DynamicTableEntity> TaskSource { get; set; }

            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage ignore,
                [Table(TableName, PartitionKey, RowKey)] DynamicTableEntity entity)
            {
                TaskSource.TrySetResult(entity);
            }
        }

        private class BindToPocoProgram
        {
            public static TaskCompletionSource<Poco> TaskSource { get; set; }

            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage ignore,
                [Table(TableName, PartitionKey, RowKey)] Poco entity)
            {
                TaskSource.TrySetResult(entity);
            }
        }

        private class UpdatePocoProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage message,
                [Table(TableName, PartitionKey, RowKey)] Poco entity)
            {
                entity.Value = message.AsString;
            }
        }

        private class BindToPocoWithByteArrayValueProgram
        {
            public static TaskCompletionSource<PocoWithByteArrayValue> TaskSource { get; set; }

            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage ignore,
                [Table(TableName, PartitionKey, RowKey)] PocoWithByteArrayValue entity)
            {
                TaskSource.TrySetResult(entity);
            }
        }

        private class UpdatePocoWithByteArrayValueProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage message,
                [Table(TableName, PartitionKey, RowKey)] PocoWithByteArrayValue entity)
            {
                entity.Value = message.AsBytes;
            }
        }

        private class UpdatePocoPartitionKeyProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage ignore,
                [Table(TableName, PartitionKey, RowKey)] PocoWithKeys entity)
            {
                entity.PartitionKey = Guid.NewGuid().ToString();
            }
        }

        private class UpdatePocoRowKeyProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage ignore,
                [Table(TableName, PartitionKey, RowKey)] PocoWithKeys entity)
            {
                entity.RowKey = Guid.NewGuid().ToString();
            }
        }

        private class BindUsingRouteParametersProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] TableEntityMessage message,
                [Table("{TableName}", "{PartitionKey}", "{RowKey}")] SdkTableEntity entity)
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

        private class SdkTableEntity : TableEntity
        {
            public int Value { get; set; }
        }
    }
}