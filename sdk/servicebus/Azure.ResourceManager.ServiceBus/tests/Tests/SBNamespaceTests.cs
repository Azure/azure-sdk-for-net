// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.ServiceBus.Tests.Helpers;

namespace Azure.ResourceManager.ServiceBus.Tests.Tests
{
    public class SBNamespaceTests : ServiceBusTestBase
    {
        private ResourceGroup _resourceGroup;
        public SBNamespaceTests(bool isAsync) : base(isAsync)
        {
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
                List<SBNamespace> namespaceList = await namespaceContainer.GetAllAsync().ToEnumerableAsync();
                foreach (SBNamespace sBNamespace in namespaceList)
                {
                    await sBNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteNamespace()
        {
            //create namespace and wait for completion
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(sBNamespace, true);

            //validate if created successfully
            sBNamespace = await namespaceContainer.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceContainer.CheckIfExistsAsync(namespaceName));
            VerifyNamespaceProperties(sBNamespace, true);

            //delete namespace
            await sBNamespace.DeleteAsync();

            //validate if deleted successfully
            sBNamespace = await namespaceContainer.GetIfExistsAsync(namespaceName);
            Assert.IsNull(sBNamespace);
            Assert.IsFalse(await namespaceContainer.CheckIfExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        public async void CreateNamespaceWithZoneRedundant()
        {
            //create namespace and wait for completion
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            var parameters = new SBNamespaceData(DefaultLocation)
            {
                ZoneRedundant = true
            };
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, parameters)).Value;
            VerifyNamespaceProperties(sBNamespace, true);
            Assert.IsTrue(sBNamespace.Data.ZoneRedundant);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateNamespace()
        {
            //create namespace
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(sBNamespace, true);

            //update namespace
            SBNamespaceUpdateParameters parameters = new SBNamespaceUpdateParameters(DefaultLocation);
            parameters.Tags.Add("key1", "value1");
            parameters.Tags.Add("key2", "value2");
            sBNamespace = await sBNamespace.UpdateAsync(parameters);

            //validate
            Assert.AreEqual(sBNamespace.Data.Tags.Count, 2);
            Assert.AreEqual("value1", sBNamespace.Data.Tags["key1"]);
            Assert.AreEqual("value2", sBNamespace.Data.Tags["key2"]);

            //wait until provision state is succeeded
            await GetSucceededNamespace(sBNamespace);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllNamespaces()
        {
            //create two namespaces
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt1");
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt2");
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            _ = (await namespaceContainer.CreateOrUpdateAsync(namespaceName1, new SBNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceContainer.CreateOrUpdateAsync(namespaceName2, new SBNamespaceData(DefaultLocation))).Value;
            int count = 0;
            SBNamespace namespace1 = null;
            SBNamespace namespace2 = null;

            //validate
            await foreach (SBNamespace sBNamespace in namespaceContainer.GetAllAsync())
            {
                count++;
                if (sBNamespace.Id.Name == namespaceName1)
                    namespace1 = sBNamespace;
                if (sBNamespace.Id.Name == namespaceName2)
                    namespace2 = sBNamespace;
            }
            Assert.AreEqual(count, 2);
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
        }

        [Test]
        [RecordedTest]
        public async Task GetNamespacesInSubscription()
        {
            //create two namespaces in two resourcegroups
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt1");
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt2");
            _resourceGroup = await CreateResourceGroupAsync();
            ResourceGroup resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer1 = _resourceGroup.GetSBNamespaces();
            SBNamespaceContainer namespaceContainer2 = resourceGroup.GetSBNamespaces();
            _ = (await namespaceContainer1.CreateOrUpdateAsync(namespaceName1, new SBNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceContainer2.CreateOrUpdateAsync(namespaceName2, new SBNamespaceData(DefaultLocation))).Value;
            int count = 0;
            SBNamespace namespace1 = null;
            SBNamespace namespace2 = null;

            //validate
            await foreach (SBNamespace sBNamespace in DefaultSubscription.GetSBNamespacesAsync())
            {
                count++;
                if (sBNamespace.Id.Name == namespaceName1)
                    namespace1 = sBNamespace;
                if (sBNamespace.Id.Name == namespaceName2)
                    namespace2 = sBNamespace;
            }
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
            Assert.AreEqual(namespace1.Id.ResourceGroupName, _resourceGroup.Id.Name);
            Assert.AreEqual(namespace2.Id.ResourceGroupName, resourceGroup.Id.Name);

            await namespace2.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task GetPrivateLinkResources()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;

            //get private link resource
            IReadOnlyList<PrivateLinkResource> privateLinkResources = (await sBNamespace.GetPrivateLinkResourcesAsync()).Value;
            Assert.NotNull(privateLinkResources);
        }

        [Test]
        [RecordedTest]
        [Ignore("return 404")]
        public async Task CreateGetDeletePrivateEndPointConnection()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;
            PrivateEndpointConnectionContainer privateEndpointConnectionContainer = sBNamespace.GetPrivateEndpointConnections();

            //create another namespace for connection
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespace sBNamespace2 = (await namespaceContainer.CreateOrUpdateAsync(namespaceName2, new SBNamespaceData(DefaultLocation))).Value;

            //create an endpoint connection
            string connectionName = Recording.GenerateAssetName("endpointconnection");
            PrivateEndpointConnectionData parameter = new PrivateEndpointConnectionData()
            {
                PrivateEndpoint = new Models.PrivateEndpoint()
                {
                    Id = sBNamespace2.Id.ToString()
                }
            };
            PrivateEndpointConnection privateEndpointConnection = (await privateEndpointConnectionContainer.CreateOrUpdateAsync(connectionName, parameter)).Value;
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, sBNamespace2.Id.ToString());
            connectionName = privateEndpointConnection.Id.Name;

            //get the endpoint connection and validate
            privateEndpointConnection = await privateEndpointConnectionContainer.GetAsync(connectionName);
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, sBNamespace2.Id.ToString());

            //get all endpoint connections and validate
            List<PrivateEndpointConnection> privateEndpointConnections = await privateEndpointConnectionContainer.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(privateEndpointConnections, 1);
            Assert.AreEqual(privateEndpointConnections.First().Data.PrivateEndpoint.Id, sBNamespace2.Id.ToString());

            //delete endpoint connection and validate
            await privateEndpointConnection.DeleteAsync();
            Assert.IsFalse(await privateEndpointConnectionContainer.CheckIfExistsAsync(connectionName));
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceCreateGetUpdateDeleteAuthorizationRule()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;
            SBAuthorizationRuleNamespaceContainer ruleContainer = sBNamespace.GetSBAuthorizationRuleNamespaces();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            SBAuthorizationRuleData parameter = new SBAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            SBAuthorizationRuleNamespace authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleContainer.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<SBAuthorizationRuleNamespace> rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();

            //there should be two authorization rules
            Assert.True(rules.Count > 1);
            bool isContainAuthorizationRuleName = false;
            bool isContainDefaultRuleName = false;
            foreach (SBAuthorizationRuleNamespace rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
                if (rule.Id.Name == DefaultNamespaceAuthorizationRule)
                {
                    isContainDefaultRuleName = true;
                }
            }
            Assert.True(isContainDefaultRuleName);
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(AccessRights.Manage);
            authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync();

            //validate if deleted
            Assert.IsFalse(await ruleContainer.CheckIfExistsAsync(ruleName));
            rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 1);
            Assert.AreEqual(rules[0].Id.Name, DefaultNamespaceAuthorizationRule);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceAuthorizationRuleRegenerateKey()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;
            SBAuthorizationRuleNamespaceContainer ruleContainer = sBNamespace.GetSBAuthorizationRuleNamespaces();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            SBAuthorizationRuleData parameter = new SBAuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            SBAuthorizationRuleNamespace authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            AccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            AccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            AccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyParameters(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SetGetNetworkRuleSets()
        {
            //create namespace with premium
            _resourceGroup = await CreateResourceGroupAsync();
            SBNamespaceContainer namespaceContainer = _resourceGroup.GetSBNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespaceData createParameters = new SBNamespaceData(DefaultLocation);
            createParameters.Sku = new SBSku(SkuName.Premium)
            {
                Tier = SkuTier.Premium
            };
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, createParameters)).Value;

            //prepare vnet
            string vnetName = Recording.GenerateAssetName("sdktestvnet");
            var parameters = new VirtualNetworkData
            {
                AddressSpace = new AddressSpace { AddressPrefixes = { "10.0.0.0/16" } },
                Subnets = {
                    new SubnetData
                    {
                        Name = "default1",
                        AddressPrefix = "10.0.0.0/24",
                        ServiceEndpoints = { new ServiceEndpointPropertiesFormat { Service = "Microsoft.ServiceBus" } }
                    },
                    new SubnetData
                    {
                        Name = "default2",
                        AddressPrefix = "10.0.1.0/24",
                        ServiceEndpoints = { new ServiceEndpointPropertiesFormat { Service = "Microsoft.ServiceBus" } }
                    },
                    new SubnetData
                    {
                        Name = "default3",
                        AddressPrefix = "10.0.2.0/24",
                        ServiceEndpoints = { new ServiceEndpointPropertiesFormat { Service = "Microsoft.ServiceBus" } }
                    }
                },
                Location = "eastus2"
            };
            VirtualNetwork virtualNetwork = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, parameters)).Value;

