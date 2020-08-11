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
        private const string AvailabilityId = "DZH318Z0C06X";
        private const string BillingAccountName = "4b15e98a-cb13-5f5d-0d2c-64eea298c8d4:277f7747-44f1-446f-88b0-d27d655c60cd_2019-05-31";
        private const string BillingProfileName = "KKMM-ZUHC-BG7-TGB";
        private const string InvoiceSectionName = "UCAF-IQUR-PJA-TGB";
        private const string ProductName = "b04536f5-e758-081a-b981-0b9afad94173";
        private const string SourceInvoiceSectionId =
            "/providers/Microsoft.Billing/billingAccounts/4b15e98a-cb13-5f5d-0d2c-64eea298c8d4:277f7747-44f1-446f-88b0-d27d655c60cd_2019-05-31/billingProfiles/KKMM-ZUHC-BG7-TGB/invoiceSections/UCAF-IQUR-PJA-TGB";
        private const string DestinationInvoiceSectionId =
            "/providers/Microsoft.Billing/billingAccounts/4b15e98a-cb13-5f5d-0d2c-64eea298c8d4:277f7747-44f1-446f-88b0-d27d655c60cd_2019-05-31/billingProfiles/KKMM-ZUHC-BG7-TGB/invoiceSections/WOEH-SLEK-DHR-TGB";

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

        [Fact]
        public void MoveProductByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the products
                var validateProductTransferEligibilityResult = billingMgmtClient.Products.ValidateMove(
                    BillingAccountName,
                    ProductName,
                    new TransferProductRequestProperties
                    {
                        DestinationInvoiceSectionId = DestinationInvoiceSectionId
                    });

                // Verify the response and make sure we can move product to destination InvoiceSection
                Assert.NotNull(validateProductTransferEligibilityResult);
                Assert.NotNull(validateProductTransferEligibilityResult.IsMoveEligible);
                if (validateProductTransferEligibilityResult.IsMoveEligible.Value)
                {
                    var movedProduct = billingMgmtClient.Products.Move(
                        BillingAccountName,
                        ProductName,
                        new TransferProductRequestProperties
                        {
                            DestinationInvoiceSectionId = DestinationInvoiceSectionId
                        });

                    // verify response
                    Assert.NotNull(movedProduct);
                    Assert.Equal(DestinationInvoiceSectionId, movedProduct.InvoiceSectionId);
                }
            }
        }

        [Fact]
        public void ValidateProductMoveEligibilityByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the products
                var validateProductTransferEligibilityResult = billingMgmtClient.Products.ValidateMove(
                    BillingAccountName,
                    ProductName,
                    new TransferProductRequestProperties
                    {
                        DestinationInvoiceSectionId = DestinationInvoiceSectionId
                    });

                // Verify the response and make sure we can move product to destination InvoiceSection
                Assert.NotNull(validateProductTransferEligibilityResult);
                Assert.NotNull(validateProductTransferEligibilityResult.IsMoveEligible);
                Assert.True(validateProductTransferEligibilityResult.IsMoveEligible.Value);
            }
        }

        [Fact]
        public void UpdateProductAutoRenewTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            var autoRenewOff = "Off";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the products
                var productUpdateResult = billingMgmtClient.Products.Update(
                    BillingAccountName,
                    ProductName,
                    new Product
                    {
                        AutoRenew = autoRenewOff
                    });

                // Verify the response
                Assert.NotNull(productUpdateResult);
                Assert.NotNull(productUpdateResult.AutoRenew);
                Assert.Equal(autoRenewOff, productUpdateResult.AutoRenew);

                // restore
                var autoRenew = "On";
                productUpdateResult = billingMgmtClient.Products.Update(
                    BillingAccountName,
                    ProductName,
                    new Product
                    {
                        AutoRenew = autoRenew
                    });

                // verify restore
                Assert.NotNull(productUpdateResult);
                Assert.NotNull(productUpdateResult.AutoRenew);
                Assert.Equal(autoRenew, productUpdateResult.AutoRenew);
            }
        }
    }
}
