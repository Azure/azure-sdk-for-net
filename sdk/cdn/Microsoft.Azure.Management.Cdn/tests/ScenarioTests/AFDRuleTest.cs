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
    public class AFDRuleTest
    {
        [Fact]
        public void AFDRuleCreateTest()
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

                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    Assert.NotNull(ruleSet);
                    Assert.Equal(ruleSetName, ruleSet.Name);

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
                    Assert.NotNull(rule);
                    Assert.Equal(ruleName, rule.Name);
                    Assert.Equal(ruleGroupCreateParameters.Conditions.Count, rule.Conditions.Count);
                    Assert.Equal(ruleGroupCreateParameters.Actions.Count, rule.Actions.Count);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDRuleUpdateTest()
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

                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    Assert.NotNull(ruleSet);
                    Assert.Equal(ruleSetName, ruleSet.Name);

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
                    Assert.NotNull(rule);
                    Assert.Equal(ruleName, rule.Name);
                    Assert.Equal(ruleGroupCreateParameters.Conditions.Count, rule.Conditions.Count);
                    Assert.Equal(ruleGroupCreateParameters.Actions.Count, rule.Actions.Count);


                    RuleUpdateParameters ruleUpdateProperties = new RuleUpdateParameters()
                    {
                        Conditions = new List<DeliveryRuleCondition>()
                        {
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
                    var updatedRule = cdnMgmtClient.Rules.Update(resourceGroupName, profileName, ruleSetName, ruleName, ruleUpdateProperties);
                    Assert.NotNull(updatedRule);
                    Assert.Equal(ruleName, updatedRule.Name);
                    Assert.Equal(ruleUpdateProperties.Conditions.Count, updatedRule.Conditions.Count);
                    Assert.Equal(ruleUpdateProperties.Actions.Count, updatedRule.Actions.Count);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDRuleDeleteTest()
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

                    string ruleSetName = TestUtilities.GenerateName("ruleSetName");
                    var ruleSet = cdnMgmtClient.RuleSets.Create(resourceGroupName, profileName, ruleSetName);
                    Assert.NotNull(ruleSet);
                    Assert.Equal(ruleSetName, ruleSet.Name);

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
                    cdnMgmtClient.Rules.Delete(resourceGroupName, profileName, ruleSetName, ruleName);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }


        [Fact]
        public void AFDRuleGetListTest()
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

                    var getRule = cdnMgmtClient.Rules.Get(resourceGroupName, profileName, ruleSetName, ruleName);
                    Assert.NotNull(rule);
                    Assert.Equal(ruleName, getRule.Name);
                    Assert.Equal(ruleGroupCreateParameters.Conditions.Count, getRule.Conditions.Count);
                    Assert.Equal(ruleGroupCreateParameters.Actions.Count, getRule.Actions.Count);

                    var ruleList = cdnMgmtClient.Rules.ListByRuleSet(resourceGroupName, profileName, ruleSetName);
                    Assert.NotNull(ruleList);
                    Assert.Single(ruleList);

                    cdnMgmtClient.Rules.Delete(resourceGroupName, profileName, ruleSetName, ruleName);
                    ruleList = cdnMgmtClient.Rules.ListByRuleSet(resourceGroupName, profileName, ruleSetName);
                    Assert.NotNull(ruleList);
                    Assert.Empty(ruleList);
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
