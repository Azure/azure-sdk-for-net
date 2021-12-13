# Azure ResourceManager client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), which provide core capabilities that are shared amongst all Azure SDKs, including:

- The intuitive Azure Identity library.
- An HTTP pipeline with custom policies.
- Error handling.
- Distributed tracing.

## Getting started 

### Install the package

Install the Azure Resources management library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.ResourceManager -Version 1.0.0-beta.6
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
using Azure.ResourceManager.Resources;
using System;
using System.Threading.Tasks;

// Code omitted for brevity

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts
### Understanding Azure Resource Hierarchy

To reduce both the number of clients needed to perform common tasks and the amount of redundant parameters that each of those clients take, we have introduced an object hierarchy in the SDK that mimics the object hierarchy in Azure. Each resource client in the SDK has methods to access the resource clients of its children that is already scoped to the proper subscription and resource group.

To accomplish this, we're introducing 3 standard types for all resources in Azure:

### **[Resource].cs**

This represents a full resource client object which contains a **Data** property exposing the details as a **[Resource]Data** type.
It also has access to all of the operations on that resource without needing to pass in scope parameters such as subscription ID or resource name.  This makes it very convenient to directly execute operations on the result of list calls
since everything is returned as a full resource client now.

```C#
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
string rgName = "myResourceGroup";
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroup rg = await subscription.GetResourceGroups().GetAsync(rgName);
await foreach (VirtualMachine vm in rg.GetVirtualMachines().GetAllAsync())
{
    //previously we would have to take the resourceGroupName and the vmName from the vm object
    //and pass those into the powerOff method as well as we would need to execute that on a separate compute client
    await vm.StartPowerOff().WaitForCompletionAsync();
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
| Contains | CheckIfExists(string name) |
| TryGet | GetIfExists(string name) |

For most things, the parent will be a **ResourceGroup**. However, each parent / child relationship is represented this way. For example, a **Subnet** is a child of a **VirtualNetwork** and a **ResourceGroup** is a child of a **Subscription**.

## Putting it all together
Imagine that our company requires all virtual machines to be tagged with the owner. We're tasked with writing a program to add the tag to any missing virtual machines in a given resource group.

 ```C#
// First we construct our armClient
var armClient = new ArmClient(new DefaultAzureCredential());

// Next we get a resource group object
// ResourceGroup is a [Resource] object from above
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

// Next we get the collection for the virtual machines
// vmCollection is a [Resource]Collection object from above
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();

// Next we loop over all vms in the collection
// Each vm is a [Resource] object from above
await foreach(VirtualMachine vm in vmCollection)
{
    // We access the [Resource]Data properties from vm.Data
    if(!vm.Data.Tags.ContainsKey("owner"))
    {
        // We can also access all operations from vm since it is already scoped for us
        await vm.StartAddTag("owner", GetOwner()).WaitForCompletionAsync();
    }
}
 ```

## Structured Resource Identifier
Resource IDs contain useful information about the resource itself, but they are plain strings that have to be parsed. Instead of implementing your own parsing logic, you can use a `ResourceIdentifier` object which will do the parsing for you: `new ResourceIdentifer("myid");`.

### Example: Parsing an ID using a ResourceIdentifier object 
```C# Snippet:Readme_CastToSpecificType
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
ResourceIdentifier id = new ResourceIdentifier(resourceId);
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```
However, keep in mind that some of those properties could be null. You can usually tell by the id string itself which type a resource ID is, but if you are unsure, check if the properties are null or use the Try methods to retrieve the values as it's shown below:

### Example: ResourceIdentifier TryGet methods 
```C# Snippet:Readme_CastToBaseResourceIdentifier
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet";
ResourceIdentifier id = new ResourceIdentifier(resourceId);
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroup: {id.ResourceGroupName}");
// Parent is only null when we reach the top of the chain which is a Tenant
Console.WriteLine($"Vnet: {id.Parent.Name}");
// Name will never be null
Console.WriteLine($"Subnet: {id.Name}");
```

## Managing Existing Resources By Id
Performing operations on resources that already exist is a common use case when using the management client libraries. In this scenario you usually have the identifier of the resource you want to work on as a string. Although the new object hierarchy is great for provisioning and working within the scope of a given parent, it is not the most efficient when it comes to this specific scenario.  

Here is an example how you to access an `AvailabilitySet` object and manage it directly with its id: 
```C#
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute;
using System;
using System.Threading.Tasks;

// Code omitted for brevity

