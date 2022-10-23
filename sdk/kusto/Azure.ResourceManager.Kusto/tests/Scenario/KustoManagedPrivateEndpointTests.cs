// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoManagedPrivateEndpointTests : KustoManagementTestBase
    {
        public KustoManagedPrivateEndpointTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ManagedPrivateEndpointTests()
        {
            var managedPrivateEndpointCollection = Cluster.GetKustoManagedPrivateEndpoints();
            var managedPrivateEndpointName = Recording.GenerateAssetName("sdkTestManagedPrivateEndpoint");
            var managedPrivateEndpointDataCreate = new KustoManagedPrivateEndpointData
            {
                PrivateLinkResourceId =
                    new ResourceIdentifier(
                        $"/subscriptions/{SubscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.EventHub/namespaces/testclientsns22"),
                GroupId = "namespace",
                RequestMessage = "Please Approve Kusto"
            };
            var managedPrivateEndpointDataUpdate = new KustoManagedPrivateEndpointData
            {
                PrivateLinkResourceId =
                    new ResourceIdentifier(
                        $"/subscriptions/{SubscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.EventHub/namespaces/testclientsns22"),
                GroupId = "namespace",
                RequestMessage = "Approve Kusto"
            };

            Task<ArmOperation<KustoManagedPrivateEndpointResource>> CreateOrUpdateManagedPrivateEndpointAsync(
                string managedPrivateEndpointName, KustoManagedPrivateEndpointData managedPrivateEndpointData) =>
                managedPrivateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, managedPrivateEndpointName,
                    managedPrivateEndpointData);

            await CollectionTests(
                managedPrivateEndpointName, managedPrivateEndpointDataCreate, managedPrivateEndpointDataUpdate,
                CreateOrUpdateManagedPrivateEndpointAsync,
                managedPrivateEndpointCollection.GetAsync,
                managedPrivateEndpointCollection.GetAllAsync,
                managedPrivateEndpointCollection.ExistsAsync,
                VerifyManagedPrivateEndpoints,
                clusterChild: true
            );

            await DeletionTest(
                managedPrivateEndpointName,
                managedPrivateEndpointCollection.GetAsync,
                managedPrivateEndpointCollection.ExistsAsync
            );
        }

        private void VerifyManagedPrivateEndpoints(KustoManagedPrivateEndpointResource managedPrivateEndpoint,
            string managedPrivateEndpointName, KustoManagedPrivateEndpointData managedPrivateEndpointData)
        {
            Assert.AreEqual(managedPrivateEndpointName, managedPrivateEndpoint.Data.Name);
            Assert.AreEqual(managedPrivateEndpointData.PrivateLinkResourceId,
                managedPrivateEndpoint.Data.PrivateLinkResourceId);
            Assert.AreEqual(managedPrivateEndpointData.GroupId, managedPrivateEndpoint.Data.GroupId);
            Assert.AreEqual(managedPrivateEndpointData.RequestMessage, managedPrivateEndpoint.Data.RequestMessage);
        }
    }
}
