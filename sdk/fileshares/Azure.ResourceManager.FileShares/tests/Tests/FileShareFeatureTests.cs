// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    /// <summary>
    /// Covers the features added in API version 2026-09-01: managed identity, encryption, offer-specific
    /// limits and recommendations (media tier and scale mode), and redundancy conversion.
    /// </summary>
    public class FileShareFeatureTests : FileSharesManagementTestBase
    {
        public FileShareFeatureTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task SystemAssignedIdentity()
        {
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var data = CreateFileShareData();
            data.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);

            var fileShare = (await resourceGroup.GetFileShares().CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, data)).Value;
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, fileShare.Data.Identity.ManagedServiceIdentityType);
            Assert.IsNotNull(fileShare.Data.Identity.PrincipalId);
            Assert.IsNotNull(fileShare.Data.Identity.TenantId);

            var patch = new FileSharePatch
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None),
            };
            var updated = (await fileShare.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.IsTrue(updated.Data.Identity == null || updated.Data.Identity.ManagedServiceIdentityType == ManagedServiceIdentityType.None);

            await updated.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task InfrastructureEncryption()
        {
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var data = CreateFileShareData();
            data.Properties.Encryption = new FileShareEncryption
            {
                InfrastructureEncryption = FileShareInfrastructureEncryption.Enabled,
            };

            var fileShare = (await resourceGroup.GetFileShares().CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, data)).Value;
            Assert.AreEqual(FileShareInfrastructureEncryption.Enabled, fileShare.Data.Properties.Encryption.InfrastructureEncryption);

            // Infrastructure encryption is set at creation and preserved by later updates.
            var patch = new FileSharePatch
            {
                Properties = new FileSharePatchProperties { ProvisionedStorageInGiB = 2048 },
            };
            var updated = (await fileShare.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(2048, updated.Data.Properties.ProvisionedStorageInGiB);
            Assert.AreEqual(FileShareInfrastructureEncryption.Enabled, updated.Data.Properties.Encryption.InfrastructureEncryption);

            await updated.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task HddOfferLimitsAndRecommendation()
        {
            var location = new AzureLocation(DefaultLocation);

            var ssdLimits = (await DefaultSubscription.GetLimitsAsync(location)).Value.Properties.Limits;
            var hddLimits = (await DefaultSubscription.GetLimitsAsync(location, new FileShareLimitsContent(HddOffer()))).Value.Properties.Limits;
            Assert.Greater(hddLimits.MaxProvisionedStorageGiB, 0);
            // HDD has its own, lower performance limits than the default SSD offer.
            Assert.Less(hddLimits.MinProvisionedIOPerSec, ssdLimits.MinProvisionedIOPerSec);
            Assert.Less(hddLimits.MaxProvisionedIOPerSec, ssdLimits.MaxProvisionedIOPerSec);

            var ssdRecommendation = (await DefaultSubscription.GetProvisioningRecommendationAsync(
                location,
                new FileShareProvisioningRecommendationContent(new FileShareProvisioningRecommendationInputProperties(1024)))).Value.Properties;
            var hddRecommendation = (await DefaultSubscription.GetProvisioningRecommendationAsync(
                location,
                new FileShareProvisioningRecommendationContent(new FileShareProvisioningRecommendationInputProperties(1024)
                {
                    Protocol = FileShareProtocol.Nfs,
                    MediaTier = FileShareMediaTier.Hdd,
                }))).Value.Properties;
            Assert.Greater(hddRecommendation.ProvisionedIOPerSec, 0);
            Assert.Less(hddRecommendation.ProvisionedIOPerSec, ssdRecommendation.ProvisionedIOPerSec);
        }

        [TestCase]
        [RecordedTest]
        public void ScaleModeNotSupportedOnHdd()
        {
            // Scale mode is served on SSD only, so the service rejects an HDD offer with the Scale mode.
            const string expected = "The requested media tier and scale mode are not a supported combination.";
            var location = new AzureLocation(DefaultLocation);
            var offer = HddOffer();
            offer.ScaleMode = FileShareScaleMode.Scale;

            var limitsError = Assert.ThrowsAsync<RequestFailedException>(
                async () => await DefaultSubscription.GetLimitsAsync(location, new FileShareLimitsContent(offer)));
            StringAssert.Contains(expected, limitsError.Message);

            var recommendationError = Assert.ThrowsAsync<RequestFailedException>(
                async () => await DefaultSubscription.GetProvisioningRecommendationAsync(
                    location,
                    new FileShareProvisioningRecommendationContent(new FileShareProvisioningRecommendationInputProperties(1024)
                    {
                        Protocol = FileShareProtocol.Nfs,
                        MediaTier = FileShareMediaTier.Hdd,
                        ScaleMode = FileShareScaleMode.Scale,
                    })));
            StringAssert.Contains(expected, recommendationError.Message);
        }

        [TestCase]
        [RecordedTest]
        public async Task RedundancyConversionRequiresPrivateEndpoint()
        {
            // Redundancy conversion is only allowed on shares reachable exclusively through a private endpoint.
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);
            Assert.AreNotEqual(true, fileShare.Data.Properties.IsRedundancyConversionInProgress);

            var error = Assert.ThrowsAsync<RequestFailedException>(
                async () => await fileShare.StartRedundancyConversionAsync(new FileShareRedundancyConversionContent(FileShareRedundancyLevel.Zone)));
            StringAssert.Contains("only supported when the account is secured exclusively via a private endpoint", error.Message);

            await fileShare.DeleteAsync(WaitUntil.Completed);
        }

        private static FileShareOfferInput HddOffer() => new FileShareOfferInput
        {
            Protocol = FileShareProtocol.Nfs,
            MediaTier = FileShareMediaTier.Hdd,
        };

        private static FileShareData CreateFileShareData() => new FileShareData(new AzureLocation(DefaultLocation))
        {
            Properties = new FileShareProperties
            {
                MediaTier = FileShareMediaTier.Ssd,
                Protocol = FileShareProtocol.Nfs,
                ProvisionedStorageInGiB = 1024,
                ProvisionedIOPerSec = 4024,
                ProvisionedThroughputMiBPerSec = 228,
                Redundancy = FileShareRedundancyLevel.Local,
                PublicNetworkAccess = FileSharePublicNetworkAccess.Enabled,
                NfsProtocolProperties = new NfsProtocolProperties { RootSquash = ShareRootSquash.NoRootSquash },
            },
            Tags = { { "environment", "test" }, { "createdBy", "sdk-test" } },
        };
    }
}
