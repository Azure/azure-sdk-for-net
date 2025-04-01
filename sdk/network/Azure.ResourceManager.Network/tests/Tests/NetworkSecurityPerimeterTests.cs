// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkSecurityPerimeterTests : NetworkServiceClientTestBase
    {
        private string _rgNamePrefix = "rg-nsp-dot-net-sdk-tests";
        private string _nspNamePrefix = "nsp-dot-net-sdk-test";
        private string _profileNamePrefix = "profile-dot-net-sdk-test";
        private string _accessRuleNamePrefix = "access-rule-dot-net-sdk-test";

        private ResourceGroupResource _resourceGroup;
        private SubscriptionResource _subscription;

        public NetworkSecurityPerimeterTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
            _resourceGroup = (await CreateResourceGroup(Recording.GenerateAssetName(_rgNamePrefix)));
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPerimeterTest()
        {
            // Create NSP
            var nspName = Recording.GenerateAssetName(_nspNamePrefix);
            var createNspReqData = new NetworkSecurityPerimeterData(TestEnvironment.Location);
            var createNspResData = (await _resourceGroup.GetNetworkSecurityPerimeters().CreateOrUpdateAsync(WaitUntil.Completed, nspName, createNspReqData)).Value;
            Assert.AreEqual(createNspResData.Data.Name, nspName);
            Assert.AreEqual(createNspResData.Data.Location.Name, TestEnvironment.Location);

            // Get NSP
            NetworkSecurityPerimeterResource nsp = (await _resourceGroup.GetNetworkSecurityPerimeterAsync(nspName)).Value;
            Assert.AreEqual(nsp.Data.Name, nspName);

            // List NSPs
            var nspList = await _resourceGroup.GetNetworkSecurityPerimeters().GetAllAsync().ToEnumerableAsync();
            Assert.That(nspList, Has.Count.EqualTo(1));

            // Delete NSP
            await nsp.DeleteAsync(WaitUntil.Completed);

            // Verify if the NSP deleted
            nspList = await _resourceGroup.GetNetworkSecurityPerimeters().GetAllAsync().ToEnumerableAsync();
            Assert.That(nspList, Has.Count.EqualTo(0));
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPerimeterProfileTest()
        {
            // Create NSP
            var nspName = Recording.GenerateAssetName(_nspNamePrefix);
            var createNspReqData = new NetworkSecurityPerimeterData(TestEnvironment.Location);
            NetworkSecurityPerimeterResource nsp = (await _resourceGroup.GetNetworkSecurityPerimeters().CreateOrUpdateAsync(WaitUntil.Completed, nspName, createNspReqData)).Value;

            // Crete NSP Profile
            var profileName = Recording.GenerateAssetName(_profileNamePrefix);
            var createProfileReqData = new NetworkSecurityPerimeterProfileData(TestEnvironment.Location);
            var createProfileResData = (await nsp.GetNetworkSecurityPerimeterProfiles().CreateOrUpdateAsync(WaitUntil.Completed, profileName, createProfileReqData)).Value;

            Assert.AreEqual(createProfileResData.Data.Name, profileName);

            // Get NSP Profile
            NetworkSecurityPerimeterProfileResource profile = (await nsp.GetNetworkSecurityPerimeterProfileAsync(profileName));

            Assert.AreEqual(profile.Data.Name, profileName);

            // List NSP Profiles
            var nspProfileList = await nsp.GetNetworkSecurityPerimeterProfiles().GetAllAsync().ToEnumerableAsync();
            Assert.That(nspProfileList, Has.Count.EqualTo(1));

            // Delete NSP Profile
            await profile.DeleteAsync(WaitUntil.Completed);

            // Verify if the profile deleted
            nspProfileList = await nsp.GetNetworkSecurityPerimeterProfiles().GetAllAsync().ToEnumerableAsync();
            Assert.That(nspProfileList, Has.Count.EqualTo(0));

            // CLEANUP; Delete NSP
            await nsp.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPrimeterAccessRuleTest()
        {
            // Create NSP
            var nspName = Recording.GenerateAssetName(_nspNamePrefix);
            var createNspReqData = new NetworkSecurityPerimeterData(TestEnvironment.Location);
            NetworkSecurityPerimeterResource nsp = (await _resourceGroup.GetNetworkSecurityPerimeters().CreateOrUpdateAsync(WaitUntil.Completed, nspName, createNspReqData)).Value;

            // Crete NSP Profile
            var profileName = Recording.GenerateAssetName(_profileNamePrefix);
            var createProfileReqData = new NetworkSecurityPerimeterProfileData(TestEnvironment.Location);
            NetworkSecurityPerimeterProfileResource profile = (await nsp.GetNetworkSecurityPerimeterProfiles().CreateOrUpdateAsync(WaitUntil.Completed, profileName, createProfileReqData)).Value;

            // Create Ip Address Access Rule
            var ipRuleName = Recording.GenerateAssetName(_accessRuleNamePrefix);
            var ipRuleReqData = new NetworkSecurityPerimeterAccessRuleData(default)
            {
                Direction = NetworkSecurityPerimeterAccessRuleDirection.Inbound,
                AddressPrefixes = { "10.11.0.0/16", "10.10.1.0/24" },
            };

            var ipRuleResData = (
                await profile
                .GetNetworkSecurityPerimeterAccessRules()
                .CreateOrUpdateAsync(WaitUntil.Completed, ipRuleName, ipRuleReqData)
            ).Value;
            Assert.AreEqual(ipRuleResData.Data.Name, ipRuleName);
            CollectionAssert.AreEqual(ipRuleResData.Data.AddressPrefixes, ipRuleReqData.AddressPrefixes);

            // Create FQDN Access Rule
            var fqdnRuleName = Recording.GenerateAssetName(_accessRuleNamePrefix);
            var fqdnRuleReqData = new NetworkSecurityPerimeterAccessRuleData(default)
            {
                Direction = NetworkSecurityPerimeterAccessRuleDirection.Outbound,
                FullyQualifiedDomainNames = { "www.contoso.com" },
            };

            var fqdnRuleResData = (
                await profile
                .GetNetworkSecurityPerimeterAccessRules()
                .CreateOrUpdateAsync(WaitUntil.Completed, fqdnRuleName, fqdnRuleReqData)
            ).Value;
            Assert.AreEqual(fqdnRuleResData.Data.Name, fqdnRuleName);
            CollectionAssert.AreEqual(fqdnRuleResData.Data.FullyQualifiedDomainNames, fqdnRuleReqData.FullyQualifiedDomainNames);

            // Get AccessRules List
            var rulesList = await profile.GetNetworkSecurityPerimeterAccessRules().GetAllAsync().ToEnumerableAsync();

            Assert.That(rulesList, Has.Count.EqualTo(2));

            // Get IP Address AccessRule
            NetworkSecurityPerimeterAccessRuleResource ipRule = await profile.GetNetworkSecurityPerimeterAccessRuleAsync(ipRuleName);
            Assert.IsNotNull(ipRule);
            Assert.AreEqual(ipRule.Data.Name, ipRuleName);

            // Update IP Address Access Rule
            var ipRulePatchReqData = new NetworkSecurityPerimeterAccessRuleData(default)
            {
                Direction = NetworkSecurityPerimeterAccessRuleDirection.Inbound,
                AddressPrefixes = { "198.168.1.1/32" },
            };
            var ipRulePatchResData = (await ipRule.UpdateAsync(WaitUntil.Completed, ipRulePatchReqData)).Value;
            CollectionAssert.AreEqual(ipRulePatchResData.Data.AddressPrefixes, ipRulePatchReqData.AddressPrefixes);

            // Delete AccessRule
            await ipRule.DeleteAsync(WaitUntil.Completed);

            rulesList = await profile.GetNetworkSecurityPerimeterAccessRules().GetAllAsync().ToEnumerableAsync();
            Assert.That(rulesList, Has.Count.EqualTo(1));

            // CLEANUP: Delete NSP
            await nsp.DeleteAsync(WaitUntil.Completed);
        }
    }
}
