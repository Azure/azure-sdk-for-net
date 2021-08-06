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
            string policyDefinitionName = Recording.GenerateAssetName("polDef-D-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData);
            await policyDefinition.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policyDefinition.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
        private static PolicyDefinitionData CreatePolicyDefinitionData(string displayName) => new PolicyDefinitionData
        {
            DisplayName = $"AutoTest ${displayName}",
            PolicyRule = new Dictionary<string, object>
                {
                    {
                        "if", new Dictionary<string, object>
                        {
                            { "source", "action" },
                            { "equals", "ResourceProviderTestHost/TestResourceType/TestResourceTypeNestedOne/write"}
                        }
                    },
                    {
                        "then", new Dictionary<string, object>
                        {
                            { "effect", "deny" }
                        }
                    }
                }
        };
    }
}
