// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class PricesheetTests : TestBase
    {
        protected const string subscriptionId = "a98d6dc5-eb8f-46cf-8938-f1fb08f03706";
        protected const string subscriptionIdTest = "1caaa5a3-2b66-438e-8ab4-bce37d518c5d";
        protected const string billingPeriodName = "201712";
        protected const int top = 3;

        [Fact]
        public void PriceSheetGetTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                var priceSheet = consumptionMgmtClient.PriceSheet.Get();
                ValidateProperties(priceSheet);
            }
        }

        [Fact]
        public void PriceSheetGetByBillingPeriodTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                var priceSheet = consumptionMgmtClient.PriceSheet.GetByBillingPeriod(billingPeriodName);
                ValidateProperties(priceSheet);
            }
        }

        [Fact]
        public void PriceSheetGetTopTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionIdTest;
                var priceSheet = consumptionMgmtClient.PriceSheet.Get(top: top);
                ValidateProperties(priceSheet, true);
            }
        }

        private static void ValidateProperties(PriceSheetResult item, bool checkTop = false, bool checkMeterDetails = false)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.NextLink);
            Assert.NotNull(item.Pricesheets);

            Assert.True(item.Pricesheets.Any());

            if (checkTop)
            {
                Assert.Equal(top, item.Pricesheets.Count);
            }

            foreach (var p in item.Pricesheets)
            {
                Assert.NotNull(p.BillingPeriodId);
                Assert.NotNull(p.CurrencyCode);
                Assert.NotNull(p.MeterId);
                Assert.NotNull(p.PartNumber);
                Assert.NotNull(p.UnitOfMeasure);

                if (checkMeterDetails)
                {
                    Assert.NotNull(p.MeterDetails);
                    Assert.NotNull(p.MeterDetails.MeterCategory);
                    Assert.NotNull(p.MeterDetails.MeterLocation);
                    Assert.NotNull(p.MeterDetails.MeterName);
                    Assert.NotNull(p.MeterDetails.MeterSubCategory);
                    Assert.NotNull(p.MeterDetails.Unit);
                }
            }
        }
    }
}
