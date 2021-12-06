// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Host.FunctionalTests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Xunit;
namespace Microsoft.Azure.WebJobs.Host.UnitTests.Tables
{
    public class HostCallTableTests
    {
        private const string ContainerName = "container";
        private const string TableName = "Table";
        private const string PartitionKey = "PK";
        private const string RowKey = "RK";
        private const int TestValue = Int32.MinValue;
        private const string TestQueueMessage = "ignore";
        [Theory]
        [InlineData("FuncWithITableEntity")]
        [InlineData("FuncWithPocoObjectEntity")]
        [InlineData("FuncWithPocoValueEntity")]
        [InlineData("FuncWithICollector")]
        public async Task Table_IfBoundToTypeAndTableIsMissing_DoesNotCreate(string methodName)
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            // Act
            await CallAsync(account, typeof(MissingTableProgram), methodName).ConfigureAwait(false);
            // Assert
            Assert.False(await table.ExistsAsync().ConfigureAwait(false));
        }
        [Fact]
        public async Task Table_IfBoundToCloudTableAndTableIsMissing_Creates()
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            // Act
            CloudTable result = await CallAsync<CloudTable>(account, typeof(BindToCloudTableProgram), "BindToCloudTable",
                (s) => BindToCloudTableProgram.TaskSource = s).ConfigureAwait(false);
            // Assert
            Assert.NotNull(result);
            var table = account.CreateCloudTableClient().GetTableReference(TableName);
            Assert.True(await table.ExistsAsync().ConfigureAwait(false));
        }
        private class BindToCloudTableProgram
        {
            public static TaskCompletionSource<CloudTable> TaskSource { get; set; }
            public static void BindToCloudTable([Table(TableName)] CloudTable queue)
            {
                TaskSource.TrySetResult(queue);
            }
        }
        [Fact]
        public async Task Table_IfBoundToICollectorITableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync(typeof(BindTableToICollectorITableEntity)).ConfigureAwait(false);
        }
        private class BindTableToICollectorITableEntity
        {
            public static void Call([Table(TableName)] ICollector<ITableEntity> table)
            {
                table.Add(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }
        [Fact]
        public async Task Table_IfBoundToICollectorDynamicTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync(typeof(BindTableToICollectorDynamicTableEntity)).ConfigureAwait(false);
        }
        private class BindTableToICollectorDynamicTableEntity
        {
            public static void Call([Table(TableName)] ICollector<DynamicTableEntity> table)
            {
                table.Add(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }
        [Fact]
        public async Task Table_IfBoundToICollectorSdkTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync(typeof(BindTableToICollectorSdkTableEntity)).ConfigureAwait(false);
        }
        private class BindTableToICollectorSdkTableEntity
        {
            public static void Call([Table(TableName)] ICollector<SdkTableEntity> table)
            {
                table.Add(new SdkTableEntity { PartitionKey = PartitionKey, RowKey = RowKey });
            }
        }
        [Fact]
        public async Task Table_IfBoundToIAsyncCollectorITableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync(typeof(BindTableToIAsyncCollectorITableEntity)).ConfigureAwait(false);
        }
        private class BindTableToIAsyncCollectorITableEntity
        {
            public static Task Call([Table(TableName)] IAsyncCollector<ITableEntity> table)
            {
                return table.AddAsync(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }
        [Fact]
        public async Task Table_IfBoundToIAsyncCollectorDynamicTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync(typeof(BindTableToIAsyncCollectorDynamicTableEntity)).ConfigureAwait(false);
        }
        private class BindTableToIAsyncCollectorDynamicTableEntity
        {
            public static Task Call([Table(TableName)] IAsyncCollector<DynamicTableEntity> table)
            {
                return table.AddAsync(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }
        [Fact]
        public async Task Table_IfBoundToIAsyncCollectorSdkTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync(typeof(BindTableToIAsyncCollectorSdkTableEntity)).ConfigureAwait(false);
        }
        private class BindTableToIAsyncCollectorSdkTableEntity
        {
            public static Task Call([Table(TableName)] IAsyncCollector<SdkTableEntity> table)
            {
                return table.AddAsync(new SdkTableEntity { PartitionKey = PartitionKey, RowKey = RowKey });
            }
        }
        private static async Task TestTableBoundToCollectorCanCallAsync(Type programType)
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            // Act
            await CallAsync(account, programType, "Call").ConfigureAwait(false);
            // Assert
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
        }
        [Fact]
        public async Task Table_IfBoundToCollectorAndETagDoesNotMatch_Throws()
        {
            await TestBindToConcurrentlyUpdatedTableEntity(typeof(BindTableToCollectorFoo), "collector").ConfigureAwait(false);
        }
        private class BindTableToCollectorFoo
        {
            public static void Call([Table(TableName)] ICollector<ITableEntity> collector,
                [Table(TableName)] CloudTable table)
            {
                SdkTableEntity entity = table.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
                Assert.NotNull(entity);
                Assert.Equal("Foo", entity.Value);
                // Update the entity to invalidate the version read by this method.
                table.Replace(new SdkTableEntity
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    ETag = "*",
                    Value = "FooBackground"
                });
                // The attempted update by this method should now fail.
                collector.Add(new DynamicTableEntity(PartitionKey, RowKey, entity.ETag,
                    new Dictionary<string, EntityProperty> { { "Value", new EntityProperty("Bar") } }));
            }
        }
        [Fact]
        [Trait("SecretsRequired", "true")]
        public async Task TableEntity_IfBoundToJArray_CanCall()
        {
            StorageAccount account = GetRealStorage(); // Fake storage doesn't implement table filters
            var client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false); // $$$ Should clear existing values.
            table.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "1", "Value", "x1", "*"));
            table.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "2", "Value", "x2", "*"));
            table.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "3", "Value", "x3", "*"));
            table.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "4", "Value", "x4", "*"));
            var instance = new BindTableEntityToJArrayProgram();
            var jobActivator = new FakeActivator();
            jobActivator.Add(instance);
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<BindTableEntityToJArrayProgram>(b =>
                {
                    b.AddAzureStorage();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IJobActivator>(jobActivator);
                    services.AddSingleton<StorageAccountProvider>(new FakeStorageAccountProvider(account));
                })
                .Build();
            // Act
            Type type = typeof(BindTableEntityToJArrayProgram);
            await host.GetJobHost().CallAsync(type.GetMethod(nameof(BindTableEntityToJArrayProgram.CallTakeFilter)));
            Assert.Equal("x1;x3;", instance._result);
            await host.GetJobHost().CallAsync(type.GetMethod(nameof(BindTableEntityToJArrayProgram.CallFilter)));
            Assert.Equal("x1;x3;x4;", instance._result);
            await host.GetJobHost().CallAsync(type.GetMethod(nameof(BindTableEntityToJArrayProgram.CallTake)));
            Assert.Equal("x1;x2;x3;", instance._result);
            await host.GetJobHost().CallAsync(type.GetMethod(nameof(BindTableEntityToJArrayProgram.Call)));
            Assert.Equal("x1;x2;x3;x4;", instance._result);
        }
        private class BindTableEntityToJArrayProgram
        {
            public string _result;
            // Helper to flatten a Jarray for quick testing.
            private static string Flatten(JArray array)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < array.Count; i++)
                {
                    sb.Append(array[i]["Value"]);
                    sb.Append(';');
                }
                return sb.ToString();
            }
            public void CallTakeFilter([Table(TableName, PartitionKey, Take = 2, Filter = "Value ne 'x2'")] JArray array)
            {
                this._result = Flatten(array);
            }
            public void CallFilter([Table(TableName, PartitionKey, Filter = "Value ne 'x2'")] JArray array)
            {
                this._result = Flatten(array);
            }
            public void CallTake([Table(TableName, PartitionKey, Take = 3)] JArray array)
            {
                this._result = Flatten(array);
            }
            // No take or filters
            public void Call([Table(TableName, PartitionKey)] JArray array)
            {
                this._result = Flatten(array);
            }
        }
        [Fact]
        public async Task TableEntity_IfBoundToJObject_CanCall()
        {
            // Arrange
            var account = CreateFakeStorageAccount();
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference(TableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            table.Insert(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));
            // Act
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<BindTableEntityToJObjectProgram>(b =>
                {
                    b.AddAzureStorage();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<StorageAccountProvider>(new FakeStorageAccountProvider(account));
                })
                .Build();
            var prog = host.GetJobHost<BindTableEntityToJObjectProgram>();
            await prog.CallAsync("Call", new
            {
                table = TableName, // Test resolution
                pk1 = PartitionKey,
                rk1 = RowKey
            });
            // Assert
            SdkTableEntity entity = table.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
        }
        private class BindTableEntityToJObjectProgram
        {
            public static void Call([Table("{table}", "{pk1}", "{rk1}")] JObject entity)
            {
                Assert.NotNull(entity);
                Assert.Equal("Foo", entity["Value"].ToString());
            }
        }
        [Fact]
        public async Task TableEntity_IfBoundToSdkTableEntity_CanCall()
        {
            // Arrange
            var account = CreateFakeStorageAccount();
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference(TableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            table.Insert(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));
            // Act
            await CallAsync(account, typeof(BindTableEntityToSdkTableEntityProgram), "Call").ConfigureAwait(false);
            // Assert
            SdkTableEntity entity = table.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.Equal("Bar", entity.Value);
        }
        private class BindTableEntityToSdkTableEntityProgram
        {
            public static void Call([Table(TableName, PartitionKey, RowKey)] SdkTableEntity entity)
            {
                Assert.NotNull(entity);
                Assert.Equal("Foo", entity.Value);
                entity.Value = "Bar";
            }
        }
        [Fact]
        public async Task TableEntity_IfBoundToPocoTableEntity_CanCall()
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference(TableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            table.Insert(new DynamicTableEntity(PartitionKey, RowKey, null, new Dictionary<string, EntityProperty>
            {
                { "Fruit", new EntityProperty("Banana") },
                { "Duration", new EntityProperty("\"00:00:01\"") },
                { "Value", new EntityProperty("Foo") }
            }));
            // Act
            await CallAsync(account, typeof(BindTableEntityToPocoTableEntityProgram), "Call").ConfigureAwait(false);
            // Assert
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.Equal(PartitionKey, entity.PartitionKey); // Guard
            Assert.Equal(RowKey, entity.RowKey); // Guard
            IDictionary<string, EntityProperty> properties = entity.Properties;
            Assert.Equal(3, properties.Count);
            Assert.True(properties.ContainsKey("Value"));
            EntityProperty fruitProperty = properties["Fruit"];
            Assert.Equal(EdmType.String, fruitProperty.PropertyType);
            Assert.Equal("Pear", fruitProperty.StringValue);
            EntityProperty durationProperty = properties["Duration"];
            Assert.Equal(EdmType.String, durationProperty.PropertyType);
            Assert.Equal("\"00:02:00\"", durationProperty.StringValue);
            EntityProperty valueProperty = properties["Value"];
            Assert.Equal(EdmType.String, valueProperty.PropertyType);
            Assert.Equal("Bar", valueProperty.StringValue);
        }
        private class BindTableEntityToPocoTableEntityProgram
        {
            public static void Call([Table(TableName, PartitionKey, RowKey)] PocoTableEntityWithEnum entity)
            {
                Assert.NotNull(entity);
                Assert.Equal(Fruit.Banana, entity.Fruit);
                Assert.Equal(TimeSpan.FromSeconds(1), entity.Duration);
                Assert.Equal("Foo", entity.Value);
                entity.Fruit = Fruit.Pear;
                entity.Duration = TimeSpan.FromMinutes(2);
                entity.Value = "Bar";
            }
        }
        private class PocoTableEntityWithEnum
        {
            public Fruit Fruit { get; set; }
            public TimeSpan Duration { get; set; }
            public string Value { get; set; }
        }
        private enum Fruit
        {
            Apple,
            Banana,
            Pear
        }
        [Fact]
        public async Task TableEntity_IfBoundToSdkTableEntityAndUpdatedConcurrently_Throws()
        {
            await TestBindTableEntityToConcurrentlyUpdatedValue(typeof(BindTableEntityToConcurrentlyUpdatedSdkTableEntity)).ConfigureAwait(false);
        }
        private class BindTableEntityToConcurrentlyUpdatedSdkTableEntity
        {
            public static void Call([Table(TableName, PartitionKey, RowKey)] SdkTableEntity entity,
                [Table(TableName)] CloudTable table)
            {
                Assert.NotNull(entity);
                Assert.Equal("Foo", entity.Value);
                // Update the entity to invalidate the version read by this method.
                table.Replace(new SdkTableEntity
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    ETag = "*",
                    Value = "FooBackground"
                });
                // The attempted update by this method should now fail.
                entity.Value = "Bar";
            }
        }
        [Fact]
        public async Task TableEntity_IfBoundToPocoTableEntityAndUpdatedConcurrently_Throws()
        {
            await TestBindTableEntityToConcurrentlyUpdatedValue(typeof(BindTableEntityToConcurrentlyUpdatedPocoTableEntity)).ConfigureAwait(false);
        }
        private class BindTableEntityToConcurrentlyUpdatedPocoTableEntity
        {
            public static void Call([Table(TableName, PartitionKey, RowKey)] PocoTableEntity entity,
                [Table(TableName)] CloudTable table)
            {
                Assert.NotNull(entity);
                Assert.Equal("Foo", entity.Value);
                // Update the entity to invalidate the version read by this method.
                table.Replace(new SdkTableEntity
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    ETag = "*",
                    Value = "FooBackground"
                });
                // The attempted update by this method should now fail.
                entity.Value = "Bar";
            }
        }
        private static async Task TestBindTableEntityToConcurrentlyUpdatedValue(Type programType)
        {
            await TestBindToConcurrentlyUpdatedTableEntity(programType, "entity").ConfigureAwait(false);
        }
        private static async Task TestBindToConcurrentlyUpdatedTableEntity(Type programType, string parameterName)
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            var client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            await table.CreateIfNotExistsAsync().ConfigureAwait(false);
            table.Insert(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));
            // Act & Assert
            Exception exception = await CallFailureAsync(account, programType, "Call").ConfigureAwait(false);
            AssertInvocationETagFailure(parameterName, exception);
            SdkTableEntity entity = table.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.Equal("FooBackground", entity.Value);
        }
        private static async Task CallAsync(StorageAccount account, Type programType, string methodName, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(account, programType, programType.GetMethod(methodName), null, customExtensions);
        }
        private static async Task CallAsync(StorageAccount account, Type programType, string methodName,
            IDictionary<string, object> arguments, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(account, programType, programType.GetMethod(methodName), arguments, customExtensions);
        }
        private static async Task<TResult> CallAsync<TResult>(StorageAccount account, Type programType, string methodName,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            IDictionary<string, object> arguments = null;
            return await FunctionalTest.CallAsync<TResult>(account, programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }
        private static async Task<TResult> CallAsync<TResult>(StorageAccount account, Type programType, string methodName,
            IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.CallAsync<TResult>(account, programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }
        private static async Task<Exception> CallFailureAsync(StorageAccount account, Type programType, string methodName)
        {
            return await FunctionalTest.CallFailureAsync(account, programType, programType.GetMethod(methodName), null);
        }
        private static StorageAccount GetRealStorage()
        {
            // Arrange
            var acs = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var account = StorageAccount.NewFromConnectionString(acs);
            return account;
        }
        private static StorageAccount CreateFakeStorageAccount()
        {
            return new FakeStorageAccount();
        }
        private static ITableEntity CreateTableEntity(string partitionKey, string rowKey, string propertyName,
    string propertyValue, string eTag = null)
        {
            return new DynamicTableEntity(partitionKey, rowKey, eTag, new Dictionary<string, EntityProperty>
            {
                { propertyName, new EntityProperty(propertyValue) }
            });
        }
        private static void AssertInvocationETagFailure(string expectedParameterName, Exception exception)
        {
            Assert.IsType<FunctionInvocationException>(exception);
            Assert.IsType<InvalidOperationException>(exception.InnerException);
            string expectedMessage = String.Format(CultureInfo.InvariantCulture,
                "Error while handling parameter {0} after function returned:", expectedParameterName);
            Assert.Equal(expectedMessage, exception.InnerException.Message);
            Exception innerException = exception.InnerException.InnerException;
            Assert.IsType<InvalidOperationException>(innerException);
            // This exception is an implementation detail of the fake storage account. A real one would use a
            // StorageException (this assert may need to change if the fake is updated to be more realistic).
            InvalidOperationException invalidOperationException = (InvalidOperationException)innerException;
            Assert.NotNull(invalidOperationException.Message);
            Assert.StartsWith("Entity PK='PK',RK='RK' does not match eTag", invalidOperationException.Message);
        }
        private class MissingTableProgram
        {
            public static void FuncWithICollector([Table(TableName)] ICollector<SdkTableEntity> entities)
            {
                Assert.NotNull(entities);
            }
            public static void FuncWithITableEntity([Table(TableName, "PK", "RK")] SdkTableEntity entity)
            {
                Assert.Null(entity);
            }
            public static void FuncWithPocoObjectEntity([Table(TableName, "PK", "RK")] PocoTableEntity entity)
            {
                Assert.Null(entity);
            }
            public static void FuncWithPocoValueEntity([Table(TableName, "PK", "RK")] StructTableEntity entity)
            {
                Assert.Null(entity.Value);
            }
        }
        private class SdkTableEntity : TableEntity
        {
            public string Value { get; set; }
        }
        private class PocoTableEntity
        {
            public string Value { get; set; }
        }
        private struct StructTableEntity
        {
            public string Value { get; set; }
        }
    }
}