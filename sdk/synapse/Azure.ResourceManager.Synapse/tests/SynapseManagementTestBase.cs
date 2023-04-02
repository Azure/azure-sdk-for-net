// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Synapse.Models;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Synapse.Tests
{
    public class SynapseManagementTestBase : ManagementRecordedTestBase<SynapseManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected CommonTestFixture CommonData { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected SynapseWorkspaceResource WorkspaceResource { get; private set; }

        protected SynapseManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SynapseManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task TestInitialize()
        {
            CommonData = InitializeCommonTestFixture();

            // create resource group
            ResourceGroup = await CreateResourceGroup(CommonData.ResourceGroupName, CommonData.Location);

            // create data lake storage
            CommonData.StorageAccountKey = await CreateStorageAccount(CommonData.ResourceGroupName, CommonData.StorageAccountName, CommonData.Location);
        }

        protected async Task CreateWorkspace()
        {
            // create workspace
            WorkspaceResource = await CreateWorkspaceResource();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string resourceGroupName, AzureLocation location)
        {
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(location));
            return operation.Value;
        }

        protected async Task<string> CreateStorageAccount(string resourceGroupName, string storageAccountName, AzureLocation location)
        {
            var parameters = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardGrs), StorageKind.StorageV2, location);
            StorageAccountCollection storageAccountCollection = ResourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, parameters)).Value;

            // Retrieve the storage account primary access key
            var accessKey = (await account.GetKeysAsync().ToEnumerableAsync()).First().Value;

            ThrowIfTrue(
                string.IsNullOrEmpty(accessKey),
                "storageAccountResource.GetKeys returned null."
            );

            // Set the storage account url
            CommonData.DefaultDataLakeStorageAccountUrl = account.Data.PrimaryEndpoints.DfsUri;

            return accessKey;
        }

        /// <summary>
        /// create Synapse workspace Resource
        /// </summary>
        /// <returns></returns>
        protected async Task<SynapseWorkspaceResource> CreateWorkspaceResource()
        {
            string workspaceName = Recording.GenerateAssetName("synapsesdkworkspace");
            var createWorkspaceParams = CommonData.PrepareWorkspaceCreateParams();
            SynapseWorkspaceCollection workspaceCollection = ResourceGroup.GetSynapseWorkspaces();
            var workspace = (await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, createWorkspaceParams)).Value;
            return workspace;
        }

        /// <summary>
        /// Throw expception if the given condition is satisfied
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        protected void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

        private CommonTestFixture InitializeCommonTestFixture()
        {
            return new CommonTestFixture()
            {
                Location = AzureLocation.EastUS2,
                LocationString = "eastus2",
                ResourceGroupName = Recording.GenerateAssetName("synapsesdkrp"),
                StorageAccountName = Recording.GenerateAssetName("synapsesdkstorage"),
                SshUsername = Recording.GenerateAssetName("sshuser"),
                SshPassword = Recording.GenerateAssetName("Password1!"),
                DefaultDataLakeStorageFilesystem = Recording.GenerateAssetName("synapsesdkfilesys"),
                PerformanceLevel = "DW200c",
                NodeCount = 3,
                NodeSize = "Small",
                SparkVersion = "2.4",
                AutoScaleMinNodeCount = 3,
                AutoScaleMaxNodeCount = 6,
                AutoPauseDelayInMinute = 15,
                StartIpAddress = IPAddress.Parse("0.0.0.0"),
                EndIpAddress = IPAddress.Parse("255.255.255.255"),
                UpdatedStartIpAddress = IPAddress.Parse("10.0.0.0"),
                UpdatedEndIpAddress = IPAddress.Parse("255.0.0.0"),
                KustoSku = new SynapseDataSourceSku(SynapseSkuName.StorageOptimized, KustoPoolSkuSize.Medium),
                UpdatedKustoSku = new SynapseDataSourceSku(SynapseSkuName.StorageOptimized, KustoPoolSkuSize.Large),
                SoftDeletePeriod = TimeSpan.FromDays(4),
                HotCachePeriod = TimeSpan.FromDays(2),
                UpdatedSoftDeletePeriod = TimeSpan.FromDays(6),
                UpdatedHotCachePeriod = TimeSpan.FromDays(3)
            };
        }
    }
}
