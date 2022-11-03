// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoPrivateEndpointConnectionTests : KustoManagementTestBase
    {
        private PrivateEndpointData PrivateEndpointData;

        public KustoPrivateEndpointConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();

            var privateEndpointCollection =
                (await ResourceGroup.GetPrivateEndpointAsync(TestEnvironment.PrivateEndpointName)).Value;

            PrivateEndpointData = privateEndpointCollection.Data;
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateEndpointConnectionTests()
        {
            var privateEndpointConnectionCollection = Cluster.GetKustoPrivateEndpointConnections();

            await CollectionTests(
                TestEnvironment.PrivateEndpointName, PrivateEndpointData, PrivateEndpointData,
                null,
                privateEndpointConnectionCollection.GetAsync,
                privateEndpointConnectionCollection.GetAllAsync,
                privateEndpointConnectionCollection.ExistsAsync,
                ValidatePrivateEndpoint,
                clusterChild: true
            );
        }

        private void ValidatePrivateEndpoint(
            KustoPrivateEndpointConnectionResource privateEndpointConnection,
            string privateEndpointConnectionName,
            PrivateEndpointData privateEndpointData
        )
        {
            Assert.AreEqual(privateEndpointConnectionName, privateEndpointConnection.Data.Name);
            Assert.AreEqual(privateEndpointData.Id, privateEndpointConnection.Data.PrivateEndpointId);
        }
    }
}
