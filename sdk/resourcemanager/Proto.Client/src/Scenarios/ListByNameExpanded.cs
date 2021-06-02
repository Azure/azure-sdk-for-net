using Proto.Compute;
using Azure.ResourceManager.Core;
using Proto.Network;
using System;
using System.Threading.Tasks;
using Azure.Identity;

namespace Proto.Client
{
    class List : Scenario
    {
        public override void Execute()
        {
            var createMultipleVms = new CreateMultipleVms(Context);
            createMultipleVms.Execute();

            var client = new ArmClient(new DefaultAzureCredential());
            var sub = client.GetSubscriptions().TryGet(Context.SubscriptionId);
            var rg = sub.GetResourceGroups().Get(Context.RgName).Value;
            foreach (var availabilitySet in rg.GetAvailabilitySets().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            foreach (var vm in rg.GetVirtualMachines().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaces().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroups().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworks().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            ExecuteAsync(rg).GetAwaiter().GetResult();
            
        }

        private async Task ExecuteAsync(ResourceGroup rg)
        {
            await foreach (var availabilitySet in rg.GetAvailabilitySets().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachines().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaces().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroups().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworks().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }
        }
    }
}
