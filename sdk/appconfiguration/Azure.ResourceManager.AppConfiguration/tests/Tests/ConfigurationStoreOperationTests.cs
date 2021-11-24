// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class ConfigurationStoreOperationTests : AppConfigurationClientBase
    {
        private ResourceGroup ResGroup { get; set; }
        private ConfigurationStore ConfigStore { get; set; }
        private string ConfigurationStoreName { get; set; }

        public ConfigurationStoreOperationTests(bool isAsync)
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
                ResGroup = await (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(groupName, new ResourceGroupData(Location))).WaitForCompletionAsync();

                ConfigurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(ConfigurationStoreName, configurationStoreData)).WaitForCompletionAsync();
            }
        }

        [Test]
        public async Task GetTest()
        {
            ConfigurationStore configurationStore = await ConfigStore.GetAsync();

            Assert.IsTrue(ConfigurationStoreName.Equals(configurationStore.Data.Name));
            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);
        }

        [Test]
        public async Task GetAvailableLocationsTest()
        {
            IEnumerable<Resources.Models.Location> locations = await ConfigStore.GetAvailableLocationsAsync();

            Assert.IsTrue(locations.Count() >= 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            await (await ConfigStore.DeleteAsync()).WaitForCompletionResponseAsync();
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetIfExistsAsync(ConfigurationStoreName);

            Assert.IsNull(configurationStore);
        }

        [Test]
        public async Task AddTagTest()
        {
            await ConfigStore.AddTagAsync("key1", "value1");
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName);
            KeyValuePair<string, string> tag = configurationStore.Data.Tags.FirstOrDefault();

            Assert.IsTrue("key1".Equals(tag.Key));
            Assert.IsTrue("value1".Equals(tag.Value));
        }

        [Test]
        public async Task SetTagTest()
        {
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await ConfigStore.SetTagsAsync(tags);
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName);

            Assert.IsTrue(configurationStore.Data.Tags.Count == 2);
        }

        [Test]
        public async Task RemoveTagTest()
        {
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await ConfigStore.SetTagsAsync(tags);
            await ConfigStore.RemoveTagAsync("key1");
            ConfigurationStore configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName);

            Assert.IsFalse(configurationStore.Data.Tags.ContainsKey("key1"));
            Assert.IsTrue(configurationStore.Data.Tags.ContainsKey("key2"));
        }

        [Test]
        public async Task RegenerateKeyTest()
        {
            List<ApiKey> keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();
            ApiKey orignalKey = keys.FirstOrDefault();

            RegenerateKeyOptions regenerateKeyOptions = new RegenerateKeyOptions() { Id = orignalKey.Id };
            ApiKey configurationStore = await ConfigStore.RegenerateKeyAsync(regenerateKeyOptions);
            keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();

            Assert.IsTrue(keys.Where(x => x.Name == orignalKey.Name).FirstOrDefault().Value != orignalKey.Value);
        }

        [Ignore("Need data plan to create key")]
        [Test]
        public async Task GetKeyValueTest()
        {
            ListKeyValueOptions listKeyValueOptions = new ListKeyValueOptions("Primary");
            KeyValue keyValue = await ConfigStore.GetKeyValueAsync(listKeyValueOptions);
            Assert.IsTrue(keyValue.Key.Equals("Primary"));
        }

        [Test]
        public async Task GetKeysTest()
        {
            List<ApiKey> keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();

            Assert.IsTrue(keys.Count >= 1);
        }

        [Test]
        public async Task UpdateTest()
        {
            ConfigurationStoreUpdateOptions configurationStoreUpdateOptions = new ConfigurationStoreUpdateOptions() { PublicNetworkAccess = PublicNetworkAccess.Enabled };
            ConfigurationStore configurationStore = await (await ConfigStore.UpdateAsync(configurationStoreUpdateOptions)).WaitForCompletionAsync();

            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Enabled);
        }
    }
}
