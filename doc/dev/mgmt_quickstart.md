
# Quickstart Tutorial - Resource Management

We are excited to announce that a new set of management libraries are
released now. Those packages share a number of new features
such as Azure Identity support, HTTP pipeline, error-handling.,etc, and
they also follow the new Azure SDK guidelines which create easy-to-use
APIs that are idiomatic, compatible, and dependable.

You can find the details of those new libraries
[here](https://azure.github.io/azure-sdk/releases/latest/mgmt/dotnet.html)

In this basic quickstart guide, we will walk you through how to
authenticate to Azure using the libraries and start interacting
with Azure resources. There are several possible approaches to
authentication. This document illustrates the most common scenario.

## Install the package

Install the Azure Resources management core library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager
```

## Prerequisites
Set up a way to authenticate to Azure with Azure Identity.

Some options are:
- Through the [Azure CLI Login](https://docs.microsoft.com/cli/azure/authenticate-azure-cli).
- Via [Visual Studio](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio).
- Setting [Environment Variables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md).

More information and different authentication approaches using Azure Identity can be found in [this document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

## Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following:

```C# Snippet:Readme_AuthClient
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;

// Code omitted for brevity

ArmClient client = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts
### Understanding Azure Resource Hierarchy

To reduce both the number of clients needed to perform common tasks and the amount of redundant parameters that each of those clients take, we have introduced an object hierarchy in the SDK that mimics the object hierarchy in Azure. Each resource client in the SDK has methods to access the resource clients of its children that is already scoped to the proper subscription and resource group.

To accomplish this, we're introducing 3 standard types for all resources in Azure:

### **[Resource]Resource.cs**

This represents a full resource client object which contains a **Data** property exposing the details as a **[Resource]Data** type.
It also has access to all of the operations on that resource without needing to pass in scope parameters such as subscription ID or resource name.  This makes it very convenient to directly execute operations on the result of list calls
since everything is returned as a full resource client now.

```C# Snippet:Readme_LoopVms
ArmClient client = new ArmClient(new DefaultAzureCredential());
string resourceGroupName = "myResourceGroup";
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
await foreach (VirtualMachineResource virtualMachine in resourceGroup.GetVirtualMachines())
{
    //previously we would have to take the resourceGroupName and the vmName from the vm object
    //and pass those into the powerOff method as well as we would need to execute that on a separate compute client
    await virtualMachine.PowerOffAsync(WaitUntil.Completed);
}
```

### **[Resource]Data.cs**

This represents the model that makes up a given resource. Typically, this is the response data from a service call such as HTTP GET and provides details about the underlying resource. Previously, this was represented by a **Model** class.

### **[Resource]Collection.cs**

This represents the operations you can perform on a collection of resources belonging to a specific parent resource.
This object provides most of the logical collection operations.

| Collection Behavior | Collection Method |
|-|-|
| Iterate/List | GetAll() |
| Index | Get(string name) |
| Add | CreateOrUpdate(string name, [Resource]Data data) |
| Contains | Exists(string name) |

For most things, the parent will be a **ResourceGroup**. However, each parent / child relationship is represented this way. For example, a **Subnet** is a child of a **VirtualNetwork** and a **ResourceGroup** is a child of a **Subscription**.

## Putting it all together
Imagine that our company requires all virtual machines to be tagged with the owner. We're tasked with writing a program to add the tag to any missing virtual machines in a given resource group.

 ```C# Snippet:Readme_PuttingItAllTogether
// First we construct our client
ArmClient client = new ArmClient(new DefaultAzureCredential());

// Next we get a resource group object
// ResourceGroupResource is a [Resource] object from above
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
ResourceGroupResource resourceGroup = await resourceGroups.GetAsync("myRgName");

// Next we get the collection for the virtual machines
// vmCollection is a [Resource]Collection object from above
VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();

// Next we loop over all vms in the collection
// Each vm is a [Resource] object from above
await foreach (VirtualMachineResource virtualMachine in virtualMachines)
{
    // We access the [Resource]Data properties from vm.Data
    if (!virtualMachine.Data.Tags.ContainsKey("owner"))
    {
        // We can also access all operations from vm since it is already scoped for us
        await virtualMachine.AddTagAsync("owner", "tagValue");
    }
}
```

## Structured Resource Identifier
Resource IDs contain useful information about the resource itself, but they are plain strings that have to be parsed. Instead of implementing your own parsing logic, you can use a `ResourceIdentifier` object which will do the parsing for you: `new ResourceIdentifier("myid");`.

### Example: Parsing an ID using a ResourceIdentifier object 
```C# Snippet:Readme_CastToSpecificType
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet");
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroupResource: {id.ResourceGroupName}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

## Managing Existing Resources By Id
Performing operations on resources that already exist is a common use case when using the management client libraries. In this scenario you usually have the identifier of the resource you want to work on as a string. Although the new object hierarchy is great for provisioning and working within the scope of a given parent, it is not the most efficient when it comes to this specific scenario.  

Here is an example how you can access an `AvailabilitySet` object and manage it directly with its id: 
```C# Snippet:Readme_ManageAvailabilitySetOld
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet");
// We construct a new client to work with
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Next we get the collection of subscriptions
SubscriptionCollection subscriptions = client.GetSubscriptions();
// Next we get the specific subscription this resource belongs to
SubscriptionResource subscription = await subscriptions.GetAsync(id.SubscriptionId);
// Next we get the collection of resource groups that belong to that subscription
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
// Next we get the specific resource group this resource belongs to
ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(id.ResourceGroupName);
// Next we get the collection of availability sets that belong to that resource group
AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
// Finally we get the resource itself
// Note: for this last step in this example, Azure.ResourceManager.Compute is needed
AvailabilitySetResource availabilitySet = await availabilitySets.GetAsync(id.Name);
```

This approach required a lot of code and 3 API calls to Azure. The same can be done with less code and without any API calls by using extension methods that we have provided on the client itself. These extension methods allow you to pass in a resource identifier and retrieve a scoped resource client. The object returned is a *[Resource]* mentioned above, since it has not reached out to Azure to retrieve the data yet the Data property will be null.

So, the previous example would end up looking like this:

```C# Snippet:Readme_ManageAvailabilitySetNow
ResourceIdentifier resourceId = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet");
// We construct a new client to work with
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Next we get the AvailabilitySetResource resource client from the client
// The method takes in a ResourceIdentifier but we can use the implicit cast from string
AvailabilitySetResource availabilitySet = client.GetAvailabilitySetResource(resourceId);
// At this point availabilitySet.Data will be null and trying to access it will throw
// If we want to retrieve the objects data we can simply call get
availabilitySet = await availabilitySet.GetAsync();
// we now have the data representing the availabilitySet
Console.WriteLine(availabilitySet.Data.Name);
```

We also provide an option that if you only know the pieces that make up the `ResourceIdentifier` each resource provides a static method to construct the full string from those pieces.
The above example would then look like this.
```C# Snippet:Readme_ManageAvailabilitySetPieces
string subscriptionId = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
string resourceGroupName = "workshop2021-rg";
string availabilitySetName = "ws2021availSet";
ResourceIdentifier resourceId = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, availabilitySetName);
// We construct a new client to work with
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Next we get the AvailabilitySetResource resource client from the client
// The method takes in a ResourceIdentifier but we can use the implicit cast from string
AvailabilitySetResource availabilitySet = client.GetAvailabilitySetResource(resourceId);
// At this point availabilitySet.Data will be null and trying to access it will throw
// If we want to retrieve the objects data we can simply call get
availabilitySet = await availabilitySet.GetAsync();
// we now have the data representing the availabilitySet
Console.WriteLine(availabilitySet.Data.Name);
```

## Check if a [Resource] exists

If you are not sure if a resource you want to get exists, or you just want to check if it exists, you can use `Exists()` method, which can be invoked from any [Resource]Collection class.

`Exists()` and `ExistsAsync()` return `Response<bool>` where the bool will be false if the specified resource does not exist.  Both of these methods still give you access to the underlying raw response.

Before these methods were introduced you would need to catch the `RequestFailedException` and inspect the status code for 404.

```C# Snippet:Readme_OldExistsRG
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
string resourceGroupName = "myRgName";

