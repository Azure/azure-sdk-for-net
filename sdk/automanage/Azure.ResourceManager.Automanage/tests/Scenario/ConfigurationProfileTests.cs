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
        public async Task CanGetAllConfigurationProfilesInSubscription()
        {
            // create resource groups
            var rg1 = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);
            var rg2 = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collections
            var collection1 = rg1.GetConfigurationProfiles();
            var collection2 = rg2.GetConfigurationProfiles();

            // create two configuration profiles in seperate resource groups
            for (int i = 0; i < 2; i++)
            {
                await CreateConfigurationProfile(collection1, Recording.GenerateAssetName("SDKAutomanageProfile-"));
                await CreateConfigurationProfile(collection2, Recording.GenerateAssetName("SDKAutomanageProfile-"));
            }

            // fetch all profiles and count them
            var profiles = Subscription.GetConfigurationProfilesAsync().ConfigureAwait(false);

            int count = 0;
            await foreach (var item in profiles)
                count++;

            // assert
            Assert.AreEqual(4, count);
        }

        [TestCase]
        public async Task CanGetAllConfigurationProfilesInResourceGroup()
        {
            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetConfigurationProfiles();

            // create configuration profile
            for (int i = 0; i < 4; i++)
                await CreateConfigurationProfile(collection, Recording.GenerateAssetName("SDKAutomanageProfile-"));

            // fetch all profiles and count them
            var profiles = collection.GetAllAsync().ConfigureAwait(false);

            int count = 0;
            await foreach (var item in profiles)
                count++;

            // assert
            Assert.AreEqual(4, count);
        }

        [TestCase]
        public async Task CanCreateConfigurationProfile()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetConfigurationProfiles();

            // create configuration profile
            await CreateConfigurationProfile(collection, profileName);

            // fetch all profiles and count them
            var profiles = collection.GetAllAsync().ConfigureAwait(false);

            int count = 0;
            await foreach (var item in profiles)
                count++;

            //assert
            Assert.AreEqual(1, count);
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
            var profile = collection.GetAsync(profileName).Result.Value;

            // assert
            Assert.NotNull(profile);
            Assert.True(profile.HasData);
            Assert.NotNull(profile.Id);
            Assert.NotNull(profile.Id.Name);
            Assert.NotNull(profile.Data);
            Assert.NotNull(profile.Data.Configuration);
            Assert.NotNull(profile.Data.Location);
        }

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
    }
}
