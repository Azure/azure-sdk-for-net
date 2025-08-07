// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.TrustedSigning.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TrustedSigning.Tests
{
    public class TrustedSigningManagementTestBase : ManagementRecordedTestBase<TrustedSigningManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected TrustedSigningManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected TrustedSigningManagementTestBase(bool isAsync)
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

        protected async Task<TrustedSigningAccountCollection> GetTrustedSigningAccounts()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetTrustedSigningAccounts();
        }

        protected async Task<TrustedSigningAccountResource> CreateTrustedSigningAccount(TrustedSigningAccountCollection accountCollection, string accountName)
        {
            TrustedSigningAccountData data = new TrustedSigningAccountData(DefaultLocation)
            {
                SkuName = TrustedSigningSkuName.Basic,
            };
            ArmOperation<TrustedSigningAccountResource> lro = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);
            return lro.Value;
        }

        protected async Task<TrustedSigningCertificateProfileResource> CreateCertificateProfile(TrustedSigningCertificateProfileCollection certProfileCollection, string profileName)
        {
            // invoke the operation
            TrustedSigningCertificateProfileData data = new TrustedSigningCertificateProfileData()
            {
                ProfileType = CertificateProfileType.PublicTrust,
                IncludeStreetAddress = false,
                IncludePostalCode = true,
                IdentityValidationId = "00000000-1234-5678-3333-444444444444",
            };
            ArmOperation<TrustedSigningCertificateProfileResource> lro = await certProfileCollection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, data);
            return lro.Value;
        }
    }
}
