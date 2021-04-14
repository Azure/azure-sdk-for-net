using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class UseParentLocation : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroups().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);

            // Create AvailabilitySet
            Console.WriteLine("--------Start create AvailabilitySet--------");
            var aset = resourceGroup.GetAvailabilitySets().Construct("Aligned").CreateOrUpdate(Context.VmName + "_aSet").Value;
            if (aset.Data.Location != Context.Loc)
                throw new Exception($"aset was on the wrong location expected {Context.Loc} actual {aset.Data.Location}");

            // Create VNet
            Console.WriteLine("--------Start create VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;
            if (vnet.Data.Location != Context.Loc)
                throw new Exception($"vnet was on the wrong location expected {Context.Loc} actual {vnet.Data.Location}");

            //create subnet
            Console.WriteLine("--------Start create Subnet async--------");
            var subnet = vnet.GetSubnets().Construct("10.0.0.0/24").CreateOrUpdateAsync(Context.SubnetName).ConfigureAwait(false).GetAwaiter().GetResult().Value;

            //create network security group
            Console.WriteLine("--------Start create NetworkSecurityGroup--------");
            var nsg = resourceGroup.GetNetworkSecurityGroups().Construct(80).CreateOrUpdate(Context.NsgName).Value;
            if (nsg.Data.Location != Context.Loc)
                throw new Exception($"nsg was on the wrong location expected {Context.Loc} actual {nsg.Data.Location}");

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface--------");
            var nic = resourceGroup.GetNetworkInterfaces().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_nic").Value;
            if (nic.Data.Location != Context.Loc)
                throw new Exception($"nic was on the wrong location expected {Context.Loc} actual {nic.Data.Location}");

            // Create VM
            Console.WriteLine("--------Start create VM--------");
            var vm = resourceGroup.GetVirtualMachines().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).CreateOrUpdate(Context.VmName).Value;
            if (vm.Data.Location != Context.Loc)
                throw new Exception($"vm was on the wrong location expected {Context.Loc} actual {vm.Data.Location}");

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done create VM--------");
            
        }
    }
}
