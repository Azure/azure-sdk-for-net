// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.Azure.Management.FrontDoor.Models;
using FrontDoor.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using refID = Microsoft.Azure.Management.FrontDoor.Models.SubResource;

namespace FrontDoor.Tests.ScenarioTests
{
    public class FrontDoorTests
    {

        [Fact]
        public void FrontDoorCRUDTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var frontDoorMgmtClient = FrontDoorTestUtilities.GetFrontDoorManagementClient(context, handler1);
                var resourcesClient = FrontDoorTestUtilities.GetResourceManagementClient(context, handler2);

                // Get subscription id
                string subid = frontDoorMgmtClient.SubscriptionId;

                // Create resource group
                var resourceGroupName = FrontDoorTestUtilities.CreateResourceGroup(resourcesClient);

                // Create two different frontDoor
                string frontDoorName = TestUtilities.GenerateName("frontDoor");

                ForwardingConfiguration forwardingConfiguration = new ForwardingConfiguration(
                    forwardingProtocol: "MatchRequest",
                    backendPool: new refID("/subscriptions/" + subid + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/frontDoors/" + frontDoorName + "/backendPools/backendPool1"));
                
                RoutingRule routingrule1 = new RoutingRule(
                    name: "routingrule1",
                    frontendEndpoints: new List<refID> { new refID("/subscriptions/"+subid+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.Network/frontDoors/"+frontDoorName+"/frontendEndpoints/frontendEndpoint1")},
                    acceptedProtocols: new List<string> { "Https" },
                    patternsToMatch: new List<string> { "/*" },
                    routeConfiguration: forwardingConfiguration,
                    enabledState: "Enabled"
                );
                HealthProbeSettingsModel healthProbeSettings1 = new HealthProbeSettingsModel(
                        name: "healthProbeSettings1",
                        path: "/",
                        protocol: "Http",
                        intervalInSeconds: 120,
                        //healthProbeMethod: "GET",
                        enabledState: "Enabled"
                    );
                
                LoadBalancingSettingsModel loadBalancingSettings1 = new LoadBalancingSettingsModel(
                    name: "loadBalancingSettings1",
                    additionalLatencyMilliseconds: 0,
                    sampleSize: 4,
                    successfulSamplesRequired: 2
                    );

                Backend backend1 = new Backend(
                    address: "contoso1.azurewebsites.net",
                    httpPort: 80,
                    httpsPort: 443,
                    enabledState: "Enabled",
                    weight: 1,
                    priority: 2
                    );

                BackendPool backendPool1 = new BackendPool(
                    name: "backendPool1",
                    backends: new List<Backend> { backend1 },
                    loadBalancingSettings: new refID("/subscriptions/"+subid+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.Network/frontDoors/"+frontDoorName+ "/loadBalancingSettings/loadBalancingSettings1"),
                    healthProbeSettings: new refID("/subscriptions/"+subid+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.Network/frontDoors/"+frontDoorName+"/healthProbeSettings/healthProbeSettings1")
                    );

                BackendPoolsSettings backendPoolsSettings1 = new BackendPoolsSettings(
                    sendRecvTimeoutSeconds: 123
                    );

                FrontendEndpoint frontendEndpoint1 = new FrontendEndpoint(
                    name: "frontendEndpoint1",
                    hostName: frontDoorName+".azurefd.net",
                    sessionAffinityEnabledState: "Disabled",
                    sessionAffinityTtlSeconds: 0
                    );

                FrontDoorModel createParameters = new FrontDoorModel
                {
                    Location = "global",
                    FriendlyName = frontDoorName,
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        },
                    RoutingRules = new List<RoutingRule> { routingrule1 },
                    LoadBalancingSettings = new List<LoadBalancingSettingsModel> { loadBalancingSettings1 },
                    HealthProbeSettings = new List<HealthProbeSettingsModel> { healthProbeSettings1 },
                    FrontendEndpoints = new List<FrontendEndpoint> { frontendEndpoint1 },
                    BackendPools = new List<BackendPool> { backendPool1 },
                    BackendPoolsSettings = backendPoolsSettings1
                };

                var createdFrontDoor = frontDoorMgmtClient.FrontDoors.CreateOrUpdate(resourceGroupName, frontDoorName, createParameters);
                
                // validate that correct frontdoor is created
                VerifyFrontDoor(createdFrontDoor, createParameters);

                // Retrieve frontdoor 
                var retrievedFrontDoor = frontDoorMgmtClient.FrontDoors.Get(resourceGroupName, frontDoorName);

                // validate that correct frontdoor is retrieved
                VerifyFrontDoor(retrievedFrontDoor, createParameters);

                // update FrontDoor
                retrievedFrontDoor.Tags = new Dictionary<string, string>
                        {
                            {"key3","value3"},
                            {"key4","value4"}
                        };


                var updatedFrontDoor = frontDoorMgmtClient.FrontDoors.CreateOrUpdate(resourceGroupName, frontDoorName, retrievedFrontDoor);

                // validate that frontDoor is correctly updated
                VerifyFrontDoor(updatedFrontDoor, retrievedFrontDoor);

                // Delete frontDoor
                frontDoorMgmtClient.FrontDoors.Delete(resourceGroupName, frontDoorName);

                // Verify that frontDoor is deleted
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    frontDoorMgmtClient.FrontDoors.Get(resourceGroupName, frontDoorName);
                });

                FrontDoorTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);

            }
        }

