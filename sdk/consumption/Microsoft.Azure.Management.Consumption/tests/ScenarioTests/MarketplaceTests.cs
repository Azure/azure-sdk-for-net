// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.Azure.OData;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class MarketplaceTests : TestBase
    {
        protected const int NumberOfItems = 10;
        protected const string subscriptionId = "6b74c45b-9597-4939-a202-36b2ee8fbb3d";
        protected const string billingPeriodName = "201801-1";
        protected const string listByBillingPeriodNexLink = "https://management.azure.com/subscriptions/6b74c45b-9597-4939-a202-36b2ee8fbb3d/providers/Microsoft.Billing/billingPeriods/201801-1/providers/Microsoft.Consumption/marketplaces?$top=10&api-version=2018-01-31&$skiptoken=AQAAAA%3D%3D";

        [Fact]
        public void ListMarketplacesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                var marketplaceUsage = consumptionMgmtClient.Marketplaces.List(new ODataQuery<Marketplace> { Top = NumberOfItems });

                Assert.NotNull(marketplaceUsage);
                Assert.True(marketplaceUsage.Any());
                foreach (var item in marketplaceUsage)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListMarketplacesByBillingPeriodTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                var marketplaceUsage = consumptionMgmtClient.Marketplaces.ListByBillingPeriod(billingPeriodName, new ODataQuery<Marketplace> { Top = NumberOfItems });

                Assert.NotNull(marketplaceUsage);
                Assert.True(marketplaceUsage.Any());
                foreach (var item in marketplaceUsage)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListMarketplacesByBillingPeriodNextTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                consumptionMgmtClient.SubscriptionId = subscriptionId;
                var marketplaceUsage = consumptionMgmtClient.Marketplaces.ListByBillingPeriodNext(listByBillingPeriodNexLink);

                Assert.NotNull(marketplaceUsage);
                Assert.True(marketplaceUsage.Any());
                foreach (var item in marketplaceUsage)
                {
                    ValidateProperties(item);
                }
            }
        }

        private static void ValidateProperties(Marketplace item)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.BillingPeriodId);
            Assert.NotNull(item.ConsumedQuantity);
            Assert.NotNull(item.Currency);
            Assert.NotNull(item.InstanceId);
            Assert.NotNull(item.InstanceName);
            Assert.NotNull(item.IsEstimated);
            Assert.NotNull(item.OrderNumber);
            Assert.NotNull(item.PretaxCost);
            Assert.NotNull(item.ResourceRate);
            Assert.NotNull(item.SubscriptionGuid);
            Assert.NotNull(item.UsageEnd);
            Assert.NotNull(item.UsageStart);
        }
    }
}

