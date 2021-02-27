using Azure.ResourceManager.Core;
using Proto.Compute;
using System;

namespace Proto.Client
{
    class AddTagToGeneric : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var rgOp = new AzureResourceManagerClient().GetResourceGroupOperations(Context.SubscriptionId, Context.RgName);
            foreach (var genericOp in rgOp.GetVirtualMachineContainer().ListByName(Context.VmName))
            {
                Console.WriteLine($"Adding tag to {genericOp.Id}");
                genericOp.StartAddTag("tagKey", "tagVaue");
            }

            var vmOp = rgOp.GetVirtualMachineOperations(Context.VmName);
            Console.WriteLine($"Getting {vmOp.Id}");
            var vm = vmOp.Get().Value;

            if(!vm.Data.Tags.ContainsKey("tagKey"))
                throw new InvalidOperationException("Failed");
            
        }
    }
}
