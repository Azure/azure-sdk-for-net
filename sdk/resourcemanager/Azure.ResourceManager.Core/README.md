# Azure ResourceManager Core client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), which provide core capabilities that are shared amongst all Azure SDKs, including:

- The intuitive Azure Identity library.
- An HTTP pipeline with custom policies.
- Error handling.
- Distributed tracing.

## Getting started 

### Install the package

Install the Azure Resources management core library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.ResourceManager.Core -Version 1.0.0-beta.1
```

### Prerequisites
Set up a way to authenticate to Azure with Azure Identity.

Some options are:
- Through the [Azure CLI Login](https://docs.microsoft.com/cli/azure/authenticate-azure-cli).
- Via [Visual Studio](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio).
- Setting [Environment Variables](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/docs/AuthUsingEnvironmentVariables.md).

More information and different authentication approaches using Azure Identity can be found in [this document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following:

```csharp
using Azure.Identity;
using Azure.ResourceManager.Core;
using System;
    
// code omitted for brevity
    
var armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts
### Understanding Azure Resource Hierarchy

To reduce both the number of clients needed to perform common tasks and the amount of redundant parameters that each of those clients take, we have introduced an object hierarchy in the SDK that mimics the object hierarchy in Azure. Each resource client in the SDK has methods to access the resource clients of its children that is already scoped to the proper subscription and resource group.

To accomplish this, we're introducing 4 standard types for all resources in Azure:

#### **[Resource]Data**
This represents the data that makes up a given resource. Typically, this is the response data from a service call such as HTTP GET and provides details about the underlying resource. Previously, this was represented by a **Model** class.

#### **[Resource]Operations**

This represents a service client that's scoped to a particular resource. You can directly execute all operations on that client without needing to pass in scope parameters such as subscription ID or resource name.

#### **[Resource]Container**

This represents the operations you can perform on a collection of resources belonging to a specific parent resource.
This mainly consists of List or Create operations. For most things, the parent will be a **ResourceGroup**. However, each parent / child relationship is represented this way. For example, a **Subnet** is a child of a **VirtualNetwork** and a **ResourceGroup** is a child of a **Subscription**.

#### **[Resource]**

This represents a full resource object which contains a **Data** property exposing the details as a **[Resource]Data** type.
It also has access to all of the operations and like the **[Resource]Operations** object is already scoped
to a specific resource in Azure.

## Examples
### Add a tag to a virtual machine
Imagine that our company requires all virtual machines to be tagged with the owner. We're tasked with writing a program to add the tag to any missing virtual machines in a given resource group.

 ```csharp
// First we construct our armClient
var armClient = new ArmClient(new DefaultAzureCredential());

// Next we get a resource group object
// ResourceGroup is a [Resource] object from above
ResourceGroup resourceGroup = await armClient.DefaultSubscription.GetResourceGroups().GetAsync("myRgName");

// Next we get the container for the virtual machines
// vmContainer is a [Resource]Container object from above
VirtualMachineContainer vmContainer = resourceGroup.GetVirtualMachines();

// Next we loop over all vms in the container
// Each vm is a [Resource] object from above
await foreach(VirtualMachine vm in vmContainer.ListAsync())
{
    // We access the [Resource]Data properties from vm.Data
    if(!vm.Data.Tags.ContainsKey("owner"))
    {
        // We can also access all [Resource]Operations from vm since it is already scoped for us
        await vm.StartAddTag("owner", GetOwner()).WaitForCompletionAsync();
    }
}
 ```

### Create a resource group
```csharp
// First, initialize the ArmClient and get the default subscription
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
// Now we get a ResourceGroup container for that subscription
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroup resourceGroup = await rgContainer.CreateAsync(rgName);
```

### List all resource groups
```csharp
// First, initialize the ArmClient and get the default subscription
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;

// Now we get a ResourceGroup container for that subscription
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

// With ListAsync(), we can get a list of the resources in the container
AsyncPageable<ResourceGroup> response = rgContainer.ListAsync();
await foreach (ResourceGroup rg in response)
{
    Console.WriteLine(rg.Data.Name);
}
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/samples) we have available.

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).
## Next steps
### More sample code

- [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/samples/Sample2_ManagingResourceGroups.md)
- [Creating a Virtual Network](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/samples/Sample3_CreatingAVirtualNetwork.md)
- [.NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK)

### Additional Documentation
For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide](https://github.com/Azure/azure-sdk-for-net/blob/feature/mgmt-track2/sdk/resourcemanager/Azure.ResourceManager.Core/docs/CONTRIBUTING.md).

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
