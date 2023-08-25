// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceProvisioningServices.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DeviceProvisioningServices.Tests
{
    public class DeviceProvisioningServicesManagementTestBase : ManagementRecordedTestBase<DeviceProvisioningServicesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected string ResourceGroupNamePrefix = "DeviceProvisioningServicesRG";

        protected DeviceProvisioningServicesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..certificate");
        }

        protected DeviceProvisioningServicesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$..certificate");
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DeviceProvisioningServiceResource> CreateDefaultDps(ResourceGroupResource resourceGroup,string dpsName)
        {
            var properties = new DeviceProvisioningServiceProperties()
            {
                IsDataResidencyEnabled = false,
            };
            var sku = new DeviceProvisioningServicesSkuInfo()
            {
                Name = "S1",
                Capacity = 1,
            };
            var data = new DeviceProvisioningServiceData(DefaultLocation, properties, sku);
            var dpsLro = await resourceGroup.GetDeviceProvisioningServices().CreateOrUpdateAsync(WaitUntil.Completed, dpsName, data);
            return dpsLro.Value;
        }
    }
}
