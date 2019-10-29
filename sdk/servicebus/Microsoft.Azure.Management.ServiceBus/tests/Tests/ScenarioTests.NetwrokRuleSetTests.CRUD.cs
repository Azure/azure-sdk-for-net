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
    using System.Threading;

    public partial class ScenarioTests
    {
        [Fact]
        public void NetworkRuleSetCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

               
                //Create a namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                new SBNamespace()
                {
                    Location = location,                        
                    Tags = new Dictionary<string, string>()
                    {
                        {"tag1", "value1"},
                        {"tag2", "value2"}
                    },
                    Sku = new SBSku { Tier = SkuTier.Premium, Name = SkuName.Premium }
                });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                //Create Namepsace IPRules 

                List<NWRuleSetIpRules> IPRules = new List<NWRuleSetIpRules>();

                IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.1", Action = NetworkRuleIPAction.Allow });
                IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.2", Action = NetworkRuleIPAction.Allow });
                IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.3", Action = NetworkRuleIPAction.Allow });
                IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.4", Action = NetworkRuleIPAction.Allow });
                IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.5", Action = NetworkRuleIPAction.Allow });

                List<NWRuleSetVirtualNetworkRules> VNetRules = new List<NWRuleSetVirtualNetworkRules>();

                VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet() { Id = @"/subscriptions/" + ServiceBusManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default" }, IgnoreMissingVnetServiceEndpoint = true });
                VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet() { Id = @"/subscriptions/" + ServiceBusManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault" }, IgnoreMissingVnetServiceEndpoint = false });
                VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet() { Id = @"/subscriptions/" + ServiceBusManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01" }, IgnoreMissingVnetServiceEndpoint = false });

                var netWorkRuleSet = ServiceBusManagementClient.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroup, namespaceName, new NetworkRuleSet() { DefaultAction = DefaultAction.Deny, VirtualNetworkRules = VNetRules, IpRules = IPRules });

                var getNetworkRuleSet = ServiceBusManagementClient.Namespaces.GetNetworkRuleSet(resourceGroup, namespaceName);

                var netWorkRuleSet1 = ServiceBusManagementClient.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroup, namespaceName, new NetworkRuleSet() { DefaultAction = "Allow" });

                var getNetworkRuleSet1 = ServiceBusManagementClient.Namespaces.GetNetworkRuleSet(resourceGroup, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                
            }
        }
    }
}
