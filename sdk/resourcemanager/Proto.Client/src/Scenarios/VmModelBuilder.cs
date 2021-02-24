// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Proto.Compute;
using Azure.ResourceManager.Core;
using Proto.Network;
using Proto.Compute.Convenience;

namespace Proto.Client
{
    class VmModelBuilder : Scenario
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }

        private Task<VirtualMachine> CreateVmWithBuilderAsync()
        {
            var client = new AzureResourceManagerClient();
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroupContainer().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;

            // Create AvailabilitySet
            Console.WriteLine("--------Start create AvailabilitySet--------");
            var aset = resourceGroup.GetAvailabilitySetContainer().Construct("Aligned").CreateOrUpdate(Context.VmName + "_aSet").Value;

            // Create VNet
            Console.WriteLine("--------Start create VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworkContainer().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;

            //create subnet
            Console.WriteLine("--------Start create Subnet--------");
            var nsg = resourceGroup.GetNetworkSecurityGroupContainer().Construct(80).CreateOrUpdate(Context.NsgName).Value;
            var subnet = vnet.GetSubnetContainer().Construct("10.0.0.0/24").CreateOrUpdate(Context.SubnetName).Value;

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface--------");
            var nic = resourceGroup.GetNetworkInterfaceContainer().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_nic").Value;

            // Options: required parameters on in the constructor
            VirtualMachineModelBuilder vmBuilder = new VirtualMachineModelBuilder(
                resourceGroup.GetVirtualMachineContainer(),
                new VirtualMachineData(new Azure.ResourceManager.Compute.Models.VirtualMachine(Context.Loc))); ;
            var vm = vmBuilder.UseWindowsImage("admin-user", "!@#$%asdfA")
                .RequiredNetworkInterface(nic.Id)
                .RequiredAvalabilitySet(aset.Id)
                .CreateOrUpdate(Context.VmName).Value;

            return Task.FromResult(vm);
        }
    }
}
