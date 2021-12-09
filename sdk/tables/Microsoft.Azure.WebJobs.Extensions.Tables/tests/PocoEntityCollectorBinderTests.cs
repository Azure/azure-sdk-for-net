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
    public class PocoEntityCollectorBinderTests
    {
        public class SimpleClass
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
        }

        internal class StubTableEntityWriter : TableEntityWriter<ITableEntity>
        {
            public StubTableEntityWriter()
                : base(new TableClient(new Uri("https://localhost:10000/account/table")))
            {
            }

            internal override Task ExecuteBatchAndCreateTableIfNotExistsAsync(
                Dictionary<string, TableTransactionAction> batch, CancellationToken cancellationToken)
            {
                // Do nothing
                return Task.FromResult(0);
            }
        }

        [Test]
        public void ValueHasNotChanged()
        {
            // Arrange
            TableClient table = Mock.Of<TableClient>();
            PocoEntityWriter<SimpleClass> writer = new PocoEntityWriter<SimpleClass>(table);
            writer.TableEntityWriter = new StubTableEntityWriter();
            Type valueType = typeof(PocoEntityWriter<SimpleClass>);
            PocoEntityCollectorBinder<SimpleClass> product = new PocoEntityCollectorBinder<SimpleClass>(table, writer,
                valueType);
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
            PocoEntityWriter<SimpleClass> writer = new PocoEntityWriter<SimpleClass>(table);
            writer.TableEntityWriter = new StubTableEntityWriter();
            Type valueType = typeof(PocoEntityWriter<SimpleClass>);
            PocoEntityCollectorBinder<SimpleClass> product = new PocoEntityCollectorBinder<SimpleClass>(table, writer, valueType);
            SimpleClass value = new SimpleClass
            {
                PartitionKey = "PK",
                RowKey = "RK"
            };
            writer.Add(value);
            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(1, parameterLog.EntitiesWritten);
        }

        [Test]
        public void PropertyHasBeenReplaced()
        {
            // Arrange
            TableClient table = Mock.Of<TableClient>();
            PocoEntityWriter<SimpleClass> writer = new PocoEntityWriter<SimpleClass>(table);
            writer.TableEntityWriter = new StubTableEntityWriter();
            Type valueType = typeof(PocoEntityWriter<SimpleClass>);
            PocoEntityCollectorBinder<SimpleClass> product = new PocoEntityCollectorBinder<SimpleClass>(table, writer, valueType);
            SimpleClass value = new SimpleClass
            {
                PartitionKey = "PK",
                RowKey = "RK"
            };
            writer.Add(value);
            // Act
            var parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(1, parameterLog.EntitiesWritten);
            // Calling again should yield no changes
            parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(1, parameterLog.EntitiesWritten);
            // Add same value again.
            writer.Add(value);
            // Act
            parameterLog = product.GetStatus() as TableParameterLog;
            // Assert
            Assert.AreEqual(2, parameterLog.EntitiesWritten);
        }
    }
}