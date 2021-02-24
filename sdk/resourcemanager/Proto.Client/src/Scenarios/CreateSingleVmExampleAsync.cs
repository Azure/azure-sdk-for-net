using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;

namespace Proto.Client
{
    class CreateSingleVmExampleAsync : Scenario
    {
        public CreateSingleVmExampleAsync() : base() { }

        public CreateSingleVmExampleAsync(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            ExcuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async System.Threading.Tasks.Task ExcuteAsync()
        {
                var client = new AzureResourceManagerClient();
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group async {Context.RgName}--------");
            var resourceGroup = (await subscription.GetResourceGroupContainer().Construct(Context.Loc).CreateOrUpdateAsync(Context.RgName)).Value;
            CleanUp.Add(resourceGroup.Id);

            // Create AvailabilitySet
            Console.WriteLine("--------Start create AvailabilitySet async--------");
            var aset = (await resourceGroup.GetAvailabilitySetContainer().Construct("Aligned").CreateOrUpdateAsync(Context.VmName + "_aSet")).Value;

            // Create VNet
            Console.WriteLine("--------Start create VNet async--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = (await resourceGroup.GetVirtualNetworkContainer().Construct("10.0.0.0/16").CreateOrUpdateAsync(vnetName)).Value;

            //create subnet
            Console.WriteLine("--------Start create Subnet async--------");
            var subnet = (await vnet.GetSubnetContainer().Construct("10.0.0.0/24").CreateOrUpdateAsync(Context.SubnetName)).Value;

            //create network security group
            Console.WriteLine("--------Start create NetworkSecurityGroup async--------");
            _ = (await resourceGroup.GetNetworkSecurityGroupContainer().Construct(80).CreateOrUpdateAsync(Context.NsgName)).Value;

            // Create Network Interface
            Console.WriteLine("--------Start create Network Interface async--------");
            var nic = (await resourceGroup.GetNetworkInterfaceContainer().Construct(subnet.Id).CreateOrUpdateAsync($"{Context.VmName}_nic")).Value;

            // Create VM
            Console.WriteLine("--------Start create VM async--------");
            var vm = (await resourceGroup.GetVirtualMachineContainer().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).CreateOrUpdateAsync(Context.VmName)).Value;

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done create VM--------");
        }
    }
}
