using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class StartStopVm : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);
            var resourceGroup = subscription.GetResourceGroups().Get(Context.RgName).Value;
            var vm = resourceGroup.GetVirtualMachines().Get(Context.VmName).Value;
            Console.WriteLine($"Found VM {Context.VmName}");
            Console.WriteLine("--------Stopping VM--------");
            vm.PowerOff();
            Console.WriteLine("--------Starting VM--------");
            vm.PowerOn();
        }
    }
}
