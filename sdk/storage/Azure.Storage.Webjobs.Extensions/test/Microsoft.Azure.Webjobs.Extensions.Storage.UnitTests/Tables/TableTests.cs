// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;


namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class TableTests
    {
        private const string TriggerQueueName = "input";
        private const string TableName = "Table";
        private const string PartitionKey = "PK";
        private const string RowKey = "RK";
        private const string PropertyName = "Property";

        [Fact]
        public void Table_IndexingFails()
        {
            void AssertIndexingError<TProgram>(string methodName, string expectedErrorMessage)
            {

                IHost host = new HostBuilder()
                    .ConfigureDefaultTestHost<TProgram>(builder =>
                    {
                        builder.UseFakeStorage();
                    })
                    .Build();

                host.GetJobHost<TProgram>().AssertIndexingError(methodName, expectedErrorMessage).GetAwaiter().GetResult();
            }

            // Verify we catch various indexing failures.             
            AssertIndexingError<BadProgramTableName>(nameof(BadProgramTableName.Run), "Validation failed for property 'TableName', value '$$'");

            // Pocos must have a default ctor. 
            AssertIndexingError<BadProgram4>(nameof(BadProgram4.Run), "Table entity types must provide a default constructor.");

            // When binding to Pocos, they must be structurally compatible with ITableEntity.
            AssertIndexingError<BadProgram1>(nameof(BadProgram1.Run), "Table entity types must implement the property RowKey.");
            AssertIndexingError<BadProgram2>(nameof(BadProgram2.Run), "Table entity types must implement the property RowKey.");
            AssertIndexingError<BadProgram3>(nameof(BadProgram3.Run), "Table entity types must implement the property PartitionKey.");
        }

        class BindToSingleOutProgram
        {
            public static void Run([Table(TableName)] out Poco x)
            {
                x = new Poco { PartitionKey = PartitionKey, RowKey = RowKey, Property = "1234" };
            }
        }

        [Fact]
        public async Task Table_SingleOut_Supported()
        {
            IHost host = new HostBuilder()
             .ConfigureDefaultTestHost<BindToSingleOutProgram>(builder =>
             {
                 builder.AddAzureStorage()
                     .UseFakeStorage();
             })
             .Build();

            await host.GetJobHost<BindToSingleOutProgram>().CallAsync(nameof(BindToSingleOutProgram.Run));

            var account = host.GetStorageAccount();
            await AssertStringPropertyAsync(account, "Property", "1234");
        }

        // Helper to demonstrate that TableName property can include { } pairs. 
        private class BindToICollectorITableEntityResolvedTableProgram
        {
            public static void Run(
                [Table("Ta{t1}")] ICollector<Poco> table1,
                [Table("{t1}x{t1}")] ICollector<Poco> table2)
            {
                table1.Add(new Poco { PartitionKey = PartitionKey, RowKey = RowKey, Property = "123" });
                table2.Add(new Poco { PartitionKey = PartitionKey, RowKey = RowKey, Property = "456" });
            }
        }

        // TableName can have {  } pairs.
        [Fact]
        public async Task Table_ResolvedName()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToICollectorITableEntityResolvedTableProgram>(builder =>
                {
                    builder.AddAzureStorage()
                        .UseFakeStorage();
                })
                .Build();

            await host.GetJobHost<BindToICollectorITableEntityResolvedTableProgram>().CallAsync("Run", new { t1 = "ZZ" });

            var account = host.GetStorageAccount();
            await AssertStringPropertyAsync(account, "Property", "123", "TaZZ");
            await AssertStringPropertyAsync(account, "Property", "456", "ZZxZZ");
        }

        private class CustomTableBindingConverter<T>
            : IConverter<CloudTable, CustomTableBinding<T>>
        {
            public CustomTableBinding<T> Convert(CloudTable input)
            {
                return new CustomTableBinding<T>(input);
            }
        }

        [Fact]
        public async Task Table_IfBoundToCustomTableBindingExtension_BindsCorrectly()
        {
            // Arrange
            var ext = new TableConverterExtensionConfigProvider();

            var host = new HostBuilder()
                .ConfigureDefaultTestHost<CustomTableBindingExtensionProgram>(builder =>
                {
                    builder.UseFakeStorage()
                    .AddExtension(ext);
                })
            .Build();

            await host.GetJobHost<CustomTableBindingExtensionProgram>().CallAsync("Run"); // Act

            // Assert
            Assert.Equal(TableName, CustomTableBinding<Poco>.Table.Name);
            Assert.True(CustomTableBinding<Poco>.AddInvoked);
            Assert.True(CustomTableBinding<Poco>.DeleteInvoked);
        }

        // Add a rule for binding CloudTable --> CustomTableBinding<TEntity>
        internal class TableConverterExtensionConfigProvider : IExtensionConfigProvider
        {
            public void Initialize(ExtensionConfigContext context)
            {
                context.AddBindingRule<TableAttribute>().
                    AddOpenConverter<CloudTable, CustomTableBinding<OpenType>>(
               typeof(CustomTableBindingConverter<>));
            }
        }

        [Fact]
        public async Task Table_IfBoundToCloudTable_BindsAndCreatesTable()
        {
            // Arrange
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage("ignore"));

            // Act
            CloudTable result = await RunTriggerAsync<CloudTable>(account, typeof(BindToCloudTableProgram),
                (s) => BindToCloudTableProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TableName, result.Name);
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            Assert.True(await table.ExistsAsync());
        }

        [Fact]
        public async Task Table_IfBoundToICollectorJObject_AddInsertsEntity()
        {
            // Arrange
            const string expectedValue = "abc";
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(expectedValue));

            // Act
            await RunTriggerAsync(account, typeof(BindToICollectorJObjectProgram));

            // Assert
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            Assert.True(await table.ExistsAsync());
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Properties);

            AssertPropertyValue(entity, "ValueStr", "abcdef");
            AssertPropertyValue(entity, "ValueNum", 123);
        }

        // Partition and RowKey values are in the attribute
        [Fact]
        public async Task Table_IfBoundToICollectorJObject__WithAttrKeys_AddInsertsEntity()
        {
            // Arrange
            const string expectedValue = "abcdef";

            // Act
            var host = new HostBuilder()
                .ConfigureDefaultTestHost<BindToICollectorJObjectProgramKeysInAttr>(builder =>
                {
                    builder.UseFakeStorage();
                })
                .Build();

            await host.GetJobHost<BindToICollectorJObjectProgramKeysInAttr>().CallAsync("Run");

            // Assert
            var account = host.GetStorageAccount();
            await AssertStringPropertyAsync(account, "ValueStr", expectedValue);
        }

        [Fact]
        public async Task Table_IfBoundToICollectorITableEntity_AddInsertsEntity()
        {
            // Arrange
            const string expectedValue = "abc";
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(expectedValue));

            // Act
            await RunTriggerAsync(account, typeof(BindToICollectorITableEntityProgram));

            // Assert
            await AssertStringPropertyAsync(account, PropertyName, expectedValue);
        }

        [Fact]
        public async Task Table_IfBoundToICollectorPoco_AddInsertsEntity()
        {
            // Arrange
            const string expectedValue = "abc";
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(expectedValue));

            // Act
            await RunTriggerAsync(account, typeof(BindToICollectorPocoProgram));

            // Assert
            await AssertStringPropertyAsync(account, PropertyName, expectedValue);
        }

        [Fact]
        public async Task Table_IfBoundToICollectorPoco_AddInsertsUsingNativeTableTypes()
        {
            // Arrange
            PocoWithAllTypes expected = new PocoWithAllTypes
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                BooleanProperty = true,
                NullableBooleanProperty = null,
                ByteArrayProperty = new byte[] { 0x12, 0x34 },
                DateTimeProperty = DateTime.Now,
                NullableDateTimeProperty = null,
                DateTimeOffsetProperty = DateTimeOffset.MaxValue,
                NullableDateTimeOffsetProperty = null,
                DoubleProperty = 3.14,
                NullableDoubleProperty = null,
                GuidProperty = Guid.NewGuid(),
                NullableGuidProperty = null,
                Int32Property = 123,
                NullableInt32Property = null,
                Int64Property = 456,
                NullableInt64Property = null,
                StringProperty = "abc",
                PocoProperty = new Poco
                {
                    PartitionKey = "def",
                    RowKey = "ghi",
                    Property = "jkl"
                }
            };
            StorageAccount account = CreateFakeStorageAccount();
            CloudQueue triggerQueue = await account.CreateQueueAsync(TriggerQueueName);
            await triggerQueue.AddMessageAsync(new CloudQueueMessage(JsonConvert.SerializeObject(expected)));

            // Act
            await RunTriggerAsync(account, typeof(BindToICollectorPocoWithAllTypesProgram));

            // Assert
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            Assert.True(await table.ExistsAsync());
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.Equal(expected.PartitionKey, entity.PartitionKey);
            Assert.Equal(expected.RowKey, entity.RowKey);
            IDictionary<string, EntityProperty> properties = entity.Properties;
            AssertNullablePropertyEqual(expected.BooleanProperty, EdmType.Boolean, properties, "BooleanProperty",
                (p) => p.BooleanValue);
            AssertPropertyNull(EdmType.Boolean, properties, "NullableBooleanProperty", (p) => p.BooleanValue);
            AssertPropertyEqual(expected.ByteArrayProperty, EdmType.Binary, properties, "ByteArrayProperty",
                (p) => p.BinaryValue);
            AssertNullablePropertyEqual(expected.DateTimeProperty, EdmType.DateTime, properties, "DateTimeProperty",
                (p) => p.DateTime);
            AssertPropertyNull(EdmType.DateTime, properties, "NullableDateTimeProperty", (p) => p.DateTime);
            AssertNullablePropertyEqual(expected.DateTimeOffsetProperty, EdmType.DateTime, properties,
                "DateTimeOffsetProperty", (p) => p.DateTime);
            AssertPropertyNull(EdmType.DateTime, properties, "NullableDateTimeOffsetProperty",
                (p) => p.DateTimeOffsetValue);
            AssertNullablePropertyEqual(expected.DoubleProperty, EdmType.Double, properties, "DoubleProperty",
                (p) => p.DoubleValue);
            AssertPropertyNull(EdmType.Double, properties, "NullableDoubleProperty", (p) => p.DoubleValue);
            AssertNullablePropertyEqual(expected.GuidProperty, EdmType.Guid, properties, "GuidProperty",
                (p) => p.GuidValue);
            AssertPropertyNull(EdmType.Guid, properties, "NullableGuidProperty", (p) => p.GuidValue);
            AssertNullablePropertyEqual(expected.Int32Property, EdmType.Int32, properties, "Int32Property",
                (p) => p.Int32Value);
            AssertPropertyNull(EdmType.Int32, properties, "NullableInt32Property", (p) => p.Int32Value);
            AssertNullablePropertyEqual(expected.Int64Property, EdmType.Int64, properties, "Int64Property",
                (p) => p.Int64Value);
            AssertPropertyNull(EdmType.Int64, properties, "NullableInt64Property", (p) => p.Int64Value);
            AssertPropertyEqual(expected.StringProperty, EdmType.String, properties, "StringProperty",
                (p) => p.StringValue);
            AssertPropertyEqual(JsonConvert.SerializeObject(expected.PocoProperty, Formatting.Indented), EdmType.String,
                properties, "PocoProperty", (p) => p.StringValue);
        }

        private static void AssertNullablePropertyEqual<T>(T expected,
            EdmType expectedType,
            IDictionary<string, EntityProperty> properties,
            string propertyName,
            Func<EntityProperty, Nullable<T>> actualAccessor)
            where T : struct
        {
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey(propertyName));
            EntityProperty property = properties[propertyName];
            Assert.Equal(expectedType, property.PropertyType);
            Nullable<T> actualValue = actualAccessor.Invoke(property);
            Assert.True(actualValue.HasValue);
            Assert.Equal(expected, actualValue.Value);
        }

        private static void AssertPropertyValue(DynamicTableEntity entity, string propertyName, object expectedValue)
        {
            Assert.True(entity.Properties.ContainsKey(propertyName));
            EntityProperty property = entity.Properties[propertyName];
            Assert.NotNull(property);

            if (expectedValue is string)
            {
                Assert.Equal(EdmType.String, property.PropertyType);
                Assert.Equal(expectedValue, property.StringValue);
            }
            else if (expectedValue is int)
            {
                Assert.Equal(EdmType.Int32, property.PropertyType);
                Assert.Equal(expectedValue, property.Int32Value);
            }
            else
            {
                Assert.False(true, "test bug: unsupported property type: " + expectedValue.GetType().FullName);
            }
        }

        private static void AssertPropertyEqual<T>(T expected,
            EdmType expectedType,
            IDictionary<string, EntityProperty> properties,
            string propertyName,
            Func<EntityProperty, T> actualAccessor)
            where T : class
        {
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey(propertyName));
            EntityProperty property = properties[propertyName];
            Assert.Equal(expectedType, property.PropertyType);
            T actualValue = actualAccessor.Invoke(property);
            Assert.Equal(expected, actualValue);
        }

        private static void AssertPropertyNull<T>(EdmType expectedType,
            IDictionary<string, EntityProperty> properties,
            string propertyName,
            Func<EntityProperty, Nullable<T>> actualAccessor)
            where T : struct
        {
            Assert.NotNull(properties);
            Assert.True(properties.ContainsKey(propertyName));
            EntityProperty property = properties[propertyName];
            Assert.Equal(expectedType, property.PropertyType);
            Nullable<T> actualValue = actualAccessor.Invoke(property);
            Assert.False(actualValue.HasValue);
        }

        // Assert the given table has the given entity with PropertyName=ExpectedValue
        private async Task AssertStringPropertyAsync(
            StorageAccount account,
            string propertyName,
            string expectedValue,
            string tableName = TableName,
            string partitionKey = PartitionKey,
            string rowKey = RowKey)
        {
            // Assert
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(tableName);
            Assert.True(await table.ExistsAsync());
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(partitionKey, rowKey);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Properties);
            Assert.True(entity.Properties.ContainsKey(propertyName));
            EntityProperty property = entity.Properties[propertyName];
            Assert.NotNull(property);
            Assert.Equal(EdmType.String, property.PropertyType);
            Assert.Equal(expectedValue, property.StringValue);
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

        private class BindToCloudTableProgram
        {
            public static TaskCompletionSource<CloudTable> TaskSource { get; set; }

            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage ignore,
                [Table(TableName)] CloudTable table)
            {
                TaskSource.TrySetResult(table);
            }
        }

        private class BindToICollectorJObjectProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage message,
                [Table(TableName)] ICollector<JObject> table)
            {
                table.Add(JObject.FromObject(new
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    ValueStr = "abcdef",
                    ValueNum = 123
                }));
            }
        }

        // Partition and RowKey are missing from JObject, get them from the attribute. 
        private class BindToICollectorJObjectProgramKeysInAttr
        {
            [NoAutomaticTrigger]
            public static void Run(
                [Table(TableName, PartitionKey, RowKey)] ICollector<JObject> table)
            {
                table.Add(JObject.FromObject(new
                {
                    // no partition and row key! USe from attribute instead. 
                    ValueStr = "abcdef",
                    ValueNum = 123
                }));
            }
        }

        private class BindToICollectorITableEntityProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage message,
                [Table(TableName)] ICollector<ITableEntity> table)
            {
                Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>
                {
                    { PropertyName, new EntityProperty(message.AsString) }
                };
                table.Add(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: properties));
            }
        }

        private class BindToICollectorPocoProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage message,
                [Table(TableName)] ICollector<Poco> table)
            {
                table.Add(new Poco { PartitionKey = PartitionKey, RowKey = RowKey, Property = message.AsString });
            }
        }

        private class BindToICollectorPocoWithAllTypesProgram
        {
            public static void Run([QueueTrigger(TriggerQueueName)] CloudQueueMessage message,
                [Table(TableName)] ICollector<PocoWithAllTypes> table)
            {
                PocoWithAllTypes entity = JsonConvert.DeserializeObject<PocoWithAllTypes>(message.AsString);
                table.Add(entity);
            }
        }

        private class CustomTableBindingExtensionProgram
        {
            public static void Run([Table(TableName)] CustomTableBinding<Poco> table)
            {
                Poco entity = new Poco();
                table.Add(entity);
                table.Delete(entity);
            }
        }

        private class BadProgramTableName
        {
            public static void Run([Table("$$")] ICollector<Poco> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram1
        {
            public static void Run([Table(TableName)] ICollector<BadPoco> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram2
        {
            public static void Run([Table(TableName)] ICollector<BadPocoMissingRowKey> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram3
        {
            public static void Run([Table(TableName)] ICollector<BadPocoMissingPartitionKey> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram4
        {
            public static void Run([Table(TableName, PartitionKey, RowKey)] BadPocoMissingDefaultCtor input)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        // Poco that should fail at binding time:
        // 1. Does not derive from ITableEntity, and 
        // 2. Missing PartitionKey and RowKey values, so not structurally  compatible with ITableEntity 
        private class BadPoco
        {
            public string Value { get; set; }
        }

        private class BadPocoMissingRowKey
        {
            public string PartitionKey { get; set; }
            public string Value { get; set; }
        }

        private class BadPocoMissingPartitionKey
        {
            public string RowKey { get; set; }
            public string Value { get; set; }
        }

        private class BadPocoMissingDefaultCtor
        {
            public BadPocoMissingDefaultCtor(string value)
            {
                this.Value = value;
            }
            public string Value { get; set; }
        }

        private class TableOutProgram
        {
            public static void Run([Table(TableName, PartitionKey, RowKey)] out Poco value)
            {
                value = null;
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class TableOutArrayProgram
        {
            public static void Run([Table(TableName, PartitionKey, RowKey)] out Poco[] value)
            {
                value = null;
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }


        private class Poco
        {
            public string PartitionKey { get; set; }

            public string RowKey { get; set; }

            public string Property { get; set; }
        }

        private class PocoWithAllTypes
        {
            public string PartitionKey { get; set; }

            public string RowKey { get; set; }

            public bool BooleanProperty { get; set; }

            public bool? NullableBooleanProperty { get; set; }

            public byte[] ByteArrayProperty { get; set; }

            public DateTime DateTimeProperty { get; set; }

            public DateTime? NullableDateTimeProperty { get; set; }

            public DateTimeOffset DateTimeOffsetProperty { get; set; }

            public DateTimeOffset? NullableDateTimeOffsetProperty { get; set; }

            public double DoubleProperty { get; set; }

            public double? NullableDoubleProperty { get; set; }

            public Guid GuidProperty { get; set; }

            public Guid? NullableGuidProperty { get; set; }

            public int Int32Property { get; set; }

            public int? NullableInt32Property { get; set; }

            public long Int64Property { get; set; }

            public long? NullableInt64Property { get; set; }

            public string StringProperty { get; set; }

            public Poco PocoProperty { get; set; }
        }

        /// <summary>
        /// Binding type demonstrating how custom binding extensions can be used to bind to
        /// arbitrary types
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public class CustomTableBinding<TEntity>
        {
            public static bool AddInvoked;
            public static bool DeleteInvoked;
            public static CloudTable Table;

            public CustomTableBinding(CloudTable table)
            {
                // this custom binding has the table, so can perform whatever storage
                // operations it needs to
                Table = table;
            }

            public void Add(TEntity entity)
            {
                // storage operations here
                AddInvoked = true;
            }

            public void Delete(TEntity entity)
            {
                // storage operations here
                DeleteInvoked = true;
            }

            internal Task FlushAsync(CancellationToken cancellationToken)
            {
                // complete and flush all storage operations
                return Task.FromResult(true);
            }
        }
    }
}