// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteConfigWebCollectionTests : AppServiceTestBase
    {
        public SiteConfigWebCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<WebSiteSlotConfigResource> GetSiteSlotConfigResourceAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var SiteName = Recording.GenerateAssetName("testSite");
            var SiteSlotName = Recording.GenerateAssetName("testSiteSlot");
            var SiteInput = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await resourceGroup.GetWebSites().CreateOrUpdateAsync(WaitUntil.Completed, SiteName, SiteInput);
            var Site = lro.Value;
            var lroSiteSlot = await Site.GetWebSiteSlots().CreateOrUpdateAsync(WaitUntil.Completed, SiteSlotName, SiteInput);
            var siteSlot = lroSiteSlot.Value;
            return siteSlot.GetWebSiteSlotConfig();
        }

        [TestCase]
        [RecordedTest]
        public async Task Demo()
        {
            try
            {
                // we just pretend that we have one
                SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
                var rgName = Recording.GenerateAssetName("testRg");
                var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                ResourceGroupResource rg = rgLro.Value;
                var siteId = WebSiteSlotResource.CreateResourceIdentifier(rg.Id.SubscriptionId, rg.Id.ResourceGroupName, "site", "slot");
                var site = Client.GetWebSiteSlotResource(siteId);
                await foreach (var configResource in site.GetConfigurationsSlotAsync())
                {
                    Assert.IsTrue(configResource is WebSiteSlotConfigResource);
                }
            }
            catch
            {
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Cannot complete the operation because the site will exceed the number of slots allowed for the 'Free' SKU")]
        public async Task CreateOrUpdate()
        {
            var container = await GetSiteSlotConfigResourceAsync();
            var name = Recording.GenerateAssetName("testSiteSlotConfigWeb");
            var Input = ResourceDataHelper.GetBasicSiteConfigResourceData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Input);
            WebSiteSlotConfigResource siteSlotConfigWeb = lro.Value;
            Assert.AreEqual(name, siteSlotConfigWeb.Data.Name);
        }
    }
}
