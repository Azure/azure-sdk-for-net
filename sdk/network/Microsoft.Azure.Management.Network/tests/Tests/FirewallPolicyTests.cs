// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Networks.Tests
{
    using System;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Xunit;

    using Microsoft.Rest;

    public class FirewallPolicyTests
    {
        [Fact()]
        public void FirewallPolicyRuleGroupDeserializationTest()
        {
            ServiceClientCredentials creds = new MockServiceClientCredentials();
            var networkManagementClient = new NetworkManagementClient(new Uri("https://management.azure.com"), creds); 
            var responseContent = FirewallPolicyRuleGroupTestResource.GetSampleResource().ToString();
            var ruleGroup = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<FirewallPolicyRuleGroup>(responseContent, networkManagementClient.DeserializationSettings);

            Assert.True(ruleGroup != null);
            Assert.Equal(1, ruleGroup.Rules.Count);

            FirewallPolicyNatRule policyRule = ruleGroup.Rules[0] as FirewallPolicyNatRule;
            Assert.Equal(typeof(NetworkRuleCondition), policyRule.RuleCondition.GetType());          
            
        }
    }
}
