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

namespace Azure.ResourceManager.Consumption.Tests
{
    internal class PriceSheetTests : ConsumptionManagementTestBase
    {
        protected ResourceIdentifier _scope;
        protected const string billingPeriodName = "202303";

        public PriceSheetTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _scope = new ResourceIdentifier($"{DefaultSubscription.Id}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}");
        }

        [RecordedTest]
        [Ignore("Cost management data is not supported for current subscription")]
        public async Task GetSubscriptionBillingPeriodConsumption()
        {
            var subscriptionBillingPeriodConsumption = Client.GetSubscriptionBillingPeriodConsumptionResource(_scope);
            var priceSheetResult = await subscriptionBillingPeriodConsumption.GetPriceSheetAsync();
            Assert.IsNotNull(priceSheetResult);
            Assert.IsNotEmpty(priceSheetResult.Value.Pricesheets.First().BillingPeriodId);
            Assert.IsNotNull(priceSheetResult.Value.Pricesheets.First().MeterId);
        }
    }
}
