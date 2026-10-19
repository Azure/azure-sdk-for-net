# Microsoft Azure Edge Actions management client library for .NET

Azure Edge Actions enables you to deploy and manage serverless edge functions that run on Azure Front Door infrastructure. Execute custom code at the edge to modify requests and responses, implement custom routing logic, and perform other edge computing tasks with low latency.

This library supports managing Microsoft Azure Edge Actions resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started

### Install the package

Install the Microsoft Azure Edge Actions management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.EdgeActions  --prerelease
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

**EdgeAction**: A serverless function that executes at the edge on Azure Front Door infrastructure.

**EdgeActionVersion**: A specific version of an edge action, allowing you to manage multiple versions and deploy updates incrementally.

**EdgeActionExecutionFilter**: A filter that controls when and how edge actions are executed based on custom headers or conditions.

## Documentation

Documentation is available to help you learn how to use this package:

* [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
* [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
* [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

Code samples for using the management library for .NET can be found in the following locations

* [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

### Create an EdgeAction

```csharp
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.EdgeActions;
using Azure.ResourceManager.EdgeActions.Models;
using Azure.ResourceManager.Resources;

ArmClient client = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync("myResourceGroup");

EdgeActionCollection edgeActions = resourceGroup.GetEdgeActions();
EdgeActionData data = new EdgeActionData(
    new AzureLocation("global"),
    new EdgeActionSkuType("Standard", "Standard"));

ArmOperation<EdgeActionResource> operation = await edgeActions.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "myEdgeAction",
    data
);
EdgeActionResource edgeAction = operation.Value;
```

### List EdgeActions

```csharp
await foreach (EdgeActionResource edgeAction in resourceGroup.GetEdgeActions())
{
    Console.WriteLine(edgeAction.Data.Name);
}
```

## Troubleshooting

* File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
* Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

### Running tests

The tests use the repository's [management recorded-test framework](../../core/Azure.Core.TestFramework/README.md).
Run from the repository root:

```powershell
dotnet test sdk\edgeactions\Azure.ResourceManager.EdgeActions\tests\Azure.ResourceManager.EdgeActions.Tests.csproj -f net10.0
```

Playback is the default and does not require Azure credentials. Offline tests under `tests\Unit`
cover patch serialization and sync/async long-running-operation behavior using mock responses;
these are not substitutes for service recordings.

Recorded scenarios cover resource lookup, tag replacement and clearing, and version metadata
CRUD for file and ZIP deployment types. `VersionsAndExecutionFilters` additionally covers code
deployment, version-code retrieval, default-version swaps, and execution-filter lifecycle operations.
`ExecutionFilterLifecycle` independently covers filters referencing newly created versions, so
deployment failures do not prevent filter creation, reassignment, update, and deletion from running.
All scenarios participate in Record and Playback modes in both sync and async fixtures.
Service failures must fail the recording run; do not skip scenarios or publish failed diagnostic
recordings as successful coverage.

Resource groups use the
`dotnetsdk-edgeaction-test-` prefix in East US, and Edge Actions use the `eadotnet` prefix in
the `global` location. Both use `Recording.GenerateAssetName`; child versions (`v1`, `v2`)
and filters (`sdkfilter`) are scoped to each test's new Edge Action. The management framework
cleans up resource groups, including when a test fails.

To create fresh recordings using an Azure CLI login with permission to manage these test resources:

```powershell
az login
az account set --subscription "<subscription-id>"
$env:EDGEACTIONS_USE_AZURE_CLI = "true"
$env:AZURE_TEST_MODE = "Record"
dotnet test sdk\edgeactions\Azure.ResourceManager.EdgeActions\tests\Azure.ResourceManager.EdgeActions.Tests.csproj -f net10.0
Remove-Item Env:AZURE_TEST_MODE
```

With this opt-in, local Record/Live setup reads the selected Azure CLI account and fills missing
subscription and tenant settings for the test process. Explicit `EDGEACTIONS_SUBSCRIPTION_ID` /
`EDGEACTIONS_TENANT_ID` or `AZURE_SUBSCRIPTION_ID` / `AZURE_TENANT_ID` settings remain authoritative:
an explicit subscription selects the account queried, and a mismatched tenant fails setup rather
than silently changing the target. The tests never run `az login` or change the selected CLI account.

Before recording requests, setup checks `Microsoft.Cdn` registration in that subscription. It registers
the provider only when needed and waits up to 10 minutes for registration to complete. This requires
permission to register resource providers; authentication, permission, and timeout failures fail setup.
Initialization runs once per test process and is excluded from recordings. Playback performs no CLI
account lookup or provider registration, even when the opt-in remains set. CI, service-principal, and
pipeline credentials retain their existing behavior.

To record just the version deployment and execution-filter scenarios with the same credentials:

```powershell
$env:AZURE_TEST_MODE = "Record"
dotnet test sdk\edgeactions\Azure.ResourceManager.EdgeActions\tests\Azure.ResourceManager.EdgeActions.Tests.csproj -f net10.0 --filter 'FullyQualifiedName~VersionsAndExecutionFilters|FullyQualifiedName~ExecutionFilterLifecycle'
Remove-Item Env:AZURE_TEST_MODE
```

Deployment and filter operations can take several minutes each. A terminal `Failed` polling
status is an operation failure, even when the polling endpoint returns HTTP 200.

Recorded scenarios use a shared cancellation token for the entire test, including requests and LRO
polling in both sync and async fixtures. Timeout budgets are 20 minutes without deployments, or
40 minutes per budgeted deployment plus a 10-minute buffer: 50, 90, and 130 minutes for one, two,
and three deployments. Lookup, tag, and version-metadata tests use 20 minutes; the independent
filter lifecycle uses 90 minutes. The combined version/swap scenario uses the requested 130-minute
total budget for two code deployments and the swap; its existing filter steps share that budget.
The framework's shorter playback limits remain unchanged, and resource-group cleanup runs
independently of the test's cancellation token.

The CLI credential is an opt-in for local development; normal framework credentials remain
the default. Test Proxy sanitizes signed polling query values without collapsing status and
result URLs, and playback continues to match API versions.

Recordings are stored in the external Azure SDK assets repository, not in this package.
After reviewing recordings for sensitive data, publish them and commit the updated `assets.json`:

```powershell
test-proxy push -a sdk\edgeactions\Azure.ResourceManager.EdgeActions\assets.json
```

Response-schema checks must use the OpenAPI version and commit pinned by `tsp-location.yaml`,
not assume that a passing playback run proves schema compliance. For this refresh, check only
the `status` field of async-operation polling bodies and defer the known `validationStatus`
nullability discrepancy. Also skip validation of the final HTTP 200 response obtained by following
`swapDefault`'s `Location` header until the RP fix is available after this SDK release. This exception
does not apply to polling failures or subsequent ordinary GETs of the same version resource.
All other responses, including other final resource and version-code bodies, still require validation.

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
