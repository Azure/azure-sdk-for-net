# Azure Container Apps Sandbox client library for .NET

Azure.Containers.Apps.Sandbox is a client library for developing .NET applications with rich experience.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Containers.Apps.Sandbox --prerelease
```

### Prerequisites

- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

Azure Container Apps Sandbox uses Microsoft Entra ID authentication. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package and create a `ContainerAppsSandboxClient` with a `TokenCredential`, such as `DefaultAzureCredential`.

## Key concepts

## Examples

## Troubleshooting

## Next steps

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