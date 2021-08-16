// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineTestBase : ComputeTestBase
    {
        protected ResourceGroup _resourceGroup;
        protected VirtualNetwork _virtualNetwork;
        protected Subnet _subnet;
        protected NetworkInterface _networkInterface;

        public VirtualMachineTestBase(bool isAsync) : base(isAsync)
        {
        }

        public VirtualMachineTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected async Task<VirtualMachineContainer> GetVirtualMachineContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetVirtualMachines();
        }

        protected async Task<VirtualNetwork> CreateVirtualNetworkAsync()
        {
            var vnetName = Recording.GenerateAssetName("testVNet-");
            var input = new VirtualNetworkData()
            {
                Location = DefaultLocation,
                AddressSpace = new Network.Models.AddressSpace()
                {
                    AddressPrefixes =
                    {
                        "10.0.0.0/16"
                    }
                }
            };
            _virtualNetwork = await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, input);
            return _virtualNetwork;
        }

        protected async Task<Subnet> CreateSubnetAsync()
        {
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            var input = new SubnetData()
            {
                AddressPrefix = "10.0.2.0/24"
            };
            _subnet = await _virtualNetwork.GetSubnets().CreateOrUpdateAsync(subnetName, input);
            return _subnet;
        }

        protected async Task<NetworkInterface> CreateNetworkInterfaceAsync()
        {
            var nicName = Recording.GenerateAssetName("testNic-");
            var input = new NetworkInterfaceData()
            {
                Location = DefaultLocation,
                IpConfigurations =
                {
                    new Network.Models.NetworkInterfaceIPConfiguration()
                    {
                        Name = "internal",
                        Subnet = new SubnetData()
                        {
                            Id = _subnet.Id
                        }
                    }
                }
            };
            _networkInterface = await _resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(nicName, input);
            return _networkInterface;
        }

        protected async Task<NetworkInterface> CreateBasicDependenciesOfVirtualMachineAsync()
        {
            await CreateVirtualNetworkAsync();
            await CreateSubnetAsync();
            return await CreateNetworkInterfaceAsync();
        }
    }
}
