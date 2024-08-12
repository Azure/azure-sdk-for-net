// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Hci.Tests
{
    public class HciManagementTestBase : ManagementRecordedTestBase<HciManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected string CustomLocationId { get; private set; }

        protected AzureLocation Location { get; private set; }

        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected HciManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HciManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            var rgPrefix = "hci-dotnet-test-rg-";
            Location = AzureLocation.EastUS;
            ResourceGroup = await CreateResourceGroupAsync(Subscription, rgPrefix, Location);
            CustomLocationId = TestEnvironment.CustomLocationId;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<HciClusterResource> CreateHciClusterAsync(ResourceGroupResource resourceGroup, string clusterName, AzureLocation? location = null)
        {
            var clusterData = new HciClusterData(location == null ? resourceGroup.Data.Location : location.Value)
            {
                AadClientId = new Guid(TestEnvironment.ClientId),
                AadTenantId = new Guid(TestEnvironment.TenantId),
                TypeIdentityType = HciManagedServiceIdentityType.None
            };
            var lro = await resourceGroup.GetHciClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            return lro.Value;
        }

        protected async Task<ArcSettingResource> CreateArcSettingAsync(HciClusterResource cluster, string arcSettingName)
        {
            var arcSettingData = new ArcSettingData();
            var lro = await cluster.GetArcSettings().CreateOrUpdateAsync(WaitUntil.Completed, arcSettingName, arcSettingData);
            return lro.Value;
        }

        protected async Task<ArcExtensionResource> CreateArcExtensionAsync(ArcSettingResource arcSetting, string arcExtensionName)
        {
            var arcExtensionData = new ArcExtensionData()
            {
                ArcExtensionType = "MicrosoftMonitoringAgent",
                Publisher = "Microsoft",
                TypeHandlerVersion = "1.10",
                Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "workspaceId", "5dcf9bc1-c220-4ed6-84f3-6919c3a393b6" }
                }),
                ProtectedSettings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "workspaceKey", "5dcf9bc1-c220-4ed6-84f3-6919c3a393b6" }
                })
            };
            var lro = await arcSetting.GetArcExtensions().CreateOrUpdateAsync(WaitUntil.Completed, arcExtensionName, arcExtensionData);
            return lro.Value;
        }

        public async Task<bool> RetryUntilSuccessOrTimeout(Func<Task<bool>> task, TimeSpan timeSpan)
        {
            bool success = false;
            int elapsed = 0;
            int frequency = 5000;
            while (!success && elapsed < timeSpan.TotalMilliseconds)
            {
                await Delay(frequency, null);
                elapsed += frequency;
                success = await task();
            }
            return success;
        }
    }
}
