// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dashboard.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Dashboard.Tests.TestsCase
{
    public class GrafanaResourceCollectionTests : DashboardTestBase
    {
        public GrafanaResourceCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<GrafanaResourceCollection> GetCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetGrafanaResources();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetCollectionAsync();
            var grafanaName = Recording.GenerateAssetName("sdkTestGrafana");
            var input = ResourceDataHelper.GetGrafanaResourceData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, grafanaName, input);
            GrafanaResource actualResource = lro.Value;
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
            GrafanaResource resource1 = lro.Value;
            GrafanaResource resource2 = await container.GetAsync(grafanaName);
            ResourceDataHelper.AssertGrafana(resource1.Data, resource2.Data);
        }
    }
}
