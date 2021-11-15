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

        protected async Task<ResourceGroup> CreateResourceGroup(Subscription subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(Location.WestUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, input);
            return lro.Value;
        }

        protected async Task<Account> CreateAccount(ResourceGroup rg, string accountName)
        {
            AccountData input = ResourceDataHelper.CreateAccountData();
            var lro = await rg.GetAccounts().CreateOrUpdateAsync(accountName, input);
            return lro.Value;
        }

        protected async Task<Instance> CreateInstance(Account account, string instanceName)
        {
            InstanceData input = ResourceDataHelper.CreateInstanceData();
            input.IotHubs.Add(new IotHubSettings("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/DeviceUpdateResourceGroup/providers/Microsoft.Devices/IotHubs/orange-aducpsdktestaccount-iothub"));
            var lro = await account.GetInstances().CreateOrUpdateAsync(instanceName, input);
            return lro.Value;
        }
    }
}
