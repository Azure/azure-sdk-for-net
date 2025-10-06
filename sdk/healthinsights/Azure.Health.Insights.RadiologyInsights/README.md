# Azure Cognitive Services Health Insights RadiologyInsights client library for .NET

[Health Insights][health_insights] is an Azure Applied AI Service built with the Azure Cognitive Services Framework, that leverages multiple Cognitive Services, Healthcare API services and other Azure resources.

[Radiology Insights][radiology_insights_docs] is a model that aims to provide quality checks as feedback on errors and inconsistencies (mismatches) and ensures critical findings are identified and communicated using the full context of the report. Follow-up recommendations and clinical findings with measurements (sizes) documented by the radiologist are also identified.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.RadiologyInsights/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Health.Insights.RadiologyInsights/) | [API reference documentation](https://learn.microsoft.com/en-in/rest/api/cognitiveservices/healthinsights/radiology-insights) | [Product documentation](https://learn.microsoft.com/azure/azure-health-insights/radiology-insights/) | [Samples][sample_folder]
## Getting started

### Prerequisites

- You need an [Azure subscription][azure_sub] to use this package.
- An existing Cognitive Services Health Insights instance.

### Install the package

Install the Azure Health Insights client Radiology Insights library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Health.Insights.RadiologyInsights
```

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version|Supported API version of service |
|-------------|---------------|
|1.0.0 | 2024-04-01|
|1.1.0 | 2024-10-01|

### Authenticate the client

You can find the endpoint for your Health Insights service resource using the [Azure Portal][azure_portal] or [Azure CLI][azure_cli]

```bash
# Get the endpoint for the Health Insights service resource
az cognitiveservices account show --name "resource-name" --resource-group "resource-group-name" --query "properties.endpoint"
```

#### Create RadiologyInsightsClient using Azure Active Directory authentication

You can also create a `RadiologyInsightsClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Age_Mismatch_SyncCreateWithDefaultAzureCredential
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:Age_Mismatch_Sync_Tests_Samples_TokenCredential
Uri endpointUri = new Uri(endpoint);
TokenCredential cred = new DefaultAzureCredential();
RadiologyInsightsClient client = new RadiologyInsightsClient(endpointUri, cred);
```

## Key concepts

Once you've initialized a `RadiologyInsightsClient`, you can use it to analyse document text by displaying inferences found within the text.
* Age Mismatch
* Laterality Discrepancy
* Sex Mismatch
* Complete Order Discrepancy
* Limited Order Discrepancy
* Finding
* Critical Result
* Follow-up Recommendation
* Communication
* Radiology Procedure

Radiology Insights currently supports one document from one patient. Please take a look [here] for more detailed information about the inferences this service produces.

## Examples

For each inference samples are available showing how to retrieve the extracted information either synchronously or asynchronously. Examples on how to create a client, a request and retrieve the results are avaible in the samples folder.

- Working samples: [samples folder][sample_folder].

## Troubleshooting

### Setting up console logging

The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use the AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

### Additional documentation

For more extensive documentation on Azure Health Insights Radiology Insights, see the [Radiology Insights documentation][radiology_insights_docs] on learn.microsoft.com.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org
[azure_portal]: https://portal.azure.com
[azure_cli]: https://learn.microsoft.com/cli/azure
[health_insights]: https://learn.microsoft.com/azure/azure-health-insights/overview?branch=main
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[radiology_insights_docs]: https://learn.microsoft.com/azure/azure-health-insights/radiology-insights/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[cla]: https://cla.microsoft.com
[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md
[coc_contact]: mailto:opencode@microsoft.com
[here]: https://learn.microsoft.com/azure/azure-health-insights/radiology-insights/inferences
[sample_folder]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.RadiologyInsights/samples
[azure_sub]: https://azure.microsoft.com/free
[nuget]: https://www.nuget.org
[azure_portal]:https://learn.microsoft.com/azure/search/search-create-service-portal
[azure_cli]:https://learn.microsoft.com/cli/azure
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[azure_identity_install]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
