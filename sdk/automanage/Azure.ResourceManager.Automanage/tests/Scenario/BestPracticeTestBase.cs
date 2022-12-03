// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class BestPracticeTestBase : AutomanageTestBase
    {
        public TenantResource Tenant { get; private set; }
        public BestPracticeTestBase(bool async) : base(async) { }

        [SetUp]
        protected async Task GetTenant()
        {
            var tenants = ArmClient.GetTenants();
            await foreach (var t in tenants)
            {
                if (t.Data.TenantId == Subscription.Data.TenantId)
                    Tenant = t;
            }
        }

        /// <summary>
        /// Asserts multiple values
        /// </summary>
        /// <param name="version">BestPracticeResource to assert</param>
        /// <param name="versionName">BestPracticeResource name to verify</param>
        protected void AssertValues(BestPracticeResource profile, string profileName)
        {
            Assert.NotNull(profile);
            Assert.True(profile.HasData);
            Assert.AreEqual(profileName, profile.Id.Name);
            Assert.NotNull(profile.Id);
            Assert.NotNull(profile.Data);
            Assert.NotNull(profile.Data.Configuration);
        }
    }
}
