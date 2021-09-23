
# Quickstart Tutorial - Resource Management (Preview Libraries)

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
authentication. This document illustrates the most common scenario.

## Getting started

### Install the package

Install the Azure Compute management library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.ResourceManager.Compute -Version 1.0.0-beta.1
```

### Prerequisites

Set up a way to authenticate to Azure with Azure Identity.

Some options are:

- Through the [Azure CLI Login](https://docs.microsoft.com/cli/azure/authenticate-azure-cli).
- Via [Visual Studio](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio).
- Setting [Environment Variables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md).

More information and different authentication approaches using Azure Identity can be found in [this document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following:

```C# Snippet:Readme_AuthClient
using Azure.Identity;
using Azure.ResourceManager;

// Code omitted for brevity

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

### Understanding Azure Resource Hierarchy

In new management libraries, we no longer provide various clients like `ResourceManagementClient` or `ComputeMangementClient`. Instead, we adopt a hierarchical resource model. **Before you continue, make sure you go through the concepts of the Azure .NET SDK [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts).**

----

## Interacting with Azure Resources

Now that we are authenticated, we can use our `ArmClient` to make API calls. Let's demonstrate the hierarchical APIs by concrete examples.

For the examples below, you need the following namespaces:

```csharp
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
```

### Example: Managing Resource Groups

We can use the `ResourceGroupContainer` to perform operations on Resource Group. In the following code snippets, we will demonstrate how to manage Resource Groups.

#### Create a resource group

```csharp
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup container for that subscription
Subscription subscription = armClient.DefaultSubscription;
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupData rgData = new ResourceGroupData(location);
ResourceGroup resourceGroup = await rgContainer.CreateOrUpdateAsync(rgName, rgData);
```

#### Update a resource group

```csharp
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

#### List all resource groups

```csharp
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// Now we get a ResourceGroup container for that subscription
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With GetAllAsync(), we can get a list of the resources in the container
await foreach (ResourceGroup rg in rgContainer.GetAllAsync())
{
    Console.WriteLine(rg.Data.Name);
}
```

#### Delete a resource group

```csharp
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
await resourceGroup.DeleteAsync();
```

### Example: Managing Virtual Machines

We can use `VirtualMachineContainer` to perform operations on Virtual Machine. In the following code snippets, we will demonstrate how to manage Virtual Machine.

#### Create a virtual machine

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();
// Use the same location as the resource group
string vmName = "myVM";
VirtualMachineData input = new VirtualMachineData(resourceGroup.Data.Location)
{
    HardwareProfile = new HardwareProfile()
    {
        VmSize = VirtualMachineSizeTypes.StandardF2
    },
    OsProfile = new OSProfile()
    {
        AdminUsername = "adminUser",
        ComputerName = "myVM",
        LinuxConfiguration = new LinuxConfiguration()
        {
            DisablePasswordAuthentication = true,
            Ssh = new SshConfiguration()
            {
                PublicKeys = {
        new SshPublicKeyInfo()
        {
            Path = $"/home/adminUser/.ssh/authorized_keys",
            KeyData = "<value of the public ssh key>",
        }
    }
            }
        }
    },
    NetworkProfile = new NetworkProfile()
    {
        NetworkInterfaces =
        {
            new NetworkInterfaceReference()
            {
                Id = "/subscriptions/<subscriptionId>/resourceGroups/<rgName>/providers/Microsoft.Network/networkInterfaces/<nicName>",
                Primary = true,
            }
        }
    },
    StorageProfile = new StorageProfile()
    {
        OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
        {
            OsType = OperatingSystemTypes.Linux,
            Caching = CachingTypes.ReadWrite,
            ManagedDisk = new ManagedDiskParameters()
            {
                StorageAccountType = StorageAccountTypes.StandardLRS
            }
        },
        ImageReference = new ImageReference()
        {
            Publisher = "Canonical",
            Offer = "UbuntuServer",
            Sku = "16.04-LTS",
            Version = "latest",
        }
    }
};
VirtualMachineCreateOrUpdateOperation lro = await vmContainer.CreateOrUpdateAsync(vmName, input);
VirtualMachine vm = lro.Value;
```

#### List all virtual machines

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();
// With ListAsync(), we can get a list of the virtual machines in the container
AsyncPageable<VirtualMachine> response = vmContainer.GetAllAsync();
await foreach (VirtualMachine vm in response)
{
    Console.WriteLine(vm.Data.Name);
}
```

#### Delete a virtual machine

```csharp
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the virtual machine container from the resource group
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();
string vmName = "myVM";
VirtualMachine vm = await vmContainer.GetAsync(vmName);
await vm.DeleteAsync();
```

## Code Samples

More code samples for using the management library for .NET can be found in the following locations

- [.NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK&terms=managing%20using%20Azure%20.NET%20SDK)

## Need help?

- File an issue via [Github
  Issues](https://github.com/Azure/azure-sdk-for-net/issues) and
  make sure you add the "Preview" label to the issue
- Check [previous
  questions](https://stackoverflow.com/questions/tagged/azure+.net)
  or ask new ones on StackOverflow using azure and .NET tags.

## Contributing

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
