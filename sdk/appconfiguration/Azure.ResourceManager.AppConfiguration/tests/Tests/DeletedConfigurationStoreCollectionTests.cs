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
    public class DeletedConfigurationStoreCollectionTests : AppConfigurationClientBase
    {
        private Subscription subscription { get; set; }
        private string configurationStoreName { get; set; }

        public DeletedConfigurationStoreCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
                subscription = await ArmClient.GetDefaultSubscriptionAsync();
                string groupName = Recording.GenerateAssetName(ResourceGroupPrefix);
                ResourceGroup resGroup = (await subscription.GetResourceGroups().CreateOrUpdateAsync(true, groupName, new ResourceGroupData(Location))).Value;

                configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigurationStore configStore = (await resGroup.GetConfigurationStores().CreateOrUpdateAsync(true, configurationStoreName, configurationStoreData)).Value;
                await configStore.DeleteAsync(true);
            }
        }

        [Test]
        public async Task GetAllTest()
        {
            int count = 0;
            await foreach (var item in subscription.GetDeletedConfigurationStores().GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [Test]
        public async Task GetTest()
        {
            DeletedConfigurationStore deletedConfigurationStore = await subscription.GetDeletedConfigurationStores().GetAsync(Location, configurationStoreName);
            Assert.AreEqual(deletedConfigurationStore.Data.Name, configurationStoreName);
        }
    }
}
