using Proto.Compute;
using Azure.ResourceManager.Core;
using System;

namespace Proto.Client
{
    class GenericEntityLoop : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var rgOp = new AzureResourceManagerClient().GetResourceGroupOperations(Context.SubscriptionId, Context.RgName);
            foreach(var entity in rgOp.GetVirtualMachineContainer().List())
            {
                Console.WriteLine($"{entity.Id.Name}");
                entity.StartAddTag("name", "Value");
            }
            
        }
    }
}
