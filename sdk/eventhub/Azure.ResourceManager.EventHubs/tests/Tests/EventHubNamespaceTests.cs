// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.ManagedServiceIdentities;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

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
            EventHubsNamespaceResource eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);
            VerifyNamespaceProperties(eventHubNamespace, true);

            //validate if created successfully
            eventHubNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceCollection.ExistsAsync(namespaceName));
            VerifyNamespaceProperties(eventHubNamespace, true);

            //delete namespace
            await CompleteAsync(await eventHubNamespace.DeleteAsync(WaitUntil.Started));

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
            EventHubsNamespaceResource eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);
            VerifyNamespaceProperties(eventHubNamespace, true);

            //update namespace
            var updateNamespaceParameter = new EventHubsNamespaceData(DefaultLocation);
            updateNamespaceParameter.Tags.Add("key1", "value1");
            updateNamespaceParameter.Tags.Add("key2", "value2");
            ArmOperation<EventHubsNamespaceResource> update = await eventHubNamespace.UpdateAsync(WaitUntil.Started, updateNamespaceParameter);
            AssertStatus(update.GetRawResponse(), 200, 202);
            EventHubsNamespaceResource eventHubNamespace2 = await CompleteAsync(update);

            //validate
            Response<EventHubsNamespaceResource> readBack = await eventHubNamespace2.GetAsync();
            AssertStatus(readBack.GetRawResponse(), 200);
            Assert.AreEqual(2, readBack.Value.Data.Tags.Count);
            Assert.AreEqual("value1", readBack.Value.Data.Tags["key1"]);
            Assert.AreEqual("value2", readBack.Value.Data.Tags["key2"]);
            Assert.IsTrue(readBack.Value.Data.DisableLocalAuth, "A tag-only PATCH must retain disableLocalAuth.");

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
            await CreateNamespaceAsync(_resourceGroup, namespaceName1);
            await CreateNamespaceAsync(_resourceGroup, namespaceName2);
            int count = 0;
            EventHubsNamespaceResource namespace1 = null;
            EventHubsNamespaceResource namespace2 = null;

            //validate
            foreach (EventHubsNamespaceResource eventHubNamespace in await ReadAllAsync(namespaceCollection.GetAllAsync()))
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
            await CreateNamespaceAsync(_resourceGroup, namespaceName1);
            await CreateNamespaceAsync(resourceGroup, namespaceName2);
            int count = 0;
            EventHubsNamespaceResource namespace1 = null;
            EventHubsNamespaceResource namespace2 = null;

            //validate
            foreach (EventHubsNamespaceResource eventHubNamespace in await ReadAllAsync(DefaultSubscription.GetEventHubsNamespacesAsync()))
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

            await CompleteAsync(await namespace2.DeleteAsync(WaitUntil.Started));
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceCreateGetUpdateDeleteAuthorizationRule()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);
            EventHubsNamespaceAuthorizationRuleCollection ruleCollection = eventHubNamespace.GetEventHubsNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubsAuthorizationRuleData parameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubsNamespaceAuthorizationRuleResource authorizationRule = await CompleteAsync(await ruleCollection.CreateOrUpdateAsync(WaitUntil.Started, ruleName, parameter));
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<EventHubsNamespaceAuthorizationRuleResource> rules = await ReadAllAsync(ruleCollection.GetAllAsync());

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
            authorizationRule = await CompleteAsync(await authorizationRule.UpdateAsync(WaitUntil.Started, parameter));
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await CompleteAsync(await authorizationRule.DeleteAsync(WaitUntil.Started));

            //validate if deleted
            Assert.IsFalse(await ruleCollection.ExistsAsync(ruleName));
            rules = await ReadAllAsync(ruleCollection.GetAllAsync());
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
                KafkaEnabled = true,
                DisableLocalAuth = true
            };
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, parameter)).Value;
            VerifyNamespaceProperties(eventHubNamespace, false);
            Assert.IsTrue(eventHubNamespace.Data.KafkaEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task CreateNamespaceWithIPAddressType()
        {
            // Validates the 2026-01-01 'ipAddressType' property (replaces the legacy 'ipV6Enabled' boolean).
            // Covers both enum values: create with DualStack, then update to IPv4 via the synchronous PATCH.
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");

            // create with dual-stack (IPv4 + IPv6)
            EventHubsNamespaceData parameter = new EventHubsNamespaceData(DefaultLocation)
            {
                IPAddressType = EventHubsIPAddressType.DualStack,
                DisableLocalAuth = true
            };
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, parameter)).Value;
            VerifyNamespaceProperties(eventHubNamespace, false);
            Assert.AreEqual(EventHubsIPAddressType.DualStack, eventHubNamespace.Data.IPAddressType);

            // re-fetch to confirm the value is persisted on the service
            eventHubNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.AreEqual(EventHubsIPAddressType.DualStack, eventHubNamespace.Data.IPAddressType);

            // update to IPv4 via the long-running namespace PATCH and assert the round-trip
            eventHubNamespace.Data.IPAddressType = EventHubsIPAddressType.IPv4;
            eventHubNamespace = (await eventHubNamespace.UpdateAsync(WaitUntil.Completed, eventHubNamespace.Data)).Value;
            Assert.AreEqual(EventHubsIPAddressType.IPv4, eventHubNamespace.Data.IPAddressType);

            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceAuthorizationRuleRegenerateKey()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);
            EventHubsNamespaceAuthorizationRuleCollection ruleCollection = eventHubNamespace.GetEventHubsNamespaceAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubsAuthorizationRuleData parameter = new EventHubsAuthorizationRuleData()
            {
                Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
            };
            EventHubsNamespaceAuthorizationRuleResource authorizationRule = await CompleteAsync(await ruleCollection.CreateOrUpdateAsync(WaitUntil.Started, ruleName, parameter));
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

            var updatePrimaryKey = GenerateRandomKey();
            EventHubsAccessKeys currentKeys = keys3;

            EventHubsAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.PrimaryKey)
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
            EventHubsAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.SecondaryKey)
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
        public async Task StandardNamespaceCreateOrUpdateParameters()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation) { DisableLocalAuth = true })).Value;
            Assert.AreEqual(DefaultLocation, eventHubNamespace.Data.Location);
            AssertDefaultNamespaceProperties(eventHubNamespace.Data, EventHubsSkuName.Standard);

            //Re-apply the full namespace definition and verify Disable Local Auth is retained
            EventHubsNamespaceResource updatedNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, eventHubNamespace.Data)).Value;
            AssertNamespacePropertiesOnUpdate(eventHubNamespace.Data, updatedNamespace.Data);

            //Enable AutoInflate on Standard Namespace
            eventHubNamespace.Data.IsAutoInflateEnabled = true;
            eventHubNamespace.Data.MaximumThroughputUnits = 10;
            updatedNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, eventHubNamespace.Data)).Value;
            AssertNamespacePropertiesOnUpdate(eventHubNamespace.Data, updatedNamespace.Data);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await namespaceCollection.ExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        public async Task ZoneRedundantStandardNamespace()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation)
            {
                ZoneRedundant = true,
                DisableLocalAuth = true
            })).Value;

            Assert.AreEqual(DefaultLocation, eventHubNamespace.Data.Location);
            Assert.True(eventHubNamespace.Data.ZoneRedundant);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await namespaceCollection.ExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        [Ignore("Premium namespace creation is restricted in the recording subscription; re-record when Premium capacity is available.")]
        public async Task PremiumNamespaceCreateOrUpdate()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation)
            {
                Sku = new EventHubsSku(EventHubsSkuName.Premium)
                {
                    Tier = EventHubsSkuTier.Premium,
                    Capacity = 1
                },
                DisableLocalAuth = true
            })).Value;
            AssertDefaultNamespaceProperties(eventHubNamespace.Data, EventHubsSkuName.Premium);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await namespaceCollection.ExistsAsync(namespaceName));
        }

        [Test]
        [RecordedTest]
        [Ignore("Run in Record mode only. Will fix later.")]
        public async Task NamespaceSystemAssignedEncryptionTests()
        {
            //This test uses a pre-created KeyVault resource. In the event the resource cannot be accessed or is deleted
            //Please create a new key vault in the subscription that the SDK repo is supposed to use
            //And update the KeyVault and KeyName in the EventHubsTestBase
            EventHubsNamespaceResource resource = null;

            _resourceGroup = await CreateResourceGroupAsync();
            ResourceGroupResource _sdk_Resource_Group = await GetResourceGroupAsync("ps-testing");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            KeyVaultCollection kvCollection = _sdk_Resource_Group.GetKeyVaults();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");

            EventHubsNamespaceData namespaceData = new EventHubsNamespaceData(DefaultLocation)
            {
                Sku = new EventHubsSku("Premium")
                {
                    Tier = "Premium",
                    Capacity = 1
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };

            ArmOperation<EventHubsNamespaceResource> eventHubsNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, namespaceData).ConfigureAwait(false));

            Assert.AreEqual(namespaceName, eventHubsNamespace.Value.Data.Name);
            Assert.AreEqual(EventHubsSkuName.Premium, eventHubsNamespace.Value.Data.Sku.Name);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, eventHubsNamespace.Value.Data.Identity.ManagedServiceIdentityType);

            namespaceData = eventHubsNamespace.Value.Data;

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

            namespaceData.Encryption = new EventHubsEncryption()
            {
                KeySource = EventHubsKeySource.MicrosoftKeyVault
            };

            namespaceData.Encryption.KeyVaultProperties.Add(new EventHubsKeyVaultProperties()
            {
                KeyName = Key1,
                KeyVaultUri = kvData.Properties.VaultUri
            });

            namespaceData.Encryption.KeyVaultProperties.Add(new EventHubsKeyVaultProperties()
            {
                KeyName = Key2,
                KeyVaultUri = kvData.Properties.VaultUri
            });

            resource = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, namespaceData).ConfigureAwait(false)).Value;
            AssertNamespaceMSIOnUpdates(namespaceData, resource.Data);

            await resource.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
        }

        [Test]
        [RecordedTest]
        [Ignore("Run in Record mode only. Will fix later.")]
        public async Task UserAssignedEncryptionTests()
        {
            EventHubsNamespaceResource resource = null;
            //UserAssignedIdentityResource identityResource = null;

            _resourceGroup = await CreateResourceGroupAsync();
            ResourceGroupResource _sdk_Resource_Group = await GetResourceGroupAsync("ps-testing");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            KeyVaultCollection kvCollection = _sdk_Resource_Group.GetKeyVaults();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");

            string identityName_1 = Recording.GenerateAssetName("identity1");
            string identityName_2 = Recording.GenerateAssetName("identity2");
            UserAssignedIdentityCollection identityCollection = _resourceGroup.GetUserAssignedIdentities();

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
            ArmOperation<KeyVaultResource> rawUpdateVault = await kvCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            EventHubsNamespaceData eventHubsNamespaceData = new EventHubsNamespaceData(DefaultLocation)
            {
                Sku = new EventHubsSku("Premium")
                {
                    Tier = "Premium",
                    Capacity = 1
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };

            eventHubsNamespaceData.Identity.UserAssignedIdentities.Add(new KeyValuePair<ResourceIdentifier, UserAssignedIdentity>(identityResponse_1.Value.Data.Id, new UserAssignedIdentity()));
            eventHubsNamespaceData.Identity.UserAssignedIdentities.Add(new KeyValuePair<ResourceIdentifier, UserAssignedIdentity>(identityResponse_2.Value.Data.Id, new UserAssignedIdentity()));

            eventHubsNamespaceData.Encryption = new EventHubsEncryption()
            {
                KeySource = EventHubsKeySource.MicrosoftKeyVault
            };

            eventHubsNamespaceData.Encryption.KeyVaultProperties.Add(new EventHubsKeyVaultProperties()
            {
                KeyName = Key1,
                KeyVaultUri = kvData.Properties.VaultUri,
                Identity = new UserAssignedIdentityProperties(identityResponse_1.Value.Data.Id.ToString(), null)
            });

            eventHubsNamespaceData.Encryption.KeyVaultProperties.Add(new EventHubsKeyVaultProperties()
            {
                KeyName = Key2,
                KeyVaultUri = kvData.Properties.VaultUri,
                Identity = new UserAssignedIdentityProperties(identityResponse_1.Value.Data.Id.ToString(), null)
            });

            resource = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, eventHubsNamespaceData)).Value;
            AssertNamespaceMSIOnUpdates(eventHubsNamespaceData, resource.Data);
            await resource.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
        }

        public void AssertDefaultNamespaceProperties(EventHubsNamespaceData namespaceData, EventHubsSkuName SkuName)
        {
            if (SkuName == EventHubsSkuName.Standard)
            {
                Assert.AreEqual(EventHubsSkuName.Standard, namespaceData.Sku.Name);
                Assert.AreEqual(1, namespaceData.Sku.Capacity);
                Assert.True(namespaceData.ZoneRedundant);
                Assert.True(namespaceData.DisableLocalAuth);
                Assert.False(namespaceData.IsAutoInflateEnabled);
                Assert.AreEqual(0, namespaceData.MaximumThroughputUnits);
                Assert.True(namespaceData.KafkaEnabled);
            }
            else
            {
                Assert.AreEqual(EventHubsSkuName.Premium, namespaceData.Sku.Name);
                Assert.AreEqual(1, namespaceData.Sku.Capacity);
                Assert.True(namespaceData.ZoneRedundant);
                Assert.True(namespaceData.DisableLocalAuth);
                Assert.False(namespaceData.IsAutoInflateEnabled);
                Assert.AreEqual(0, namespaceData.MaximumThroughputUnits);
                Assert.True(namespaceData.KafkaEnabled);
            }
        }

        public void AssertNamespacePropertiesOnUpdate(EventHubsNamespaceData expectedNamespace, EventHubsNamespaceData actualNamespace)
        {
            Assert.AreEqual(expectedNamespace.Sku.Name, actualNamespace.Sku.Name);
            Assert.AreEqual(expectedNamespace.Sku.Capacity, actualNamespace.Sku.Capacity);
            Assert.AreEqual(expectedNamespace.ZoneRedundant, actualNamespace.ZoneRedundant);
            Assert.AreEqual(expectedNamespace.DisableLocalAuth, actualNamespace.DisableLocalAuth);
            Assert.AreEqual(expectedNamespace.IsAutoInflateEnabled, actualNamespace.IsAutoInflateEnabled);
            Assert.AreEqual(expectedNamespace.MaximumThroughputUnits, actualNamespace.MaximumThroughputUnits);
            Assert.AreEqual(expectedNamespace.KafkaEnabled, actualNamespace.KafkaEnabled);
        }

        public void AssertNamespaceMSIOnUpdates(EventHubsNamespaceData expectedNamespace, EventHubsNamespaceData actualNamespace)
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
                    new EventHubsNetworkRuleSetVirtualNetworkRules() { SubnetId = subnetId1 },
                    new EventHubsNetworkRuleSetVirtualNetworkRules() { SubnetId = subnetId2 },
                    new EventHubsNetworkRuleSetVirtualNetworkRules() { SubnetId = subnetId3 }
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

        [TestCase(false)]
        [RecordedTest]
        [Ignore("Run in Record mode only. Will fix later.")]
        public async Task AddSetRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt10");
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;

            //add a tag
            eventHubNamespace = await eventHubNamespace.AddTagAsync("key1", "value1");
            Assert.AreEqual(eventHubNamespace.Data.Tags.Count, 1);
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(eventHubNamespace.Data.Tags["key1"], "value1");
            }

            //set the tag
            eventHubNamespace.Data.Tags.Add("key2", "value2");
            eventHubNamespace = await eventHubNamespace.SetTagsAsync(eventHubNamespace.Data.Tags);
            Assert.AreEqual(eventHubNamespace.Data.Tags.Count, 2);
            Assert.AreEqual(eventHubNamespace.Data.Tags["key2"], "value2");

            //remove a tag
            eventHubNamespace = await eventHubNamespace.RemoveTagAsync("key1");
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
            Assert.AreEqual("Succeeded", eventHubNamespace.Data.ProvisioningState);
            return eventHubNamespace;
        }

        [Test]
        [RecordedTest]
        public async Task GetEventHubPrivateLinkResources()
        {
            //create namespace
            _resourceGroup = await CreateResourceGroupAsync();
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceResource eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);

            //get private link resource
            var resources = await ReadAllAsync(eventHubNamespace.GetPrivateLinkResourcesAsync());
            Assert.IsNotEmpty(resources);
            Assert.That(resources.Any(resource => resource.GroupId == "namespace"));
        }

        [RecordedTest]
        public async Task UpdateNamespaceAuthenticationPreservesTags()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var resource = await CreateNamespaceAsync(_resourceGroup, await CreateValidNamespaceName("testnamespacemgmt"));
            await CompleteAsync(await resource.UpdateAsync(WaitUntil.Started, new EventHubsNamespaceData(DefaultLocation)
            {
                Tags = { { "retained", "value" } }
            }));
            EventHubsNamespaceResource updated = await CompleteAsync(await resource.UpdateAsync(WaitUntil.Started, new EventHubsNamespaceData(DefaultLocation)
            {
                DisableLocalAuth = true
            }));
            Assert.IsTrue(updated.Data.DisableLocalAuth);
            Response<EventHubsNamespaceResource> readBack = await resource.GetAsync();
            AssertStatus(readBack.GetRawResponse(), 200);
            Assert.IsTrue(readBack.Value.Data.DisableLocalAuth);
            Assert.AreEqual("value", readBack.Value.Data.Tags["retained"]);
            Assert.AreEqual("Succeeded", readBack.Value.Data.ProvisioningState);
        }

        [RecordedTest]
        public async Task CreateGetAndListNetworkRuleSets()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var resource = await CreateNamespaceAsync(_resourceGroup, await CreateValidNamespaceName("testnamespacemgmt"));
            await CompleteAsync(await resource.GetEventHubsNetworkRuleSet().CreateOrUpdateAsync(WaitUntil.Started, new EventHubsNetworkRuleSetData
            {
                DefaultAction = EventHubsNetworkRuleSetDefaultAction.Deny,
                IPRules = { new EventHubsNetworkRuleSetIPRules { IPMask = "1.1.1.1", Action = "Allow" } }
            }));
            Response<EventHubsNetworkRuleSetResource> readBack = await resource.GetEventHubsNetworkRuleSet().GetAsync();
            AssertStatus(readBack.GetRawResponse(), 200);
            Assert.AreEqual(EventHubsNetworkRuleSetDefaultAction.Deny, readBack.Value.Data.DefaultAction);
            Assert.AreEqual(1, readBack.Value.Data.IPRules.Count);
            var listed = await resource.GetNetworkRuleSetsAsync();
            AssertStatus(listed.GetRawResponse(), 200);
            Assert.IsNotNull(listed.Value);
        }
        private const string NamespaceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/tests/providers/Microsoft.EventHub/namespaces/test";
        private const string PollPath = "/providers/Microsoft.EventHub/operations/test";
        private const string NamespaceJson = "{\"id\":\"" + NamespaceId + "\",\"name\":\"test\",\"type\":\"Microsoft.EventHub/namespaces\",\"location\":\"eastus2\",\"tags\":{\"retained\":\"value\"},\"properties\":{\"provisioningState\":\"Succeeded\",\"disableLocalAuth\":true}}";

        [Test]
        [Category("Unit")]
        public async Task DefaultArmRetryRecoversOnLastAttempt()
        {
            var options = new ArmClientOptions();
            Assert.AreEqual(RetryMode.Exponential, options.Retry.Mode);
            Assert.AreEqual(3, options.Retry.MaxRetries);
            Assert.AreEqual(TimeSpan.FromSeconds(0.8), options.Retry.Delay);
            Assert.AreEqual(TimeSpan.FromMinutes(1), options.Retry.MaxDelay);
            int attempts = 0;
            options.Transport = new MockTransport(_ => ++attempts < 4
                ? new MockResponse(503).AddHeader("Retry-After", "0")
                : new MockResponse(200).SetContent(NamespaceJson));
            Response<EventHubsNamespaceResource> response = await CreateResource(options).GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(4, attempts);
        }

        [Test]
        [Category("Unit")]
        public void DefaultArmRetryStopsAfterThreeRetries()
        {
            int attempts = 0;
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(_ =>
                {
                    attempts++;
                    return new MockResponse(503).AddHeader("Retry-After", "0");
                })
            };
            RequestFailedException failure = Assert.ThrowsAsync<RequestFailedException>(async () => await CreateResource(options).GetAsync());
            Assert.AreEqual(503, failure.Status);
            Assert.AreEqual(4, attempts);
        }

        [Test]
        [Category("Unit")]
        public void DefaultArmRetryDoesNotRetryBadRequest()
        {
            int attempts = 0;
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(_ =>
                {
                    attempts++;
                    return new MockResponse(400);
                })
            };
            RequestFailedException failure = Assert.ThrowsAsync<RequestFailedException>(async () => await CreateResource(options).GetAsync());
            Assert.AreEqual(400, failure.Status);
            Assert.AreEqual(1, attempts);
        }

        [Test]
        [Category("Unit")]
        public async Task Patch200CompletesWithoutPollingAndOmitsUnchangedAuthentication()
        {
            int requests = 0;
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(request =>
                {
                    requests++;
                    Assert.AreEqual(RequestMethod.Patch, request.Method);
                    using var body = ReadBody(request);
                    Assert.AreEqual("value", body.RootElement.GetProperty("tags").GetProperty("retained").GetString());
                    Assert.IsFalse(body.RootElement.TryGetProperty("properties", out var properties) &&
                        properties.TryGetProperty("disableLocalAuth", out _));
                    return new MockResponse(200).SetContent(NamespaceJson);
                })
            };
            ArmOperation<EventHubsNamespaceResource> operation = await CreateResource(options).UpdateAsync(
                WaitUntil.Completed, new EventHubsNamespaceData(AzureLocation.EastUS2) { Tags = { { "retained", "value" } } });
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
            Assert.AreEqual("value", operation.Value.Data.Tags["retained"]);
            Assert.IsTrue(operation.Value.Data.DisableLocalAuth);
            Assert.AreEqual(1, requests);
        }

        [Test]
        [Category("Unit")]
        public async Task Patch202TagUpdatePollsUntilSucceededAndPreservesAuthentication()
        {
            var transport = new MockTransport(
                new MockResponse(202).AddHeader("Azure-AsyncOperation", "https://management.azure.com" + PollPath).AddHeader("Retry-After", "0"),
                new MockResponse(200).AddHeader("Retry-After", "0").SetContent("{\"status\":\"InProgress\"}"),
                new MockResponse(200).SetContent("{\"status\":\"Succeeded\"}"),
                new MockResponse(200).SetContent(NamespaceJson.Replace("\"retained\":\"value\"", "\"retained\":\"updated\"")));
            var resource = CreateResource(new ArmClientOptions { Transport = transport });
            ArmOperation<EventHubsNamespaceResource> operation = await resource.UpdateAsync(
                WaitUntil.Started, new EventHubsNamespaceData(AzureLocation.EastUS2) { Tags = { { "retained", "updated" } } });
            Assert.AreEqual(202, operation.GetRawResponse().Status);
            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(1, transport.Requests.Count);
            using var body = ReadBody(transport.Requests[0]);
            Assert.AreEqual("updated", body.RootElement.GetProperty("tags").GetProperty("retained").GetString());
            Assert.IsFalse(body.RootElement.TryGetProperty("properties", out var properties) &&
                properties.TryGetProperty("disableLocalAuth", out _));
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
            Assert.AreEqual("Succeeded", operation.Value.Data.ProvisioningState);
            Assert.AreEqual("updated", operation.Value.Data.Tags["retained"]);
            Assert.IsTrue(operation.Value.Data.DisableLocalAuth);
            Assert.AreEqual(4, transport.Requests.Count);
            Assert.AreEqual(PollPath, transport.Requests[1].Uri.Path);
            Assert.AreEqual(PollPath, transport.Requests[2].Uri.Path);
            Assert.AreEqual(NamespaceId, transport.Requests[3].Uri.Path);
        }

        [Test]
        [Category("Unit")]
        public async Task Patch202PollsUntilSucceededAndRetainsTags()
        {
            int requests = 0;
            var options = new ArmClientOptions
            {
                Transport = new MockTransport(request =>
                {
                    requests++;
                    if (requests == 1)
                    {
                        Assert.AreEqual(RequestMethod.Patch, request.Method);
                        using var body = ReadBody(request);
                        Assert.IsFalse(body.RootElement.GetProperty("properties").GetProperty("disableLocalAuth").GetBoolean());
                        Assert.IsFalse(body.RootElement.TryGetProperty("tags", out _));
                        return new MockResponse(202).AddHeader("Azure-AsyncOperation", "https://management.azure.com" + PollPath)
                            .AddHeader("Retry-After", "0");
                    }
                    Assert.AreEqual(RequestMethod.Get, request.Method);
                    if (requests < 4)
                    {
                        Assert.AreEqual(PollPath, request.Uri.Path);
                        return new MockResponse(200).AddHeader("Retry-After", "0")
                            .SetContent(requests == 2 ? "{\"status\":\"InProgress\"}" : "{\"status\":\"Succeeded\"}");
                    }
                    Assert.AreEqual(NamespaceId, request.Uri.Path);
                    return new MockResponse(200).SetContent(NamespaceJson.Replace("\"disableLocalAuth\":true", "\"disableLocalAuth\":false"));
                })
            };
            ArmOperation<EventHubsNamespaceResource> operation = await CreateResource(options).UpdateAsync(
                WaitUntil.Started, new EventHubsNamespaceData(AzureLocation.EastUS2) { DisableLocalAuth = false });
            Assert.AreEqual(202, operation.GetRawResponse().Status);
            Assert.IsFalse(operation.HasCompleted);
            Assert.AreEqual(1, requests);
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
            Assert.AreEqual("Succeeded", operation.Value.Data.ProvisioningState);
            Assert.AreEqual("value", operation.Value.Data.Tags["retained"]);
            Assert.IsFalse(operation.Value.Data.DisableLocalAuth);
            Assert.AreEqual(4, requests);
        }

        private EventHubsNamespaceResource CreateResource(ArmClientOptions options)
        {
            var client = InstrumentClient(new ArmClient(new MockCredential(), "00000000-0000-0000-0000-000000000001", options));
            return client.GetEventHubsNamespaceResource(new ResourceIdentifier(NamespaceId));
        }

        private static JsonDocument ReadBody(MockRequest request)
        {
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            return JsonDocument.Parse(Encoding.UTF8.GetString(stream.ToArray()));
        }
    }
}
