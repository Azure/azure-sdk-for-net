using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class StartCreateSingleVmExample : Scenario
    {
        public StartCreateSingleVmExample() : base() { }

        public StartCreateSingleVmExample(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            ExcuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async System.Threading.Tasks.Task ExcuteAsync()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start StartCreate group {Context.RgName}--------");
            var resourceGroup = (await(subscription.GetResourceGroups().Construct(Context.Loc).StartCreateOrUpdate(Context.RgName)).WaitForCompletionAsync()).Value;
            CleanUp.Add(resourceGroup.Id);

            // Create AvailabilitySet
            Console.WriteLine("--------Start StartCreate AvailabilitySet async--------");
            var aset = (await(resourceGroup.GetAvailabilitySets().Construct("Aligned").StartCreateOrUpdate(Context.VmName + "_aSet")).WaitForCompletionAsync()).Value;

            // Create VNet
            Console.WriteLine("--------Start StartCreate VNet--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = (await(resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").StartCreateOrUpdate(vnetName)).WaitForCompletionAsync()).Value;

            //create subnet
            Console.WriteLine("--------Start StartCreate Subnet--------");
            var subnet = (await(vnet.GetSubnets().Construct("10.0.0.0/24").StartCreateOrUpdate(Context.SubnetName)).WaitForCompletionAsync()).Value;

            //create network security group
            Console.WriteLine("--------Start StartCreate NetworkSecurityGroup--------");
            _ = (await(resourceGroup.GetNetworkSecurityGroups().Construct(80).StartCreateOrUpdate(Context.NsgName)).WaitForCompletionAsync()).Value;

            // Create Network Interface
            Console.WriteLine("--------Start StartCreate Network Interface--------");
            var nic = (await(resourceGroup.GetNetworkInterfaces().Construct(subnet.Id).StartCreateOrUpdate($"{Context.VmName}_nic")).WaitForCompletionAsync()).Value;

            // Create VM
            Console.WriteLine("--------Start StartCreate VM --------");
            var vm = (await(resourceGroup.GetVirtualMachines().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).StartCreateOrUpdate(Context.VmName)).WaitForCompletionAsync()).Value;

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done StartCreate VM--------");
        }
    }
}
