# Azure Container Apps Sandbox client library for .NET

The Azure Container Apps Sandbox client library for .NET provides data-plane operations for creating and managing sandboxes and their related resources, including volumes, snapshots, files, secrets, connections, credentials, content packages, egress policies, and disk images.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Containers.Apps.Sandbox --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- You must have an Azure Container Apps sandbox group and its regional data-plane endpoint.
- Your identity must have permission to access the sandbox group, such as the `Container Apps SandboxGroup Data Owner` role.

### Authenticate the client

Azure Container Apps Sandbox uses Microsoft Entra ID authentication. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package and create a `SandboxGroupClient` with a `TokenCredential`, such as `DefaultAzureCredential`.

```C#
using Azure.Containers.Apps.Sandbox;
using Azure.Identity;

Uri endpoint = new Uri("<sandbox-group-endpoint>");
string subscriptionId = "<subscription-id>";
string resourceGroupName = "<resource-group-name>";
string sandboxGroupName = "<sandbox-group-name>";

SandboxGroupClient sandboxGroupClient = new SandboxGroupClient(
    endpoint,
    subscriptionId,
    resourceGroupName,
    sandboxGroupName,
    new DefaultAzureCredential());
```

## Key concepts

### Sandbox group client

`SandboxGroupClient` is the entry point for a specific sandbox group. It contains the endpoint and Azure resource identifiers required by every request.
Its read-only `SubscriptionId`, `ResourceGroupName`, and `Name` properties expose the identifiers supplied when the client was created. `Id` is the sandbox group's full Azure Resource Manager `ResourceIdentifier`; it does not represent an individual sandbox.

### Resource operations

`SandboxGroupClient` exposes create and list operations for sandboxes and related resources. Its `GetSandbox(id)`, `GetVolume(volumeName)`, `GetConnection(id)`, and other resource factory methods provide clients for individual resources. Operations on a known resource, including sandbox files, commands, lifecycle, and streams, are available on the corresponding resource client. The generated operation subclients are internal implementation details.

### Scoped clients

For operations on a known resource, `SandboxGroupClient` offers scoped clients such as `SandboxClient`, `VolumeClient`, and `SandboxSecretClient`, obtained through `GetSandbox(id)`, `GetVolume(volumeName)`, and `GetSecret(secretId)`. Each client holds its identifier and delegates requests to the corresponding subclient. The group's create and list methods return clients with their `Data` populated from the service response; a client obtained by identifier alone has `Data == null`. Where the service supports retrieval, `Get()` or `GetAsync()` returns a **new** client with the retrieved data, leaving the original client's `Data` unchanged. Mutating operations do not refresh `Data`.
`SandboxClient.Id` is the sandbox's opaque string identifier, not an ARM resource identifier.
`SandboxClient` also offers async exec and process WebSocket streams and an HTTP log stream scoped to its `Id`.

### Models

Request and response models are in the `Azure.Containers.Apps.Sandbox.Models` namespace.

### File transfer streams

Sandbox file, volume file, and content package upload convenience methods accept readable, seekable `Stream` instances. The client does not dispose upload streams. File download convenience methods return unbuffered `Stream` instances that the caller must dispose.

## Examples

### Create a sandbox, execute a command, and delete it

The following example also uses types from `Azure.Containers.Apps.Sandbox.Models`.

