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
    }
}
