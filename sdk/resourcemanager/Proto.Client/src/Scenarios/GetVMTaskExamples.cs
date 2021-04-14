using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network;
using Proto.Compute;
using Proto.Network;
using System;
using System.Linq;
using Azure.Identity;

namespace Proto.Client
{
    class GetVMTaskExamples : Scenario
    {
        public GetVMTaskExamples() : base() { }

        public GetVMTaskExamples(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);
            var resourceGroup = subscription.GetResourceGroups().Get(Context.RgName).Value;
            var vmId = resourceGroup.GetVirtualMachines().Get(Context.VmName).Value.Id;
            var vnId = resourceGroup.GetVirtualNetworks().Get(Context.VmName + "_vnet").Value.Id;
            var subnetId = resourceGroup.GetVirtualNetworks().Get(Context.VmName + "_vnet").Value.GetSubnets().Get(Context.SubnetName).Value.Id;
            var asId = resourceGroup.GetAvailabilitySets().Get(Context.VmName + "_aSet").Value.Id;
            var nsgId = resourceGroup.GetNetworkSecurityGroups().Get(Context.NsgName).Value.Id;
            var niId = resourceGroup.GetNetworkInterfaces().Get(Context.VmName + "_nic").Value.Id;

            var vmOps = client.GetVirtualMachineOperations(vmId);
            Console.WriteLine("\nclient.GetVirtualMachineOperations(vmResourceId)");
            vmOps.PowerOff();            
            Console.WriteLine("Option 1 vm is " + vmOps.Get().Value.Data.InstanceView.Statuses.Last().Code);
            vmOps.PowerOn();
            Console.WriteLine("Option 1 vm is " + vmOps.Get().Value.Data.InstanceView.Statuses.Last().Code);

            var subnetOps = client.GetSubnetOperations(subnetId);
            Console.WriteLine("Option 1 subnet is " + subnetOps.Id);

            var vnOps = client.GetVirtualNetworkOperations(vnId);            
            var nsgOps = client.GetNetworkSecurityGroupOperations(nsgId);
            var niOps = client.GetNetworkInterfaceOperations(niId);
            var asOps = client.GetAvailabilitySetOperations(asId);

            Console.WriteLine(vnOps.Id);
            Console.WriteLine(nsgOps.Id);
            Console.WriteLine(niOps.Id);
            Console.WriteLine(asOps.Id);

            Console.WriteLine("Demo complete");
        }
    }
}
