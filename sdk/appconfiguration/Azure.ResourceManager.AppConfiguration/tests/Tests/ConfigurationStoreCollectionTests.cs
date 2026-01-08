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
    public class ConfigurationStoreCollectionTests : AppConfigurationClientBase
    {
        private ResourceGroupResource ResGroup { get; set; }

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
                ResGroup = (await ArmClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
            {
                PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
            };
            AppConfigurationStoreResource configurationStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(configurationStoreName, Is.EqualTo(configurationStore.Data.Name));
                Assert.That(configurationStore.Data.PublicNetworkAccess, Is.EqualTo(AppConfigurationPublicNetworkAccess.Disabled));
            });

            configurationStore.Data.PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Enabled;
            configurationStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStore.Data)).Value;

            Assert.That(configurationStore.Data.PublicNetworkAccess, Is.EqualTo(AppConfigurationPublicNetworkAccess.Enabled));
        }

        [Test]
        public async Task CreateOrUpdateDataPlaneProxyTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(new AzureLocation("westus"), new AppConfigurationSku("Standard"))
            {
                DataPlaneProxy = new AppConfigurationDataPlaneProxyProperties()
                {
                    AuthenticationMode = DataPlaneProxyAuthenticationMode.PassThrough,
                    PrivateLinkDelegation = DataPlaneProxyPrivateLinkDelegation.Enabled,
                },
            };
            AppConfigurationStoreResource configurationStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(configurationStoreName, Is.EqualTo(configurationStore.Data.Name));
                Assert.That(configurationStore.Data.DataPlaneProxy.AuthenticationMode, Is.EqualTo(DataPlaneProxyAuthenticationMode.PassThrough));
                Assert.That(configurationStore.Data.DataPlaneProxy.PrivateLinkDelegation, Is.EqualTo(DataPlaneProxyPrivateLinkDelegation.Enabled));
            });

            configurationStore.Data.DataPlaneProxy.AuthenticationMode = DataPlaneProxyAuthenticationMode.Local;
            configurationStore.Data.DataPlaneProxy.PrivateLinkDelegation = DataPlaneProxyPrivateLinkDelegation.Disabled;
            configurationStore = (await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStore.Data)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(configurationStoreName, Is.EqualTo(configurationStore.Data.Name));
                Assert.That(configurationStore.Data.DataPlaneProxy.AuthenticationMode, Is.EqualTo(DataPlaneProxyAuthenticationMode.Local));
                Assert.That(configurationStore.Data.DataPlaneProxy.PrivateLinkDelegation, Is.EqualTo(DataPlaneProxyPrivateLinkDelegation.Disabled));
            });
        }

        [Test]
        public async Task GetTest()
        {
            string configurationStoreName = Recording.GenerateAssetName("testapp-");
            AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
            {
                PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
            };
            await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData);
            AppConfigurationStoreResource configurationStore = await ResGroup.GetAppConfigurationStores().GetAsync(configurationStoreName);

            Assert.Multiple(() =>
            {
                Assert.That(configurationStoreName, Is.EqualTo(configurationStore.Data.Name));
                Assert.That(configurationStore.Data.PublicNetworkAccess, Is.EqualTo(AppConfigurationPublicNetworkAccess.Disabled));
            });
        }

        [Test]
        public async Task GetAllTest()
        {
            string configurationStoreName1 = Recording.GenerateAssetName("testapp-");
            string configurationStoreName2 = Recording.GenerateAssetName("testapp-");
            AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
            {
                PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
            };
            await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName1, configurationStoreData);
            await ResGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName2, configurationStoreData);
            List<AppConfigurationStoreResource> configurationStores = await ResGroup.GetAppConfigurationStores().GetAllAsync().ToEnumerableAsync();

            Assert.That(configurationStores, Has.Count.EqualTo(2));
            Assert.That(configurationStores.First(x => x.Data.Name == configurationStoreName1).Data.PublicNetworkAccess, Is.EqualTo(AppConfigurationPublicNetworkAccess.Disabled));
        }
    }
}
