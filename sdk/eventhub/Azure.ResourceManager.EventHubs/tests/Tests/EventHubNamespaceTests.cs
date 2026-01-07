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
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Models;
using Azure.Core;
using Azure.ResourceManager.ManagedServiceIdentities;

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
            Assert.That((bool)await namespaceCollection.ExistsAsync(namespaceName), Is.True);
            VerifyNamespaceProperties(eventHubNamespace, true);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await namespaceCollection.ExistsAsync(namespaceName), Is.False);
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
            var eventHubNamespace2 = await eventHubNamespace.UpdateAsync(WaitUntil.Completed, updateNamespaceParameter);

            //validate
            Assert.That(eventHubNamespace2.Value.Data.Tags.Count, Is.EqualTo(2));
            Assert.That(eventHubNamespace2.Value.Data.Tags["key1"], Is.EqualTo("value1"));
            Assert.That(eventHubNamespace2.Value.Data.Tags["key2"], Is.EqualTo("value2"));

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
            Assert.That(count, Is.EqualTo(2));
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
        }

        [Test]
        [RecordedTest]
        [Ignore("Testing")]
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
            Assert.That(_resourceGroup.Id.Name, Is.EqualTo(namespace1.Id.ResourceGroupName));
            Assert.That(resourceGroup.Id.Name, Is.EqualTo(namespace2.Id.ResourceGroupName));

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
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.That(ruleName, Is.EqualTo(authorizationRule.Id.Name));
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //get all authorization rules
            List<EventHubsNamespaceAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //there should be two authorization rules
            Assert.That(rules.Count > 1, Is.True);
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
            Assert.That(isContainDefaultRuleName, Is.True);
            Assert.That(isContainAuthorizationRuleName, Is.True);

            //update authorization rule
            parameter.Rights.Add(EventHubsAccessRight.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.That((bool)await ruleCollection.ExistsAsync(ruleName), Is.False);
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(rules.Count, Is.EqualTo(1));
            Assert.That(rules[0].Id.Name, Is.EqualTo(DefaultNamespaceAuthorizationRule));
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
            Assert.That(eventHubNamespace.Data.KafkaEnabled, Is.True);
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
            Assert.That(authorizationRule, Is.Not.Null);
            Assert.That(parameter.Rights.Count, Is.EqualTo(authorizationRule.Data.Rights.Count));

            EventHubsAccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.That(keys1, Is.Not.Null);
            Assert.That(keys1.PrimaryConnectionString, Is.Not.Null);
            Assert.That(keys1.SecondaryConnectionString, Is.Not.Null);

            EventHubsAccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys2.PrimaryKey, Is.Not.EqualTo(keys1.PrimaryKey));
                Assert.That(keys2.SecondaryKey, Is.EqualTo(keys1.SecondaryKey));
            }

            EventHubsAccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys3.PrimaryKey, Is.EqualTo(keys2.PrimaryKey));
                Assert.That(keys3.SecondaryKey, Is.Not.EqualTo(keys2.SecondaryKey));
            }

            var updatePrimaryKey = GenerateRandomKey();
            EventHubsAccessKeys currentKeys = keys3;

            EventHubsAccessKeys keys4 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.PrimaryKey)
            {
                Key = updatePrimaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys4.PrimaryKey, Is.EqualTo(updatePrimaryKey));
                Assert.That(keys4.SecondaryKey, Is.EqualTo(currentKeys.SecondaryKey));
            }

            currentKeys = keys4;
            var updateSecondaryKey = GenerateRandomKey();
            EventHubsAccessKeys keys5 = await authorizationRule.RegenerateKeysAsync(new EventHubsRegenerateAccessKeyContent(EventHubsAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(keys5.SecondaryKey, Is.EqualTo(updateSecondaryKey));
                Assert.That(keys5.PrimaryKey, Is.EqualTo(currentKeys.PrimaryKey));
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
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
            Assert.That(eventHubNamespace.Data.Location, Is.EqualTo(DefaultLocation));
            AssertDefaultNamespaceProperties(eventHubNamespace.Data, EventHubsSkuName.Standard);

            //Set Disable Local Auth on the standard namespace
            eventHubNamespace.Data.DisableLocalAuth = true;
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
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await namespaceCollection.ExistsAsync(namespaceName), Is.False);
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
                ZoneRedundant = true
            })).Value;

            Assert.That(eventHubNamespace.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(eventHubNamespace.Data.ZoneRedundant, Is.True);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await namespaceCollection.ExistsAsync(namespaceName), Is.False);
        }

        [Test]
        [RecordedTest]
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
                }
            })).Value;
            AssertDefaultNamespaceProperties(eventHubNamespace.Data, EventHubsSkuName.Premium);

            //delete namespace
            await eventHubNamespace.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await namespaceCollection.GetAsync(namespaceName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await namespaceCollection.ExistsAsync(namespaceName), Is.False);
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

            Assert.That(eventHubsNamespace.Value.Data.Name, Is.EqualTo(namespaceName));
            Assert.That(eventHubsNamespace.Value.Data.Sku.Name, Is.EqualTo(EventHubsSkuName.Premium));
            Assert.That(eventHubsNamespace.Value.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

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
                Assert.That(namespaceData.Sku.Name, Is.EqualTo(EventHubsSkuName.Standard));
                Assert.That(namespaceData.Sku.Capacity, Is.EqualTo(1));
                Assert.That(namespaceData.ZoneRedundant, Is.True);
                Assert.That(namespaceData.DisableLocalAuth, Is.False);
                Assert.That(namespaceData.IsAutoInflateEnabled, Is.False);
                Assert.That(namespaceData.MaximumThroughputUnits, Is.EqualTo(0));
                Assert.That(namespaceData.KafkaEnabled, Is.True);
            }
            else
            {
                Assert.That(namespaceData.Sku.Name, Is.EqualTo(EventHubsSkuName.Premium));
                Assert.That(namespaceData.Sku.Capacity, Is.EqualTo(1));
                Assert.That(namespaceData.ZoneRedundant, Is.True);
                Assert.That(namespaceData.DisableLocalAuth, Is.False);
                Assert.That(namespaceData.IsAutoInflateEnabled, Is.False);
                Assert.That(namespaceData.MaximumThroughputUnits, Is.EqualTo(0));
                Assert.That(namespaceData.KafkaEnabled, Is.True);
            }
        }

        public void AssertNamespacePropertiesOnUpdate(EventHubsNamespaceData expectedNamespace, EventHubsNamespaceData actualNamespace)
        {
            Assert.That(actualNamespace.Sku.Name, Is.EqualTo(expectedNamespace.Sku.Name));
            Assert.That(actualNamespace.Sku.Capacity, Is.EqualTo(expectedNamespace.Sku.Capacity));
            Assert.That(actualNamespace.ZoneRedundant, Is.EqualTo(expectedNamespace.ZoneRedundant));
            Assert.That(actualNamespace.DisableLocalAuth, Is.EqualTo(expectedNamespace.DisableLocalAuth));
            Assert.That(actualNamespace.IsAutoInflateEnabled, Is.EqualTo(expectedNamespace.IsAutoInflateEnabled));
            Assert.That(actualNamespace.MaximumThroughputUnits, Is.EqualTo(expectedNamespace.MaximumThroughputUnits));
            Assert.That(actualNamespace.KafkaEnabled, Is.EqualTo(expectedNamespace.KafkaEnabled));
        }

        public void AssertNamespaceMSIOnUpdates(EventHubsNamespaceData expectedNamespace, EventHubsNamespaceData actualNamespace)
        {
            if (expectedNamespace.Identity != null)
            {
                Assert.That(actualNamespace.Identity, Is.Not.Null);
                Assert.That(actualNamespace.Identity.ManagedServiceIdentityType, Is.EqualTo(expectedNamespace.Identity.ManagedServiceIdentityType));
                Assert.That(actualNamespace.Identity.PrincipalId, Is.EqualTo(expectedNamespace.Identity.PrincipalId));
                Assert.That(actualNamespace.Identity.TenantId, Is.EqualTo(expectedNamespace.Identity.TenantId));

                if (expectedNamespace.Identity.UserAssignedIdentities != null)
                {
                    Assert.That(actualNamespace.Identity.UserAssignedIdentities, Is.Not.Null);
                    Assert.That(actualNamespace.Identity.UserAssignedIdentities.Count, Is.EqualTo(expectedNamespace.Identity.UserAssignedIdentities.Count));
                }
                else
                {
                    Assert.That(actualNamespace.Identity.UserAssignedIdentities, Is.Null);
                }

                if (expectedNamespace.Encryption != null)
                {
                    Assert.That(actualNamespace.Encryption, Is.Not.Null);
                    Assert.That(actualNamespace.Encryption.KeyVaultProperties.Count, Is.EqualTo(expectedNamespace.Encryption.KeyVaultProperties.Count));
                }
                else
                {
                    Assert.That(actualNamespace.Encryption, Is.Null);
                }
            }
            else
            {
                Assert.That(actualNamespace.Identity, Is.Null);
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
            Assert.That(networkRuleSet, Is.Not.Null);
            Assert.That(networkRuleSet.Data.IPRules, Is.Not.Null);
            Assert.That(networkRuleSet.Data.VirtualNetworkRules, Is.Not.Null);
            Assert.That(networkRuleSet.Data.VirtualNetworkRules.Count, Is.EqualTo(3));
            Assert.That(networkRuleSet.Data.IPRules.Count, Is.EqualTo(5));

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
            Assert.That(eventHubNamespace.Data.Tags.Count, Is.EqualTo(1));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(eventHubNamespace.Data.Tags["key1"], Is.EqualTo("value1"));
            }

            //set the tag
            eventHubNamespace.Data.Tags.Add("key2", "value2");
            eventHubNamespace = await eventHubNamespace.SetTagsAsync(eventHubNamespace.Data.Tags);
            Assert.That(eventHubNamespace.Data.Tags.Count, Is.EqualTo(2));
            Assert.That(eventHubNamespace.Data.Tags["key2"], Is.EqualTo("value2"));

            //remove a tag
            eventHubNamespace = await eventHubNamespace.RemoveTagAsync("key1");
            Assert.That(eventHubNamespace.Data.Tags.Count, Is.EqualTo(1));

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
