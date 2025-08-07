// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchManagementTestBase : ManagementRecordedTestBase<BatchManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected ResourceIdentifier StorageAccountIdentifier { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;

        private ResourceIdentifier _resourceGroupIdentifier;

        protected BatchManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected BatchManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
            ResourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
        }

        [OneTimeSetUp]
        public async Task CommonGlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName("testrg-batch");
            var storageAccountName = SessionRecording.GenerateAssetName("azstorageforbatch");
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName);
                StorageAccountIdentifier = StorageAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, storageAccountName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.EastUS));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    StorageAccountIdentifier = storage.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        private async Task<StorageAccountResource> CreateStorageAccount(ResourceGroupResource rg, string storageAccountName)
        {
            var storageInput = ResourceDataHelper.GetStorageAccountData();
            var lro = await rg.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, storageInput);
            return lro.Value;
        }

        protected async Task<BatchAccountResource> CreateBatchAccount(ResourceGroupResource rg, string batchAccountName, ResourceIdentifier storageAccountId)
        {
            var input = ResourceDataHelper.GetBatchAccountData(storageAccountId);
            var lro = await rg.GetBatchAccounts().CreateOrUpdateAsync(WaitUntil.Completed, batchAccountName, input);
            return lro.Value;
        }

        protected async Task<BatchAccountPoolResource> CreateBatchAccountPool(BatchAccountResource batchAccount, string poolName)
        {
            var input = ResourceDataHelper.GetBatchAccountPoolData();
            var lro = await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolName, input);
            return lro.Value;
        }

        protected async Task<BatchApplicationResource> CreateBatchApplication(BatchAccountResource batchAccount, string applicationName)
        {
            var input = ResourceDataHelper.GetBatchApplicationData();
            var lro = await batchAccount.GetBatchApplications().CreateOrUpdateAsync(WaitUntil.Completed, applicationName, input);
            return lro.Value;
        }

        protected async Task<BatchApplicationPackageResource> CreateBatchApplicationPackage(BatchApplicationResource batchApplication, string applicationPackageName)
        {
            var input = ResourceDataHelper.GetBatchApplicationPackageData();
            var lro = await batchApplication.GetBatchApplicationPackages().CreateOrUpdateAsync(WaitUntil.Completed, applicationPackageName, input);
            return lro.Value;
        }
    }
}
