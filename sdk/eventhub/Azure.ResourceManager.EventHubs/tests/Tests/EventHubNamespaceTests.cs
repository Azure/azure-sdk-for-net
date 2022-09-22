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
using Azure.Core;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventHubNamespaceTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        public EventHubNamespaceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteNamespace()
        {
            //create namespace and wait for completion
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eventHubNamespace, true);

            //validate if created successfully
            eventHubNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceCollection.ExistsAsync(namespaceName));
            VerifyNamespaceProperties(eventHubNamespace, true);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await namespaceCollection.ExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateNamespace()
        {
            //create namespace
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
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
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            _ = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName1, new EventHubsNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, new EventHubsNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EventHubsNamespaceResource namespace1 = null;
            EventHubsNamespaceResource namespace2 = null;

            //validate
            await foreach (EventHubsNamespaceResource eventHubNamespace in namespaceCollection.GetAllAsync())
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
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection1 = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceCollection namespaceCollection2 = resourceGroup.GetEventHubsNamespaces();
            _ = (await namespaceCollection1.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName1, new EventHubsNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceCollection2.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, new EventHubsNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EventHubsNamespaceResource namespace1 = null;
            EventHubsNamespaceResource namespace2 = null;

            //validate
            await foreach (EventHubsNamespaceResource eventHubNamespace in DefaultSubscription.GetEventHubsNamespacesAsync())
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

            await namespace2.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceCreateGetUpdateDeleteAuthorizationRule()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
            EventHubsNamespaceAuthorizationRuleCollection ruleCollection = eventHubNamespace.GetEventHubsNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubsAuthorizationRuleData parameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubsNamespaceAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<EventHubsNamespaceAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //there should be two authorization rules
            Assert.True(rules.Count > 1);
            bool isContainAuthorizationRuleName = false;
            bool isContainDefaultRuleName = false;
            foreach (EventHubsNamespaceAuthorizationRuleResource rule in rules)
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
            parameter.Rights.Add(EventHubsAccessRight.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.IsFalse(await ruleCollection.ExistsAsync(ruleName));
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
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceData parameter = new EventHubsNamespaceData(DefaultLocation)
            {
                KafkaEnabled = true
            };
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eventHubNamespace, false);
            Assert.IsTrue(eventHubNamespace.Data.KafkaEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceAuthorizationRuleRegenerateKey()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
            EventHubsNamespaceAuthorizationRuleCollection ruleCollection = eventHubNamespace.GetEventHubsNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubsAuthorizationRuleData parameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubsNamespaceAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            EventHubsAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            EventHubsAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            EventHubsAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("exceed 8s")]
        public async Task SetGetNetworkRuleSets()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;

            //prepare vnet
            string vnetName = Recording.GenerateAssetName("sdktestvnet");
            var parameters = new VirtualNetworkData
            {
                Subnets = {
                    new SubnetData
                    {
                        Name = "default1",
                        AddressPrefix = "10.0.0.0/24",
                        ServiceEndpoints = { new ServiceEndpointProperties { Service = "Microsoft.EventHub" } }
                    },
                    new SubnetData
                    {
                        Name = "default2",
                        AddressPrefix = "10.0.1.0/24",
                        ServiceEndpoints = { new ServiceEndpointProperties { Service = "Microsoft.EventHub" } }
                    },
                    new SubnetData
                    {
                        Name = "default3",
                        AddressPrefix = "10.0.2.0/24",
                        ServiceEndpoints = { new ServiceEndpointProperties { Service = "Microsoft.EventHub" } }
                    }
                },
                Location = "eastus2"
            };
            parameters.AddressPrefixes.Add("10.0.0.0/16");
            VirtualNetworkResource virtualNetwork = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, parameters)).Value;

            //set network rule set
            string subscriptionId = DefaultSubscription.Id.ToString();
            ResourceIdentifier subnetId1 = new ResourceIdentifier(subscriptionId + "/resourcegroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default1");
            ResourceIdentifier subnetId2 = new ResourceIdentifier(subscriptionId + "/resourcegroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default2");
            ResourceIdentifier subnetId3 = new ResourceIdentifier(subscriptionId + "/resourcegroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default3");
            EventHubsNetworkRuleSetData parameter = new EventHubsNetworkRuleSetData()
            {
                DefaultAction = EventHubsNetworkRuleSetDefaultAction.Deny,
                VirtualNetworkRules =
                {
                    new EventHubsNetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId1} },
                    new EventHubsNetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId2} },
                    new EventHubsNetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){Id=subnetId3} }
                },
                IPRules =
                    {
                        new EventHubsNetworkRuleSetIPRules() { IPMask = "1.1.1.1", Action = "Allow" },
                        new EventHubsNetworkRuleSetIPRules() { IPMask = "1.1.1.2", Action = "Allow" },
                        new EventHubsNetworkRuleSetIPRules() { IPMask = "1.1.1.3", Action = "Allow" },
                        new EventHubsNetworkRuleSetIPRules() { IPMask = "1.1.1.4", Action = "Allow" },
                        new EventHubsNetworkRuleSetIPRules() { IPMask = "1.1.1.5", Action = "Allow" }
                    }
            };
            await eventHubNamespace.GetEventHubsNetworkRuleSet().CreateOrUpdateAsync(WaitUntil.Completed, parameter);

            //get the network rule set
            EventHubsNetworkRuleSetResource networkRuleSet = await eventHubNamespace.GetEventHubsNetworkRuleSet().GetAsync();
            Assert.NotNull(networkRuleSet);
            Assert.NotNull(networkRuleSet.Data.IPRules);
            Assert.NotNull(networkRuleSet.Data.VirtualNetworkRules);
            Assert.AreEqual(networkRuleSet.Data.VirtualNetworkRules.Count, 3);
            Assert.AreEqual(networkRuleSet.Data.IPRules.Count, 5);

            //delete virtual network
            await virtualNetwork.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddSetRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;

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

        public async Task<EventHubsNamespaceResource> GetSucceededNamespace(EventHubsNamespaceResource eventHubNamespace)
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
        public async Task GetEventHubPrivateLinkResources()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;

            //get private link resource
            await foreach (var _ in eventHubNamespace.GetPrivateLinkResourcesAsync())
            {
                return;
            }

            Assert.Fail($"{nameof(EventHubsNamespaceResource)}.{nameof(EventHubsNamespaceResource.GetPrivateLinkResourcesAsync)} has returned an empty collection of {nameof(EventHubsPrivateLinkResourceData)}.");
        }
    }
}