            //set network rule set
            string subscriptionId = DefaultSubscription.Id.ToString();
            string subnetId1 = subscriptionId + "/resourcegroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default1";
            string subnetId2 = subscriptionId + "/resourcegroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default2";
            string subnetId3 = subscriptionId + "/resourcegroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default3";
            NetworkRuleSet parameter = new NetworkRuleSet()
            {
                DefaultAction = DefaultAction.Deny,
                VirtualNetworkRules =
                {
                    new NWRuleSetVirtualNetworkRules() { Subnet = new Models.Subnet(subnetId1) ,IgnoreMissingVnetServiceEndpoint = true},
                    new NWRuleSetVirtualNetworkRules() { Subnet = new Models.Subnet(subnetId2) ,IgnoreMissingVnetServiceEndpoint = false},
                    new NWRuleSetVirtualNetworkRules() { Subnet = new Models.Subnet(subnetId3) ,IgnoreMissingVnetServiceEndpoint = false}
                },
                IpRules =
                    {
                        new NWRuleSetIpRules() { IpMask = "1.1.1.1", Action = "Allow" },
                        new NWRuleSetIpRules() { IpMask = "1.1.1.2", Action = "Allow" },
                        new NWRuleSetIpRules() { IpMask = "1.1.1.3", Action = "Allow" },
                        new NWRuleSetIpRules() { IpMask = "1.1.1.4", Action = "Allow" },
                        new NWRuleSetIpRules() { IpMask = "1.1.1.5", Action = "Allow" }
                    }
            };
            await sBNamespace.CreateOrUpdateNetworkRuleSetAsync(parameter);

            //get the network rule set
            NetworkRuleSet networkRuleSet = await sBNamespace.GetNetworkRuleSetAsync();
            Assert.NotNull(networkRuleSet);
            Assert.NotNull(networkRuleSet.IpRules);
            Assert.NotNull(networkRuleSet.VirtualNetworkRules);
            Assert.AreEqual(networkRuleSet.VirtualNetworkRules.Count, 3);
            Assert.AreEqual(networkRuleSet.IpRules.Count, 5);

            //delete virtual network
            await virtualNetwork.DeleteAsync();
        }

        public async Task<SBNamespace> GetSucceededNamespace(SBNamespace sBNamespace)
        {
            int i = 0;
            while (!sBNamespace.Data.ProvisioningState.Equals("Succeeded") && i < 10)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
                sBNamespace = await sBNamespace.GetAsync();
                i++;
            }
            return sBNamespace;
        }
    }
}
