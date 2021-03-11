using Proto.Compute;
using Azure.ResourceManager.Core;
using Proto.Network;
using System;
using System.Threading.Tasks;

namespace Proto.Client
{
    class List : Scenario
    {
        public override void Execute()
        {
            var createMultipleVms = new CreateMultipleVms(Context);
            createMultipleVms.Execute();

            var rg = new AzureResourceManagerClient().GetResourceGroupOperations(Context.SubscriptionId, Context.RgName).Get().Value;
            foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            foreach (var availabilitySet in rg.GetAvailabilitySetContainer().List(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet id--------: {availabilitySet.Data.Id}");
            }

            foreach (var vm in rg.GetVirtualMachineContainer().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            foreach (var vm in rg.GetVirtualMachineContainer().List(Environment.UserName))
            {
                Console.WriteLine($"--------VM id--------: {vm.Data.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            foreach (var networkInterface in rg.GetNetworkInterfaceContainer().List(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface id--------: {networkInterface.Data.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().List(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup id--------: {networkSecurityGroup.Data.Id}");
            }

            foreach (var publicIpAddress in rg.GetNetworkSecurityGroupContainer().List(Environment.UserName))
            {
                Console.WriteLine($"--------PublicIpAddress id--------: {publicIpAddress.Data.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworkContainer().ListAsGenericResource(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            foreach (var VNet in rg.GetVirtualNetworkContainer().List(Environment.UserName))
            {
                Console.WriteLine($"--------VNet id--------: {VNet.Data.Id}");
            }
            ExecuteAsync(rg).GetAwaiter().GetResult();
            
        }

        private async Task ExecuteAsync(ResourceGroup rg)
        {
            await foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet operation id--------: {availabilitySet.Id}");
            }

            await foreach (var availabilitySet in rg.GetAvailabilitySetContainer().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------AvailabilitySet id--------: {availabilitySet.Data.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachineContainer().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM operation id--------: {vm.Id}");
            }

            await foreach (var vm in rg.GetVirtualMachineContainer().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VM id--------: {vm.Data.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface operation id--------: {networkInterface.Id}");
            }

            await foreach (var networkInterface in rg.GetNetworkInterfaceContainer().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkInterface id--------: {networkInterface.Data.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup operation id--------: {networkSecurityGroup.Id}");
            }

            await foreach (var networkSecurityGroup in rg.GetNetworkSecurityGroupContainer().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------NetworkSecurityGroup id--------: {networkSecurityGroup.Data.Id}");
            }

            await foreach (var publicIpAddress in rg.GetNetworkSecurityGroupContainer().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------PublicIpAddress id--------: {publicIpAddress.Data.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworkContainer().ListAsGenericResourceAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet operation id--------: {VNet.Id}");
            }

            await foreach (var VNet in rg.GetVirtualNetworkContainer().ListAsync(Environment.UserName))
            {
                Console.WriteLine($"--------VNet id--------: {VNet.Data.Id}");
            }
        }
    }
}
