// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
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

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                
                //Create a namespace
                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {
                    var createNamespaceResponse = EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                new EHNamespace()
                {
                    Location = location,
                    Sku = new Sku
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

                    //Get the created namespace
                    var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                    if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                        TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
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

                    VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet() { Id = @"/subscriptions/" + EventHubManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default" }, IgnoreMissingVnetServiceEndpoint = true });
                    VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet() { Id = @"/subscriptions/" + EventHubManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault" }, IgnoreMissingVnetServiceEndpoint = false });
                    VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet() { Id = @"/subscriptions/" + EventHubManagementClient.SubscriptionId + "/resourcegroups/v-ajnavtest/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01" }, IgnoreMissingVnetServiceEndpoint = false });

                    var netWorkRuleSet = EventHubManagementClient.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroup, namespaceName, new NetworkRuleSet() { DefaultAction = DefaultAction.Deny, VirtualNetworkRules = VNetRules, IpRules = IPRules });

                    var getNetworkRuleSet = EventHubManagementClient.Namespaces.GetNetworkRuleSet(resourceGroup, namespaceName);

                    var netWorkRuleSet1 = EventHubManagementClient.Namespaces.CreateOrUpdateNetworkRuleSet(resourceGroup, namespaceName, new NetworkRuleSet() { DefaultAction = "Allow" });

                    var getNetworkRuleSet1 = EventHubManagementClient.Namespaces.GetNetworkRuleSet(resourceGroup, namespaceName);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }

            }
        }
    }
}