using Proto.Compute;
using Azure.ResourceManager.Core;
using Proto.Network;
using System;
using System.Threading.Tasks;

namespace Proto.Client
{
    class ListByNameExpanded : Scenario
    {
        public override void Execute()
        {
            var createMultipleVms = new CreateMultipleVms(Context);
            createMultipleVms.Execute();

            var rg = new AzureResourceManagerClient().GetResourceGroupOperations(Context.SubscriptionId, Context.RgName).Get().Value;
            foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListByName(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListByNameExpanded(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet id--------: {availabilitySet.Data.Id}");
            }

            foreach (var vm in rg.GetVirtualMachineContainer().ListByName(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            foreach (var vm in rg.GetVirtualMachineContainer().ListByNameExpanded(Environment.UserName))
            {
                Console.WriteLine($"--------VM id--------: {vm.Data.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListByName(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListByNameExpanded(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface id--------: {networkInterface.Data.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListByName(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListByNameExpanded(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup id--------: {networkSecurityGroup.Data.Id}");
            }

            foreach (var publicIpAddress in rg.GetNetworkSecurityGroupContainer().ListByNameExpanded(Environment.UserName))
            {
                Console.WriteLine($"--------PublicIpAddress id--------: {publicIpAddress.Data.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworkContainer().ListByName(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworkContainer().ListByNameExpanded(Environment.UserName))
            {
                Console.WriteLine($"--------VNet id--------: {VNet.Data.Id}");
            }
            ExecuteAsync(rg).GetAwaiter().GetResult();
            
        }

        private async Task ExecuteAsync(ResourceGroup rg)
        {
            await foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListByNameAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            await foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListByNameExpandedAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet id--------: {availabilitySet.Data.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachineContainer().ListByNameAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachineContainer().ListByNameExpandedAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM id--------: {vm.Data.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListByNameAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListByNameExpandedAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface id--------: {networkInterface.Data.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListByNameAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListByNameExpandedAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup id--------: {networkSecurityGroup.Data.Id}");
            }

            await foreach (var publicIpAddress in rg.GetNetworkSecurityGroupContainer().ListByNameExpandedAsync(Environment.UserName))
            {
                Console.WriteLine($"--------PublicIpAddress id--------: {publicIpAddress.Data.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworkContainer().ListByNameAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworkContainer().ListByNameExpandedAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet id--------: {VNet.Data.Id}");
            }
        }
    }
}
