
Quickstart Tutorial - Resource Management (Preview Libraries)
=============================================================

We are excited to announce that a new set of management libraries are
now in Public Preview. Those packages share a number of new features
such as Azure Identity support, HTTP pipeline, error-handling.,etc, and
they also follow the new Azure SDK guidelines which create easy-to-use
APIs that are idiomatic, compatible, and dependable.

You can find the details of those new libraries
[here](https://azure.github.io/azure-sdk/releases/latest/#dotnet)

In this basic quickstart guide, we will walk you through how to
authenticate to Azure using the preview libraries and start interacting
with Azure resources. There are several possible approaches to
authentication. This document illustrates the most common scenario

Prerequisites
-------------

You will need the following values to authenticate to Azure

-   **Subscription ID**
-   **Client ID**
-   **Client Secret**
-   **Tenant ID**

These values can be obtained from the portal, here's the instructions:

### Get Subscription ID

1.  Login into your Azure account
2.  Select Subscriptions in the left sidebar
3.  Select whichever subscription is needed
4.  Click on Overview
5.  Copy the Subscription ID

### Get Client ID / Client Secret / Tenant ID

For information on how to get Client ID, Client Secret, and Tenant ID,
please refer to [this
document](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal)

### Setting Environment Variables

After you obtained the values, you need to set the following values as
your environment variables

-   `AZURE_CLIENT_ID`
-   `AZURE_CLIENT_SECRET`
-   `AZURE_TENANT_ID`
-   `AZURE_SUBSCRIPTION_ID`

To set the following environment variables on your development system:

Windows (Note: Administrator access is required)

1.  Open the Control Panel
2.  Click System Security, then System
3.  Click Advanced system settings on the left
4.  Inside the System Properties window, click the Environment
    Variables… button.
5.  Click on the property you would like to change, then click the Edit…
    button. If the property name is not listed, then click the New…
    button.

Linux-based OS :

    export AZURE_CLIENT_ID="__CLIENT_ID__"
    export AZURE_CLIENT_SECRET="__CLIENT_SECRET__"
    export AZURE_TENANT_ID="__TENANT_ID__"
    export AZURE_SUBSCRIPTION_ID="__SUBSCRIPTION_ID__"

Authentication and Creating Resource Management Client
------------------------------------------------------

Now that the environment is setup, all you need to do is to create an
authenticated client. Our default option is to use
**DefaultAzureCredential** and in this guide we have picked
**Resources** as our target service, but you can set it up similarly for
any other service that you are using. **For example, in order to manage Compute or Network resources, you would create a ``ComputeManagementClient`` or ``NetworkManagementClient``**

To authenticate to Azure and create a management client, simply do the
following:
```csharp
    using Azure.Identity;
    using Azure.ResourceManager.Resources;
    using Azure.ResourceManager.Resources.Models;
    using System;
    ...
    var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
    var resourceClient = new ResourcesManagementClient(subscriptionId, new DefaultAzureCredential());
    var resourceGroupsClient = resourceClient.ResourceGroups;
```
From this code snippet, we showed that in order to interact with Resources, we need to create a top-level client first (**ResourcesManagementClient**), then get the corresponding sub-resource client we are interested in, in this case we called **.ResourceGroups** to get a ResourceGroupsOperations

For more information and different authentication approaches using Azure
Identity can be found in [this document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

Interacting with Azure Resources
--------------------------------

Now that we are authenticated, we can use our management client to make API calls. Let's demonstrate management client's usage by showing concrete examples

Example: Managing Resource Groups
---------------------------------
We can use the Resource client (``Azure.ResourceManager.Resources.ResourcesManagementClient``) we have created to perform operations on Resource Group. In this example, we will show to manage Resource Groups.

***Create a resource group***

```csharp
    var location = "westus2";
    var resourceGroupName = "myResourceGroupName";
    var resourceGroup = new ResourceGroup(location);
    resourceGroup = await resourceGroupsClient.CreateOrUpdateAsync(resourceGroupName, resourceGroup);
```

***Update a resource group***

```csharp
    ...
    var newResourceGroup = new ResourceGroup(location);
    var resourceGroupName = "myResourceGroupName";
    var tags = new Dictionary<string,string>();
    tags.Add("environment","test");
    tags.Add("department","tech");
    newResourceGroup.Tags = tags;
    // Use existing resource group name and new resource group object
    newResourceGroup = await resourceGroupsClient.CreateOrUpdateAsync(resourceGroupName, newResourceGroup);
```


***List all resource groups***

```csharp
    AsyncPageable<ResourceGroup> response = resourceGroupsClient.ListAsync();
    await foreach (ResourceGroup rg in response)
    {
        Console.WriteLine(rg.Name);
    }
```

***Delete a resource group***

```csharp
    await resourceGroupsClient.StartDeleteAsync(groupName);
```

Example: Creating a Virtual Machine
-----------------------------------
Let's show a concrete example of how you would create a virtual machine using .NET SDK
```csharp
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace AzureCreateVMSample
{
    /// <summary>
    /// Create a Virtual Machine
    /// </summary>
    public class CreateVMSample
    {
        public static async Task CreateVmAsync(
            string subscriptionId,
            string resourceGroupName,
            string location,
            string vmName)
        {
            var computeClient = new ComputeManagementClient(subscriptionId, new DefaultAzureCredential());
            var networkClient = new NetworkManagementClient(subscriptionId, new DefaultAzureCredential());
            var resourcesClient = new ResourcesManagementClient(subscriptionId, new DefaultAzureCredential());
 
            var virtualNetworksClient = networkClient.VirtualNetworks;
            var networkInterfaceClient = networkClient.NetworkInterfaces;
            var publicIpAddressClient = networkClient.PublicIPAddressses;
            var availabilitySetsClient = computeClient.AvailabilitySets;
            var virtualMachinesClient = computeClient.VirtualMachines;
            var resourceGroupClient = resourcesClient.ResourceGroups;

            // Create Resource Group
            var resourceGroup = new ResourceGroup(location);
            resourceGroup = await resourceGroupClient.CreateOrUpdateAsync(resourceGroupName, resourceGroup);

            // Create AvailabilitySet
            var availabilitySet = new AvailabilitySet(location)
            {
                PlatformUpdateDomainCount = 5,
                PlatformFaultDomainCount = 2,
                Sku = new Sku() { Name = "Aligned" }  // TODO. Verify new codegen on AvailabilitySetSkuTypes.Aligned
            };

            availabilitySet = await availabilitySetsClient.CreateOrUpdateAsync(resourceGroupName, vmName + "_aSet", availabilitySet);

            // Create IP Address
            var ipAddress = new PublicIPAddress()
            {
                PublicIPAddressVersion = IPVersion.IPv4,
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                Location = location,
            };

            ipAddress = await publicIpAddressClient.StartCreateOrUpdate(resourceGroupName, vmName + "_ip", ipAddress)
                .WaitForCompletionAsync();

            // Create VNet
            var vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16" } },
                Subnets = new List<Subnet>()
                {
                    new Subnet()
                    {
                        Name = "mySubnet",
                        AddressPrefix = "10.0.0.0/24",
                    }
                },
            };

            vnet = await virtualNetworksClient
                .StartCreateOrUpdate(resourceGroupName, vmName + "_vent", vnet)
                .WaitForCompletionAsync();

            // Create Network interface
            var nic = new NetworkInterface()
            {
                Location = location,
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = "Primary",
                        Primary = true,
                        Subnet = new Subnet() { Id = vnet.Subnets.First().Id },
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new PublicIPAddress() { Id = ipAddress.Id }
                    }
                }
            };

            nic = await networkInterfaceClient
                .StartCreateOrUpdate(resourceGroupName, vmName + "_nic", nic)
                .WaitForCompletionAsync();

            var vm = new VirtualMachine(location)
            {
                NetworkProfile = new Compute.Models.NetworkProfile { NetworkInterfaces = new[] { new NetworkInterfaceReference() { Id = nic.Id } } },
                OsProfile = new OSProfile
                {
                    ComputerName = "testVM",
                    AdminUsername = "username",
                    AdminPassword = "(YourPassword)",
                    LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVMAgent = true }
                },
                StorageProfile = new StorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Offer = "UbuntuServer",
                        Publisher = "Canonical",
                        Sku = "18.04-LTS",
                        Version = "latest"
                    },
                    DataDisks = new List<DataDisk>()
                },
                HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
            };
            vm.AvailabilitySet.Id = availabilitySet.Id;

            var operaiontion = await virtualMachinesClient.StartCreateOrUpdateAsync(resourceGroupName, vmName, vm);
            var vm = (await operaiontion.WaitForCompletionAsync()).Value;
        }
    }
}

```

Driver program

```csharp
using System;
using System.Threading.Tasks;

namespace AzureCreateVMSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
            var location = "westus2";

            await CreateVMSample.CreateVmAsync(subscriptionId, "myResourceGroupName", location, "myVirtualMachine");
        }
    }
}
```
        
Need help?
----------

-   File an issue via [Github
    Issues](https://github.com/Azure/azure-sdk-for-net/issues) and
    make sure you add the "Preview" label to the issue
-   Check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.

Contributing
------------

For details on contributing to this repository, see the contributing
guide.

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the Microsoft Open Source Code of Conduct. For
more information see the Code of Conduct FAQ or contact
<opencode@microsoft.com> with any additional questions or comments.
