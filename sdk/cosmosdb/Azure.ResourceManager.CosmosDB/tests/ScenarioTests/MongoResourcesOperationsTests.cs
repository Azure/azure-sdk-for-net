// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class MongoResourcesOperationsTests : CosmosDBManagementClientBase
    {
        private string resourceGroupName;
        private const string databaseAccountName = "db4932";
        private const string databaseName = "mongodb3668";
        private const string capability = "EnableMongo";
        private const string collectionName = "collectionName3668";
        private const string mongoDBDatabasesThroughputType = "Microsoft.DocumentDB/databaseAccounts/mongodbDatabases/throughputSettings";
        private const string mongoDBCollectionsThroughputType = "Microsoft.DocumentDB/databaseAccounts/mongodbDatabases/collections/throughputSettings";
        private const string location = "WEST US";
        private const int defaultThroughput = 400;
        private const int defaultMaxThroughput = 4000;
        private const int sampleThroughput1 = 700;
        private const int sampleThroughput2 = 1000;
        private bool setupRun = false;
        public MongoResourcesOperationsTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
            {
                await InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    CosmosDBTestUtilities.Location,
                    this.resourceGroupName);
                await PrepareDatabaseAccount();
                setupRun = true;
            }
            else if (setupRun)
            {
                await initNewRecord();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task MongoDBDatabaseCreateAndUpdateTest()
        {
            MongoDBDatabaseResource mongoDBDatabase1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBDatabaseAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new MongoDBDatabaseCreateUpdateParameters(
                        new MongoDBDatabaseResource(databaseName), new CosmosDBCreateUpdateConfig(sampleThroughput1, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBDatabase1);
            Assert.AreEqual(databaseName, mongoDBDatabase1.Resource.Id);
            ThroughputSettingsData throughputSettings1 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(throughputSettings1);
            Assert.AreEqual(sampleThroughput1, throughputSettings1.Resource.Throughput);
            Assert.AreEqual(mongoDBDatabasesThroughputType, throughputSettings1.Type);
            MongoDBDatabaseResource mongoDBDatabase =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(mongoDBDatabase);
            VerifyMongoDBDatases(mongoDBDatabase1, mongoDBDatabase);

            MongoDBDatabaseResource mongoDBDatabase2 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBDatabaseAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new MongoDBDatabaseCreateUpdateParameters(
                        new MongoDBDatabaseResource(databaseName), new CosmosDBCreateUpdateConfig(sampleThroughput2, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBDatabase2);
            Assert.AreEqual(databaseName, mongoDBDatabase2.Resource.Id);
            ThroughputSettingsData throughputSettings2 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(throughputSettings2);
            Assert.AreEqual(sampleThroughput2, throughputSettings2.Resource.Throughput);
            Assert.AreEqual(mongoDBDatabasesThroughputType, throughputSettings2.Type);
            mongoDBDatabase = await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(mongoDBDatabase);
            VerifyMongoDBDatases(mongoDBDatabase2, mongoDBDatabase);
        }

        [TestCase, Order(2)]
        public async Task MongoDBDatabaseListTest()
        {
            List<MongoDBDatabaseResource> mongoDBDatabases =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBDatabases);
            Assert.AreEqual(1, mongoDBDatabases.Count);
            MongoDBDatabaseResource mongoDBDatabase =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(mongoDBDatabase);
            VerifyMongoDBDatases(mongoDBDatabase, mongoDBDatabases[0]);
        }

        [TestCase, Order(2)]
        public async Task MongoDBDatabaseUpdateThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = (await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartUpdateMongoDBDatabaseThroughputAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(sampleThroughput1, null, null, null))))).Value;
            Assert.IsNotNull(throughputSettings);
            Assert.AreEqual(sampleThroughput1, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task MongoDBDatabaseMigrateToAutoscaleTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBDatabaseToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task MongoDBDatabaseMigrateToManualThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBDatabaseToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task MongoDBCollectionCreateAndUpdateTest()
        {
            MongoDBCollectionResource mongoDBCollection1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBCollectionAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    new MongoDBCollectionCreateUpdateParameters(
                        new MongoDBCollectionResource(collectionName), new CosmosDBCreateUpdateConfig(sampleThroughput1, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBCollection1);
            Assert.AreEqual(collectionName, mongoDBCollection1.Resource.Id);
            ThroughputSettingsData throughputSettings1 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionThroughputAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(throughputSettings1);
            Assert.AreEqual(sampleThroughput1, throughputSettings1.Resource.Throughput);
            Assert.AreEqual(mongoDBCollectionsThroughputType, throughputSettings1.Type);

            MongoDBCollectionResource mongoDBCollection =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(mongoDBCollection);
            VerifyMongoDBCollections(mongoDBCollection1, mongoDBCollection);

            MongoDBCollectionResource mongoDBCollection2 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBCollectionAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    new MongoDBCollectionCreateUpdateParameters(
                        new MongoDBCollectionResource(collectionName), new CosmosDBCreateUpdateConfig(sampleThroughput2, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBCollection2);
            Assert.AreEqual(collectionName, mongoDBCollection2.Resource.Id);
            ThroughputSettingsData throughputSettings2 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionThroughputAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(throughputSettings2);
            Assert.AreEqual(sampleThroughput2, throughputSettings2.Resource.Throughput);
            Assert.AreEqual(mongoDBCollectionsThroughputType, throughputSettings2.Type);

            mongoDBCollection =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(mongoDBCollection);
            VerifyMongoDBCollections(mongoDBCollection2, mongoDBCollection);
        }

        [TestCase, Order(6)]
        public async Task MongoDBCollectionListTest()
        {
            List<MongoDBCollectionResource> mongoDBCollections =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBCollectionsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBCollections);
            Assert.AreEqual(1, mongoDBCollections.Count);
            MongoDBCollectionResource mongoDBCollection =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(mongoDBCollection);
            VerifyMongoDBCollections(mongoDBCollection, mongoDBCollections[0]);
        }

        [TestCase, Order(6)]
        public async Task MongoDBCollectionUpdateThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = (
                await WaitForCompletionAsync(
                    await CosmosDBManagementClient.MongoDBResources.StartUpdateMongoDBCollectionThroughputAsync(
                        resourceGroupName,
                        databaseAccountName,
                        databaseName,
                        collectionName,
                        new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(sampleThroughput1, null, null, null))))).Value;
            Assert.IsNotNull(throughputSettings);
            Assert.AreEqual(sampleThroughput1, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(7)]
        public async Task MongoDBCollectionMigrateToAutoscaleTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBCollectionToAutoscaleAsync(
                    resourceGroupName, databaseAccountName, databaseName, collectionName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(8)]
        public async Task MongoDBCollectionMigrateToManualThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBCollectionToManualThroughputAsync(
                    resourceGroupName, databaseAccountName, databaseName, collectionName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(9)]
        public async Task MongoDBCollectionDeleteTest()
        {
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartDeleteMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName));
            List<MongoDBCollectionResource> mongoDBCollections =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBCollectionsAsync(resourceGroupName, databaseAccountName, collectionName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBCollections);
            Assert.AreEqual(0, mongoDBCollections.Count);
        }

        [TestCase, Order(10)]
        public async Task MongoDBDatabaseDeleteTest()
        {
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartDeleteMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName));
            List<MongoDBDatabaseResource> mongoDBDatabases =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBDatabases);
            Assert.AreEqual(0, mongoDBDatabases.Count);
        }

        private async Task PrepareDatabaseAccount()
        {
            List<Location> locationList = new List<Location>();
            locationList.Add(new Location(id: null, locationName: location, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: null));
            var databaseAccountsCreateOrUpdateParameters = new DatabaseAccountCreateUpdateParameters(locationList);
            databaseAccountsCreateOrUpdateParameters.Kind = DatabaseAccountKind.MongoDB;
            databaseAccountsCreateOrUpdateParameters.Location = location;
            databaseAccountsCreateOrUpdateParameters.Capabilities.Add(new Capability(capability));
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountsCreateOrUpdateParameters));
            var response = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(true, response.Value);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        private void VerifyMongoDBDatases(MongoDBDatabaseResource expectedValue, MongoDBDatabaseResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
        }

        private void VerifyMongoDBCollections(MongoDBCollectionResource expectedValue, MongoDBCollectionResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
        }
    }
}
#endif
