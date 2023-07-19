// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Relay.Models;
using Azure.ResourceManager.Relay.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Relay.Tests
{
    public class AuthorizationRuleTests: RelayTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private RelayNamespaceResource _relayNamespace;
        private RelayHybridConnectionResource _relayHybridConnection;
        private WcfRelayResource _relayWcf;

        public AuthorizationRuleTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            RelayNamespaceCollection namespaceCollection = _resourceGroup.GetRelayNamespaces();
            _relayNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new RelayNamespaceData(DefaultLocation))).Value;

            RelayHybridConnectionCollection _hybridConnectionCollection = _relayNamespace.GetRelayHybridConnections();
            _relayHybridConnection = (await _hybridConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h1", new RelayHybridConnectionData()
                {
                    IsClientAuthorizationRequired = true
                })).Value;

            WcfRelayCollection _wcfRelayCollection = _relayNamespace.GetWcfRelays();
            _relayWcf = (await _wcfRelayCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h2", new WcfRelayData()
                {
                    IsClientAuthorizationRequired = true,
                    RelayType = RelayType.NetTcp
                })).Value;
        }

        [Test]
        [RecordedTest]
        public async Task NamespaceAuthorizationRuleAndKeyGenerationsTests()
        {
            RelayNamespaceAuthorizationRuleCollection _relayAuthRule = _relayNamespace.GetRelayNamespaceAuthorizationRules();

            RelayAuthorizationRuleData relayAuthRule = new RelayAuthorizationRuleData()
            {
                Rights = { RelayAccessRight.Listen, RelayAccessRight.Send, RelayAccessRight.Manage }
            };

            RelayNamespaceAuthorizationRuleResource _relayAuthRuleResource = (await _relayAuthRule.CreateOrUpdateAsync(WaitUntil.Completed, "authRule1", relayAuthRule)).Value;
            Assert.AreEqual(3, _relayAuthRuleResource.Data.Rights.Count);

            relayAuthRule.Rights.Remove(RelayAccessRight.Manage);
            relayAuthRule.Rights.Remove(RelayAccessRight.Listen);
            _relayAuthRuleResource = (await _relayAuthRuleResource.UpdateAsync(WaitUntil.Completed, relayAuthRule)).Value;
            Assert.AreEqual(1, _relayAuthRuleResource.Data.Rights.Count);

            var listOfAuthRules = await _relayAuthRule.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, listOfAuthRules.Count);

            //Regenerate Keys on the authorization rule
            RelayAccessKeys keys1 = await _relayAuthRuleResource.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            RelayAccessKeys keys2 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            RelayAccessKeys keys3 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }

            var updatePrimaryKey = GenerateRandomKey();
            RelayAccessKeys currentKeys = keys3;

            RelayAccessKeys keys4 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.PrimaryKey)
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
            RelayAccessKeys keys5 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updateSecondaryKey, keys5.SecondaryKey);
                Assert.AreEqual(currentKeys.PrimaryKey, keys5.PrimaryKey);
            }

            await _relayAuthRuleResource.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _relayAuthRuleResource.GetAsync(); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _relayAuthRule.ExistsAsync("authRule1"));
        }

        [Test]
        [RecordedTest]
        public async Task HybridConnectionAuthorizationRuleAndKeyGenerationsTests()
        {
            RelayHybridConnectionAuthorizationRuleCollection _hybridConnectionAuthRule = _relayHybridConnection.GetRelayHybridConnectionAuthorizationRules();

            RelayAuthorizationRuleData relayAuthRuleData = new RelayAuthorizationRuleData()
            {
                Rights = { RelayAccessRight.Listen }
            };

            RelayHybridConnectionAuthorizationRuleResource _relayAuthRuleResource = (await _hybridConnectionAuthRule.CreateOrUpdateAsync(WaitUntil.Completed, "authRule1", relayAuthRuleData)).Value;
            Assert.AreEqual(1, _relayAuthRuleResource.Data.Rights.Count);

            relayAuthRuleData.Rights.Add(RelayAccessRight.Manage);
            relayAuthRuleData.Rights.Add(RelayAccessRight.Send);
            _relayAuthRuleResource = (await _relayAuthRuleResource.UpdateAsync(WaitUntil.Completed, relayAuthRuleData)).Value;
            Assert.AreEqual(3, _relayAuthRuleResource.Data.Rights.Count);

            var listOfAuthRules = await _hybridConnectionAuthRule.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, listOfAuthRules.Count);

            //Regenerate Keys on the authorization rule
            RelayAccessKeys keys1 = await _relayAuthRuleResource.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            RelayAccessKeys keys2 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            RelayAccessKeys keys3 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }

            var updatePrimaryKey = GenerateRandomKey();
            RelayAccessKeys currentKeys = keys3;

            RelayAccessKeys keys4 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.PrimaryKey)
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
            RelayAccessKeys keys5 = await _relayAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updateSecondaryKey, keys5.SecondaryKey);
                Assert.AreEqual(currentKeys.PrimaryKey, keys5.PrimaryKey);
            }

            await _relayAuthRuleResource.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _relayAuthRuleResource.GetAsync(); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _hybridConnectionAuthRule.ExistsAsync("authRule1"));
        }

        [Test]
        [RecordedTest]
        public async Task WcfRelayAuthorizationRuleAndKeyGenerationsTests()
        {
            WcfRelayAuthorizationRuleCollection wcfAuthRuleCollection = _relayWcf.GetWcfRelayAuthorizationRules();

            RelayAuthorizationRuleData relayAuthRuleData = new RelayAuthorizationRuleData()
            {
                Rights = { RelayAccessRight.Listen }
            };

            WcfRelayAuthorizationRuleResource _wcfAuthRuleResource = (await wcfAuthRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, "authRule1", relayAuthRuleData)).Value;
            Assert.AreEqual(1, _wcfAuthRuleResource.Data.Rights.Count);

            relayAuthRuleData.Rights.Add(RelayAccessRight.Manage);
            relayAuthRuleData.Rights.Add(RelayAccessRight.Send);
            _wcfAuthRuleResource = (await _wcfAuthRuleResource.UpdateAsync(WaitUntil.Completed, relayAuthRuleData)).Value;
            Assert.AreEqual(3, _wcfAuthRuleResource.Data.Rights.Count);

            var listOfAuthRules = await wcfAuthRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, listOfAuthRules.Count);

            //Regenerate Keys on the authorization rule
            RelayAccessKeys keys1 = await _wcfAuthRuleResource.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            RelayAccessKeys keys2 = await _wcfAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.PrimaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            RelayAccessKeys keys3 = await _wcfAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }

            var updatePrimaryKey = GenerateRandomKey();
            RelayAccessKeys currentKeys = keys3;

            RelayAccessKeys keys4 = await _wcfAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.PrimaryKey)
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
            RelayAccessKeys keys5 = await _wcfAuthRuleResource.RegenerateKeysAsync(new RelayRegenerateAccessKeyContent(RelayAccessKeyType.SecondaryKey)
            {
                Key = updateSecondaryKey
            });
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(updateSecondaryKey, keys5.SecondaryKey);
                Assert.AreEqual(currentKeys.PrimaryKey, keys5.PrimaryKey);
            }

            await _wcfAuthRuleResource.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _wcfAuthRuleResource.GetAsync(); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await wcfAuthRuleCollection.ExistsAsync("authRule1"));
        }
    }
}
