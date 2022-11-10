// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            await BaseSetUp(database: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task IotHubDataConnectionTests()
        {
            var dataConnectionCollection = Database.GetKustoDataConnections();

            var iotHubDataConnectionName = GenerateAssetName("sdkIotHubDataConnection");

            var iotHubDataConnectionDataCreate = new KustoIotHubDataConnection
            {
                ConsumerGroup = "$Default", IotHubResourceId = TE.IotHubId, SharedAccessPolicyName = "registryRead"
            };

            var iotHubDataConnectionDataUpdate = new KustoIotHubDataConnection
            {
                ConsumerGroup = "$Default",
                DatabaseRouting = KustoDatabaseRouting.Multi,
                DataFormat = KustoIotHubDataFormat.Csv,
                IotHubResourceId = TE.IotHubId,
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
                ConsumerGroup = "$Default", EventHubResourceId = TE.EventHubId
            };

            var eventHubDataConnectionDataUpdate = new KustoEventHubDataConnection
            {
                ConsumerGroup = "$Default",
                DatabaseRouting = KustoDatabaseRouting.Multi,
                DataFormat = KustoEventHubDataFormat.Csv,
                EventHubResourceId = TE.EventHubId,
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
                StorageAccountResourceId = TE.StorageAccountId
            };

            var eventGridDataConnectionDataUpdate = new KustoEventGridDataConnection()
            {
                ConsumerGroup = "$Default",
                DatabaseRouting = KustoDatabaseRouting.Multi,
                DataFormat = KustoEventGridDataFormat.Csv,
                EventHubResourceId = TE.EventHubId,
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

        private static void ValidateIotHubDataConnection(
            string iotHubDataConnectionName,
            KustoIotHubDataConnection expectedIotHubDataConnectionData,
            KustoIotHubDataConnection actualIotHubDataConnectionData
        )
        {
            Assert.AreEqual(
                expectedIotHubDataConnectionData.ConsumerGroup, actualIotHubDataConnectionData.ConsumerGroup
            );
            Assert.AreEqual(
                expectedIotHubDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                actualIotHubDataConnectionData.DatabaseRouting
            );
            Assert.AreEqual(
                expectedIotHubDataConnectionData.DataFormat ?? string.Empty,
                actualIotHubDataConnectionData.DataFormat
            );
            Assert.AreEqual(
                expectedIotHubDataConnectionData.IotHubResourceId, actualIotHubDataConnectionData.IotHubResourceId
            );
            Assert.AreEqual(iotHubDataConnectionName, actualIotHubDataConnectionData.Name);
            Assert.AreEqual(expectedIotHubDataConnectionData.TableName, actualIotHubDataConnectionData.TableName);
        }

        private static void ValidateEventHubDataConnection(
            string eventHubDataConnectionName,
            KustoEventHubDataConnection expectedEventHubDataConnectionData,
            KustoEventHubDataConnection actualEventHubDataConnectionData
        )
        {
            Assert.AreEqual(
                expectedEventHubDataConnectionData.ConsumerGroup,
                actualEventHubDataConnectionData.ConsumerGroup
            );
            Assert.AreEqual(
                expectedEventHubDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                actualEventHubDataConnectionData.DatabaseRouting
            );
            Assert.AreEqual(
                expectedEventHubDataConnectionData.DataFormat ?? string.Empty,
                actualEventHubDataConnectionData.DataFormat
            );
            Assert.AreEqual(
                expectedEventHubDataConnectionData.EventHubResourceId,
                actualEventHubDataConnectionData.EventHubResourceId
            );
            Assert.AreEqual(
                expectedEventHubDataConnectionData.ManagedIdentityResourceId,
                actualEventHubDataConnectionData.ManagedIdentityResourceId
            );
            Assert.AreEqual(eventHubDataConnectionName, actualEventHubDataConnectionData.Name);
            Assert.AreEqual(expectedEventHubDataConnectionData.TableName, actualEventHubDataConnectionData.TableName);
        }

        private void ValidateEventGridDataConnection(
            string eventGridDataConnectionName,
            KustoEventGridDataConnection expectedEventGridDataConnectionData,
            KustoEventGridDataConnection actualEventGridDataConnectionData
        )
        {
            Assert.AreEqual(
                expectedEventGridDataConnectionData.ConsumerGroup, actualEventGridDataConnectionData.ConsumerGroup
            );
            Assert.AreEqual(
                expectedEventGridDataConnectionData.DatabaseRouting ?? KustoDatabaseRouting.Single,
                actualEventGridDataConnectionData.DatabaseRouting
            );
            Assert.AreEqual(
                expectedEventGridDataConnectionData.DataFormat ?? string.Empty,
                actualEventGridDataConnectionData.DataFormat
            );
            Assert.AreEqual(
                expectedEventGridDataConnectionData.EventHubResourceId,
                actualEventGridDataConnectionData.EventHubResourceId
            );
            Assert.AreEqual(
                expectedEventGridDataConnectionData.ManagedIdentityResourceId,
                actualEventGridDataConnectionData.ManagedIdentityResourceId
            );
            Assert.AreEqual(
                GetFullDatabaseChildResourceName(eventGridDataConnectionName),
                actualEventGridDataConnectionData.Name
            );
            Assert.AreEqual(
                expectedEventGridDataConnectionData.StorageAccountResourceId,
                actualEventGridDataConnectionData.StorageAccountResourceId
            );
            Assert.AreEqual(expectedEventGridDataConnectionData.TableName, actualEventGridDataConnectionData.TableName);
        }
    }
}
