using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class StartFromVm : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();
            var client = new ArmClient(new DefaultAzureCredential());

            //retrieve from lowest level, doesn't give ability to walk up and down the container structure
            var vmOp = client.GetResourceOperations<VirtualMachineOperations>(Context.SubscriptionId, Context.RgName, Context.VmName);
            var vm = vmOp.Get().Value.Data;
            Console.WriteLine($"Found VM {vm.Id}");

            //retrieve from lowest level inside management package gives ability to walk up and down
            var rg = client.GetResourceGroupOperations(Context.SubscriptionId, Context.RgName);
            var vm2 = rg.GetVirtualMachineOperations(Context.VmName).Get().Value.Data;
            Console.WriteLine($"Found VM {vm2.Id}");
        }
    }
}
