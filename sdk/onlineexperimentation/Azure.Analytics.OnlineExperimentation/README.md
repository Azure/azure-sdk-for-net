# Azure Online Experimentation client library for .NET

Azure Online Experimentation is a managed service that enables developers to create and manage experiment metrics for evaluating online A/B tests.

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/src) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure) | [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples)

## Getting started

### Install the package

Install the Azure Online Experimentation client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Analytics.OnlineExperimentation --prerelease
```

### Prerequisites

You need an [Azure subscription](https://azure.microsoft.com/free/dotnet/) with an Azure Online Experimentation workspace resource.

### Authenticate the client

The Azure Online Experimentation client library initialization requires two parameters:

- The `endpoint` property value from the [`Microsoft.OnlineExperimentation/workspaces`](https://learn.microsoft.com/azure/templates/microsoft.onlineexperimentation/workspaces) resource.
- A `TokenCredential` for authentication, the simplest approach is to use [`DefaultAzureCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

```C# Snippet:OnlineExperimentation_InitializeClient
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());
```

### Select a service API version

You can explicitly select a supported service API version when instantiating a client:

```C# Snippet:OnlineExperimentation_InitializeClientApiVersion
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var options = new OnlineExperimentationClientOptions(OnlineExperimentationClientOptions.ServiceVersion.V2025_05_31_Preview);
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential(), options);
```

Always ensure that the chosen API version is fully supported and operational for your specific use case and aligns with the service's versioning policy.

## Key concepts

The Azure Online Experimentation client library provides the following key classes:

- `OnlineExperimentationClient`: Main client class for interacting with the service.
- `DiagnosticDetail`: Represents diagnostic details for experiment metrics.

### Thread safety

All client instances are thread-safe. It's recommended to reuse client instances across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-response-details) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md)

## Examples

Explore common scenarios using the [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples):

- [Creating Experiment Metrics](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample2_CreateExperimentMetrics.md)
- [Updating Experiment Metrics](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples/Sample5_UpdateExperimentMetrics.md)

## Troubleshooting

Common exceptions include:

- `RequestFailedException`: Indicates a failure in the request. Inspect the exception message and status code for details.

Enable logging and diagnostics to debug issues:

```C# Snippet:OnlineExperimentation_InitializeClientDiagnostics
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var options = new OnlineExperimentationClientOptions()
{
    Diagnostics =
    {
        IsLoggingContentEnabled = true
    }
};
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential(), options);
```

## Next steps

- Explore additional [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/samples) to learn more.
- Visit the [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) repository for more libraries.

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contributing to this library.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/README.png)
