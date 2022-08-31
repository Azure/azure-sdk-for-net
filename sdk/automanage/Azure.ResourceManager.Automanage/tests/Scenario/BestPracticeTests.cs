// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class BestPracticeTests : AutomanageTestBase
    {
        public BestPracticeTests(bool async) : base(async) { }

        private async Task<BestPracticeResource> GetBestPracticesProfile(string profileName)
        {
            // fetch tenant collection
            var tenants = ArmClient.GetTenants();

            // fetch Azure best practices production profile
            BestPracticeResource profile = null;
            await foreach (var tenant in tenants)
            {
                if (tenant.Data.TenantId == Subscription.Data.TenantId)
                    profile = tenant.GetBestPracticeAsync(profileName).Result;
            }

            return profile;
        }

        [TestCase]
        public async Task CanGetBestPracticesProductionProfile()
        {
            string profileName = "AzureBestPracticesProduction";
            var profile = await GetBestPracticesProfile(profileName);

            // assert
            Assert.NotNull(profile);
            Assert.True(profile.HasData);
            Assert.AreEqual(profileName, profile.Id.Name);
            Assert.NotNull(profile.Id);
            Assert.NotNull(profile.Data);
            Assert.NotNull(profile.Data.Configuration);
        }

        [TestCase]
        public async Task CanGetBestPracticesDevTestProfile()
        {
            string profileName = "AzureBestPracticesDevTest";
            var profile = await GetBestPracticesProfile(profileName);

            // assert
            Assert.NotNull(profile);
            Assert.True(profile.HasData);
            Assert.AreEqual(profileName, profile.Id.Name);
            Assert.NotNull(profile.Id);
            Assert.NotNull(profile.Data);
            Assert.NotNull(profile.Data.Configuration);
        }
    }
}
