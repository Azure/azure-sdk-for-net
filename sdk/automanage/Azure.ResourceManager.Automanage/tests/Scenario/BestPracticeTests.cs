// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class BestPracticeTests : AutomanageTestBase
    {
        private TenantResource tenant;
        public BestPracticeTests(bool async) : base(async) { }

        [SetUp]
        protected async Task GetTenant()
        {
            var tenants = ArmClient.GetTenants();
            await foreach (var t in tenants)
            {
                if (t.Data.TenantId == Subscription.Data.TenantId)
                    tenant = t;
            }
        }

        [TestCase]
        public async Task CanGetBestPracticesProductionProfile()
        {
            string profileName = "AzureBestPracticesProduction";

            // fetch tenant collection
            var collection = tenant.GetBestPractices();
            var profile = await collection.GetAsync(profileName);

            // assert
            Assert.NotNull(profile);
            Assert.True(profile.Value.HasData);
            Assert.AreEqual(profileName, profile.Value.Id.Name);
            Assert.NotNull(profile.Value.Id);
            Assert.NotNull(profile.Value.Data);
            Assert.NotNull(profile.Value.Data.Configuration);
        }

        [TestCase]
        public async Task CanGetBestPracticesDevTestProfile()
        {
            string profileName = "AzureBestPracticesDevTest";

            // fetch tenant collection
            var collection = tenant.GetBestPractices();
            var profile = await collection.GetAsync(profileName);

            // assert
            Assert.NotNull(profile);
            Assert.True(profile.Value.HasData);
            Assert.AreEqual(profileName, profile.Value.Id.Name);
            Assert.NotNull(profile.Value.Id);
            Assert.NotNull(profile.Value.Data);
            Assert.NotNull(profile.Value.Data.Configuration);
        }

        [TestCase]
        public async Task CanGetAllBestPracticesProfiles()
        {
            // fetch tenant collection
            var collection = tenant.GetBestPractices();
            var profiles = collection.GetAllAsync();

            int count = 0;
            await foreach (var profile in profiles)
                count++;

            // assert
            // there are two best practices profiles, Production & DevTest
            Assert.AreEqual(2, count);
        }
    }
}
