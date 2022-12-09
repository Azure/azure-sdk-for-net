// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Hci.Tests
{
    public class HciManagementTestBase : ManagementRecordedTestBase<HciManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

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
                AadTenantId = new Guid(TestEnvironment.TenantId)
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
                Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "workspaceId", "5dcf9bc1-c220-4ed6-84f3-6919c3a393b6" }
                })
            };
            var lro = await arcSetting.GetArcExtensions().CreateOrUpdateAsync(WaitUntil.Completed, arcExtensionName, arcExtensionData);
            return lro.Value;
        }
    }
}