try
{
    ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
    // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Resource Group {resourceGroupName} does not exist.");
}
```

Now with these convenience methods we can simply do the following.

```C# Snippet:Readme_ExistsRG
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
string resourceGroupName = "myRgName";

bool exists = await resourceGroups.ExistsAsync(resourceGroupName);

if (exists)
{
    Console.WriteLine($"Resource Group {resourceGroupName} exists.");

    // We can get the resource group now that we know it exists.
    // This does introduce a small race condition where resource group could have been deleted between the check and the get.
    ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
}
else
{
    Console.WriteLine($"Resource Group {resourceGroupName} does not exist.");
}
```

## Examples

### Create a resource group
```C# Snippet:Managing_Resource_Groups_CreateAResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroupResource collection for that subscription
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string resourceGroupName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupData resourceGroupData = new ResourceGroupData(location);
ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
ResourceGroupResource resourceGroup = operation.Value;
```

### List all resource groups
```C# Snippet:Managing_Resource_Groups_ListAllResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
// Now we get a ResourceGroupResource collection for that subscription
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
// We can then iterate over this collection to get the resources in the collection
await foreach (ResourceGroupResource resourceGroup in resourceGroups)
{
    Console.WriteLine(resourceGroup.Data.Name);
}
```

### Update a resource group
```C# Snippet:Managing_Resource_Groups_UpdateAResourceGroup
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
string resourceGroupName = "myRgName";
ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

### Delete a resource group
```C# Snippet:Managing_Resource_Groups_DeleteResourceGroup
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
string resourceGroupName = "myRgName";
ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupName);
await resourceGroup.DeleteAsync(WaitUntil.Completed);
```

## Code Samples

More code samples for using the management library for .NET can be found in the following locations

- [.NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK&terms=managing%20using%20Azure%20.NET%20SDK)

## Need help?

- File an issue via [Github
  Issues](https://github.com/Azure/azure-sdk-for-net/issues) and
  make sure you add the "Mgmt" label to the issue
- Check [previous
  questions](https://stackoverflow.com/questions/tagged/azure+.net)
  or ask new ones on StackOverflow using azure and .NET tags.

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
