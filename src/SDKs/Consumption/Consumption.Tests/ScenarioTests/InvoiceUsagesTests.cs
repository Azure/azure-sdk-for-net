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
    public class InvoiceUsagesTests : UsageBaseTest
    {
        [Fact]
        public void ListInvoiceUsagesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(InvoiceId, top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.Equal(NumberOfItems, usages.Count());
                Assert.NotNull(usages.NextPageLink);
                foreach (var item in usages)
                {
                    ValidateProperties(item);
                    Assert.Null(item.AdditionalProperties);
                    Assert.Null(item.MeterDetails);
                }
            }
        }

        [Fact]
        public void ListInvoiceUsagesWithDateFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(InvoiceId, filter: DateFilter, top: 10);
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
        public void ListInvoiceUsagesWithDateTimeFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(InvoiceId, filter: DateTimeFilter, top: 10);
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
        public void ListInvoiceUsagesWithExpandTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var usages = consumptionMgmtClient.UsageDetails.List(InvoiceId, expand: "AdditionalProperties,MeterDetails", top: NumberOfItems);
                Assert.NotNull(usages);
                Assert.True(usages.Any());
                Assert.Equal(NumberOfItems, usages.Count());
                Assert.NotNull(usages.NextPageLink);
                foreach (var item in usages)
                {
                    ValidateProperties(item);
                    ValidExpandedMeterDetails(item);
                }
            }
        }
    }
}