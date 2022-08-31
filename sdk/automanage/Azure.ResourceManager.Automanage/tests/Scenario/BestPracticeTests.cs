// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class BestPracticeTests : AutomanageTestBase
    {
        public BestPracticeTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanGetBestPracticesProductionProfile()
        {
            string profileName = "AzureBestPracticesProduction";

            // fetch tenant collection
            var tenants = ArmClient.GetTenants();

            // fetch Azure best practices production profile
            BestPracticeResource profile = null;
            await foreach (var tenant in tenants)
            {
                if (tenant.Data.TenantId == Subscription.Data.TenantId)
                    profile = tenant.GetBestPracticeAsync(profileName).Result;
            }

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
