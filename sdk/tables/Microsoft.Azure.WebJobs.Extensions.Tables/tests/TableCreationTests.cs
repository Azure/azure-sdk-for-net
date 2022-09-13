// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableCreationTests : TablesLiveTestBase
    {
        public TableCreationTests(bool isAsync, bool useCosmos): base(isAsync, useCosmos, createTable: false)
        {
        }

        [RecordedTest]
        [GenericTestCase(typeof(ITableEntity))]
        [GenericTestCase(typeof(TableEntity))]
        [GenericTestCase(typeof(JObject))]
        [GenericTestCase(typeof(StructTableEntity))]
        [GenericTestCase(typeof(PocoTableEntity))]
        public async Task Table_IfBoundToTypeAndTableIsMissing_DoesNotCreate<T>()
        {
            // Act
            await CallAsync<BindEntity<T>>();
            // Assert
            Assert.False(await TableExistsAsync(TableName));
        }

        private class BindEntity<T>
        {
            public static void Call([Table(TableNameExpression, "PK", "RK")] T entity)
            {
                Assert.AreEqual(default(T), entity);
            }
        }

        [RecordedTest]
        [GenericTestCase(typeof(ITableEntity))]
        [GenericTestCase(typeof(TableEntity))]
        [GenericTestCase(typeof(JObject))]
        [GenericTestCase(typeof(StructTableEntity))]
        [GenericTestCase(typeof(PocoTableEntity))]
        public async Task Table_IfBoundToCollectorAndTableIsMissing_DoesNotCreate<T>()
        {
            // Act
            await CallAsync<BindCollector<T>>();
            // Assert
            Assert.False(await TableExistsAsync(TableName));
        }

        private class BindCollector<T>
        {
            public static void Call([Table(TableNameExpression)] ICollector<T> entities)
            {
                Assert.NotNull(entities);
            }
        }

        [RecordedTest]
        [GenericTestCase(typeof(ITableEntity))]
        [GenericTestCase(typeof(TableEntity))]
        [GenericTestCase(typeof(JObject))]
        [GenericTestCase(typeof(StructTableEntity))]
        [GenericTestCase(typeof(PocoTableEntity))]
        public async Task Table_IfBoundToCollectorAndTableIsMissingAndAdds_CreatesTable<T>()
        {
            // Act
            await CallAsync<BindCollectorAndAdd<T>>();
            // Assert
            var entity = TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.AreEqual("test value", entity.Result.Value["Value"]);
        }

        private class BindCollectorAndAdd<T>
        {
            public static void Call([Table(TableNameExpression)] ICollector<T> entities)
            {
                entities.Add(Create<T>());
            }
        }

        [RecordedTest]
        [GenericTestCase(typeof(ITableEntity))]
        [GenericTestCase(typeof(TableEntity))]
        [GenericTestCase(typeof(JObject))]
        [GenericTestCase(typeof(PocoTableEntity))]
        public async Task Table_IfBoundToOutParameterAndTableIsMissingAndAdds_CreatesTable<T>()
        {
            // Act
            await CallAsync<BindOut<T>>();
            // Assert
            var entity = TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.AreEqual("test value", entity.Result.Value["Value"]);
        }

        private class BindOut<T>
        {
            public static void Call([Table(TableNameExpression)] out T entity)
            {
                entity = Create<T>();
            }
        }

        [RecordedTest]
        [GenericTestCase(typeof(ITableEntity))]
        [GenericTestCase(typeof(TableEntity))]
        [GenericTestCase(typeof(JObject))]
        [GenericTestCase(typeof(StructTableEntity))]
        [GenericTestCase(typeof(PocoTableEntity))]
        [GenericTestCase(typeof(ExplicitlyImplementedITableEntity))]
        public async Task Table_IfBoundToReturnAndTableIsMissingAndAdds_CreatesTable<T>()
        {
            // Act
            await CallAsync<BindReturn<T>>();
            // Assert
            var entity = TableClient.GetEntityAsync<TableEntity>(PartitionKey, RowKey);
            Assert.AreEqual("test value", entity.Result.Value["Value"]);
        }

        private class BindReturn<T>
        {
            [return: Table(TableNameExpression)]
            public static T Call()
            {
                return Create<T>();
            }
        }

        [RecordedTest]
        public async Task Table_IfBoundToTableClient_BindsAndCreatesTable()
        {
            // Act
            TableClient result = (await CallAsync<BindToTableClientProgram>()).Table;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(TableName, result.Name);

            Assert.True(await TableExistsAsync(TableName).ConfigureAwait(false));
        }

        private class BindToTableClientProgram
        {
            public void Run([Table(TableNameExpression)] TableClient table)
            {
                Table = table;
            }

            public TableClient Table { get; set; }
        }

        private static T Create<T>()
        {
            if (typeof(T) == typeof(TableEntity) || typeof(T) == typeof(ITableEntity))
            {
                return (T)(object)new TableEntity(PartitionKey, RowKey)
                {
                    ["Value"] = "test value"
                };
            }
            if (typeof(T) == typeof(JObject))
            {
                return (T)(object)new JObject()
                {
                    ["RowKey"] = RowKey,
                    ["PartitionKey"] = PartitionKey,
                    ["Value"] = "test value"
                };
            }

            if (typeof(T) == typeof(PocoTableEntity))
            {
                return (T)(object)new PocoTableEntity()
                {
                    RowKey = RowKey,
                    PartitionKey = PartitionKey,
                    Value = "test value"
                };
            }

            if (typeof(T) == typeof(StructTableEntity))
            {
                return (T)(object)new StructTableEntity()
                {
                    RowKey = RowKey,
                    PartitionKey = PartitionKey,
                    Value = "test value"
                };
            }

            if (typeof(T) == typeof(ExplicitlyImplementedITableEntity))
            {
                return (T)(object)new ExplicitlyImplementedITableEntity()
                {
                    StringRK = RowKey,
                    StringPK = PartitionKey,
                    Value = "test value"
                };
            }

            Assert.Fail();
            return default;
        }

        private class PocoTableEntity
        {
            public string RowKey { get; set; }
            public string PartitionKey { get; set; }
            public string Value { get; set; }
        }

        private struct StructTableEntity
        {
            public string RowKey { get; set; }
            public string PartitionKey { get; set; }
            public string Value { get; set; }
        }

        private class ExplicitlyImplementedITableEntity : ITableEntity
        {
            public string StringPK { get; set; }
            public string StringRK { get; set; }
            public string Value { get; set; }

            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
            string ITableEntity.PartitionKey
            {
                get => StringPK;
                set => StringPK = value;
            }
            string ITableEntity.RowKey
            {
                get => StringRK;
                set => StringRK = value;
            }
        }
    }
}