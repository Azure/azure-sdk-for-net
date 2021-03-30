using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class ShutdownVmsByName: Scenario
    {
        public override void Execute()
        {
            var createMultipleVms = new CreateMultipleVms(Context);
            createMultipleVms.Execute();

            var sub = new ArmClient(new DefaultAzureCredential()).GetSubscriptionOperations(Context.SubscriptionId);

            foreach(var armResource in sub.ListVirtualMachinesByName("-e"))
            {
                var vmOperations = VirtualMachineOperations.FromGeneric(armResource);
                Console.WriteLine($"Stopping {vmOperations.Id.ResourceGroupName} : {armResource.Id.Name}");
                vmOperations.PowerOff();
                Console.WriteLine($"Starting {vmOperations.Id.ResourceGroupName} : {armResource.Id.Name}");
                vmOperations.PowerOn();
            }
            
            
        }
    }
}
