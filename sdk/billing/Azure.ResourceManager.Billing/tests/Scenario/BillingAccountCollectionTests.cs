// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Billing.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Billing.Tests
{
    public class BillingAccountCollectionTests : BillingManagementTestBase
    {
        private TenantResource Tenant { get; set; }
        private BillingAccountCollection Collection { get; set; }

        public BillingAccountCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();

                AsyncPageable<TenantResource> tenantResourcesResponse = Client.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
                Collection = Tenant.GetBillingAccounts();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListBillingAccount()
        {
            var options = new BillingAccountCollectionGetAllOptions()
            {
                IncludeAll = true
            };

            AsyncPageable<BillingAccountResource> response = Collection.GetAllAsync(options);
            List<BillingAccountResource> billingAccountResources = await response.ToEnumerableAsync();

            Assert.IsNotNull(billingAccountResources);
        }
    }
}
