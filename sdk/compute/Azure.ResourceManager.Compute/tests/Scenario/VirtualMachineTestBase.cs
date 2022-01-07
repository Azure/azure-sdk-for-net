// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VirtualMachineTestBase : ComputeTestBase
    {
        protected ResourceGroup _resourceGroup;
        protected GenericResourceCollection _genericResourceCollection;

        public VirtualMachineTestBase(bool isAsync) : base(isAsync)
        {
        }

        public VirtualMachineTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected async Task<VirtualMachineCollection> GetVirtualMachineCollectionAsync()
        {
            _genericResourceCollection = DefaultSubscription.GetGenericResources();
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetVirtualMachines();
        }

        protected async Task<GenericResource> CreateVirtualNetwork()
        {
            var vnetName = Recording.GenerateAssetName("testVNet-");
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                }
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(vnetId, input);
            return operation.Value;
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties as IDictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }

        // WEIRD: second level resources cannot use GenericResourceCollection to create.
        // Exception thrown: System.InvalidOperationException : An invalid resource id was given /subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testRG-4544/providers/Microsoft.Network/virtualNetworks/testVNet-9796/subnets/testSubnet-1786
        private async Task<GenericResource> CreateSubnet(ResourceIdentifier vnetId)
        {
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier subnetId = new ResourceIdentifier($"{vnetId}/subnets/{subnetName}");
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "addressPrefixes", new List<string>() { "10.0.2.0/24" } }
                }
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(subnetId, input);
            return operation.Value;
        }

        private async Task<GenericResource> CreateNetworkInterface(ResourceIdentifier subnetId)
        {
            var nicName = Recording.GenerateAssetName("testNic-");
            ResourceIdentifier nicId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}");
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "ipConfigurations", new List<object>()
                        {
                            new Dictionary<string, object>()
                            {
                                { "name", "internal" },
                                { "properties", new Dictionary<string, object>()
                                    {
                                        { "subnet", new Dictionary<string, object>() { { "id", subnetId.ToString() } } }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(nicId, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineAsync()
        {
            var vnet = await CreateVirtualNetwork();
            //var subnet = await CreateSubnet(vnet.Id as ResourceGroupResourceIdentifier);
            var nic = await CreateNetworkInterface(GetSubnetId(vnet));
            return nic;
        }
    }
}
