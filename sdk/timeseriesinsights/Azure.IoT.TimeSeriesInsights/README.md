# Azure Time Series Insights client library for .NET

---
[//]: <> (This content is similar to https://github.com/MicrosoftDocs/azure-docs/blob/main/includes/tsi-retirement.md)

**NOTE**
>The Time Series Insights (TSI) service will no longer be supported after March 2025. Consider migrating existing TSI environments to alternative solutions as soon as possible. For more information on the deprecation and migration, visit our [documentation](https://aka.ms/tsi2adx).
---

Azure Time Series Insights provides data exploration and telemetry tools to help you improve operational analysis. It's a fully managed analytics, storage, and visualization service where you can explore and analyze billions of Internet of Things (IoT) events simultaneously.

Azure Time Series Insights gives you a global view of your data, so you can quickly validate your IoT solution and avoid costly downtime to mission-critical devices. It can help you discover hidden trends, spot anomalies, and conduct root-cause analysis in near real time.

If you are new to Azure Time Series Insights and would like to learn more about the platform, please make sure you check out the Azure Time Series Insights official [documentation page][tsi_product_documentation].

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure downloads][microsoft_sdk_download] page, and it ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package

Install the Azure Time Series Insights client library for .NET with NuGet:

```dotnetcli
dotnet add package Azure.IoT.TimeSeriesInsights --prerelease
```

View the package details at [nuget.org][tsi_nuget].

### Prerequisites

- A Microsoft Azure Subscription
  - To call Microsoft Azure services, create an [Azure subscription][azure_sub].

### Authenticate the Client

In order to interact with the Azure Time Series Insights service, you will need to create an instance of a [TokenCredential class][token_credential] and pass it to the constructor of your [TimeSeriesInsightsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/TimeSeriesInsightsClient.cs).

## Key concepts

The Time Series Insights client library for .NET provides the following functionality:
- Retrieving and being able to make changes to the Time Series Insights environment model settings, such as changing the model name or default type ID.
- Retrieving and being able to add, update and remove Time Series instances.
- Retrieving and being able to make changes to the Time Series Insights environment types, such as creating, updating and deleting Time Series types.
- Retrieving and being able to make changes to the Time Series Insights hierarchies, such as creating, updating and deleting Time Series hierarchies.
- Querying raw events, computed series and aggregate series.

[Source Code][tsi_client_src] | [Package (NuGet)][tsi_nuget] | [Product documentation][tsi_product_documentation] | [Samples][tsi_samples]

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that reusing client instances is always safe, even across threads.

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

You can familiarize yourself with different APIs using [samples for Time Series Insights][tsi_samples].

## Source code folder structure

### /src

The Time Series Insights public client, `TimeSeriesInsightsClient`, and the additional configuration options, `TimeSeriesInsightsClientOptions`, that can be sent to the Time Series Insights service.

### /src/Generated

The code generated by autorest using the swagger file defined in the autorest config file.

To regenerate the code, run the powershell script [generate.ps1](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/generate.ps1).

Any time the client library code is updated, the following scripts need to be run:

- [Export-AdtApis.ps1](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Export-TsiApis.ps1), which will update the [API surface document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/api/Azure.IoT.TimeSeriesInsights.netstandard2.0.cs).
- [Update-Snippets.ps1](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Update-TsiSnippets.ps1), which will update all the code snippets in the readme files and in the client documentation comments.

### /src/Customized

The customzied code written to override the following behavior of auto-generated code:

- Declare some of the generated types as **internal**, instead of the autorest default of **public**.

### /src/Models

Model classes useful for use with the Time Series Insights client operations.

### /src/Properties

Assembly properties required for running unit tests.

## Troubleshooting

Time Series Insights service operation failures are usually returned to the user as [TimeSeriesOperationError](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/Generated/Models/TimeSeriesOperationError.cs). The TimeSeriesOperationError response is either returned directly by the client library API, or as a nested property within the actual response for the client library API. For example, the DeleteByName API that is part of the hierarchies client returns a TimeSeriesOperationError directly. Whereas, the Replace API that is part of the instances client returns a [InstancesOperationResult](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/Generated/Models/InstancesOperationResult.cs), which has a TimeSeriesOperationError property nested within it.

Example below shows use of TimeSeriesInsightsSampleGetTypeById operation, iterate through response error to find out if a type does not exist.

```C# Snippet:TimeSeriesInsightsSampleGetTypeById
// Code snippet below shows getting a default Type using Id
// The default type Id can be obtained programmatically by using the ModelSettings client.

TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
TimeSeriesModelSettings modelSettings = await modelSettingsClient.GetAsync();
Response<TimeSeriesTypeOperationResult[]> getTypeByIdResults = await typesClient
    .GetByIdAsync(new string[] { modelSettings.DefaultTypeId });

// The response of calling the API contains a list of type or error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < getTypeByIdResults.Value.Length; i++)
{
    if (getTypeByIdResults.Value[i].Error == null)
    {
        Console.WriteLine($"Retrieved Time Series type with Id: '{getTypeByIdResults.Value[i].TimeSeriesType.Id}'.");
    }
    else
    {
        Console.WriteLine($"Failed to retrieve a Time Series type due to '{getTypeByIdResults.Value[i].Error.Message}'.");
    }
}
```

## Next steps

See implementation examples with our [code samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples).

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com.>

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct].
For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[microsoft_sdk_download]: https://azure.microsoft.com/downloads/?sdk=net
[azure_sdk_target_frameworks]: https://github.com/azure/azure-sdk-for-net#target-frameworks
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[package]: https://www.nuget.org/packages/Azure.IoT.TimeSeriesInsights
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com/
[azure_rest_api]: https://learn.microsoft.com/rest/api/azure/
[azure_core_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core
[token_credential]: https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet
[azure_cli]: https://learn.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest
[iot_cli_extension]: https://github.com/Azure/azure-iot-cli-extension/releases
[iot_cli_doc]: https://learn.microsoft.com/cli/azure/ext/azure-iot/dt?view=azure-cli-latest
[http_status_code]: https://learn.microsoft.com/dotnet/api/system.net.httpstatuscode?view=netcore-3.1
[tsi_nuget]: https://www.nuget.org/packages/Azure.IoT.TimeSeriesInsights
[tsi_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src
[tsi_product_documentation]: https://learn.microsoft.com/azure/time-series-insights/
[tsi_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/samples/Readme.md
