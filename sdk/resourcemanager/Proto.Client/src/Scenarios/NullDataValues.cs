using Azure.ResourceManager.Core;
using Proto.Compute;
using Proto.Network;

namespace Proto.Client
{
    class NullDataValues : Scenario
    {
        public override void Execute()
        {
            var resourceGroupData = new ResourceGroupData("East US");
            var nic = new Azure.ResourceManager.Network.Models.NetworkInterface();
            var networkInterfaceData = new NetworkInterfaceData(nic);
            var aset = new Azure.ResourceManager.Compute.Models.AvailabilitySet("East US");
            var availabilitySet = new AvailabilitySetData(aset);
        }
    }
}
