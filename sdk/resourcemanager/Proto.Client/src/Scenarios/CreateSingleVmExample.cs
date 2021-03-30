using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class CreateSingleVmExample : Scenario
    {
        public CreateSingleVmExample() : base() { }

        public CreateSingleVmExample(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.DefaultSubscription;

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroups().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);

            // Create AvailabilitySet
            Console.WriteLine("--------Start create AvailabilitySet--------");
            var aset = resourceGroup.GetAvailabilitySets().Construct("Aligned").CreateOrUpdate(Context.VmName + "_aSet").Value;

            // Create VNet
            Console.WriteLine("--------Start create VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;

            //create subnet
            Console.WriteLine("--------Start create Subnet async--------");
            var subnet = vnet.GetSubnets().Construct("10.0.0.0/24").CreateOrUpdate(Context.SubnetName).Value;

            //create network security group
            Console.WriteLine("--------Start create NetworkSecurityGroup--------");
            _ = resourceGroup.GetNetworkSecurityGroups().Construct(80).CreateOrUpdate(Context.NsgName).Value;

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface--------");
            var nic = resourceGroup.GetNetworkInterfaces().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_nic").Value;

            // Create VM
            Console.WriteLine("--------Start create VM--------");
            var vm = resourceGroup.GetVirtualMachines().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).CreateOrUpdate(Context.VmName).Value;

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done create VM--------");
            
        }
    }
}
