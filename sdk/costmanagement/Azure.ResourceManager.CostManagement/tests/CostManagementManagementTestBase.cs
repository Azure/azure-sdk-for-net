// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CostManagement.Tests
{
    public class CostManagementManagementTestBase : ManagementRecordedTestBase<CostManagementManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected ResourceIdentifier DefaultScope => DefaultSubscription.Id;
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected const string ResourceGroupPrefixName = "CostManagementRG";

        protected CostManagementManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected CostManagementManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupPrefixName);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task CreateStorageAccount(ResourceGroupResource resourceGroup, string storageAccountName)
        {
            if (Mode == RecordedTestMode.Record)
            {
                using (Recording.DisableRecording())
                {
                    StorageSku sku = new StorageSku(StorageSkuName.StandardGrs);
                    StorageKind kind = StorageKind.Storage;
                    StorageAccountCreateOrUpdateContent storagedata = new StorageAccountCreateOrUpdateContent(sku, kind, DefaultLocation)
                    {
                        //AccessTier = StorageAccountAccessTier.Hot,
                    };
                    var storage = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, storagedata);
                }
            }
        }
    }
}
