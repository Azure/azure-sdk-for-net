// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BillingBenefits.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
#pragma warning disable CS0618 // Exercise the obsolete compatibility aliases alongside their replacements.
    public class BillingBenefitsExtensionTests
    {
        private const string TenantResponse = "{\"value\":[{\"id\":\"/tenants/00000000-0000-0000-0000-000000000001\",\"tenantId\":\"00000000-0000-0000-0000-000000000001\"}]}";
        private const string EmptyListResponse = "{\"value\":[]}";
        private static readonly ResourceIdentifier BillingAccountId = new ResourceIdentifier("/providers/Microsoft.Billing/billingAccounts/account");

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task GetApplicableMaccsPreservesRequest(bool async, bool legacy)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent(EmptyListResponse));
            var client = CreateClient(transport);

            int count;
            if (async)
            {
                count = await CountAsync(legacy ? client.GetAllAsync(BillingAccountId) : client.GetApplicableMaccsAsync(BillingAccountId));
            }
            else
            {
                count = (legacy ? client.GetAll(BillingAccountId) : client.GetApplicableMaccs(BillingAccountId)).Count();
            }

            Assert.That(count, Is.Zero);
            AssertRequest(transport, 1, RequestMethod.Get, "/providers/microsoft.Billing/billingAccounts/account/providers/Microsoft.BillingBenefits/applicableMaccs");
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task GetApplicableCreditsPreservesRequest(bool async, bool legacy)
        {
            var transport = new MockTransport(new MockResponse(200).SetContent(EmptyListResponse));
            var client = CreateClient(transport);

            int count;
            if (async)
            {
                count = await CountAsync(legacy ? client.GetApplicableAsync(BillingAccountId) : client.GetApplicableCreditsAsync(BillingAccountId));
            }
            else
            {
                count = (legacy ? client.GetApplicable(BillingAccountId) : client.GetApplicableCredits(BillingAccountId)).Count();
            }

            Assert.That(count, Is.Zero);
            // Preserve the existing encoding of scope as a single path parameter.
            AssertRequest(transport, 1, RequestMethod.Get, "/providers%2FMicrosoft.Billing%2FbillingAccounts%2Faccount/providers/Microsoft.BillingBenefits/applicableCredits");
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task GetMaccsPreservesPostRequest(bool async, bool legacy)
        {
            var transport = new MockTransport(
                new MockResponse(200).SetContent(TenantResponse),
                new MockResponse(200).SetContent("[]"));
            var tenant = CreateClient(transport).GetTenants().GetAll().Single();
            var content = new SellerResourceListContent { IncludeContributors = true };

            int count = async
                ? await CountAsync(legacy ? tenant.GetAllAsync(content) : tenant.GetMaccsAsync(content))
                : (legacy ? tenant.GetAll(content) : tenant.GetMaccs(content)).Count();

            Assert.That(count, Is.Zero);
            AssertRequest(transport, 2, RequestMethod.Post, "/providers/Microsoft.BillingBenefits/listSellerResources");
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task ValidateBillingBenefitsSavingsPlanPurchasePreservesRequest(bool async, bool legacy)
        {
            var rawResponse = new MockResponse(200).SetContent("{\"benefits\":[]}");
            var transport = new MockTransport(new MockResponse(200).SetContent(TenantResponse), rawResponse);
            var tenant = CreateClient(transport).GetTenants().GetAll().Single();
            var content = new BenefitValidateContent();

            var response = async
                ? await (legacy ? tenant.ValidateAsync(content) : tenant.ValidateBillingBenefitsSavingsPlanPurchaseAsync(content))
                : (legacy ? tenant.Validate(content) : tenant.ValidateBillingBenefitsSavingsPlanPurchase(content));

            Assert.That(response.Value.Benefits, Is.Empty);
            Assert.That(response.GetRawResponse(), Is.SameAs(rawResponse));
            AssertRequest(transport, 2, RequestMethod.Post, "/providers/Microsoft.BillingBenefits/validate");
        }

        private static ArmClient CreateClient(MockTransport transport)
        {
            return new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
        }

        private static async Task<int> CountAsync<T>(AsyncPageable<T> items)
        {
            int count = 0;
            await foreach (var item in items)
            {
                count++;
            }
            return count;
        }

        private static void AssertRequest(MockTransport transport, int requestCount, RequestMethod method, string path)
        {
            Assert.That(transport.Requests, Has.Count.EqualTo(requestCount));
            var request = transport.Requests.Last();
            Assert.That(request.Method, Is.EqualTo(method));
            Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo(path));
            Assert.That(request.Uri.ToUri().Query, Does.Contain("api-version=2025-12-01-preview"));
        }
    }
#pragma warning restore CS0618
}
