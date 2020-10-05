// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class FirewallPolicyTests : NetworkTestsManagementClientBase
    {
        public FirewallPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("Track2: Nunit cannot implement this test")]
        public void FirewallPolicyRuleGroupDeserializationTest()
        {
            //ServiceClientCredentials creds = new MockServiceClientCredentials();
            //var networkManagementClient = new NetworkManagementClient(new Uri("https://management.azure.com"), creds);
            //var responseContent = FirewallPolicyRuleGroupTestResource.GetSampleResource().ToString();
            //var middle = networkManagementClient.DeserializationSettings;
            //var ruleGroup = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<FirewallPolicyRuleGroup>(responseContent, networkManagementClient.DeserializationSettings);

            //Assert.True(ruleGroup != null);
            //Assert.Equal(1, ruleGroup.Rules.Count);

            //FirewallPolicyNatRule policyRule = ruleGroup.Rules[0] as FirewallPolicyNatRule;
            //Assert.Equal(typeof(NetworkRuleCondition), policyRule.RuleCondition.GetType());
        }
    }
}
