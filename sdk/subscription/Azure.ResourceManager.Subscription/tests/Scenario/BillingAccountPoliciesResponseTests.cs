// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Subscription.Models;
using Azure.ResourceManager.Subscription.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Subscription.Tests
{
    internal class BillingAccountPoliciesResponseTests : SubscriptionManagementTestBase
    {
        private BillingAccountPolicyCollection _billingAccountPolicesCollection => GetBillingAccountPoliciesResponseCollection().Result;

        public BillingAccountPoliciesResponseTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<BillingAccountPolicyCollection> GetBillingAccountPoliciesResponseCollection()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            return tenants.FirstOrDefault().GetBillingAccountPolicies();
        }

        [RecordedTest]
        public void Exist()
        {
            // Unable to get a valid account name
            // Azure.RequestFailedException : Invalid billing account name.
            Assert.ThrowsAsync<RequestFailedException>(() => _billingAccountPolicesCollection.ExistsAsync("testBillingAccountId"));
        }

        [RecordedTest]
        public void Get()
        {
            // Unable to get a valid account name
            // Azure.RequestFailedException : Invalid billing account name.
            Assert.ThrowsAsync<RequestFailedException>(() => _billingAccountPolicesCollection.GetAsync("testBillingAccountId"));
        }
    }
}
