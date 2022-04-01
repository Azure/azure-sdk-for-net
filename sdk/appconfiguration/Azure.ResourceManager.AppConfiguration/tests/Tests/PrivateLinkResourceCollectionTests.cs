// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class PrivateLinkResourceCollectionTests : AppConfigurationClientBase
    {
        private ResourceGroupResource ResGroup { get; set; }
        private ConfigurationStoreResource ConfigStore { get; set; }

        public PrivateLinkResourceCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
                string groupName = Recording.GenerateAssetName(ResourceGroupPrefix);
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;
            }
        }

        [Ignore("Error resource id without '/' in the beginning")]
        [Test]
        public async Task GetTest()
        {
            PrivateLinkResource linkResource = await ConfigStore.GetPrivateLinkResources().GetAsync("configurationStores");

            Assert.NotNull(linkResource);
        }

        [Ignore("Error resource id without '/' in the beginning")]
        [Test]
        public async Task GetAllTest()
        {
            List<PrivateLinkResource> linkResources = await ConfigStore.GetPrivateLinkResources().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(linkResources.Count > 0);
        }

        [Ignore("Error resource id without '/' in the beginning")]
        [Test]
        public async Task ExistsTest()
        {
            bool linkResource = await ConfigStore.GetPrivateLinkResources().ExistsAsync("configurationStores");

            Assert.IsTrue(linkResource);
        }
    }
}
