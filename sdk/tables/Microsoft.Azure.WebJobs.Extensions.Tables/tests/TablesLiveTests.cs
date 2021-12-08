// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.Tables.Tests;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TablesLiveTests: TablesLiveTestBase
    {
        [TestCase("FuncWithITableEntity")]
        [TestCase("FuncWithPocoObjectEntity")]
        [TestCase("FuncWithPocoValueEntity")]
        [TestCase("FuncWithICollector")]
        public async Task Table_IfBoundToTypeAndTableIsMissing_DoesNotCreate(string methodName)
        {
            TableName = "ThisTableDoesntExistAndShouldntBeCreated";
            // Act
            await CallAsync<MissingTableProgram>(methodName);
            // Assert
            var table = Account.CreateCloudTableClient().GetTableReference(TableName);
            Assert.False(await table.ExistsAsync());
        }

        [Test]
        public async Task Table_IfBoundToCloudTableAndTableIsMissing_Creates()
        {
            TableName = "ThisTableDoesntExist";
            var tableReference = Account.CreateCloudTableClient().GetTableReference(TableName);

            // Act
            await CallAsync<BindToCloudTableProgram>();

            // Assert

            var table = tableReference;
            Assert.True(await table.ExistsAsync());
        }

        private class BindToCloudTableProgram
        {
            public async Task BindToCloudTable([Table(TableNameExpression)] CloudTable table)
            {
                Assert.NotNull(table);
                await table.ExistsAsync();
            }
        }

        [Test]
        public async Task Table_IfBoundToICollectorITableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToICollectorITableEntity>();
        }

        private class BindTableToICollectorITableEntity
        {
            public static void Call([Table(TableNameExpression)] ICollector<ITableEntity> table)
            {
                table.Add(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }

        [Test]
        public async Task Table_IfBoundToICollectorDynamicTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToICollectorDynamicTableEntity>();
        }

        private class BindTableToICollectorDynamicTableEntity
        {
            public static void Call([Table(TableNameExpression)] ICollector<DynamicTableEntity> table)
            {
                table.Add(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }

        [Test]
        public async Task Table_IfBoundToICollectorSdkTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToICollectorSdkTableEntity>();
        }

        private class BindTableToICollectorSdkTableEntity
        {
            public static void Call([Table(TableNameExpression)] ICollector<SdkTableEntity> table)
            {
                table.Add(new SdkTableEntity { PartitionKey = PartitionKey, RowKey = RowKey });
            }
        }

        [Test]
        public async Task Table_IfBoundToIAsyncCollectorITableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToIAsyncCollectorITableEntity>();
        }

        private class BindTableToIAsyncCollectorITableEntity
        {
            public static Task Call([Table(TableNameExpression)] IAsyncCollector<ITableEntity> table)
            {
                return table.AddAsync(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }

        [Test]
        public async Task Table_IfBoundToIAsyncCollectorDynamicTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToIAsyncCollectorDynamicTableEntity>();
        }

        private class BindTableToIAsyncCollectorDynamicTableEntity
        {
            public static Task Call([Table(TableNameExpression)] IAsyncCollector<DynamicTableEntity> table)
            {
                return table.AddAsync(new DynamicTableEntity(PartitionKey, RowKey));
            }
        }

        [Test]
        public async Task Table_IfBoundToIAsyncCollectorSdkTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToIAsyncCollectorSdkTableEntity>();
        }

        private class BindTableToIAsyncCollectorSdkTableEntity
        {
            public static Task Call([Table(TableNameExpression)] IAsyncCollector<SdkTableEntity> table)
            {
                return table.AddAsync(new SdkTableEntity { PartitionKey = PartitionKey, RowKey = RowKey });
            }
        }

        private async Task TestTableBoundToCollectorCanCallAsync<T>() where T : new()
        {
            // Arrange
            await CallAsync<T>();

            // Assert
            DynamicTableEntity entity = CloudTable.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
        }

        [Test]
        public async Task Table_IfBoundToCollectorAndETagDoesNotMatch_Throws()
        {
            await TestBindToConcurrentlyUpdatedTableEntity<BindTableToCollectorFoo>("collector");
        }

        private class BindTableToCollectorFoo
        {
            public static void Call([Table(TableNameExpression)] ICollector<ITableEntity> collector,
                [Table(TableNameExpression)] CloudTable table)
            {
                SdkTableEntity entity = table.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
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

        [Test]
        public async Task TableEntity_IfBoundToJArray_CanCall()
        {
            CloudTable.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "1", "Value", "x1", "*"));
            CloudTable.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "2", "Value", "x2", "*"));
            CloudTable.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "3", "Value", "x3", "*"));
            CloudTable.InsertOrReplace(CreateTableEntity(PartitionKey, RowKey + "4", "Value", "x4", "*"));

            // Act
            var result1 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.CallTakeFilter));
            Assert.AreEqual("x1;x3;", result1._result);

            var result2 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.CallFilter));
            Assert.AreEqual("x1;x3;x4;", result2._result);

            var result3 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.CallTake));
            Assert.AreEqual("x1;x2;x3;", result3._result);

            var result4 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.Call));
            Assert.AreEqual("x1;x2;x3;x4;", result4._result);
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

            public void CallTakeFilter([Table(TableNameExpression, PartitionKey, Take = 2, Filter = "Value ne 'x2'")] JArray array)
            {
                this._result = Flatten(array);
            }

            public void CallFilter([Table(TableNameExpression, PartitionKey, Filter = "Value ne 'x2'")] JArray array)
            {
                this._result = Flatten(array);
            }

            public void CallTake([Table(TableNameExpression, PartitionKey, Take = 3)] JArray array)
            {
                this._result = Flatten(array);
            }

            // No take or filters
            public void Call([Table(TableNameExpression, PartitionKey)] JArray array)
            {
                this._result = Flatten(array);
            }
        }

        [Test]
        public async Task TableEntity_IfBoundToJObject_CanCall()
        {
            // Arrange
            CloudTable.Insert(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));

            await CallAsync<BindTableEntityToJObjectProgram>(arguments: new
            {
                table = TableName, // Test resolution
                pk1 = PartitionKey,
                rk1 = RowKey
            });

            // Assert
            SdkTableEntity entity = CloudTable.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
        }

        private class BindTableEntityToJObjectProgram
        {
            public static void Call([Table("{table}", "{pk1}", "{rk1}")] JObject entity)
            {
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity["Value"].ToString());
            }
        }

        [Test]
        public async Task TableEntity_IfBoundToSdkTableEntity_CanCall()
        {
            // Arrange
            CloudTable.Insert(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));
            // Act
            await CallAsync<BindTableEntityToSdkTableEntityProgram>();
            // Assert
            SdkTableEntity entity = CloudTable.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual("Bar", entity.Value);
        }

        private class BindTableEntityToSdkTableEntityProgram
        {
            public static void Call([Table(TableNameExpression, PartitionKey, RowKey)] SdkTableEntity entity)
            {
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
                entity.Value = "Bar";
            }
        }

        [Test]
        public async Task TableEntity_IfBoundToPocoTableEntity_CanCall()
        {
            // Arrange
            CloudTable.Insert(new DynamicTableEntity(PartitionKey, RowKey, null, new Dictionary<string, EntityProperty>
            {
                { "Fruit", new EntityProperty("Banana") },
                { "Duration", new EntityProperty("\"00:00:01\"") },
                { "Value", new EntityProperty("Foo") }
            }));

            // Act
            await CallAsync<BindTableEntityToPocoTableEntityProgram>();

            // Assert
            DynamicTableEntity entity = CloudTable.Retrieve<DynamicTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual(PartitionKey, entity.PartitionKey); // Guard
            Assert.AreEqual(RowKey, entity.RowKey); // Guard
            IDictionary<string, EntityProperty> properties = entity.Properties;
            Assert.AreEqual(3, properties.Count);
            Assert.True(properties.ContainsKey("Value"));
            EntityProperty fruitProperty = properties["Fruit"];
            Assert.AreEqual(EdmType.String, fruitProperty.PropertyType);
            Assert.AreEqual("Pear", fruitProperty.StringValue);
            EntityProperty durationProperty = properties["Duration"];
            Assert.AreEqual(EdmType.String, durationProperty.PropertyType);
            Assert.AreEqual("\"00:02:00\"", durationProperty.StringValue);
            EntityProperty valueProperty = properties["Value"];
            Assert.AreEqual(EdmType.String, valueProperty.PropertyType);
            Assert.AreEqual("Bar", valueProperty.StringValue);
        }

        private class BindTableEntityToPocoTableEntityProgram
        {
            public static void Call([Table(TableNameExpression, PartitionKey, RowKey)] PocoTableEntityWithEnum entity)
            {
                Assert.NotNull(entity);
                Assert.AreEqual(Fruit.Banana, entity.Fruit);
                Assert.AreEqual(TimeSpan.FromSeconds(1), entity.Duration);
                Assert.AreEqual("Foo", entity.Value);
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

        [Test]
        public async Task TableEntity_IfBoundToSdkTableEntityAndUpdatedConcurrently_Throws()
        {
            await TestBindTableEntityToConcurrentlyUpdatedValue<BindTableEntityToConcurrentlyUpdatedSdkTableEntity>();
        }

        private class BindTableEntityToConcurrentlyUpdatedSdkTableEntity
        {
            public static void Call([Table(TableNameExpression, PartitionKey, RowKey)] SdkTableEntity entity,
                [Table(TableNameExpression)] CloudTable table)
            {
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
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

        [Test]
        public async Task TableEntity_IfBoundToPocoTableEntityAndUpdatedConcurrently_Throws()
        {
            await TestBindTableEntityToConcurrentlyUpdatedValue<BindTableEntityToConcurrentlyUpdatedPocoTableEntity>();
        }

        private class BindTableEntityToConcurrentlyUpdatedPocoTableEntity
        {
            public static void Call([Table(TableNameExpression, PartitionKey, RowKey)] PocoTableEntity entity,
                [Table(TableNameExpression)] CloudTable table)
            {
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
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

        private async Task TestBindTableEntityToConcurrentlyUpdatedValue<T>()
        {
            await TestBindToConcurrentlyUpdatedTableEntity<T>("entity");
        }

        private async Task TestBindToConcurrentlyUpdatedTableEntity<T>(string parameterName)
        {
            // Arrange
            await CloudTable.CreateIfNotExistsAsync();
            CloudTable.Insert(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));

            // Act & Assert
            var exception = Assert.CatchAsync<FunctionInvocationException>(async () => await CallAsync<T>("Call"));

            AssertInvocationETagFailure(parameterName, exception);
            SdkTableEntity entity = CloudTable.Retrieve<SdkTableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual("FooBackground", entity.Value);
        }

        private void AssertInvocationETagFailure(string expectedParameterName, Exception exception)
        {
            Assert.IsInstanceOf<FunctionInvocationException>(exception);

            Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
            string expectedMessage = String.Format(CultureInfo.InvariantCulture,
                "Error while handling parameter {0} after function returned:", expectedParameterName);
            Assert.AreEqual(expectedMessage, exception.InnerException.Message);

            Exception innerException = exception.InnerException.InnerException;
            Assert.IsInstanceOf<StorageException>(innerException);

            StorageException invalidOperationException = (StorageException)innerException;
            Assert.NotNull(invalidOperationException.Message);
            //"Precondition Failed",
            Assert.That(invalidOperationException.Message, Contains.Substring("UpdateConditionNotSatisfied").Or.Contains("Precondition Failed"));
        }

        private ITableEntity CreateTableEntity(string partitionKey, string rowKey, string propertyName,
            string propertyValue, string eTag = null)
        {
            return new DynamicTableEntity(partitionKey, rowKey, eTag, new Dictionary<string, EntityProperty>
            {
                { propertyName, new EntityProperty(propertyValue) }
            });
        }

        private class MissingTableProgram
        {
            public static void FuncWithICollector([Table(TableNameExpression)] ICollector<SdkTableEntity> entities)
            {
                Assert.NotNull(entities);
            }

            public static void FuncWithITableEntity([Table(TableNameExpression, "PK", "RK")] SdkTableEntity entity)
            {
                Assert.Null(entity);
            }

            public static void FuncWithPocoObjectEntity([Table(TableNameExpression, "PK", "RK")] PocoTableEntity entity)
            {
                Assert.Null(entity);
            }

            public static void FuncWithPocoValueEntity([Table(TableNameExpression, "PK", "RK")] StructTableEntity entity)
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