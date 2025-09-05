// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CarbonOptimization.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.CarbonOptimization.Tests
{
    public class QueryCarbonEmissionDataAvailableDateRangeTests : CarbonOptimizationManagementTestBase
    {
        public QueryCarbonEmissionDataAvailableDateRangeTests(bool isAsync)
            : base(isAsync)
        {
        }

        private TenantResource Tenant { get; set; }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                AsyncPageable<TenantResource> tenantResourcesResponse = Client.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestQueryCarbonEmissionDataAvailableDateRange()
        {
            // invoke the operation
            CarbonEmissionAvailableDateRange result = await Tenant.QueryCarbonEmissionAvailableDateRangeAsync();
            Assert.IsNotNull(result);

            // validate the result startDate and endDate format is like 'yyyy-MM-dd'
            Assert.IsNotNull(result.StartOn);
            Assert.IsNotNull(result.EndOn);
        }
    }
}
