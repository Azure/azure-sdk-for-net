# Microsoft Azure Resource Manager client library for .NET

Microsoft Azure Resource Manager is the deployment and management service for Azure. It provides a management layer that enables you to create, update, and delete resources in your Azure account.

This library provides resource group and resource management capabilities for Microsoft Azure.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Microsoft Azure Resources management core library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager
```

### Prerequisites

- You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

- Set up a way to authenticate to Azure with Azure Identity.

  Some options are:
    - Through the [Azure CLI sign in](https://learn.microsoft.com/cli/azure/authenticate-azure-cli).
    - Via [Visual Studio](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#authenticating-via-visual-studio).
    - Setting [Environment Variables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md).

    More information and different authentication approaches using Azure Identity can be found in [this document](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Authenticate the Client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, in order to interact with resources, only one top-level `ArmClient` has to be created.

To authenticate to Azure and create an `ArmClient`, do the following code:

```C# Snippet:Readme_AuthClient_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
```
```C# Snippet:Readme_AuthClient
ArmClient client = new ArmClient(new DefaultAzureCredential());
```

Note: if you want to authenticate with the azure in China, you can use the following code:
```C# Snippet:Readme_AuthClientChina
// Please replace the following placeholders with your Azure information
string tenantId = "your-tenant-id";
string clientId = "your-client-id";
string clientSecret = "your-client-secret";
string subscriptionId = "your-subscription-id";
//ArmClientOptions to set the Azure China environment
ArmClientOptions armOptions = new ArmClientOptions { Environment = ArmEnvironment.AzureChina };
// AzureAuthorityHosts to set the Azure China environment
Uri authorityHost = AzureAuthorityHosts.AzureChina;
// Create ClientSecretCredential for authentication
TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions { AuthorityHost = authorityHost });
// Create the Azure Resource Manager client
ArmClient client = new ArmClient(credential, subscriptionId, armOptions);
```

More documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

### Understanding Azure Resource Hierarchy

To reduce both the number of clients needed to perform common tasks, and the number of redundant parameters that each of those clients take, we've introduced an object hierarchy in the SDK that mimics the object hierarchy in Azure. Each resource client in the SDK has methods to access the resource clients of its children that are already scoped to the proper subscription and resource group.

To accomplish this goal, we're introducing three standard types for all resources in Azure:

### **[Resource]Resource.cs**

This class represents a full resource client object that contains a **Data** property exposing the details as a **[Resource]Data** type.
It also has access to all of the operations on that resource without needing to pass in scope parameters such as subscription ID or resource name. This resource class makes it convenient to directly execute operations on the result of list calls
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

This class represents the model that makes up a given resource. Typically, this class is the response data from a service call such as HTTP GET and provides details about the underlying resource. Previously, this class was represented by a **Model** class.

### **[Resource]Collection.cs**

This class represents the operations you can perform on a collection of resources belonging to a specific parent resource.
This class provides most of the logical collection operations.

| Collection Behavior | Collection Method |
|-|-|
| Iterate/List | GetAll() |
| Index | Get(string name) |
| Add | CreateOrUpdate(string name, [Resource]Data data) |
| Contains | Exists(string name) |

For most things, the parent will be a **ResourceGroup**. For example, a **Subnet** is a child of a **VirtualNetwork** and a **ResourceGroup** is a child of a **Subscription**.

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
Resource IDs contain useful information about the resource itself, but they're plain strings that have to be parsed. Instead of implementing your own parsing logic, you can use a `ResourceIdentifier` object that will do the parsing for you: `new ResourceIdentifier("myid");`.

### Example: Parsing an ID using a ResourceIdentifier object 
```C# Snippet:Readme_CastToSpecificType
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee/resourceGroups/workshop2021-rg/providers/Microsoft.Network/virtualNetworks/myVnet/subnets/mySubnet");
Console.WriteLine($"Subscription: {id.SubscriptionId}");
Console.WriteLine($"ResourceGroupResource: {id.ResourceGroupName}");
Console.WriteLine($"Vnet: {id.Parent.Name}");
Console.WriteLine($"Subnet: {id.Name}");
```

## Managing Existing Resources by Resource Identifier
Performing operations on resources that already exist is a common use case when using the management client libraries. In this scenario, you usually have the identifier of the resource you want to work on as a string. Although the new object hierarchy is great for provisioning, and working within the scope of a given parent, it isn't the most efficient when it comes to this specific scenario.  

Here's an example how you can access an `AvailabilitySet` object and manage it directly with its ID: 
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

This approach required much code and three API calls to Azure. The same can be done with less code and without any API calls by using extension methods that we've provided on the client itself. These extension methods allow you to pass in a resource identifier and retrieve a scoped resource client. The object returned is a *[Resource]* mentioned above, since it hasn't reached out to Azure to retrieve the data yet the Data property will be null.

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

If you aren't sure if a resource you want to get exists, or you just want to check if it exists, you can use `Exists()` method, which can be invoked from any [Resource]Collection class.

`Exists()` and `ExistsAsync()` return `Response<bool>` where the bool will be false if the specified resource doesn't exist.  Both of these methods still give you access to the underlying raw response.

Before these methods were introduced, you would need to catch the `RequestFailedException` and inspect the status code for 404.

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

Now with these convenience methods we can do the following code.

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
### Get GenericResource List
```C# Snippet:Get_GenericResource_List
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource sub = client.GetDefaultSubscription();
AsyncPageable<GenericResource> networkAndVmWithTestInName = sub.GetGenericResourcesAsync(
    // Set filter to only return virtual network and virtual machine resource with 'test' in the name
    filter: "(resourceType eq 'Microsoft.Network/virtualNetworks' or resourceType eq 'Microsoft.Compute/virtualMachines') and substringof('test', name)",
    // Include 'createdTime' and 'changeTime' properties in the returned data
    expand: "createdTime,changedTime"
    );

