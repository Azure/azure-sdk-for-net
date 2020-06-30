// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;
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
    public class TableClientLiveTests : TableServiceLiveTestsBase
    {

        public TableClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [Test]
        public void ValidateSasCredentials()
        {
            // Create a SharedKeyCredential that we can use to sign the SAS token

            var credential = new TableSharedKeyCredential(TestEnvironment.AccountName, TestEnvironment.PrimaryStorageAccountKey);

            // Build a shared access signature with only Read permissions.

            TableSasBuilder sas = client.GetSasBuilder(TableSasPermissions.Read, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            string token = sas.Sign(credential);

            // Build a SAS URI
            UriBuilder sasUri = new UriBuilder(TestEnvironment.StorageUri)
            {
                Query = token
            };

            // Create the TableServiceClient using the SAS URI.

            var sasAuthedService = InstrumentClient(new TableServiceClient(sasUri.Uri, Recording.InstrumentClientOptions(new TableClientOptions())));
            var sasTableclient = sasAuthedService.GetTableClient(tableName);

            // Validate that we are able to query the table from the service.

            Assert.That(async () => await sasTableclient.QueryAsync().ToEnumerableAsync().ConfigureAwait(false), Throws.Nothing);

            // Validate that we are not able to upsert an entity to the table.

            Assert.That(async () => await sasTableclient.InsertOrReplaceAsync(CreateTableEntities("partition", 1).First()), Throws.InstanceOf<RequestFailedException>().And.Property("Status").EqualTo((int)HttpStatusCode.Forbidden));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task InsertedEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            List<IDictionary<string, object>> entityResults;
            List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(PartitionKeyValue, 20);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // Query the entities.

            entityResults = await client.QueryAsync(top: pageCount).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(entitiesToInsert.Count), "The entity result count should match the inserted count");
            entityResults.Clear();
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedEntitiesCanBeQueriedWithFilters()
        {
            List<IDictionary<string, object>> entityResults;
            List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(PartitionKeyValue, 20);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey gt '10'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntitiyCanBeUpserted()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";

            var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var entityToUpdate = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            entityToUpdate[propertyName] = updatedValue;
            await client.InsertOrReplaceAsync(entityToUpdate).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityUpdateRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.UpdateAsync(originalEntity, "*").ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.UpdateAsync(updatedEntity, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.UpdateAsync(updatedEntity, updatedEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityMergeRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.MergeAsync(originalEntity, "*").ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.MergeAsync(updatedEntity, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.MergeAsync(updatedEntity, updatedEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityMergeDoesPartialPropertyUpdates()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string mergepropertyName = "MergedProperty";
            const string originalValue = "This is the original";
            const string mergeValue = "This was merged!";
            const string mergeUpdatedValue = "merged value was updated!";
            var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };
            var partialEntity = new Dictionary<string, object>
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {mergepropertyName, mergeValue}
                };


            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Verify that the merge property does not yet exist yet and that the original property does exist.

            Assert.That(originalEntity.TryGetValue(mergepropertyName, out var _), Is.False);
            Assert.That(originalEntity[propertyName], Is.EqualTo(originalValue));

            await client.InsertOrMergeAsync(partialEntity).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var mergedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Verify that the merge property does not yet exist yet and that the original property does exist.

            Assert.That(mergedEntity[mergepropertyName], Is.EqualTo(mergeValue));
            Assert.That(mergedEntity[propertyName], Is.EqualTo(originalValue));

            // Update just the merged value.

            partialEntity[mergepropertyName] = mergeUpdatedValue;
            await client.InsertOrMergeAsync(partialEntity).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            mergedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Verify that the merge property does not yet exist yet and that the original property does exist.

            Assert.That(mergedEntity[mergepropertyName], Is.EqualTo(mergeUpdatedValue));
            Assert.That(mergedEntity[propertyName], Is.EqualTo(originalValue));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task EntityDeleteRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            var entity = new Dictionary<string, object>
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            var staleEtag = originalEntity[TableConstants.PropertyNames.Etag] as string;

            // Use a wildcard ETag to delete unconditionally.

            await client.DeleteAsync(PartitionKeyValue, rowKeyValue).ConfigureAwait(false);

            // Validate that the entity is deleted.

            var emptyresult = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");

            // Insert the new entity again.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Use a non-matching ETag.

            Assert.That(async () => await client.DeleteAsync(PartitionKeyValue, rowKeyValue, staleEtag).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.DeleteAsync(PartitionKeyValue, rowKeyValue, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

            // Validate that the entity is deleted.

            emptyresult = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedEntitiesAreRoundtrippedWithProperOdataAnnoations()
        {
            List<IDictionary<string, object>> entityResults;
            List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(PartitionKeyValue, 1);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.First()[StringTypePropertyName], Is.TypeOf<string>(), "The entity property should be of type string");
            Assert.That(entityResults.First()[DateTypePropertyName], Is.TypeOf<DateTime>(), "The entity property should be of type DateTime");
            Assert.That(entityResults.First()[GuidTypePropertyName], Is.TypeOf<Guid>(), "The entity property should be of type Guid");
            Assert.That(entityResults.First()[BinaryTypePropertyName], Is.TypeOf<byte[]>(), "The entity property should be of type byte[]");
            Assert.That(entityResults.First()[Int64TypePropertyName], Is.TypeOf<long>(), "The entity property should be of type int64");
            Assert.That(entityResults.First()[DoubleTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            Assert.That(entityResults.First()[DoubleDecimalTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            Assert.That(entityResults.First()[IntTypePropertyName], Is.TypeOf<int>(), "The entity property should be of type int");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task UpsertedEntitiesAreRoundtrippedWithProperOdataAnnoations()
        {
            List<IDictionary<string, object>> entityResults;
            List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(PartitionKeyValue, 1);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.First()[StringTypePropertyName], Is.TypeOf<string>(), "The entity property should be of type string");
            Assert.That(entityResults.First()[DateTypePropertyName], Is.TypeOf<DateTime>(), "The entity property should be of type DateTime");
            Assert.That(entityResults.First()[GuidTypePropertyName], Is.TypeOf<Guid>(), "The entity property should be of type Guid");
            Assert.That(entityResults.First()[BinaryTypePropertyName], Is.TypeOf<byte[]>(), "The entity property should be of type byte[]");
            Assert.That(entityResults.First()[Int64TypePropertyName], Is.TypeOf<long>(), "The entity property should be of type int64");
            Assert.That(entityResults.First()[DoubleTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            Assert.That(entityResults.First()[DoubleDecimalTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            Assert.That(entityResults.First()[IntTypePropertyName], Is.TypeOf<int>(), "The entity property should be of type int");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertReturnsEntitiesWithoutOdataAnnoations()
        {
            List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(PartitionKeyValue, 1);

            // Insert an entity.

            var insertedEntity = (await client.InsertAsync(entitiesToInsert.First()).ConfigureAwait(false)).Value;

            Assert.That(insertedEntity.Keys.Count(k => k.EndsWith(TableConstants.Odata.OdataTypeString)), Is.Zero, "The entity should not containt any odata data annotation properties");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task QueryReturnsEntitiesWithoutOdataAnnoations()
        {
            List<IDictionary<string, object>> entityResults;
            List<Dictionary<string, object>> entitiesToInsert = CreateTableEntities(PartitionKeyValue, 1);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.First().Keys.Count(k => k.EndsWith(TableConstants.Odata.OdataTypeString)), Is.Zero, "The entity should not containt any odata data annotation properties");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task InsertedCustomEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            List<TestEntity> entityResults;
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 20);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // Query the entities.

            entityResults = await client.QueryAsync<TestEntity>(top: pageCount).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(entitiesToInsert.Count), "The entity result count should match the inserted count");
            entityResults.Clear();
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedCustomEntitiesCanBeQueriedWithFilters()
        {
            List<TestEntity> entityResults;
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 20);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TestEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey gt '10'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task CustomEntityCanBeUpserted()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";

            var entity = new SimpleTestEntity
            {
                PartitionKey = PartitionKeyValue,
                RowKey = rowKeyValue,
                StringTypeProperty = originalValue,
            };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var entityToUpdate = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            entityToUpdate[propertyName] = updatedValue;
            await client.InsertOrReplaceAsync(entityToUpdate).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task CustomEntityUpdateRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            var entity = new SimpleTestEntity
            {
                PartitionKey = PartitionKeyValue,
                RowKey = rowKeyValue,
                StringTypeProperty = originalValue,
            };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.UpdateAsync(originalEntity, "*").ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.UpdateAsync(updatedEntity, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.UpdateAsync(updatedEntity, updatedEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task CustomEntityMergeRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            var entity = new SimpleTestEntity
            {
                PartitionKey = PartitionKeyValue,
                RowKey = rowKeyValue,
                StringTypeProperty = originalValue,
            };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.MergeAsync(originalEntity, "*").ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.MergeAsync(updatedEntity, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.MergeAsync(updatedEntity, updatedEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task CustomEntityDeleteRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string originalValue = "This is the original";
            var entity = new SimpleTestEntity
            {
                PartitionKey = PartitionKeyValue,
                RowKey = rowKeyValue,
                StringTypeProperty = originalValue,
            };

            // Insert the new entity.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            var staleEtag = originalEntity[TableConstants.PropertyNames.Etag] as string;

            // Use a wildcard ETag to delete unconditionally.

            await client.DeleteAsync(PartitionKeyValue, rowKeyValue).ConfigureAwait(false);

            // Validate that the entity is deleted.

            var emptyresult = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");

            // Insert the new entity again.

            await client.InsertOrReplaceAsync(entity).ConfigureAwait(false);

            // Fetch the created entity from the service.

            originalEntity = (await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Use a non-matching ETag.

            Assert.That(async () => await client.DeleteAsync(PartitionKeyValue, rowKeyValue, staleEtag).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.DeleteAsync(PartitionKeyValue, rowKeyValue, originalEntity[TableConstants.PropertyNames.Etag] as string).ConfigureAwait(false);

            // Validate that the entity is deleted.

            emptyresult = await client.QueryAsync(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedCustomEntitiesAreRoundtrippedProprly()
        {
            List<TestEntity> entityResults;
            var entitiesToInsert = CreateCustomTableEntities(PartitionKeyValue, 1);

            // Insert the new entities.

            foreach (var entity in entitiesToInsert)
            {
                await client.InsertAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TestEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);
            entityResults.Sort((first, second) => first.IntTypeProperty.CompareTo(second.IntTypeProperty));

            for (int i = 0; i < entityResults.Count; i++)
            {
                Assert.That(entityResults[i].BinaryTypeProperty, Is.EqualTo(entitiesToInsert[i].BinaryTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].DatetimeOffsetTypeProperty, Is.EqualTo(entitiesToInsert[i].DatetimeOffsetTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].DatetimeTypeProperty, Is.EqualTo(entitiesToInsert[i].DatetimeTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].DoubleTypeProperty, Is.EqualTo(entitiesToInsert[i].DoubleTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].GuidTypeProperty, Is.EqualTo(entitiesToInsert[i].GuidTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].Int64TypeProperty, Is.EqualTo(entitiesToInsert[i].Int64TypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].IntTypeProperty, Is.EqualTo(entitiesToInsert[i].IntTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].PartitionKey, Is.EqualTo(entitiesToInsert[i].PartitionKey), "The entities should be equivalent");
                Assert.That(entityResults[i].RowKey, Is.EqualTo(entitiesToInsert[i].RowKey), "The entities should be equivalent");
                Assert.That(entityResults[i].StringTypeProperty, Is.EqualTo(entitiesToInsert[i].StringTypeProperty), "The entities should be equivalent");
            }
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public async Task GetAccessPoliciesReturnsPolicies()
        {
            // Create some policies.

            var policyToCreate = new List<SignedIdentifier>
            {
                new SignedIdentifier("MyPolicy", new AccessPolicy(new DateTime(2020, 1,1,1,1,0,DateTimeKind.Utc), new DateTime(2021, 1,1,1,1,0,DateTimeKind.Utc), "r"))
            };

            await client.SetAccessPolicyAsync(tableAcl: policyToCreate);


            // Get the created policy.

            var policies = await client.GetAccessPolicyAsync();

            Assert.That(policies.Value[0].Id, Is.EqualTo(policyToCreate[0].Id));
            Assert.That(policies.Value[0].AccessPolicy.Expiry, Is.EqualTo(policyToCreate[0].AccessPolicy.Expiry));
            Assert.That(policies.Value[0].AccessPolicy.Permission, Is.EqualTo(policyToCreate[0].AccessPolicy.Permission));
            Assert.That(policies.Value[0].AccessPolicy.Start, Is.EqualTo(policyToCreate[0].AccessPolicy.Start));

        }
    }
}
