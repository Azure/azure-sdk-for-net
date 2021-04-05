using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Identity;

namespace Proto.Client
{
    class GetByContainersAsync: Scenario
    {
        public override void Execute()
        {
            ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        private async Task ExecuteAsync()
        {
            var createMultipleVms = new CreateMultipleVms(Context);
            createMultipleVms.Execute();

            var sub = new ArmClient(new DefaultAzureCredential()).GetSubscriptionOperations(Context.SubscriptionId);
            var rg = sub.GetResourceGroupOperations(Context.RgName);
            var virtualMachineContainer = rg.GetVirtualMachines();
            await foreach (var response in virtualMachineContainer.ListAsync())
            {
                var virtualMachine = await virtualMachineContainer.GetAsync(response.Data.Id.Name);
                Debug.Assert(virtualMachine.Value.Data.Name.Equals(response.Data.Id.Name));
            }
            var virtualNetworkContainer = rg.GetVirtualNetworks();
            await foreach (var response in virtualNetworkContainer.ListAsync())
            {
                var virtualNetwork = await virtualNetworkContainer.GetAsync(response.Data.Id.Name);
                Debug.Assert(virtualNetwork.Value.Data.Name.Equals(response.Data.Id.Name));
                await foreach (var subnetResponse in response.GetSubnets().ListAsync())
                {
                    var subnets = await response.GetSubnets().GetAsync(subnetResponse.Data.Name);
                    Debug.Assert(subnets.Value.Data.Name.Equals(subnetResponse.Data.Name));
                }
            }
            Console.WriteLine("\nDone all asserts passed ...");
            
        }
    }
}
