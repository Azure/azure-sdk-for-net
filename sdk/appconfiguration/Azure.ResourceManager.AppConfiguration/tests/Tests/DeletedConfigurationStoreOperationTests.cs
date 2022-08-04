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
        private SubscriptionResource subscription { get; set; }
        private string configurationStoreName { get; set; }
        private DeletedConfigurationStoreResource deletedConfigurationStore { get; set; }

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
                var resGroup = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, groupName, new ResourceGroupData(Location))).Value;

                configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new AppConfigurationSku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                var configStore = (await resGroup.GetConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;
                await configStore.DeleteAsync(WaitUntil.Completed);
                deletedConfigurationStore = ArmClient.GetDeletedConfigurationStoreResource(DeletedConfigurationStoreResource.CreateResourceIdentifier(subscription.Data.SubscriptionId, Location, configurationStoreName));
            }
        }

        [Test]
        public async Task GetTest()
        {
            var getDeletedConfigurationStore = await deletedConfigurationStore.GetAsync();
            Assert.AreEqual(getDeletedConfigurationStore.Value.Data.Name, configurationStoreName);
        }

        [Test]
        public async Task PurgeTest()
        {
            _ = await deletedConfigurationStore.PurgeDeletedAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deletedConfigurationStore.GetAsync());
            Assert.AreEqual(ex.Status, 404);
        }
    }
}
