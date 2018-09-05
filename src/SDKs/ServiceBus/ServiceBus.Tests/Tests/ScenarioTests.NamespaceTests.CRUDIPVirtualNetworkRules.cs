// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceCreateGetUpdateDeleteVirtualNetworkRules()
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
                var virtualNetworkRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.VirtualNetworkRulesPrefix);
                var createVirtualNetworkRuleParameter = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = @"/subscriptions/"+ ServiceBusManagementClient.SubscriptionId+ "/resourceGroups/EventHubClusterRG/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default"
                };

                var createNamespaceVirtualNetworkResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateVirtualNetworkRule(resourceGroup, namespaceName,
                    virtualNetworkRuleName, createVirtualNetworkRuleParameter);
                Assert.NotNull(createNamespaceVirtualNetworkResponse);
                Assert.Equal(createNamespaceVirtualNetworkResponse.VirtualNetworkSubnetId, createNamespaceVirtualNetworkResponse.VirtualNetworkSubnetId);
                Assert.Equal(virtualNetworkRuleName, createNamespaceVirtualNetworkResponse.Name);

                // Get namespace VirtualNetwork
                var getNamespaceVirtualNetworkRulesResponse = ServiceBusManagementClient.Namespaces.GetVirtualNetworkRule(resourceGroup, namespaceName, virtualNetworkRuleName);
                Assert.NotNull(getNamespaceVirtualNetworkRulesResponse);
                Assert.Equal(createVirtualNetworkRuleParameter.VirtualNetworkSubnetId, getNamespaceVirtualNetworkRulesResponse.VirtualNetworkSubnetId);
                Assert.Equal(virtualNetworkRuleName, getNamespaceVirtualNetworkRulesResponse.Name);

                // Get all VirtualNetworks
                var getAllVirtualNetworkRulesResponse = ServiceBusManagementClient.Namespaces.ListVirtualNetworkRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllVirtualNetworkRulesResponse);                
                Assert.True(getAllVirtualNetworkRulesResponse.Count() > 0);
                Assert.Contains(getAllVirtualNetworkRulesResponse, ns => ns.Name == virtualNetworkRuleName);
                               
                VirtualNetworkRule updateVirtualNetworkRuleParameter = new VirtualNetworkRule();
                updateVirtualNetworkRuleParameter.VirtualNetworkSubnetId = @"/subscriptions/"+ ServiceBusManagementClient.SubscriptionId+ "/resourceGroups/EventHubClusterRG/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default";

                var updateVirtualNetworkRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateVirtualNetworkRule(resourceGroup,
                    namespaceName, virtualNetworkRuleName, updateVirtualNetworkRuleParameter);

                Assert.NotNull(updateVirtualNetworkRuleResponse);
                Assert.Equal(virtualNetworkRuleName, updateVirtualNetworkRuleResponse.Name);

                // Get the updated VirtualNetworks
                var getVirtualNetworkRuleResponse = ServiceBusManagementClient.Namespaces.GetVirtualNetworkRule(resourceGroup, namespaceName, virtualNetworkRuleName);
                Assert.NotNull(getVirtualNetworkRuleResponse);
                Assert.Equal(virtualNetworkRuleName, getVirtualNetworkRuleResponse.Name);

                // Delete VirtualNetworks
                ServiceBusManagementClient.Namespaces.DeleteVirtualNetworkRule(resourceGroup, namespaceName, virtualNetworkRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
            }
        }
    }
}
