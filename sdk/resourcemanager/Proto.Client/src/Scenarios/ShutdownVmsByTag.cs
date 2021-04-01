using Proto.Compute;
using Azure.ResourceManager.Core;
using System;
using System.Linq;
using Azure.Identity;

namespace Proto.Client
{
    class ShutdownVmsByTag : Scenario
    {
        public override void Execute()
        {
            var createMultipleVms = new CreateMultipleVms(Context);
            createMultipleVms.Execute();

            var rg = new ArmClient(new DefaultAzureCredential()).GetResourceGroupOperations(Context.SubscriptionId, Context.RgName).Get().Value;

            //set tags on random vms
            Random rand = new Random(Environment.TickCount);
            foreach (var generic in rg.GetVirtualMachines().ListAsGenericResource(Environment.UserName))
            {
                var vm = VirtualMachineOperations.FromGeneric(generic);
                if (rand.NextDouble() > 0.5)
                {
                    Console.WriteLine("adding tag to {0}", vm.Id.Name);
                    vm.StartAddTag("tagkey", "tagvalue");
                }
            }

            var filteredList = rg.GetVirtualMachines().List().Where(vm =>
            {
                string value;
                return (vm.Data.Tags.TryGetValue("tagkey", out value) && value == "tagvalue");
            });

            foreach (var vm in filteredList)
            {
                Console.WriteLine("--------Stopping VM {0}--------", vm.Id.Name);
                vm.PowerOff();
                Console.WriteLine("--------Starting VM {0}--------", vm.Id.Name);
                vm.PowerOn();
            }
        }
    }
}
