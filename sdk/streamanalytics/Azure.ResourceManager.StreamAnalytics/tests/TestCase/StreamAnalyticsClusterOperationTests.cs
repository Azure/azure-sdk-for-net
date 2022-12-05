// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StreamAnalytics.Models;
using Azure.ResourceManager.StreamAnalytics.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.StreamAnalytics.Tests.TestCase
{
    public class StreamAnalyticsClusterOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamAnalyticsClusterOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamAnalyticsClusterResource> CreateClusterResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamAnalyticsClusters();
            var input = ResourceDataHelpers.GetClusterData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            return lro.Value;
        }

        [TestCase]
        public async Task StreamAnalyticsCluserOperationApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testCluser-");
            var cluster1 = await CreateClusterResourceAsync(Name);
            StreamAnalyticsClusterResource cluster2 = await cluster1.GetAsync();

            ResourceDataHelpers.AssertCluster(cluster1.Data, cluster2.Data);
            //2.Delete
            await cluster1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
