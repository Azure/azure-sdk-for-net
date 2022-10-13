// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario.Collections
{
    public class KustoManagedPrivateEndpointCollectionTests : KustoManagementTestBase
    {
        private KustoManagedPrivateEndpointCollection _managedPrivateEndpointCollection;

        private string _managedPrivateEndpointName;
        private KustoManagedPrivateEndpointData _managedPrivateEndpointData;

        private CreateOrUpdateAsync<KustoManagedPrivateEndpointResource, KustoManagedPrivateEndpointData> _createOrUpdateAsync;

        public KustoManagedPrivateEndpointCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ManagedPrivateEndpointCollectionSetup()
        {
            var cluster = await GetCluster(ResourceGroup);
            _managedPrivateEndpointCollection = cluster.GetKustoManagedPrivateEndpoints();

            _managedPrivateEndpointName = Recording.GenerateAssetName("managedPrivateEndpoint");
            _managedPrivateEndpointData = new KustoManagedPrivateEndpointData();

            _createOrUpdateAsync = (managedPrivateEndpointName, managedPrivateEndpointData) =>
                _managedPrivateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, managedPrivateEndpointName, managedPrivateEndpointData);
        }

        [TestCase]
        [RecordedTest]
        public async Task ManagedPrivateEndpointCollectionTests()
        {
            await CollectionTests(
                _managedPrivateEndpointName, _managedPrivateEndpointData,
                _createOrUpdateAsync,
                _managedPrivateEndpointCollection.GetAsync,
                _managedPrivateEndpointCollection.GetAllAsync,
                _managedPrivateEndpointCollection.ExistsAsync
            );
        }
    }
}
