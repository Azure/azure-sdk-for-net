// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;

using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests : EventHubsManagementClientBase
    {
        [Test]
        public async Task NetworkRuleSetCreateGetUpdateDelete()
        {
            var location = GetLocation();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location.Result, resourceGroup);
            //Create a namespace
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroup, namespaceName,
                new EHNamespace()
                {
                    Location = location.Result,
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                }
                );
            var np = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np.Name, namespaceName);
            DelayInTest(5);
            //get the created namespace
            var getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroup, namespaceName);
            if (string.Compare(getNamespaceResponse.Value.ProvisioningState, "Succeeded", true) != 0)
                DelayInTest(5);
            getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroup, namespaceName);
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual("Succeeded", getNamespaceResponse.Value.ProvisioningState,StringComparer.CurrentCultureIgnoreCase.ToString());
            Assert.AreEqual(location.Result, getNamespaceResponse.Value.Location, StringComparer.CurrentCultureIgnoreCase.ToString());
            //Create Namepsace IPRules
            List<NWRuleSetIpRules> IPRules = new List<NWRuleSetIpRules>();
            //TODO
            IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.1", Action = "Allow" });
            IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.2", Action = "Allow" });
            IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.3", Action = "Allow" });
            IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.4", Action = "Allow" });
            IPRules.Add(new NWRuleSetIpRules() { IpMask = "1.1.1.5", Action = "Allow" });
            List<NWRuleSetVirtualNetworkRules> VNetRules = new List<NWRuleSetVirtualNetworkRules>();
            //You should create Three virtualNetworks/sbehvnettest1/subnets/default(sbdefault and sbdefault01) and add EventHub to Service endpoint --youri 8.5.2020
            VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet("/subscriptions/" + SubscriptionId + "/resourcegroups/"+ resourceGroup + "/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default") });
            VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet("/subscriptions/" + SubscriptionId + "/resourcegroups/"+ resourceGroup + "/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault") });
            VNetRules.Add(new NWRuleSetVirtualNetworkRules() { Subnet = new Subnet("/subscriptions/" + SubscriptionId + "/resourcegroups/"+ resourceGroup + "/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/sbdefault01") });
            var netWorkRuleSet =await NamespacesOperations.CreateOrUpdateNetworkRuleSetAsync(resourceGroup, namespaceName, new NetworkRuleSet() { DefaultAction = DefaultAction.Deny, VirtualNetworkRules = VNetRules, IpRules = IPRules });
            var getNetworkRuleSet = await NamespacesOperations.GetNetworkRuleSetAsync(resourceGroup, namespaceName);
            var netWorkRuleSet1 = await NamespacesOperations.CreateOrUpdateNetworkRuleSetAsync(resourceGroup, namespaceName, new NetworkRuleSet() { DefaultAction = "Allow" });
            var getNetworkRuleSet1 = await NamespacesOperations.GetNetworkRuleSetAsync(resourceGroup, namespaceName);
            DelayInTest(60);
            //Delete namespace
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroup, namespaceName));
        }
    }
}
