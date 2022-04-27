// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class ConfigurationStoreOperationTests : AppConfigurationClientBase
    {
        private ResourceGroupResource ResGroup { get; set; }
        private ConfigurationStoreResource ConfigStore { get; set; }
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
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;

                ConfigurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, ConfigurationStoreName, configurationStoreData)).Value;
            }
        }

        [Test]
        public async Task GetTest()
        {
            ConfigurationStoreResource configurationStore = await ConfigStore.GetAsync();

            Assert.IsTrue(ConfigurationStoreName.Equals(configurationStore.Data.Name));
            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Disabled);
        }

        [Test]
        public async Task GetAvailableLocationsTest()
        {
            IEnumerable<AzureLocation> locations = (await ConfigStore.GetAvailableLocationsAsync()).Value;

            Assert.IsTrue(locations.Count() >= 0);
        }

        [Test]
        public async Task DeleteTest()
        {
            await ConfigStore.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { ConfigurationStoreResource configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName); });

            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        public async Task AddTagTest()
        {
            await ConfigStore.AddTagAsync("key1", "value1");
            ConfigurationStoreResource configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName);
            KeyValuePair<string, string> tag = configurationStore.Data.Tags.FirstOrDefault();

            Assert.IsTrue("key1".Equals(tag.Key));
            Assert.IsTrue("value1".Equals(tag.Value));
        }

        [Test]
        public async Task SetTagTest()
        {
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await ConfigStore.SetTagsAsync(tags);
            ConfigurationStoreResource configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName);

            Assert.IsTrue(configurationStore.Data.Tags.Count == 2);
        }

        [Test]
        public async Task RemoveTagTest()
        {
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await ConfigStore.SetTagsAsync(tags);
            await ConfigStore.RemoveTagAsync("key1");
            ConfigurationStoreResource configurationStore = await ResGroup.GetConfigurationStores().GetAsync(ConfigurationStoreName);

            Assert.IsFalse(configurationStore.Data.Tags.ContainsKey("key1"));
            Assert.IsTrue(configurationStore.Data.Tags.ContainsKey("key2"));
        }

        [Test]
        public async Task RegenerateKeyTest()
        {
            List<ApiKey> keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();
            ApiKey orignalKey = keys.FirstOrDefault();

            RegenerateKeyContent regenerateKeyOptions = new RegenerateKeyContent() { Id = orignalKey.Id };
            ApiKey configurationStore = await ConfigStore.RegenerateKeyAsync(regenerateKeyOptions);
            keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();

            Assert.IsTrue(keys.Where(x => x.Name == orignalKey.Name).FirstOrDefault().Value != orignalKey.Value);
        }

        [Ignore("Need data plan to create key")]
        [Test]
        public async Task GetKeyValueTest()
        {
            KeyValueResource keyValue = (await ConfigStore.GetKeyValues().ToEnumerableAsync()).FirstOrDefault();
            Assert.IsTrue(keyValue.Data.Key.Equals("Primary"));
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
            ConfigurationStorePatch PatchableconfigurationStoreData = new ConfigurationStorePatch() { PublicNetworkAccess = PublicNetworkAccess.Enabled };
            ConfigurationStoreResource configurationStore = (await ConfigStore.UpdateAsync(WaitUntil.Completed, PatchableconfigurationStoreData)).Value;

            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == PublicNetworkAccess.Enabled);
        }
    }
}
