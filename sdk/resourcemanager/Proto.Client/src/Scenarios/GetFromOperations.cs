using Azure.Identity;
using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;

namespace Proto.Client
{
    class GetFromOperations : Scenario
    {
        public override void Execute()
        {
            var createVm = new CreateSingleVmExample(Context);
            createVm.Execute();

            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            var resourceGroup = subscription.GetResourceGroupOperations(Context.RgName).Get().Value;
            _ = resourceGroup.GetAvailabilitySetOperations(Context.VmName + "_aSet").Get().Value;
            var vnet = resourceGroup.GetVirtualNetworkOperations(Context.VmName + "_vnet").Get().Value;
            _ = vnet.GetSubnetOperations(Context.SubnetName).Get().Value;
            _ = resourceGroup.GetNetworkSecurityGroupOperations(Context.NsgName).Get().Value;
            _ = resourceGroup.GetNetworkInterfaceOperations($"{Context.VmName}_nic").Get().Value;
            _ = resourceGroup.GetVirtualMachineOperations(Context.VmName).Get().Value;
        }
    }
}
