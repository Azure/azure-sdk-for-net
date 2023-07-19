// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class StreamAnalyticsPrivateEndPointCollectionTests : StreamAnalyticsManagementTestBase
    {
    public StreamAnalyticsPrivateEndPointCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
    {
    }

    private async Task<StreamAnalyticsPrivateEndpointCollection> GetStreamAnalyticsPrivateEndpointCollectionAsync()
    {
        var container = (await CreateResourceGroupAsync()).GetStreamAnalyticsClusters();
        var input = ResourceDataHelpers.GetClusterData(DefaultLocation);
        var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, "testCluster-", input);
        var cluster = lro.Value;
        return cluster.GetStreamAnalyticsPrivateEndpoints();
    }

    [TestCase]
    [RecordedTest]
    public async Task StreamAnalyticsPrivateEndpointApiTests()
    {
        //1.CreateorUpdate
        var container = await GetStreamAnalyticsPrivateEndpointCollectionAsync();
        var name = Recording.GenerateAssetName("StreamAnalyticsEndpoint-");
        var input = ResourceDataHelpers.GetEndPointData();
        var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
        StreamAnalyticsPrivateEndpointResource account1 = lro.Value;
        Assert.AreEqual(name, account1.Data.Name);
        //2.Get
        StreamAnalyticsPrivateEndpointResource account2 = await container.GetAsync(name);
        ResourceDataHelpers.AssertEndPoint(account1.Data, account2.Data);
        //3.GetAll
        _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
        int count = 0;
        await foreach (var account in container.GetAllAsync())
        {
            count++;
        }
        Assert.GreaterOrEqual(count, 1);
        //4Exists
        Assert.IsTrue(await container.ExistsAsync(name));
        Assert.IsFalse(await container.ExistsAsync(name + "1"));

        Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
    }
}
}