string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet";
ResourceIdentifier id = new ResourceIdentifier(resourceId);
// We construct a new armClient to work with
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Next we get the specific subscription this resource belongs to
Subscription subscription = await armClient.GetSubscriptions().GetAsync(id.SubscriptionId);
// Next we get the specific resource group this resource belongs to
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(id.ResourceGroupName);
// Finally we get the resource itself
// Note: for this last step in this example, Azure.ResourceManager.Compute is needed
AvailabilitySet availabilitySet = await resourceGroup.GetAvailabilitySets().GetAsync(id.Name);
```

This approach required a lot of code and 3 API calls to Azure. The same can be done with less code and without any API calls by using extension methods that we have provided on the client itself. These extension methods allow you to pass in a resource identifier and retrieve a scoped resource client. The object returned is a *[Resource]* mentioned above, since it has not reached out to Azure to retrieve the data yet the Data property will be null.

So, the previous example would end up looking like this:

```C#
string resourceId = "/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Compute/availabilitySets/ws2021availSet";
// We construct a new armClient to work with
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Next we get the AvailabilitySet resource client from the armClient
// The method takes in a ResourceIdentifier but we can use the implicit cast from string
AvailabilitySet availabilitySet = armClient.GetAvailabilitySet(resourceId);
// At this point availabilitySet.Data will be null and trying to access it will throw
// If we want to retrieve the objects data we can simply call get
availabilitySet = await availabilitySet.GetAsync();
// we now have the data representing the availabilitySet
Console.WriteLine(availabilitySet.Data.Name);
```

## Check if a [Resource] exists

If you are not sure if a resource you want to get exists, or you just want to check if it exists, you can use `GetIfExists()` or `CheckIfExists()` methods, which can be invoked from any [Resource]Collection class.

`GetIfExists()` and `GetIfExistsAsync()` return a `Response<T>` where T is null if the specified resource does not exist. On the other hand, `CheckIfExists()` and `CheckIfExistsAsync()` return `Response<bool>` where the bool will be false if the specified resource does not exist.  Both of these methods still give you access to the underlying raw response.

Before these methods were introduced you would need to catch the `RequestFailedException` and inspect the status code for 404.

```C# Snippet:Readme_OldCheckIfExistsRG
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";

try
{
    ResourceGroup myRG = await subscription.GetResourceGroups().GetAsync(rgName);
    // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Resource Group {rgName} does not exist.");
}
```

Now with these convenience methods we can simply do the following.

```C# Snippet:Readme_CheckIfExistssRG
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";

bool exists = await subscription.GetResourceGroups().CheckIfExistsAsync(rgName);

if (exists)
{
    Console.WriteLine($"Resource Group {rgName} exists.");

    // We can get the resource group now that we know it exists.
    // This does introduce a small race condition where resource group could have been deleted between the check and the get.
    ResourceGroup myRG = await subscription.GetResourceGroups().GetAsync(rgName);
}
else
{
    Console.WriteLine($"Resource Group {rgName} does not exist.");
}
```

Another way to do this is by using `GetIfExists()` which will avoid the race condition mentioned above:

```C# Snippet:Readme_TryGetRG
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";

ResourceGroup myRG = await subscription.GetResourceGroups().GetIfExistsAsync(rgName);

if (myRG == null)
{
    Console.WriteLine($"Resource Group {rgName} does not exist.");
}
else
{
    // At this point, we are sure that myRG is a not null Resource Group, so we can use this object to perform any operations we want.
}
```

## Examples

### Create a resource group
```C# Snippet:Managing_Resource_Groups_CreateAResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupData rgData = new ResourceGroupData(location);
ResourceGroupCreateOrUpdateOperation operation = await rgCollection.CreateOrUpdateAsync(rgName, rgData);
ResourceGroup resourceGroup = operation.Value;
```

### List all resource groups
```C# Snippet:Managing_Resource_Groups_ListAllResourceGroup
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
// Now we get a ResourceGroup collection for that subscription
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With GetAllAsync(), we can get a list of the resources in the collection
await foreach (ResourceGroup rg in rgCollection.GetAllAsync())
{
    Console.WriteLine(rg.Data.Name);
}
```

### Update a resource group
```C# Snippet:Managing_Resource_Groups_UpdateAResourceGroup
// Note: Resource group named 'myRgName' should exist for this example to work.
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
resourceGroup = await resourceGroup.AddTagAsync("key", "value");
```

### Delete a resource group
```C# Snippet:Managing_Resource_Groups_DeleteResourceGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myRgName";
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
await resourceGroup.DeleteAsync();
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager/samples) we have available.

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).

## Next steps
### More sample code

- [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/Sample2_ManagingResourceGroups.md)
- [Creating a Virtual Network](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/Sample3_CreatingAVirtualNetwork.md)
- [.NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK)

### Additional Documentation
If you are migrating from the old SDK to this preview, check out this [Migration guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/MigrationGuide.md).

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md).

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
