// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileTests : AutomanageTestBase
    {
        public ConfigurationProfileTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanDeleteConfigurationProfile()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetConfigurationProfiles();

            // create configuration profile
            await CreateConfigurationProfile(collection, profileName);

            // delete configuration profile
            var deletedProfile = await collection.GetAsync(profileName);
            await deletedProfile.Value.DeleteAsync(WaitUntil.Completed);

            // attempt to fetch deleted profile
            var exists = collection.ExistsAsync(profileName).Result.Value;

            // assert
            Assert.False(exists);
        }

        [TestCase]
        public async Task CanGetConfigurationProfile()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetConfigurationProfiles();

            // create configuration profile
            await CreateConfigurationProfile(collection, profileName);

            // fetch new configuration profile
            var profile = await collection.GetAsync(profileName);

            // assert
            VerifyConfigurationProfileProperties(profile);
        }
    }
}
