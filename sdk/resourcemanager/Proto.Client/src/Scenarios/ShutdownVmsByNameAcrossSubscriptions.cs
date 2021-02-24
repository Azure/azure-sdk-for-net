using Azure.ResourceManager.Compute;
using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using System.Threading.Tasks;

namespace Proto.Client
{
    class ShutdownVmsByNameAcrossSubscriptions : Scenario
    {
        public async void ShutdownAsync()
        {
            var client = new AzureResourceManagerClient();

            await foreach (var subscription in client.GetSubscriptionContainer().ListAsync())
            {
                await foreach (var armResource in subscription.ListVirtualMachinesByNameAsync("-e"))
                {
                    var vmOperations = VirtualMachineOperations.FromGeneric(armResource);
                    await vmOperations.PowerOffAsync();
                    await vmOperations.PowerOnAsync();
                }
            }
        }

        public async override void Execute()
        {
            #region SETUP
            ScenarioContext[] contexts = new ScenarioContext[] { new ScenarioContext(), new ScenarioContext("c9cbd920-c00c-427c-852b-8aaf38badaeb") };
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 1
            };

            Parallel.ForEach(contexts, options, context =>
            {
                var createMultipleVms = new CreateMultipleVms(context);
                createMultipleVms.Execute();
            });
            #endregion


            var client = new AzureResourceManagerClient();
            foreach (var sub in client.GetSubscriptionContainer().List())
            {
                await foreach (var armResource in sub.ListVirtualMachinesByNameAsync("-e"))
                {
                    var vmOperations = VirtualMachineOperations.FromGeneric(armResource);
                    Console.WriteLine($"Stopping {vmOperations.Id.Subscription} {vmOperations.Id.ResourceGroup} {vmOperations.Id.Name}");
                    vmOperations.PowerOff();
                    Console.WriteLine($"Starting {vmOperations.Id.Subscription} {vmOperations.Id.ResourceGroup} {vmOperations.Id.Name}");
                    vmOperations.PowerOn();
                }
            }
        }
    }
}
