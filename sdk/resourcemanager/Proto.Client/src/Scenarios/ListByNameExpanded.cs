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

            var rg = new ArmClient(new DefaultAzureCredential()).GetResourceGroupOperations(Context.SubscriptionId, Context.RgName).Get().Value;
            foreach (var availabilitySet in rg.GetAvailabilitySets().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            foreach (var availabilitySet in rg.GetAvailabilitySets().List(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet id--------: {availabilitySet.Data.Id}");
            }

            foreach (var vm in rg.GetVirtualMachines().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            foreach (var vm in rg.GetVirtualMachines().List(Environment.UserName))
            {
                Console.WriteLine($"--------VM id--------: {vm.Data.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaces().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaces().List(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface id--------: {networkInterface.Data.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroups().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroups().List(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup id--------: {networkSecurityGroup.Data.Id}");
            }

            foreach (var publicIpAddress in rg.GetNetworkSecurityGroups().List(Environment.UserName))
            {
                Console.WriteLine($"--------PublicIpAddress id--------: {publicIpAddress.Data.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworks().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworks().List(Environment.UserName))
            {
                Console.WriteLine($"--------VNet id--------: {VNet.Data.Id}");
            }
            ExecuteAsync(rg).GetAwaiter().GetResult();
            
        }

        private async Task ExecuteAsync(ResourceGroup rg)
        {
            await foreach (var availabilitySet in rg.GetAvailabilitySets().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            await foreach (var availabilitySet in rg.GetAvailabilitySets().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet id--------: {availabilitySet.Data.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachines().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachines().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM id--------: {vm.Data.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaces().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaces().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface id--------: {networkInterface.Data.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroups().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroups().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup id--------: {networkSecurityGroup.Data.Id}");
            }

            await foreach (var publicIpAddress in rg.GetNetworkSecurityGroups().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------PublicIpAddress id--------: {publicIpAddress.Data.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworks().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworks().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet id--------: {VNet.Data.Id}");
            }
        }
    }
}
