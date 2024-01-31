// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests
{
    //public class ResourceLinkOperationsTests : ResourceManagerTestBase
    //{
    //    public ResourceLinkOperationsTests(bool isAsync)
    //        : base(isAsync)//, RecordedTestMode.Record)
    //    {
    //    }

    //    [TestCase]
    //    [RecordedTest]
    //    public async Task Delete()
    //    {
    //        TenantResource tenant = await Client.GetTenants().GetAllAsync().FirstOrDefaultAsync(_ => true);
    //        SubscriptionResource subscription = await tenant.GetSubscriptions().GetAllAsync().FirstOrDefaultAsync(_ => true);
    //        string rgName = Recording.GenerateAssetName("testRg-");
    //        ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
    //        string vnName1 = Recording.GenerateAssetName("testVn-");
    //        string vnName2 = Recording.GenerateAssetName("testVn-");
    //        GenericResource vn1 = await CreateGenericVirtualNetwork(subscription, rg, vnName1);
    //        GenericResource vn2 = await CreateGenericVirtualNetwork(subscription, rg, vnName2);
    //        string resourceLinkName = Recording.GenerateAssetName("link-");
    //        ResourceLinkResource resourceLink = await CreateResourceLink(tenant, vn1, vn2, resourceLinkName);
    //        await resourceLink.DeleteAsync(WaitUntil.Completed);
    //        var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await resourceLink.GetAsync());
    //        Assert.AreEqual(404, ex.Status);
    //    }
    //}
}
