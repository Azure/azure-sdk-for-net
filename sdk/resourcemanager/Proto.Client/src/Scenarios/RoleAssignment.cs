using Azure.ResourceManager.Core;
using Proto.Authorization;
using Proto.Compute;
using Proto.Network;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class RoleAssignment : Scenario
    {
        public override void Execute()
        {
            var client = new AzureResourceManagerClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroupContainer().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);

            Console.WriteLine("--------Start create Assignment--------");
            var input = new RoleAssignmentCreateParameters($"/subscriptions/{Context.SubscriptionId}/resourceGroups/{Context.RgName}/providers/Microsoft.Authorization/roleDefinitions/{Context.RoleId}", Context.PrincipalId);
            var assign = resourceGroup.GetRoleAssignmentContainer().Create(Guid.NewGuid().ToString(), input).Value;
            Console.WriteLine("--------Done create Assignment--------");

            assign = assign.Get().Value;

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

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface--------");
            var nic = resourceGroup.GetNetworkInterfaceContainer().Construct(subnet.Id).CreateOrUpdate($"{Context.VmName}_nic").Value;

            // Create VM
            Console.WriteLine("--------Start create VM--------");
            var vm = resourceGroup.GetVirtualMachineContainer().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).CreateOrUpdate(Context.VmName).Value;

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done create VM--------");


            Console.WriteLine("--------Start create Assignment--------");
            var input2 = new RoleAssignmentCreateParameters($"{vm.Id}/providers/Microsoft.Authorization/roleDefinitions/{Context.RoleId}", Context.PrincipalId);
            var assign2 = vm.GetRoleAssignmentContainer().Create(Guid.NewGuid().ToString(), input2).Value;
            Console.WriteLine("--------Done create Assignment--------");

            assign2 = assign2.Get().Value;
            Console.WriteLine($"Created assignment: '{assign.Data.Id}'");

            
        }
    }
}
