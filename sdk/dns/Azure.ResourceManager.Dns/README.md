# Microsoft Azure Dns management client library for .NET

Microsoft Azure Dns is a hosting service for Dns domains that provides name resolution by using Microsoft Azure infrastructure. By hosting your domains in Microsoft Azure, you can manage your Dns records by using the same credentials, APIs, tools, and billing as your other Azure services.

This library supports managing Microsoft Azure Dns resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Azure DNS management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.Dns
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

### Create a Dns zone

```C# Snippet:Managing_DnsZones_CreateADnsZones
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the DnsZone collection from the resource group
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
// Use the same location as the resource group
string dnsZoneName = "sample.com";
DnsZoneData data = new DnsZoneData("Global")
{
};
ArmOperation<DnsZoneResource> lro = await dnsZoneCollection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
DnsZoneResource dnsZone = lro.Value;
```

### Get all Dns zones in a resource group

```C# Snippet:Managing_DnsZones_ListAllDnsZones
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the DnsZone collection from the resource group
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
// With ListAsync(), we can get a list of the DnsZones
AsyncPageable<DnsZoneResource> response = dnsZoneCollection.GetAllAsync();
await foreach (DnsZoneResource dnsZone in response)
{
    Console.WriteLine(dnsZone.Data.Name);
}
```

### Delete a Dns zone

```C# Snippet:Managing_DnsZones_DeleteDnsZone
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
// first we need to get the resource group
string rgName = "myRgName";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
// Now we get the DnsZone collection from the resource group
DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
string dnsZoneName = "sample.com";
DnsZoneResource dnsZone = await dnsZoneCollection.GetAsync(dnsZoneName);
await dnsZone.DeleteAsync(WaitUntil.Completed);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet).

## Next steps

### More sample code

- [Managing DNS Zones](https://github.com/dvbb/azure-sdk-for-net/blob/dvbb-mgmt-track2-dns-2/sdk/dns/Azure.ResourceManager.Dns/samples/Sample1_ManagingDNSZones.md)
- [Managing Record Set Ptrs](https://github.com/dvbb/azure-sdk-for-net/blob/dvbb-mgmt-track2-dns-2/sdk/dns/Azure.ResourceManager.Dns/samples/Sample2_ManagingRecordSetPtrs.md)

### Other Documentation

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

