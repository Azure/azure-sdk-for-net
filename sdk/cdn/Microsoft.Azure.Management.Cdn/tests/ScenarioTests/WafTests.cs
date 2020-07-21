// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading;
using Microsoft.Rest;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Xunit.Sdk;

namespace Cdn.Tests.ScenarioTests
{
    public class WafTests
    {
        [Fact(Skip = "CDN WAF features are not working for new API versions due to a known issue")]
        public void WafPolicyLinkTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a cdn waf policy
                var policyName = TestUtilities.GenerateName("policy");
                var policy = cdnMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, new CdnWebApplicationFirewallPolicy
                {
                    Location = "Global",
                    Sku = new Sku("Standard_Microsoft"),
                    PolicySettings = new PolicySettings
                    {
                        EnabledState = "Enabled",
                        Mode = "Detection",
                        DefaultCustomBlockResponseBody = "PGh0bWw+PGJvZHk+PGgzPkludmFsaWQgcmVxdWVzdDwvaDM+PC9ib2R5PjwvaHRtbD4=",
                        DefaultRedirectUrl = "https://example.com/redirected",
                        DefaultCustomBlockResponseStatusCode = 406
                    },
                    CustomRules = new CustomRuleList(new List<CustomRule>
                    {
                        new CustomRule {
                            Name = "CustomRule1",
                            Priority = 2,
                            EnabledState = "Enabled",
                            Action = "Block",
                            MatchConditions = new List<MatchCondition>
                            {
                                new MatchCondition {
                                    MatchVariable = "QueryString",
                                    OperatorProperty = "Contains",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                    "TestTrigger123"
                                    },
                                    //Transforms = new List<String> { "Uppercase" }
                                }
                            }
                        }
                    }),
                    RateLimitRules = new RateLimitRuleList(new List<RateLimitRule>
                    {
                        new RateLimitRule {
                            Name = "RateLimitRule1",
                            Priority = 1,
                            EnabledState = "Disabled",
                            RateLimitDurationInMinutes = 1,
                            RateLimitThreshold = 3,
                            MatchConditions = new List<MatchCondition> {
                                new MatchCondition {
                                    MatchVariable = "RemoteAddr",
                                    Selector = null,
                                    OperatorProperty = "IPMatch",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                        "131.107.0.0/16",
                                        "167.220.0.0/16"
                                    }
                                }
                            },
                            Action = "Block"
                        },
                        new RateLimitRule {
                            Name = "RateLimitRule2",
                            Priority = 10,
                            EnabledState = "Enabled",
                            RateLimitDurationInMinutes = 1,
                            RateLimitThreshold = 1,
                            MatchConditions = new List<MatchCondition> {
                                new MatchCondition {
                                    MatchVariable = "RequestUri",
                                    Selector = null,
                                    OperatorProperty = "Contains",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                    "yes"
                                    }
                                }
                            },
                            Action = "Block"
                        }
                    }),
                    ManagedRules = new ManagedRuleSetList(new List<ManagedRuleSet>
                    {
                        new ManagedRuleSet {
                            RuleSetType = "DefaultRuleSet",
                            RuleSetVersion = "1.0",
                            RuleGroupOverrides = new List<ManagedRuleGroupOverride> {
                                new ManagedRuleGroupOverride {
                                    RuleGroupName = "JAVA",
                                    Rules = new List<ManagedRuleOverride> {
                                        new ManagedRuleOverride {
                                            RuleId = "944100",
                                            EnabledState = "Disabled",
                                            Action = "Redirect"
                                        }
                                    }
                                }
                            }
                        }
                    }),
                    Tags = new Dictionary<string, string>
                    {
                        { "abc", "123" }
                    }
                });

                // Create a standard Microsoft cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardMicrosoft },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };

                // Wait for policy to complete creation
                CdnTestUtilities.WaitIfNotInPlaybackMode();

                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                // Create a cdn endpoint with waf link should succeed
                string endpointName = TestUtilities.GenerateName("endpoint");
                var endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, new Endpoint
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    WebApplicationFirewallPolicyLink = new EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink(policy.Id.ToString()),
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = "host1.hello.com"
                        }
                    }
                });

                // Verify linked endpoint
                var existingEndpoint = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpointName);
                Assert.Equal(policy.Id.ToString(), existingEndpoint.WebApplicationFirewallPolicyLink.Id);

                // Verify policy shows linked endpoint
                var existingPolicy = cdnMgmtClient.Policies.Get(resourceGroupName, policyName);
                Assert.Single(existingPolicy.EndpointLinks);
                Assert.Contains(endpoint.Id, existingPolicy.EndpointLinks.Select(l => l.Id));

                // Create second endpoint linked to the same profile should succeed
                var endpoint2Name = TestUtilities.GenerateName("endpoint");
                var endpoint2 = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpoint2Name, new Endpoint
                {
                    Location = "EastUs",
                    IsHttpAllowed = false,
                    IsHttpsAllowed = true,
                    WebApplicationFirewallPolicyLink = new EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink(policy.Id.ToString()),
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin2",
                            HostName = "host2.hello.com"
                        }
                    }
                });

                // Verify second linked endpoint
                var existingEndpoint2 = cdnMgmtClient.Endpoints.Get(resourceGroupName, profileName, endpoint2Name);
                Assert.Equal(policy.Id.ToString(), existingEndpoint2.WebApplicationFirewallPolicyLink.Id);

                // Verify policy shows both linked endpoints.
                existingPolicy = cdnMgmtClient.Policies.Get(resourceGroupName, policyName);
                Assert.Equal(2, existingPolicy.EndpointLinks.Count());
                Assert.Contains(endpoint.Id, existingPolicy.EndpointLinks.Select(l => l.Id));
                Assert.Contains(endpoint2.Id, existingPolicy.EndpointLinks.Select(l => l.Id));

                // Unlink endpoint should succeed.
                endpoint.WebApplicationFirewallPolicyLink = null;
                endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpoint);
                Assert.Null(endpoint.WebApplicationFirewallPolicyLink);

                // Verify policy shows only second linked endpoint.
                existingPolicy = cdnMgmtClient.Policies.Get(resourceGroupName, policyName);
                Assert.Single(existingPolicy.EndpointLinks);
                Assert.Contains(endpoint2.Id, existingPolicy.EndpointLinks.Select(l => l.Id));

                // Unlink second endpoint should succeed
                endpoint2.WebApplicationFirewallPolicyLink = null;
                endpoint2 = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpoint2Name, endpoint2);
                Assert.Null(endpoint2.WebApplicationFirewallPolicyLink);

                // Verify policy shows no linked endpoints
                existingPolicy = cdnMgmtClient.Policies.Get(resourceGroupName, policyName);
                Assert.Empty(existingPolicy.EndpointLinks);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact(Skip = "CDN WAF features are not working for new API versions due to a known issue")]
        public void WafPolicyCreateOrUpdateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a minimal cdn waf policy should succeed
                var policyName = TestUtilities.GenerateName("policy");
                var policy = cdnMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, new CdnWebApplicationFirewallPolicy
                {
                    Sku = new Sku(SkuName.StandardMicrosoft),
                    Location = "Global",
                });
                //Assert.NotNull(policy.Etag);
                Assert.Equal(policyName, policy.Name);
                Assert.Equal($"/subscriptions/{resourcesClient.SubscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Cdn/cdnwebapplicationfirewallpolicies/{policy.Name}", policy.Id);
                Assert.Equal("Global", policy.Location);
                Assert.Equal(SkuName.StandardMicrosoft, policy.Sku.Name);
                Assert.Equal(ProvisioningState.Succeeded, policy.ProvisioningState);
                Assert.Equal(PolicyResourceState.Enabled, policy.ResourceState);
                Assert.Empty(policy.EndpointLinks);
                Assert.Empty(policy.ManagedRules.ManagedRuleSets);
                Assert.Empty(policy.RateLimitRules.Rules);
                Assert.Empty(policy.CustomRules.Rules);
                Assert.Null(policy.PolicySettings.DefaultCustomBlockResponseBody);
                Assert.Null(policy.PolicySettings.DefaultCustomBlockResponseStatusCode);
                Assert.Null(policy.PolicySettings.DefaultRedirectUrl);
                Assert.Equal(PolicyEnabledState.Enabled, policy.PolicySettings.EnabledState);
                Assert.Equal(PolicyMode.Prevention, policy.PolicySettings.Mode);

                // Update policy with all parameters should succeed
                var expect = new CdnWebApplicationFirewallPolicy
                {
                    Location = "Global",
                    Sku = new Sku(SkuName.StandardMicrosoft),
                    PolicySettings = new PolicySettings
                    {
                        EnabledState = "Enabled",
                        Mode = "Detection",
                        DefaultCustomBlockResponseBody = "PGh0bWw+PGJvZHk+PGgzPkludmFsaWQgcmVxdWVzdDwvaDM+PC9ib2R5PjwvaHRtbD4=",
                        DefaultRedirectUrl = "https://example.com/redirected",
                        DefaultCustomBlockResponseStatusCode = 406
                    },
                    CustomRules = new CustomRuleList(new List<CustomRule>
                    {
                        new CustomRule {
                            Name = "CustomRule1",
                            Priority = 2,
                            EnabledState = "Enabled",
                            Action = "Block",
                            MatchConditions = new List<MatchCondition>
                            {
                                new MatchCondition {
                                    MatchVariable = "QueryString",
                                    OperatorProperty = "Contains",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                    "TestTrigger123"
                                    },
                                    //Transforms = new List<String> { "Uppercase" }
                                }
                            }
                        }
                    }),
                    RateLimitRules = new RateLimitRuleList(new List<RateLimitRule>
                    {
                        new RateLimitRule {
                            Name = "RateLimitRule1",
                            Priority = 1,
                            EnabledState = "Disabled",
                            RateLimitDurationInMinutes = 1,
                            RateLimitThreshold = 3,
                            MatchConditions = new List<MatchCondition> {
                                new MatchCondition {
                                    MatchVariable = "RemoteAddr",
                                    Selector = null,
                                    OperatorProperty = "IPMatch",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                        "131.107.0.0/16",
                                        "167.220.0.0/16"
                                    }
                                }
                            },
                            Action = "Block"
                        },
                        new RateLimitRule {
                            Name = "RateLimitRule2",
                            Priority = 10,
                            EnabledState = "Enabled",
                            RateLimitDurationInMinutes = 1,
                            RateLimitThreshold = 1,
                            MatchConditions = new List<MatchCondition> {
                                new MatchCondition {
                                    MatchVariable = "RequestUri",
                                    Selector = null,
                                    OperatorProperty = "Contains",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                    "yes"
                                    }
                                }
                            },
                            Action = "Block"
                        }
                    }),
                    ManagedRules = new ManagedRuleSetList(new List<ManagedRuleSet>
                    {
                        new ManagedRuleSet {
                            RuleSetType = "DefaultRuleSet",
                            RuleSetVersion = "1.0",
                            RuleGroupOverrides = new List<ManagedRuleGroupOverride> {
                                new ManagedRuleGroupOverride {
                                    RuleGroupName = "JAVA",
                                    Rules = new List<ManagedRuleOverride> {
                                        new ManagedRuleOverride {
                                            RuleId = "944100",
                                            EnabledState = "Disabled",
                                            Action = "Redirect"
                                        }
                                    }
                                }
                            }
                        }
                    }),
                    Tags = new Dictionary<string, string>
                    {
                        { "abc", "123" }
                    }
                };
                policy = cdnMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, expect);
                AssertPoliciesEqual(resourcesClient.SubscriptionId, resourceGroupName, policyName, new List<CdnEndpoint>(), expect, policy);

                // Create a complete cdn waf policy should succeed
                var policy2Name = TestUtilities.GenerateName("policy");
                var expect2 = new CdnWebApplicationFirewallPolicy
                {
                    Location = "Global",
                    Sku = new Sku(SkuName.StandardMicrosoft),
                    PolicySettings = new PolicySettings
                    {
                        EnabledState = "Enabled",
                        Mode = "Detection",
                        DefaultCustomBlockResponseBody = "PGh0bWw+PGJvZHk+PGgzPkludmFsaWQgcmVxdWVzdDwvaDM+PC9ib2R5PjwvaHRtbD4=",
                        DefaultRedirectUrl = "https://example.com/redirected",
                        DefaultCustomBlockResponseStatusCode = 406
                    },
                    CustomRules = new CustomRuleList(new List<CustomRule>
                    {
                        new CustomRule {
                            Name = "CustomRule1",
                            Priority = 2,
                            EnabledState = "Enabled",
                            Action = "Block",
                            MatchConditions = new List<MatchCondition>
                            {
                                new MatchCondition {
                                    MatchVariable = "QueryString",
                                    OperatorProperty = "Contains",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                    "TestTrigger123"
                                    },
                                    //Transforms = new List<String> { "Uppercase" }
                                }
                            }
                        }
                    }),
                    RateLimitRules = new RateLimitRuleList(new List<RateLimitRule>
                    {
                        new RateLimitRule {
                            Name = "RateLimitRule1",
                            Priority = 1,
                            EnabledState = "Disabled",
                            RateLimitDurationInMinutes = 1,
                            RateLimitThreshold = 3,
                            MatchConditions = new List<MatchCondition> {
                                new MatchCondition {
                                    MatchVariable = "RemoteAddr",
                                    Selector = null,
                                    OperatorProperty = "IPMatch",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                        "131.107.0.0/16",
                                        "167.220.0.0/16"
                                    }
                                }
                            },
                            Action = "Block"
                        },
                        new RateLimitRule {
                            Name = "RateLimitRule2",
                            Priority = 10,
                            EnabledState = "Enabled",
                            RateLimitDurationInMinutes = 1,
                            RateLimitThreshold = 1,
                            MatchConditions = new List<MatchCondition> {
                                new MatchCondition {
                                    MatchVariable = "RequestUri",
                                    Selector = null,
                                    OperatorProperty = "Contains",
                                    NegateCondition = false,
                                    MatchValue = new List<string> {
                                    "yes"
                                    }
                                }
                            },
                            Action = "Block"
                        }
                    }),
                    ManagedRules = new ManagedRuleSetList(new List<ManagedRuleSet>
                    {
                        new ManagedRuleSet {
                            RuleSetType = "DefaultRuleSet",
                            RuleSetVersion = "1.0",
                            RuleGroupOverrides = new List<ManagedRuleGroupOverride> {
                                new ManagedRuleGroupOverride {
                                    RuleGroupName = "JAVA",
                                    Rules = new List<ManagedRuleOverride> {
                                        new ManagedRuleOverride {
                                            RuleId = "944100",
                                            EnabledState = "Disabled",
                                            Action = "Redirect"
                                        }
                                    }
                                }
                            }
                        }
                    }),
                    Tags = new Dictionary<string, string>
                    {
                        { "abc", "123" }
                    }
                };
                var policy2 = cdnMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policy2Name, expect2);
                AssertPoliciesEqual(resourcesClient.SubscriptionId, resourceGroupName, policy2Name, new List<CdnEndpoint>(), expect2, policy2);
            }
        }

        [Fact(Skip = "CDN WAF features are not working for new API versions due to a known issue")]
        public void WafPolicyDeleteTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a minimal CDN WAF policy
                var policyName = TestUtilities.GenerateName("policy");
                var policy = cdnMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, new CdnWebApplicationFirewallPolicy
                {
                    Sku = new Sku(SkuName.StandardMicrosoft),
                    Location = "Global",
                });

                Assert.Equal(PolicyResourceState.Enabled, policy.ResourceState);

                // List WAF policies should return one
                var policies = cdnMgmtClient.Policies.List(resourceGroupName.ToUpperInvariant());
                Assert.Single(policies);

                // Delete existing WAF policy should succeed
                cdnMgmtClient.Policies.Delete(resourceGroupName, policyName);

                // List WAF policies should return none
                policies = cdnMgmtClient.Policies.List(resourceGroupName.ToUpperInvariant());
                Assert.Empty(policies);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact(Skip = "CDN WAF features are not working for new API versions due to a known issue")]
        public void WafPolicyGetListTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // List WAF policies should return none
                var policies = cdnMgmtClient.Policies.List(resourceGroupName.ToUpperInvariant());
                Assert.Empty(policies);

                // Create a minimal CDN WAF policy
                var policyName = TestUtilities.GenerateName("policy");
                var policy = cdnMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, new CdnWebApplicationFirewallPolicy
                {
                    Sku = new Sku(SkuName.StandardMicrosoft),
                    Location = "Global",
                });
                
                // Get WAF policies returns the created policy
                var existingPolicy = cdnMgmtClient.Policies.Get(resourceGroupName, policyName);
                Assert.NotNull(existingPolicy);
                Assert.Equal(existingPolicy.ResourceState, PolicyResourceState.Enabled);

                // List WAF policies should return one policy
                policies = cdnMgmtClient.Policies.List(resourceGroupName.ToUpperInvariant());
                Assert.Single(policies);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        private static void AssertPoliciesEqual(string expectSubscriptionId, string expectResourceGroupName, string expectName, IList<CdnEndpoint> expectEndpointLinks, CdnWebApplicationFirewallPolicy expect, CdnWebApplicationFirewallPolicy actual)
        {
            Assert.Equal(expectName, actual.Name);
            Assert.Equal($"/subscriptions/{expectSubscriptionId}/resourcegroups/{expectResourceGroupName}/providers/Microsoft.Cdn/cdnwebapplicationfirewallpolicies/{expectName}", actual.Id);
            Assert.Equal(expect.Location, actual.Location);
            Assert.Equal(expect.Sku.Name, actual.Sku.Name);
            Assert.Equal(ProvisioningState.Succeeded, actual.ProvisioningState);
            Assert.Equal(PolicyResourceState.Enabled, actual.ResourceState);
            Assert.Equal(expect.Etag, actual.Etag);
            if (expect.RateLimitRules == null)
            {
                Assert.Null(actual.RateLimitRules);
            }
            else
            {
                Assert.Equal(expect.RateLimitRules.Rules.Count(), actual.RateLimitRules.Rules.Count());
                foreach (var pair in expect.RateLimitRules.Rules.Zip(actual.RateLimitRules.Rules, (e, a) => new { Expect = e, Actual = a }))
                {
                    Assert.Equal(pair.Expect.Action, pair.Actual.Action);
                    Assert.Equal(pair.Expect.EnabledState, pair.Actual.EnabledState);
                    Assert.Equal(pair.Expect.Name, pair.Actual.Name);
                    Assert.Equal(pair.Expect.Priority, pair.Actual.Priority);
                    Assert.Equal(pair.Expect.RateLimitDurationInMinutes, pair.Actual.RateLimitDurationInMinutes);
                    Assert.Equal(pair.Expect.RateLimitThreshold, pair.Actual.RateLimitThreshold);
                    if (pair.Expect.MatchConditions == null)
                    {
                        Assert.Null(pair.Actual.MatchConditions);
                    }
                    else
                    {
                        Assert.Equal(pair.Expect.MatchConditions.Count(), pair.Actual.MatchConditions.Count());
                        foreach (var mc in pair.Expect.MatchConditions.Zip(pair.Actual.MatchConditions, (e, a) => new { Expect = e, Actual = a }))
                        {
                            Assert.Equal(mc.Expect.MatchValue, mc.Actual.MatchValue);
                            Assert.Equal(mc.Expect.MatchVariable, mc.Actual.MatchVariable);
                            Assert.Equal(mc.Expect.NegateCondition, mc.Actual.NegateCondition);
                            Assert.Equal(mc.Expect.OperatorProperty, mc.Actual.OperatorProperty);
                            Assert.Equal(mc.Expect.Selector, mc.Actual.Selector);
                            Assert.Equal(mc.Expect.Transforms, mc.Actual.Transforms);
                        }
                    }
                }
            }

            if (expect.CustomRules == null)
            {
                Assert.Null(actual.CustomRules);
            }
            else
            {
                Assert.Equal(expect.CustomRules.Rules.Count(), actual.CustomRules.Rules.Count());
                foreach (var pair in expect.CustomRules.Rules.Zip(actual.CustomRules.Rules, (e, a) => new { Expect = e, Actual = a }))
                {
                    Assert.Equal(pair.Expect.Action, pair.Actual.Action);
                    Assert.Equal(pair.Expect.EnabledState, pair.Actual.EnabledState);
                    Assert.Equal(pair.Expect.Name, pair.Actual.Name);
                    Assert.Equal(pair.Expect.Priority, pair.Actual.Priority);
                    if (pair.Expect.MatchConditions == null)
                    {
                        Assert.Null(pair.Actual.MatchConditions);
                    }
                    else
                    {
                        Assert.Equal(pair.Expect.MatchConditions.Count(), pair.Actual.MatchConditions.Count());
                        foreach (var mc in pair.Expect.MatchConditions.Zip(pair.Actual.MatchConditions, (e, a) => new { Expect = e, Actual = a }))
                        {
                            Assert.Equal(mc.Expect.MatchValue, mc.Actual.MatchValue);
                            Assert.Equal(mc.Expect.MatchVariable, mc.Actual.MatchVariable);
                            Assert.Equal(mc.Expect.NegateCondition, mc.Actual.NegateCondition);
                            Assert.Equal(mc.Expect.OperatorProperty, mc.Actual.OperatorProperty);
                            Assert.Equal(mc.Expect.Selector, mc.Actual.Selector);
                            Assert.Equal(mc.Expect.Transforms, mc.Actual.Transforms);
                        }
                    }
                }
            }

            if (expect.ManagedRules == null)
            {
                Assert.Null(actual.ManagedRules);
            }
            else
            {
                Assert.Equal(expect.ManagedRules.ManagedRuleSets.Count(), actual.ManagedRules.ManagedRuleSets.Count());
                foreach (var pair in expect.ManagedRules.ManagedRuleSets.Zip(actual.ManagedRules.ManagedRuleSets, (e, a) => new { Expect = e, Actual = a }))
                {
                    Assert.Equal(pair.Expect.RuleSetType, pair.Actual.RuleSetType);
                    Assert.Equal(pair.Expect.RuleSetVersion, pair.Actual.RuleSetVersion);
                    if (pair.Expect.RuleGroupOverrides == null)
                    {
                        Assert.Null(pair.Actual.RuleGroupOverrides);
                    }
                    else
                    {
                        Assert.Equal(pair.Expect.RuleGroupOverrides.Count(), pair.Actual.RuleGroupOverrides.Count());
                        foreach (var rg in pair.Expect.RuleGroupOverrides.Zip(pair.Actual.RuleGroupOverrides, (e, a) => new { Expect = e, Actual = a }))
                        {
                            Assert.Equal(rg.Expect.RuleGroupName, rg.Actual.RuleGroupName);
                            if (rg.Expect.Rules == null)
                            {
                                Assert.Null(rg.Actual.Rules);
                            }
                            else
                            {
                                Assert.Equal(rg.Expect.Rules.Count(), rg.Actual.Rules.Count());
                                foreach (var r in rg.Expect.Rules.Zip(rg.Actual.Rules, (e, a) => new { Expect = e, Actual = a }))
                                {
                                    Assert.Equal(r.Expect.Action, r.Actual.Action);
                                    Assert.Equal(r.Expect.EnabledState, r.Actual.EnabledState);
                                    Assert.Equal(r.Expect.RuleId, r.Actual.RuleId);
                                }
                            }
                        }
                    }
                }
            }
            
            Assert.Equal(expect.PolicySettings.DefaultCustomBlockResponseBody, actual.PolicySettings.DefaultCustomBlockResponseBody);
            Assert.Equal(expect.PolicySettings.DefaultCustomBlockResponseStatusCode, actual.PolicySettings.DefaultCustomBlockResponseStatusCode);
            Assert.Equal(expect.PolicySettings.DefaultRedirectUrl, actual.PolicySettings.DefaultRedirectUrl);
            Assert.Equal(expect.PolicySettings.EnabledState, actual.PolicySettings.EnabledState);
            Assert.Equal(expect.PolicySettings.Mode, actual.PolicySettings.Mode);
            if (expectEndpointLinks == null)
            {
                Assert.Null(actual.EndpointLinks);
            }
            else
            {
                Assert.Equal(expectEndpointLinks.Count(), actual.EndpointLinks.Count());
                foreach (var pair in expectEndpointLinks.Zip(actual.EndpointLinks, (e, a) => new { Expect = e, Actual = a }))
                {
                    Assert.Equal(pair.Expect.Id, pair.Actual.Id);
                }
            }
        }
    }
}