# Azure IoT DeviceUpdate client library for .NET

Azure.IoT.DeviceUpdate is a client library for developing .NET applications with rich experience.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.IoT.DeviceUpdate
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

To interact with the Device Update for IoT Hub service, you need to create an instance of a client class and authenticate it with a credential. The examples in this document use a credential object named `DefaultAzureCredential` from the [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md) library to authenticate the client.

## Key concepts

The Device Update for IoT Hub client library contains clients for update management and device management operations.

## Examples

Code samples for using the management library for .NET can be found in the following locations
- [.NET Device Update Code Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.ResourceManager.DeviceUpdate/samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.