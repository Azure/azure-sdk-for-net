﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class ConfigurationStoreCollectionTests : AppConfigurationClientBase
    {
        private ResourceGroup ResGroup { get; set; }

        public ConfigurationStoreCollectionTests(bool isAsync)
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
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(true, groupName, new ResourceGroupData(Location))).Value;
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            ConfigurationStore configurationStore = (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName, configurationStoreData)).Value;

            Assert.IsTrue(configurationStoreName.Equals(configurationStore.Data.Name));
            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);

            configurationStore.Data.PublicNetworkAccess = PublicNetworkAccess.Enabled;
            configurationStore = (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName, configurationStore.Data)).Value;

            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Enabled);
        }

        [Test]
        public async Task GetTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName, configurationStoreData);
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetAsync(configurationStoreName);

            Assert.IsTrue(configurationStoreName.Equals(configurationStore.Data.Name));
            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);
        }

        [Test]
        public async Task GetAllTest()
        {
            string configurationStoreName1 = Recording.GenerateAssetName("testapp-");
            string configurationStoreName2 = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName1, configurationStoreData);
            await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName2, configurationStoreData);
            List<ConfigurationStore> configurationStores = await ResGroup.GetConfigurationStores().GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(configurationStores.Count == 2);
            Assert.IsTrue(configurationStores.First(x => x.Data.Name == configurationStoreName1).Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);
        }

        [Test]
        public async Task GetIfExistsTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName, configurationStoreData);
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetIfExistsAsync(configurationStoreName);

            Assert.IsTrue(configurationStore.Data.Name == configurationStoreName);

            configurationStore = await ResGroup.GetConfigurationStores().GetIfExistsAsync("foo");

            Assert.IsNull(configurationStore);
        }
    }
}
