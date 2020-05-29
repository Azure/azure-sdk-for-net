// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Billing.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.Billing.Models;

namespace Billing.Tests.ScenarioTests
{
    public class ProductsOperationsTest : TestBase
    {
        private const string AvailabilityId = "DZH318Z0CCBJ";
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string InvoiceSectionName = "CGPK-BEXW-PJA-TGB";
        private const string ProductName = "8853e514-bd17-4c9c-8b7c-4d2f520ce9f3";

        [Fact]
        public void GetProductTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the product
                var product = billingMgmtClient.Products.Get(BillingAccountName, ProductName);

                // Verify the response
                Assert.Contains(BillingProfileName, product.BillingProfileId);
                Assert.Contains(InvoiceSectionName, product.InvoiceSectionId);
                Assert.Equal(AvailabilityId, product.AvailabilityId);
                Assert.Equal(ProductName, product.Name);
            }
        }

        [Fact]
        public void ListProductsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the products
                var products = billingMgmtClient.Products.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(products);
                Assert.Equal(2, products.Count());
                var product = Assert.Single(products.Where(p => p.Name == ProductName));
                Assert.Contains(BillingProfileName, product.BillingProfileId);
                Assert.Contains(InvoiceSectionName, product.InvoiceSectionId);
                Assert.Equal(AvailabilityId, product.AvailabilityId);
                Assert.Equal(ProductName, product.Name);
            }
        }

        [Fact]
        public void ListProductsByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the products
                var products = billingMgmtClient.Products.ListByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(products);
                Assert.Equal(2, products.Count());
                var product = Assert.Single(products.Where(p => p.Name == ProductName));
                Assert.Contains(BillingProfileName, product.BillingProfileId);
                Assert.Contains(InvoiceSectionName, product.InvoiceSectionId);
                Assert.Equal(AvailabilityId, product.AvailabilityId);
                Assert.Equal(ProductName, product.Name);
            }
        }
    }
}
