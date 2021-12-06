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
    public class PrivateLinkResourceOperationTests : AppConfigurationClientBase
    {
        private ResourceGroup ResGroup { get; set; }
        private ConfigurationStore ConfigStore { get; set; }
        private PrivateLinkResource LinkResource { get; set; }

        public PrivateLinkResourceOperationTests(bool isAsync)
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
                string configurationStoreName = Recording.GenerateAssetName("testapp-");
                ConfigurationStoreData configurationStoreData = new ConfigurationStoreData(Location, new Models.Sku("Standard"))
                {
                    PublicNetworkAccess = PublicNetworkAccess.Disabled
                };
                ConfigStore = await (await ResGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName, configurationStoreData)).WaitForCompletionAsync();
                LinkResource = await ConfigStore.GetPrivateLinkResources().GetAsync("configurationStores");
            }
        }

        [Ignore("Error resource id without '/' in the beginning")]
        [Test]
        public async Task GetTest()
        {
            PrivateLinkResource linkResource = await LinkResource.GetAsync();

            Assert.IsTrue(LinkResource.Data.Name.Equals(linkResource.Data.Name));
        }

        [Ignore("Error resource id without '/' in the beginning")]
        [Test]
        public async Task GetAvailableLocationsTest()
        {
            IEnumerable<Resources.Models.Location> locations = await LinkResource.GetAvailableLocationsAsync();

            Assert.IsTrue(locations.Count() >= 0);
        }
    }
}
