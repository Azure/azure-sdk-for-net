using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Identity;

namespace Proto.Client
{
    class ShutdownVmsByNameAcrossResourceGroups : Scenario
    {
        public override void Execute()
        {
            int numberOfRgs = 2;
            var context = Context;
            for (int i = 0; i < numberOfRgs; i++)
            {
                var createMultipleVms = new CreateMultipleVms(context);
                createMultipleVms.Execute();
                context = new ScenarioContext();
            }

            var subscription = new ArmClient(new DefaultAzureCredential()).GetSubscriptionOperations(Context.SubscriptionId);

            Regex reg = new Regex($"{Context.VmName}.*-e");
            Parallel.ForEach(subscription.ListVirtualMachines(), vm =>
            {
                if (reg.IsMatch(vm.Id.Name))
                {
                    Console.WriteLine($"Stopping {vm.Id.ResourceGroupName} {vm.Id.Name}");
                    vm.PowerOff();
                    Console.WriteLine($"Starting {vm.Id.ResourceGroupName} {vm.Id.Name}");
                    vm.PowerOn();
                }
            });
            
        }
    }
}
