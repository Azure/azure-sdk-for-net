# Microsoft Azure MigrationDiscoverySap management client library for .NET

Azure Migrate now provides a new capability to help accelerate SAP workload migration to Azure. With this you can discover your SAP estates and get recommendations and cost estimates for migrating them to Azure.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started

### Install the package

Install the Microsoft Azure MigrationDiscoverySap management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.MigrationDiscoverySap --prerelease
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html)

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

### Get the intermediate status of the ImportEntities method

```C# Snippet:Readme_GetIntermediateStatusOfImportEntitiesMethod
ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

string resourceGroupName = "myRgName";
ResourceGroupResource rg = await resourceGroups.GetAsync(resourceGroupName);
// Create Resource group, create a discovery site.
// Get Discovery site resource with the created name.
string discoverySiteName = "siteName";
SapDiscoverySiteResource sapDiscoverySiteResource = await rg.GetSapDiscoverySiteAsync(discoverySiteName);
// Post import entities operation.
ArmOperation<OperationStatusResult> importEntitiesOp = await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);
// Get operation status.
Response<GenericResource> operationStatus = await client.GetGenericResources().GetAsync(ResourceIdentifier.Parse(importEntitiesOp.Value.Id));
JsonDocument doc = JsonDocument.Parse(operationStatus?.GetRawResponse()?.Content?.ToString());
JsonElement root = doc.RootElement;
JsonElement p = root.GetProperty("properties");
string status = p.GetProperty("status").GetString();
```

Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

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
