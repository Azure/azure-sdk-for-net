// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task ManagedPrivateEndpointTests()
        {
            var managedPrivateEndpointCollection = Cluster.GetKustoManagedPrivateEndpoints();

            var managedPrivateEndpointName = GenerateAssetName("sdkManagedPrivateEndpoint");
            var privateLinkResourceId = TE.EventHubId.Parent;

            var managedPrivateEndpointDataCreate = new KustoManagedPrivateEndpointData
            {
                PrivateLinkResourceId = privateLinkResourceId,
                GroupId = "namespace",
                RequestMessage = "Please Approve"
            };

            Task<ArmOperation<KustoManagedPrivateEndpointResource>> CreateOrUpdateManagedPrivateEndpointAsync(
                string managedPrivateEndpointName, KustoManagedPrivateEndpointData managedPrivateEndpointData
            ) => managedPrivateEndpointCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, managedPrivateEndpointName, managedPrivateEndpointData
            );

            await CollectionTests(
                managedPrivateEndpointName,
                GetFullClusterChildResourceName(managedPrivateEndpointName),
                managedPrivateEndpointDataCreate,
                managedPrivateEndpointDataCreate,
                CreateOrUpdateManagedPrivateEndpointAsync,
                managedPrivateEndpointCollection.GetAsync,
                managedPrivateEndpointCollection.GetAllAsync,
                managedPrivateEndpointCollection.ExistsAsync,
                ValidateManagedPrivateEndpoints
            );

            await DeletionTest(
                managedPrivateEndpointName,
                managedPrivateEndpointCollection.GetAsync,
                managedPrivateEndpointCollection.ExistsAsync
            );
        }

        private static void ValidateManagedPrivateEndpoints(
            string expectedFullManagedPrivateEndpointName,
            KustoManagedPrivateEndpointData expectedManagedPrivateEndpointData,
            KustoManagedPrivateEndpointData actualManagedPrivateEndpointData)
        {
            AssertEquality(expectedManagedPrivateEndpointData.GroupId, actualManagedPrivateEndpointData.GroupId);
            AssertEquality(expectedFullManagedPrivateEndpointName, actualManagedPrivateEndpointData.Name);
            AssertEquality(
                expectedManagedPrivateEndpointData.PrivateLinkResourceId,
                actualManagedPrivateEndpointData.PrivateLinkResourceId
            );
            AssertEquality(
                expectedManagedPrivateEndpointData.RequestMessage, actualManagedPrivateEndpointData.RequestMessage
            );
        }
    }
}
