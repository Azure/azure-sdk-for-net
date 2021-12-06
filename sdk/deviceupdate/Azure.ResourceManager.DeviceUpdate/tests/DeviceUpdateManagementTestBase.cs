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

namespace Azure.ResourceManager.DeviceUpdate.Tests
{
    public class DeviceUpdateManagementTestBase : ManagementRecordedTestBase<DeviceUpdateManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DeviceUpdateManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode, useLegacyTransport: true)
        {
        }

        protected DeviceUpdateManagementTestBase(bool isAsync)
            : base(isAsync, useLegacyTransport: true)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroup> CreateResourceGroup(Subscription subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(Location.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, input);
            return lro.Value;
        }

        protected async Task<DeviceUpdateAccount> CreateAccount(ResourceGroup rg, string accountName)
        {
            DeviceUpdateAccountData input = ResourceDataHelper.CreateAccountData();
            var lro = await rg.GetDeviceUpdateAccounts().CreateOrUpdateAsync(accountName, input);
            return lro.Value;
        }

        protected async Task<DeviceUpdateInstance> CreateInstance(DeviceUpdateAccount account, string instanceName)
        {
            DeviceUpdateInstanceData input = ResourceDataHelper.CreateInstanceData();
            input.IotHubs.Add(new IotHubSettings("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/DeviceUpdateResourceGroup/providers/Microsoft.Devices/IotHubs/orange-aducpsdktestaccount-iothub"));
            var lro = await account.GetDeviceUpdateInstances().CreateOrUpdateAsync(instanceName, input);
            return lro.Value;
        }
    }
}
