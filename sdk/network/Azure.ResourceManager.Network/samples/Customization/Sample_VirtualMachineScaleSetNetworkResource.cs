// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.Network.Samples
{
    public partial class Sample_VirtualMachineScaleSetNetworkResource
    {
        // List virtual machine scale set network interfaces
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetNetworkInterfaces_ListVirtualMachineScaleSetNetworkInterfaces()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssNetworkInterfaceList.json
            // this example is just showing the usage of "VirtualMachineScaleSets_ListNetworkInterfaces" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetNetworkResource, please refer to the document of VirtualMachineScaleSetNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualMachineScaleSetName = "vmss1";
            ResourceIdentifier virtualMachineScaleSetResourceId = VirtualMachineScaleSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName);
            VirtualMachineScaleSetNetworkResource virtualMachineScaleSetNetwork = client.GetVirtualMachineScaleSetNetworkResource(virtualMachineScaleSetResourceId);

            // invoke the operation and iterate over the result
            await foreach (NetworkInterfaceData data in virtualMachineScaleSetNetwork.GetAllNetworkInterfaceDataAsync())
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // ListVMSSPublicIP
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetPublicIPAddresses_ListVMSSPublicIP()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssPublicIpListAll.json
            // this example is just showing the usage of "VirtualMachineScaleSets_ListPublicIPAddresses" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetNetworkResource, please refer to the document of VirtualMachineScaleSetNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "vmss-tester";
            string virtualMachineScaleSetName = "vmss1";
            ResourceIdentifier virtualMachineScaleSetResourceId = VirtualMachineScaleSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName);
            VirtualMachineScaleSetNetworkResource virtualMachineScaleSetNetwork = client.GetVirtualMachineScaleSetNetworkResource(virtualMachineScaleSetResourceId);

            // invoke the operation and iterate over the result
            await foreach (PublicIPAddressData data in virtualMachineScaleSetNetwork.GetAllPublicIPAddressDataAsync())
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