int count = 0;
await foreach (var res in networkAndVmWithTestInName)
{
    Console.WriteLine($"{res.Id.Name} in resource group {res.Id.ResourceGroupName} created at {res.Data.CreatedOn} and changed at {res.Data.ChangedOn}");
    count++;
}
Console.WriteLine($"{count} resources found");
```
### Create GenericResource
```C# Snippet:Create_GenericResource
ArmClient client = new ArmClient(new DefaultAzureCredential());

var subnetName = "samplesubnet";
var addressSpaces = new Dictionary<string, object>()
{
    { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
};
var subnet = new Dictionary<string, object>()
{
    { "name", subnetName },
    { "properties", new Dictionary<string, object>()
        {
            { "addressPrefix", "10.0.1.0/24" }
        }
    }
};
var subnets = new List<object>() { subnet };
var data = new GenericResourceData(AzureLocation.EastUS)
{
    Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    {
        { "addressSpace", addressSpaces },
        { "subnets", subnets }
    })
};
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

var createResult = await client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, id, data);
Console.WriteLine($"Resource {createResult.Value.Id.Name} in resource group {createResult.Value.Id.ResourceGroupName} created");
```
### Update GenericResource
```C# Snippet:Update_GenericResource
ArmClient client = new ArmClient(new DefaultAzureCredential());

var subnetName = "samplesubnet";
var addressSpaces = new Dictionary<string, object>()
{
    { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
};
var subnet = new Dictionary<string, object>()
{
    { "name", subnetName },
    { "properties", new Dictionary<string, object>()
        {
            { "addressPrefix", "10.0.1.0/24" }
        }
    }
};
var subnets = new List<object>() { subnet };
var data = new GenericResourceData(AzureLocation.EastUS)
{
    Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
    {
        { "addressSpace", addressSpaces },
        { "subnets", subnets }
    })
};
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

