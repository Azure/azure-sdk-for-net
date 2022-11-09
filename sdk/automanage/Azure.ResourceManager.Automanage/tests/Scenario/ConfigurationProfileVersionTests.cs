// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileVersionTests : AutomanageTestBase
    {
        public ConfigurationProfileVersionTests(bool async) : base(async) { }
        /*
         things to test:
            - can create second version
            - can get version
            - can get all versions
            - can make assignment with new version
         */

        private void AssertValues(ConfigurationProfileVersionResource version, string versionName)
        {
            Assert.NotNull(version);
            Assert.True(version.HasData);
            Assert.NotNull(version.Id);
            Assert.NotNull(version.Id.Name);
            Assert.NotNull(version.Data);
            Assert.NotNull(version.Data.Configuration);
            Assert.NotNull(version.Data.Location);
            Assert.AreEqual(versionName, version.Id.Name);
        }

        [TestCase]
        public async Task CanCreateTwoConfigurationProfileVersions()
        {
            // arrange
            string version2Name = "2";
            string version3Name = "3";
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");

            // act
            var rg = await CreateResourceGroup("SDKAutomanage-", DefaultLocation);
            var profileCollection = rg.GetConfigurationProfiles();
            var profile = await CreateConfigurationProfile(profileCollection, profileName);
            var versionCollection = profile.GetConfigurationProfileVersions();
            var version2 = await CreateConfigurationProfileVersion(versionCollection, version2Name);
            var version3 = await CreateConfigurationProfileVersion(versionCollection, version3Name);

            // assert
            AssertValues(version2, version2Name);
            AssertValues(version3, version3Name);
        }
    }
}
