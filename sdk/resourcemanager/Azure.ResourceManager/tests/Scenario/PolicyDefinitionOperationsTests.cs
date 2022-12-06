// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicyDefinitionOperationsTests : ResourceManagerTestBase
    {
        public PolicyDefinitionOperationsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string policyDefinitionName = Recording.GenerateAssetName("polDef-");
            SubscriptionPolicyDefinitionResource policyDefinition = await CreatePolicyDefinitionAtSubscription(subscription, policyDefinitionName);
            await policyDefinition.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyDefinition.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
