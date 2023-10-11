// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoDataConnectionTests : KustoManagementTestBase
    {
        public KustoDataConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task IotHubDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();

            var iotHubDataConnectionName = GenerateAssetName("sdkIotHubDataConnection");

            var iotHubDataConnectionDataCreate = new KustoIotHubDataConnection
            {
                ConsumerGroup = "$Default",
                IotHubResourceId = TE.IotHubId,
                Location = Location,
                SharedAccessPolicyName = "registryRead"
            };

            var iotHubDataConnectionDataUpdate = new KustoIotHubDataConnection
            {
                ConsumerGroup = "$Default",
                DatabaseRouting = KustoDatabaseRouting.Multi,
                DataFormat = KustoIotHubDataFormat.Csv,
                IotHubResourceId = TE.IotHubId,
                Location = Location,
                SharedAccessPolicyName = "registryRead",
                TableName = TE.TableName
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateIotHubDataConnectionAsync(
                string iotHubDataConnectionName, KustoIotHubDataConnection iotHubDataConnectionData
            ) => dataConnectionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, iotHubDataConnectionName, iotHubDataConnectionData
            );

            await CollectionTests(
                iotHubDataConnectionName,
                GetFullDatabaseChildResourceName(iotHubDataConnectionName),
                iotHubDataConnectionDataCreate,
                iotHubDataConnectionDataUpdate,
                CreateOrUpdateIotHubDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateIotHubDataConnection
            );

            await DeletionTest(
                iotHubDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
        }

        [TestCase]
        [RecordedTest]
        public async Task EventHubDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();

            var eventHubDataConnectionName = GenerateAssetName("sdkEventHubDataConnection");

            var eventHubDataConnectionDataCreate = new KustoEventHubDataConnection
            {
                ConsumerGroup = "$Default", EventHubResourceId = TE.EventHubId, Location = Location,
            };

            var eventHubDataConnectionDataUpdate = new KustoEventHubDataConnection
            {
                ConsumerGroup = "$Default",
                DatabaseRouting = KustoDatabaseRouting.Multi,
                DataFormat = KustoEventHubDataFormat.Csv,
                EventHubResourceId = TE.EventHubId,
                Location = Location,
                ManagedIdentityResourceId = TE.UserAssignedIdentityId,
                TableName = TE.TableName
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateEventHubDataConnectionAsync(
                string eventHubDataConnectionName, KustoEventHubDataConnection eventHubDataConnectionData
            ) => dataConnectionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, eventHubDataConnectionName, eventHubDataConnectionData
            );

            await CollectionTests(
                eventHubDataConnectionName,
                GetFullDatabaseChildResourceName(eventHubDataConnectionName),
                eventHubDataConnectionDataCreate,
                eventHubDataConnectionDataUpdate,
                CreateOrUpdateEventHubDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateEventHubDataConnection
            );

            await DeletionTest(
                eventHubDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
        }

        [TestCase]
        [RecordedTest]
        public async Task EventGridDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();

            var eventGridDataConnectionName = GenerateAssetName("sdkEventGridDataConnection");

            var eventGridDataConnectionDataCreate = new KustoEventGridDataConnection()
            {
                ConsumerGroup = "$Default",
                EventHubResourceId = TE.EventHubId,
                Location = Location,
                StorageAccountResourceId = TE.StorageAccountId
            };

            var eventGridDataConnectionDataUpdate = new KustoEventGridDataConnection()
            {
                ConsumerGroup = "$Default",
                DatabaseRouting = KustoDatabaseRouting.Multi,
                DataFormat = KustoEventGridDataFormat.Csv,
                EventHubResourceId = TE.EventHubId,
                Location = Location,
                ManagedIdentityResourceId = TE.UserAssignedIdentityId,
                StorageAccountResourceId = TE.StorageAccountId,
                TableName = TE.TableName
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateEventGridDataConnectionAsync(
                string eventGridDataConnectionName, KustoEventGridDataConnection eventGridDataConnectionData
            ) => dataConnectionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, eventGridDataConnectionName, eventGridDataConnectionData
            );

            await CollectionTests(
                eventGridDataConnectionName,
                GetFullDatabaseChildResourceName(eventGridDataConnectionName),
                eventGridDataConnectionDataCreate,
                eventGridDataConnectionDataUpdate,
                CreateOrUpdateEventGridDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateEventGridDataConnection
            );

            await DeletionTest(
                eventGridDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
        }

        [TestCase]
        [RecordedTest]
        public async Task CosmosDbDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();

            var cosmosDbDataConnectionName = GenerateAssetName("sdkCosmosDbDataConnection");

            var cosmosDbDataConnectionDataCreate = new KustoCosmosDBDataConnection()
            {
                CosmosDBAccountResourceId = TE.CosmosDbAccountId,
                CosmosDBDatabase = TE.CosmosDbDatabaseName,
                CosmosDBContainer = TE.CosmosDbContainerName,
                Location = Location,
                ManagedIdentityResourceId = TE.UserAssignedIdentityId,
                TableName = TE.TableName
            };

            var cosmosDbDataConnectionDataUpdate = new KustoCosmosDBDataConnection()
            {
                CosmosDBAccountResourceId = TE.CosmosDbAccountId,
                CosmosDBDatabase = TE.CosmosDbDatabaseName,
                CosmosDBContainer = TE.CosmosDbContainerName,
                Location = Location,
                ManagedIdentityResourceId = TE.UserAssignedIdentityId,
                TableName = TE.TableName,
                RetrievalStartOn = DateTimeOffset.MinValue
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateCosmosDbDataConnectionAsync(
                string cosmosDbDataConnectionName, KustoCosmosDBDataConnection cosmosDbDataConnectionData
            ) => dataConnectionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, cosmosDbDataConnectionName, cosmosDbDataConnectionData
            );

            await CollectionTests(
                cosmosDbDataConnectionName,
                GetFullDatabaseChildResourceName(cosmosDbDataConnectionName),
                cosmosDbDataConnectionDataCreate,
                cosmosDbDataConnectionDataUpdate,
                CreateOrUpdateCosmosDbDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateCosmosDbDataConnection
            );

            await DeletionTest(
                cosmosDbDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
        }

        private static void ValidateIotHubDataConnection(
            string iotHubDataConnectionName,
            KustoIotHubDataConnection expectedIotHubDataConnectionData,
            KustoIotHubDataConnection actualIotHubDataConnectionData)
        {
            AssertEquality(
                expectedIotHubDataConnectionData.ConsumerGroup, actualIotHubDataConnectionData.ConsumerGroup
            );
            AssertEquality(
                expectedIotHubDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                actualIotHubDataConnectionData.DatabaseRouting
            );
            AssertEquality(expectedIotHubDataConnectionData.DataFormat, actualIotHubDataConnectionData.DataFormat);
            AssertEquality(
                expectedIotHubDataConnectionData.IotHubResourceId, actualIotHubDataConnectionData.IotHubResourceId
            );
            AssertEquality(expectedIotHubDataConnectionData.Location, actualIotHubDataConnectionData.Location);
            AssertEquality(iotHubDataConnectionName, actualIotHubDataConnectionData.Name);
            AssertEquality(expectedIotHubDataConnectionData.TableName, actualIotHubDataConnectionData.TableName);
        }

        private static void ValidateEventHubDataConnection(
            string eventHubDataConnectionName,
            KustoEventHubDataConnection expectedEventHubDataConnectionData,
            KustoEventHubDataConnection actualEventHubDataConnectionData)
        {
            AssertEquality(
                expectedEventHubDataConnectionData.ConsumerGroup, actualEventHubDataConnectionData.ConsumerGroup
            );
            AssertEquality(
                expectedEventHubDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                actualEventHubDataConnectionData.DatabaseRouting
            );
            AssertEquality(expectedEventHubDataConnectionData.DataFormat, actualEventHubDataConnectionData.DataFormat);
            AssertEquality(
                expectedEventHubDataConnectionData.EventHubResourceId,
                actualEventHubDataConnectionData.EventHubResourceId
            );
            AssertEquality(expectedEventHubDataConnectionData.Location, actualEventHubDataConnectionData.Location);
            AssertEquality(
                expectedEventHubDataConnectionData.ManagedIdentityResourceId,
                actualEventHubDataConnectionData.ManagedIdentityResourceId
            );
            AssertEquality(eventHubDataConnectionName, actualEventHubDataConnectionData.Name);
            AssertEquality(expectedEventHubDataConnectionData.TableName, actualEventHubDataConnectionData.TableName);
        }

        private static void ValidateEventGridDataConnection(
            string eventGridDataConnectionName,
            KustoEventGridDataConnection expectedEventGridDataConnectionData,
            KustoEventGridDataConnection actualEventGridDataConnectionData)
        {
            AssertEquality(
                expectedEventGridDataConnectionData.ConsumerGroup, actualEventGridDataConnectionData.ConsumerGroup
            );
            AssertEquality(
                expectedEventGridDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                actualEventGridDataConnectionData.DatabaseRouting
            );
            AssertEquality(expectedEventGridDataConnectionData.DataFormat,
                actualEventGridDataConnectionData.DataFormat);
            AssertEquality(
                expectedEventGridDataConnectionData.EventHubResourceId,
                actualEventGridDataConnectionData.EventHubResourceId
            );
            AssertEquality(expectedEventGridDataConnectionData.Location, actualEventGridDataConnectionData.Location);
            AssertEquality(
                expectedEventGridDataConnectionData.ManagedIdentityResourceId,
                actualEventGridDataConnectionData.ManagedIdentityResourceId
            );
            AssertEquality(eventGridDataConnectionName, actualEventGridDataConnectionData.Name);
            AssertEquality(
                expectedEventGridDataConnectionData.StorageAccountResourceId,
                actualEventGridDataConnectionData.StorageAccountResourceId
            );
            AssertEquality(expectedEventGridDataConnectionData.TableName, actualEventGridDataConnectionData.TableName);
        }
        private static void ValidateCosmosDbDataConnection(
            string cosmosDbDataConnectionName,
            KustoCosmosDBDataConnection expectedCosmosDbDataConnectionData,
            KustoCosmosDBDataConnection actualCosmosDbDataConnectionData)
        {
            AssertEquality(expectedCosmosDbDataConnectionData.TableName, actualCosmosDbDataConnectionData.TableName);
            AssertEquality(expectedCosmosDbDataConnectionData.MappingRuleName, actualCosmosDbDataConnectionData.MappingRuleName);
            AssertEquality(expectedCosmosDbDataConnectionData.ManagedIdentityResourceId, actualCosmosDbDataConnectionData.ManagedIdentityResourceId);
            AssertEquality(expectedCosmosDbDataConnectionData.CosmosDBAccountResourceId, actualCosmosDbDataConnectionData.CosmosDBAccountResourceId);
            AssertEquality(expectedCosmosDbDataConnectionData.CosmosDBDatabase, actualCosmosDbDataConnectionData.CosmosDBDatabase);
            AssertEquality(expectedCosmosDbDataConnectionData.CosmosDBContainer, actualCosmosDbDataConnectionData.CosmosDBContainer);
            Assert.IsTrue(actualCosmosDbDataConnectionData.ManagedIdentityObjectId.HasValue);
            Assert.NotNull(actualCosmosDbDataConnectionData.RetrievalStartOn);
        }
    }
}
