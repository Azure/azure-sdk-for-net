# Azure DNS Management client library for .NET

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

## Getting started 

### Install the package

Install the Azure DNS management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.Dns --prerelease
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

Additional documentation for the `Azure.Identity.DefaultAzureCredential` class can be found in [this document](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts)

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
AsyncPageable<DnsZoneResource>  response = dnsZoneCollection.GetAllAsync();
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
DnsZoneResource dnsZone =await dnsZoneCollection.GetAsync(dnsZoneName);
await dnsZone.DeleteAsync(WaitUntil.Completed);
```

## Troubleshooting

-   If you find a bug or have a suggestion, file an issue via [GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and make sure you add the "Preview" label to the issue.
-   If you need help, check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.
-   If having trouble with authentication, go to [DefaultAzureCredential documentation](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet)

## Next steps

### More sample code

- [Managing DNS Zones](https://github.com/dvbb/azure-sdk-for-net/blob/dvbb-mgmt-track2-dns-2/sdk/dns/Azure.ResourceManager.Dns/samples/Sample1_ManagingDNSZones.md)
- [Managing Record Set Ptrs](https://github.com/dvbb/azure-sdk-for-net/blob/dvbb-mgmt-track2-dns-2/sdk/dns/Azure.ResourceManager.Dns/samples/Sample2_ManagingRecordSetPtrs.md)

### Additional Documentation

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/).

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
