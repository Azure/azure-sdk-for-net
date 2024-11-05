// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Subscription.Tests
{
    [LiveOnly(Reason = "Tests rely on PII data.")]
    internal class TenantPolicyDefinitionTests : SubscriptionManagementTestBase
    {
        private TenantPolicyDefinitionCollection _tenantPolicyDefinitionCollection => GetTenantPolicyDefinition().Result;

        public TenantPolicyDefinitionTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<TenantPolicyDefinitionCollection> GetTenantPolicyDefinition()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            return tenants.FirstOrDefault().GetTenantPolicyDefinitions();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _tenantPolicyDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var list = await _tenantPolicyDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            string policyName = list.FirstOrDefault().Data.Name;
            bool flag = await _tenantPolicyDefinitionCollection.ExistsAsync(policyName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var list = await _tenantPolicyDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            string policyName = list.FirstOrDefault().Data.Name;
            var policy = await _tenantPolicyDefinitionCollection.GetAsync(policyName);
            Assert.IsNotNull(policy);
            Assert.AreEqual(policyName, policy.Value.Data.Name);
        }
    }
}
