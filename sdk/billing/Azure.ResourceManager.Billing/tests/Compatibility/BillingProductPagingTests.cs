// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Billing.Tests
{
    public class BillingProductPagingTests
    {
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task GetProductsUsesCorrectScope(bool invoiceSection, bool async)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent("{\"value\":[]}"));
            var client = new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000001", new ArmClientOptions { Transport = transport });
            const string profilePath = "/providers/Microsoft.Billing/billingAccounts/account/billingProfiles/profile";
            string expectedPath = invoiceSection ? profilePath + "/invoiceSections/section/products" : profilePath + "/products";

            if (invoiceSection)
            {
                var resource = client.GetBillingInvoiceSectionResource(BillingInvoiceSectionResource.CreateResourceIdentifier("account", "profile", "section"));
                if (async)
                {
                    await foreach (var page in resource.GetProductsAsync().AsPages())
                    { }
                }
                else
                {
                    foreach (var page in resource.GetProducts().AsPages())
                    { }
                }
            }
            else
            {
                var resource = client.GetBillingProfileResource(BillingProfileResource.CreateResourceIdentifier("account", "profile"));
                if (async)
                {
                    await foreach (var page in resource.GetProductsAsync().AsPages())
                    { }
                }
                else
                {
                    foreach (var page in resource.GetProducts().AsPages())
                    { }
                }
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(expectedPath));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task GetProductsForwardsQueryAndNextLink(bool invoiceSection, bool async)
        {
            const string profilePath = "/providers/Microsoft.Billing/billingAccounts/account/billingProfiles/profile";
            string expectedPath = invoiceSection ? profilePath + "/invoiceSections/section/products" : profilePath + "/products";
            string nextLink = $"https://management.azure.com{expectedPath}?api-version=2024-04-01&skiptoken=next";
            var transport = new MockTransport(
                new MockResponse(200).SetContent($"{{\"value\":[],\"nextLink\":\"{nextLink}\"}}"),
                new MockResponse(200).SetContent("{\"value\":[]}"));
            var client = new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000001", new ArmClientOptions { Transport = transport });

            if (invoiceSection)
            {
                var resource = client.GetBillingInvoiceSectionResource(BillingInvoiceSectionResource.CreateResourceIdentifier("account", "profile", "section"));
                if (async)
                {
                    await foreach (var page in resource.GetProductsAsync(filter: "active").AsPages())
                    { }
                }
                else
                {
                    foreach (var page in resource.GetProducts(filter: "active").AsPages())
                    { }
                }
            }
            else
            {
                var resource = client.GetBillingProfileResource(BillingProfileResource.CreateResourceIdentifier("account", "profile"));
                if (async)
                {
                    await foreach (var page in resource.GetProductsAsync(filter: "active").AsPages())
                    { }
                }
                else
                {
                    foreach (var page in resource.GetProducts(filter: "active").AsPages())
                    { }
                }
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(expectedPath));
            Assert.That(transport.Requests[0].Uri.ToUri().Query, Does.Contain("filter=active"));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task CustomerProductsUseCustomerScope(bool async)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent("{\"value\":[]}"));
            var client = new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000001", new ArmClientOptions { Transport = transport });
            var resource = client.GetBillingCustomerResource(BillingCustomerResource.CreateResourceIdentifier("account", "customer"));

            if (async)
            {
                await foreach (var page in resource.GetByCustomerAsync().AsPages())
                { }
            }
            else
            {
                foreach (var page in resource.GetByCustomer().AsPages())
                { }
            }

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo("/providers/Microsoft.Billing/billingAccounts/account/customers/customer/products"));
        }
    }
}
