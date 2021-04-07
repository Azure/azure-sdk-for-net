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
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);

            var resourceGroup = subscription.GetResourceGroups().Get(Context.RgName).Value;
            _ = resourceGroup.GetAvailabilitySets().Get(Context.VmName + "_aSet").Value;
            var vnet = resourceGroup.GetVirtualNetworks().Get(Context.VmName + "_vnet").Value;
            _ = vnet.GetSubnets().Get(Context.SubnetName).Value;
            _ = resourceGroup.GetNetworkSecurityGroups().Get(Context.NsgName).Value;
            _ = resourceGroup.GetNetworkInterfaces().Get($"{Context.VmName}_nic").Value;
            _ = resourceGroup.GetVirtualMachines().Get(Context.VmName).Value;
        }
    }
}
