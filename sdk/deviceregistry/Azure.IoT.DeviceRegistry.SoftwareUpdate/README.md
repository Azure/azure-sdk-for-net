# Azure Software Update for Device Registry client library for .NET

The Azure Software Update for Device Registry client library enables .NET applications to publish updates for IoT devices, inspect imported update content, and manage device classes. The service uses the security and reliability of the Update platform to help customers manage updates for devices registered with Azure Device Registry.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.IoT.DeviceRegistry.SoftwareUpdate --prerelease
dotnet add package Azure.Identity
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- You need the endpoint for your Software Update for Device Registry service, such as `https://contoso.api.adu.microsoft.com`.
- Your Microsoft Entra identity must have permission to access the service.

### Authenticate the client

To interact with Software Update for Device Registry, create a `DeviceRegistrySoftwareUpdateClient` with the service endpoint and a `TokenCredential`. The examples in this document use `DefaultAzureCredential` from the [Azure Identity client library for .NET](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Key concepts

`DeviceRegistrySoftwareUpdateClient` is the entry point for the library. It provides access to two operation groups:

- `SoftwareUpdate` manages imported updates, update files, providers, names, versions, and import operation status.
- `DeviceClasses` lists device classes, retrieves a device class, and deletes a device class.

List operations return `Pageable<T>` or `AsyncPageable<T>`, allowing results to be processed one page or one item at a time. The `ImportUpdate` and `DeleteUpdate` methods start long-running operations and can either return after the operation starts or wait until it completes.

## Examples

The following example creates an authenticated client and asynchronously lists imported updates:

```C# Snippet:DeviceRegistrySoftwareUpdate_ListUpdatesAsync
string endpoint = Environment.GetEnvironmentVariable("DEVICE_REGISTRY_SOFTWARE_UPDATE_ENDPOINT")
    ?? throw new InvalidOperationException("Set DEVICE_REGISTRY_SOFTWARE_UPDATE_ENDPOINT before running this example.");

var client = new DeviceRegistrySoftwareUpdateClient(
    new Uri(endpoint),
    new DefaultAzureCredential());

SoftwareUpdate softwareUpdate = client.GetSoftwareUpdateClient();

await foreach (UpdateContent update in softwareUpdate.GetUpdatesAsync())
{
    Console.WriteLine($"{update.UpdateId.Provider}/{update.UpdateId.Name}/{update.UpdateId.Version}");
}
```

## Troubleshooting

- Service failures throw a [`RequestFailedException`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) that includes the HTTP status and service error details.
- Verify that the endpoint is correct and that the credential has permission to access Software Update for Device Registry.
- File an issue through [Azure SDK for .NET GitHub issues](https://github.com/Azure/azure-sdk-for-net/issues) and include the exception message and request ID when available.

## Next steps

- Review the library's [public API surface](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceregistry/Azure.IoT.DeviceRegistry.SoftwareUpdate/api).
- Learn more about [authentication with Azure Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).
- Learn about [Azure SDK for .NET](https://azure.github.io/azure-sdk-for-net/).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.