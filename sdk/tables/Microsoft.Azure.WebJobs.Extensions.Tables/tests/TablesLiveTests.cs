// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TablesLiveTests: TablesLiveTestBase
    {
        public TablesLiveTests(bool isAsync, bool useCosmos) : base(isAsync, useCosmos)
        {
        }

        [RecordedTest]
        public async Task Table_IfBoundToICollectorITableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToICollectorITableEntity>();
        }

        private class BindTableToICollectorITableEntity
        {
            public static void Call([Table(TableNameExpression)] ICollector<ITableEntity> table)
            {
                table.Add(new TableEntity(PartitionKey, RowKey));
            }
        }

        [RecordedTest]
        public async Task Table_IfBoundToICollectorTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToICollectorTableEntity>();
        }

        private class BindTableToICollectorTableEntity
        {
            public static void Call([Table(TableNameExpression)] ICollector<TableEntity> table)
            {
                table.Add(new TableEntity(PartitionKey, RowKey));
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task Table_IfBoundToIAsyncCollectorITableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToIAsyncCollectorITableEntity>();
        }

        private class BindTableToIAsyncCollectorITableEntity
        {
            public static Task Call([Table(TableNameExpression)] IAsyncCollector<ITableEntity> table)
            {
                return table.AddAsync(new TableEntity(PartitionKey, RowKey));
            }
        }

        [RecordedTest]
        public async Task Table_IfBoundToIAsyncCollectorTableEntity_CanCall()
        {
            await TestTableBoundToCollectorCanCallAsync<BindTableToIAsyncCollectorTableEntity>();
        }

        private class BindTableToIAsyncCollectorTableEntity
        {
            public static Task Call([Table(TableNameExpression)] IAsyncCollector<TableEntity> table)
            {
                return table.AddAsync(new TableEntity(PartitionKey, RowKey));
            }
        }

        [RecordedTest]
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
            TableEntity entity = await TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
        }

        [Test]
        public async Task Table_IfBoundToCollectorAndETagDoesNotMatch_Throws()
        {
            await TestBindToConcurrentlyUpdatedTableEntity<BindTableToCollectorFoo>("collector");
        }

        private class BindTableToCollectorFoo
        {
            public static async Task Call([Table(TableNameExpression)] ICollector<ITableEntity> collector,
                [Table(TableNameExpression)] TableClient table)
            {
                SdkTableEntity entity = await table.GetEntityAsync<SdkTableEntity>(PartitionKey, RowKey);
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
                // Update the entity to invalidate the version read by this method.
                await table.UpdateEntityAsync(new SdkTableEntity
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    Value = "FooBackground"
                }, ETag.All);
                // The attempted update by this method should now fail.
                collector.Add(new TableEntity(PartitionKey, RowKey)
                {
                    ETag = entity.ETag,
                    ["Value"] = "Bar"
                });
            }
        }

        [RecordedTest]
        public async Task TableEntity_IfBoundToJArray_CanCall()
        {
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey + "1", "Value", "x1"));
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey + "2", "Value", "x2"));
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey + "3", "Value", "x3"));
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey + "4", "Value", "x4"));

            // Act
            var result1 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.CallTakeFilter));
            Assert.AreEqual("x1;x3;", result1.Result);

            var result2 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.CallFilter));
            Assert.AreEqual("x1;x3;x4;", result2.Result);

            var result3 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.CallTake));
            Assert.AreEqual("x1;x2;x3;", result3.Result);

            var result4 = await CallAsync<BindTableEntityToJArrayProgram>(nameof(BindTableEntityToJArrayProgram.Call));
            Assert.AreEqual("x1;x2;x3;x4;", result4.Result);
        }

        private class BindTableEntityToJArrayProgram
        {
            public string Result;

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
                Result = Flatten(array);
            }

            public void CallFilter([Table(TableNameExpression, PartitionKey, Filter = "Value ne 'x2'")] JArray array)
            {
                Result = Flatten(array);
            }

            public void CallTake([Table(TableNameExpression, PartitionKey, Take = 3)] JArray array)
            {
                Result = Flatten(array);
            }

            // No take or filters
            public void Call([Table(TableNameExpression, PartitionKey)] JArray array)
            {
                Result = Flatten(array);
            }
        }

        [RecordedTest]
        public async Task TableEntity_IfBoundToJObject_CanCall()
        {
            // Arrange
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));

            await CallAsync<BindTableEntityToJObjectProgram>(arguments: new
            {
                table = TableName, // Test resolution
                pk1 = PartitionKey,
                rk1 = RowKey
            });

            // Assert
            SdkTableEntity entity = await TableClient.GetEntityAsync<SdkTableEntity>(PartitionKey, RowKey);
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

        [RecordedTest]
        public async Task TableEntity_IfBoundToSdkTableEntity_CanCall()
        {
            // Arrange
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));
            // Act
            await CallAsync<BindTableEntityToSdkTableEntityProgram>();
            // Assert
            SdkTableEntity entity = await TableClient.GetEntityAsync<SdkTableEntity>(PartitionKey, RowKey);
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

        [RecordedTest]
        public async Task TableEntity_IfBoundToPocoTableEntity_CanCall()
        {
            // Arrange
            await TableClient.AddEntityAsync(new TableEntity(PartitionKey, RowKey)
            {
                { "Fruit", ("Banana") },
                { "Duration", ("\"00:00:01\"") },
                { "Value", ("Foo") }
            });

            // Act
            await CallAsync<BindTableEntityToPocoTableEntityProgram>();

            // Assert
            TableEntity entity = await TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.NotNull(entity);
            Assert.AreEqual(PartitionKey, entity.PartitionKey); // Guard
            Assert.AreEqual(RowKey, entity.RowKey); // Guard

            // TODO: behavior change. Was 3 before
            Assert.AreEqual(7, entity.Count);
            Assert.AreEqual("Pear", entity["Fruit"]);
            Assert.AreEqual("\"00:02:00\"", entity["Duration"]);
            Assert.AreEqual("Bar", entity["Value"]);
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

        [RecordedTest]
        public Task TableEntity_IfBoundToPocoThatDoesntExist_Null_PocoTableEntity() =>
            CallAsync<BindTableEntityToPocoTableEntityDoesntExistProgram<PocoTableEntity>>();

        [RecordedTest]
        public Task TableEntity_IfBoundToPocoThatDoesntExist_Null_JObject() =>
            CallAsync<BindTableEntityToPocoTableEntityDoesntExistProgram<JObject>>();

        [RecordedTest]
        public Task TableEntity_IfBoundToPocoThatDoesntExist_Null_ITableEntity() =>
            CallAsync<BindTableEntityToPocoTableEntityDoesntExistProgram<ITableEntity>>();

        [RecordedTest]
        public Task TableEntity_IfBoundToPocoThatDoesntExist_Null_TableEntity() =>
            CallAsync<BindTableEntityToPocoTableEntityDoesntExistProgram<TableEntity>>();

        private class BindTableEntityToPocoTableEntityDoesntExistProgram<T>
        {
            public static void Call([Table(TableNameExpression, PartitionKey, RowKey)] T entity)
            {
                Assert.IsNull(entity);
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

        [RecordedTest]
        public async Task TableEntity_IfBoundToSdkTableEntityAndUpdatedConcurrently_Throws()
        {
            await TestBindTableEntityToConcurrentlyUpdatedValue<BindTableEntityToConcurrentlyUpdatedSdkTableEntity>();
        }

        private class BindTableEntityToConcurrentlyUpdatedSdkTableEntity
        {
            public static async Task Call([Table(TableNameExpression, PartitionKey, RowKey)] SdkTableEntity entity,
                [Table(TableNameExpression)] TableClient table)
            {
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
                // Update the entity to invalidate the version read by this method.
                await table.UpdateEntityAsync(new SdkTableEntity
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    Value = "FooBackground"
                }, ETag.All);
                // The attempted update by this method should now fail.
                entity.Value = "Bar";
            }
        }

        [RecordedTest]
        public async Task TableEntity_IfBoundToPocoTableEntityAndUpdatedConcurrently_Throws()
        {
            await TestBindTableEntityToConcurrentlyUpdatedValue<BindTableEntityToConcurrentlyUpdatedPocoTableEntity>();
        }

        private class BindTableEntityToConcurrentlyUpdatedPocoTableEntity
        {
            public static async Task Call([Table(TableNameExpression, PartitionKey, RowKey)] PocoTableEntity entity,
                [Table(TableNameExpression)] TableClient table)
            {
                Assert.NotNull(entity);
                Assert.AreEqual("Foo", entity.Value);
                // Update the entity to invalidate the version read by this method.
                await table.UpdateEntityAsync(new SdkTableEntity
                {
                    PartitionKey = PartitionKey,
                    RowKey = RowKey,
                    Value = "FooBackground"
                }, ETag.All);
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
            await TableClient.CreateIfNotExistsAsync();
            await TableClient.AddEntityAsync(CreateTableEntity(PartitionKey, RowKey, "Value", "Foo"));

            // Act & Assert
            var exception = Assert.CatchAsync<FunctionInvocationException>(async () => await CallAsync<T>("Call"));

            AssertInvocationETagFailure(parameterName, exception);
            SdkTableEntity entity = await TableClient.GetEntityAsync<SdkTableEntity>(PartitionKey, RowKey);
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
            Assert.IsInstanceOf<RequestFailedException>(innerException);

            RequestFailedException invalidOperationException = (RequestFailedException)innerException;
            Assert.NotNull(invalidOperationException.Message);
            //"Precondition Failed",
            Assert.That(invalidOperationException.Message, Contains.Substring("UpdateConditionNotSatisfied").Or.Contains("Precondition Failed"));
        }

        private TableEntity CreateTableEntity(string partitionKey, string rowKey, string propertyName,
            string propertyValue, string eTag = null)
        {
            return new TableEntity(partitionKey, rowKey)
            {
                ETag = eTag != null ? new ETag(eTag) : default,
                [propertyName] = propertyValue
            };
        }
        private class SdkTableEntity : ITableEntity
        {
            public string Value { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
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