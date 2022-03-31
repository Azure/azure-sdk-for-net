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
    public class DeletedConfigurationStoreOperationTests : AppConfigurationClientBase
    {
        private Subscription subscription { get; set; }
        private string configurationStoreName { get; set; }
        private DeletedConfigurationStore deletedConfigurationStore { get; set; }

        public DeletedConfigurationStoreOperationTests(bool isAsync)
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
                deletedConfigurationStore = ArmClient.GetDeletedConfigurationStore(DeletedConfigurationStore.CreateResourceIdentifier(subscription.Data.SubscriptionId, Location, configurationStoreName));
            }
        }

        [Test]
        public async Task GetTest()
        {
            DeletedConfigurationStore getDeletedConfigurationStore = await deletedConfigurationStore.GetAsync();
            Assert.AreEqual(getDeletedConfigurationStore.Data.Name, configurationStoreName);
        }

        [Test]
        public async Task PurgeTest()
        {
            _ = await deletedConfigurationStore.PurgeDeletedAsync(true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deletedConfigurationStore.GetAsync());
            Assert.AreEqual(ex.Status, 404);
        }
    }
}
