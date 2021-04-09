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

            var client = new ArmClient(new DefaultAzureCredential());
            var sub = client.GetSubscriptions().TryGet(Context.SubscriptionId);
            var rgOp = sub.GetResourceGroups().Get(Context.RgName).Value;
            foreach(var entity in rgOp.GetVirtualMachines().List())
            {
                Console.WriteLine($"{entity.Id.Name}");
                entity.StartAddTag("name", "Value");
            }
            
        }
    }
}
