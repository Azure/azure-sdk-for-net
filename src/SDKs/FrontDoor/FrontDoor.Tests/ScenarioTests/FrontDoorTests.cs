// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.Azure.Management.FrontDoor.Models;
using FrontDoor.Tests.Helpers;
using Microsoft.Azure.Management.Resources.Models;
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
            
            string subid = ConnectionStringKeys.SubscriptionIdKey;
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var frontDoorMgmtClient = FrontDoorTestUtilities.GetFrontDoorManagementClient(context, handler1);
                var resourcesClient = FrontDoorTestUtilities.GetResourceManagementClient(context, handler2);
                
                // Create resource group
                var resourceGroupName = FrontDoorTestUtilities.CreateResourceGroup(resourcesClient);

                // Create two different frontDoor
                string frontDoorName = TestUtilities.GenerateName("frontDoor");

                RoutingRule routingrule1 = new RoutingRule(
                    name: "routingrule1",
                    frontendEndpoints: new List<refID> { new refID("/subscriptions/"+subid+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.Network/frontDoors/"+frontDoorName+"/frontendEndpoints/frontendEndpoint1")},
                    acceptedProtocols: new List<string> { "Https" },
                    patternsToMatch: new List<string> { "/*" },
                    forwardingProtocol: "MatchRequest",
                    backendPool: new refID("/subscriptions/"+subid+"/resourceGroups/"+resourceGroupName+"/providers/Microsoft.Network/frontDoors/"+frontDoorName+"/backendPools/backendPool1"),
                    enabledState: "Enabled"
                );
                HealthProbeSettingsModel healthProbeSettings1 = new HealthProbeSettingsModel(
                        name: "healthProbeSettings1",
                        path: "/",
                        protocol: "Http",
                        intervalInSeconds: 120
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
                    BackendPools = new List<BackendPool> { backendPool1 }
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var frontDoorMgmtClient = FrontDoorTestUtilities.GetFrontDoorManagementClient(context, handler1);
                var resourcesClient = FrontDoorTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = FrontDoorTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a frontDoor
                string policyName = TestUtilities.GenerateName("policy");

                WebApplicationFirewallPolicy1 createParameters = new WebApplicationFirewallPolicy1
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
                        Mode = "Prevention"
                    },
                    CustomRules = new CustomRules(
                        new List<CustomRule>
                        {
                            new CustomRule
                            {
                                Name = "rule1",
                                Priority = 1,
                                RuleType = "RateLimitRule",
                                RateLimitThreshold = 1000,
                                MatchConditions = new List<MatchCondition1>
                                {
                                    new MatchCondition1
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
                    ManagedRules = new ManagedRuleSets(
                        new List <ManagedRuleSet> {
                            new AzureManagedRuleSet
                            {
                                Priority = 1,
                                RuleGroupOverrides = new List<AzureManagedOverrideRuleGroup>
                                {
                                    new AzureManagedOverrideRuleGroup
                                    {
                                        RuleGroupOverride = "SqlInjection",
                                        Action = "Block"
                                    },
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
                    MatchConditions = new List<MatchCondition1>
                                {
                                    new MatchCondition1
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


                var updatedPolicy = frontDoorMgmtClient.Policies.CreateOrUpdate(resourceGroupName,policyName, retrievedPolicy);

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
        private static void VerifyPolicy(WebApplicationFirewallPolicy1 policy, WebApplicationFirewallPolicy1 parameters)
        {
            Assert.Equal(policy.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(policy.Tags.Count, parameters.Tags.Count);
            Assert.True(policy.Tags.SequenceEqual(parameters.Tags));
            Assert.Equal(policy.PolicySettings.EnabledState, parameters.PolicySettings.EnabledState);
            Assert.Equal(policy.PolicySettings.Mode, parameters.PolicySettings.Mode);
            Assert.Equal(policy.CustomRules.Rules.Count, parameters.CustomRules.Rules.Count);
            Assert.Equal(policy.ManagedRules.RuleSets.Count, parameters.ManagedRules.RuleSets.Count);
        }

        private static void VerifyFrontDoor(FrontDoorModel frontDoor, FrontDoorModel parameters)
        {
            Assert.Equal(frontDoor.Location.ToLower(), parameters.Location.ToLower());
            Assert.Equal(frontDoor.FriendlyName, parameters.FriendlyName);
            Assert.Equal(frontDoor.Tags.Count, parameters.Tags.Count);
            Assert.True(frontDoor.Tags.SequenceEqual(parameters.Tags));
            VerifyRoutingRules(frontDoor.RoutingRules, parameters.RoutingRules);
            VerifyBackendPool(frontDoor.BackendPools, parameters.BackendPools);
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
                Assert.Equal(routingRules[i].CustomForwardingPath, parameters[i].CustomForwardingPath);
                Assert.Equal(routingRules[i].ForwardingProtocol, parameters[i].ForwardingProtocol);
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

        private static void VerifyHealthProbeSettings(IList<HealthProbeSettingsModel> healthProbeSettings, IList<HealthProbeSettingsModel> parameters)
        {
            Assert.Equal(healthProbeSettings.Count, parameters.Count);
            for (int i = 0; i < parameters.Count; i++)
            {
                Assert.Equal(healthProbeSettings[i].Path, parameters[i].Path);
                Assert.Equal(healthProbeSettings[i].Protocol, parameters[i].Protocol);
                Assert.Equal(healthProbeSettings[i].IntervalInSeconds, parameters[i].IntervalInSeconds);
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