var createResult = await client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, id, data);
Console.WriteLine($"Resource {createResult.Value.Id.Name} in resource group {createResult.Value.Id.ResourceGroupName} updated");
```
### Update GenericResource Tags
```C# Snippet:Update_GenericResourc_Tags
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");
GenericResource resource = client.GetGenericResources().Get(id).Value;

GenericResourceData updateTag = new GenericResourceData(AzureLocation.EastUS);
updateTag.Tags.Add("tag1", "sample-for-genericresource");
ArmOperation<GenericResource> updateTagResult = await resource.UpdateAsync(WaitUntil.Completed, updateTag);

Console.WriteLine($"Resource {updateTagResult.Value.Id.Name} in resource group {updateTagResult.Value.Id.ResourceGroupName} updated");
```
### Get GenericResource
```C# Snippet:Get_GenericResource
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

Response<GenericResource> getResultFromGenericResourceCollection = await client.GetGenericResources().GetAsync(id);
Console.WriteLine($"Resource {getResultFromGenericResourceCollection.Value.Id.Name} in resource group {getResultFromGenericResourceCollection.Value.Id.ResourceGroupName} got");

GenericResource resource = getResultFromGenericResourceCollection.Value;
Response<GenericResource> getResultFromGenericResource = await resource.GetAsync();
Console.WriteLine($"Resource {getResultFromGenericResource.Value.Id.Name} in resource group {getResultFromGenericResource.Value.Id.ResourceGroupName} got");
```
### Check whether GenericResource exists
```C# Snippet:Is_GenericResource_Exist
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");

bool existResult = await client.GetGenericResources().ExistsAsync(id);
Console.WriteLine($"Resource exists: {existResult}");
```
### Delete GenericResource
```C# Snippet:Delete_GenericResource
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceIdentifier id = new ResourceIdentifier("/subscriptions/{subscription_id}/resourceGroups/{resourcegroup_name}/providers/Microsoft.Network/virtualNetworks/{vnet_name}");
GenericResource resource = client.GetGenericResources().Get(id).Value;

var deleteResult = await resource.DeleteAsync(WaitUntil.Completed);
Console.WriteLine($"Resource deletion response status code: {deleteResult.WaitForCompletionResponse().Status}");
```

### Rehydrate a long-running operation
```C# Snippet:Readme_LRORehydration
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
var orgData = new ResourceGroupData(AzureLocation.WestUS2);
// We initialize a long-running operation
var rgOp = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Started, "orgName", orgData);
// We get the rehydration token from the operation
var rgOpRehydrationToken = rgOp.GetRehydrationToken();
// We rehydrate the long-running operation with the rehydration token, we can also do this asynchronously
var rehydratedOrgOperation = ArmOperation.Rehydrate<ResourceGroupResource>(client, rgOpRehydrationToken!.Value);
var rehydratedOrgOperationAsync = await ArmOperation.RehydrateAsync<ResourceGroupResource>(client, rgOpRehydrationToken!.Value);
// Now we can operate with the rehydrated operation
var rawResponse = rehydratedOrgOperation.GetRawResponse();
await rehydratedOrgOperation.WaitForCompletionAsync();
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager/samples) we have available.

## Azure Resource Manager Tests

To run test: ```dotnet test```

To run test with code coverage and auto generate an html report: ```dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura```

Coverage report will be placed in your path relative to azure-proto-core-test in```/coverage``` in html format for viewing

Reports can also be viewed VS or VsCode with the proper viewer plugin

A terse report will also be displayed on the command line when running. 


### run test with single file or test

To run test with code coverage and auto generate an html report with just a single test: ```dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --filter <test-to-run>```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps
### More sample code

- [Managing Resource Groups](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/Sample2_ManagingResourceGroups.md)
- [Creating a Virtual Network](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/Sample3_CreatingAVirtualNetwork.md)
- [.NET Management Library Code Samples](https://learn.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK)

### Other Documentation

If you're migrating from the old SDK, check out this [Migration guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/MigrationGuide.md).

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
