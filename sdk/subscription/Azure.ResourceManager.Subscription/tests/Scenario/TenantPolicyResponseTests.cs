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
    internal class TenantPolicyResponseTests : SubscriptionManagementTestBase
    {
        public TenantPolicyResponseTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/31127")]
        public async Task GetAll()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var response = tenants.FirstOrDefault().GetTenantPolicy();
            Assert.NotNull(response);
        }
    }
}
