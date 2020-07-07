﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Tables;
using Microsoft.Azure.Cosmos.Table;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Tables
{
    public class TableEntityCollectorBinderTests
    {
        internal class StubTableEntityWriter<T> : TableEntityWriter<T>
            where T : ITableEntity
        {
            public int TimesPartitionFlushed { get; set; }
            public int TimesFlushed { get; set; }

            public StubTableEntityWriter()
                : base(new CloudTable(new Uri("http://localhost:10000/account/table")))
            {
                TimesFlushed = 0;
                TimesPartitionFlushed = 0;
            }

            public override Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                TimesFlushed++;
                return base.FlushAsync(cancellationToken);
            }

            internal override Task ExecuteBatchAndCreateTableIfNotExistsAsync(
                Dictionary<string, TableOperation> batch, CancellationToken cancellationToken)
            {
                // Do nothing
                TimesPartitionFlushed++;

                return Task.FromResult(0);
            }
        }

        [Fact]
        public void ValueHasNotChanged()
        {
            // Arrange
            var client = CreateTableClient();
            var table = client.GetTableReference("table");
            StubTableEntityWriter<DynamicTableEntity> writer = new StubTableEntityWriter<DynamicTableEntity>();
            Type valueType = typeof(TableEntityWriter<DynamicTableEntity>);
            TableEntityCollectorBinder<DynamicTableEntity> product = new TableEntityCollectorBinder<DynamicTableEntity>(table, writer, valueType);

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;

            // Assert
            Assert.Null(parameterLog);
        }

        [Fact]
        public void PropertyHasBeenAdded()
        {
            // Arrange
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
            StubTableEntityWriter<DynamicTableEntity> writer = new StubTableEntityWriter<DynamicTableEntity>();
            Type valueType = typeof(TableEntityWriter<DynamicTableEntity>);
            TableEntityCollectorBinder<DynamicTableEntity> product = new TableEntityCollectorBinder<DynamicTableEntity>(table, writer, valueType);

            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };

            writer.Add(value);

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;

            // Assert
            Assert.Equal(1, parameterLog.EntitiesWritten);
            Assert.Equal(0, writer.TimesPartitionFlushed);
        }

        [Fact]
        public void MaximumBatchSizeFlushes()
        {
            // Arrange
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
            StubTableEntityWriter<DynamicTableEntity> writer = new StubTableEntityWriter<DynamicTableEntity>();
            Type valueType = typeof(TableEntityWriter<DynamicTableEntity>);
            TableEntityCollectorBinder<DynamicTableEntity> product = new TableEntityCollectorBinder<DynamicTableEntity>(table, writer, valueType);

            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };

            for (int i = 0; i < TableEntityWriter<ITableEntity>.MaxBatchSize + 1; i++)
            {
                value.RowKey = "RK" + i;
                writer.Add(value);
            }

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;

            // Assert
            Assert.Equal(TableEntityWriter<ITableEntity>.MaxBatchSize + 1, parameterLog.EntitiesWritten);
            Assert.Equal(1, writer.TimesPartitionFlushed);
        }

        [Fact]
        public void MaximumPartitionWidthFlushes()
        {
            // Arrange
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
            StubTableEntityWriter<DynamicTableEntity> writer = new StubTableEntityWriter<DynamicTableEntity>();
            Type valueType = typeof(TableEntityWriter<DynamicTableEntity>);
            TableEntityCollectorBinder<DynamicTableEntity> product = new TableEntityCollectorBinder<DynamicTableEntity>(table, writer, valueType);

            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };

            for (int i = 0; i < TableEntityWriter<ITableEntity>.MaxPartitionWidth + 1; i++)
            {
                value.PartitionKey = "PK" + i;
                writer.Add(value);
            }

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;

            // Assert
            Assert.Equal(TableEntityWriter<ITableEntity>.MaxPartitionWidth + 1, parameterLog.EntitiesWritten);
            Assert.Equal(1, writer.TimesFlushed);
            Assert.Equal(TableEntityWriter<ITableEntity>.MaxPartitionWidth, writer.TimesPartitionFlushed);
        }

        [Fact]
        public void PropertyHasBeenReplaced()
        {
            // Arrange
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
            StubTableEntityWriter<DynamicTableEntity> writer = new StubTableEntityWriter<DynamicTableEntity>();
            Type valueType = typeof(TableEntityWriter<DynamicTableEntity>);
            TableEntityCollectorBinder<DynamicTableEntity> product = new TableEntityCollectorBinder<DynamicTableEntity>(table, writer, valueType);

            DynamicTableEntity value = new DynamicTableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                Properties = new Dictionary<string, EntityProperty> { { "Item", new EntityProperty("Foo") } }
            };

            writer.Add(value);

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;

            // Assert
            Assert.Equal(1, parameterLog.EntitiesWritten);
            Assert.Equal(0, writer.TimesPartitionFlushed);

            // Calling again should yield no changes
            Assert.Equal(1, parameterLog.EntitiesWritten);

            // Assert
            Assert.Equal(0, writer.TimesPartitionFlushed);

            // Add same value again.
            writer.Add(value);

            // Act
            parameterLog = product.GetStatus() as TableParameterLog;

            // Assert
            Assert.Equal(2, parameterLog.EntitiesWritten);
            Assert.Equal(1, writer.TimesPartitionFlushed);
        }

        private CloudTableClient CreateTableClient()
        {
            // StorageClientFactory clientFactory = new StorageClientFactory();
            // IStorageTableClient client = new StorageAccount(CloudStorageAccount.DevelopmentStorageAccount, clientFactory).CreateTableClient();
            var account = StorageAccount.New(null, CloudStorageAccount.DevelopmentStorageAccount);
            return account.CreateCloudTableClient();
        }
    }
}
