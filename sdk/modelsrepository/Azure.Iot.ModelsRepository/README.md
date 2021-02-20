# Azure IoT Models Repository client library for .NET

This library provides functionality for interacting with the Azure IoT Models Repository. It also aims to provide a consistent experience working with digital twin model repositories following Azure IoT conventions.

[Source code][source] | [Package (nuget)][package]

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure downloads][microsoft_sdk_download] page, and it ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package

Install the Azure IoT Models Repository client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Iot.ModelsRepository
```

View the package details at [nuget.org][modelsrepository_nuget].

### Prerequisites

- A models repository following [Azure IoT conventions][modelsrepository_conventions]
  - The models repository can be located on the local filesystem or hosted on a webserver.
  - Azure IoT hosts the global [Azure IoT Models Repository](modelsrepository_iot_endpoint) which the client will point to by default if no Uri is provided.

### Authenticate the Client

Currently no authentication mechanisms are supported in the client. The global endpoint is not tied to an Azure subscription and does not support auth. All models published are meant for anonymous public consumption.

## Key concepts

The Azure IoT Models Repository enables builders to manage and share digital twin models. The models are JSON-LD documents defined using the Digital Twins Definition Language (DTDL).

The repository defines a pattern to store DTDL interfaces in a directory structure based on the Digital Twin Model Identifier (DTMI). You can locate an interface in the repository by converting the DTMI to a relative path. For example, the DTMI "dtmi:com:example:Thermostat;1" translates to /dtmi/com/example/thermostat-1.json.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with the client using [samples for IoT Models Repository](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/modelsrepository/Azure.Iot.ModelsRepository/samples/).

## Troubleshooting

All service operations will throw RequestFailedException on failure, with helpful error codes and other information.

## Next steps

See implementation examples with our [code samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/modelsrepository/Azure.Iot.ModelsRepository/samples/).

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/modelsrepository
[package]: https://www.nuget.org/packages/Azure.Iot.ModelsRepository
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[nuget]: https://www.nuget.org/
[azure_core_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core
[modelsrepository_nuget]: https://www.nuget.org/packages/Azure.Iot.ModelsRepository
[modelsrepository_conventions]: https://github.com/Azure/iot-plugandplay-models-tools/wiki
[modelsrepository_iot_endpoint]: https://devicemodels.azure.com/
