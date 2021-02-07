// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
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
                InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    CosmosDBTestUtilities.Location,
                    this.resourceGroupName);
                await PrepareDatabaseAccount();
                setupRun = true;
            }
            else if (setupRun)
            {
                initNewRecord();
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
            MongoDBDatabaseGetResults mongoDBDatabaseGetResults1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBDatabaseAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new MongoDBDatabaseCreateUpdateParameters(
                        new MongoDBDatabaseResource(databaseAccountName), new CreateUpdateOptions(sampleThroughput1, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBDatabaseGetResults1);
            Assert.AreEqual(databaseName, mongoDBDatabaseGetResults1.Resource.Id);
            ThroughputSettingsGetResults throughputSettingsGetResults1 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(throughputSettingsGetResults1);
            Assert.AreEqual(sampleThroughput1, throughputSettingsGetResults1.Resource.Throughput);
            Assert.AreEqual(mongoDBDatabasesThroughputType, throughputSettingsGetResults1.Type);
            MongoDBDatabaseGetResults mongoDBDatabaseGetResults =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(mongoDBDatabaseGetResults);
            VerifyMongoDBDatases(mongoDBDatabaseGetResults1, mongoDBDatabaseGetResults);

            MongoDBDatabaseGetResults mongoDBDatabaseGetResults2 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBDatabaseAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new MongoDBDatabaseCreateUpdateParameters(
                        new MongoDBDatabaseResource(databaseAccountName), new CreateUpdateOptions(sampleThroughput2, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBDatabaseGetResults2);
            Assert.AreEqual(databaseName, mongoDBDatabaseGetResults2.Resource.Id);
            ThroughputSettingsGetResults throughputSettingsGetResults2 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(throughputSettingsGetResults2);
            Assert.AreEqual(sampleThroughput2, throughputSettingsGetResults2.Resource.Throughput);
            Assert.AreEqual(mongoDBDatabasesThroughputType, throughputSettingsGetResults2.Type);
            mongoDBDatabaseGetResults = await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(mongoDBDatabaseGetResults);
            VerifyMongoDBDatases(mongoDBDatabaseGetResults2, mongoDBDatabaseGetResults);
        }

        [TestCase, Order(2)]
        public async Task MongoDBDatabaseListTest()
        {
            List<MongoDBDatabaseGetResults> mongoDBDatabases =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBDatabases);
            Assert.AreEqual(1, mongoDBDatabases.Count);
            MongoDBDatabaseGetResults mongoDBDatabaseGetResults =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.IsNotNull(mongoDBDatabaseGetResults);
            VerifyMongoDBDatases(mongoDBDatabaseGetResults, mongoDBDatabases[0]);
        }

        [TestCase, Order(2)]
        public async Task MongoDBDatabaseUpdateThroughputTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = (await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartUpdateMongoDBDatabaseThroughputAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(sampleThroughput1, null, null, null))))).Value;
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.AreEqual(sampleThroughput1, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task MongoDBDatabaseMigrateToAutoscaleTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBDatabaseToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task MongoDBDatabaseMigrateToManualThroughputTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBDatabaseToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task MongoDBCollectionCreateAndUpdateTest()
        {
            MongoDBCollectionGetResults mongoDBCollectionGetResults1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBCollectionAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    new MongoDBCollectionCreateUpdateParameters(
                        new MongoDBCollectionResource(collectionName), new CreateUpdateOptions(sampleThroughput1, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBCollectionGetResults1);
            Assert.AreEqual(collectionName, mongoDBCollectionGetResults1.Resource.Id);
            ThroughputSettingsGetResults throughputSettingsGetResults1 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionThroughputAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(throughputSettingsGetResults1);
            Assert.AreEqual(sampleThroughput1, throughputSettingsGetResults1.Resource.Throughput);
            Assert.AreEqual(mongoDBCollectionsThroughputType, throughputSettingsGetResults1.Type);

            MongoDBCollectionGetResults mongoDBCollectionGetResults =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(mongoDBCollectionGetResults);
            VerifyMongoDBCollections(mongoDBCollectionGetResults1, mongoDBCollectionGetResults);

            MongoDBCollectionGetResults mongoDBCollectionGetResults2 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartCreateUpdateMongoDBCollectionAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    collectionName,
                    new MongoDBCollectionCreateUpdateParameters(
                        new MongoDBCollectionResource(collectionName), new CreateUpdateOptions(sampleThroughput2, new AutoscaleSettings()))));
            Assert.IsNotNull(mongoDBCollectionGetResults2);
            Assert.AreEqual(collectionName, mongoDBCollectionGetResults2.Resource.Id);
            ThroughputSettingsGetResults throughputSettingsGetResults2 =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionThroughputAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(throughputSettingsGetResults2);
            Assert.AreEqual(sampleThroughput2, throughputSettingsGetResults2.Resource.Throughput);
            Assert.AreEqual(mongoDBCollectionsThroughputType, throughputSettingsGetResults2.Type);

            mongoDBCollectionGetResults =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(mongoDBCollectionGetResults);
            VerifyMongoDBCollections(mongoDBCollectionGetResults2, mongoDBCollectionGetResults);
        }

        [TestCase, Order(6)]
        public async Task MongoDBCollectionListTest()
        {
            List<MongoDBCollectionGetResults> mongoDBCollections =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBCollectionsAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBCollections);
            Assert.AreEqual(1, mongoDBCollections.Count);
            MongoDBCollectionGetResults mongoDBCollectionGetResults =
                await CosmosDBManagementClient.MongoDBResources.GetMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName);
            Assert.IsNotNull(mongoDBCollectionGetResults);
            VerifyMongoDBCollections(mongoDBCollectionGetResults, mongoDBCollections[0]);
        }

        [TestCase, Order(6)]
        public async Task MongoDBCollectionUpdateThroughputTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = (
                await WaitForCompletionAsync(
                    await CosmosDBManagementClient.MongoDBResources.StartUpdateMongoDBCollectionThroughputAsync(
                        resourceGroupName,
                        databaseAccountName,
                        databaseName,
                        collectionName,
                        new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(sampleThroughput1, null, null, null))))).Value;
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.AreEqual(sampleThroughput1, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(7)]
        public async Task MongoDBCollectionMigrateToAutoscaleTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBCollectionToAutoscaleAsync(
                    resourceGroupName, databaseAccountName, databaseName, collectionName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(8)]
        public async Task MongoDBCollectionMigrateToManualThroughputTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartMigrateMongoDBCollectionToManualThroughputAsync(
                    resourceGroupName, databaseAccountName, databaseName, collectionName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(9)]
        public async Task MongoDBCollectionDeleteTest()
        {
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartDeleteMongoDBCollectionAsync(resourceGroupName, databaseAccountName, databaseName, collectionName));
            List<MongoDBCollectionGetResults> mongoDBCollections =
                await CosmosDBManagementClient.MongoDBResources.ListMongoDBCollectionsAsync(resourceGroupName, databaseAccountName, collectionName).ToEnumerableAsync();
            Assert.IsNotNull(mongoDBCollections);
            Assert.AreEqual(0, mongoDBCollections.Count);
        }

        [TestCase, Order(10)]
        public async Task MongoDBDatabaseDeleteTest()
        {
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.MongoDBResources.StartDeleteMongoDBDatabaseAsync(resourceGroupName, databaseAccountName, databaseName));
            List<MongoDBDatabaseGetResults> mongoDBDatabases =
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

        private void VerifyMongoDBDatases(MongoDBDatabaseGetResults expectedValue, MongoDBDatabaseGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }

        private void VerifyMongoDBCollections(MongoDBCollectionGetResults expectedValue, MongoDBCollectionGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }
    }
}
