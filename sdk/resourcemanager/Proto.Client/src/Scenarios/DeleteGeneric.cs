using Azure;
using Azure.ResourceManager.Core;
using Proto.Compute;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class DeleteGeneric : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();
            var client = new ArmClient(new DefaultAzureCredential());
            var sub = client.GetSubscriptions().TryGet(Context.SubscriptionId);
            var rgOp = sub.GetResourceGroups().Get(Context.RgName).Value;
            foreach(var genericOp in rgOp.GetVirtualMachines().ListAsGenericResource(Context.VmName))
            {
                Console.WriteLine($"Deleting {genericOp.Id}");
                genericOp.Delete();
            }

            try
            {
                var vmOp = rgOp.GetVirtualMachines().Get(Context.VmName).Value;
                Console.WriteLine($"Trying to get {vmOp.Id}");
                var response = vmOp.Get();
            }
            catch(RequestFailedException e) when (e.Status == 404)
            {
                Console.WriteLine("Got 404 returned as expected");
                
            }

            throw new InvalidOperationException("Failed");
        }
    }
}
