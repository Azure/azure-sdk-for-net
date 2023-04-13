// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Consumption.Tests.Scenario
{
    internal class BillingPeriodTests : ConsumptionManagementTestBase
    {
        protected ResourceIdentifier _billingAccount;

        public BillingPeriodTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _billingAccount = new ResourceIdentifier("<reservation-id>");
        }

        [RecordedTest]
        [Ignore("Have not enough permission check billing account")]
        public async Task GetTenantBillingPeriodConsumption()
        {
            var tenantBillingPeriodConsumption = Client.GetTenantBillingPeriodConsumptionResource(_billingAccount);
            var consumptionBalance = await tenantBillingPeriodConsumption.GetBalanceAsync();
            Assert.IsNotNull(consumptionBalance);
            Assert.IsNotEmpty(consumptionBalance.Value.Currency);
            Assert.GreaterOrEqual(0, consumptionBalance.Value.BeginningBalance);
            Assert.GreaterOrEqual(0, consumptionBalance.Value.EndingBalance);
        }

        [RecordedTest]
        [Ignore("Have not enough permission check billing account")]
        public async Task GetSubscriptionBillingPeriodConsumption()
        {
            var subscriptionBillingPeriodConsumption = Client.GetSubscriptionBillingPeriodConsumptionResource(_billingAccount);
            var PriceSheetResult = await subscriptionBillingPeriodConsumption.GetPriceSheetAsync();
            Assert.IsNotNull(PriceSheetResult);
            Assert.IsNotEmpty(PriceSheetResult.Value.Pricesheets.First().BillingPeriodId);
            Assert.IsNotNull(PriceSheetResult.Value.Pricesheets.First().MeterId);
        }
    }
}