```C# Snippet:Azure_Containers_Apps_Sandbox_CreateExecuteAndDeleteAsync
var sandboxGroup = new SandboxGroupClient(
    new Uri("<sandbox-group-endpoint>"),
    "<subscription-id>",
    "<resource-group-name>",
    "<sandbox-group-name>",
    new DefaultAzureCredential());
CreateSandboxContent content = new CreateSandboxContent
{
    SourcesRef = new SandboxSource
    {
        DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
    },
    Resources = new SandboxResources("1000m", "2048Mi")
};

SandboxClient sandbox = (await sandboxGroup.CreateSandboxAsync(content)).Value;
try
{
    ExecuteSandboxCommandContent command = new ExecuteSandboxCommandContent("/bin/echo");
    command.Arguments.Add("sandbox-command");
    SandboxExecuteCommandResult result = (await sandbox.ExecuteCommandAsync(command)).Value;
    if (result.ExitCode != 0)
    {
        throw new InvalidOperationException($"Command failed with exit code {result.ExitCode}: {result.StandardError}");
    }
    Console.WriteLine(result.StandardOutput);
}
finally
{
    await sandbox.DeleteAsync();
}
```

For synchronous usage and more details, see the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerapps/Azure.Containers.Apps.Sandbox/samples/README.md).

### List sandboxes

```C#
await foreach (SandboxClient sandbox in sandboxGroupClient.GetSandboxesAsync())
{
    Console.WriteLine($"{sandbox.Id}: {sandbox.Data.State}");
}
```

### Work with a sandbox resource

```C#
SandboxClient sandbox = sandboxGroupClient.GetSandbox("sandbox-id");
Response<SandboxClient> current = await sandbox.GetAsync();
Console.WriteLine($"{current.Value.Id}: {current.Value.Data.State}");

await foreach (SandboxClient item in sandboxGroupClient.GetSandboxesAsync())
{
    Console.WriteLine($"{item.Id}: {item.Data.State}");
}
```

### List sandbox-group volumes

```C#
await foreach (VolumeClient volume in sandboxGroupClient.GetVolumesAsync())
{
    Console.WriteLine($"{volume.VolumeName}: {volume.Data.ProvisioningState}");
}
```

### Stream sandbox processes

Exec and process streams use WebSocket connections. The process stream sends one text frame per refresh in the service's `top` output format:

```C#
SandboxClient sandbox = sandboxGroupClient.GetSandbox("<sandbox-id>");
await using SandboxProcessStream stream = await sandbox.OpenSandboxProcessStreamAsync();
string snapshot;
while ((snapshot = await stream.ReadSnapshotAsync()) != null)
{
    Console.WriteLine(snapshot);
}
```

### Execute an interactive command

The exec session sends a JSON start frame from `SandboxExecStartRequest`, then accepts stdin bytes and yields decoded events (stdout/stderr bytes, session ID, exit code, or service error). The start request is specific to WebSocket exec and is separate from the HTTP `ExecuteSandboxCommandContent` model:

```C#
using Azure.Containers.Apps.Sandbox.Models;

SandboxExecStartRequest request = new SandboxExecStartRequest("/bin/sh")
{
    AllocateTerminal = false,
    EnableStandardInput = false
};
request.Arguments.Add("-c");
request.Arguments.Add("echo hello");
SandboxClient sandbox = sandboxGroupClient.GetSandbox("<sandbox-id>");
await using SandboxExecSession session = await sandbox.StartSandboxExecSessionAsync(request);
SandboxExecEvent started = await session.ReceiveAsync();
if (started.Type != SandboxExecEventType.SessionId)
    throw new InvalidOperationException("Exec session did not start.");

SandboxExecEvent execEvent;
while ((execEvent = await session.ReceiveAsync()).Type != SandboxExecEventType.Closed)
{
    if (execEvent.Type == SandboxExecEventType.StandardOutput)
        Console.WriteLine(execEvent.Data);
    if (execEvent.Type == SandboxExecEventType.Error)
        throw new InvalidOperationException(execEvent.Text);
}
```

The low-level `ConnectToSandboxExecStreamAsync` and `ConnectToSandboxProcessesStreamAsync` methods return raw WebSocket frames for advanced scenarios. WebSocket frames cannot be recorded by the HTTP test transport.

### Read sandbox logs

Log streaming is **HTTP chunked transfer**, not WebSocket. Dispose the returned `Stream` when finished; it is not buffered. The default format is plain text; `SandboxLogFormat.Json` returns newline-delimited JSON with `timestamp`, `stream`, and `message` fields.

