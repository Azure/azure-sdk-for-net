// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageSync.Models;
using Azure.ResourceManager.StorageSync.Tests.CustomPolicy;
using Azure.ResourceManager.TestFramework;
using Castle.DynamicProxy;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading.Tasks;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public class StorageSyncManagementTestBase : ManagementRecordedTestBase<StorageSyncManagementTestEnvironment>
    {
        public static RecordedTestMode ModeFromSourceCode => RecordedTestMode.Playback;
        public static bool IsTestTenant = false;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public static string DefaultLocation = IsTestTenant ? null : "eastus2";
        public StorageSyncResponseNullFilterPolicy StorageSyncNullFilterPolicy = new StorageSyncResponseNullFilterPolicy();

        protected static string DefaultStorageSyncServiceRecordingName = "afs-sdk-sss-create";
        protected static string DefaultStorageSyncGroupRecordingName = "afs-sdk-sg-create";
        protected static string DefaultCloudEndpointRecordingName = "afs-sdk-cep-create";
        protected static string DefaultServerEndpointRecordingName = "afs-sdk-sep-create";
        protected static AzureEventSourceListener identityListener;
        protected static StreamWriter streamWriter;
        protected StorageSyncManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            streamWriter = new StreamWriter(new FileStream($"Test-{Guid.NewGuid()}.log", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                AutoFlush = true
            };
            identityListener = new AzureEventSourceListener((args, message) =>
            {
                try
                {
                    streamWriter.WriteLine(message);
                }
                catch { }
            }, EventLevel.LogAlways);
        }

        protected StorageSyncManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetCustomArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected ArmClient GetCustomArmClient(ArmClientOptions clientOptions = default, string subscriptionId = default)
        {
            var options = InstrumentClientOptions(clientOptions ?? new ArmClientOptions());
            options.Environment = ArmEnvironment.AzurePublicCloud;
            options.AddPolicy(ResourceGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(ManagementGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(StorageSyncNullFilterPolicy, HttpPipelinePosition.PerRetry);
            //if (ApiVersion is not null)
            //    options.SetApiVersion(_resourceType, ApiVersion);

            return InstrumentClient(new ArmClient(
                TestEnvironment.Credential,
                subscriptionId ?? TestEnvironment.SubscriptionId,
                options), new IInterceptor[] { new ManagementInterceptor(this) });
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("afs-sdk-rg");
            ArmOperation<ResourceGroupResource> operation = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return operation.Value;
        }

        public async Task<StorageSyncServiceResource> CreateSyncServiceAsync(ResourceGroupResource resourceGroup)
        {
            string storageSyncServiceName = Recording.GenerateAssetName(DefaultStorageSyncServiceRecordingName);
            StorageSyncServiceCreateOrUpdateContent storageSyncServiceCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

            return (await resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, storageSyncServiceName, storageSyncServiceCreateOrUpdateContent)).Value;
        }

        public async Task<StorageSyncGroupResource> CreateSyncGroupAsync(StorageSyncServiceResource storageSyncServiceResource)
        {
            string storageSynGroupName = Recording.GenerateAssetName(DefaultStorageSyncGroupRecordingName);
            StorageSyncGroupCreateOrUpdateContent storageSyncGroupCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();

            return (await storageSyncServiceResource.GetStorageSyncGroups().CreateOrUpdateAsync(WaitUntil.Completed, storageSynGroupName, storageSyncGroupCreateOrUpdateContent)).Value;
        }

        public async Task<CloudEndpointResource> CreateCloudEndpointAsync(StorageSyncGroupResource storageSyncGroupResource)
        {
            string cloudEndpointName = Recording.GenerateAssetName(DefaultCloudEndpointRecordingName);
            CloudEndpointCreateOrUpdateContent cloudEndpointCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

            return (await storageSyncGroupResource.GetCloudEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, cloudEndpointName, cloudEndpointCreateOrUpdateContent)).Value;
        }
    }
}
