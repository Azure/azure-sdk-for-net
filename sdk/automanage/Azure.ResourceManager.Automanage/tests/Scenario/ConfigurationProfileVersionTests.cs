// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileVersionTests : ConfigurationProfileVersionTestBase
    {
        public ConfigurationProfileVersionTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanCreateTwoConfigurationProfileVersions()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create configuration profile
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create configuration profile versions
            var versionCollection = profile.GetConfigurationProfileVersions();
            var versions = new List<ConfigurationProfileVersionResource>();
            for (int i = 1; i <= 2; i++)
            {
                var newVersion = await CreateConfigurationProfileVersion(versionCollection, i.ToString());
                versions.Add(newVersion);
            }

            // assert
            AssertValues(versions[0], "1");
            AssertValues(versions[1], "2");
        }

        [TestCase]
        public async Task CanGetAllConfigurationProfileVersions()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create configuration profile
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create configuration profile version
            var versionCollection = profile.GetConfigurationProfileVersions();
            for (int i = 1; i <= 3; i++)
                await CreateConfigurationProfileVersion(versionCollection, i.ToString());

            // count versions
            int count = 0;
            await foreach (var v in versionCollection)
                count++;

            // assert
            Assert.AreEqual(3, count);
        }

        [TestCase]
        public async Task CanGetConfigurationProfileVersion()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create configuration profile
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create configuration profile version
            var versionCollection = profile.GetConfigurationProfileVersions();
            await CreateConfigurationProfileVersion(versionCollection, "1");
            var version = await versionCollection.GetAsync("1");

            // assert
            AssertValues(version, "1");
        }

        [TestCase]
        public async Task CanMakeAssignmentWithConfigurationProfileVersion()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");
            string vmName = "sdk-test-vm";

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create configuration profile
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create configuration profile version
            var versionCollection = profile.GetConfigurationProfileVersions();
            await CreateConfigurationProfileVersion(versionCollection, "1");
            var version = await versionCollection.GetAsync("1");

            // create vm & assignment
            var vmId = await CreateVirtualMachineFromTemplate(vmName, rg);
            var assignment = await CreateAssignment(vmId, version.Value.Id);

            // assert
            Assert.True(assignment.HasData);
            Assert.NotNull(assignment.Data.Name);
            Assert.NotNull(assignment.Data.Id);
            Assert.AreEqual(vmId, assignment.Data.Properties.TargetId);
        }

        [TestCase]
        public async Task CanDeleteConfigurationProfileVersion()
        {
            // arrange
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);

            // create configuration profile
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create configuration profile version
            var versionCollection = profile.GetConfigurationProfileVersions();
            var version = await CreateConfigurationProfileVersion(versionCollection, "1");

            // delete version
            var res = await version.DeleteAsync(WaitUntil.Completed);
            var statusCode = res.WaitForCompletionResponseAsync().Result.Status;

            // count versions
            int count = 0;
            await foreach (var v in versionCollection)
                count++;

            // assert
            Assert.AreEqual(0, count);
            Assert.AreEqual(200, statusCode);
        }
    }
}
