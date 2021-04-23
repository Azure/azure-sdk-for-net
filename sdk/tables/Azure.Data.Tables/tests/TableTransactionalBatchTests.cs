// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableTransactionalBatchTests
    {
        private const string partition = "partition";

        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new TableTransactionalBatch(null));
            Assert.Throws<ArgumentException>(() => new TableTransactionalBatch(string.Empty));
            new TableTransactionalBatch(partition);
        }

        [Test]
        public void GetEntities()
        {
            var entities = TableServiceLiveTestsBase.CreateTableEntities(partition, 5);
            var target = new TableTransactionalBatch(partition);

            target.AddEntity(entities[0]);
            target.DeleteEntity(entities[1].RowKey);
            target.UpdateEntity(entities[2], entities[2].ETag);
            target.UpsertEntity(entities[3]);
            target.AddEntities(entities.Skip(4));

            CollectionAssert.AreEqual(entities.Select(e => e.RowKey), target.GetEntities().Select(e => e.RowKey));
        }

        [Test]
        public void ClearOperations()
        {
            var entities = TableServiceLiveTestsBase.CreateTableEntities(partition, 5);
            var target = new TableTransactionalBatch(partition);
            target.AddEntities(entities);

            target.ClearOperations();

            CollectionAssert.IsEmpty(target.GetEntities());
            Assert.AreEqual(0, target.OperationCount);
        }

        [Test]
        public void RemoveEntity()
        {
            var entities = TableServiceLiveTestsBase.CreateTableEntities(partition, 5);
            var target = new TableTransactionalBatch(partition);
            target.AddEntities(entities);

            target.RemoveEntity(entities[3]);
            entities.Remove(entities[3]);

            CollectionAssert.AreEqual(entities.Select(e => e.RowKey), target.GetEntities().Select(e => e.RowKey));
            Assert.AreEqual(4, target.OperationCount);
        }
    }
}
