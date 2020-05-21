// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;
using Azure.Data.Tables.Queryable;
using static Azure.Data.Tables.Tests.TableServiceLiveTestsBase;
using System.Linq;
using System.Reflection;

namespace Azure.Data.Tables.Tests
{
    public class TableClientQueryableTests : ClientTestBase
    {
        public TableClientQueryableTests(bool isAsync) : base(isAsync)
        { }
        /*
        private const string tableName = "someTableName";
        private TableClient client { get; set; }

        [SetUp]
        public void TestSetup()
        {
            var service_Instrumented = InstrumentClient(new TableServiceClient(new Uri("https://example.com")));
            client = service_Instrumented.GetTableClient(tableName);
        }

        [Test]
        public void TableQueryableWithInvalidTakeCount()
        {
            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.String.CompareTo("0050") > 0
                               select ent).Take(0).ToList(), Throws.InstanceOf<ArgumentException>());

            Assert.That(() =>
                client.CreateQuery<ComplexEntity>()
                    .Where(ent => ent.String.CompareTo("0050") > 0)
                    .Take(-1).ToList(), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void TableQueryableUnsupportedMultipleFrom()
        {
            TableQuery<ComplexEntity> query = (from ent in client.CreateQuery<ComplexEntity>()
                                               from ent2 in client.CreateQuery<ComplexEntity>()
                                               where ent.RowKey == ent2.RowKey
                                               select ent).AsTableQuery();

            Assert.That(() => query.ExecuteAsync(), Throws.InstanceOf<NotSupportedException>());
        }

        [Test]
        public void TableQueryableUnsupportedReverse()
        {
            System.Linq.IQueryable<ComplexEntity> query = (from ent in client.CreateQuery<ComplexEntity>()
                                                           where (ent.PartitionKey == "tables_batch_1" && ent.RowKey.CompareTo("0050") > 0)
                                                           select ent).Reverse();
            Assert.That(() => query.Count(), Throws.InstanceOf<TargetInvocationException>());
        }

        [Test]
        public void TableQueryableUnsupportedGroupBy()
        {
            var query = (from ent in client.CreateQuery<ComplexEntity>()
                         group ent.Int32 by ent.Int32 % 5 into mod5Group
                         select new
                         {
                             numbers = mod5Group
                         });

            Assert.That(() => query.Count(), Throws.InstanceOf<TargetInvocationException>());
        }

        [Test]
        public void TableQueryableUnsupportedDistinct()
        {
            System.Linq.IQueryable<string> query = (from ent in client.CreateQuery<TestEntity>()
                                                    select ent.RowKey).Distinct();

            Assert.That(() => query.Count(), Throws.InstanceOf<TargetInvocationException>());
        }

        [Test]
        public void TableQueryableUnsupportedSetOperators()
        {
            System.Linq.IQueryable<string> query = from ent in client.CreateQuery<TestEntity>()
                                                   where ent.PartitionKey == "tables_batch_1" && ent.RowKey.CompareTo("0050") >= 0
                                                   select ent.RowKey;

            System.Linq.IQueryable<string> query2 = from ent in client.CreateQuery<ComplexEntity>()
                                                    where ent.RowKey.CompareTo("0050") <= 0
                                                    select ent.RowKey;
            // Set operators
            Assert.That(() => query.Union(query2).Count(), Throws.InstanceOf<TargetInvocationException>());
            Assert.That(() => query.Intersect(query2).Count(), Throws.InstanceOf<TargetInvocationException>());
            Assert.That(() => query.Except(query2).Count(), Throws.InstanceOf<TargetInvocationException>());

            // Miscellaneous operators
            Assert.That(() => query.Concat(query2).Count(), Throws.InstanceOf<TargetInvocationException>());
            Assert.That(() => query.SequenceEqual(query2), Throws.InstanceOf<TargetInvocationException>());
        }

        [Test]
        public void TableQueryableUnsupportedElementAt()
        {
            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.RowKey.CompareTo("0050") > 0
                               select ent.Int32).ElementAt(0), Throws.InstanceOf<TargetInvocationException>());

            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.RowKey.CompareTo("0050") > 0
                               select ent.Int32).ElementAtOrDefault(0), Throws.InstanceOf<TargetInvocationException>());
        }

        [Test]
        public void TableQueryableUnsupportedAggregation()
        {
            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.RowKey.CompareTo("0050") > 0
                               select ent.Int32).Sum(), Throws.InstanceOf<TargetInvocationException>());

            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.RowKey.CompareTo("0050") > 0
                               select ent.Int32).Min(), Throws.InstanceOf<TargetInvocationException>());

            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.RowKey.CompareTo("0050") > 0
                               select ent.Int32).Max(), Throws.InstanceOf<TargetInvocationException>());

            Assert.That(() => (from ent in client.CreateQuery<ComplexEntity>()
                               where ent.RowKey.CompareTo("0050") > 0
                               select ent.Int32).Average(), Throws.InstanceOf<TargetInvocationException>());

        }
        */
    }
}
