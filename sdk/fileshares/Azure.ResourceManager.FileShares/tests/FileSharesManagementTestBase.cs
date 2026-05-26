// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    public class FileSharesManagementTestBase : ManagementRecordedTestBase<FileSharesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected const string DefaultLocation = "eastus2euap";

        protected FileSharesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected FileSharesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        private const string CanaryArmEndpoint = "https://eastus2euap.management.azure.com";

        [SetUp]
        public async Task CreateCommonClient()
        {
            // Ensure the canary ARM endpoint is used when RESOURCE_MANAGER_URL is not already set.
            // This must be set before GetArmClient() because the base class reads this env var
            // to configure the ArmEnvironment (ResourceManagerUrl is not virtual on TestEnvironment).
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RESOURCE_MANAGER_URL")))
            {
                Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", CanaryArmEndpoint);
            }

            // The canary endpoint requires standard management audience for auth.
            // Without this, GetArmEnvironment() falls back to "{canaryUrl}/.default" which is not
            // a valid resource principal in AAD.
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SERVICE_MANAGEMENT_URL")))
            {
                Environment.SetEnvironmentVariable("SERVICE_MANAGEMENT_URL", "https://management.azure.com");
            }

            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string rgNamePrefix)
        {
            return await CreateResourceGroup(DefaultSubscription, rgNamePrefix, new AzureLocation(DefaultLocation));
        }

        protected async Task<FileShareResource> CreateFileShare(
            ResourceGroupResource resourceGroup,
            string fileShareName,
            FileShareMediaTier? mediaTier = null,
            FileShareProtocol? protocol = null,
            int provisionedStorageGiB = 1024,
            int provisionedIOPerSec = 4024,
            int provisionedThroughputMiBPerSec = 228,
            FileShareRedundancyLevel? redundancy = null,
            FileSharePublicNetworkAccess? publicNetworkAccess = null)
        {
            var effectiveMediaTier = mediaTier ?? FileShareMediaTier.Ssd;
            var effectiveProtocol = protocol ?? FileShareProtocol.Nfs;
            var effectiveRedundancy = redundancy ?? FileShareRedundancyLevel.Local;
            var effectivePublicNetworkAccess = publicNetworkAccess ?? FileSharePublicNetworkAccess.Enabled;

            var data = new FileShareData(new AzureLocation(DefaultLocation))
            {
                Properties = new FileShareProperties
                {
                    MediaTier = effectiveMediaTier,
                    Protocol = effectiveProtocol,
                    ProvisionedStorageInGiB = provisionedStorageGiB,
                    ProvisionedIOPerSec = provisionedIOPerSec,
                    ProvisionedThroughputMiBPerSec = provisionedThroughputMiBPerSec,
                    Redundancy = effectiveRedundancy,
                    PublicNetworkAccess = effectivePublicNetworkAccess,
                    NfsProtocolProperties = effectiveProtocol == FileShareProtocol.Nfs
                        ? new NfsProtocolProperties { RootSquash = ShareRootSquash.NoRootSquash }
                        : null,
                },
                Tags = { { "environment", "test" }, { "createdBy", "sdk-test" } },
            };

            var collection = resourceGroup.GetFileShares();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, data);
            return lro.Value;
        }

        protected async Task<FileShareSnapshotResource> CreateSnapshot(
            FileShareResource fileShare,
            string snapshotName)
        {
            var data = new FileShareSnapshotData
            {
                Properties = new FileShareSnapshotProperties
                {
                    Metadata = { { "purpose", "testing" }, { "environment", "test" } },
                },
            };

            var collection = fileShare.GetFileShareSnapshots();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, snapshotName, data);
            return lro.Value;
        }
    }
}
