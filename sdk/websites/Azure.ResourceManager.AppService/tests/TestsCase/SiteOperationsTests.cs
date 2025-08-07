// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteOperationsTests : AppServiceTestBase
    {
        public SiteOperationsTests(bool isAsync)
    : base(isAsync)
        {
        }

        private async Task<WebSiteResource> CreateSiteAsync(string siteName)
        {
            var container = (await CreateResourceGroupAsync()).GetWebSites();
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, siteName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var siteName = Recording.GenerateAssetName("testSite-");
            var plan = await CreateSiteAsync(siteName);
            await plan.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var siteName = Recording.GenerateAssetName("testSite-");
            var site1 = await CreateSiteAsync(siteName);
            WebSiteResource site2 = await site1.GetAsync();

            ResourceDataHelper.AssertSite(site1.Data, site2.Data);
        }

        //Manual operation needed to create website/hybridconnection resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task GetHybridConnections()
        {
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
            ResourceGroupResource rg = await rgCollection.GetAsync("Rg_Lwm");
            WebSiteCollection webSiteCollection = rg.GetWebSites();
            WebSiteResource webSiteResource = await webSiteCollection.GetAsync("sitelwm01");
            var hybridConnectionDataCollection = webSiteResource.GetHybridConnectionsAsync();
            int count = 0;
            await foreach (HybridConnectionData item in hybridConnectionDataCollection)
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }
        //Manual operation needed to create website/hybridconnection resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task GetHybridConnectionsSlot()
        {
            var wbSiteSlotID = WebSiteSlotResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, "Rg_Lwm", "sitelwm01", "slotsitelwm01");
            WebSiteSlotResource wsSlotResource = Client.GetWebSiteSlotResource(wbSiteSlotID);
            var hybridConnectionDataCollection = wsSlotResource.GetHybridConnectionsSlotAsync();
            int count = 0;
            await foreach (HybridConnectionData item in hybridConnectionDataCollection)
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }
    }
}
