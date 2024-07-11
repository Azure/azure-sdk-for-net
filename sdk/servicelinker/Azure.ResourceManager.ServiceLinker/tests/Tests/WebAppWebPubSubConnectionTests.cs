// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceLinker.Models;
using Azure.ResourceManager.WebPubSub;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceLinker.Tests.Tests
{
    [TestFixture]
    public class WebAppWebPubSubConnectionTests : ServiceLinkerTestBase
    {
        public WebAppWebPubSubConnectionTests() : base(true)
        {
            BodyKeySanitizers.Add(new Core.TestFramework.Models.BodyKeySanitizer("$..value") { Regex = "AccessKey=.*" });
        }

        [SetUp]
        public async Task Init()
        {
            await InitializeClients();
        }

        [TestCase]
        public async Task WebAppWebPubSubConnectionCRUD()
        {
            string resourceGroupName = Recording.GenerateAssetName("SdkRg");
            string webAppName = Recording.GenerateAssetName("SdkWeb");
            string webpubsubName = Recording.GenerateAssetName("SdkWebPubSub");
            string linkerName = Recording.GenerateAssetName("SdkLinker");

            // create resource group
            await ResourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new Resources.ResourceGroupData(DefaultLocation));
            ResourceGroupResource resourceGroup = await ResourceGroups.GetAsync(resourceGroupName);

            // create web app
            WebSiteCollection webSites = resourceGroup.GetWebSites();
            await webSites.CreateOrUpdateAsync(WaitUntil.Completed, webAppName, new WebSiteData(DefaultLocation));
            WebSiteResource webapp = await webSites.GetAsync(webAppName);

            // create webpubsub
            WebPubSubCollection webPubSubs = resourceGroup.GetWebPubSubs();
            WebPubSubData webPubSubData = new WebPubSubData(DefaultLocation)
            {
                Sku = new WebPubSub.Models.BillingInfoSku("Standard_S1"),
                LiveTraceConfiguration = new WebPubSub.Models.LiveTraceConfiguration(),
                NetworkAcls = new WebPubSub.Models.WebPubSubNetworkAcls
                {
                    PublicNetwork = new WebPubSub.Models.PublicNetworkAcls(),
                },
            };
            webPubSubData.LiveTraceConfiguration.Categories.Clear();
            webPubSubData.NetworkAcls.PublicNetwork.Allow.Clear();
            webPubSubData.NetworkAcls.PublicNetwork.Deny.Clear();
            webPubSubData.ResourceLogCategories.Clear();
            await webPubSubs.CreateOrUpdateAsync(WaitUntil.Completed, webpubsubName, webPubSubData);
            WebPubSubResource webPubSub = await webPubSubs.GetAsync(webpubsubName);

            // create service linker
            LinkerResourceCollection linkers = webapp.GetLinkerResources();
            var linkerData = new LinkerResourceData
            {
                TargetService = new Models.AzureResourceInfo
                {
                    Id = webPubSub.Id,
                },
                AuthInfo = new SecretAuthInfo(),
                ClientType = LinkerClientType.Dotnet,
            };
            await linkers.CreateOrUpdateAsync(WaitUntil.Completed, linkerName, linkerData);

            // list service linker
            var linkerResources = await linkers.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, linkerResources.Count);
            Assert.AreEqual(linkerName, linkerResources[0].Data.Name);

            // get service linker
            LinkerResource linker = await linkers.GetAsync(linkerName);
            Assert.IsTrue(linker.Id.ToString().StartsWith(webapp.Id.ToString(), StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(webPubSub.Id, (linker.Data.TargetService as AzureResourceInfo).Id);
            Assert.AreEqual(LinkerAuthType.Secret, linker.Data.AuthInfo.AuthType);

            // get service linker configurations
            SourceConfigurationResult configurations = await linker.GetConfigurationsAsync();
            foreach (var configuration in configurations.Configurations)
            {
                Assert.IsNotNull(configuration.Name);
                Assert.IsNotNull(configuration.Value);
            }

            // delete service linker
            var operation = await linker.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
