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
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string InvoiceSectionName = "ICYS-ZE5B-PJA-PGB";
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
                var product = billingMgmtClient.Products.Get(BillingAccountName, BillingProfileName, InvoiceSectionName, ProductName);

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
                Assert.Equal(2, products.Value.Count);
                var product = Assert.Single(products.Value.Where(p => p.Name == ProductName));
                Assert.Contains(BillingProfileName, product.BillingProfileId);
                Assert.Contains(InvoiceSectionName, product.InvoiceSectionId);
                Assert.Equal(AvailabilityId, product.AvailabilityId);
                Assert.Equal(ProductName, product.Name);
            }
        }
    }
}
