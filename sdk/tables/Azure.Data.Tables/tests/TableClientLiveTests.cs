// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
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
    public class TableClientLiveTests : RecordedTestBase<TablesTestEnvironment>
    {

        public TableClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
        }

        /// <summary>
        /// Creates a <see cref="TableServiceClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="TableServiceClient" />.</returns>
        private TableServiceClient CreateTableServiceClient()
        {
            return InstrumentClient(new TableServiceClient(new Uri(TestEnvironment.StorageUri),
                                                               new TablesSharedKeyCredential(
                                                                   TestEnvironment.AccountName,
                                                                   TestEnvironment.PrimaryStorageAccountKey
                                                               ), Recording.InstrumentClientOptions(new TableClientOptions())));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task InsertedEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(partitionKeyValue, 20);

                // Insert the new entities.

                foreach (var entity in entitiesToInsert)
                {
                    await client.InsertAsync(entity).ConfigureAwait(false);
                }

                // Query the entities.

                entityResults = (await client.QueryAsync(top: pageCount).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(entityResults.Count, Is.EqualTo(entitiesToInsert.Count), "The entity result count should match the inserted count");
                entityResults.Clear();
            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedEntitiesCanBeQueriedWithFilters()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(partitionKeyValue, 20);

                // Insert the new entities.

                foreach (var entity in entitiesToInsert)
                {
                    await client.InsertAsync(entity).ConfigureAwait(false);
                }

                // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

                entityResults = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey gt '10'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntitiyCanBeUpserted()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

                // Insert the new entity.

                await client.UpsertAsync(entity).ConfigureAwait(false);

                // Fetch the created entity from the service.

                var entityToUpdate = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                entityToUpdate[propertyName] = updatedValue;
                await client.UpsertAsync(entityToUpdate).ConfigureAwait(false);

                // Fetch the updated entity from the service.

                var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");
            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityUpdateRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

                // Insert the new entity.

                await client.UpsertAsync(entity).ConfigureAwait(false);

                // Fetch the created entity from the service.

                var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
                originalEntity[propertyName] = updatedValue;

                // Use a wildcard ETag to update unconditionally.

                await client.UpdateAsync(originalEntity, "*").ConfigureAwait(false);

                // Fetch the updated entity from the service.

                var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

                updatedEntity[propertyName] = updatedValue2;

                // Use a non-matching ETag.

                Assert.That(async () => await client.UpdateAsync(updatedEntity, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

                // Use a matching ETag.

                await client.UpdateAsync(updatedEntity, updatedEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

                // Fetch the newly updated entity from the service.

                updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");


            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityMergeRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

                // Insert the new entity.

                await client.UpsertAsync(entity).ConfigureAwait(false);

                // Fetch the created entity from the service.

                var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
                originalEntity[propertyName] = updatedValue;

                // Use a wildcard ETag to update unconditionally.

                await client.MergeAsync(originalEntity, "*").ConfigureAwait(false);

                // Fetch the updated entity from the service.

                var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

                updatedEntity[propertyName] = updatedValue2;

                // Use a non-matching ETag.

                Assert.That(async () => await client.MergeAsync(updatedEntity, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

                // Use a matching ETag.

                await client.MergeAsync(updatedEntity, updatedEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

                // Fetch the newly updated entity from the service.

                updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");


            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityMergeDoesPartialPropertyUpdates()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string mergepropertyName = "MergedProperty";
            const string originalValue = "This is the original";
            const string mergeValue = "This was merged!";
            const string mergeUpdatedValue = "merged value was updated!";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };
                var partialEntity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {mergepropertyName, mergeValue}
                };


                // Insert the new entity.

                await client.UpsertAsync(entity).ConfigureAwait(false);

                // Fetch the created entity from the service.

                var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                // Verify that the merge property does not yet exist yet and that the original property does exist.

                Assert.That(originalEntity.TryGetValue(mergepropertyName, out var _), Is.False);
                Assert.That(originalEntity[propertyName], Is.EqualTo(originalValue));

                // Do not provide an ETag to update unconditionally.

                await client.MergeAsync(partialEntity).ConfigureAwait(false);

                // Fetch the updated entity from the service.

                var mergedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                // Verify that the merge property does not yet exist yet and that the original property does exist.

                Assert.That(mergedEntity[mergepropertyName], Is.EqualTo(mergeValue));
                Assert.That(mergedEntity[propertyName], Is.EqualTo(originalValue));

                // Update just the merged value.

                partialEntity[mergepropertyName] = mergeUpdatedValue;
                await client.MergeAsync(partialEntity).ConfigureAwait(false);

                // Fetch the updated entity from the service.

                mergedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                // Verify that the merge property does not yet exist yet and that the original property does exist.

                Assert.That(mergedEntity[mergepropertyName], Is.EqualTo(mergeUpdatedValue));
                Assert.That(mergedEntity[propertyName], Is.EqualTo(originalValue));
            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityDeleteRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";
            const string partitionKeyValue = "somPartition";
            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            bool doCleanup = false;
            TableServiceClient service = CreateTableServiceClient();

            try
            {
                var createdTable = await service.CreateTableAsync(tableName).ConfigureAwait(false);
                TableClient client = InstrumentClient(service.GetTableClient(tableName));
                var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", partitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

                // Insert the new entity.

                await client.UpsertAsync(entity).ConfigureAwait(false);

                // Fetch the created entity from the service.

                var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
                var staleEtag = originalEntity[TableConstants.PropertyNames.Etag] as string;

                // Use a wildcard ETag to delete unconditionally.

                await client.DeleteAsync(partitionKeyValue, rowKeyValue).ConfigureAwait(false);

                // Validate that the entity is deleted.

                var emptyresult = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false));

                Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");

                // Insert the new entity again.

                await client.UpsertAsync(entity).ConfigureAwait(false);

                // Fetch the created entity from the service.

                originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

                // Use a non-matching ETag.

                Assert.That(async () => await client.DeleteAsync(partitionKeyValue, rowKeyValue, staleEtag).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

                // Use a matching ETag.

                await client.DeleteAsync(partitionKeyValue, rowKeyValue, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

                // Validate that the entity is deleted.

                emptyresult = (await client.QueryAsync(filter: $"PartitionKey eq '{partitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false));

                Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");


            }
            finally
            {
                if (doCleanup)
                {
                    await service.DeleteTableAsync(tableName);
                }
            }
        }

        private static List<Dictionary<string, object>> CreateTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.
            return Enumerable.Range(1, count).Select(n =>
            {
                string number = n.ToString();
                return new Dictionary<string, object>
                    {
                        {"PartitionKey", partitionKeyValue},
                        {"RowKey", n.ToString("D2")},
                        {"SomeStringProperty", $"This is table entity number {n:D2}"},
                        {"SomeDateProperty", new DateTime(2020, 1,1).AddMinutes(n).ToUniversalTime()},
                        {"SomeGuidProperty", new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}")},
                        {"SomeBinaryProperty", new byte[]{ 0x01, 0x02, 0x03, 0x04, 0x05 }},
                        {"SomeInt64Property", long.Parse(number)},
                        {"SomeDoubleProperty0", (double)n},
                        {"SomeDoubleProperty1", n + 0.1},
                        {"SomeIntProperty", int.Parse(number)},
                    };
            }).ToList();
        }
    }
}
