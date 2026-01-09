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
        public async Task CanGetConfigurationProfile()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetAutomanageConfigurationProfiles();

            // create configuration profile
            await CreateConfigurationProfile(collection, profileName);

            // fetch new configuration profile
            var profile = collection.GetAsync(profileName).Result.Value;

            // assert
            Assert.That(profile, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(profile.HasData, Is.True);
                Assert.That(profile.Id, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(profile.Id.Name, Is.Not.Null);
                Assert.That(profile.Data, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(profile.Data.Configuration, Is.Not.Null);
                Assert.That(profile.Data.Location, Is.Not.Null);
            });
        }

        [TestCase]
        public async Task CanGetAllConfigurationProfilesInResourceGroup()
        {
            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetAutomanageConfigurationProfiles();

            // create configuration profile
            for (int i = 0; i < 4; i++)
                await CreateConfigurationProfile(collection, Recording.GenerateAssetName("SDKAutomanageProfile-"));

            // fetch all profiles and count them
            var profiles = collection.GetAllAsync().ConfigureAwait(false);

            int count = 0;
            await foreach (var item in profiles)
                count++;

            // assert
            Assert.That(count, Is.EqualTo(4));
        }

        [TestCase]
        public async Task CanCreateConfigurationProfile()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetAutomanageConfigurationProfiles();

            // create configuration profile
            await CreateConfigurationProfile(collection, profileName);

            // fetch all profiles and count them
            var profiles = collection.GetAllAsync().ConfigureAwait(false);

            int count = 0;
            await foreach (var item in profiles)
                count++;

            //assert
            Assert.That(count, Is.EqualTo(1));
        }

        [TestCase]
        public async Task CanDeleteConfigurationProfile()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // create resource group
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var collection = rg.GetAutomanageConfigurationProfiles();

            // create configuration profile
            await CreateConfigurationProfile(collection, profileName);

            // delete configuration profile
            var deletedProfile = await collection.GetAsync(profileName);
            await deletedProfile.Value.DeleteAsync(WaitUntil.Completed);

            // attempt to fetch deleted profile
            var exists = collection.ExistsAsync(profileName).Result.Value;

            // assert
            Assert.That(exists, Is.False);
        }
    }
}
