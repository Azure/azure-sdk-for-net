# Azure Device Update for IoT Hub client library for .NET

Azure Device Update for IoT Hub is a service that enables you to deploy over-the-air updates (OTA) for your IoT devices. This client library lets you publish, manage, and deploy updates and inspect device state from .NET applications.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.IoT.DeviceUpdate --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing Azure Device Update for IoT Hub account and instance.

### Authenticate the client

To create a `DeviceUpdateClient`, you need your Device Update account endpoint, the instance ID, and a token credential. The example below uses [`DefaultAzureCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential) from the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package:

```csharp
using Azure.Identity;
using Azure.IoT.DeviceUpdate;

DeviceUpdateClient client = new DeviceUpdateClient(
    "<endpoint>",
    "<instanceId>",
    new DefaultAzureCredential());
```

## Key concepts

## Examples

## Troubleshooting

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.