// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class SubscriptionUsagesTests : TestBase
    {
        protected const int NumberOfItems = 100;
        protected const string SubscriptionScope = "/subscriptions/a98d6dc5-eb8f-46cf-8938-f1fb08f03706";
        protected const string SubscriptionBillingPeriodScope = "/subscriptions/a98d6dc5-eb8f-46cf-8938-f1fb08f03706/providers/Microsoft.Billing/billingPeriods/201710";

        [Fact]
        public void ListUsagesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(SubscriptionScope, top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.True(NumberOfItems >= usages.Count());
                Assert.NotNull(usages.NextPageLink);
                foreach (var item in usages)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListUsagesWithDateTimeFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var dateTimeFilter = "properties/usageStart ge '2017-10-02' and properties/usageEnd le '2017-10-03'";
                var usages = consumptionMgmtClient.UsageDetails.List(SubscriptionScope, filter: dateTimeFilter, top: 10);
                Assert.NotNull(usages);
                foreach (var item in usages)
                {
                    ValidateProperties(item, 
                        usageStart: new DateTime(2017, 10, 2),
                        usageEnd: new DateTime(2017, 10, 3));
                }
            }
        }

        [Fact]
        public void ListUsagesForBillingPeriodTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(SubscriptionBillingPeriodScope, top: 10);
                Assert.NotNull(usages);
                foreach (var item in usages)
                {
                    ValidateProperties(item, expectedBillingPeriodId: SubscriptionBillingPeriodScope.Substring(1));
                }
            }
        }

        [Fact]
        public void ListUsagesWithExpandTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(
                    SubscriptionScope, 
                    expand: "MeterDetails,AdditionalDetails",                     
                    top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.True(NumberOfItems >= usages.Count());
                foreach (var item in usages)
                {
                    ValidateProperties(item, true, true);
                }
            }
        }

        [Fact]
        public void ListUsagesWithInstanceNameFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var instanceName = "D1v2";
                var filter = $"properties/instanceName eq '{instanceName}'";
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(
                    SubscriptionScope,
                    filter: filter,
                    top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.True(NumberOfItems >= usages.Count());
                foreach (var item in usages)
                {
                    ValidateProperties(item, instanceName:instanceName);
                }
            }
        }

        private static void ValidateProperties(
            UsageDetail item,
            bool includeMeterDetails = false,
            bool includeAdditionalProperties = false,
            string expectedBillingPeriodId = null,
            DateTime? usageStart = null,
            DateTime? usageEnd = null,
            string instanceName = null)
        {
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.InstanceId);
            Assert.NotNull(item.InstanceName);
            Assert.NotNull(item.InstanceLocation);
            Assert.EndsWith(item.Name, item.Id);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.BillingPeriodId);
            Assert.NotNull(item.Currency);
            Assert.True(item.UsageStart.Value < item.UsageEnd.Value);
            Assert.NotNull(item.MeterId);
            Assert.NotNull(item.IsEstimated);
            Assert.True(item.PretaxCost.Value >= 0);


            if (expectedBillingPeriodId != null)
            {
                Assert.Contains(expectedBillingPeriodId.ToLowerInvariant(), item.BillingPeriodId.ToLowerInvariant());
            }
            else
            {
                Assert.NotNull(item.BillingPeriodId);
            }

            if (usageStart != null && usageEnd != null)
            {
                Assert.True(item.UsageStart.Value >= usageStart);
                Assert.True(item.UsageEnd.Value <= usageEnd);
            }

            if (includeMeterDetails)
            {
                Assert.NotNull(item.MeterDetails);
                Assert.NotNull(item.MeterDetails.MeterName);
                Assert.NotNull(item.MeterDetails.MeterCategory);
                Assert.NotNull(item.MeterDetails.Unit);
            }
            else
            {
                Assert.Null(item.MeterDetails);

            }

            if (!includeAdditionalProperties)
            {
                Assert.Null(item.AdditionalProperties);
            }

            if (instanceName != null)
            {
                Assert.Equal(instanceName, item.InstanceName, ignoreCase: true);
            }
        }
    }
}