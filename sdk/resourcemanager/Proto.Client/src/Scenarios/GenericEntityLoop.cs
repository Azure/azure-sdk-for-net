using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class GenericEntityLoop : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var rgOp = new ArmClient(new DefaultAzureCredential()).GetResourceGroupOperations(Context.SubscriptionId, Context.RgName);
            foreach(var entity in rgOp.GetVirtualMachines().List())
            {
                Console.WriteLine($"{entity.Id.Name}");
                entity.StartAddTag("name", "Value");
            }
            
        }
    }
}
