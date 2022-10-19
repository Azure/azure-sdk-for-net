// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoDataConnectionTests : KustoManagementTestBase
    {
        private const string ConnectionsResourceGroupName = "test-clients-rg";

        private KustoDataConnectionCollection _dataConnectionCollection;

        public KustoDataConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task DataConnectionSetup()
        {
            var cluster = await GetCluster(ResourceGroup);
            var database = await GetDatabase(cluster);
            _dataConnectionCollection = database.GetKustoDataConnections();
        }

        [TestCase]
        [RecordedTest]
        public async Task EventHubDataConnectionTests()
        {
            string eventHubDataConnectionName = Recording.GenerateAssetName("sdkTestEventHubDataConnection");

            ResourceIdentifier eventHubResourceId = new(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.EventHub/namespaces/testclientsns22/eventhubs/testclientseh");
            KustoEventHubDataConnection eventHubDataConnectionDataCreate = new()
            {
                Location = Location,
                EventHubResourceId = new ResourceIdentifier(eventHubResourceId),
                ConsumerGroup = "$Default"
            };
            KustoEventHubDataConnection eventHubDataConnectionDataUpdate = new()
            {
                Location = Location,
                EventHubResourceId = new ResourceIdentifier(eventHubResourceId),
                ConsumerGroup = "$Default",
                DataFormat = KustoEventHubDataFormat.Csv,
                DatabaseRouting = KustoDatabaseRouting.Multi,
                ManagedIdentityResourceId = Cluster.Id
            };

            await CollectionTests(
                eventHubDataConnectionName, $"{ClusterName}/{DatabaseName}/{eventHubDataConnectionName}",
                eventHubDataConnectionDataCreate, eventHubDataConnectionDataUpdate,
                (eventHubDataConnectionName, eventHubDataConnectionData) =>
                    _dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubDataConnectionName,
                        eventHubDataConnectionData),
                _dataConnectionCollection.GetAsync,
                _dataConnectionCollection.GetAllAsync,
                _dataConnectionCollection.ExistsAsync,
                ValidateEventHubDataConnection
            );

            KustoDataConnectionResource eventHubDataConnection =
                (await _dataConnectionCollection.GetAsync(eventHubDataConnectionName)).Value;
            await DeleteDataConnectionTest(eventHubDataConnection);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotHubDataConnectionTests()
        {
            string iotHubDataConnectionName = Recording.GenerateAssetName("sdkTestIotHubDataConnection");

            ResourceIdentifier iotHubResourceId = new(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.Devices/IotHubs/test-clients-iot");
            KustoIotHubDataConnection iotHubDataConnectionDataCreate = new()
            {
                Location = Location,
                IotHubResourceId = iotHubResourceId,
                SharedAccessPolicyName = "registryRead",
                ConsumerGroup = "$Default"
            };
            KustoIotHubDataConnection iotHubDataConnectionDataUpdate = new()
            {
                Location = Location,
                IotHubResourceId = iotHubResourceId,
                SharedAccessPolicyName = "registryRead",
                ConsumerGroup = "$Default",
                DataFormat = KustoIotHubDataFormat.Csv,
                DatabaseRouting = KustoDatabaseRouting.Multi
            };

            await CollectionTests(
                iotHubDataConnectionName, $"{ClusterName}/{DatabaseName}/{iotHubDataConnectionName}",
                iotHubDataConnectionDataCreate, iotHubDataConnectionDataUpdate,
                (iotHubDataConnectionName, iotHubDataConnectionData) =>
                    _dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, iotHubDataConnectionName,
                        iotHubDataConnectionData),
                _dataConnectionCollection.GetAsync,
                _dataConnectionCollection.GetAllAsync,
                _dataConnectionCollection.ExistsAsync,
                ValidateIotHubDataConnection
            );

            KustoDataConnectionResource iotHubDataConnection =
                (await _dataConnectionCollection.GetAsync(iotHubDataConnectionName)).Value;
            await DeleteDataConnectionTest(iotHubDataConnection);
        }

        [TestCase]
        [RecordedTest]
        public async Task EventGridDataConnectionTests()
        {
            string eventGridDataConnectionName = Recording.GenerateAssetName("sdkTestEventGridDataConnection");

            ResourceIdentifier storageAccountResourceId = new(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.Storage/storageAccounts/testclients");
            ResourceIdentifier eventHubResourceId = new(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.EventHub/namespaces/testclientsns22/eventhubs/testclientseh");
            ResourceIdentifier clusterResourceId = new(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.Kusto/Clusters/eventgridclienttest");
            KustoEventGridDataConnection eventGridDataConnectionDataCreate = new KustoEventGridDataConnection
            {
                Location = Location,
                StorageAccountResourceId = storageAccountResourceId,
                EventHubResourceId = eventHubResourceId,
                ConsumerGroup = "$Default",
                TableName = "MyTest"
            };
            KustoEventGridDataConnection eventGridDataConnectionDataUpdate = new KustoEventGridDataConnection
            {
                Location = Location,
                StorageAccountResourceId = storageAccountResourceId,
                EventHubResourceId = eventHubResourceId,
                ConsumerGroup = "$Default",
                TableName = "MyTest",
                DataFormat = KustoEventGridDataFormat.Csv,
                DatabaseRouting = KustoDatabaseRouting.Multi,
                ManagedIdentityResourceId = clusterResourceId
            };

            await CollectionTests(
                eventGridDataConnectionName, $"{ClusterName}/{DatabaseName}/{eventGridDataConnectionName}",
                eventGridDataConnectionDataCreate, eventGridDataConnectionDataUpdate,
                (eventGridDataConnectionName, eventGridDataConnectionData) =>
                    _dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventGridDataConnectionName,
                        eventGridDataConnectionData),
                _dataConnectionCollection.GetAsync,
                _dataConnectionCollection.GetAllAsync,
                _dataConnectionCollection.ExistsAsync,
                ValidateEventGridDataConnection
            );

            KustoDataConnectionResource eventGridDataConnection =
                (await _dataConnectionCollection.GetAsync(eventGridDataConnectionName)).Value;
            await DeleteDataConnectionTest(eventGridDataConnection);
        }

        private async Task DeleteDataConnectionTest(KustoDataConnectionResource dataConnection)
        {
            bool exists;

            await dataConnection.DeleteAsync(WaitUntil.Completed);
            exists = await _dataConnectionCollection.ExistsAsync(dataConnection.Data.Name);
            Assert.IsFalse(exists);
        }

        private void ValidateEventHubDataConnection(KustoDataConnectionResource eventHubDataConnection,
            string eventHubDataConnectionName,
            KustoEventHubDataConnection eventHubDataConnectionData)
        {
            Assert.AreEqual(eventHubDataConnectionName, eventHubDataConnection.Data.Name);
            Assert.AreEqual(eventHubDataConnectionData.EventHubResourceId,
                ((KustoEventHubDataConnection)eventHubDataConnection.Data).EventHubResourceId);
            Assert.AreEqual(eventHubDataConnectionData.ConsumerGroup,
                ((KustoEventHubDataConnection)eventHubDataConnection.Data).ConsumerGroup);
            Assert.AreEqual(eventHubDataConnectionData.DataFormat ?? string.Empty,
                ((KustoEventHubDataConnection)eventHubDataConnection.Data).DataFormat);
            Assert.AreEqual(eventHubDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                ((KustoEventHubDataConnection)eventHubDataConnection.Data).DatabaseRouting);
            Assert.AreEqual(eventHubDataConnectionData.ManagedIdentityResourceId,
                ((KustoEventHubDataConnection)eventHubDataConnection.Data).ManagedIdentityResourceId);
        }

        private void ValidateIotHubDataConnection(KustoDataConnectionResource iotHubDataConnection,
            string iotHubDataConnectionName,
            KustoIotHubDataConnection iotHubDataConnectionData)
        {
            Assert.AreEqual(iotHubDataConnectionName, iotHubDataConnection.Data.Name);
            Assert.AreEqual(iotHubDataConnectionData.IotHubResourceId,
                ((KustoIotHubDataConnection)iotHubDataConnection.Data).IotHubResourceId);
            Assert.AreEqual(iotHubDataConnectionData.ConsumerGroup,
                ((KustoIotHubDataConnection)iotHubDataConnection.Data).ConsumerGroup);
            Assert.AreEqual(iotHubDataConnectionData.DataFormat ?? string.Empty,
                ((KustoIotHubDataConnection)iotHubDataConnection.Data).DataFormat);
            Assert.AreEqual(iotHubDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                ((KustoIotHubDataConnection)iotHubDataConnection.Data).DatabaseRouting);
        }

        private void ValidateEventGridDataConnection(KustoDataConnectionResource eventGridDataConnection,
            string eventGridDataConnectionName,
            KustoEventGridDataConnection eventGridDataConnectionData)
        {
            Assert.AreEqual(eventGridDataConnectionName, eventGridDataConnection.Data.Name);
            Assert.AreEqual(eventGridDataConnectionData.EventHubResourceId,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).EventHubResourceId);
            Assert.AreEqual(eventGridDataConnectionData.ConsumerGroup,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).ConsumerGroup);
            Assert.AreEqual(eventGridDataConnectionData.DataFormat ?? string.Empty,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).DataFormat);
            Assert.AreEqual(eventGridDataConnectionData.StorageAccountResourceId,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).StorageAccountResourceId);
            Assert.AreEqual(eventGridDataConnectionData.TableName,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).TableName);
            Assert.AreEqual(eventGridDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).DatabaseRouting);
            Assert.AreEqual(eventGridDataConnectionData.ManagedIdentityResourceId,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).ManagedIdentityResourceId);
            Guid? managedIdentityObjectId = eventGridDataConnectionData.ManagedIdentityResourceId is null
                ? null
                : Guid.Parse("a4f74545-0569-49ab-a902-f712fcf2f9e0");
            Assert.AreEqual(managedIdentityObjectId, ((KustoEventGridDataConnection)eventGridDataConnection.Data).ManagedIdentityObjectId);
        }
    }
}
