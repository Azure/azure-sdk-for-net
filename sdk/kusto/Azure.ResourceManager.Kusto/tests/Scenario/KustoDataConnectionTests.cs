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

        public KustoDataConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task EventHubDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();
            var eventHubDataConnectionName = Recording.GenerateAssetName("sdkTestEventHubDataConnection");
            var eventHubResourceId = new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.EventHub/namespaces/testclientsns22/eventhubs/testclientseh"
            );
            var eventHubDataConnectionDataCreate = new KustoEventHubDataConnection
            {
                Location = KustoTestUtils.Location,
                EventHubResourceId = new ResourceIdentifier(eventHubResourceId),
                ConsumerGroup = "$Default"
            };
            var eventHubDataConnectionDataUpdate = new KustoEventHubDataConnection
            {
                Location = KustoTestUtils.Location,
                EventHubResourceId = new ResourceIdentifier(eventHubResourceId),
                ConsumerGroup = "$Default",
                DataFormat = KustoEventHubDataFormat.Csv,
                DatabaseRouting = KustoDatabaseRouting.Multi,
                ManagedIdentityResourceId = Cluster.Id
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateEventHubDataConnectionAsync(
                string eventHubDataConnectionName, KustoEventHubDataConnection eventHubDataConnectionData) =>
                dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubDataConnectionName,
                    eventHubDataConnectionData);

            await CollectionTests(
                eventHubDataConnectionName,
                eventHubDataConnectionDataCreate, eventHubDataConnectionDataUpdate,
                CreateOrUpdateEventHubDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateEventHubDataConnection,
                databaseChild: true
            );

            await DeletionTest(
                eventHubDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
        }

        [TestCase]
        [RecordedTest]
        public async Task IotHubDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();
            var iotHubDataConnectionName = Recording.GenerateAssetName("sdkTestIotHubDataConnection");
            var iotHubResourceId = new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.Devices/IotHubs/test-clients-iot");
            var iotHubDataConnectionDataCreate = new KustoIotHubDataConnection
            {
                Location = KustoTestUtils.Location,
                IotHubResourceId = iotHubResourceId,
                SharedAccessPolicyName = "registryRead",
                ConsumerGroup = "$Default"
            };
            var iotHubDataConnectionDataUpdate = new KustoIotHubDataConnection
            {
                Location = KustoTestUtils.Location,
                IotHubResourceId = iotHubResourceId,
                SharedAccessPolicyName = "registryRead",
                ConsumerGroup = "$Default",
                DataFormat = KustoIotHubDataFormat.Csv,
                DatabaseRouting = KustoDatabaseRouting.Multi
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateIotHubDataConnectionAsync(
                string iotHubDataConnectionName, KustoIotHubDataConnection iotHubDataConnectionData) =>
                dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, iotHubDataConnectionName,
                    iotHubDataConnectionData);

            await CollectionTests(
                iotHubDataConnectionName,
                iotHubDataConnectionDataCreate, iotHubDataConnectionDataUpdate,
                CreateOrUpdateIotHubDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateIotHubDataConnection,
                databaseChild: true
            );

            await DeletionTest(
                iotHubDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
        }

        [TestCase]
        [RecordedTest]
        public async Task EventGridDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();
            var eventGridDataConnectionName = Recording.GenerateAssetName("sdkTestEventGridDataConnection");
            var storageAccountResourceId = new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.Storage/storageAccounts/testclients");
            var eventHubResourceId = new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.EventHub/namespaces/testclientsns22/eventhubs/testclientseh");
            var clusterResourceId = new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/{ConnectionsResourceGroupName}/providers/Microsoft.Kusto/Clusters/eventgridclienttest");
            var eventGridDataConnectionDataCreate = new KustoEventGridDataConnection()
            {
                Location = KustoTestUtils.Location,
                StorageAccountResourceId = storageAccountResourceId,
                EventHubResourceId = eventHubResourceId,
                ConsumerGroup = "$Default",
                TableName = "MyTest"
            };
            var eventGridDataConnectionDataUpdate = new KustoEventGridDataConnection()
            {
                Location = KustoTestUtils.Location,
                StorageAccountResourceId = storageAccountResourceId,
                EventHubResourceId = eventHubResourceId,
                ConsumerGroup = "$Default",
                TableName = "MyTest",
                DataFormat = KustoEventGridDataFormat.Csv,
                DatabaseRouting = KustoDatabaseRouting.Multi,
                ManagedIdentityResourceId = clusterResourceId
            };

            Task<ArmOperation<KustoDataConnectionResource>> CreateOrUpdateEventGridDataConnectionAsync(
                string eventGridDataConnectionName, KustoEventGridDataConnection eventGridDataConnectionData) =>
                dataConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventGridDataConnectionName,
                    eventGridDataConnectionData);

            await CollectionTests(
                eventGridDataConnectionName,
                eventGridDataConnectionDataCreate, eventGridDataConnectionDataUpdate,
                CreateOrUpdateEventGridDataConnectionAsync,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.GetAllAsync,
                dataConnectionCollection.ExistsAsync,
                ValidateEventGridDataConnection,
                databaseChild: true
            );

            await DeletionTest(
                eventGridDataConnectionName,
                dataConnectionCollection.GetAsync,
                dataConnectionCollection.ExistsAsync
            );
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
            Assert.AreEqual(managedIdentityObjectId,
                ((KustoEventGridDataConnection)eventGridDataConnection.Data).ManagedIdentityObjectId);
        }
    }
}
