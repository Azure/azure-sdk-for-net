// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class NetworkSecurityPerimeterTests : NetworkServiceClientTestBase
    {
        private string _rgNamePrefix = "rg-nsp-dot-net-sdk-test-";
        private string _nspNamePrefix = "nsp-dot-net-sdk-test-";
        private string _profileNamePrefix = "profile-dot-net-sdk-test-";
        private string _associationNamePrefix = "association-dot-net-sdk-test-";
        private string _accessRuleNamePrefix = "access-rule-dot-net-sdk-test-";
        private string _linkNamePrefix = "link-dot-net-sdk-test-";
        private string _saNamePrefix = "sadotnetsdktest";

        private ResourceGroupResource _resourceGroup;

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
            _resourceGroup = (await CreateResourceGroup(Recording.GenerateAssetName(_rgNamePrefix)));
        }

        private async Task<NetworkSecurityPerimeterResource> CreateRandomNsp()
        {
            var nspName = Recording.GenerateAssetName(_nspNamePrefix);
            var createNspReqData = new NetworkSecurityPerimeterData(TestEnvironment.Location);
            return  (await _resourceGroup.GetNetworkSecurityPerimeters().CreateOrUpdateAsync(WaitUntil.Completed, nspName, createNspReqData)).Value;
        }

        private async Task<NetworkSecurityPerimeterProfileResource> CreateRandomProfile(NetworkSecurityPerimeterResource nsp)
        {
            var profileName = Recording.GenerateAssetName(_nspNamePrefix);
            var createProfileReqData = new NetworkSecurityPerimeterProfileData();
            return (await nsp.GetNetworkSecurityPerimeterProfiles().CreateOrUpdateAsync(WaitUntil.Completed, profileName, createProfileReqData)).Value;
        }

        private async Task<StorageAccountResource> CreateRandomStorageAccount()
        {
            var storageAccountName = Recording.GenerateAssetName(_saNamePrefix);
            var createStorageAccountReqData = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.Storage, TestEnvironment.Location);
            return (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, createStorageAccountReqData)).Value;
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
            var createProfileReqData = new NetworkSecurityPerimeterProfileData();
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
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPrimeterAccessRuleTest()
        {
            // Create NSP, Profile
            NetworkSecurityPerimeterResource nsp = await CreateRandomNsp();
            NetworkSecurityPerimeterProfileResource profile = await CreateRandomProfile(nsp);

            // Create Ip Address Access Rule
            var ipRuleName = Recording.GenerateAssetName(_accessRuleNamePrefix);
            var ipRuleReqData = new NetworkSecurityPerimeterAccessRuleData()
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
            var fqdnRuleReqData = new NetworkSecurityPerimeterAccessRuleData()
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
            var ipRulePatchReqData = new NetworkSecurityPerimeterAccessRuleData()
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
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPerimeterAssociationTest()
        {
            // Create NSP, Profile
            NetworkSecurityPerimeterResource nsp = await CreateRandomNsp();
            NetworkSecurityPerimeterProfileResource profile = await CreateRandomProfile(nsp);
            var associationName = Recording.GenerateAssetName(_associationNamePrefix);

            var storageAccount = await CreateRandomStorageAccount();
            ResourceIdentifier storageAccountId = storageAccount.Id;

            // Create Association
            var createAssociationReqData = new NetworkSecurityPerimeterAssociationData()
            {
                ProfileId = profile.Id,
                PrivateLinkResourceId = storageAccountId
            };

            var createAssociationResData = (await nsp.GetNetworkSecurityPerimeterAssociations().CreateOrUpdateAsync(WaitUntil.Completed, associationName, createAssociationReqData)).Value;
            Assert.AreEqual(createAssociationResData.Data.Name, associationName);
            Assert.AreEqual(createAssociationResData.Data.PrivateLinkResourceId, createAssociationReqData.PrivateLinkResourceId);
            Assert.AreEqual(createAssociationResData.Data.ProfileId, createAssociationReqData.ProfileId);

            // Get
            NetworkSecurityPerimeterAssociationResource association = await nsp.GetNetworkSecurityPerimeterAssociationAsync(associationName);
            Assert.AreEqual(association.Data.Name, associationName);
            Assert.AreEqual(association.Data.PrivateLinkResourceId, createAssociationReqData.PrivateLinkResourceId);
            Assert.AreEqual(association.Data.ProfileId, createAssociationReqData.ProfileId);

            // Update Association
            var partchAssociationReqData = new NetworkSecurityPerimeterAssociationData()
            {
                ProfileId = profile.Id,
                PrivateLinkResourceId = storageAccountId,
                AccessMode = NetworkSecurityPerimeterAssociationAccessMode.Enforced,
            };
            await association.UpdateAsync(WaitUntil.Completed, partchAssociationReqData);

            association = await nsp.GetNetworkSecurityPerimeterAssociationAsync(associationName);
            Assert.AreEqual(association.Data.AccessMode, partchAssociationReqData.AccessMode);

            // List Associations
            var associationsList = await nsp.GetNetworkSecurityPerimeterAssociations().GetAllAsync().ToEnumerableAsync();
            Assert.That(associationsList, Has.Count.EqualTo(1));

            // Delete Association
            await association.DeleteAsync(WaitUntil.Completed);

            associationsList =  await nsp.GetNetworkSecurityPerimeterAssociations().GetAllAsync().ToEnumerableAsync();
            Assert.That(associationsList, Has.Count.EqualTo(0));
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPerimeterLinkTest()
        {
            // Create NSPs
            NetworkSecurityPerimeterResource nsp = await CreateRandomNsp();
            NetworkSecurityPerimeterResource remoteNsp = await CreateRandomNsp();

            // Create Link
            var linkName = Recording.GenerateAssetName(_linkNamePrefix);
            var createLinkReqData = new NetworkSecurityPerimeterLinkData
            {
                AutoApprovedRemotePerimeterResourceId = remoteNsp.Data.Id,
                LocalInboundProfiles = { "*" },
                RemoteInboundProfiles = { "*" },
            };

            var createLinkResData = (await nsp.GetNetworkSecurityPerimeterLinks().CreateOrUpdateAsync(WaitUntil.Completed, linkName, createLinkReqData)).Value;

            Assert.AreEqual(createLinkResData.Data.Name, linkName);
            Assert.AreEqual(createLinkResData.Data.AutoApprovedRemotePerimeterResourceId, remoteNsp.Data.Id.ToString());

            //List Link & Link references
            var linksList = await nsp.GetNetworkSecurityPerimeterLinks().GetAllAsync().ToEnumerableAsync();

            Assert.That(linksList,Has.Count.EqualTo(1));

            var linkReferencesList = await remoteNsp.GetNetworkSecurityPerimeterLinkReferences().GetAllAsync().ToEnumerableAsync();
            Assert.That(linkReferencesList, Has.Count.EqualTo(1));

            // Get Link
            var link = (await nsp.GetNetworkSecurityPerimeterLinkAsync(linkName)).Value;
            Assert.AreEqual(link.Data.Name, linkName);
            Assert.AreEqual(link.Data.AutoApprovedRemotePerimeterResourceId, remoteNsp.Data.Id.ToString());

            // Delete Link
            await link.DeleteAsync(WaitUntil.Completed);

            //List Link
            linksList = await nsp.GetNetworkSecurityPerimeterLinks().GetAllAsync().ToEnumerableAsync();
            Assert.That(linksList, Has.Count.EqualTo(0));

            // Get Link Ref
            var linkRefName = "Ref-from-" + linkName + "-" + nsp.Data.PerimeterGuid;
            var linkRef = (await remoteNsp.GetNetworkSecurityPerimeterLinkReferenceAsync(linkRefName)).Value;
            Assert.AreEqual(linkRef.Data.Status, NetworkSecurityPerimeterLinkStatus.Disconnected);

            // Delete Link Ref
            await linkRef.DeleteAsync(WaitUntil.Completed);

            // List Link references
            linkReferencesList = await remoteNsp.GetNetworkSecurityPerimeterLinkReferences().GetAllAsync().ToEnumerableAsync();
            Assert.That(linkReferencesList, Has.Count.EqualTo(0));
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityPerimeterLoggingConfigurationTest()
        {
            // Create NSP
            NetworkSecurityPerimeterResource nsp = await CreateRandomNsp();

            //Create Logging configuration
            var logConfigName = "instance";
            var createLogConfigReqData = new NetworkSecurityPerimeterLoggingConfigurationData()
            {
                EnabledLogCategories = { "NspPublicInboundPerimeterRulesDenied", "NspPublicOutboundPerimeterRulesDenied" },
            };
            var createLogConfigResData = (await nsp.GetNetworkSecurityPerimeterLoggingConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, logConfigName, createLogConfigReqData)).Value;
            Assert.AreEqual(createLogConfigResData.Data.Name, logConfigName);
            CollectionAssert.AreEqual(createLogConfigResData.Data.EnabledLogCategories, createLogConfigReqData.EnabledLogCategories);

            // Ge Logging configuration
            NetworkSecurityPerimeterLoggingConfigurationResource logConfig = await nsp.GetNetworkSecurityPerimeterLoggingConfigurationAsync(logConfigName);
            CollectionAssert.AreEqual(logConfig.Data.EnabledLogCategories, createLogConfigReqData.EnabledLogCategories);

            await logConfig.DeleteAsync(WaitUntil.Completed);

            Assert.ThrowsAsync<RequestFailedException>(() => nsp.GetNetworkSecurityPerimeterLoggingConfigurationAsync(logConfigName));
        }
    }
}
