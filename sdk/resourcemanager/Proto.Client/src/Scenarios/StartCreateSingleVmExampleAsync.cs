using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class StartCreateSingleVmExampleAsync : Scenario
    {
        public StartCreateSingleVmExampleAsync() : base() { }

        public StartCreateSingleVmExampleAsync(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        private async System.Threading.Tasks.Task ExecuteAsync()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start StartCreate group async {Context.RgName}--------");
            var resourceGroup = (await (await subscription.GetResourceGroups().Construct(Context.Loc).StartCreateOrUpdateAsync(Context.RgName)).WaitForCompletionAsync()).Value;
            CleanUp.Add(resourceGroup.Id);

            // Create AvailabilitySet
            Console.WriteLine("--------Start StartCreate AvailabilitySet async--------");
            var aset = (await (await resourceGroup.GetAvailabilitySets().Construct("Aligned").StartCreateOrUpdateAsync(Context.VmName + "_aSet")).WaitForCompletionAsync()).Value;

            // Create VNet
            Console.WriteLine("--------Start StartCreate VNet async--------");
            string vnetName = Context.VmName + "_vnet";
            var vnet = (await (await resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").StartCreateOrUpdateAsync(vnetName)).WaitForCompletionAsync()).Value;

            //create subnet
            Console.WriteLine("--------Start StartCreate Subnet async--------");
            var subnet = (await (await vnet.GetSubnets().Construct("10.0.0.0/24").StartCreateOrUpdateAsync(Context.SubnetName)).WaitForCompletionAsync()).Value;

            //create network security group
            Console.WriteLine("--------Start StartCreate NetworkSecurityGroup async--------");
            _ = (await (await resourceGroup.GetNetworkSecurityGroups().Construct(80).StartCreateOrUpdateAsync(Context.NsgName)).WaitForCompletionAsync()).Value;

            // Create Network Interface
            Console.WriteLine("--------Start StartCreate Network Interface async--------");
            var nic = (await (await resourceGroup.GetNetworkInterfaces().Construct(subnet.Id).StartCreateOrUpdateAsync($"{Context.VmName}_nic")).WaitForCompletionAsync()).Value;

            // Create VM
            Console.WriteLine("--------Start StartCreate VM async--------");
            var vm = (await (await resourceGroup.GetVirtualMachines().Construct(Context.Hostname, "admin-user", "!@#$%asdfA", nic.Id, aset.Id).StartCreateOrUpdateAsync(Context.VmName)).WaitForCompletionAsync()).Value;

            Console.WriteLine("VM ID: " + vm.Id);
            Console.WriteLine("--------Done StartCreate VM--------");
        }
    }
}
