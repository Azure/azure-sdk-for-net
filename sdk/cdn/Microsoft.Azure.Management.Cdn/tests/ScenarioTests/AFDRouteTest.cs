// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Cdn.Tests.Helpers;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Cdn.Tests.ScenarioTests
{
    public class AFDRouteTest
    {
        [Fact]
        public void AFDRouteCreateTest()
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

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor originGroup
                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);

                    // Create a standard Azure frontdoor origin
                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);


                    // Create a standard Azure frontdoor ruleSet
                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    // Create a standard Azure frontdoor rule
                    string ruleName = TestUtilities.GenerateName("ruleName");
                    var ruleGroupCreateParameters = new Rule
                    {
                        Conditions = new List<DeliveryRuleCondition>()
                        {
                            new DeliveryRuleRequestUriCondition()
                            {
                                Parameters = new RequestUriMatchConditionParameters()
                                {
                                    OperatorProperty = "Any"
                                }
                            }
                        },
                        Actions = new List<DeliveryRuleAction>
                        {
                            new DeliveryRuleCacheExpirationAction()
                            {
                                Parameters = new CacheExpirationActionParameters()
                                {
                                    CacheBehavior = "Override",
                                    CacheDuration = "00:00:20"
                                }
                            }
                        }
                    };
                    var rule = cdnMgmtClient.Rules.Create(resourceGroupName, profileName, ruleSetName, ruleName, ruleGroupCreateParameters);

                    // Create a standard Azure frontdoor route
                    string routeName = TestUtilities.GenerateName("routeName");
                    var routeCreateParameters = new Route
                    {
                        OriginGroup = new ResourceReference(originGroup.Id),
                        RuleSets = new List<ResourceReference>()
                        {
                            new ResourceReference(ruleSet.Id),
                        },
                        PatternsToMatch = new List<string>()
                        {
                            "/*"
                        },
                        LinkToDefaultDomain = "Enabled",
                        EnabledState = "Enabled",
                    };
                    var route = cdnMgmtClient.Routes.Create(resourceGroupName, profileName, endpointName, routeName, routeCreateParameters);
                    Assert.NotNull(route);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDRouteUpdateTest()
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

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor originGroup
                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);

                    // Create a standard Azure frontdoor origin
                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);


                    // Create a standard Azure frontdoor ruleSet
                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    // Create a standard Azure frontdoor rule
                    string ruleName = TestUtilities.GenerateName("ruleName");
                    var ruleGroupCreateParameters = new Rule
                    {
                        Conditions = new List<DeliveryRuleCondition>()
                        {
                            new DeliveryRuleRequestUriCondition()
                            {
                                Parameters = new RequestUriMatchConditionParameters()
                                {
                                    OperatorProperty = "Any"
                                }
                            }
                        },
                        Actions = new List<DeliveryRuleAction>
                        {
                            new DeliveryRuleCacheExpirationAction()
                            {
                                Parameters = new CacheExpirationActionParameters()
                                {
                                    CacheBehavior = "Override",
                                    CacheDuration = "00:00:20"
                                }
                            }
                        }
                    };
                    var rule = cdnMgmtClient.Rules.Create(resourceGroupName, profileName, ruleSetName, ruleName, ruleGroupCreateParameters);

                    // Create a standard Azure frontdoor route
                    string routeName = TestUtilities.GenerateName("routeName");
                    var routeCreateParameters = new Route
                    {
                        OriginGroup = new ResourceReference(originGroup.Id),
                        RuleSets = new List<ResourceReference>()
                        {
                            new ResourceReference(ruleSet.Id),
                        },
                        PatternsToMatch = new List<string>()
                        {
                            "/*"
                        },
                        LinkToDefaultDomain = "Enabled",
                        EnabledState = "Enabled",
                    };
                    var route = cdnMgmtClient.Routes.Create(resourceGroupName, profileName, endpointName, routeName, routeCreateParameters);
                    Assert.NotNull(route);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDRouteDeleteTest()
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

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor originGroup
                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);

                    // Create a standard Azure frontdoor origin
                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);


                    // Create a standard Azure frontdoor ruleSet
                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    // Create a standard Azure frontdoor rule
                    string ruleName = TestUtilities.GenerateName("ruleName");
                    var ruleGroupCreateParameters = new Rule
                    {
                        Conditions = new List<DeliveryRuleCondition>()
                        {
                            new DeliveryRuleRequestUriCondition()
                            {
                                Parameters = new RequestUriMatchConditionParameters()
                                {
                                    OperatorProperty = "Any"
                                }
                            }
                        },
                        Actions = new List<DeliveryRuleAction>
                        {
                            new DeliveryRuleCacheExpirationAction()
                            {
                                Parameters = new CacheExpirationActionParameters()
                                {
                                    CacheBehavior = "Override",
                                    CacheDuration = "00:00:20"
                                }
                            }
                        }
                    };
                    var rule = cdnMgmtClient.Rules.Create(resourceGroupName, profileName, ruleSetName, ruleName, ruleGroupCreateParameters);

                    // Create a standard Azure frontdoor route
                    string routeName = TestUtilities.GenerateName("routeName");
                    var routeCreateParameters = new Route
                    {
                        OriginGroup = new ResourceReference(originGroup.Id),
                        RuleSets = new List<ResourceReference>()
                        {
                            new ResourceReference(ruleSet.Id),
                        },
                        PatternsToMatch = new List<string>()
                        {
                            "/*"
                        },
                        LinkToDefaultDomain = "Enabled",
                        EnabledState = "Enabled",
                    };
                    var route = cdnMgmtClient.Routes.Create(resourceGroupName, profileName, endpointName, routeName, routeCreateParameters);
                    cdnMgmtClient.Routes.Delete(resourceGroupName, profileName, endpointName, routeName);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDRouteGetListTest()
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

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor endpoint
                    string endpointName = TestUtilities.GenerateName("endpointName");
                    var endpointCreateParameters = new AFDEndpoint("WestUs")
                    {
                        EnabledState = "Enabled",
                        OriginResponseTimeoutSeconds = 60,
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var endpoint = cdnMgmtClient.AFDEndpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                    // Create a standard Azure frontdoor originGroup
                    string originGroupName = TestUtilities.GenerateName("originGroupName");
                    var originGroupCreateParameters = new AFDOriginGroup(name: originGroupName)
                    {
                        LoadBalancingSettings = new LoadBalancingSettingsParameters
                        {
                            SampleSize = 5,
                            SuccessfulSamplesRequired = 4,
                            AdditionalLatencyInMilliseconds = 200,
                        },
                        HealthProbeSettings = new HealthProbeParameters
                        {
                            ProbeIntervalInSeconds = 1,
                            ProbePath = "/",
                            ProbeProtocol = ProbeProtocol.Https,
                            ProbeRequestType = HealthProbeRequestType.GET
                        },
                    };
                    var originGroup = cdnMgmtClient.AFDOriginGroups.Create(resourceGroupName, profileName, originGroupName, originGroupCreateParameters);

                    // Create a standard Azure frontdoor origin
                    string originName = TestUtilities.GenerateName("originName");
                    var hostName = "en.wikipedia.org";
                    var originCreateParameters = new AFDOrigin(hostName: hostName)
                    {
                        OriginHostHeader = hostName,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Priority = 1,
                        Weight = 1000,
                    };
                    var origin = cdnMgmtClient.AFDOrigins.Create(resourceGroupName, profileName, originGroupName, originName, originCreateParameters);


                    // Create a standard Azure frontdoor ruleSet
                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    // Create a standard Azure frontdoor rule
                    string ruleName = TestUtilities.GenerateName("ruleName");
                    var ruleGroupCreateParameters = new Rule
                    {
                        Conditions = new List<DeliveryRuleCondition>()
                        {
                            new DeliveryRuleRequestUriCondition()
                            {
                                Parameters = new RequestUriMatchConditionParameters()
                                {
                                    OperatorProperty = "Any"
                                }
                            }
                        },
                        Actions = new List<DeliveryRuleAction>
                        {
                            new DeliveryRuleCacheExpirationAction()
                            {
                                Parameters = new CacheExpirationActionParameters()
                                {
                                    CacheBehavior = "Override",
                                    CacheDuration = "00:00:20"
                                }
                            }
                        }
                    };
                    var rule = cdnMgmtClient.Rules.Create(resourceGroupName, profileName, ruleSetName, ruleName, ruleGroupCreateParameters);

                    // Create a standard Azure frontdoor route
                    string routeName = TestUtilities.GenerateName("routeName");
                    var routeCreateParameters = new Route
                    {
                        OriginGroup = new ResourceReference(originGroup.Id),
                        RuleSets = new List<ResourceReference>()
                        {
                            new ResourceReference(ruleSet.Id),
                        },
                        PatternsToMatch = new List<string>()
                        {
                            "/*"
                        },
                        LinkToDefaultDomain = "Enabled",
                        EnabledState = "Enabled",
                    };
                    var route = cdnMgmtClient.Routes.Create(resourceGroupName, profileName, endpointName, routeName, routeCreateParameters);
                    Assert.NotNull(route);
                    Assert.Equal(routeName, route.Name);

                    var getRoute = cdnMgmtClient.Routes.Get(resourceGroupName, profileName, endpointName, routeName);
                    Assert.NotNull(getRoute);
                    Assert.Equal(routeName, getRoute.Name);

                    var routList = cdnMgmtClient.Routes.ListByEndpoint(resourceGroupName, profileName, endpointName);
                    Assert.NotNull(routList);
                    Assert.Single(routList);

                    cdnMgmtClient.Routes.Delete(resourceGroupName, profileName, endpointName, routeName);
                    routList = cdnMgmtClient.Routes.ListByEndpoint(resourceGroupName, profileName, endpointName);
                    Assert.NotNull(routList);
                    Assert.Empty(routList);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }
    }
}
