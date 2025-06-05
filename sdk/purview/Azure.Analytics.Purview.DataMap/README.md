# Azure Purview DataMap client library for .NET

Microsoft Purview Data Map provides the foundation for data discovery and data governance. Microsoft Purview Data Map is a cloud native PaaS service that captures metadata about enterprise data present in analytics and operation systems on-premises and cloud. Azure PurviewDataMap client provides a set of APIs in Purview Data Map Data Plane. For a full list of APIs, please refer to [Data Map API](https://learn.microsoft.com/rest/api/purview/datamapdataplane/operation-groups?view=rest-purview-datamapdataplane-2023-09-01).

**Please rely heavily on the [service's documentation][catalog_service_documentation] and our [protocol client docs][protocol_client_quickstart] to use this library**

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/purview/Azure.Analytics.Purview.DataMap/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://learn.microsoft.com/rest/api/purview/datamapdataplane/operation-groups?view=rest-purview-datamapdataplane-2023-09-01) | [Product documentation](https://learn.microsoft.com/azure)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/packages?q=Azure.Analytics.Purview.DataMap):

```dotnetcli
dotnet add package Azure.Analytics.Purview.DataMap --prerelease
```

### Prerequisites

- You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

#### Using Azure Active Directory

This document demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate via Azure Active Directory. However, any of the credentials offered by the [Azure.Identity][azure_identity] will be accepted.  See the [Azure.Identity][azure_identity] documentation for more information about other credentials.

Once you have chosen and configured your credential, you can create instances of the `DataMapClient`.

```C#
var credential = new DefaultAzureCredential();
var client = new DataMapClient(new Uri("https://<my-account-name>.purview.azure.com"), credential);
```

## Key concepts

### Protocol Methods

Operations exposed by the Purview Catalog SDK for .NET use *protocol methods* to expose the underlying REST operations. You can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section shows you how to initialize and authenticate your client, then get type definition by name.

* [Create Data Map Client](#create-data-map-client)
* [Get Type Definition By Name](#get-type-definition-by-name)
* [Get Type By Name Asynchronously](#get-type-by-name-asynchronously)

### Create Data Map Client

```C# Snippet:CreateDataMapClient
Uri endpoint = TestEnvironment.Endpoint;
TokenCredential credential = new DefaultAzureCredential();
DataMapClient dataMapClient = new DataMapClient(endpoint, credential);
```

### Get Type Definition By Name

```C# Snippet:GetTypeByName
TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
Response response = client.GetByName("AtlasGlossary", null);
```

## Get Type By Name Asynchronously

```C# Snippet:DataMapGetTypeByNameAsync
TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
var response = await client.GetByNameAsync("AtlasGlossary", null);
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

This client SDK exposes operations using *protocol methods*, you can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[default_cred_ref]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[catalog_service_documentation]: https://azure.microsoft.com/services/purview/
[catalog_product_documentation]: https://learn.microsoft.com/azure/purview/
[protocol_client_quickstart]: https://aka.ms/azsdk/net/protocol/quickstart
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://learn.microsoft.com/azure/purview/create-catalog-portal
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
