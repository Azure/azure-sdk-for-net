using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;
using System;
using Azure.Identity;


namespace Proto.Client
{
    class GenericResourceOperationsExample : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var rgOp = new ArmClient(new DefaultAzureCredential()).GetResourceGroupOperations(Context.SubscriptionId, Context.RgName);
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);
            var resourceGroup = subscription.GetResourceGroups().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            var aset = resourceGroup.GetAvailabilitySets().Construct("Aligned").CreateOrUpdate(Context.VmName + "_aSet").Value;
            string vnetName = Context.VmName + "_vnet";
            var vnet = resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").CreateOrUpdate(vnetName).Value;
            foreach (var genericOp in rgOp.GetAvailabilitySets().ListAsGenericResource(Context.VmName))
            {
                genericOp.Get();
            }

            foreach (var genericOp in rgOp.GetVirtualNetworks().ListAsGenericResource(Context.VmName))
            {
                genericOp.Get();
            }
            Console.WriteLine(subscription.ClientOptions.ApiVersions.TryGetApiVersion(VirtualNetwork.ResourceType));
        }
    }
}
