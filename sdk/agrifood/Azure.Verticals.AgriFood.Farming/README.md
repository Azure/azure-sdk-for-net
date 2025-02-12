# Azure FarmBeats client library for .NET

FarmBeats is a B2B PaaS offering from Microsoft that makes it easy for AgriFood companies to build intelligent digital agriculture solutions on Azure. FarmBeats allows users to acquire, aggregate, and process agricultural data from various sources (farm equipment, weather, satellite) without the need to invest in deep data engineering resources.  Customers can build SaaS solutions on top of FarmBeats and leverage first class support for model building to generate insights at scale.

**Please rely heavily on the [service's documentation][product_documentation] and our [protocol client docs][protocol_client_quickstart] to use this library**

[Source code][source_code] | [Package (NuGet)][client_nuget_package] | [Product documentation][product_documentation]

## Getting started

### Install the package

Install the Azure FarmBeats client library for .NET with [NuGet][client_nuget_package]:

```dotnetcli
dotnet add package Azure.Verticals.AgriFood.Farming --prerelease
```

### Prerequisites

To use this package, you must have:

- An [Azure subscription][azure_subscription]
- An [AgriFood (FarmBeats) resource][install_farmbeats]

### Authenticate the client

#### Using Azure Active Directory

This document demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate via Azure Active Directory. However, any of the credentials offered by the [Azure.Identity][azure_identity] will be accepted. See the [Azure.Identity][azure_identity] documentation for more information about other credentials.

Once you have chosen and configured your credential, you can create instances of any client types, for example, `FarmClient`.

```C#
var credential = new DefaultAzureCredential();
var client = new FarmClient(new Uri("https://<my-account-name>.farmbeats.azure.net"), credential);
```

## Key concepts

Basic understanding of below terms will help to get started with FarmBeats client library.

### [Farm Hierarchy][farm_hierarchy]
Farm hierarchy is a collection of below entities.
- Farmer - is the custodian of all the agronomic data.
- Farm - is a logical collection of fields and/or seasonal fields. They do not have any area associated with them.
- Field - is a multi-polygon area. This is expected to be stable across seasons.
- Seasonal field - is a multi-polygon area. To define a seasonal boundary we need the details of area (boundary), time (season) and crop. New seasonal fields are expected to be created for every growing season.
- Boundary - is the actual multi-polygon area expressed as a geometry (in geojson). It is normally associated with a field or a seasonal field. Satellite, weather and farm operations data is linked to a boundary.
- Cascade delete - Agronomic data is stored hierarchically with farmer as the root. The hierarchy includes Farmer -> Farms -> Fields -> Seasonal Fields -> Boundaries -> Associated data (satellite, weather, farm operations). Cascade delete refers to the process of deleting any node and its subtree.

### [Scenes][scenes]
Scenes refers to images normally ingested using satellite APIs. This includes raw bands and derived bands (Ex: NDVI). Scenes may also include spatial outputs of an inference or AI/ML model (Ex: LAI).

### [Farm Operations][farm_operations_docs]
Fam operations includes details pertaining to tilling, planting, application of pesticides & nutrients, and harvesting. This can either be manually pushed into FarmBeats using APIs or the same information can be pulled from farm equipment service providers like John Deere.

### Protocol Methods

Operations exposed by the FarmBeats SDK for .NET use *protocol methods* to expose the underlying REST operations. You can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section shows you how to initialize and authenticate your client, then list all of your data sources.

### List All Farmers

```C#
var credential = new DefaultAzureCredential();
var client = new FamersClient(new Uri("https://<my-account-name>.farmbeats.azure.net"), credential);

var response = await client.ListAsync();
using var responseDocument = JsonDocument.Parse(response.Content);
Console.WriteLine(responseDocument.RootElement.GetProperty("value"));
```

## Troubleshooting

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][azure_core_diagnostics].

## Next steps

### Additional documentation

For more extensive documentation on the FarmBeats, see the [FarmBeats documentation][product_docs] on learn.microsoft.com.

This client SDK exposes operations using *protocol methods*, you can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agrifood/Azure.Verticals.AgriFood.Farming
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Verticals.AgriFood.Farming
[product_documentation]: https://aka.ms/FarmBeatsProductDocumentationPaaS
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[protocol_client_quickstart]: https://aka.ms/azsdk/net/protocol/quickstart
[default_cred_ref]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[scenes]: https://aka.ms/FarmBeatsSatellitePaaSDocumentation
[farm_operations_docs]: https://aka.ms/FarmBeatsFarmOperationsDocumentation
[farm_hierarchy]: https://aka.ms/FarmBeatsFarmHierarchyDocs
[install_farmbeats]: https://aka.ms/FarmBeatsInstallDocumentationPaaS
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
