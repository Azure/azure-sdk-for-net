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
        private async Task<WebSiteCollection> GetSiteCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetWebSites();
        }

        public async Task<WebSiteResource> SiteCreateOrUpdate()
        {
            var webSiteResources = await GetSiteCollectionAsync();
            var name = Recording.GenerateAssetName("testSite");
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await webSiteResources.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var site = lro.Value;
            return site;
        }
        [TestCase]
        [RecordedTest]
        [Ignore("could note create the function trigger using the code below")]
        public async Task FunctionTriggers()
        {
            var rg = await CreateResourceGroupAsync();

            //create websiteresource
            var appName = Recording.GenerateAssetName("functest-");
            var appData = new WebSiteData(AzureLocation.EastUS)
            {
                ContainerSize = 1536,
                ClientCertMode = ClientCertMode.Required,
                Kind = "functionapp",
                IsEnabled = true,
                KeyVaultReferenceIdentity = "SystemAssigned"
            };
            var app = (await rg.GetWebSites().CreateOrUpdateAsync(WaitUntil.Completed, appName, appData)).Value;
            var getApp = (await app.GetAsync()).Value;

            var siteFuncCollection = getApp.GetSiteFunctions();
            var str1 = """{"name":"HttpTrigger0407","entryPoint":"Wicresoft0407.Function.HttpTrigger0407.Run","scriptFile":"06AzureFunction.dll","language":"dotnet-isolated","functionDirectory":"","bindings":[{"name":"req","type":"httpTrigger","direction":"In","authLevel":"Function","methods":["get","post"]},{"name":"$return","type":"http","direction":"Out"}]}""";
            FunctionEnvelopeData functionEnvelopeData = new FunctionEnvelopeData { Config = BinaryData.FromObjectAsJson(str1) };
            await siteFuncCollection.CreateOrUpdateAsync(WaitUntil.Completed, $"HttpTrigger0407", functionEnvelopeData);
            var result = await getApp.SyncFunctionTriggersAsync();
            Assert.IsNotNull(result);
        }

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
        [TestCase]
        [RecordedTest]
        public async Task WebSiteSlotResource_Test()
        {
            var wbSiteSlotID = WebSiteSlotResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, "Lwm_Rg", "testSite01lwm", "siteSlot01");
            WebSiteSlotResource wsSlotResource = Client.GetWebSiteSlotResource(wbSiteSlotID);
            AppServiceConfigurationDictionary appset = await wsSlotResource.GetApplicationSettingsSlotAsync();
            Assert.GreaterOrEqual(appset.Properties.Count, 1);
        }
        [TestCase]
        [RecordedTest]
        public async Task SiteFunctionResource_Test()
        {
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
            ResourceGroupResource rg = await rgCollection.GetAsync("Lwm_Rg");
            WebSiteCollection webSiteCollection = rg.GetWebSites();
            WebSiteResource webSiteResource = await webSiteCollection.GetAsync("FunctionApp1Lwm");
            SiteFunctionResource siteFuncResource = await webSiteResource.GetSiteFunctionAsync("HttpTrigger1");
            IReadOnlyDictionary<string, string> funtionKeys = (await siteFuncResource.GetFunctionKeysAsDictionaryAsync()).Value;
            Assert.GreaterOrEqual(funtionKeys.Count, 1);
        }
        [TestCase]
        [RecordedTest]
        public async Task SiteSlotFunctionResource_Test()
        {
            var subId = DefaultSubscription.Data.SubscriptionId;
            var siteSlotFunction = SiteSlotFunctionResource.CreateResourceIdentifier(subId, "Lwm_Rg", "FunctionApp1Lwm", "FunctionApp1Slot", "HttpTrigger1");
            var slot = Client.GetSiteSlotFunctionResource(siteSlotFunction);
            IReadOnlyDictionary<string, string> funtionKeys = (await slot.GetFunctionKeysSlotAsDictionaryAsync()).Value;
            Assert.NotZero(funtionKeys.Count);
        }
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
