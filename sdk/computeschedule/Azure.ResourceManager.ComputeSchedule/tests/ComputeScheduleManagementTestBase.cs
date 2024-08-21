// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using Azure.ResourceManager.ComputeSchedule.Tests.Helpers;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleManagementTestBase : ManagementRecordedTestBase<ComputeScheduleManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation Location { get; private set; }
        protected GenericResourceCollection _genericResourceCollection;

        protected ComputeScheduleManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ComputeScheduleManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            Location = AzureLocation.CentralUS;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(string rgName)
        {
            var resourceGroupName = Recording.GenerateAssetName(rgName);
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(Location)
                {
                    Tags =
                    {
                        { "computescheduletest", "test" }
                    }
                });
            return rgOp.Value;
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }

        private async Task<GenericResource> CreateNetworkInterface(ResourceIdentifier subnetId, ResourceGroupResource rg)
        {
            var nicName = Recording.GenerateAssetName("computeschedule-test-nic-");
            ResourceIdentifier nicId = new ResourceIdentifier($"{rg.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}");
            var input = new GenericResourceData(Location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
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
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nicId, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork(ResourceGroupResource rg)
        {
            var vnetName = Recording.GenerateAssetName("computeschedule-test-vnet-");
            var subnetName = Recording.GenerateAssetName("computeschedule-test-subnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{rg.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
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
            var input = new GenericResourceData(Location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        /// <summary>
        /// Dependencies for creating a virtual machine
        /// </summary>
        /// <returns></returns>
        protected async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineCreationAsync(ResourceGroupResource rg)
        {
            var vnet = await CreateVirtualNetwork(rg);
            //var subnet = await CreateSubnet(vnet.Id as ResourceGroupIdentifier);
            var nic = await CreateNetworkInterface(GetSubnetId(vnet), rg);
            return nic;
        }

        /// <summary>
        /// Create a virtual machine in a resource group
        /// </summary>
        /// <param name="vmName"></param>
        /// <param name="resourceGroup"></param>
        /// <returns></returns>
        protected async Task<VirtualMachineResource> CreateVirtualMachineAsync(string vmName, string vmnamesuffix, ResourceGroupResource resourceGroup)
        {
            var wholeVmName = $"{vmName}-{vmnamesuffix}";
            var vmCollection = resourceGroup.GetVirtualMachines();
            var nic = await CreateBasicDependenciesOfVirtualMachineCreationAsync(resourceGroup);
            var input = ResourceUtils.GetBasicLinuxVirtualMachineData(Location, wholeVmName, nic.Id);
            var lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, wholeVmName, input);
            return lro.Value;
        }

        protected async Task<List<VirtualMachineResource>> GenerateMultipleVirtualMachines(string vmName, ResourceGroupResource resourceGroup, int vmCount)
        {
            var item = new List<VirtualMachineResource>();
            item.Clear();

            for (int i = 0; i <= vmCount; i++)
            {
                var vm = await CreateVirtualMachineAsync(vmName, $"{i}", resourceGroup);
                item.Add(vm);
            }

            return item;
        }

        protected static SubscriptionResource GenerateSubscriptionResource(ArmClient client, string subid)
        {
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subid);
            return client.GetSubscriptionResource(subscriptionResourceId);
        }
    }
}
