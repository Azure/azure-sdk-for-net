// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.EventHubs.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EventHubs.Tests.Tests
{
    public class EHNamespaceTests : EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        public EHNamespaceTests(bool isAsync) : base(isAsync)
        {
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
                List<EHNamespace> namespaceList = await namespaceContainer.GetAllAsync().ToEnumerableAsync();
                foreach (EHNamespace eHNamespace in namespaceList)
                {
                    await eHNamespace.DeleteAsync();
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
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eHNamespace, true);

            //validate if created successfully
            eHNamespace = await namespaceContainer.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceContainer.CheckIfExistsAsync(namespaceName));
            VerifyNamespaceProperties(eHNamespace, true);

            //delete namespace
            await eHNamespace.DeleteAsync();

            //validate if deleted successfully
            eHNamespace = await namespaceContainer.GetIfExistsAsync(namespaceName);
            Assert.IsNull(eHNamespace);
            Assert.IsFalse(await namespaceContainer.CheckIfExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateNamespace()
        {
            //create namespace
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eHNamespace, true);

            //update namespace
            var updateNamespaceParameter = eHNamespace.Data;
            updateNamespaceParameter.Tags.Add("key1", "value1");
            updateNamespaceParameter.Tags.Add("key2", "value2");
            eHNamespace = await eHNamespace.UpdateAsync(updateNamespaceParameter);

            //validate
            Assert.AreEqual(eHNamespace.Data.Tags.Count, 2);
            Assert.AreEqual("value1", eHNamespace.Data.Tags["key1"]);
            Assert.AreEqual("value2", eHNamespace.Data.Tags["key2"]);

            //wait until provision state is succeeded
            await GetSucceededNamespace(eHNamespace);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllNamespaces()
        {
            //create two namespaces
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt1");
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt2");
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            _ = (await namespaceContainer.CreateOrUpdateAsync(namespaceName1, new EHNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceContainer.CreateOrUpdateAsync(namespaceName2, new EHNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EHNamespace namespace1 = null;
            EHNamespace namespace2 = null;

            //validate
            await foreach (EHNamespace eHNamespace in namespaceContainer.GetAllAsync())
            {
                count++;
                if (eHNamespace.Id.Name == namespaceName1)
                    namespace1 = eHNamespace;
                if (eHNamespace.Id.Name == namespaceName2)
                    namespace2 = eHNamespace;
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
            EHNamespaceContainer namespaceContainer1 = _resourceGroup.GetEHNamespaces();
            EHNamespaceContainer namespaceContainer2 = resourceGroup.GetEHNamespaces();
            _ = (await namespaceContainer1.CreateOrUpdateAsync(namespaceName1, new EHNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceContainer2.CreateOrUpdateAsync(namespaceName2, new EHNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EHNamespace namespace1 = null;
            EHNamespace namespace2 = null;

            //validate
            await foreach (EHNamespace eHNamespace in DefaultSubscription.GetEHNamespacesAsync())
            {
                count++;
                if (eHNamespace.Id.Name == namespaceName1)
                    namespace1 = eHNamespace;
                if (eHNamespace.Id.Name == namespaceName2)
                    namespace2 = eHNamespace;
            }
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
            Assert.AreEqual(namespace1.Id.ResourceGroupName, _resourceGroup.Id.Name);
            Assert.AreEqual(namespace2.Id.ResourceGroupName, resourceGroup.Id.Name);

            await namespace2.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceCreateGetUpdateDeleteAuthorizationRule()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            AuthorizationRuleNamespaceContainer ruleContainer = eHNamespace.GetAuthorizationRuleNamespaces();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            AuthorizationRuleNamespace authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleContainer.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<AuthorizationRuleNamespace> rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();

            //there should be two authorization rules
            Assert.True(rules.Count > 1);
            bool isContainAuthorizationRuleName = false;
            bool isContainDefaultRuleName = false;
            foreach (AuthorizationRuleNamespace rule in rules)
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
        public async Task CreateNamespaceWithKafkaEnabled()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespaceData parameter = new EHNamespaceData(DefaultLocation)
            {
                KafkaEnabled = true
            };
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eHNamespace, false);
            Assert.IsTrue(eHNamespace.Data.KafkaEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceAuthorizationRuleRegenerateKey()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            AuthorizationRuleNamespaceContainer ruleContainer = eHNamespace.GetAuthorizationRuleNamespaces();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            AuthorizationRuleNamespace authorizationRule = (await ruleContainer.CreateOrUpdateAsync(ruleName, parameter)).Value;
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
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;

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
                        ServiceEndpoints = { new ServiceEndpointPropertiesFormat { Service = "Microsoft.EventHub" } }
                    },
                    new SubnetData
                    {
                        Name = "default2",
                        AddressPrefix = "10.0.1.0/24",
                        ServiceEndpoints = { new ServiceEndpointPropertiesFormat { Service = "Microsoft.EventHub" } }
                    },
                    new SubnetData
                    {
                        Name = "default3",
                        AddressPrefix = "10.0.2.0/24",
                        ServiceEndpoints = { new ServiceEndpointPropertiesFormat { Service = "Microsoft.EventHub" } }
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
                    new NWRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId1} },
                    new NWRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId2} },
                    new NWRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId3} }
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
            await eHNamespace.CreateOrUpdateNetworkRuleSetAsync(parameter);

            //get the network rule set
            NetworkRuleSet networkRuleSet = await eHNamespace.GetNetworkRuleSetAsync();
            Assert.NotNull(networkRuleSet);
            Assert.NotNull(networkRuleSet.IpRules);
            Assert.NotNull(networkRuleSet.VirtualNetworkRules);
            Assert.AreEqual(networkRuleSet.VirtualNetworkRules.Count, 3);
            Assert.AreEqual(networkRuleSet.IpRules.Count, 5);

            //delete virtual network
            await virtualNetwork.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task AddSetRemoveTag()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;

            //add a tag
            eHNamespace = await eHNamespace.AddTagAsync("key", "value");
            Assert.AreEqual(eHNamespace.Data.Tags.Count, 1);
            Assert.AreEqual(eHNamespace.Data.Tags["key"], "value");

            //set the tag
            eHNamespace.Data.Tags.Add("key1", "value1");
            eHNamespace = await eHNamespace.SetTagsAsync(eHNamespace.Data.Tags);
            Assert.AreEqual(eHNamespace.Data.Tags.Count, 2);
            Assert.AreEqual(eHNamespace.Data.Tags["key1"], "value1");

            //remove a tag
            eHNamespace = await eHNamespace.RemoveTagAsync("key");
            Assert.AreEqual(eHNamespace.Data.Tags.Count, 1);

            //wait until provision state is succeeded
            await GetSucceededNamespace(eHNamespace);
        }

        public async Task<EHNamespace> GetSucceededNamespace(EHNamespace eHNamespace)
        {
            int i = 0;
            while (!eHNamespace.Data.ProvisioningState.Equals("Succeeded") && i < 10)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
                eHNamespace = await eHNamespace.GetAsync();
                i++;
            }
            return eHNamespace;
        }

        [Test]
        [RecordedTest]
        [Ignore("returned id is invalid")]
        public async Task GetPrivateLinkResources()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;

            //get private link resource
            IReadOnlyList<PrivateLinkResource> privateLinkResources = (await eHNamespace.GetPrivateLinkResourcesAsync()).Value;
            Assert.NotNull(privateLinkResources);
        }

        [Test]
        [RecordedTest]
        [Ignore("return 404")]
        public async Task CreateGetDeletePrivateEndPointConnection()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            PrivateEndpointConnectionContainer privateEndpointConnectionContainer = eHNamespace.GetPrivateEndpointConnections();

            //create another namespace for connection
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            EHNamespace eHNamespace2 = (await namespaceContainer.CreateOrUpdateAsync(namespaceName2, new EHNamespaceData(DefaultLocation))).Value;

            //create an endpoint connection
            string connectionName = Recording.GenerateAssetName("endpointconnection");
            PrivateEndpointConnectionData parameter = new PrivateEndpointConnectionData()
            {
                PrivateEndpoint = new WritableSubResource()
                {
                    Id = eHNamespace2.Id.ToString()
                }
            };
            PrivateEndpointConnection privateEndpointConnection = (await privateEndpointConnectionContainer.CreateOrUpdateAsync(connectionName, parameter)).Value;
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, eHNamespace2.Id.ToString());
            connectionName = privateEndpointConnection.Id.Name;

            //get the endpoint connection and validate
            privateEndpointConnection = await privateEndpointConnectionContainer.GetAsync(connectionName);
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, eHNamespace2.Id.ToString());

            //get all endpoint connections and validate
            List<PrivateEndpointConnection> privateEndpointConnections = await privateEndpointConnectionContainer.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(privateEndpointConnections, 1);
            Assert.AreEqual(privateEndpointConnections.First().Data.PrivateEndpoint.Id, eHNamespace2.Id.ToString());

            //delete endpoint connection and validate
            await privateEndpointConnection.DeleteAsync();
            Assert.IsFalse(await privateEndpointConnectionContainer.CheckIfExistsAsync(connectionName));
        }
    }
}
