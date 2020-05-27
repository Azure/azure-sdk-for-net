// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

            var results = (await client.QueryAsync<ComplexEntity>(x => x.PartitionKey == PartitionKeyValue, default).ToEnumerableAsync().ConfigureAwait(false)).ToList();

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
            var results = (await client.QueryAsync<ComplexEntity>(ent => ent.RowKey != "0004" && ent.PartitionKey == PartitionKeyValue).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            foreach (ComplexEntity ent in results)
            {
                Assert.That(ent.PartitionKey, Is.EqualTo(PartitionKeyValue));
                Assert.That(ent.RowKey, Is.Not.EqualTo("0004"));
            }
            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count - 1));

            // Key predicate before filter.

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.PartitionKey == PartitionKeyValue && ent.RowKey != "0004").ToEnumerableAsync().ConfigureAwait(false)).ToList();

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

            var results = (await client.QueryAsync<ComplexEntity>(ent => (ent.RowKey == "0004" && ent.Int32 == 4) || ((ent.Int32 == 2) && (ent.String == "wrong string" || ent.Bool == true)) || (ent.LongPrimitiveN == (long)int.MaxValue + 50)).ToEnumerableAsync().ConfigureAwait(false)).ToList();

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
            var results = (await client.QueryAsync<ComplexEntity>(ent => (ent.RowKey == "0004" && ent.Int32 == 4) ||
                         ((ent.Int32 == 2) && (ent.String == "wrong string" || ent.Bool == true) && !(ent.IntegerPrimitive == 1 && ent.LongPrimitive == (long)int.MaxValue + 1)) ||
                         (ent.LongPrimitiveN == (long)int.MaxValue + 50)).ToEnumerableAsync().ConfigureAwait(false)).ToList();

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

            var results = (await client.QueryAsync<ComplexEntity>(x => x.PartitionKey == PartitionKeyValue && !(x.RowKey == entitiesToInsert[0].RowKey)).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            // Assert that all but one were returned

            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count - 1));

            foreach (var ent in results)
            {
                Assert.That(ent.RowKey, Is.Not.EqualTo(entitiesToInsert[0].RowKey));
            }

            // Unary +.

            results = (await client.QueryAsync<ComplexEntity>(x => x.PartitionKey == PartitionKeyValue && +x.Int32 < +5).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            // Assert that all were returned
            Assert.That(results.Count, Is.EqualTo(entitiesToInsert.Count));

            // Unary -.

            results = (await client.QueryAsync<ComplexEntity>(x => x.PartitionKey == PartitionKeyValue && x.Int32 > -1).ToEnumerableAsync().ConfigureAwait(false)).ToList();

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

            var pagedResult = client.QueryAsync<TestEntity>(e => e.PartitionKey == PartitionKeyValue, top: 10);

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

            var pagedResult = client.QueryAsync<TestEntity>(e => e.PartitionKey == PartitionKeyValue, top: 5);

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

            var results = (await client.QueryAsync<ComplexEntity>(x => x.PartitionKey == PartitionKeyValue && x.RowKey == identityFunc(entitiesToInsert[1].RowKey)).ToEnumerableAsync().ConfigureAwait(false)).ToList();
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

            var results = (await client.QueryAsync<ComplexEntity>(x => x.PartitionKey == PartitionKeyValue && x.RowKey == entitiesToInsert[1].RowKey).ToEnumerableAsync().ConfigureAwait(false)).ToList();
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

            var results = (await client.QueryAsync<ComplexEntity>(x => true).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            List<ComplexEntity> firstIteration = new List<ComplexEntity>();
            List<ComplexEntity> secondIteration = new List<ComplexEntity>();

            foreach (ComplexEntity ent in results)
            {
                Assert.That(ent.PartitionKey, Is.EqualTo(PartitionKeyValue));
                firstIteration.Add(ent);
            }

            foreach (ComplexEntity ent in results)
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
            var results = (await client.QueryAsync<ComplexEntity>(ent => ent.String.CompareTo(thirdEntity.String) >= 0).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            // 2. Filter on Guid
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Guid == thirdEntity.Guid).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));


            // 3. Filter on Long
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Int64 >= thirdEntity.Int64).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.LongPrimitive >= thirdEntity.LongPrimitive).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.LongPrimitiveN >= thirdEntity.LongPrimitiveN).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 4. Filter on Double
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Double >= thirdEntity.Double).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.DoublePrimitive >= thirdEntity.DoublePrimitive).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 5. Filter on Integer
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Int32 >= thirdEntity.Int32).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Int32N >= thirdEntity.Int32N).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 6. Filter on Date
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.DateTimeOffset >= thirdEntity.DateTimeOffset).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.DateTimeOffset < thirdEntity.DateTimeOffset).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 7. Filter on Boolean
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Bool == thirdEntity.Bool).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.BoolPrimitive == thirdEntity.BoolPrimitive).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));


            // 8. Filter on Binary
            results = (await client.QueryAsync<ComplexEntity>(ent => ent.Binary == thirdEntity.Binary).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.BinaryPrimitive == thirdEntity.BinaryPrimitive).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));


            // 10. Complex Filter on Binary GTE

            results = (await client.QueryAsync<ComplexEntity>(ent => ent.PartitionKey == thirdEntity.PartitionKey &&
                     ent.String.CompareTo(thirdEntity.String) >= 0 &&
                     ent.Int64 >= thirdEntity.Int64 &&
                     ent.LongPrimitive >= thirdEntity.LongPrimitive &&
                     ent.LongPrimitiveN >= thirdEntity.LongPrimitiveN &&
                     ent.Int32 >= thirdEntity.Int32 &&
                     ent.Int32N >= thirdEntity.Int32N &&
                     ent.DateTimeOffset >= thirdEntity.DateTimeOffset).ToEnumerableAsync().ConfigureAwait(false)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TableQueryableWithInvalidQuery()
        {
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 1);
            entitiesToInsert.AddRange(CreateCustomTableEntities(PartitionKeyValue2, 1));

            // Insert the new entities.

            await InsertTestEntities(entitiesToInsert).ConfigureAwait(false);

            var results = (await client.QueryAsync<ComplexEntity>(ent => ent.PartitionKey == PartitionKeyValue && ent.PartitionKey == PartitionKeyValue2).ToEnumerableAsync().ConfigureAwait(false)).ToList();
            Assert.That(results.Count, Is.Zero);
        }
    }
}
