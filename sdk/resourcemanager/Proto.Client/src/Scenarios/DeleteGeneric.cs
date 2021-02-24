using Azure;
using Azure.ResourceManager.Core;
using Proto.Compute;
using System;

namespace Proto.Client
{
    class DeleteGeneric : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var rgOp = new AzureResourceManagerClient().GetResourceGroupOperations(Context.SubscriptionId, Context.RgName);
            foreach(var genericOp in rgOp.GetVirtualMachineContainer().ListByName(Context.VmName))
            {
                Console.WriteLine($"Deleting {genericOp.Id}");
                genericOp.Delete();
            }

            try
            {
                var vmOp = rgOp.GetVirtualMachineOperations(Context.VmName);
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
