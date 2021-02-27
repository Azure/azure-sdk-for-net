using Proto.Compute;
using Azure.ResourceManager.Core;
using Proto.Network;
using System;
using System.Collections.Generic;

namespace Proto.Client
{
    class CreateMultipleVms : Scenario
    {
        public CreateMultipleVms() : base() { }

        public CreateMultipleVms(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            var client = new AzureResourceManagerClient();
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroupContainer().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);

            // Create AvailabilitySet
            Console.WriteLine("--------Start create AvailabilitySet--------");
            var aset = resourceGroup.GetAvailabilitySetContainer().Construct("Aligned").CreateOrUpdate(Context.VmName + "_aSet").Value;

            // Create VNet
            Console.WriteLine("--------Start create VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworkContainer().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;

            //create subnet
            Console.WriteLine("--------Start create Subnet--------");
            var subnet = vnet.GetSubnetContainer().Construct("10.0.0.0/24").CreateOrUpdate(Context.SubnetName).Value;

            //create network security group
            Console.WriteLine("--------Start create NetworkSecurityGroup--------");
            _ = resourceGroup.GetNetworkSecurityGroupContainer().Construct(80).CreateOrUpdate(Context.NsgName).Value;

            CreateVms(resourceGroup, aset, subnet);
            
        }

        private void CreateVms(ResourceGroup resourceGroup, AvailabilitySet aset, SubnetOperations subnet)
        {
            List<ArmOperation<VirtualMachine>> operations = new List<ArmOperation<VirtualMachine>>();
            for (int i = 0; i < 10; i++)
            {
                // Create Network Interface
                Console.WriteLine("--------Start create Network Interface--------");
                var nic = resourceGroup.GetNetworkInterfaceContainer().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_{i}_nic").Value;

                // Create VM
                string num = i % 2 == 0 ? "-e" : "-o";
                string name = $"{Context.VmName}{i}{num}";
                Console.WriteLine("--------Start create VM {0}--------", i);
                var vmOp = resourceGroup.GetVirtualMachineContainer().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).StartCreateOrUpdate(name);
                operations.Add(vmOp);
            }

            foreach (var operation in operations)
            {
                var vm = operation.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult().Value;
                Console.WriteLine($"--------Finished creating VM {vm.Id.Name}");
            }
        }
    }
}
