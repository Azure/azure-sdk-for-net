// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Castle.Core.Resource;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class AppServiceConfigurationDictionaryTest : AppServiceTestBase
    {
        public AppServiceConfigurationDictionaryTest(bool isAsync)
    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        //Manual operation needed to create website/function resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task WebSiteResource_Test()
        {
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
            ResourceGroupResource rg = await rgCollection.GetAsync("Lwm_Rg");
            WebSiteCollection webSiteCollection = rg.GetWebSites();
            WebSiteResource webSiteResource = await webSiteCollection.GetAsync("FunctionApp1Lwm");
            AppServiceConfigurationDictionary appDic = await webSiteResource.GetApplicationSettingsAsync();
            AppServiceConfigurationDictionary metaData = await webSiteResource.GetMetadataAsync();
            Assert.NotZero(appDic.Properties.Count);
            Assert.NotNull(metaData.Properties);
        }

        //Manual operation needed to create website/function resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task WebSiteSlotResource_Test()
        {
            var wbSiteSlotID = WebSiteSlotResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, "Lwm_Rg", "testSite01lwm", "siteSlot01");
            WebSiteSlotResource wsSlotResource = Client.GetWebSiteSlotResource(wbSiteSlotID);
            AppServiceConfigurationDictionary appset = await wsSlotResource.GetApplicationSettingsSlotAsync();
            Assert.GreaterOrEqual(appset.Properties.Count, 1);
        }

        //Manual operation needed to create website/function resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task SiteFunctionResource_Test()
        {
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
            ResourceGroupResource rg = await rgCollection.GetAsync("Lwm_Rg");
            WebSiteCollection webSiteCollection = rg.GetWebSites();
            WebSiteResource webSiteResource = await webSiteCollection.GetAsync("FunctionApp1Lwm");
            SiteFunctionResource siteFuncResource = await webSiteResource.GetSiteFunctionAsync("HttpTrigger1");
            var funtionKeys = (await siteFuncResource.GetFunctionKeysAsync()).Value;
            Assert.GreaterOrEqual(funtionKeys.Properties.Count, 1);
        }

        //Manual operation needed to create website/function resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task SiteSlotFunctionResource_Test()
        {
            var subId = DefaultSubscription.Data.SubscriptionId;
            var siteSlotFunction = SiteSlotFunctionResource.CreateResourceIdentifier(subId, "Lwm_Rg", "FunctionApp1Lwm", "FunctionApp1Slot", "HttpTrigger1");
            var slot = Client.GetSiteSlotFunctionResource(siteSlotFunction);
            var funtionKeys = (await slot.GetFunctionKeysSlotAsync()).Value;
            Assert.NotZero(funtionKeys.Properties.Count);
        }

        //Manual operation needed to create website/function resource, get it from existing one.
        [TestCase]
        [RecordedTest]
        public async Task StaticSiteResource_Test()
        {
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
            ResourceGroupResource rg = await rgCollection.GetAsync("staticweb006_group");
            StaticSiteCollection staticSiteResource = rg.GetStaticSites();
            StaticSiteResource staticRes = await staticSiteResource.GetAsync("staticweb006");
            AppServiceConfigurationDictionary staticResour1 = await staticRes.CreateOrUpdateFunctionAppSettingsAsync(new AppServiceConfigurationDictionary()
            {
                Properties = { { "key1", "val1" }, { "key2", "val2" }, { "key3", "val3" } },
            });
            AppServiceConfigurationDictionary staticResour2 = await staticRes.CreateOrUpdateAppSettingsAsync(new AppServiceConfigurationDictionary()
            {
                Properties = { { "key11", "val11" }, { "key22", "val22" }, { "key33", "val33" } },
            });
            AppServiceConfigurationDictionary appset = await staticRes.GetAppSettingsAsync();
            StaticSiteBuildCollection sbc = staticRes.GetStaticSiteBuilds();
            var allStaticBuilds = sbc.GetAllAsync().ToEnumerableAsync();
            var staticSiteBuild = (await staticRes.GetStaticSiteBuildAsync("2")).Value;
            await staticSiteBuild.CreateOrUpdateAppSettingsAsync(new AppServiceConfigurationDictionary()
            {
                Properties = { { "key1", "val1" }, { "key2", "val2" }, { "key3", "val3" } },
            });
            var appsettStaticBuild = (await staticSiteBuild.GetStaticSiteBuildAppSettingsAsync()).Value;

            await staticSiteBuild.CreateOrUpdateFunctionAppSettingsAsync(new AppServiceConfigurationDictionary()
            {
                Properties = { { "key1", "val1" }, { "key2", "val2" }, { "key3", "val3" } },
            });
            var appsettStaticFunctionBuild = (await staticSiteBuild.GetStaticSiteBuildAppSettingsAsync()).Value;
            Assert.NotZero(staticResour1.Properties.Count);
            Assert.NotZero(staticResour2.Properties.Count);
            Assert.NotZero(appset.Properties.Count);
            Assert.NotZero(appsettStaticBuild.Properties.Count);
            Assert.NotZero(appsettStaticFunctionBuild.Properties.Count);
        }
    }
}
