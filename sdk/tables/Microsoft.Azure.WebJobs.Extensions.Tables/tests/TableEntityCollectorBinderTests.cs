// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TableEntityCollectorBinderTests
    {
        internal class StubTableEntityWriter<T> : TableEntityWriter<T>
            where T : ITableEntity
        {
            public int TimesPartitionFlushed { get; set; }
            public int TimesFlushed { get; set; }

            public StubTableEntityWriter()
                : base(new TableClient(new Uri("https://localhost:10000/account/table")))
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
                Dictionary<string, TableTransactionAction> batch, CancellationToken cancellationToken)
            {
                // Do nothing
                TimesPartitionFlushed++;
                return Task.FromResult(0);
            }
        }

        [Test]
        public void ValueHasNotChanged()
        {
            // Arrange
            var table = Mock.Of<TableClient>();
            StubTableEntityWriter<TableEntity> writer = new StubTableEntityWriter<TableEntity>();
            Type valueType = typeof(TableEntityWriter<TableEntity>);
            TableEntityCollectorBinder<TableEntity> product = new TableEntityCollectorBinder<TableEntity>(table, writer, valueType);
            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.Null(parameterLog);
        }

        [Test]
        public void PropertyHasBeenAdded()
        {
            // Arrange
            TableClient table = Mock.Of<TableClient>();
            StubTableEntityWriter<TableEntity> writer = new StubTableEntityWriter<TableEntity>();
            Type valueType = typeof(TableEntityWriter<TableEntity>);
            TableEntityCollectorBinder<TableEntity> product = new TableEntityCollectorBinder<TableEntity>(table, writer, valueType);
            TableEntity value = new TableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                ["Item"]=("Foo")
            };
            writer.Add(value);
            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(1, parameterLog.EntitiesWritten);
            Assert.AreEqual(0, writer.TimesPartitionFlushed);
        }

        [Test]
        public void MaximumBatchSizeFlushes()
        {
            // Arrange
            TableClient table = Mock.Of<TableClient>();
            StubTableEntityWriter<TableEntity> writer = new StubTableEntityWriter<TableEntity>();
            Type valueType = typeof(TableEntityWriter<TableEntity>);
            TableEntityCollectorBinder<TableEntity> product = new TableEntityCollectorBinder<TableEntity>(table, writer, valueType);
            TableEntity value = new TableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                ["Item"]=("Foo")
            };
            for (int i = 0; i < TableEntityWriter<ITableEntity>.MaxBatchSize + 1; i++)
            {
                value.RowKey = "RK" + i;
                writer.Add(value);
            }

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(TableEntityWriter<ITableEntity>.MaxBatchSize + 1, parameterLog.EntitiesWritten);
            Assert.AreEqual(1, writer.TimesPartitionFlushed);
        }

        [Test]
        public void MaximumPartitionWidthFlushes()
        {
            // Arrange
            TableClient table = Mock.Of<TableClient>();
            StubTableEntityWriter<TableEntity> writer = new StubTableEntityWriter<TableEntity>();
            Type valueType = typeof(TableEntityWriter<TableEntity>);
            TableEntityCollectorBinder<TableEntity> product = new TableEntityCollectorBinder<TableEntity>(table, writer, valueType);
            TableEntity value = new TableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                ["Item"]=("Foo")
            };
            for (int i = 0; i < TableEntityWriter<ITableEntity>.MaxPartitionWidth + 1; i++)
            {
                value.PartitionKey = "PK" + i;
                writer.Add(value);
            }

            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(TableEntityWriter<ITableEntity>.MaxPartitionWidth + 1, parameterLog.EntitiesWritten);
            Assert.AreEqual(1, writer.TimesFlushed);
            Assert.AreEqual(TableEntityWriter<ITableEntity>.MaxPartitionWidth, writer.TimesPartitionFlushed);
        }

        [Test]
        public void PropertyHasBeenReplaced()
        {
            // Arrange
            TableClient table = Mock.Of<TableClient>();
            StubTableEntityWriter<TableEntity> writer = new StubTableEntityWriter<TableEntity>();
            Type valueType = typeof(TableEntityWriter<TableEntity>);
            TableEntityCollectorBinder<TableEntity> product = new TableEntityCollectorBinder<TableEntity>(table, writer, valueType);
            TableEntity value = new TableEntity
            {
                PartitionKey = "PK",
                RowKey = "RK",
                ["Item"]=("Foo")
            };
            writer.Add(value);
            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(1, parameterLog.EntitiesWritten);
            Assert.AreEqual(0, writer.TimesPartitionFlushed);
            // Calling again should yield no changes
            Assert.AreEqual(1, parameterLog.EntitiesWritten);
            // Assert
            Assert.AreEqual(0, writer.TimesPartitionFlushed);
            // Add same value again.
            writer.Add(value);
            // Act
            parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(2, parameterLog.EntitiesWritten);
            Assert.AreEqual(1, writer.TimesPartitionFlushed);
        }
    }
}