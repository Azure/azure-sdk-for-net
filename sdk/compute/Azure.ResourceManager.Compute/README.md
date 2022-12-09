# Azure Compute Management client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html),which provide core capabilities that are shared amongst all Azure SDKs, including:

- The intuitive Azure Identity library.
- An HTTP pipeline with custom policies.
- Error handling.
- Distributed tracing.

## Getting started 

### Install the package

Install the Azure Compute management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.Compute
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
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

// Code omitted for brevity

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

## Examples

### Create an availability set

Before creating an availability set, we need to have a resource group.

```C# Snippet:Readme_GetResourceGroupCollection
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

```C# Snippet:Managing_Availability_Set_CreateAnAvailabilitySet
AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
string availabilitySetName = "myAvailabilitySet";
AvailabilitySetData input = new AvailabilitySetData(location);
ArmOperation<AvailabilitySetResource> lro = await availabilitySetCollection.CreateOrUpdateAsync(WaitUntil.Completed, availabilitySetName, input);
AvailabilitySetResource availabilitySet = lro.Value;
```

### Get all availability set in a resource group

```C# Snippet:Managing_Availability_Set_GetAllAvailabilitySets
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroupResource collection for that subscription
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

string rgName = "myRgName";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
// First, we get the availability set collection from the resource group
AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
// With GetAllAsync(), we can get a list of the availability sets in the collection
AsyncPageable<AvailabilitySetResource> response = availabilitySetCollection.GetAllAsync();
await foreach (AvailabilitySetResource availabilitySet in response)
{
    Console.WriteLine(availabilitySet.Data.Name);
}
```

### Update an availability set

```C# Snippet:Managing_Availability_Set_UpdateAnAvailabilitySet
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroupResource collection for that subscription
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
string availabilitySetName = "myAvailabilitySet";
AvailabilitySetResource availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
// availabilitySet is an AvailabilitySetResource instance created above
AvailabilitySetPatch update = new AvailabilitySetPatch()
{
    PlatformFaultDomainCount = 3
};
AvailabilitySetResource updatedAvailabilitySet = await availabilitySet.UpdateAsync(update);
```

### Delete an availability set

```C# Snippet:Managing_Availability_Set_DeleteAnAvailabilitySet
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroupResource collection for that subscription
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
string availabilitySetName = "myAvailabilitySet";
AvailabilitySetResource availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
// delete the availability set
await availabilitySet.DeleteAsync(WaitUntil.Completed);
```

### Check if availability set exists

If you just want to verify if the availability set exists, you can use the function `CheckIfExists`.

```C# Snippet:Managing_Availability_Set_CheckIfExistsForAvailabilitySet
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

string rgName = "myRgName";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
string availabilitySetName = "myAvailabilitySet";
bool exists = await resourceGroup.GetAvailabilitySets().ExistsAsync(availabilitySetName);

if (exists)
{
    Console.WriteLine($"Availability Set {availabilitySetName} exists.");
}
else
{
    Console.WriteLine($"Availability Set {availabilitySetName} does not exist.");
}
```

### Add a tag to an availability set

```C# Snippet:Managing_Availability_Set_AddTagAvailabilitySet
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroupResource collection for that subscription
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

string rgName = "myRgName";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
AvailabilitySetCollection availabilitySetCollection = resourceGroup.GetAvailabilitySets();
string availabilitySetName = "myAvailabilitySet";
AvailabilitySetResource availabilitySet = await availabilitySetCollection.GetAsync(availabilitySetName);
// add a tag on this availabilitySet
AvailabilitySetResource updatedAvailabilitySet = await availabilitySet.AddTagAsync("key", "value");
```

For more detailed examples, take a look at [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/compute/Azure.ResourceManager.Compute/samples) we have available.

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet)

## Next steps

### More sample code

- [Managing Disks](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/compute/Azure.ResourceManager.Compute/samples/Sample1_ManagingDisks.md)
- [Managing Virtual Machines](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/compute/Azure.ResourceManager.Compute/samples/Sample2_ManagingVirtualMachines.md)

### Additional Documentation

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

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
