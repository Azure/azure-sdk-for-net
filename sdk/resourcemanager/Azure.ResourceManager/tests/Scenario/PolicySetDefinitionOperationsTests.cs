// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PolicySetDefinitionOperationsTests : ResourceManagerTestBase
    {
        public PolicySetDefinitionOperationsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string policyDefinitionName = Recording.GenerateAssetName("testPolDef-");
            PolicyDefinitionData policyDefinitionData = CreatePolicyDefinitionData(policyDefinitionName);
            PolicyDefinition policyDefinition = (await Client.DefaultSubscription.GetPolicyDefinitions().CreateOrUpdateAsync(policyDefinitionName, policyDefinitionData)).Value;
            string policySetDefinitionName = Recording.GenerateAssetName("polSetDef-D-");
            PolicySetDefinitionData policySetDefinitionData = CreatePolicySetDefinitionData(policySetDefinitionName, policyDefinition);
            PolicySetDefinition policySetDefinition = (await Client.DefaultSubscription.GetPolicySetDefinitions().CreateOrUpdateAsync(policySetDefinitionName, policySetDefinitionData)).Value;
            await policySetDefinition.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await policySetDefinition.GetAsync());
            Assert.AreEqual(404, ex.Status);
            await policyDefinition.DeleteAsync();
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
        private static PolicySetDefinitionData CreatePolicySetDefinitionData(string displayName, PolicyDefinition policyDefinition) => new PolicySetDefinitionData
        {
            DisplayName = $"AutoTest ${displayName}",
            PolicyDefinitions = { new PolicyDefinitionReference(policyDefinition.Id) }
        };
    }
}
