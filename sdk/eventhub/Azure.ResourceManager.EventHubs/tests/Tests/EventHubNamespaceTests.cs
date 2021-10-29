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

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventHubNamespaceTests : EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        public EventHubNamespaceTests(bool isAsync) : base(isAsync)
        {
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
                List<EventHubNamespace> namespaceList = await namespaceCollection.GetAllAsync().ToEnumerableAsync();
                foreach (EventHubNamespace EventHubNamespace in namespaceList)
                {
                    await EventHubNamespace.DeleteAsync();
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
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eventHubNamespace, true);

            //validate if created successfully
            eventHubNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceCollection.CheckIfExistsAsync(namespaceName));
            VerifyNamespaceProperties(eventHubNamespace, true);

            //delete namespace
            await eventHubNamespace.DeleteAsync();

            //validate if deleted successfully
            eventHubNamespace = await namespaceCollection.GetIfExistsAsync(namespaceName);
            Assert.IsNull(eventHubNamespace);
            Assert.IsFalse(await namespaceCollection.CheckIfExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateNamespace()
        {
            //create namespace
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eventHubNamespace, true);

            //update namespace
            var updateNamespaceParameter = eventHubNamespace.Data;
            updateNamespaceParameter.Tags.Add("key1", "value1");
            updateNamespaceParameter.Tags.Add("key2", "value2");
            eventHubNamespace = await eventHubNamespace.UpdateAsync(updateNamespaceParameter);

            //validate
            Assert.AreEqual(eventHubNamespace.Data.Tags.Count, 2);
            Assert.AreEqual("value1", eventHubNamespace.Data.Tags["key1"]);
            Assert.AreEqual("value2", eventHubNamespace.Data.Tags["key2"]);

            //wait until provision state is succeeded
            await GetSucceededNamespace(eventHubNamespace);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllNamespaces()
        {
            //create two namespaces
            string namespaceName1 = await CreateValidNamespaceName("testnamespacemgmt1");
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt2");
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            _ = (await namespaceCollection.CreateOrUpdateAsync(namespaceName1, new EventHubNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceCollection.CreateOrUpdateAsync(namespaceName2, new EventHubNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EventHubNamespace namespace1 = null;
            EventHubNamespace namespace2 = null;

            //validate
            await foreach (EventHubNamespace eventHubNamespace in namespaceCollection.GetAllAsync())
            {
                count++;
                if (eventHubNamespace.Id.Name == namespaceName1)
                    namespace1 = eventHubNamespace;
                if (eventHubNamespace.Id.Name == namespaceName2)
                    namespace2 = eventHubNamespace;
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
            EventHubNamespaceCollection namespaceCollection1 = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespaceCollection namespaceCollection2 = resourceGroup.GetEventHubNamespaces();
            _ = (await namespaceCollection1.CreateOrUpdateAsync(namespaceName1, new EventHubNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceCollection2.CreateOrUpdateAsync(namespaceName2, new EventHubNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EventHubNamespace namespace1 = null;
            EventHubNamespace namespace2 = null;

            //validate
            await foreach (EventHubNamespace eventHubNamespace in DefaultSubscription.GetEventHubNamespacesAsync())
            {
                count++;
                if (eventHubNamespace.Id.Name == namespaceName1)
                    namespace1 = eventHubNamespace;
                if (eventHubNamespace.Id.Name == namespaceName2)
                    namespace2 = eventHubNamespace;
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
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            NamespaceAuthorizationRuleCollection ruleCollection = eventHubNamespace.GetNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceAuthorizationRule authorizationRule = (await ruleCollection.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<NamespaceAuthorizationRule> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //there should be two authorization rules
            Assert.True(rules.Count > 1);
            bool isContainAuthorizationRuleName = false;
            bool isContainDefaultRuleName = false;
            foreach (NamespaceAuthorizationRule rule in rules)
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
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync();

            //validate if deleted
            Assert.IsFalse(await ruleCollection.CheckIfExistsAsync(ruleName));
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 1);
            Assert.AreEqual(rules[0].Id.Name, DefaultNamespaceAuthorizationRule);
        }

        [Test]
        [RecordedTest]
        public async Task CreateNamespaceWithKafkaEnabled()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespaceData parameter = new EventHubNamespaceData(DefaultLocation)
            {
                KafkaEnabled = true
            };
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eventHubNamespace, false);
            Assert.IsTrue(eventHubNamespace.Data.KafkaEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceAuthorizationRuleRegenerateKey()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            NamespaceAuthorizationRuleCollection ruleCollection = eventHubNamespace.GetNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            NamespaceAuthorizationRule authorizationRule = (await ruleCollection.CreateOrUpdateAsync(ruleName, parameter)).Value;
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
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;

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
                    new NetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId1} },
                    new NetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId2} },
                    new NetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId3} }
                },
                IpRules =
                    {
                        new NetworkRuleSetIpRules() { IpMask = "1.1.1.1", Action = "Allow" },
                        new NetworkRuleSetIpRules() { IpMask = "1.1.1.2", Action = "Allow" },
                        new NetworkRuleSetIpRules() { IpMask = "1.1.1.3", Action = "Allow" },
                        new NetworkRuleSetIpRules() { IpMask = "1.1.1.4", Action = "Allow" },
                        new NetworkRuleSetIpRules() { IpMask = "1.1.1.5", Action = "Allow" }
                    }
            };
            await eventHubNamespace.CreateOrUpdateNetworkRuleSetAsync(parameter);

            //get the network rule set
            NetworkRuleSet networkRuleSet = await eventHubNamespace.GetNetworkRuleSetAsync();
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
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;

            //add a tag
            eventHubNamespace = await eventHubNamespace.AddTagAsync("key", "value");
            Assert.AreEqual(eventHubNamespace.Data.Tags.Count, 1);
            Assert.AreEqual(eventHubNamespace.Data.Tags["key"], "value");

            //set the tag
            eventHubNamespace.Data.Tags.Add("key1", "value1");
            eventHubNamespace = await eventHubNamespace.SetTagsAsync(eventHubNamespace.Data.Tags);
            Assert.AreEqual(eventHubNamespace.Data.Tags.Count, 2);
            Assert.AreEqual(eventHubNamespace.Data.Tags["key1"], "value1");

            //remove a tag
            eventHubNamespace = await eventHubNamespace.RemoveTagAsync("key");
            Assert.AreEqual(eventHubNamespace.Data.Tags.Count, 1);

            //wait until provision state is succeeded
            await GetSucceededNamespace(eventHubNamespace);
        }

        public async Task<EventHubNamespace> GetSucceededNamespace(EventHubNamespace eventHubNamespace)
        {
            int i = 0;
            while (!eventHubNamespace.Data.ProvisioningState.Equals("Succeeded") && i < 10)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
                eventHubNamespace = await eventHubNamespace.GetAsync();
                i++;
            }
            return eventHubNamespace;
        }

        [Test]
        [RecordedTest]
        [Ignore("returned id is invalid")]
        public async Task GetPrivateLinkResources()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;

            //get private link resource
            IReadOnlyList<PrivateLinkResource> privateLinkResources = (await eventHubNamespace.GetPrivateLinkResourcesAsync()).Value;
            Assert.NotNull(privateLinkResources);
        }

        [Test]
        [RecordedTest]
        [Ignore("return 404")]
        public async Task CreateGetDeletePrivateEndPointConnection()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            PrivateEndpointConnectionCollection privateEndpointConnectionCollection = eventHubNamespace.GetPrivateEndpointConnections();

            //create another namespace for connection
            string namespaceName2 = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespace eventHubNamespace2 = (await namespaceCollection.CreateOrUpdateAsync(namespaceName2, new EventHubNamespaceData(DefaultLocation))).Value;

            //create an endpoint connection
            string connectionName = Recording.GenerateAssetName("endpointconnection");
            PrivateEndpointConnectionData parameter = new PrivateEndpointConnectionData()
            {
                PrivateEndpoint = new WritableSubResource()
                {
                    Id = eventHubNamespace2.Id.ToString()
                }
            };
            PrivateEndpointConnection privateEndpointConnection = (await privateEndpointConnectionCollection.CreateOrUpdateAsync(connectionName, parameter)).Value;
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, eventHubNamespace2.Id.ToString());
            connectionName = privateEndpointConnection.Id.Name;

            //get the endpoint connection and validate
            privateEndpointConnection = await privateEndpointConnectionCollection.GetAsync(connectionName);
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, eventHubNamespace2.Id.ToString());

            //get all endpoint connections and validate
            List<PrivateEndpointConnection> privateEndpointConnections = await privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(privateEndpointConnections, 1);
            Assert.AreEqual(privateEndpointConnections.First().Data.PrivateEndpoint.Id, eventHubNamespace2.Id.ToString());

            //delete endpoint connection and validate
            await privateEndpointConnection.DeleteAsync();
            Assert.IsFalse(await privateEndpointConnectionCollection.CheckIfExistsAsync(connectionName));
        }
    }
}
