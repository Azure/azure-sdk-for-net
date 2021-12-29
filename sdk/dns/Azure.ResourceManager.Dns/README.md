# Azure dns Management client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

## Getting started 

### Install the package

Install the Azure dns management library for .NET with [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.ResourceManager.dns -Version 1.0.0-preview.1 
```

### Prerequisites

* You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/)

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

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html)

## Documentation

Documentation is available to help you learn how to use this package

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/mgmt_preview_quickstart.md)
- [API References](https://docs.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md)

## Examples

### Create a DNS zone

Before creating a DNS zone, we need to have a resource group.

```C# Snippet:Readme_GetResourceGroupCollection
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
ResourceGroup resourceGroup = lro.Value;
```

```C# Snippet:Managing_DNS_Zone_CreateADNSZone
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZoneData input = new DnsZoneData("global");
ZoneCreateOrUpdateOperation zlro = await zoneCollection.CreateOrUpdateAsync(dnsZoneName, input);
DnsZone zone = zlro.Value;
```

### Update a DNS zone

```C# Snippet:Readme_GetResourceGroupCollection
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZone zone = await zoneCollection.GetAsync(dnsZoneName);
var zoneUpdate = new ZoneUpdateOptions();
zoneUpdate.Tags.Add("tag1", "value1");
DnsZone updatedDnsZone = await zone.UpdateAsync(zoneUpdate);
```

### Delete a DNS zone

```C# Snippet:Readme_GetResourceGroupCollection
// First, initialize the ArmClient and get the default subscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
// Now we get a ResourceGroup collection for that subscription
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
ResourceGroup resourceGroup = await rgCollection.GetAsync(rgName);
DnsZoneCollection zoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "test.domain";
DnsZone zone = await zoneCollection.GetAsync(dnsZoneName);
await zone.DeleteAsync();
```
## Troubleshooting

-   File an issue via [Github
    Issues](https://github.com/Azure/azure-sdk-for-net/issues)
-   Check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on Stack Overflow using azure and .net tags.


## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

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

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide
