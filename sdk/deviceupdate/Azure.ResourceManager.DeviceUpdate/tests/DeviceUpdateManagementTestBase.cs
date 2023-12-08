// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DeviceUpdate.Models;
using Azure.ResourceManager.DeviceUpdate.Tests.Helper;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.DeviceUpdate.Tests
{
    public class DeviceUpdateManagementTestBase : ManagementRecordedTestBase<DeviceUpdateManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DeviceUpdateManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DeviceUpdateManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(AzureLocation.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DeviceUpdateAccountResource> CreateAccount(ResourceGroupResource rg, string accountName)
        {
            DeviceUpdateAccountData input = ResourceDataHelper.CreateAccountData();
            var lro = await rg.GetDeviceUpdateAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return lro.Value;
        }

        protected async Task<DeviceUpdateInstanceResource> CreateInstance(DeviceUpdateAccountResource account, string instanceName)
        {
            DeviceUpdateInstanceData input = ResourceDataHelper.CreateInstanceData();
            input.IotHubs.Add(new DeviceUpdateIotHubSettings(new ResourceIdentifier("/subscriptions/a645d3be-5a4a-40ef-82a1-d5f5358a424c/resourcegroups/mfrintu/providers/Microsoft.Devices/IotHubs/orange-aducpsdktestaccount-hub")));
            var lro = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(WaitUntil.Completed, instanceName, input);
            return lro.Value;
        }
    }
}
