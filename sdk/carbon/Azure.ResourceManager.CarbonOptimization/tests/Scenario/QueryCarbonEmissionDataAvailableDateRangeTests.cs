// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CarbonOptimization.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
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
            CarbonEmissionDataAvailableDateRange result = await Tenant.QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync();
            Assert.IsNotNull(result);

            // validate the result startDate and endDate format is like 'yyyy-MM-dd'
            Assert.IsNotNull(result.StartDate);
            Assert.IsNotNull(result.EndDate);

            string format = "yyyy-MM-dd";
            bool isValid = DateTime.TryParseExact(
                result.StartDate,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate
            );
            Assert.IsTrue(isValid, $"StartDate '{result.StartDate}' is not in the expected format '{format}'.");

            isValid = DateTime.TryParseExact(
                result.EndDate,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate
            );
            Assert.IsTrue(isValid, $"EndDate '{result.EndDate}' is not in the expected format '{format}'.");
        }
    }
}
