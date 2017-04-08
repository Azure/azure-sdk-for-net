// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Management.Billing.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using Xunit;

namespace Billing.Tests.ScenarioTests
{
    public class InvoicesTests : TestBase
    {
        const string DownloadUrlExpand = "downloadUrl";
        const string RangeFilter = "invoicePeriodEndDate ge 2017-01-31 and invoicePeriodEndDate le 2017-02-28";
        const string InvoiceName = "2017-02-09-117646100066812";

        [Fact]
        public void ListInvoicesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var invoices = billingMgmtClient.Invoices.List();
                Assert.NotNull(invoices);
                Assert.True(invoices.Any());
                Assert.False(invoices.Any(x => x.DownloadUrl != null));
            }
        }

        [Fact]
        public void ListInvoicesWithQueryParametersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var invoices = billingMgmtClient.Invoices.List(DownloadUrlExpand, RangeFilter, null, 1);
                Assert.NotNull(invoices);
                Assert.Equal(1, invoices.Count());
                Assert.NotNull(invoices.First().DownloadUrl);
                var invoice = invoices.First();
                Assert.False(string.IsNullOrWhiteSpace(invoice.DownloadUrl.Url));
                Assert.True(invoice.DownloadUrl.ExpiryTime.HasValue);
            }
        }

        [Fact]
        public void GetLatestInvoice()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var invoice = billingMgmtClient.Invoices.GetLatest();
                Assert.NotNull(invoice);
                Assert.False(string.IsNullOrWhiteSpace(invoice.DownloadUrl.Url));
                Assert.True(invoice.DownloadUrl.ExpiryTime.HasValue);
            }
        }

        [Fact]
        public void GetInvoiceWithName()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var invoice = billingMgmtClient.Invoices.Get(InvoiceName);
                Assert.NotNull(invoice);
                Assert.Equal(InvoiceName, invoice.Name);
                Assert.False(string.IsNullOrWhiteSpace(invoice.DownloadUrl.Url));
                Assert.True(invoice.DownloadUrl.ExpiryTime.HasValue);
            }
        }

        [Fact]
        public void GetInvoicesNoResult()
        {
            string rangeFilter = "invoicePeriodEndDate lt 2016-01-31";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                    billingMgmtClient.Invoices.List(DownloadUrlExpand, rangeFilter, null, 1);
                    Assert.False(true, "ErrorResponseException should have been thrown");
                }
                catch(ErrorResponseException e)
                {
                    Assert.NotNull(e.Body);
                    Assert.NotNull(e.Body.Error);
                    Assert.Equal("ResourceNotFound", e.Body.Error.Code);
                    Assert.False(string.IsNullOrWhiteSpace(e.Body.Error.Message));
                }
            }
        }
    }
}