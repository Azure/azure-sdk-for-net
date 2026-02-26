// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.ArtifactSigning.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ArtifactSigning.Tests
{
    public class ArtifactSigningManagementTestBase : ManagementRecordedTestBase<ArtifactSigningManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected ArtifactSigningManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ArtifactSigningManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }

        protected async Task<ArtifactSigningAccountCollection> GetArtifactSigningAccounts()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetArtifactSigningAccounts();
        }

        protected async Task<ArtifactSigningAccountResource> CreateArtifactSigningAccount(ArtifactSigningAccountCollection accountCollection, string accountName)
        {
            ArtifactSigningAccountData data = new ArtifactSigningAccountData(DefaultLocation)
            {
                SkuName = ArtifactSigningSkuName.Basic,
            };
            ArmOperation<ArtifactSigningAccountResource> lro = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);
            return lro.Value;
        }

        protected async Task<ArtifactSigningCertificateProfileResource> CreateCertificateProfile(ArtifactSigningCertificateProfileCollection certProfileCollection, string profileName)
        {
            // invoke the operation
            ArtifactSigningCertificateProfileData data = new ArtifactSigningCertificateProfileData()
            {
                ProfileType = CertificateProfileType.PublicTrust,
                IncludeStreetAddress = false,
                IncludePostalCode = true,
                IdentityValidationId = "00000000-1234-5678-3333-444444444444",
            };
            ArmOperation<ArtifactSigningCertificateProfileResource> lro = await certProfileCollection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            return lro.Value;
        }
    }
}
