// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class UsageBaseTest : TestBase
    {
        protected const int NumberOfItems = 10;
        protected const string DateFilter = "usageEnd gt 2017-03-22 and usageEnd lt 2017-03-26";
        protected const string DateTimeFilter = "usageEnd ge 2017-03-28T23:59:59Z and usageEnd le 2017-03-29T23:59:59Z";
        protected const string BillingPeriodId = "/subscriptions/8baabac0-a508-47cf-b519-730d7ba6bf9b/providers/Microsoft.Billing/billingPeriods/201705-1";
        protected const string InvoiceId = "/subscriptions/8baabac0-a508-47cf-b519-730d7ba6bf9b/providers/Microsoft.Billing/invoices/201705-217512100075561";
        protected const string SubscriptionScope = "/subscriptions/8baabac0-a508-47cf-b519-730d7ba6bf9b";

        protected static void ValidateProperties(UsageDetail item, string expectedInvoiceId = InvoiceId, string expectedBillingPeriodId = BillingPeriodId)
        {
            Assert.NotNull(item.Name);
            Assert.True(item.Id.EndsWith(item.Name));
            Assert.NotNull(item.Type);

            if (!string.IsNullOrWhiteSpace(expectedInvoiceId))
            {
                Assert.True(item.InvoiceId.Equals(expectedInvoiceId, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(expectedBillingPeriodId))
            {
                Assert.True(item.BillingPeriodId.Equals(expectedBillingPeriodId, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                Assert.NotNull(item.BillingPeriodId);
            }
            Assert.NotNull(item.Currency);
            Assert.True(item.UsageStart.Value < item.UsageEnd.Value);
            Assert.True(item.BillableQuantity.Value <= item.UsageQuantity.Value);
            Assert.True(item.InstanceId != null || item.InstanceName != null);
            Assert.NotNull(item.InstanceLocation);
            Assert.NotNull(item.MeterId);
            Assert.NotNull(item.IsEstimated);
            Assert.True(item.PretaxCost.Value >= 0);
        }

        protected static void ValidExpandedMeterDetails(UsageDetail item)
        {
            Assert.NotNull(item.MeterDetails);
            Assert.NotNull(item.MeterDetails.MeterName);
            Assert.NotNull(item.MeterDetails.MeterCategory);
            Assert.NotNull(item.MeterDetails.Unit);
            Assert.NotNull(item.MeterDetails.TotalIncludedQuantity);
        }
    }
}