        [Fact]
        public void WAFCRUDTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var frontDoorMgmtClient = FrontDoorTestUtilities.GetFrontDoorManagementClient(context, handler1);
                var resourcesClient = FrontDoorTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = FrontDoorTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a frontDoor WAF policy
                string policyName = TestUtilities.GenerateName("policy");

                WebApplicationFirewallPolicy createParameters = new WebApplicationFirewallPolicy
                {
                    Location = "global",
                    Tags = new Dictionary<string, string>
                    {
                        {"key1","value1"},
                        {"key2","value2"}
                    },
                    PolicySettings = new PolicySettings
                    {
                        EnabledState = "Enabled",
                        Mode = "Prevention",
                        CustomBlockResponseBody = "PGh0bWw+SGVsbG88L2h0bWw+",
                        CustomBlockResponseStatusCode = 403,
                        RedirectUrl = "http://www.bing.com"
                    },
                    CustomRules = new CustomRuleList(
                        new List<CustomRule>
                        {
                            new CustomRule
                            {
                                Name = "rule1",
                                EnabledState = "Enabled",
                                Priority = 1,
                                RuleType = "RateLimitRule",
                                RateLimitThreshold = 1000,
                                MatchConditions = new List<MatchCondition>
                                {
                                    new MatchCondition
                                    {
                                        MatchVariable = "RemoteAddr",
                                        OperatorProperty = "IPMatch",
                                        MatchValue = new List<string>
                                        {
                                            "192.168.1.0/24",
                                            "10.0.0.0/24"
                                        }
                                    }
                                },
                                Action = "Block"
                            }
                        }
                    ),
                    ManagedRules = new ManagedRuleSetList(
                        new List<ManagedRuleSet> {
                            new ManagedRuleSet
                            {
                                RuleSetType = "DefaultRuleSet",
                                RuleSetVersion = "1.0",
                                Exclusions = new List<ManagedRuleExclusion>
                                {
                                    new ManagedRuleExclusion
                                    {
                                        MatchVariable = ManagedRuleExclusionMatchVariable.RequestBodyPostArgNames,
                                        SelectorMatchOperator = ManagedRuleExclusionSelectorMatchOperator.Contains,
                                        Selector = "query"
                                    }
                                },
                                RuleGroupOverrides = new List<ManagedRuleGroupOverride>
                                {
                                    new ManagedRuleGroupOverride
                                    {
                                        RuleGroupName = "SQLI",
                                        Exclusions = new List<ManagedRuleExclusion>
                                        {
                                                new ManagedRuleExclusion
                                                {
                                                    MatchVariable = ManagedRuleExclusionMatchVariable.RequestHeaderNames,
                                                    SelectorMatchOperator = ManagedRuleExclusionSelectorMatchOperator.Equals,
                                                    Selector = "User-Agent"
                                                }
                                        },
                                        Rules = new List<ManagedRuleOverride>
                                        {
                                            new ManagedRuleOverride
                                            {
                                                RuleId = "942100",
                                                Action = "Redirect",
                                                EnabledState = "Disabled",
                                                Exclusions = new List<ManagedRuleExclusion>
                                                {
                                                    new ManagedRuleExclusion
                                                    {
                                                        MatchVariable = ManagedRuleExclusionMatchVariable.QueryStringArgNames,
                                                        SelectorMatchOperator = ManagedRuleExclusionSelectorMatchOperator.Equals,
                                                        Selector = "search"
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                    })

                };

                var policy = frontDoorMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, createParameters);

                // validate the created policy
                VerifyPolicy(policy, createParameters);

                // Retrieve policy
                var retrievedPolicy = frontDoorMgmtClient.Policies.Get(resourceGroupName, policyName);

                // validate that correct policy is retrieved
                VerifyPolicy(retrievedPolicy, createParameters);

                // update Policy
                CustomRule geoFilter = new CustomRule
                {
                    Name = "rule2",
                    Priority = 2,
                    RuleType = "MatchRule",
                    MatchConditions = new List<MatchCondition>
                                {
                                    new MatchCondition
                                    {
                                        MatchVariable = "RemoteAddr",
                                        OperatorProperty = "GeoMatch",
                                        MatchValue = new List<string>
                                        {
                                            "US"
                                        }
                                    }
                                },
                    Action = "Allow"
                };
                retrievedPolicy.CustomRules.Rules.Add(geoFilter);


                var updatedPolicy = frontDoorMgmtClient.Policies.CreateOrUpdate(resourceGroupName, policyName, retrievedPolicy);

                // validate that Policy is correctly updated
                VerifyPolicy(updatedPolicy, retrievedPolicy);

                // Delete Policy
                frontDoorMgmtClient.Policies.Delete(resourceGroupName, policyName);

                // Verify that Policy is deleted
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    frontDoorMgmtClient.Policies.Get(resourceGroupName, policyName);
                });

                FrontDoorTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        private static void VerifyPolicy(WebApplicationFirewallPolicy policy, WebApplicationFirewallPolicy parameters)
        {
            Assert.Equal(policy.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(policy.Tags.Count, parameters.Tags.Count);
            Assert.True(policy.Tags.SequenceEqual(parameters.Tags));
            Assert.Equal(policy.PolicySettings.EnabledState, parameters.PolicySettings.EnabledState);
            Assert.Equal(policy.PolicySettings.Mode, parameters.PolicySettings.Mode);
            Assert.Equal(policy.PolicySettings.CustomBlockResponseBody, parameters.PolicySettings.CustomBlockResponseBody);
            Assert.Equal(policy.PolicySettings.CustomBlockResponseStatusCode, parameters.PolicySettings.CustomBlockResponseStatusCode);
            Assert.Equal(policy.PolicySettings.RedirectUrl, parameters.PolicySettings.RedirectUrl);
            Assert.Equal(policy.CustomRules.Rules.Count, parameters.CustomRules.Rules.Count);
            Assert.Equal(policy.ManagedRules.ManagedRuleSets.Count, parameters.ManagedRules.ManagedRuleSets.Count);
            Assert.Equal(policy.ManagedRules.ManagedRuleSets[0].Exclusions.Count, parameters.ManagedRules.ManagedRuleSets[0].Exclusions.Count);
            Assert.Equal(policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides[0].Exclusions.Count, parameters.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides[0].Exclusions.Count);
            Assert.Equal(policy.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides[0].Rules[0].Exclusions.Count, parameters.ManagedRules.ManagedRuleSets[0].RuleGroupOverrides[0].Rules[0].Exclusions.Count);
        }

        private static void VerifyFrontDoor(FrontDoorModel frontDoor, FrontDoorModel parameters)
        {
            Assert.Equal(frontDoor.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(frontDoor.FriendlyName, parameters.FriendlyName);
            Assert.Equal(frontDoor.Tags.Count, parameters.Tags.Count);
            Assert.True(frontDoor.Tags.SequenceEqual(parameters.Tags));
            VerifyRoutingRules(frontDoor.RoutingRules, parameters.RoutingRules);
            VerifyBackendPool(frontDoor.BackendPools, parameters.BackendPools);
            VerifyBackendPoolsSettings(frontDoor.BackendPoolsSettings, parameters.BackendPoolsSettings);
            VerifyHealthProbeSettings(frontDoor.HealthProbeSettings, parameters.HealthProbeSettings);
            VerifyLoadBalancingSettings(frontDoor.LoadBalancingSettings, parameters.LoadBalancingSettings);
            VerifyFrontendEndpoint(frontDoor.FrontendEndpoints, parameters.FrontendEndpoints);
        }

        private static void VerifyRoutingRules(IList<RoutingRule> routingRules, IList<RoutingRule> parameters)
        {
            Assert.Equal(routingRules.Count, parameters.Count);
            for (int i = 0; i < routingRules.Count; i++)
            {
                Assert.Equal(routingRules[i].AcceptedProtocols, parameters[i].AcceptedProtocols);
                Assert.Equal(routingRules[i].PatternsToMatch, parameters[i].PatternsToMatch);
                Assert.Equal((routingRules[i].RouteConfiguration as ForwardingConfiguration).CustomForwardingPath, (parameters[i].RouteConfiguration as ForwardingConfiguration).CustomForwardingPath);
                Assert.Equal((routingRules[i].RouteConfiguration as ForwardingConfiguration).ForwardingProtocol, (parameters[i].RouteConfiguration as ForwardingConfiguration).ForwardingProtocol);
            }
        }

        private static void VerifyBackendPool(IList<BackendPool> backendPools, IList<BackendPool> parameters)
        {
            Assert.Equal(backendPools.Count, parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                VerifyBackend(backendPools[i].Backends, parameters[i].Backends);
            }
        }
        private static void VerifyBackend(IList<Backend> backends, IList<Backend> parameters)
        {
            Assert.Equal(backends.Count, parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                Assert.Equal(backends[i].Address, parameters[i].Address);
                Assert.Equal(backends[i].Priority, parameters[i].Priority);
                Assert.Equal(backends[i].Weight, parameters[i].Weight);
                Assert.Equal(backends[i].HttpPort, parameters[i].HttpPort);
                Assert.Equal(backends[i].HttpsPort, parameters[i].HttpsPort);
                Assert.Equal(backends[i].BackendHostHeader, parameters[i].BackendHostHeader);
                Assert.Equal(backends[i].EnabledState, parameters[i].EnabledState);
            }
        }

        private static void VerifyBackendPoolsSettings(BackendPoolsSettings backendPoolsSettings, BackendPoolsSettings parameters)
        {
            Assert.Equal(backendPoolsSettings.SendRecvTimeoutSeconds, parameters.SendRecvTimeoutSeconds);
        }

        private static void VerifyHealthProbeSettings(IList<HealthProbeSettingsModel> healthProbeSettings, IList<HealthProbeSettingsModel> parameters)
        {
            Assert.Equal(healthProbeSettings.Count, parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                Assert.Equal(healthProbeSettings[i].Path, parameters[i].Path);
                Assert.Equal(healthProbeSettings[i].Protocol, parameters[i].Protocol);
                Assert.Equal(healthProbeSettings[i].IntervalInSeconds, parameters[i].IntervalInSeconds);
                //Assert.Equal(healthProbeSettings[i].HealthProbeMethod, parameters[i].HealthProbeMethod);
                Assert.Equal(healthProbeSettings[i].EnabledState, parameters[i].EnabledState);
            }
        }

        private static void VerifyLoadBalancingSettings(IList<LoadBalancingSettingsModel> loadBalancingSettings, IList<LoadBalancingSettingsModel> parameters)
        {
            Assert.Equal(loadBalancingSettings.Count, parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                Assert.Equal(loadBalancingSettings[i].SampleSize, parameters[i].SampleSize);
                Assert.Equal(loadBalancingSettings[i].SuccessfulSamplesRequired, parameters[i].SuccessfulSamplesRequired);
                Assert.Equal(loadBalancingSettings[i].AdditionalLatencyMilliseconds, parameters[i].AdditionalLatencyMilliseconds);
            }
        }

        private static void VerifyFrontendEndpoint(IList<FrontendEndpoint> frontendEndpoint, IList<FrontendEndpoint> parameters)
        {
            Assert.Equal(frontendEndpoint.Count, parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                Assert.Equal(frontendEndpoint[i].HostName, parameters[i].HostName);
                Assert.Equal(frontendEndpoint[i].SessionAffinityEnabledState, parameters[i].SessionAffinityEnabledState);
                Assert.Equal(frontendEndpoint[i].SessionAffinityTtlSeconds, parameters[i].SessionAffinityTtlSeconds);
            }
        }
    }
}
