// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Security;
using System.Threading.Tasks;

namespace Azure.ResourceManager.IotHub.Tests
{
    public class IotHubManagementTestBase : ManagementRecordedTestBase<IotHubManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected IotHubManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected IotHubManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<IotHubDescriptionResource> CreateIotHub(ResourceGroupResource resourceGroup,string iotHubName)
        {
            var sku = new IotHubSkuInfo("S1")
            {
                Name = "S1",
                Capacity = 1
            };
            IotHubDescriptionData data = new IotHubDescriptionData(resourceGroup.Data.Location, sku) { };
            var iotHub = await resourceGroup.GetIotHubDescriptions().CreateOrUpdateAsync(WaitUntil.Completed, iotHubName, data);
            return iotHub.Value;
        }

        protected async Task<VirtualNetworkResource> CreateVirtualNetwork(ResourceGroupResource resourceGroup, string iotHubName)
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            VirtualNetworkData data = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
            };
            data.AddressPrefixes.Add("10.10.0.0/16");
            data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24" });
            data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return vnet.Value;
        }
    }
}
