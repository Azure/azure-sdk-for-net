# Azure Purview Scanning client library for .NET

Azure Purview Scanning is a fully managed cloud service whose users can scan your data into your data estate (also known as your **catalog**). Scanning is a process by which the catalog connects directly to a data source on a user-specified schedule.

- Scan your data into your catalog
- Examine your data
- Extract schemas from your data

**Please rely heavily on the [service's documentation][catalog_product_documentation] and our [protocol client docs][protocol_client_quickstart] to use this library**

[Source code][source_code] | [Package (NuGet)][client_nuget_package] | [Product documentation][catalog_product_documentation]

## Getting started

### Install the package

Install the Azure Purview Scanning client library for .NET with [NuGet][client_nuget_package]:

```
dotnet add package Azure.Analysis.Purview.Scanning --prerelease
```

### Prerequisites

- You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

#### Using Azure Active Directory

This document demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate via Azure Active Directory. However, any of the credentials offered by the [Azure.Identity][azure_identity] will be accepted. See the [Azure.Identity][azure_identity] documentation for more information about other credentials.

Once you have chosen and configured your credential, you can create instances of the `PurviewScanningClient`.

```C#
var credential = new DefaultAzureCredential();
var client = new PurviewScanningClient(new Url("https://<my-account-name>.scanning.purview.azure.com"), credential);
```

## Key concepts

### Protocol Methods

Operations exposed by the Purview Scanning SDK for .NET use *protocol methods* to expose the underlying REST operations. You can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

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

The following section shows you how to initialize and authenticate your client, then list all of your data sources.

### List All Data Sources

```C#
var credential = new DefaultAzureCredential();
var client = new PurviewScanningServiceClient(new Uri("https://<my-account-name>.scanning.purview.azure.com"), credential);

var response = await client.GetDataSourcesAsync();
var responseDocument = JsonDocument.Parse(response.Content);
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

This client SDK exposes operations using *protocol methods*, you can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/purview/Azure.Analytics.Purview.Scanning/src
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Analytics.Purview.Scanning
[catalog_product_documentation]: https://azure.microsoft.com/services/purview/
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[protocol_client_quickstart]: https://aka.ms/azsdk/net/protocol/quickstart
[default_cred_ref]: https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://docs.microsoft.com/azure/purview/create-catalog-portal
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fpurview%2FAzure.Analytics.Purview.Scanning%2FREADME.png)
