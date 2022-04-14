// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Grafana.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Grafana.Tests.TestsCase
{
    public class GrafanaResourceCollectionTests : GrafanaTestBase
    {
        public GrafanaResourceCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<ManagedGrafanaCollection> GetCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetManagedGrafanas();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetCollectionAsync();
            var grafanaName = Recording.GenerateAssetName("sdkTestGrafana");
            var input = ResourceDataHelper.GetGrafanaResourceData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, grafanaName, input);
            ManagedGrafanaResource actualResource = lro.Value;
            Assert.AreEqual(grafanaName, actualResource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetCollectionAsync();
            var grafanaName = Recording.GenerateAssetName("sdkTestGrafana");
            var input = ResourceDataHelper.GetGrafanaResourceData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, grafanaName, input);
            ManagedGrafanaResource resource1 = lro.Value;
            ManagedGrafanaResource resource2 = await container.GetAsync(grafanaName);
            ResourceDataHelper.AssertGrafana(resource1.Data, resource2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetCollectionAsync();
            var grafanaName1 = Recording.GenerateAssetName("sdkTestGrafana1");
            var grafanaName2 = Recording.GenerateAssetName("sdkTestGrafana2");
            var input1 = ResourceDataHelper.GetGrafanaResourceData(DefaultLocation);
            var input2 = ResourceDataHelper.GetGrafanaResourceData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, grafanaName1, input1);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, grafanaName2, input2);
            int count = 0;
            await foreach (var appServicePlan in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
