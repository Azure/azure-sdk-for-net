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
        private AppConfigurationStoreResource ConfigStore { get; set; }
        private string ConfigurationStoreName { get; set; }

        public ConfigurationStoreOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
                AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
                {
                    PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
                };
                ConfigStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, ConfigurationStoreName, configurationStoreData)).Value;
            }
        }

        [Test]
        public async Task GetTest()
        {
            AppConfigurationStoreResource configurationStore = await ConfigStore.GetAsync();

            Assert.IsTrue(ConfigurationStoreName.Equals(configurationStore.Data.Name));
            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == AppConfigurationPublicNetworkAccess.Disabled);
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
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { AppConfigurationStoreResource configurationStore = await ResGroup.GetAppConfigurationStores().GetAsync(ConfigurationStoreName); });

            Assert.AreEqual(404, exception.Status);
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task AddTagTest(bool useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            await ConfigStore.AddTagAsync("key1", "value1");
            AppConfigurationStoreResource configurationStore = await ResGroup.GetAppConfigurationStores().GetAsync(ConfigurationStoreName);
            KeyValuePair<string, string> tag = configurationStore.Data.Tags.FirstOrDefault();

            Assert.IsTrue("key1".Equals(tag.Key));
            Assert.IsTrue("value1".Equals(tag.Value));
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTagTest(bool useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await ConfigStore.SetTagsAsync(tags);
            AppConfigurationStoreResource configurationStore = await ResGroup.GetAppConfigurationStores().GetAsync(ConfigurationStoreName);

            Assert.IsTrue(configurationStore.Data.Tags.Count == 2);
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task RemoveTagTest(bool useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            Dictionary<string, string> tags = new Dictionary<string, string> { { "key1", "Value1" }, { "key2", "vaule2" } };
            await ConfigStore.SetTagsAsync(tags);
            await ConfigStore.RemoveTagAsync("key1");
            AppConfigurationStoreResource configurationStore = await ResGroup.GetAppConfigurationStores().GetAsync(ConfigurationStoreName);

            Assert.IsFalse(configurationStore.Data.Tags.ContainsKey("key1"));
            Assert.IsTrue(configurationStore.Data.Tags.ContainsKey("key2"));
        }

        [Test]
        public async Task RegenerateKeyTest()
        {
            List<AppConfigurationStoreApiKey> keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();
            AppConfigurationStoreApiKey orignalKey = keys.FirstOrDefault();

            AppConfigurationRegenerateKeyContent regenerateKeyOptions = new AppConfigurationRegenerateKeyContent() { Id = orignalKey.Id };
            AppConfigurationStoreApiKey configurationStore = await ConfigStore.RegenerateKeyAsync(regenerateKeyOptions);
            keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();

            Assert.IsTrue(keys.Where(x => x.Name == orignalKey.Name).FirstOrDefault().Value != orignalKey.Value);
        }

        [Ignore("Need data plan to create key")]
        [Test]
        public async Task GetKeyValueTest()
        {
            AppConfigurationKeyValueResource keyValue = (await ConfigStore.GetAppConfigurationKeyValues().ToEnumerableAsync()).FirstOrDefault();
            Assert.IsTrue(keyValue.Data.Key.Equals("Primary"));
        }

        [Test]
        public async Task GetKeysTest()
        {
            List<AppConfigurationStoreApiKey> keys = await ConfigStore.GetKeysAsync().ToEnumerableAsync();

            Assert.IsTrue(keys.Count >= 1);
        }

        [Test]
        public async Task UpdateTest()
        {
            AppConfigurationStorePatch PatchableconfigurationStoreData = new AppConfigurationStorePatch() { PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Enabled };
            AppConfigurationStoreResource configurationStore = (await ConfigStore.UpdateAsync(WaitUntil.Completed, PatchableconfigurationStoreData)).Value;

            Assert.IsTrue(configurationStore.Data.PublicNetworkAccess == AppConfigurationPublicNetworkAccess.Enabled);
        }
    }
}
