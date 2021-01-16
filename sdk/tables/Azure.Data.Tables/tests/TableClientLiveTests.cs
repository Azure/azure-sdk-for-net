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
        public TableClientLiveTests(bool isAsync, TableEndpointType endpointType) : base(isAsync, endpointType /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreateIfNotExists()
        {
            // Call CreateIfNotExists when the table already exists.
            Assert.That(async () => await CosmosThrottleWrapper(async () => await client.CreateIfNotExistsAsync().ConfigureAwait(false)), Throws.Nothing);

            // Call CreateIfNotExists when the table does not already exist.
            var newTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            TableItem table;
            TableClient tableClient = null;
            try
            {
                tableClient = service.GetTableClient(newTableName);
                table = await CosmosThrottleWrapper(async () => await tableClient.CreateIfNotExistsAsync().ConfigureAwait(false));
            }
            finally
            {
                await tableClient.DeleteAsync().ConfigureAwait(false);
            }

            Assert.That(table.TableName, Is.EqualTo(newTableName));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task ValidateCreateDeleteTable()
        {
            // Get the TableClient of a table that hasn't been created yet.
            var validTableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            var tableClient = service.GetTableClient(validTableName);

            // Create the table using the TableClient method.
            await CosmosThrottleWrapper(async () => await tableClient.CreateAsync().ConfigureAwait(false));

            // Check that the table was created.
            var tableResponses = (await service.GetTablesAsync(filter: $"TableName eq '{validTableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();
            Assert.That(() => tableResponses, Is.Not.Empty);

            // Delete the table using the TableClient method.
            await CosmosThrottleWrapper(async () => await tableClient.DeleteAsync().ConfigureAwait(false));

            // Check that the table was deleted.
            tableResponses = (await service.GetTablesAsync(filter: $"TableName eq '{validTableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();
            Assert.That(() => tableResponses, Is.Empty);
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public void ValidateSasCredentials()
        {
            // Create a SharedKeyCredential that we can use to sign the SAS token

            var credential = new TableSharedKeyCredential(AccountName, AccountKey);

            // Build a shared access signature with only Read permissions.

            TableSasBuilder sas = client.GetSasBuilder(TableSasPermissions.Read, new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc));
            if (_endpointType == TableEndpointType.CosmosTable)
            {
                sas.Version = "2017-07-29";
            }

            string token = sas.Sign(credential);

            // Build a SAS URI
            UriBuilder sasUri = new UriBuilder(ServiceUri)
            {
                Query = token
            };

            // Create the TableServiceClient using the SAS URI.

            var sasAuthedService = InstrumentClient(new TableServiceClient(sasUri.Uri, InstrumentClientOptions(new TableClientOptions())));
            var sasTableclient = sasAuthedService.GetTableClient(tableName);

            // Validate that we are able to query the table from the service.

            Assert.That(async () => await sasTableclient.QueryAsync<TableEntity>().ToEnumerableAsync().ConfigureAwait(false), Throws.Nothing);

            // Validate that we are not able to upsert an entity to the table.

            Assert.That(async () => await sasTableclient.UpsertEntityAsync(CreateTableEntities("partition", 1).First(), TableUpdateMode.Replace).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>().And.Property("Status").EqualTo((int)HttpStatusCode.Forbidden));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        [TestCase(null)]
        [TestCase(5)]
        public async Task CreatedEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            List<TableEntity> entityResults;
            List<TableEntity> entitiesToCreate = CreateTableEntities(PartitionKeyValue, 20);

            // Create the new entities.

            await CreateTestEntities(entitiesToCreate).ConfigureAwait(false);

            // Query the entities.

            entityResults = await client.QueryAsync<TableEntity>(maxPerPage: pageCount).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(entitiesToCreate.Count), "The entity result count should match the created count");
            entityResults.Clear();
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreatedDynamicEntitiesCanBeQueriedWithFilters()
        {
            List<TableEntity> entityResults;
            List<TableEntity> entitiesToCreate = CreateDictionaryTableEntities(PartitionKeyValue, 20);

            // Create the new entities.

            foreach (var entity in entitiesToCreate)
            {
                await client.AddEntityAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey gt '10'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreatedEntitiesCanBeQueriedWithFilters()
        {
            List<TableEntity> entityResults;
            List<TableEntity> entitiesToCreate = CreateTableEntities(PartitionKeyValue, 20);

            // Create the new entities.

            await CreateTestEntities(entitiesToCreate).ConfigureAwait(false);

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey gt '10'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task EntityCanBeUpserted()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";

            var entity = new TableEntity
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var entityToUpdate = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            entityToUpdate[propertyName] = updatedValue;
            await client.UpsertEntityAsync(entityToUpdate, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task EntityUpdateRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            var entity = new TableEntity
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.UpdateEntityAsync(originalEntity, ETag.All, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.UpdateEntityAsync(updatedEntity, originalEntity.ETag, TableUpdateMode.Replace).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.UpdateEntityAsync(updatedEntity, updatedEntity.ETag, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task EntityMergeRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            const string updatedValue = "This is new and improved!";
            const string updatedValue2 = "This changed due to a matching Etag";
            var entity = new TableEntity
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.UpdateEntityAsync(originalEntity, ETag.All, TableUpdateMode.Merge).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.UpdateEntityAsync(updatedEntity, originalEntity.ETag, TableUpdateMode.Merge).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.UpdateEntityAsync(updatedEntity, updatedEntity.ETag, TableUpdateMode.Merge).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task EntityMergeDoesPartialPropertyUpdates()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string mergepropertyName = "MergedProperty";
            const string originalValue = "This is the original";
            const string mergeValue = "This was merged!";
            const string mergeUpdatedValue = "merged value was updated!";
            var entity = new TableEntity
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };
            var partialEntity = new TableEntity
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {mergepropertyName, mergeValue}
                };

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Verify that the merge property does not yet exist yet and that the original property does exist.

            Assert.That(originalEntity.TryGetValue(mergepropertyName, out var _), Is.False);
            Assert.That(originalEntity[propertyName], Is.EqualTo(originalValue));

            await client.UpsertEntityAsync(partialEntity, TableUpdateMode.Merge).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var mergedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Verify that the merge property does not yet exist yet and that the original property does exist.

            Assert.That(mergedEntity[mergepropertyName], Is.EqualTo(mergeValue));
            Assert.That(mergedEntity[propertyName], Is.EqualTo(originalValue));

            // Update just the merged value.

            partialEntity[mergepropertyName] = mergeUpdatedValue;
            await client.UpsertEntityAsync(partialEntity, TableUpdateMode.Merge).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            mergedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Verify that the merge property does not yet exist yet and that the original property does exist.

            Assert.That(mergedEntity[mergepropertyName], Is.EqualTo(mergeUpdatedValue));
            Assert.That(mergedEntity[propertyName], Is.EqualTo(originalValue));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task EntityDeleteRespectsEtag()
        {
            string tableName = $"testtable{Recording.GenerateId()}";

            const string rowKeyValue = "1";
            const string propertyName = "SomeStringProperty";
            const string originalValue = "This is the original";
            var entity = new TableEntity
                {
                    {"PartitionKey", PartitionKeyValue},
                    {"RowKey", rowKeyValue},
                    {propertyName, originalValue}
                };

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            var staleEtag = originalEntity.ETag;

            // Use a wildcard ETag to delete unconditionally.

            await client.DeleteEntityAsync(PartitionKeyValue, rowKeyValue).ConfigureAwait(false);

            // Validate that the entity is deleted.

            var emptyresult = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");

            // Create the new entity again.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Use a non-matching ETag.

            Assert.That(async () => await client.DeleteEntityAsync(PartitionKeyValue, rowKeyValue, staleEtag).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.DeleteEntityAsync(PartitionKeyValue, rowKeyValue, originalEntity.ETag).ConfigureAwait(false);

            // Validate that the entity is deleted.

            emptyresult = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreatedEntitiesAreRoundtrippedWithProperOdataAnnoations()
        {
            List<TableEntity> entityResults;
            List<TableEntity> entitiesToCreate = CreateTableEntities(PartitionKeyValue, 1);

            // Create the new entities.

            await CreateTestEntities(entitiesToCreate).ConfigureAwait(false);

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.First().PartitionKey, Is.TypeOf<string>(), "The entity property should be of type string");
            Assert.That(entityResults.First().RowKey, Is.TypeOf<string>(), "The entity property should be of type string");
            Assert.That(entityResults.First().Timestamp, Is.TypeOf<DateTimeOffset>(), "The entity property should be of type DateTimeOffset?");
            Assert.That(entityResults.First().Timestamp, Is.Not.Null, "The entity property should not be null");
            Assert.That(entityResults.First()[StringTypePropertyName], Is.TypeOf<string>(), "The entity property should be of type string");
            Assert.That(entityResults.First()[DateTypePropertyName], Is.TypeOf<DateTimeOffset>(), "The entity property should be of type DateTime");
            Assert.That(entityResults.First()[GuidTypePropertyName], Is.TypeOf<Guid>(), "The entity property should be of type Guid");
            Assert.That(entityResults.First()[BinaryTypePropertyName], Is.TypeOf<byte[]>(), "The entity property should be of type byte[]");
            Assert.That(entityResults.First()[Int64TypePropertyName], Is.TypeOf<long>(), "The entity property should be of type int64");
            //TODO: Remove conditional after fixing https://github.com/Azure/azure-sdk-for-net/issues/13552
            if (_endpointType != TableEndpointType.CosmosTable)
            {
                Assert.That(entityResults.First()[DoubleTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            }
            Assert.That(entityResults.First()[DoubleDecimalTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            Assert.That(entityResults.First()[IntTypePropertyName], Is.TypeOf<int>(), "The entity property should be of type int");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task UpsertedEntitiesAreRoundtrippedWithProperOdataAnnoations()
        {
            List<TableEntity> entityResults;
            List<TableEntity> entitiesToCreate = CreateTableEntities(PartitionKeyValue, 1);

            // Upsert the new entities.

            await UpsertTestEntities(entitiesToCreate, TableUpdateMode.Replace).ConfigureAwait(false);

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.First()[StringTypePropertyName], Is.TypeOf<string>(), "The entity property should be of type string");
            Assert.That(entityResults.First()[DateTypePropertyName], Is.TypeOf<DateTimeOffset>(), "The entity property should be of type DateTime");
            Assert.That(entityResults.First()[GuidTypePropertyName], Is.TypeOf<Guid>(), "The entity property should be of type Guid");
            Assert.That(entityResults.First()[BinaryTypePropertyName], Is.TypeOf<byte[]>(), "The entity property should be of type byte[]");
            Assert.That(entityResults.First()[Int64TypePropertyName], Is.TypeOf<long>(), "The entity property should be of type int64");
            //TODO: Remove conditional after fixing https://github.com/Azure/azure-sdk-for-net/issues/13552
            if (_endpointType != TableEndpointType.CosmosTable)
            {
                Assert.That(entityResults.First()[DoubleTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            }
            Assert.That(entityResults.First()[DoubleDecimalTypePropertyName], Is.TypeOf<double>(), "The entity property should be of type double");
            Assert.That(entityResults.First()[IntTypePropertyName], Is.TypeOf<int>(), "The entity property should be of type int");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreateEntityReturnsEntitiesWithoutOdataAnnoations()
        {
            TableEntity entityToCreate = CreateTableEntities(PartitionKeyValue, 1).First();

            // Create an entity.

            await client.AddEntityAsync(entityToCreate).ConfigureAwait(false);
            TableEntity entity = await client.GetEntityAsync<TableEntity>(entityToCreate.PartitionKey, entityToCreate.RowKey).ConfigureAwait(false);

            Assert.That(entity.Keys.Count(k => k.EndsWith(TableConstants.Odata.OdataTypeString)), Is.Zero, "The entity should not containt any odata data annotation properties");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreateEntityAllowsSelect()
        {
            TableEntity entityToCreate = CreateTableEntities(PartitionKeyValue, 1).First();

            // Create an entity.

            await client.AddEntityAsync(entityToCreate).ConfigureAwait(false);
            TableEntity entity = await client.GetEntityAsync<TableEntity>(entityToCreate.PartitionKey, entityToCreate.RowKey, new[] { nameof(entityToCreate.Timestamp) }).ConfigureAwait(false);

            Assert.That(entity.PartitionKey, Is.Null, "The entity property should be null");
            Assert.That(entity.RowKey, Is.Null, "The entity property should be null");
            Assert.That(entity.Timestamp, Is.Not.Null, "The entity property should not be null");
            Assert.That(entity.TryGetValue(StringTypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(DateTypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(GuidTypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(BinaryTypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(Int64TypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(DoubleTypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(DoubleDecimalTypePropertyName, out _), Is.False, "The entity property should not exist");
            Assert.That(entity.TryGetValue(IntTypePropertyName, out _), Is.False, "The entity property should not exist");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task QueryReturnsEntitiesWithoutOdataAnnoations()
        {
            List<TableEntity> entityResults;
            List<TableEntity> entitiesToCreate = CreateTableEntities(PartitionKeyValue, 1);

            // Upsert the new entities.

            await UpsertTestEntities(entitiesToCreate, TableUpdateMode.Replace).ConfigureAwait(false);

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.First().Keys.Count(k => k.EndsWith(TableConstants.Odata.OdataTypeString)), Is.Zero, "The entity should not containt any odata data annotation properties");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        [TestCase(null)]
        [TestCase(5)]
        public async Task CreatedCustomEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            List<TestEntity> entityResults;
            var entitiesToCreate = CreateCustomTableEntities(PartitionKeyValue, 20);

            // Create the new entities.

            await CreateTestEntities(entitiesToCreate).ConfigureAwait(false);

            // Query the entities.

            entityResults = await client.QueryAsync<TestEntity>(maxPerPage: pageCount).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(entitiesToCreate.Count), "The entity result count should match the created count");
            entityResults.Clear();
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreatedCustomEntitiesCanBeQueriedWithFilters()
        {
            List<TestEntity> entityResults;
            var entitiesToCreate = CreateCustomTableEntities(PartitionKeyValue, 20);

            // Create the new entities.

            await CreateTestEntities(entitiesToCreate).ConfigureAwait(false);

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TestEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey gt '10'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(10), "The entity result count should be 10");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
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

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var entityToUpdate = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            entityToUpdate[propertyName] = updatedValue;
            await client.UpsertEntityAsync(entityToUpdate, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
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

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.UpdateEntityAsync(originalEntity, ETag.All, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.UpdateEntityAsync(updatedEntity, originalEntity.ETag, TableUpdateMode.Replace).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.UpdateEntityAsync(updatedEntity, updatedEntity.ETag, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
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

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            originalEntity[propertyName] = updatedValue;

            // Use a wildcard ETag to update unconditionally.

            await client.UpdateEntityAsync(originalEntity, ETag.All, TableUpdateMode.Merge).ConfigureAwait(false);

            // Fetch the updated entity from the service.

            var updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue), $"The property value should be {updatedValue}");

            updatedEntity[propertyName] = updatedValue2;

            // Use a non-matching ETag.

            Assert.That(async () => await client.UpdateEntityAsync(updatedEntity, originalEntity.ETag, TableUpdateMode.Merge).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.UpdateEntityAsync(updatedEntity, updatedEntity.ETag, TableUpdateMode.Merge).ConfigureAwait(false);

            // Fetch the newly updated entity from the service.

            updatedEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            Assert.That(updatedEntity[propertyName], Is.EqualTo(updatedValue2), $"The property value should be {updatedValue2}");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
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

            // Create the new entity.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            var originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();
            var staleEtag = originalEntity.ETag;

            // Use a wildcard ETag to delete unconditionally.

            await client.DeleteEntityAsync(PartitionKeyValue, rowKeyValue).ConfigureAwait(false);

            // Validate that the entity is deleted.

            var emptyresult = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");

            // Create the new entity again.

            await client.UpsertEntityAsync(entity, TableUpdateMode.Replace).ConfigureAwait(false);

            // Fetch the created entity from the service.

            originalEntity = (await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false)).Single();

            // Use a non-matching ETag.

            Assert.That(async () => await client.DeleteEntityAsync(PartitionKeyValue, rowKeyValue, staleEtag).ConfigureAwait(false), Throws.InstanceOf<RequestFailedException>());

            // Use a matching ETag.

            await client.DeleteEntityAsync(PartitionKeyValue, rowKeyValue, originalEntity.ETag).ConfigureAwait(false);

            // Validate that the entity is deleted.

            emptyresult = await client.QueryAsync<TableEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '{rowKeyValue}'").ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(emptyresult, Is.Empty, $"The query should have returned no results.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreatedCustomEntitiesAreRoundtrippedProprly()
        {
            List<TestEntity> entityResults;
            var entitiesToCreate = CreateCustomTableEntities(PartitionKeyValue, 1);

            // Create the new entities.

            foreach (var entity in entitiesToCreate)
            {
                await client.AddEntityAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<TestEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);
            entityResults.Sort((first, second) => first.IntTypeProperty.CompareTo(second.IntTypeProperty));

            for (int i = 0; i < entityResults.Count; i++)
            {
                Assert.That(entityResults[i].BinaryTypeProperty, Is.EqualTo(entitiesToCreate[i].BinaryTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].DatetimeOffsetTypeProperty, Is.EqualTo(entitiesToCreate[i].DatetimeOffsetTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].DatetimeTypeProperty, Is.EqualTo(entitiesToCreate[i].DatetimeTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].DoubleTypeProperty, Is.EqualTo(entitiesToCreate[i].DoubleTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].GuidTypeProperty, Is.EqualTo(entitiesToCreate[i].GuidTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].Int64TypeProperty, Is.EqualTo(entitiesToCreate[i].Int64TypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].IntTypeProperty, Is.EqualTo(entitiesToCreate[i].IntTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].PartitionKey, Is.EqualTo(entitiesToCreate[i].PartitionKey), "The entities should be equivalent");
                Assert.That(entityResults[i].RowKey, Is.EqualTo(entitiesToCreate[i].RowKey), "The entities should be equivalent");
                Assert.That(entityResults[i].StringTypeProperty, Is.EqualTo(entitiesToCreate[i].StringTypeProperty), "The entities should be equivalent");
                Assert.That(entityResults[i].ETag, Is.Not.EqualTo(default(ETag)), $"ETag value should not be default: {entityResults[i].ETag}");
            }
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task CreatedEnumEntitiesAreRoundtrippedProperly()
        {
            List<EnumEntity> entityResults;
            var entitiesToCreate = new[]
            {
                new EnumEntity{ PartitionKey = PartitionKeyValue, RowKey = "01", MyFoo = Foo.Two}
            };

            // Create the new entities.

            foreach (var entity in entitiesToCreate)
            {
                await client.AddEntityAsync(entity).ConfigureAwait(false);
            }

            // Query the entities with a filter specifying that to RowKey value must be greater than or equal to '10'.

            entityResults = await client.QueryAsync<EnumEntity>(filter: $"PartitionKey eq '{PartitionKeyValue}' and RowKey eq '01'").ToEnumerableAsync().ConfigureAwait(false);

            for (int i = 0; i < entityResults.Count; i++)
            {
                Assert.That(entityResults[i].PartitionKey, Is.EqualTo(entitiesToCreate[i].PartitionKey), "The entities should be equivalent");
                Assert.That(entityResults[i].RowKey, Is.EqualTo(entitiesToCreate[i].RowKey), "The entities should be equivalent");
                Assert.That(entityResults[i].MyFoo, Is.EqualTo(entitiesToCreate[i].MyFoo), "The entities should be equivalent");
            }
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [RecordedTest]
        public async Task GetAccessPoliciesReturnsPolicies()
        {
            // Create some policies.

            var policyToCreate = new List<SignedIdentifier>
            {
                new SignedIdentifier("MyPolicy", new TableAccessPolicy(new DateTime(2020, 1,1,1,1,0,DateTimeKind.Utc), new DateTime(2021, 1,1,1,1,0,DateTimeKind.Utc), "r"))
            };

            await client.SetAccessPolicyAsync(tableAcl: policyToCreate);

            // Get the created policy.

            var policies = await client.GetAccessPolicyAsync();

            Assert.That(policies.Value[0].Id, Is.EqualTo(policyToCreate[0].Id));
            Assert.That(policies.Value[0].AccessPolicy.ExpiresOn, Is.EqualTo(policyToCreate[0].AccessPolicy.ExpiresOn));
            Assert.That(policies.Value[0].AccessPolicy.Permission, Is.EqualTo(policyToCreate[0].AccessPolicy.Permission));
            Assert.That(policies.Value[0].AccessPolicy.StartsOn, Is.EqualTo(policyToCreate[0].AccessPolicy.StartsOn));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task GetEntityReturnsSingleEntity()
        {
            TableEntity entityResults;
            List<TableEntity> entitiesToCreate = CreateTableEntities(PartitionKeyValue, 1);

            // Upsert the new entities.

            await UpsertTestEntities(entitiesToCreate, TableUpdateMode.Replace).ConfigureAwait(false);

            // Get the single entity by PartitionKey and RowKey.

            entityResults = (await client.GetEntityAsync<TableEntity>(PartitionKeyValue, "01").ConfigureAwait(false)).Value;

            Assert.That(entityResults, Is.Not.Null, "The entity should not be null.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task BatchInsert()
        {
            var entitiesToCreate = CreateCustomTableEntities(PartitionKeyValue, 5);

            // Create the batch.
            var batch = InstrumentClient(client.CreateTransactionalBatch(entitiesToCreate[0].PartitionKey));

            batch.SetBatchGuids(Recording.Random.NewGuid(), Recording.Random.NewGuid());

            // Add the entities to the batch.
            batch.AddEntities(entitiesToCreate);
            TableBatchResponse response = await batch.SubmitBatchAsync().ConfigureAwait(false);

            foreach (var entity in entitiesToCreate)
            {
                Assert.That(response.GetResponseForEntity(entity.RowKey).Status, Is.EqualTo((int)HttpStatusCode.NoContent));
            }

            Assert.That(response.ResponseCount, Is.EqualTo(entitiesToCreate.Count));

            // Query the entities.

            var entityResults = await client.QueryAsync<TestEntity>().ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(entitiesToCreate.Count), "The entity result count should match the created count");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task BatchInsertAndMergeAndDelete()
        {
            const string updatedString = "the string was updated!";

            var entitiesToCreate = CreateCustomTableEntities(PartitionKeyValue, 5);

            // Add just the first three entities
            await client.AddEntityAsync(entitiesToCreate[0]).ConfigureAwait(false);
            await client.AddEntityAsync(entitiesToCreate[1]).ConfigureAwait(false);
            await client.AddEntityAsync(entitiesToCreate[2]).ConfigureAwait(false);

            // Create the batch.
            TableTransactionalBatch batch = InstrumentClient(client.CreateTransactionalBatch(entitiesToCreate[0].PartitionKey));

            batch.SetBatchGuids(Recording.Random.NewGuid(), Recording.Random.NewGuid());

            // Add a Merge operation to the entity we are adding.
            var updatedEntity = entitiesToCreate[0];
            updatedEntity.StringTypeProperty = updatedString;
            batch.UpdateEntity(updatedEntity, ETag.All, TableUpdateMode.Merge);

            // Add a Delete operation.
            var entityToDelete = entitiesToCreate[1];
            batch.DeleteEntity(entityToDelete.PartitionKey, entityToDelete.RowKey, ETag.All);

            // Add an Upsert operation to replace the entity with an updated value.
            entitiesToCreate[2].StringTypeProperty = updatedString;
            batch.UpsertEntity(entitiesToCreate[2], TableUpdateMode.Replace);

            // Add an Upsert operation to add an entity.
            batch.UpsertEntity(entitiesToCreate[3], TableUpdateMode.Replace);

            // Add the last entity.
            batch.AddEntity(entitiesToCreate.Last());

            // Submit the batch.
            TableBatchResponse response = await batch.SubmitBatchAsync().ConfigureAwait(false);

            // Validate that the batch throws if we try to send it again.
            Assert.ThrowsAsync<InvalidOperationException>(() => batch.SubmitBatchAsync());

            // Validate that adding more operations to the batch throws.
            Assert.Throws<InvalidOperationException>(() => batch.AddEntity(new TableEntity()));

            foreach (var entity in entitiesToCreate)
            {
                Assert.That(response.GetResponseForEntity(entity.RowKey).Status, Is.EqualTo((int)HttpStatusCode.NoContent));
            }

            Assert.That(response.ResponseCount, Is.EqualTo(entitiesToCreate.Count));

            // Query the entities.

            var entityResults = await client.QueryAsync<TestEntity>().ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(entityResults.Count, Is.EqualTo(entitiesToCreate.Count - 1), "The entity result count should match the created count minus the deleted count.");
            Assert.That(entityResults.Single(e => e.RowKey == entitiesToCreate[0].RowKey).StringTypeProperty, Is.EqualTo(updatedString), "The entity result property should have been updated.");
            Assert.That(entityResults.Single(e => e.RowKey == entitiesToCreate[2].RowKey).StringTypeProperty, Is.EqualTo(updatedString), "The entity result property should have been updated.");
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [RecordedTest]
        public async Task BatchError()
        {
            var entitiesToCreate = CreateCustomTableEntities(PartitionKeyValue, 4);

            // Create the batch.
            var batch = InstrumentClient(client.CreateTransactionalBatch(entitiesToCreate[0].PartitionKey));

            batch.SetBatchGuids(Recording.Random.NewGuid(), Recording.Random.NewGuid());

            // Add the last entity to the table prior to adding it as part of the batch to cause a batch failure.
            await client.AddEntityAsync(entitiesToCreate.Last());

            // Add the entities to the batch
            batch.AddEntities(entitiesToCreate);

            try
            {
                TableBatchResponse response = await batch.SubmitBatchAsync().ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Status == (int)HttpStatusCode.Conflict, $"Status should be {HttpStatusCode.Conflict}");
                Assert.That(ex.Message, Is.Not.Null, "Message should not be null");
                Assert.That(batch.TryGetFailedEntityFromException(ex, out ITableEntity failedEntity), Is.True);
                Assert.That(failedEntity.RowKey, Is.EqualTo(entitiesToCreate.Last().RowKey));
                Assert.That(ex.Message.Contains(nameof(TableTransactionalBatch.TryGetFailedEntityFromException)));
            }
        }
    }
}
