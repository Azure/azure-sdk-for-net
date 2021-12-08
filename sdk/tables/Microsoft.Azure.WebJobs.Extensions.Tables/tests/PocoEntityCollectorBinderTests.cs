// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Cosmos.Table;
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
                : base(new CloudTable(new Uri("http://localhost:10000/account/table")))
            {
            }

            internal override Task ExecuteBatchAndCreateTableIfNotExistsAsync(
                Dictionary<string, TableOperation> batch, CancellationToken cancellationToken)
            {
                // Do nothing
                return Task.FromResult(0);
            }
        }

        [Test]
        public void ValueHasNotChanged()
        {
            // Arrange
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
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
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
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
            var client = CreateTableClient();
            CloudTable table = client.GetTableReference("table");
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

        private CloudTableClient CreateTableClient()
        {
            //StorageClientFactory clientFactory = new StorageClientFactory();
            //IStorageTableClient client = new StorageAccount(CloudStorageAccount.DevelopmentStorageAccount, clientFactory).CreateTableClient();
            // return client;
            var account = StorageAccount.New(null, CloudStorageAccount.DevelopmentStorageAccount);
            return account.CreateCloudTableClient();
        }
    }
}