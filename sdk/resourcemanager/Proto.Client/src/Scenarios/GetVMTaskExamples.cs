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
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);
            var resourceGroup = subscription.GetResourceGroupOperations(Context.RgName);
            var vmId = resourceGroup.GetVirtualMachineOperations(Context.VmName).Id;
            var vnId = resourceGroup.GetVirtualNetworkOperations(Context.VmName + "_vnet").Id;
            var subnetId = resourceGroup.GetVirtualNetworkOperations(Context.VmName + "_vnet").GetSubnetOperations(Context.SubnetName).Id;
            var asId = resourceGroup.GetAvailabilitySetOperations(Context.VmName + "_aSet").Id;
            var nsgId = resourceGroup.GetNetworkSecurityGroupOperations(Context.NsgName).Id;
            var niId = resourceGroup.GetNetworkInterfaceOperations(Context.VmName + "_nic").Id;

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
