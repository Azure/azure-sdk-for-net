// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceCreateGetUpdateDeleteIPFilterRules()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create a namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create a namespace IPFilter
                var ipFilterRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.IPFilterRulesPrefix);
                var createIPFilterRuleParameter = new IpFilterRule()
                {
                    IpMask = "13.78.143.246/32",
                    FilterName = ipFilterRuleName,
                    Action = IPAction.Accept
                };

                var createNamespaceIPFilterRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateIpFilterRule(resourceGroup, namespaceName,
                    ipFilterRuleName, createIPFilterRuleParameter);
                Assert.NotNull(createNamespaceIPFilterRuleResponse);
                Assert.Equal(createIPFilterRuleParameter.IpMask, createNamespaceIPFilterRuleResponse.IpMask);
                Assert.Equal(ipFilterRuleName, createNamespaceIPFilterRuleResponse.Name);
                Assert.Equal(createIPFilterRuleParameter.Action, createNamespaceIPFilterRuleResponse.Action);

                // Get namespace IFilterRule
                var getNamespaceFilterRulesResponse = ServiceBusManagementClient.Namespaces.GetIpFilterRule(resourceGroup, namespaceName, ipFilterRuleName);
                Assert.NotNull(getNamespaceFilterRulesResponse);
                Assert.Equal(createIPFilterRuleParameter.IpMask, getNamespaceFilterRulesResponse.IpMask);
                Assert.Equal(ipFilterRuleName, getNamespaceFilterRulesResponse.Name);
                Assert.Equal(createIPFilterRuleParameter.Action, getNamespaceFilterRulesResponse.Action);
                
                // Get all namespaces AuthorizationRules
                var getAllNamespaceFilterRulesResponse = ServiceBusManagementClient.Namespaces.ListIPFilterRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceFilterRulesResponse);
                Assert.True( getAllNamespaceFilterRulesResponse.Count() > 0);

                // Update namespace authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                IpFilterRule updateNamespaceIPFilterRuleParameter = new IpFilterRule();
                updateNamespaceIPFilterRuleParameter.Action = IPAction.Accept;
                updateNamespaceIPFilterRuleParameter.IpMask = "13.78.144.246/32";

                var updateNamespaceIPFilterRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateIpFilterRule(resourceGroup,
                    namespaceName, ipFilterRuleName, updateNamespaceIPFilterRuleParameter);

                Assert.NotNull(updateNamespaceIPFilterRuleResponse);
                Assert.Equal(ipFilterRuleName, updateNamespaceIPFilterRuleResponse.Name);
                Assert.True(updateNamespaceIPFilterRuleResponse.IpMask != createNamespaceIPFilterRuleResponse.IpMask);

                // Get the updated namespace AuthorizationRule
                var getNamespaceIPFilterRuleResponse = ServiceBusManagementClient.Namespaces.GetIpFilterRule(resourceGroup, namespaceName, ipFilterRuleName);
                Assert.NotNull(getNamespaceIPFilterRuleResponse);
                Assert.Equal(ipFilterRuleName, getNamespaceIPFilterRuleResponse.Name);

                // Delete namespace authorizationRule
                ServiceBusManagementClient.Namespaces.DeleteIpFilterRule(resourceGroup, namespaceName, ipFilterRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);

            }
        }
    }
}