```C#
SandboxClient sandbox = sandboxGroupClient.GetSandbox("<sandbox-id>");
Response<Stream> response = await sandbox.OpenSandboxLogStreamAsync(
    logFormat: SandboxLogFormat.Json, follow: false);
using StreamReader reader = new StreamReader(response.Value);
string line;
while ((line = await reader.ReadLineAsync()) != null)
    Console.WriteLine(line);
```

## Troubleshooting

HTTP service failures throw `RequestFailedException` and include an HTTP status code and service error details. WebSocket connection and frame failures can instead throw `WebSocketException`. For authentication failures, verify that the credential can obtain a token and that the identity has access to the sandbox group. For endpoint or routing failures, verify that the endpoint belongs to the same region as the sandbox group.

To inspect requests and responses during development, enable Azure SDK logging before creating the client.

## Next steps

- Review the [Azure SDK for .NET documentation](https://learn.microsoft.com/dotnet/azure/).
- Review the [Azure Identity client library documentation](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme).
- Explore the tests in the `tests` directory for additional sandbox and resource-management scenarios.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.

### Testing

From the repository root, run unit and playback tests without Azure resources:

```dotnetcli
dotnet test sdk/containerapps/Azure.Containers.Apps.Sandbox/tests/Azure.Containers.Apps.Sandbox.Tests.csproj --filter TestCategory!=Live
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

To run only the WebSocket live tests (exec, including a TTY stdin-to-file round trip, and process streaming):

```powershell
$env:AZURE_TEST_MODE = "Live"
dotnet test sdk/containerapps/Azure.Containers.Apps.Sandbox/tests/Azure.Containers.Apps.Sandbox.Tests.csproj -f net10.0 --filter 'FullyQualifiedName~SandboxWebSocketLiveTests'
```

To run the HTTP log stream live test (reads the JSON log response to completion):

```powershell
$env:AZURE_TEST_MODE = "Live"
dotnet test sdk/containerapps/Azure.Containers.Apps.Sandbox/tests/Azure.Containers.Apps.Sandbox.Tests.csproj -f net10.0 --filter 'FullyQualifiedName~SandboxLogStreamLiveTests'
```

The resource template deploys a `Microsoft.App/sandboxGroups` resource in `eastus2` and grants the generated test identity the `Container Apps SandboxGroup Data Owner` role. Override the `sandboxLocation` template parameter if the service is enabled in a different region for your subscription.

The sandbox group, endpoint, and role assignment are shared test infrastructure. Sandboxes, volumes, snapshots, secrets, egress policies, content packages, files, and other mutable data-plane resources are created by individual tests and registered for reverse-order cleanup in `SandboxClientTestBase`.

Generate recordings for the recordable tests:

```powershell
$env:AZURE_TEST_MODE = "Record"
dotnet test sdk/containerapps/Azure.Containers.Apps.Sandbox/tests/Azure.Containers.Apps.Sandbox.Tests.csproj -f net10.0
```

The test suite consolidates the generated TypeSpec scenarios by resource area:

- sandbox CRUD, lifecycle, policy, statistics, commands, and networking;
- volumes, volume files, mounts, snapshots, and sandbox files;
- secrets, content packages, named egress policies, and disk images.

Connection, credential, and interactive stream request construction is covered with `MockTransport`, including pagination, optional query parameters, and request serialization. WebSocket exec and process streams have live-only tests because Azure.Core HTTP recording cannot capture WebSocket frames. The exec stdin test writes an exact byte count through a TTY session, then reads the file through a second exec session to verify that the input reached the container. The HTTP log stream live test checks that historical JSON logs can be read to completion. Provider authorization requires provider-specific secrets and is not exercised by these tests. Long-running disk-image creation and commit scenarios are marked live-only.