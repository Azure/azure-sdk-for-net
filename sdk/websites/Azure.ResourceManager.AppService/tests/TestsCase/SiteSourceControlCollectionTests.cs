// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteSourceControlCollectionTests : AppServiceTestBase
    {
        public SiteSourceControlCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<WebSiteSourceControlResource> GetSiteSourceControlCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var SiteName = Recording.GenerateAssetName("testSiteSource");
            var SiteInput = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await resourceGroup.GetWebSites().CreateOrUpdateAsync(WaitUntil.Completed, SiteName, SiteInput);
            var Site = lro.Value;
            return Site.GetWebSiteSourceControl();
        }

        [TestCase]
        [RecordedTest]
        public async Task SiteSourceControlCreateOrUpdate()
        {
            var container = await GetSiteSourceControlCollectionAsync();
            //var name = Recording.GenerateAssetName("testSiteSource");
            var input = ResourceDataHelper.GetBasicSiteSourceControlData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, input);
            var siteSourceControl = lro.Value;
            //Assert.AreEqual(name, siteSourceControl.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetSiteSourceControlCollectionAsync();
            //var controlName = Recording.GenerateAssetName("testSiteSourceControl-");
            var input = ResourceDataHelper.GetBasicSiteSourceControlData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, input);
            WebSiteSourceControlResource sourcecontrol1 = lro.Value;
            WebSiteSourceControlResource sourcecontrol2 = await container.GetAsync();
            ResourceDataHelper.AssertSiteSourceControlData(sourcecontrol1.Data, sourcecontrol2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var planName = Recording.GenerateAssetName("testAppServicePlan-");
            var plan = await GetSiteSourceControlCollectionAsync();
            await plan.DeleteAsync(WaitUntil.Completed);
        }
    }
}
