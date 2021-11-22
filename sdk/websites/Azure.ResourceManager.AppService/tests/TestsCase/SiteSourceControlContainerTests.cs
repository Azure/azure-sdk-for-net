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
    public class SiteSourceControlContainerTests : AppServiceTestBase
    {
        public SiteSourceControlContainerTests(bool isAsync)
           : base(isAsync, Azure.Core.TestFramework.RecordedTestMode.Record)
        {
        }

        private async Task<SiteSourcecontrolContainer> GetSiteSourceControlContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var SiteName = Recording.GenerateAssetName("testSiteSource");
            var SiteInput = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await resourceGroup.GetSites().CreateOrUpdateAsync(SiteName, SiteInput);
            var Site = lro.Value;
            return Site.GetSiteSourcecontrols();
        }

        [TestCase]
        [RecordedTest]
        public async Task SiteSourceControlCreateOrUpdate()
        {
            var container = await GetSiteSourceControlContainerAsync();
            //var name = Recording.GenerateAssetName("testSiteSource");
            var input = ResourceDataHelper.GetBasicSiteSourceControlData();
            var lro = await container.CreateOrUpdateAsync(input);
            var siteSourceControl = lro.Value;
            //Assert.AreEqual(name, siteSourceControl.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetSiteSourceControlContainerAsync();
            //var controlName = Recording.GenerateAssetName("testSiteSourceControl-");
            var input = ResourceDataHelper.GetBasicSiteSourceControlData();
            var lro = await container.CreateOrUpdateAsync(input);
            SiteSourcecontrol sourcecontrol1 = lro.Value;
            SiteSourcecontrol sourcecontrol2 = await container.GetAsync();
            ResourceDataHelper.AssertSiteSourceControlData(sourcecontrol1.Data, sourcecontrol2.Data);
        }
    }
}
