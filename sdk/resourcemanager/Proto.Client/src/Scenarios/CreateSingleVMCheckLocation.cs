using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using System.Linq;
using Azure.Identity;

namespace Proto.Client
{
    class CreateSingleVMCheckLocation : Scenario
    {
        public CreateSingleVMCheckLocation() : base() { }

        public CreateSingleVMCheckLocation(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroups().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);
            Console.WriteLine("\nResource Group List Available Locations: ");
            var loc = resourceGroup.ListAvailableLocations();
            foreach(var l in loc)
            {
                Console.WriteLine(l.DisplayName);
            }

            // Create AvailabilitySet
            Console.WriteLine("--------Start create AvailabilitySet--------");
            var aset = resourceGroup.GetAvailabilitySets().Construct("Aligned").CreateOrUpdate(Context.VmName + "_aSet").Value;
            Console.WriteLine("\nAvailability Set List Available Locations: ");
            loc = aset.ListAvailableLocations();
            foreach (var l in loc)
            {
                Console.WriteLine(l.DisplayName);
            }            

            // Create VNet
            Console.WriteLine("--------Start create VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;
            Console.WriteLine("\nVirtual Network List Available Locations: ");
            loc = vnet.ListAvailableLocations();
            foreach (var l in loc)
            {
                Console.WriteLine(l.DisplayName);
            }

            //create subnet
            Console.WriteLine("--------Start create Subnet--------");
            var subnet = vnet.GetSubnets().Construct("10.0.0.0/24").CreateOrUpdate(Context.SubnetName).Value;

            //create network security group
            Console.WriteLine("--------Start create NetworkSecurityGroup--------");
            var nsg = resourceGroup.GetNetworkSecurityGroups().Construct(80).CreateOrUpdate(Context.NsgName).Value;
            Console.WriteLine("\nNetwork Security Group List Available Locations: ");
            loc = nsg.ListAvailableLocations();
            foreach (var l in loc)
            {
                Console.WriteLine(l.DisplayName);
            }

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface--------");
            var nic = resourceGroup.GetNetworkInterfaces().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_nic").Value;
            Console.WriteLine("\nNetwork Interface Container List Available Locations: ");
            loc = nic.ListAvailableLocations();
            foreach (var l in loc)
            {
                Console.WriteLine(l.DisplayName);
            }

            // Create VM
            Console.WriteLine("--------Start create VM--------");
            var vm = resourceGroup.GetVirtualMachines().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).CreateOrUpdate(Context.VmName).Value;
            Console.WriteLine("\nVirtual Machine List Available Locations: ");
            loc = vm.ListAvailableLocations();
            foreach (var l in loc)
            {
                Console.WriteLine(l.DisplayName);
            }

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done create VM--------");
        }
    }
}
