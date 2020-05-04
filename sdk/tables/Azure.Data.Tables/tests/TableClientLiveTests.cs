// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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
            // Build a shared access signature with only Read permissions.

            TableSasBuilder sas = new TableSasBuilder(tableName)
            {
                ExpiresOn = new DateTime(2040, 1, 1, 1, 1, 0, DateTimeKind.Utc)
            };
            sas.SetPermissions(TableSasPermissions.Read);

            // Create a SharedKeyCredential that we can use to sign the SAS token
            var credential = new TablesSharedKeyCredential(TestEnvironment.AccountName, TestEnvironment.PrimaryStorageAccountKey);

            // Build a SAS URI
            UriBuilder sasUri = new UriBuilder(TestEnvironment.StorageUri)
            {
                Query = sas.ToSasQueryParameters(credential).ToString()
            };

            // Create the TableServiceClient using the SAS URI.

            var sasAuthedService = InstrumentClient(new TableServiceClient(sasUri.Uri, Recording.InstrumentClientOptions(new TableClientOptions())));
            var sasTableclient = InstrumentClient(sasAuthedService.GetTableClient(tableName));

            // Validate that we are able to query the table from the service.

            Assert.That(async () => await sasTableclient.QueryAsync().ToEnumerableAsync().ConfigureAwait(false), Throws.Nothing);

            // Validate that we are not able to upsert an entity to the table.

            Assert.That(async () => await sasTableclient.UpsertAsync(CreateTableEntities("partition", 1).First()), Throws.InstanceOf<RequestFailedException>().And.Property("Status").EqualTo((int)HttpStatusCode.Forbidden));
        }

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task InsertedEntitiesCanBeQueriedWithAndWithoutPagination(int? pageCount)
        {
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();
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

        /// <summary>
        /// Validates the functionality of the TableClient.
        /// </summary>
        [Test]
        public async Task InsertedEntitiesCanBeQueriedWithFilters()
        {
            List<IDictionary<string, object>> entityResults = new List<IDictionary<string, object>>();
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
    }
}
