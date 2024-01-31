// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoPrivateEndpointConnectionTests : KustoManagementTestBase
    {
        public KustoPrivateEndpointConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();
        }

        [Ignore("Depend on Network which will block the pipeline to release new Network package, disable this case temporary")]
        [RecordedTest]
        public async Task PrivateEndpointConnectionTests()
        {
            var privateEndpointConnectionCollection = Cluster.GetKustoPrivateEndpointConnections();

            var privateEndpointConnection = await privateEndpointConnectionCollection.GetAllAsync().FirstAsync();
            var privateEndpointConnectionName = privateEndpointConnection.Data.Name;

            ValidatePrivateEndpointConnection(privateEndpointConnection.Data);

            privateEndpointConnection =
                await privateEndpointConnectionCollection.GetAsync(privateEndpointConnectionName);

            ValidatePrivateEndpointConnection(privateEndpointConnection.Data);

            // TODO: bug in exists non-existent
            // await CollectionTests<KustoPrivateEndpointConnectionResource, KustoPrivateEndpointConnectionData>(
            //     privateEndpointConnectionName,
            //     privateEndpointConnectionName,
            //     null,
            //     null,
            //     null,
            //     privateEndpointConnectionCollection.GetAsync,
            //     privateEndpointConnectionCollection.GetAllAsync,
            //     privateEndpointConnectionCollection.ExistsAsync,
            //     ValidatePrivateEndpointConnection
            // );

            // TODO: bug in exists non-existent
            // await DeletionTest(
            //     privateEndpointConnectionName,
            //     privateEndpointConnectionCollection.GetAsync,
            //     privateEndpointConnectionCollection.ExistsAsync
            // );
        }

        private void ValidatePrivateEndpointConnection(
            KustoPrivateEndpointConnectionData actualPrivateEndpointConnectionData
        )
        {
            AssertEquality("cluster", actualPrivateEndpointConnectionData.GroupId);
            Assert.IsTrue(actualPrivateEndpointConnectionData.Name.Contains(TE.PrivateEndpointName));
            ValidatePrivateEndpointConnectionState(actualPrivateEndpointConnectionData.ConnectionState);
        }

        private static void ValidatePrivateEndpointConnectionState(
            KustoPrivateLinkServiceConnectionStateProperty actualPrivateEndpointConnectionState
        )
        {
            AssertEquality("Approved", actualPrivateEndpointConnectionState.Status);
            AssertEquality("", actualPrivateEndpointConnectionState.Description);
            AssertEquality("None", actualPrivateEndpointConnectionState.ActionsRequired);
        }
    }
}
