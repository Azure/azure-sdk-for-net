// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;

namespace Azure.ResourceManager.FrontDoor.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region FrontDoor
        public static void AssertFrontDoor(FrontDoorData data1, FrontDoorData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.FriendlyName, data2.FriendlyName);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
            Assert.AreEqual(data2.Cname, data2.Cname);
        }

        public static FrontDoorData GetFrontDoorData(AzureLocation location, string frontDoorName, string resourceGroupName, string subid)
        {
            var load = new FrontDoorLoadBalancingSettingsData()
            {
                Name = "loadBalancingSettings1",
                AdditionalLatencyMilliseconds = 0,
                SampleSize = 4,
                SuccessfulSamplesRequired = 2
            };
            var health = new FrontDoorHealthProbeSettingsData()
            {
                Name = "healthProbeSettings1",
                Path = "/",
                Protocol = FrontDoorProtocol.Http,
                IntervalInSeconds = 120,
                HealthProbeMethod = FrontDoorHealthProbeMethod.Get,
                EnabledState = HealthProbeEnabled.Enabled
            };
            var endpoints = new FrontendEndpointData()
            {
                Name = "frontendEndpoint1",
                SessionAffinityEnabledState = SessionAffinityEnabledState.Disabled,
                SessionAffinityTtlInSeconds = 0,
                HostName = frontDoorName + ".azurefd.net",
            };
            var backends = new FrontDoorBackend()
            {
                Address = "contoso1.azurewebsites.net",
                HttpPort = 80,
                HttpsPort = 443,
                EnabledState = BackendEnabledState.Enabled,
                Weight = 1,
                Priority = 2
            };
            var data = new FrontDoorData(location)
            {
                RoutingRules =
                {
                    new RoutingRuleData()
                    {
                        Name = "routingrule1",
                        PatternsToMatch =
                        {
                            "/*"
                        },
                        FrontendEndpoints =
                        {
                            new WritableSubResource()
                            {
                                Id = new ResourceIdentifier(subid + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/frontDoors/" + frontDoorName + "/frontendEndpoints/frontendEndpoint1")
                            }
                        },
                        AcceptedProtocols =
                        {
                            FrontDoorProtocol.Https
                        },
                        EnabledState = RoutingRuleEnabledState.Enabled,
                        RouteConfiguration = new ForwardingConfiguration()
                        {
                            ForwardingProtocol = FrontDoorForwardingProtocol.MatchRequest,
                            BackendPool = new WritableSubResource()
                            {
                                Id = new ResourceIdentifier(subid + "/resourcegroups/" + resourceGroupName + "/providers/Microsoft.Network/Frontdoors/" + frontDoorName + "/BackendPools/backendPool1")
                            }
                        }
                    }
                },
                HealthProbeSettings =
                {
                    health
                },
                BackendPoolsSettings = new BackendPoolsSettings()
                {
                    SendRecvTimeoutInSeconds = 123
                },
                LoadBalancingSettings =
                {
                    load
                },
                FrontendEndpoints =
                {
                    endpoints
                },
                BackendPools =
                {
                    new FrontDoorBackendPool()
                    {
                        Name = "backendPool1",
                        LoadBalancingSettings = new WritableSubResource()
                        {
                            Id = new ResourceIdentifier(subid + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/frontDoors/" + frontDoorName + "/loadBalancingSettings/loadBalancingSettings1")
                        },
                        HealthProbeSettings = new WritableSubResource()
                        {
                            Id = new ResourceIdentifier(subid + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/frontDoors/" + frontDoorName + "/healthProbeSettings/healthProbeSettings1")
                        },
                        Backends =
                        {
                            backends
                        }
                    }
                }
            };
            return data;
        }
        #endregion

        #region FrontDoorExperiment
        public static void AssertFrontDoorExperiment(FrontDoorExperimentData data1, FrontDoorExperimentData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.Description, data2.Description);
            Assert.AreEqual(data1.Status, data2.Status);
        }

        public static FrontDoorExperimentData GetFrontDoorExperimentData(AzureLocation location)
        {
            var data = new FrontDoorExperimentData(location)
            {
                ExperimentEndpointA = new FrontDoorExperimentEndpointProperties()
                {
                    Endpoint = "www.bing.com",
                    Name = "bing"
                },
                ExperimentEndpointB = new FrontDoorExperimentEndpointProperties()
                {
                    Endpoint = "www.constoso.com",
                    Name = "contoso"
                },
                EnabledState = FrontDoorExperimentState.Enabled
            };
            return data;
        }
        #endregion

        #region FrontDoorNetWorkExperiment
        public static void AssertFrontDoorNetWorkExperiment(FrontDoorNetworkExperimentProfileData data1, FrontDoorNetworkExperimentProfileData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.EnabledState, data2.EnabledState);
            Assert.AreEqual(data1.ResourceState, data2.ResourceState);
            Assert.AreEqual(data1.ETag, data2.ETag);
        }

        public static FrontDoorNetworkExperimentProfileData GetProfileData(AzureLocation location)
        {
            var data = new FrontDoorNetworkExperimentProfileData(location)
            {
                EnabledState = FrontDoorExperimentState.Disabled,
            };
            return data;
        }
        #endregion

        #region RultEngine
        public static void AssertRuleEngine(FrontDoorRulesEngineData data1, FrontDoorRulesEngineData data2)
        {
            Assert.AreEqual(data1.Name, data2.Name);
            Assert.AreEqual(data1.Id, data2.Id);
            Assert.AreEqual(data1.ResourceType, data2.ResourceType);
            Assert.AreEqual(data1.ResourceState, data2.ResourceState);
        }
        public static FrontDoorRulesEngineData GetRulesEngineData()
        {
            RulesEngineAction rulesEngineAction1 = new RulesEngineAction()
            {
                ResponseHeaderActions =
                {
                    new RulesEngineHeaderAction(RulesEngineHeaderActionType.Append, "X-TEST-HEADER")
                    {
                        Value = "Append Header Rule"
                    },
                }
            };
            RulesEngineAction rulesEngineAction2 = new RulesEngineAction()
            {
                ResponseHeaderActions =
                {
                    new RulesEngineHeaderAction(RulesEngineHeaderActionType.Overwrite, "Access-Control-Allow-Origin")
                    {
                        Value = "*"
                    },
                    new RulesEngineHeaderAction(RulesEngineHeaderActionType.Overwrite, "Access-Control-Allow-Credentials")
                    {
                        Value = "true"
                    },
                }
            };
            var data = new FrontDoorRulesEngineData()
            {
                Rules =
                {
                    new RulesEngineRule("debuggingoutput", 1, rulesEngineAction1),
                    new RulesEngineRule("overwriteorigin", 2, rulesEngineAction2)
                }
            };
            return data;
        }
        #endregion

        #region FrontDoorWebApplicationFirewallPolicyData
        public static void AssertPolicy(FrontDoorWebApplicationFirewallPolicyData data1, FrontDoorWebApplicationFirewallPolicyData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
            Assert.AreEqual(data1.ResourceState, data2.ResourceState);
        }

        public static FrontDoorWebApplicationFirewallPolicyData GetPolicyData(AzureLocation location)
        {
            IEnumerable<WebApplicationRuleMatchCondition> matchConditions1 = new List<WebApplicationRuleMatchCondition>()
            {
                new WebApplicationRuleMatchCondition(WebApplicationRuleMatchVariable.RemoteAddr, WebApplicationRuleMatchOperator.IPMatch, new List<String>(){ "192.168.1.0/24", "10.0.0.0/24"})
            };
            IEnumerable<WebApplicationRuleMatchCondition> matchConditions2 = new List<WebApplicationRuleMatchCondition>()
            {
                new WebApplicationRuleMatchCondition(WebApplicationRuleMatchVariable.RemoteAddr, WebApplicationRuleMatchOperator.GeoMatch, new List<String>(){ "CH"}),
                new WebApplicationRuleMatchCondition(WebApplicationRuleMatchVariable.RequestHeader, WebApplicationRuleMatchOperator.Contains, new List<String>(){ "windows" })
                {
                    Selector = "UserAgent",
                }
            };
            var data = new FrontDoorWebApplicationFirewallPolicyData(location)
            {
                PolicySettings = new FrontDoorWebApplicationFirewallPolicySettings()
                {
                    EnabledState = PolicyEnabledState.Enabled,
                    Mode = FrontDoorWebApplicationFirewallPolicyMode.Prevention,
                    RedirectUri = new Uri("http://www.bing.com")
,
                    CustomBlockResponseStatusCode = 429,
                    CustomBlockResponseBody = "PGh0bWw+CjxoZWFkZXI+PHRpdGxlPkhlbGxvPC90aXRsZT48L2hlYWRlcj4KPGJvZHk+CkhlbGxvIHdvcmxkCjwvYm9keT4KPC9odG1sPg==",
                    RequestBodyCheck = PolicyRequestBodyCheck.Disabled,
                },
                CustomRuleList = new CustomRuleList()
                {
                    Rules =
            {
                new WebApplicationCustomRule(1, WebApplicationRuleType.RateLimitRule, matchConditions1,RuleMatchActionType.Block)
                {
                    Name = "customrule1",
                    RateLimitThreshold = 5,
                },
                new WebApplicationCustomRule(2, WebApplicationRuleType.MatchRule, matchConditions2,RuleMatchActionType.Block)
                {
                    Name = "customrule2"
                }
            }
                },
                Sku = new FrontDoorSku()
                {
                    Name = "Premium_AzureFrontDoor"
                },
                ManagedRules = new ManagedRuleSetList()
                {
                    ManagedRuleSets =
            {
                new ManagedRuleSet("DefaultRuleSet", "1.0")
                {
                    RuleSetAction = ManagedRuleSetActionType.Block,
                    Exclusions =
                    {
                        new ManagedRuleExclusion(ManagedRuleExclusionMatchVariable.RequestHeaderNames, ManagedRuleExclusionSelectorMatchOperator.EqualsValue, "User-Agent")
                    },
                    RuleGroupOverrides =
                    {
                        new ManagedRuleGroupOverride("SQLI")
                        {
                            Exclusions =
                            {
                                new ManagedRuleExclusion(ManagedRuleExclusionMatchVariable.RequestCookieNames, ManagedRuleExclusionSelectorMatchOperator.StartsWith, "token")
                            },
                            Rules =
                            {
                                new ManagedRuleOverride("942100")
                                {
                                    EnabledState = ManagedRuleEnabledState.Enabled,
                                    Action = RuleMatchActionType.Redirect,
                                    Exclusions =
                                    {
                                        new ManagedRuleExclusion(ManagedRuleExclusionMatchVariable.RequestHeaderNames, ManagedRuleExclusionSelectorMatchOperator.EqualsValue, "query")
                                    }
                                },
                                new ManagedRuleOverride("942110")
                                {
                                    EnabledState = ManagedRuleEnabledState.Disabled
                                }
                            },
                        }
                    }
                }
            }
                }
            };
            return data;
        }
        #endregion
    }
}
