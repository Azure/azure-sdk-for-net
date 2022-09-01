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
    }
}
