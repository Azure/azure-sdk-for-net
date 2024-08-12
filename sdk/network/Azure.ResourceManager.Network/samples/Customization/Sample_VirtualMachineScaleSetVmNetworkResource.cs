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
    public partial class Sample_VirtualMachineScaleSetVmNetworkResource
    {
        // List virtual machine scale set vm network interfaces
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetNetworkInterfaces_ListVirtualMachineScaleSetVmNetworkInterfaces()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssVmNetworkInterfaceList.json
            // this example is just showing the usage of "VirtualMachineScaleSetVMs_ListNetworkInterfaces" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetVmNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetVmNetworkResource, please refer to the document of VirtualMachineScaleSetVmNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualMachineScaleSetName = "vmss1";
            string virtualmachineIndex = "1";
            ResourceIdentifier virtualMachineScaleSetVmResourceId = VirtualMachineScaleSetVmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName, virtualmachineIndex);
            VirtualMachineScaleSetVmNetworkResource virtualMachineScaleSetVmNetwork = client.GetVirtualMachineScaleSetVmNetworkResource(virtualMachineScaleSetVmResourceId);

            // invoke the operation and iterate over the result
            await foreach (NetworkInterfaceData data in virtualMachineScaleSetVmNetwork.GetAllNetworkInterfaceDataAsync())
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // ListVMSSVMPublicIP
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetPublicIPAddresses_ListVMSSVMPublicIP()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssVmPublicIpList.json
            // this example is just showing the usage of "VirtualMachineScaleSetVMs_ListPublicIPAddresses" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetVmNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetVmNetworkResource, please refer to the document of VirtualMachineScaleSetVmNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "vmss-tester";
            string virtualMachineScaleSetName = "vmss1";
            string virtualmachineIndex = "1";
            ResourceIdentifier virtualMachineScaleSetVmResourceId = VirtualMachineScaleSetVmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName, virtualmachineIndex);
            VirtualMachineScaleSetVmNetworkResource virtualMachineScaleSetVmNetwork = client.GetVirtualMachineScaleSetVmNetworkResource(virtualMachineScaleSetVmResourceId);

            // invoke the operation and iterate over the result
            string networkInterfaceName = "nic1";
            string ipConfigurationName = "ip1";
            await foreach (PublicIPAddressData data in virtualMachineScaleSetVmNetwork.GetAllPublicIPAddressDataAsync(networkInterfaceName, ipConfigurationName))
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Get virtual machine scale set network interface
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetNetworkInterface_GetVirtualMachineScaleSetNetworkInterface()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssNetworkInterfaceGet.json
            // this example is just showing the usage of "VirtualMachineScaleSets_GetNetworkInterface" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetVmNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetVmNetworkResource, please refer to the document of VirtualMachineScaleSetVmNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualMachineScaleSetName = "vmss1";
            string virtualmachineIndex = "1";
            ResourceIdentifier virtualMachineScaleSetVmResourceId = VirtualMachineScaleSetVmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName, virtualmachineIndex);
            VirtualMachineScaleSetVmNetworkResource virtualMachineScaleSetVmNetwork = client.GetVirtualMachineScaleSetVmNetworkResource(virtualMachineScaleSetVmResourceId);

            // invoke the operation
            string networkInterfaceName = "nic1";
            NetworkInterfaceData result = await virtualMachineScaleSetVmNetwork.GetNetworkInterfaceDataAsync(networkInterfaceName);

            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {result.Id}");
        }

        // List virtual machine scale set network interface ip configurations
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetIPConfigurations_ListVirtualMachineScaleSetNetworkInterfaceIpConfigurations()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssNetworkInterfaceIpConfigList.json
            // this example is just showing the usage of "VirtualMachineScaleSets_ListIpConfigurations" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetVmNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetVmNetworkResource, please refer to the document of VirtualMachineScaleSetVmNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualMachineScaleSetName = "vmss1";
            string virtualmachineIndex = "2";
            ResourceIdentifier virtualMachineScaleSetVmResourceId = VirtualMachineScaleSetVmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName, virtualmachineIndex);
            VirtualMachineScaleSetVmNetworkResource virtualMachineScaleSetVmNetwork = client.GetVirtualMachineScaleSetVmNetworkResource(virtualMachineScaleSetVmResourceId);

            // invoke the operation and iterate over the result
            string networkInterfaceName = "nic1";
            await foreach (NetworkInterfaceIPConfigurationData data in virtualMachineScaleSetVmNetwork.GetAllIPConfigurationDataAsync(networkInterfaceName))
            {
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Get virtual machine scale set network interface
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetIPConfiguration_GetVirtualMachineScaleSetNetworkInterface()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssNetworkInterfaceIpConfigGet.json
            // this example is just showing the usage of "VirtualMachineScaleSets_GetIpConfiguration" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetVmNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetVmNetworkResource, please refer to the document of VirtualMachineScaleSetVmNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string virtualMachineScaleSetName = "vmss1";
            string virtualmachineIndex = "2";
            ResourceIdentifier virtualMachineScaleSetVmResourceId = VirtualMachineScaleSetVmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName, virtualmachineIndex);
            VirtualMachineScaleSetVmNetworkResource virtualMachineScaleSetVmNetwork = client.GetVirtualMachineScaleSetVmNetworkResource(virtualMachineScaleSetVmResourceId);

            // invoke the operation
            string networkInterfaceName = "nic1";
            string ipConfigurationName = "ip1";
            NetworkInterfaceIPConfigurationData result = await virtualMachineScaleSetVmNetwork.GetIPConfigurationDataAsync(networkInterfaceName, ipConfigurationName);

            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {result.Id}");
        }

        // GetVMSSPublicIP
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetPublicIPAddress_GetVMSSPublicIP()
        {
            // Generated from example definition: specification/network/resource-manager/Microsoft.Network/stable/2023-05-01/examples/VmssPublicIpGet.json
            // this example is just showing the usage of "VirtualMachineScaleSets_GetPublicIPAddress" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this VirtualMachineScaleSetVmNetworkResource created on azure
            // for more information of creating VirtualMachineScaleSetVmNetworkResource, please refer to the document of VirtualMachineScaleSetVmNetworkResource
            string subscriptionId = "subid";
            string resourceGroupName = "vmss-tester";
            string virtualMachineScaleSetName = "vmss1";
            string virtualmachineIndex = "1";
            ResourceIdentifier virtualMachineScaleSetVmResourceId = VirtualMachineScaleSetVmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, virtualMachineScaleSetName, virtualmachineIndex);
            VirtualMachineScaleSetVmNetworkResource virtualMachineScaleSetVmNetwork = client.GetVirtualMachineScaleSetVmNetworkResource(virtualMachineScaleSetVmResourceId);

            // invoke the operation
            string networkInterfaceName = "nic1";
            string ipConfigurationName = "ip1";
            string publicIPAddressName = "pub1";
            PublicIPAddressData result = await virtualMachineScaleSetVmNetwork.GetPublicIPAddressDataAsync(networkInterfaceName, ipConfigurationName, publicIPAddressName);

            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {result.Id}");
        }
    }
}
