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
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.ManagedServiceIdentities.Models;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class ServiceBusNamespaceTests : ServiceBusManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string namespacePrefix = "testnamespacemgmt";

        public ServiceBusNamespaceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteNamespace()
        {
            IgnoreTestInLiveMode();
            //create namespace and wait for completion
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(serviceBusNamespace, true);

            //validate if created successfully
            serviceBusNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceCollection.ExistsAsync(namespaceName));
            VerifyNamespaceProperties(serviceBusNamespace, true);

            //delete namespace
            await serviceBusNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await namespaceCollection.ExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        public async Task CreateNamespaceWithZoneRedundant()
        {
            IgnoreTestInLiveMode();
            //create namespace and wait for completion
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            var parameters = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
                {
                    Tier = ServiceBusSkuTier.Premium
                },
                IsZoneRedundant = true
            };
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, parameters)).Value;
            VerifyNamespaceProperties(serviceBusNamespace, false);
            Assert.IsTrue(serviceBusNamespace.Data.IsZoneRedundant);
        }

        [Test]
        [RecordedTest]
        public async Task CreateNamespaceWithPremiumPartitionCount()
        {
            IgnoreTestInLiveMode();
            //create namespace and wait for completion
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            var parameters = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
                {
                    Tier = ServiceBusSkuTier.Premium,
                    Capacity = 2
                },
                PremiumMessagingPartitions = 2,
                IsZoneRedundant = true,
                Location = "North Europe"
            };
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, parameters)).Value;
            VerifyNamespaceProperties(serviceBusNamespace, false);
            Assert.AreEqual(parameters.Sku.Capacity, serviceBusNamespace.Data.Sku.Capacity);
            Assert.IsTrue(serviceBusNamespace.Data.IsZoneRedundant);
            Assert.AreEqual(serviceBusNamespace.Data.PremiumMessagingPartitions, 2);
            await serviceBusNamespace.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateNamespace()
        {
            IgnoreTestInLiveMode();
            //create namespace
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(serviceBusNamespace, true);

            //update namespace
            ServiceBusNamespacePatch parameters = new ServiceBusNamespacePatch(DefaultLocation);
            parameters.Tags.Add("key1", "value1");
            parameters.Tags.Add("key2", "value2");
            serviceBusNamespace = await serviceBusNamespace.UpdateAsync(parameters);

            //validate
            Assert.AreEqual(serviceBusNamespace.Data.Tags.Count, 2);
            Assert.AreEqual("value1", serviceBusNamespace.Data.Tags["key1"]);
            Assert.AreEqual("value2", serviceBusNamespace.Data.Tags["key2"]);

            //wait until provision state is succeeded
            await GetSucceededNamespace(serviceBusNamespace);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllNamespaces()
        {
            IgnoreTestInLiveMode();
            //create two namespaces
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName1 = await CreateValidNamespaceName(namespacePrefix);
            _ = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName1, new ServiceBusNamespaceData(DefaultLocation))).Value;
            string namespaceName2 = await CreateValidNamespaceName(namespacePrefix);
            _ = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, new ServiceBusNamespaceData(DefaultLocation))).Value;
            int count = 0;
            ServiceBusNamespaceResource namespace1 = null;
            ServiceBusNamespaceResource namespace2 = null;

            //validate
            await foreach (ServiceBusNamespaceResource serviceBusNamespace in namespaceCollection.GetAllAsync())
            {
                count++;
                if (serviceBusNamespace.Id.Name == namespaceName1)
                    namespace1 = serviceBusNamespace;
                if (serviceBusNamespace.Id.Name == namespaceName2)
                    namespace2 = serviceBusNamespace;
            }
            Assert.AreEqual(count, 2);
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
        }

        [Test]
        [RecordedTest]
        public async Task GetNamespacesInSubscription()
        {
            IgnoreTestInLiveMode();
            //create two namespaces in two resourcegroups
            string namespaceName1 = await CreateValidNamespaceName(namespacePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection1 = _resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceCollection namespaceCollection2 = resourceGroup.GetServiceBusNamespaces();
            _ = (await namespaceCollection1.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName1, new ServiceBusNamespaceData(DefaultLocation))).Value;
            string namespaceName2 = await CreateValidNamespaceName(namespacePrefix);
            _ = (await namespaceCollection2.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, new ServiceBusNamespaceData(DefaultLocation))).Value;
            int count = 0;
            ServiceBusNamespaceResource namespace1 = null;
            ServiceBusNamespaceResource namespace2 = null;

            //validate
            await foreach (ServiceBusNamespaceResource serviceBusNamespace in DefaultSubscription.GetServiceBusNamespacesAsync())
            {
                count++;
                if (serviceBusNamespace.Id.Name == namespaceName1)
                    namespace1 = serviceBusNamespace;
                if (serviceBusNamespace.Id.Name == namespaceName2)
                    namespace2 = serviceBusNamespace;
            }
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
            Assert.AreEqual(namespace1.Id.ResourceGroupName, _resourceGroup.Id.Name);
            Assert.AreEqual(namespace2.Id.ResourceGroupName, resourceGroup.Id.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetPrivateLinkResources()
        {
            IgnoreTestInLiveMode();
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //get private link resource
            await foreach (var _ in serviceBusNamespace.GetPrivateLinkResourcesAsync())
            {
                return;
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("return 404")]
        public async Task CreateGetDeletePrivateEndPointConnection()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;
            ServiceBusPrivateEndpointConnectionCollection privateEndpointConnectionCollection = serviceBusNamespace.GetServiceBusPrivateEndpointConnections();

            //create another namespace for connection
            string namespaceName2 = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceResource serviceBusNamespace2 = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //create an endpoint connection
            string connectionName = Recording.GenerateAssetName("endpointconnection");
            ServiceBusPrivateEndpointConnectionData parameter = new ServiceBusPrivateEndpointConnectionData()
            {
                PrivateEndpoint = new WritableSubResource()
                {
                    Id = serviceBusNamespace2.Id
                }
            };
            ServiceBusPrivateEndpointConnectionResource privateEndpointConnection = (await privateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, connectionName, parameter)).Value;
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, serviceBusNamespace2.Id.ToString());
            connectionName = privateEndpointConnection.Id.Name;

            //get the endpoint connection and validate
            privateEndpointConnection = await privateEndpointConnectionCollection.GetAsync(connectionName);
            Assert.NotNull(privateEndpointConnection);
            Assert.AreEqual(privateEndpointConnection.Data.PrivateEndpoint.Id, serviceBusNamespace2.Id.ToString());

            //get all endpoint connections and validate
            List<ServiceBusPrivateEndpointConnectionResource> privateEndpointConnections = await privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(privateEndpointConnections, 1);
            Assert.AreEqual(privateEndpointConnections.First().Data.PrivateEndpoint.Id, serviceBusNamespace2.Id.ToString());

            //delete endpoint connection and validate
            await privateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await privateEndpointConnectionCollection.ExistsAsync(connectionName));
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceCreateGetUpdateDeleteAuthorizationRule()
        {
            IgnoreTestInLiveMode();
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;
            ServiceBusNamespaceAuthorizationRuleCollection ruleCollection = serviceBusNamespace.GetServiceBusNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send }
            };
            ServiceBusNamespaceAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<ServiceBusNamespaceAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //there should be two authorization rules
            Assert.True(rules.Count > 1);
            bool isContainAuthorizationRuleName = false;
            bool isContainDefaultRuleName = false;
            foreach (ServiceBusNamespaceAuthorizationRuleResource rule in rules)
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
            parameter.Rights.Add(ServiceBusAccessRight.Manage);
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
        public async Task NamespaceAuthorizationRuleRegenerateKey()
        {
            IgnoreTestInLiveMode();
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;
            ServiceBusNamespaceAuthorizationRuleCollection ruleCollection = serviceBusNamespace.GetServiceBusNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            ServiceBusAuthorizationRuleData parameter = new ServiceBusAuthorizationRuleData()
            {
                Rights = { ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send }
            };
            ServiceBusNamespaceAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            ServiceBusAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            ServiceBusAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            ServiceBusAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }

            var updatePrimaryKey = GenerateRandomKey();
            ServiceBusAccessKeys currentKeys = keys3;

            ServiceBusAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.PrimaryKey)
            {
                Key = updatePrimaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updatePrimaryKey, keys4.PrimaryKey);
                Assert.AreEqual(currentKeys.SecondaryKey, keys4.SecondaryKey);
            }

            currentKeys = keys4;
            var updateSecondaryKey = GenerateRandomKey();
            ServiceBusAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new ServiceBusRegenerateAccessKeyContent(ServiceBusAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updateSecondaryKey, keys5.SecondaryKey);
                Assert.AreEqual(currentKeys.PrimaryKey, keys5.PrimaryKey);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SetGetNetworkRuleSets()
        {
            IgnoreTestInLiveMode();
            //create namespace with premium
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceData createParameters = new ServiceBusNamespaceData(DefaultLocation);
            createParameters.Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
            {
                Tier = ServiceBusSkuTier.Premium
            };
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, createParameters)).Value;

            //prepare vnet
            string vnetName = Recording.GenerateAssetName("sdktestvnet");
            var parameters = new VirtualNetworkData
            {
                Subnets = {
                    new SubnetData
                    {
                        Name = "default1",
                        AddressPrefix = "10.0.0.0/24",
                        ServiceEndpoints = { new ServiceEndpointProperties { Service = "Microsoft.ServiceBus" } }
                    },
                    new SubnetData
                    {
                        Name = "default2",
                        AddressPrefix = "10.0.1.0/24",
                        ServiceEndpoints = { new ServiceEndpointProperties { Service = "Microsoft.ServiceBus" } }
                    },
                    new SubnetData
                    {
                        Name = "default3",
                        AddressPrefix = "10.0.2.0/24",
                        ServiceEndpoints = { new ServiceEndpointProperties { Service = "Microsoft.ServiceBus" } }
                    }
                },
                Location = "eastus2"
            };
            parameters.AddressPrefixes.Add("10.0.0.0/16");
            VirtualNetworkResource virtualNetwork = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, parameters)).Value;

            //set network rule set
            string subscriptionId = DefaultSubscription.Id.ToString();
            ResourceIdentifier subnetId1 = new ResourceIdentifier(subscriptionId + "/resourceGroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default1");
            ResourceIdentifier subnetId2 = new ResourceIdentifier(subscriptionId + "/resourceGroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default2");
            ResourceIdentifier subnetId3 = new ResourceIdentifier(subscriptionId + "/resourceGroups/" + _resourceGroup.Id.Name + "/providers/Microsoft.Network/virtualNetworks/" + vnetName + "/subnets/default3");
            ServiceBusNetworkRuleSetData parameter = new ServiceBusNetworkRuleSetData()
            {
                DefaultAction = ServiceBusNetworkRuleSetDefaultAction.Deny,
                VirtualNetworkRules =
                {
                    new ServiceBusNetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){ Id=subnetId1 } ,IgnoreMissingVnetServiceEndpoint = true},
                    new ServiceBusNetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){ Id=subnetId2 } ,IgnoreMissingVnetServiceEndpoint = false},
                    new ServiceBusNetworkRuleSetVirtualNetworkRules() { Subnet = new WritableSubResource(){ Id=subnetId3 } ,IgnoreMissingVnetServiceEndpoint = false}
                },
                IPRules =
                    {
                        new ServiceBusNetworkRuleSetIPRules() { IPMask = "1.1.1.1", Action = "Allow" },
                        new ServiceBusNetworkRuleSetIPRules() { IPMask = "1.1.1.2", Action = "Allow" },
                        new ServiceBusNetworkRuleSetIPRules() { IPMask = "1.1.1.3", Action = "Allow" },
                        new ServiceBusNetworkRuleSetIPRules() { IPMask = "1.1.1.4", Action = "Allow" },
                        new ServiceBusNetworkRuleSetIPRules() { IPMask = "1.1.1.5", Action = "Allow" }
                    }
            };
            await serviceBusNamespace.GetServiceBusNetworkRuleSet().CreateOrUpdateAsync(WaitUntil.Completed, parameter);

            //get the network rule set
            ServiceBusNetworkRuleSetResource networkRuleSet = await serviceBusNamespace.GetServiceBusNetworkRuleSet().GetAsync();
            Assert.NotNull(networkRuleSet);
            Assert.NotNull(networkRuleSet.Data.IPRules);
            Assert.NotNull(networkRuleSet.Data.VirtualNetworkRules);
            Assert.AreEqual(networkRuleSet.Data.VirtualNetworkRules.Count, 3);
            Assert.AreEqual(networkRuleSet.Data.IPRules.Count, 5);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceSystemAssignedEncryptionTests()
        {
            //This test uses a pre-created KeyVault resource. In the event the resource cannot be accessed or is deleted
            //Please create a new key vault in the subscription that the SDK repo is supposed to use
            //And update the KeyVault and KeyName in the ServiceBusTestBase
            ServiceBusNamespaceResource resource = null;

            _resourceGroup = await CreateResourceGroupAsync();
            ResourceGroupResource _sdk_Resource_Group = await GetResourceGroupAsync("ps-testing");
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            KeyVaultCollection kvCollection = _sdk_Resource_Group.GetKeyVaults();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");

            ServiceBusNamespaceData namespaceData = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
                {
                    Tier = ServiceBusSkuTier.Premium,
                    Capacity = 1
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };

            ArmOperation<ServiceBusNamespaceResource> serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, namespaceData).ConfigureAwait(false));

            Assert.AreEqual(namespaceName, serviceBusNamespace.Value.Data.Name);
            Assert.AreEqual(ServiceBusSkuName.Premium, serviceBusNamespace.Value.Data.Sku.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, serviceBusNamespace.Value.Data.Identity.ManagedServiceIdentityType);

            namespaceData = serviceBusNamespace.Value.Data;

            IdentityAccessPermissions identityAccessPermissions = new IdentityAccessPermissions();
            identityAccessPermissions.Keys.Add(IdentityAccessKeyPermission.WrapKey);
            identityAccessPermissions.Keys.Add(IdentityAccessKeyPermission.UnwrapKey);
            identityAccessPermissions.Keys.Add(IdentityAccessKeyPermission.Get);

            KeyVaultAccessPolicy property = new KeyVaultAccessPolicy((Guid)namespaceData.Identity.TenantId, namespaceData.Identity.PrincipalId.ToString(), identityAccessPermissions);
            Response<KeyVaultResource> kvResponse = await kvCollection.GetAsync(VaultName).ConfigureAwait(false);
            KeyVaultData kvData = kvResponse.Value.Data;
            kvData.Properties.AccessPolicies.Add(property);
            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(AzureLocation.EastUS, kvData.Properties);
            ArmOperation<KeyVaultResource> rawUpdateVault = await kvCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            namespaceData.Encryption = new ServiceBusEncryption()
            {
                KeySource = ServiceBusEncryptionKeySource.MicrosoftKeyVault
            };

            namespaceData.Encryption.KeyVaultProperties.Add(new ServiceBusKeyVaultProperties()
            {
                KeyName = Key1,
                KeyVaultUri = kvData.Properties.VaultUri
            });

            namespaceData.Encryption.KeyVaultProperties.Add(new ServiceBusKeyVaultProperties()
            {
                KeyName = Key2,
                KeyVaultUri = kvData.Properties.VaultUri
            });

            namespaceData.Encryption.KeyVaultProperties.Add(new ServiceBusKeyVaultProperties()
            {
                KeyName = Key3,
                KeyVaultUri = kvData.Properties.VaultUri
            });

            resource = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, namespaceData).ConfigureAwait(false)).Value;
            AssertNamespaceMSIOnUpdates(namespaceData, resource.Data);
        }

        [Test]
        [RecordedTest]
        public async Task UserAssignedEncryptionTests()
        {
            ServiceBusNamespaceResource resource = null;
            //UserAssignedIdentityResource identityResource = null;

            _resourceGroup = await CreateResourceGroupAsync();
            ResourceGroupResource _sdk_Resource_Group = await GetResourceGroupAsync("ps-testing");
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            KeyVaultCollection kvCollection = _sdk_Resource_Group.GetKeyVaults();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");

            string identityName_1 = Recording.GenerateAssetName("identity1");
            string identityName_2 = Recording.GenerateAssetName("identity2");
            UserAssignedIdentityCollection identityCollection = _resourceGroup.GetUserAssignedIdentities();

            ResourceIdentifier firstIdentityId, secondIdentityId;
            ArmOperation<UserAssignedIdentityResource> identityResponse_1 = (await identityCollection.CreateOrUpdateAsync(WaitUntil.Completed, identityName_1, new UserAssignedIdentityData(DefaultLocation)));
            ArmOperation<UserAssignedIdentityResource> identityResponse_2 = (await identityCollection.CreateOrUpdateAsync(WaitUntil.Completed, identityName_2, new UserAssignedIdentityData(DefaultLocation)));

            IdentityAccessPermissions identityAccessPermissions = new IdentityAccessPermissions();
            identityAccessPermissions.Keys.Add(IdentityAccessKeyPermission.WrapKey);
            identityAccessPermissions.Keys.Add(IdentityAccessKeyPermission.UnwrapKey);
            identityAccessPermissions.Keys.Add(IdentityAccessKeyPermission.Get);
            KeyVaultAccessPolicy property = new KeyVaultAccessPolicy((Guid)identityResponse_1.Value.Data.TenantId, identityResponse_1.Value.Data.PrincipalId.ToString(), identityAccessPermissions);
            Response<KeyVaultResource> kvResponse = await kvCollection.GetAsync(VaultName).ConfigureAwait(false);
            KeyVaultData kvData = kvResponse.Value.Data;
            kvData.Properties.AccessPolicies.Add(property);
            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(AzureLocation.EastUS, kvData.Properties);
            await kvCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);
            var keyVaultUri = kvData.Properties.VaultUri;
            firstIdentityId = identityResponse_1.Value.Data.Id;
            secondIdentityId = identityResponse_2.Value.Data.Id;

            ServiceBusNamespaceData serviceBusNamespaceData = new ServiceBusNamespaceData(DefaultLocation)
            {
                Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
                {
                    Tier = ServiceBusSkuTier.Premium,
                    Capacity = 1
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };

            serviceBusNamespaceData.Identity.UserAssignedIdentities.Add(new KeyValuePair<ResourceIdentifier, UserAssignedIdentity>(firstIdentityId, new UserAssignedIdentity()));
            serviceBusNamespaceData.Identity.UserAssignedIdentities.Add(new KeyValuePair<ResourceIdentifier, UserAssignedIdentity>(secondIdentityId, new UserAssignedIdentity()));

            serviceBusNamespaceData.Encryption = new ServiceBusEncryption()
            {
                KeySource = ServiceBusEncryptionKeySource.MicrosoftKeyVault
            };

            serviceBusNamespaceData.Encryption.KeyVaultProperties.Add(new ServiceBusKeyVaultProperties()
            {
                KeyName = Key1,
                KeyVaultUri = keyVaultUri,
                Identity = new UserAssignedIdentityProperties(firstIdentityId.ToString(), null)
            });

            serviceBusNamespaceData.Encryption.KeyVaultProperties.Add(new ServiceBusKeyVaultProperties()
            {
                KeyName = Key2,
                KeyVaultUri = keyVaultUri,
                Identity = new UserAssignedIdentityProperties(firstIdentityId.ToString(), null)
            });

            serviceBusNamespaceData.Encryption.KeyVaultProperties.Add(new ServiceBusKeyVaultProperties()
            {
                KeyName = Key3,
                KeyVaultUri = keyVaultUri,
                Identity = new UserAssignedIdentityProperties(firstIdentityId.ToString(), null)
            });

            resource = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, serviceBusNamespaceData)).Value;
            AssertNamespaceMSIOnUpdates(serviceBusNamespaceData, resource.Data);
        }

        [Test]
        [RecordedTest]
        public async Task StandardToPremiumMigration()
        {
            IgnoreTestInLiveMode();
            //create namespace with premium
            _resourceGroup = await CreateResourceGroupAsync();
            ServiceBusNamespaceCollection namespaceCollection = _resourceGroup.GetServiceBusNamespaces();
            string namespaceName1 = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceData createParameters1 = new ServiceBusNamespaceData(DefaultLocation);
            createParameters1.Sku = new ServiceBusSku(ServiceBusSkuName.Premium)
            {
                Tier = ServiceBusSkuTier.Premium
            };
            ServiceBusNamespaceResource serviceBusNamespace1 = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName1, createParameters1)).Value;

            //create namespace with standard
            string namespaceName2 = await CreateValidNamespaceName(namespacePrefix);
            ServiceBusNamespaceData createParameters2 = new ServiceBusNamespaceData(AzureLocation.EastUS);
            createParameters2.Sku = new ServiceBusSku(ServiceBusSkuName.Standard)
            {
                Tier = ServiceBusSkuTier.Standard
            };
            ServiceBusNamespaceResource serviceBusNamespace2 = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, createParameters2)).Value;

            //add 10 queues to standard namespace
            for (int i = 0; i < 10; i++)
            {
                string queueName = Recording.GenerateAssetName("queue" + i);
                _ = await serviceBusNamespace2.GetServiceBusQueues().CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData());
            }

            //add 10 topics to standard namespace
            for (int i = 0; i < 10; i++)
            {
                string topicName = Recording.GenerateAssetName("topic" + i);
                _ = await serviceBusNamespace2.GetServiceBusTopics().CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData());
            }

            //create the migration config, it's name should always be $default
            string postMigrationName = Recording.GenerateAssetName("postmigration");
            var migrationParameters = new MigrationConfigurationData()
            {
                PostMigrationName = postMigrationName,
                TargetServiceBusNamespace = serviceBusNamespace1.Id
            };
            _ = await serviceBusNamespace2.GetMigrationConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, MigrationConfigurationName.Default, migrationParameters);

            //wait for migration state
            MigrationConfigurationResource migrationConfig = await serviceBusNamespace2.GetMigrationConfigurations().GetAsync(MigrationConfigurationName.Default);
            int count = 0;
            while (count < 100 && (migrationConfig.Data.MigrationState != "Active" || (migrationConfig.Data.PendingReplicationOperationsCount.HasValue && migrationConfig.Data.PendingReplicationOperationsCount != 0)))
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(30000);
                }
                migrationConfig = await serviceBusNamespace2.GetMigrationConfigurations().GetAsync(MigrationConfigurationName.Default);
                count++;
            }
            Assert.NotNull(migrationConfig);
            List<MigrationConfigurationResource> migrationConfigs = await serviceBusNamespace2.GetMigrationConfigurations().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, migrationConfigs.Count);

            //complete migration
            await migrationConfig.CompleteMigrationAsync();

            //validate migration
            List<ServiceBusTopicResource> topics = await serviceBusNamespace1.GetServiceBusTopics().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(10, topics.Count);
            List<ServiceBusQueueResource> queues = await serviceBusNamespace1.GetServiceBusQueues().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(10, queues.Count);

            //wait for migration config and premium namespace
            migrationConfig = await serviceBusNamespace2.GetMigrationConfigurations().GetAsync(MigrationConfigurationName.Default);
            count = 0;
            while (count < 100 && migrationConfig.Data.MigrationState != "Active")
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(30000);
                }
                migrationConfig = await serviceBusNamespace2.GetMigrationConfigurations().GetAsync(MigrationConfigurationName.Default);
                count++;
            }
            await GetSucceededNamespace(serviceBusNamespace1);
        }

        public void AssertNamespaceMSIOnUpdates(ServiceBusNamespaceData expectedNamespace, ServiceBusNamespaceData actualNamespace)
        {
            if (expectedNamespace.Identity != null)
            {
                Assert.IsNotNull(actualNamespace.Identity);
                Assert.AreEqual(expectedNamespace.Identity.ManagedServiceIdentityType, actualNamespace.Identity.ManagedServiceIdentityType);
                Assert.AreEqual(expectedNamespace.Identity.PrincipalId, actualNamespace.Identity.PrincipalId);
                Assert.AreEqual(expectedNamespace.Identity.TenantId, actualNamespace.Identity.TenantId);

                if (expectedNamespace.Identity.UserAssignedIdentities != null)
                {
                    Assert.NotNull(actualNamespace.Identity.UserAssignedIdentities);
                    Assert.AreEqual(expectedNamespace.Identity.UserAssignedIdentities.Count, actualNamespace.Identity.UserAssignedIdentities.Count);
                }
                else
                {
                    Assert.Null(actualNamespace.Identity.UserAssignedIdentities);
                }

                if (expectedNamespace.Encryption != null)
                {
                    Assert.NotNull(actualNamespace.Encryption);
                    Assert.AreEqual(expectedNamespace.Encryption.KeyVaultProperties.Count, actualNamespace.Encryption.KeyVaultProperties.Count);
                }
                else
                {
                    Assert.Null(actualNamespace.Encryption);
                }
            }
            else
            {
                Assert.Null(actualNamespace.Identity);
            }
        }

        public async Task<ServiceBusNamespaceResource> GetSucceededNamespace(ServiceBusNamespaceResource serviceBusNamespace)
        {
            int i = 0;
            serviceBusNamespace = await serviceBusNamespace.GetAsync();
            while (!serviceBusNamespace.Data.ProvisioningState.Equals("Succeeded") && i < 100)
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
                serviceBusNamespace = await serviceBusNamespace.GetAsync();
                i++;
            }
            return serviceBusNamespace;
        }
    }
}
