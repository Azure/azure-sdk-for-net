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
            Assert.That(nspName, Is.EqualTo(createNspResData.Data.Name));
            Assert.That(TestEnvironment.Location, Is.EqualTo(createNspResData.Data.Location.Name));

            // Get NSP
            NetworkSecurityPerimeterResource nsp = (await _resourceGroup.GetNetworkSecurityPerimeterAsync(nspName)).Value;
            Assert.That(nspName, Is.EqualTo(nsp.Data.Name));

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

            Assert.That(profileName, Is.EqualTo(createProfileResData.Data.Name));

            // Get NSP Profile
            NetworkSecurityPerimeterProfileResource profile = (await nsp.GetNetworkSecurityPerimeterProfileAsync(profileName));

            Assert.That(profileName, Is.EqualTo(profile.Data.Name));

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
            Assert.That(ipRuleName, Is.EqualTo(ipRuleResData.Data.Name));
            Assert.That(ipRuleReqData.AddressPrefixes, Is.EqualTo(ipRuleResData.Data.AddressPrefixes).AsCollection);

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
            Assert.That(fqdnRuleName, Is.EqualTo(fqdnRuleResData.Data.Name));
            Assert.That(fqdnRuleReqData.FullyQualifiedDomainNames, Is.EqualTo(fqdnRuleResData.Data.FullyQualifiedDomainNames).AsCollection);

            // Get AccessRules List
            var rulesList = await profile.GetNetworkSecurityPerimeterAccessRules().GetAllAsync().ToEnumerableAsync();

            Assert.That(rulesList, Has.Count.EqualTo(2));

            // Get IP Address AccessRule
            NetworkSecurityPerimeterAccessRuleResource ipRule = await profile.GetNetworkSecurityPerimeterAccessRuleAsync(ipRuleName);
            Assert.That(ipRule, Is.Not.Null);
            Assert.That(ipRuleName, Is.EqualTo(ipRule.Data.Name));

            // Update IP Address Access Rule
            var ipRulePatchReqData = new NetworkSecurityPerimeterAccessRuleData()
            {
                Direction = NetworkSecurityPerimeterAccessRuleDirection.Inbound,
                AddressPrefixes = { "198.168.1.1/32" },
            };
            var ipRulePatchResData = (await ipRule.UpdateAsync(WaitUntil.Completed, ipRulePatchReqData)).Value;
            Assert.That(ipRulePatchReqData.AddressPrefixes, Is.EqualTo(ipRulePatchResData.Data.AddressPrefixes).AsCollection);

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
            Assert.That(associationName, Is.EqualTo(createAssociationResData.Data.Name));
            Assert.That(createAssociationReqData.PrivateLinkResourceId, Is.EqualTo(createAssociationResData.Data.PrivateLinkResourceId));
            Assert.That(createAssociationReqData.ProfileId, Is.EqualTo(createAssociationResData.Data.ProfileId));

            // Get
            NetworkSecurityPerimeterAssociationResource association = await nsp.GetNetworkSecurityPerimeterAssociationAsync(associationName);
            Assert.That(associationName, Is.EqualTo(association.Data.Name));
            Assert.That(createAssociationReqData.PrivateLinkResourceId, Is.EqualTo(association.Data.PrivateLinkResourceId));
            Assert.That(createAssociationReqData.ProfileId, Is.EqualTo(association.Data.ProfileId));

            // Update Association
            var partchAssociationReqData = new NetworkSecurityPerimeterAssociationData()
            {
                ProfileId = profile.Id,
                PrivateLinkResourceId = storageAccountId,
                AccessMode = NetworkSecurityPerimeterAssociationAccessMode.Enforced,
            };
            await association.UpdateAsync(WaitUntil.Completed, partchAssociationReqData);

            association = await nsp.GetNetworkSecurityPerimeterAssociationAsync(associationName);
            Assert.That(partchAssociationReqData.AccessMode, Is.EqualTo(association.Data.AccessMode));

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

            Assert.That(linkName, Is.EqualTo(createLinkResData.Data.Name));
            Assert.That(remoteNsp.Data.Id.ToString(), Is.EqualTo(createLinkResData.Data.AutoApprovedRemotePerimeterResourceId));

            //List Link & Link references
            var linksList = await nsp.GetNetworkSecurityPerimeterLinks().GetAllAsync().ToEnumerableAsync();

            Assert.That(linksList,Has.Count.EqualTo(1));

            var linkReferencesList = await remoteNsp.GetNetworkSecurityPerimeterLinkReferences().GetAllAsync().ToEnumerableAsync();
            Assert.That(linkReferencesList, Has.Count.EqualTo(1));

            // Get Link
            var link = (await nsp.GetNetworkSecurityPerimeterLinkAsync(linkName)).Value;
            Assert.That(linkName, Is.EqualTo(link.Data.Name));
            Assert.That(remoteNsp.Data.Id.ToString(), Is.EqualTo(link.Data.AutoApprovedRemotePerimeterResourceId));

            // Delete Link
            await link.DeleteAsync(WaitUntil.Completed);

            //List Link
            linksList = await nsp.GetNetworkSecurityPerimeterLinks().GetAllAsync().ToEnumerableAsync();
            Assert.That(linksList, Has.Count.EqualTo(0));

            // Get Link Ref
            var linkRefName = "Ref-from-" + linkName + "-" + nsp.Data.PerimeterGuid;
            var linkRef = (await remoteNsp.GetNetworkSecurityPerimeterLinkReferenceAsync(linkRefName)).Value;
            Assert.That(NetworkSecurityPerimeterLinkStatus.Disconnected, Is.EqualTo(linkRef.Data.Status));

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
            Assert.That(logConfigName, Is.EqualTo(createLogConfigResData.Data.Name));
            Assert.That(createLogConfigReqData.EnabledLogCategories, Is.EqualTo(createLogConfigResData.Data.EnabledLogCategories).AsCollection);

            // Ge Logging configuration
            NetworkSecurityPerimeterLoggingConfigurationResource logConfig = await nsp.GetNetworkSecurityPerimeterLoggingConfigurationAsync(logConfigName);
            Assert.That(createLogConfigReqData.EnabledLogCategories, Is.EqualTo(logConfig.Data.EnabledLogCategories).AsCollection);

            await logConfig.DeleteAsync(WaitUntil.Completed);

            Assert.ThrowsAsync<RequestFailedException>(() => nsp.GetNetworkSecurityPerimeterLoggingConfigurationAsync(logConfigName));
        }
    }
}
