// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Queryable;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TableClientQueryableLiveTests : TableServiceLiveTestsBase
    {

        public TableClientQueryableLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [Test]
        public async Task TableQueryableExecuteQueryGeneric()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 1);
            entitiesToInsert.AddRange(CreateComplexTableEntities(PartitionKeyValue2, 1));

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            var query = client.CreateQuery<ComplexEntity>().Where(x => x.PartitionKey == PartitionKeyValue).AsTableQuery();
            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            foreach (var entity in results)
            {
                Assert.That(entity.PartitionKey, Is.EqualTo(PartitionKeyValue));
            }
        }

        [Test]
        public async Task TableQueryableFilterPredicate()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 4);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            // Filter before key predicate.
            var query = (from ent in client.CreateQuery<ComplexEntity>()
                         where ent.RowKey != "0004" && ent.PartitionKey == PartitionKeyValue
                         select ent).AsTableQuery();

            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            foreach (ComplexEntity ent in results)
            {
                Assert.That(ent.PartitionKey, Is.EqualTo(PartitionKeyValue));
                Assert.That(ent.RowKey, Is.Not.EqualTo("0004"));
            }
            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count - 1));

            // Key predicate before filter.
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.PartitionKey == PartitionKeyValue && ent.RowKey != "0004"
                     select ent).AsTableQuery();

            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            foreach (ComplexEntity ent in results)
            {
                Assert.That(ent.PartitionKey, Is.EqualTo(PartitionKeyValue));
                Assert.That(ent.RowKey, Is.Not.EqualTo("0004"));
            }
            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count - 1));
        }

        [Test]
        public async Task TableQueryableComplexFilter()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 4);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            var query = (from ent in client.CreateQuery<ComplexEntity>()
                         where (ent.RowKey == "0004" && ent.Int32 == 4) || ((ent.Int32 == 2) && (ent.String == "wrong string" || ent.Bool == true)) || (ent.LongPrimitiveN == (long)int.MaxValue + 50)
                         select ent).AsTableQuery();

            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            foreach (ComplexEntity ent in results)
            {
                Assert.IsTrue(ent.Int32 == 4 || ent.Int32 == 2);
            }

            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TableQueryableNestedParanthesis()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 4);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            // Complex nested query to return entity 2 and 4.
            var query = (from ent in client.CreateQuery<ComplexEntity>()
                         where (ent.RowKey == "0004" && ent.Int32 == 4) ||
                         ((ent.Int32 == 2) && (ent.String == "wrong string" || ent.Bool == true) && !(ent.IntegerPrimitive == 1 && ent.LongPrimitive == (long)int.MaxValue + 1)) ||
                         (ent.LongPrimitiveN == (long)int.MaxValue + 50)
                         select ent).AsTableQuery();

            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            foreach (ComplexEntity ent in results)
            {
                Assert.IsTrue(ent.Int32 == 4 || ent.Int32 == 2);
            }

            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TableQueryableUnary()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 4);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            // Unary Not.

            var query = client.CreateQuery<ComplexEntity>()
                .Where(x => x.PartitionKey == PartitionKeyValue)
                .Where(x => !(x.RowKey == entitiesToInsert[0].RowKey))
                .AsTableQuery();
            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            // Assert that all but one were returned

            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count - 1));

            foreach (var ent in results)
            {
                Assert.That(ent.RowKey, Is.Not.EqualTo(entitiesToInsert[0].RowKey));
            }

            // Unary +.

            query = client.CreateQuery<ComplexEntity>()
                .Where(x => x.PartitionKey == PartitionKeyValue)
                .Where(x => +x.Int32 < +5)
                .AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            // Assert that all were returned
            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count));

            // Unary -.

            query = client.CreateQuery<ComplexEntity>()
                .Where(x => x.PartitionKey == PartitionKeyValue)
                .Where(x => x.Int32 > -1)
                .AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            // Assert that all were returned
            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count));
        }

        [Test]
        public async Task TableTakeWithContinuationTask()
        {
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 20);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            // Query the entities with a Take count to limit the number of responses

            var query = client.CreateQuery<TestEntity>()
                .Where(e => e.PartitionKey == PartitionKeyValue)
                .Take(10)
                .AsTableQuery();

            var pagedResult = InstrumentClient(query).ExecuteAsync();

            await foreach (Page<TestEntity> page in pagedResult.AsPages())
            {
                Assert.That(page.Values.Count, Is.EqualTo(10), "The entity paged result count should be 10");
            }
        }

        [Test]
        public async Task TableQueryableMultipleTake()
        {
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 10);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            // Query the entities with a Take count to limit the number of responses. The lower of the Take values is what takes effect.

            var query = client.CreateQuery<TestEntity>()
                .Where(e => e.PartitionKey == PartitionKeyValue)
                .Take(5).Take(12)
                .AsTableQuery();

            var pagedResult = InstrumentClient(query).ExecuteAsync();

            await foreach (Page<TestEntity> page in pagedResult.AsPages())
            {
                Assert.That(page.Values.Count, Is.EqualTo(5), "The entity paged result count should be 5");
            }
        }

        [Test]
        public async Task TableQueryableDynamicTableEntityQuery()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 2);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            Func<string, string> identityFunc = (s) => s;

            var query = client.CreateQuery<ComplexEntity>()
                .Where(x => x.PartitionKey == PartitionKeyValue && x.RowKey == identityFunc(entitiesToInsert[1].RowKey))
                .AsTableQuery();
            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();
            var entity = results.SingleOrDefault();

            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.PartitionKey, Is.EqualTo(PartitionKeyValue));
            Assert.That(entity.RowKey, Is.EqualTo(entitiesToInsert[1].RowKey));
        }

        [Test]
        public async Task TableQueryableMultipleWhere()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 2);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            var query = client.CreateQuery<ComplexEntity>()
                .Where(x => x.PartitionKey == PartitionKeyValue)
                .Where(x => x.RowKey == entitiesToInsert[1].RowKey)
                .AsTableQuery();
            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();
            var entity = results.SingleOrDefault();

            Assert.That(entity, Is.Not.Null);
            Assert.That(entity.PartitionKey, Is.EqualTo(PartitionKeyValue));
            Assert.That(entity.RowKey, Is.EqualTo(entitiesToInsert[1].RowKey));

        }

        [Test]
        public async Task TableQueryableEnumerateTwice()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 2);

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            TableQuery<ComplexEntity> res = (from ent in client.CreateQuery<ComplexEntity>()
                                             select ent).AsTableQuery();

            List<ComplexEntity> firstIteration = new List<ComplexEntity>();
            List<ComplexEntity> secondIteration = new List<ComplexEntity>();

            foreach (ComplexEntity ent in res)
            {
                Assert.That(ent.PartitionKey, Is.EqualTo(PartitionKeyValue));
                firstIteration.Add(ent);
            }

            foreach (ComplexEntity ent in res)
            {
                Assert.That(ent.PartitionKey, Is.EqualTo(PartitionKeyValue));
                secondIteration.Add(ent);
            }
            Assert.That(firstIteration.Count, Is.EqualTo(secondIteration.Count));

            for (int m = 0; m < firstIteration.Count; m++)
            {
                ComplexEntity.AssertEquality(firstIteration[m], secondIteration[m]);
            }
        }


        [Test]
        public async Task TableQueryableOnSupportedTypes()
        {
            var entitiesToInsert = CreateComplexTableEntities(PartitionKeyValue, 4);
            ComplexEntity thirdEntity = entitiesToInsert[2];

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // 1. Filter on String
            var query = (from ent in client.CreateQuery<ComplexEntity>()
                         where ent.String.CompareTo(thirdEntity.String) >= 0
                         select ent).AsTableQuery();
            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            // 2. Filter on Guid
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Guid == thirdEntity.Guid
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));


            // 3. Filter on Long
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Int64 >= thirdEntity.Int64
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.LongPrimitive >= thirdEntity.LongPrimitive
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.LongPrimitiveN >= thirdEntity.LongPrimitiveN
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 4. Filter on Double
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Double >= thirdEntity.Double
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.DoublePrimitive >= thirdEntity.DoublePrimitive
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 5. Filter on Integer
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Int32 >= thirdEntity.Int32
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Int32N >= thirdEntity.Int32N
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 6. Filter on Date
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.DateTimeOffset >= thirdEntity.DateTimeOffset
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.DateTimeOffset < thirdEntity.DateTimeOffset
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 7. Filter on Boolean
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Bool == thirdEntity.Bool
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.BoolPrimitive == thirdEntity.BoolPrimitive
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 8. Filter on Binary
            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.Binary == thirdEntity.Binary
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.BinaryPrimitive == thirdEntity.BinaryPrimitive
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));


            // 10. Complex Filter on Binary GTE

            query = (from ent in client.CreateQuery<ComplexEntity>()
                     where ent.PartitionKey == thirdEntity.PartitionKey &&
                     ent.String.CompareTo(thirdEntity.String) >= 0 &&
                     ent.Int64 >= thirdEntity.Int64 &&
                     ent.LongPrimitive >= thirdEntity.LongPrimitive &&
                     ent.LongPrimitiveN >= thirdEntity.LongPrimitiveN &&
                     ent.Int32 >= thirdEntity.Int32 &&
                     ent.Int32N >= thirdEntity.Int32N &&
                     ent.DateTimeOffset >= thirdEntity.DateTimeOffset
                     select ent).AsTableQuery();
            results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TableQueryableWithInvalidQuery()
        {
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 1);
            entitiesToInsert.AddRange(CreateCustomTableEntities(PartitionKeyValue2, 1));

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            var query = (from ent in client.CreateQuery<TestEntity>()
                         where ent.PartitionKey == PartitionKeyValue && ent.PartitionKey == PartitionKeyValue2
                         select ent).AsTableQuery();

            var results = (await InstrumentClient(query).ExecuteAsync().ToEnumerableAsync().ConfigureAwait(false)).ToList();
            Assert.That(results.Count, Is.Zero);
        }
    }
}
