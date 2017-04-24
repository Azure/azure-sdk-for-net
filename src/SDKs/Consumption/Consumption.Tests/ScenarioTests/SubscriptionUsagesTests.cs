// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class SubscriptionUsagesTests : UsageBaseTest
    {
        [Fact]
        public void ListUsagesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(SubscriptionScope, top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.True(NumberOfItems >= usages.Count());
                Assert.NotNull(usages.NextPageLink);
                foreach (var item in usages)
                {
                    ValidateProperties(item, null, null);
                    Assert.Null(item.AdditionalProperties);
                    Assert.Null(item.MeterDetails);
                }
            }
        }

        [Fact]
        public void ListUsagesWithDateTimeFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(SubscriptionScope, filter: DateTimeFilter, top: 10);
                Assert.NotNull(usages);
                foreach (var item in usages)
                {
                    ValidateProperties(item);
                    Assert.Null(item.AdditionalProperties);
                    Assert.Null(item.MeterDetails);
                }
            }
        }

        [Fact]
        public void ListUsagesWithExpandTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(SubscriptionScope, expand: "MeterDetails", filter: DateTimeFilter, top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.True(NumberOfItems >= usages.Count());
                foreach (var item in usages)
                {
                    ValidateProperties(item);
                    ValidExpandedMeterDetails(item);
                }
            }
        }
    }
}