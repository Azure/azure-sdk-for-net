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
    public class StreamAnalyticsPEOperationTests : StreamAnalyticsManagementTestBase
    {
        public StreamAnalyticsPEOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<StreamAnalyticsPrivateEndpointResource> CreateStreamAnalyticsPrivateEndpointResourceAsync(string Name)
        {
            var container = (await CreateResourceGroupAsync()).GetStreamAnalyticsClusters();
            var input = ResourceDataHelpers.GetClusterData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Name, input);
            var cluster =  lro.Value;
            var endPointContainer = cluster.GetStreamAnalyticsPrivateEndpoints();
            var endPointInput = ResourceDataHelpers.GetEndPointData();
            var lroEP = await endPointContainer.CreateOrUpdateAsync(WaitUntil.Completed, Name, endPointInput);
            return lroEP.Value;
        }

        [TestCase]
        public async Task PrivateEndpointOperationApiTests()
        {
            //1.Get
            var Name = Recording.GenerateAssetName("testCluser-");
            var endpoint1 = await CreateStreamAnalyticsPrivateEndpointResourceAsync(Name);
            StreamAnalyticsPrivateEndpointResource endpoint2 = await endpoint1.GetAsync();

            ResourceDataHelpers.AssertEndPoint(endpoint1.Data, endpoint2.Data);
            //2.Delete
            await endpoint1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
