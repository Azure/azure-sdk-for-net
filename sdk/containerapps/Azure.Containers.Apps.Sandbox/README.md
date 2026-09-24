# Azure Container Apps Sandbox client library for .NET

The Azure Container Apps Sandbox client library provides data-plane operations for creating and managing sandboxes and their files, networking, storage, connections, credentials, and supporting resources.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Containers.Apps.Sandbox --prerelease
dotnet add package Azure.Identity
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An Azure Container Apps sandbox group and its data-plane endpoint.
- The `Container Apps SandboxGroup Data Owner` role, or equivalent permissions, on the sandbox group.

### Authenticate the client

Azure Container Apps Sandbox uses Microsoft Entra ID authentication. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package and create a `ContainerAppsSandboxClient` with a `TokenCredential`, such as `DefaultAzureCredential`.

```csharp
using System.IO;
using Azure.Containers.Apps.Sandbox;
using Azure.Identity;

Uri endpoint = new Uri("<sandbox-group-endpoint>");
ContainerAppsSandboxClient client = new ContainerAppsSandboxClient(
    endpoint,
    new DefaultAzureCredential());
```

## Key concepts

- **Top-level client:** `ContainerAppsSandboxClient` authenticates requests and creates clients scoped to a sandbox group.
- **Sandbox group client:** `SandboxGroup` uses the subscription ID, resource group name, and sandbox group name to perform collection operations and create resource-specific subclients.
- **Sandbox client:** `SandboxGroupSandbox` is scoped to a sandbox ID and provides lifecycle, command, statistics, storage, networking, and file subclients.
- **Supporting resource clients:** A sandbox group exposes clients for connections, content packages, credentials, disk images, egress policies, secrets, snapshots, and volumes.
- **Models:** Request and response models are available in the `Azure.Containers.Apps.Sandbox.Models` namespace.

## Examples

The following examples assume that `client` was created as shown in [Authenticate the client](#authenticate-the-client).

### Get sandbox group and sandbox clients

Create a sandbox group client from its Azure resource scope, then create a client for an existing sandbox:

```csharp
SandboxGroup sandboxGroup = client.GetSandboxGroupClient(
    "<subscription-id>",
    "<resource-group-name>",
    "<sandbox-group-name>");

SandboxGroupSandbox sandbox = sandboxGroup.GetSandboxGroupSandboxClient("<sandbox-id>");
```

### Get sandbox properties

Use the sandbox-scoped client to retrieve the current sandbox properties:

```csharp
var response = await sandbox.GetPropertiesAsync();

Console.WriteLine($"Sandbox ID: {response.Value.Id}");
Console.WriteLine($"State: {response.Value.State}");
```

### List sandboxes

Sandbox collection operations are pageable:

```csharp
await foreach (var item in sandboxGroup.GetSandboxesAsync())
{
    Console.WriteLine($"{item.Id}: {item.State}");
}
```

### Get file metadata

Obtain the file subclient from a sandbox and retrieve metadata for a file:

```csharp
SandboxGroupSandboxFiles files = sandbox.GetSandboxGroupSandboxFilesClient();
var response = await files.GetSandboxFileMetadataAsync("/tmp/example.txt");

Console.WriteLine($"Path: {response.Value.Path}");
Console.WriteLine($"Size: {response.Value.Size} bytes");
```

### Upload and download a file as a stream

Upload streams must be readable and seekable so the client can replay the request if the pipeline retries it. Upload starts at the stream's current position, and the client leaves the stream open. Streaming downloads are not buffered; dispose the returned stream after reading it.

```csharp
SandboxGroupSandboxFiles files = sandbox.GetSandboxGroupSandboxFilesClient();

using Stream upload = File.OpenRead("example.txt");
await files.UploadSandboxFileAsync(
    "/tmp/example.txt",
    upload,
    createDirs: true);

var response = await files.DownloadSandboxFileStreamingAsync("/tmp/example.txt");
using Stream download = response.Value;
using FileStream destination = File.Create("downloaded-example.txt");
await download.CopyToAsync(destination);
```

## Troubleshooting

Service operations throw a `RequestFailedException` when the service returns an unsuccessful response. Inspect the exception's `Status`, `ErrorCode`, and `Message` properties for details.

Common causes include:

- using the Azure Resource Manager endpoint instead of the sandbox group's data-plane endpoint;
- authenticating with an identity that does not have data-plane access to the sandbox group;
- using a subscription, resource group, sandbox group, or sandbox ID that does not match the endpoint;
- attempting an operation while the sandbox is in an incompatible lifecycle state.

To enable Azure SDK console logging during development:

```csharp
using Azure.Core.Diagnostics;

using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

For additional logging, distributed tracing, and request diagnostics guidance, see the [Azure SDK diagnostics documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## Next steps

- Review the [package source](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/containerapps/Azure.Containers.Apps.Sandbox).
- Review the [release history](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerapps/Azure.Containers.Apps.Sandbox/CHANGELOG.md).
- Learn more about authentication with the [Azure Identity client library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.

### Testing

Run unit tests without Azure resources:

```dotnetcli
dotnet test tests/Azure.Containers.Apps.Sandbox.Tests.csproj --filter TestCategory!=Live
```

Create the sandbox group and role assignment used by live tests from the repository root:

```powershell
eng/common/TestResources/New-TestResources.ps1 containerapps
```

Run the self-contained live tests:

```powershell
$env:AZURE_TEST_MODE = "Live"
dotnet test sdk/containerapps/Azure.Containers.Apps.Sandbox/tests/Azure.Containers.Apps.Sandbox.Tests.csproj -f net10.0
```

The resource template deploys a `Microsoft.App/sandboxGroups` resource in `eastus2` and grants the generated test identity the `Container Apps SandboxGroup Data Owner` role. Override the `sandboxLocation` template parameter if the service is enabled in a different region for your subscription.

The sandbox group, endpoint, and role assignment are shared test infrastructure. Sandboxes, volumes, snapshots, secrets, egress policies, content packages, files, and other mutable data-plane resources are created by individual tests and registered for reverse-order cleanup in `SandboxClientTestBase`.

Generate recordings for the recordable tests:

```powershell
$env:AZURE_TEST_MODE = "Record"
dotnet test sdk/containerapps/Azure.Containers.Apps.Sandbox/tests/Azure.Containers.Apps.Sandbox.Tests.csproj -f net10.0
```

The test suite consolidates the generated Java scenarios by resource area:

- sandbox CRUD, lifecycle, policy, statistics, commands, and networking;
- volumes, volume files, mounts, snapshots, and sandbox files;
- secrets, content packages, named egress policies, and disk images.

Connection, credential, and interactive stream request construction is covered with `MockTransport`, including pagination, optional query parameters, and request serialization. Provider authorization and WebSocket frame exchange are not exercised as live tests because they require provider-specific secrets or transport support outside Azure.Core HTTP recording. Long-running disk-image creation and commit scenarios are marked live-only.