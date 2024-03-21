# Azure Cognitive Services Health Insights RadiologyInsights client library for .NET

[Health Insights][health_insights] is an Azure Applied AI Service built with the Azure Cognitive Services Framework, that leverages multiple Cognitive Services, Healthcare API services and other Azure resources.


Use the client library for to:

* [Get secret](https://docs.microsoft.com/azure)

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.RadiologyInsights/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://learn.microsoft.com/azure/azure-health-insights/radiology-insights/)

## Getting started

### Prerequisites

- You need an [Azure subscription][azure_sub] to use this package.
- An existing Cognitive Services Health Insights instance.

### Install the package

Install the Azure Health Insights client Radiology Insights library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Health.Insights.RadiologyInsights --prerelease
```

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version|Supported API version of service |
|-------------|---------------|
|1.0.0-beta.1 | 2023-09-01-preview|

### Authenticate the client

You can find the endpoint for your Health Insights service resource using the [Azure Portal][azure_portal] or [Azure CLI][azure_cli]

```bash
# Get the endpoint for the Health Insights service resource
az cognitiveservices account show --name "resource-name" --resource-group "resource-group-name" --query "properties.endpoint"
```

#### Get the API Key

You can get the **API Key** from the Health Insights service resource in the Azure Portal.
Alternatively, you can use **Azure CLI** snippet below to get the API key of your resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create RadiologyInsightsClient with AzureKeyCredential

Once you have the value for the API key, create an `AzureKeyCredential`.  With the endpoint and key credential, you can create the `RadiologyInsightsClient`:

```C#
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new RadiologyInsightsClient(new Uri(endpoint), credential);
```

## Key concepts

Radiology Insights currently supports one document from one patient. Please take a look [here] for more detailed information about the inferences this service produces.

## Examples

- Working samples available in the [samples folder][sample_folder].

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

For more extensive documentation on Azure Health Insights Radiology Insights, see the [Radiology Insights documentation][radiology_insights_docs] on docs.microsoft.com.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[health_insights]: https://learn.microsoft.com/azure/azure-health-insights/overview?branch=main
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[radiology_insights_docs]: https://learn.microsoft.com/azure/azure-health-insights/radiology-insights/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[cla]: https://cla.microsoft.com
[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md
[coc_contact]: mailto:opencode@microsoft.com
[here]: https://learn.microsoft.com/azure/azure-health-insights/radiology-insights/inferences
[sample_folder]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/healthinsights/Azure.Health.Insights.RadiologyInsights/samples
