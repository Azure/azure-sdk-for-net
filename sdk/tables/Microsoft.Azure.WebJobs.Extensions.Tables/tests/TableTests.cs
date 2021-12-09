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
using Microsoft.Azure.WebJobs.Host.Indexers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableTests: TablesLiveTestBase
    {
        private const string PropertyName = "Property";

        [Test]
        public async Task Table_IndexingFails()
        {
            async Task AssertIndexingError<TProgram>(string methodName, string expectedErrorMessage)
            {
                try
                {
                    // Indexing is lazy, so must actually try a call first.
                    await CallAsync<TProgram>(methodName);
                }
                catch (FunctionIndexingException e)
                {
                    string functionName = typeof(TProgram).Name + "." + methodName;
                    Assert.AreEqual("Error indexing method '" + functionName + "'", e.Message);
                    StringAssert.Contains(expectedErrorMessage, e.InnerException.Message);
                    return;
                }
                Assert.True(false, "Invoker should have failed");
            }

            // Verify we catch various indexing failures.
            await AssertIndexingError<BadProgramTableName>(nameof(BadProgramTableName.Run), "Validation failed for property 'TableName', value '$$'");
            // Pocos must have a default ctor.
            await AssertIndexingError<BadProgram4>(nameof(BadProgram4.Run), "Table entity types must provide a default constructor.");
            // When binding to Pocos, they must be structurally compatible with ITableEntity.
            await AssertIndexingError<BadProgram1>(nameof(BadProgram1.Run), "Table entity types must implement the property RowKey.");
            await AssertIndexingError<BadProgram2>(nameof(BadProgram2.Run), "Table entity types must implement the property RowKey.");
            await AssertIndexingError<BadProgram3>(nameof(BadProgram3.Run), "Table entity types must implement the property PartitionKey.");
        }

        private class BindToSingleOutProgram
        {
            public static void Run([Table(TableNameExpression)] out Poco x)
            {
                x = new Poco { PartitionKey = PartitionKey, RowKey = RowKey, Property = "1234" };
            }
        }

        [Test]
        public async Task Table_SingleOut_Supported()
        {
            await CallAsync<BindToSingleOutProgram>();

            await AssertStringPropertyAsync("Property", "1234").ConfigureAwait(false);
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
        [Test]
        public async Task Table_ResolvedName()
        {
            await CallAsync<BindToICollectorITableEntityResolvedTableProgram>(arguments: new { t1 = TableName });

            await AssertStringPropertyAsync("Property", "123", "Ta" + TableName).ConfigureAwait(false);
            await AssertStringPropertyAsync("Property", "456", TableName+ "x" + TableName).ConfigureAwait(false);
        }

        private class CustomTableBindingConverter<T>
            : IConverter<CloudTable, CustomTableBinding<T>>
        {
            public CustomTableBinding<T> Convert(CloudTable input)
            {
                return new CustomTableBinding<T>(input);
            }
        }

        [Test]
        public async Task Table_IfBoundToCustomTableBindingExtension_BindsCorrectly()
        {
            // Arrange
            var ext = new TableConverterExtensionConfigProvider();
            await CallAsync<CustomTableBindingExtensionProgram>(configure: builder => builder.ConfigureWebJobs(builder =>
            {
                builder.AddExtension(ext);
            }));

            // Assert
            Assert.AreEqual(TableName, CustomTableBinding<Poco>.Table.Name);
            Assert.True(CustomTableBinding<Poco>.AddInvoked);
            Assert.True(CustomTableBinding<Poco>.DeleteInvoked);
        }

        // Add a rule for binding CloudTable --> CustomTableBinding<TEntity>
        internal class TableConverterExtensionConfigProvider : IExtensionConfigProvider
        {
            public void Initialize(ExtensionConfigContext context)
            {
                context.AddBindingRule<TableAttribute>().AddOpenConverter<CloudTable, CustomTableBinding<OpenType>>(
                    typeof(CustomTableBindingConverter<>));
            }
        }

        [Test]
        public async Task Table_IfBoundToCloudTable_BindsAndCreatesTable()
        {
            // Act
            CloudTable result = (await CallAsync<BindToCloudTableProgram>()).Table;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(TableName, result.Name);

            CloudTableClient client = Account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(TableName);
            Assert.True(await table.ExistsAsync().ConfigureAwait(false));
        }

        [Test]
        public async Task Table_IfBoundToICollectorJObject_AddInsertsEntity()
        {
            // Act
            await CallAsync<BindToICollectorJObjectProgram>();

            // Assert
            DynamicTableEntity entity = CloudTable.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Properties);
            AssertPropertyValue(entity, "ValueStr", "abcdef");
            AssertPropertyValue(entity, "ValueNum", 123);
        }

        // Partition and RowKey values are in the attribute
        [Test]
        public async Task Table_IfBoundToICollectorJObject__WithAttrKeys_AddInsertsEntity()
        {
            // Act
            await CallAsync<BindToICollectorJObjectProgramKeysInAttr>();

            // Assert
            await AssertStringPropertyAsync("ValueStr", "abcdef").ConfigureAwait(false);
        }

        [Test]
        public async Task Table_IfBoundToICollectorITableEntity_AddInsertsEntity()
        {
            // Act
            await CallAsync<BindToICollectorITableEntityProgram>(arguments: new
            {
                newValue = "abc"
            });

            // Assert
            await AssertStringPropertyAsync(PropertyName, "abc").ConfigureAwait(false);
        }

        [Test]
        public async Task Table_IfBoundToICollectorPoco_AddInsertsEntity()
        {
            // Act
            await CallAsync<BindToICollectorPocoProgram>(arguments: new
            {
                newValue = "abc"
            });
            // Assert
            await AssertStringPropertyAsync(PropertyName, "abc").ConfigureAwait(false);
        }

        [Test]
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
                DateTimeProperty = DateTime.UtcNow,
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

            // Act
            await CallAsync<BindToICollectorPocoWithAllTypesProgram>(arguments: new
            {
                entity = expected
            });

            // Assert
            DynamicTableEntity entity = CloudTable.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.AreEqual(expected.PartitionKey, entity.PartitionKey);
            Assert.AreEqual(expected.RowKey, entity.RowKey);
            IDictionary<string, EntityProperty> properties = entity.Properties;
            AssertNullablePropertyEqual(expected.BooleanProperty, EdmType.Boolean, properties, "BooleanProperty",
                (p) => p.BooleanValue);
            AssertPropertyNull(properties, "NullableBooleanProperty");
            AssertPropertyEqual(expected.ByteArrayProperty, EdmType.Binary, properties, "ByteArrayProperty",
                (p) => p.BinaryValue);
            AssertNullablePropertyEqual(expected.DateTimeProperty, EdmType.DateTime, properties, "DateTimeProperty",
                (p) => p.DateTime);
            AssertPropertyNull(properties, "NullableDateTimeProperty");
            AssertNullablePropertyEqual(expected.DateTimeOffsetProperty, EdmType.DateTime, properties,
                "DateTimeOffsetProperty", (p) => p.DateTime);
            AssertPropertyNull(properties, "NullableDateTimeOffsetProperty");
            AssertNullablePropertyEqual(expected.DoubleProperty, EdmType.Double, properties, "DoubleProperty",
                (p) => p.DoubleValue);
            AssertPropertyNull(properties, "NullableDoubleProperty");
            AssertNullablePropertyEqual(expected.GuidProperty, EdmType.Guid, properties, "GuidProperty",
                (p) => p.GuidValue);
            AssertPropertyNull(properties, "NullableGuidProperty");
            AssertNullablePropertyEqual(expected.Int32Property, EdmType.Int32, properties, "Int32Property",
                (p) => p.Int32Value);
            AssertPropertyNull(properties, "NullableInt32Property");
            AssertNullablePropertyEqual(expected.Int64Property, EdmType.Int64, properties, "Int64Property",
                (p) => p.Int64Value);
            AssertPropertyNull(properties, "NullableInt64Property");
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
            Assert.AreEqual(expectedType, property.PropertyType);
            Nullable<T> actualValue = actualAccessor.Invoke(property);
            Assert.True(actualValue.HasValue);
            Assert.AreEqual(expected, actualValue.Value);
        }

        private static void AssertPropertyValue(DynamicTableEntity entity, string propertyName, object expectedValue)
        {
            Assert.True(entity.Properties.ContainsKey(propertyName));
            EntityProperty property = entity.Properties[propertyName];
            Assert.NotNull(property);
            if (expectedValue is string)
            {
                Assert.AreEqual(EdmType.String, property.PropertyType);
                Assert.AreEqual(expectedValue, property.StringValue);
            }
            else if (expectedValue is int)
            {
                Assert.AreEqual(EdmType.Int32, property.PropertyType);
                Assert.AreEqual(expectedValue, property.Int32Value);
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
            Assert.AreEqual(expectedType, property.PropertyType);
            T actualValue = actualAccessor.Invoke(property);
            Assert.AreEqual(expected, actualValue);
        }

        private static void AssertPropertyNull(IDictionary<string, EntityProperty> properties,
            string propertyName)
        {
            Assert.NotNull(properties);
            Assert.False(properties.ContainsKey(propertyName));
        }

        // Assert the given table has the given entity with PropertyName=ExpectedValue
        private async Task AssertStringPropertyAsync(
            string propertyName,
            string expectedValue,
            string tableName = null,
            string partitionKey = PartitionKey,
            string rowKey = RowKey)
        {
            // Assert
            tableName ??= TableName;
            CloudTableClient client = Account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(tableName);
            Assert.True(await table.ExistsAsync().ConfigureAwait(false));
            DynamicTableEntity entity = table.Retrieve<DynamicTableEntity>(partitionKey, rowKey);
            Assert.NotNull(entity);
            Assert.NotNull(entity.Properties);
            Assert.True(entity.Properties.ContainsKey(propertyName));
            EntityProperty property = entity.Properties[propertyName];
            Assert.NotNull(property);
            Assert.AreEqual(EdmType.String, property.PropertyType);
            Assert.AreEqual(expectedValue, property.StringValue);
        }

        private class BindToCloudTableProgram
        {
            public void Run([Table(TableNameExpression)] CloudTable table)
            {
                Table = table;
            }

            public CloudTable Table { get; set; }
        }

        private class BindToICollectorJObjectProgram
        {
            public static void Run(
                [Table(TableNameExpression)] ICollector<JObject> table)
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
                [Table(TableNameExpression, PartitionKey, RowKey)]
                ICollector<JObject> table)
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
            public static void Run(
                [Table(TableNameExpression)] ICollector<ITableEntity> table, string newValue)
            {
                Dictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>
                {
                    { PropertyName, new EntityProperty(newValue) }
                };
                table.Add(new DynamicTableEntity(PartitionKey, RowKey, etag: null, properties: properties));
            }
        }

        private class BindToICollectorPocoProgram
        {
            public static void Run(
                [Table(TableNameExpression)] ICollector<Poco> table, string newValue)
            {
                table.Add(new Poco { PartitionKey = PartitionKey, RowKey = RowKey, Property = newValue });
            }
        }

        private class BindToICollectorPocoWithAllTypesProgram
        {
            public static void Run(
                [Table(TableNameExpression)] ICollector<PocoWithAllTypes> table, PocoWithAllTypes entity)
            {
                table.Add(entity);
            }
        }

        private class CustomTableBindingExtensionProgram
        {
            public static void Run([Table(TableNameExpression)] CustomTableBinding<Poco> table)
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
            public static void Run([Table(TableNameExpression)] ICollector<BadPoco> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram2
        {
            public static void Run([Table(TableNameExpression)] ICollector<BadPocoMissingRowKey> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram3
        {
            public static void Run([Table(TableNameExpression)] ICollector<BadPocoMissingPartitionKey> output)
            {
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class BadProgram4
        {
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] BadPocoMissingDefaultCtor input)
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
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] out Poco value)
            {
                value = null;
                Assert.True(false, "should have gotten error at indexing time.");
            }
        }

        private class TableOutArrayProgram
        {
            public static void Run([Table(TableNameExpression, PartitionKey, RowKey)] out Poco[] value)
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