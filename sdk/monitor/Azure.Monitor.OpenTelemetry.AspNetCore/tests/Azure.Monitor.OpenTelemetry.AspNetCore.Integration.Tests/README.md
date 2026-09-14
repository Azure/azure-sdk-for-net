# Azure Monitor Distro client library for .NET

This project is the Integration tests using the [Azure SDK TestFramework](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md).

## Getting started

### First time setup

Before running these integration tests against Azure for the first time, you must first create the required Azure test resources by following the setup steps below. Run the commands from the repository root (`azure-sdk-for-net`) in PowerShell, and install the repository's required .NET SDK and the .NET 8 runtime before running the tests.

1. Connect to an Azure Subscription. This command requires the [Azure PowerShell module](https://learn.microsoft.com/powershell/azure/install-az-ps).

    ```powershell
    Connect-AzAccount -Subscription 'YOUR SUBSCRIPTION ID'
    ```

2. Then run the New-TestResources cmd which will create the required test resources.

    ```powershell
    eng\common\TestResources\New-TestResources.ps1 -ServiceDirectory monitor -SubscriptionId 'YOUR SUBSCRIPTION ID' -ResourceGroupName 'YOUR RESOURCE GROUP NAME'
    ```

    If this script fails, it should instruct you to install any missing dependencies.

    On Windows, this script normally creates `sdk/monitor/test-resources.bicep.env` containing your local test settings. The test framework loads it automatically. It is encrypted for the Windows account that created it; run the tests as that same account, and do not edit or commit this file.

    `sdk/monitor/test-resources.bicep` is the existing, checked-in deployment template, not the generated settings file.

  3. Confirm that the resource group contains two Application Insights resources and their Log Analytics workspaces. The shared Monitor template also creates resources used by other tests.

  ### Run against real Azure resources

  After provisioning, run the existing integration scenarios with Live mode explicitly enabled:

  ```powershell
  $previousMode = $env:AZURE_TEST_MODE
  try {
    $env:AZURE_TEST_MODE = 'Live'

    dotnet test sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.csproj `
      --framework net8.0 `
      --filter "FullyQualifiedName~DistroWebAppLiveTests" `
      --logger "console;verbosity=normal" `
      --logger trx
  }
  finally {
    $env:AZURE_TEST_MODE = $previousMode
  }
  ```

  These tests start a local web application, send telemetry to Application Insights, and query Log Analytics to verify requests, dependencies, metrics, and logs. They cover `UseAzureMonitor`, two named exporters, and `UseAzureMonitorExporter`. This command does not select the separate multi-tenant test suite.

  - Without an explicit mode, recorded tests default to **Playback**. A Playback pass does not validate your deployed Azure resources.
  - Queries retry every 30 seconds for up to 10 minutes per query while waiting for ingestion. Keep local port `9998` available and avoid concurrent runs of this suite.
  - The framework creates sync/async fixture variants; these scenarios use `[SyncOnly]`, so the async variants are skipped. Check that the three synchronous scenarios actually pass.
  - TRX results are written under the test project's `TestResults` directory by default. These local runs do not automatically delete the resource group. Delete the dedicated test resource group when you no longer need it.

  ### Authentication and common failures

  Provisioning authentication and test authentication are separate. The tests use configured service-principal or pipeline credentials when available; otherwise they use the shared Azure SDK test framework's developer authentication. Sign in with an identity that can query the deployed workspaces.

  - **Authentication failed:** confirm the tenant and account used by the developer credential. For Azure PowerShell, use the `Connect-AzAccount` command above; a successful deployment alone does not prove the .NET test client can authenticate.
  - **Query returns 403:** verify the querying identity has access to the workspace and allow time for new role assignments to propagate.
  - **Missing configuration or settings cannot be decrypted:** confirm provisioning completed and `sdk/monitor/test-resources.bicep.env` exists, and use the Windows account that created it. Do not paste its contents into logs or issue reports.
  - **No telemetry found:** check the selected resources, ingestion connectivity, and test output. Resource provisioning and ingestion can take several minutes.

### Multi-tenant export live tests

[MultiTenantExportLiveTests.cs](MultiTenantExportLiveTests.cs) lives in this same
project and reuses [BaseLiveTest.cs](BaseLiveTest.cs). It emits server/client
activities and normal/exception logs through one exporter per signal, then queries
real Azure workspaces for every record's destination and trace correlation. It is
live-only: there are no recordings for this scenario.

#### Provision the additional region

The minimum topology is three Application Insights destinations: tenants A/B share
a region and ingestion endpoint; tenant C uses another region and ingestion
endpoint. The existing template's primary/secondary resources remain unchanged.
The opt-in adds one Application Insights resource, one workspace, and query-reader
role assignments on all three workspaces. Without the opt-in it creates none of
these additions.

After confirming the subscription, identity, permissions, and resource cost, run
from the repository root. Use a dedicated resource group and two supported regions:

```powershell
eng/common/TestResources/New-TestResources.ps1 `
  -ServiceDirectory monitor `
  -SubscriptionId 'YOUR SUBSCRIPTION ID' `
  -ResourceGroupName 'YOUR DEDICATED RESOURCE GROUP NAME' `
  -Location westus2 `
  -ArmTemplateParameters @{
    enableMultiTenantExport = $true
    multiTenantLocation = 'eastus2'
    multiTenantPrincipalType = 'User'
  }
```

The example uses a developer user identity. For a service principal, use
`multiTenantPrincipalType = 'ServicePrincipal'` and the standard deployment
script's service-principal settings. `testApplicationOid` must identify the
identity used for workspace queries. The deployer must be allowed to assign
roles; resource Contributor alone is not sufficient. Do not change the location
of an existing deployment merely to match this example.

The template outputs `MONITOR_MULTI_TENANT_RESOURCES` as a JSON array encoded in
a string. The standard deployment script stores it in the test environment file.
Each entry contains `connectionString`, `workspaceId`, `resourceId`, and `region`.
The first two entries must share an actual endpoint; the third must differ.
Externally supplied resources may use the same schema. Include full connection
strings with explicit ingestion endpoints, keep their values out of logs, and
grant query access to every associated workspace. The test validates resource/key
uniqueness, regions, and actual endpoint diversity before Azure setup.

#### Run in an isolated test host

Run this command separately from ordinary integration tests. Do not combine the
two fixture filters or run the whole assembly with the multi-tenant opt-in enabled.

```powershell
$previousMode = $env:AZURE_TEST_MODE
$previousOptIn = $env:MONITOR_MULTI_TENANT_LIVE
try {
  $env:AZURE_TEST_MODE = 'Live'
  $env:MONITOR_MULTI_TENANT_LIVE = 'true'

  dotnet test sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.csproj `
    --framework net8.0 `
    -p:UseProjectReferenceToAzureClients=true `
    --filter "FullyQualifiedName~MultiTenantExportLiveTests" `
    --logger "console;verbosity=normal" `
    --logger trx

  if ($LASTEXITCODE -ne 0) { throw 'Multi-tenant live tests failed.' }
}
finally {
  $env:AZURE_TEST_MODE = $previousMode
  $env:MONITOR_MULTI_TENANT_LIVE = $previousOptIn
}
```

Check that `RoutesTracesAndLogsAcrossResourcesAndEndpoints` actually passes in
the synchronous fixture. The `[SyncOnly]` asynchronous variant is expected to be
skipped; zero tests or only skips do not constitute live verification. An explicitly
selected Live run with missing opt-in or invalid configuration fails before Azure
setup rather than being silently skipped.

The feature switch is cached process-wide. This fixture enables it before creating
exporters and deliberately does not reset it. A fresh `dotnet test` process supplies
isolation; constructor/setup guards prevent ordinary fixtures from running in the
opted-in host. The fixture is `[Explicit]`, `[LiveOnly]`, and categorized `Manually`,
so ordinary test and package live-pipeline invocations do not select it. This change
does not add a CI matrix or automatic cloud execution. Future CI integration must
use a dedicated, filtered invocation with the opt-in topology.

Verification polls every 30 seconds for up to ten minutes, with a twelve-minute
cancellation limit for query work. It requires all expected records followed by
a one-minute observation window across all destinations. Duplicate delivery is
allowed; unexpected records, wrong destinations/correlation, partial results, and
missing records fail. Absence during this window is bounded evidence, not a promise
that a late record can never arrive. Flush/shutdown calls each have a 60-second
limit. Offline storage is disabled for this routing-only scenario; outage/replay
coverage remains a separate follow-up.

Queries use the existing test credentials; ingestion uses connection strings and
does not receive the query credential. Local framework setup may also read/update
the resource group's expiry tag, requiring the normal test-environment permissions.
A credential or permission error must be resolved before claiming live success.
No resources are deleted by the test itself. Use the existing cleanup procedure for
the dedicated test group after testing; expiry tags alone do not guarantee deletion.

Local topology, result-validation, and isolation checks require no Azure resources:

```powershell
dotnet test sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.csproj `
  --framework net8.0 --filter "FullyQualifiedName~MultiTenantExportValidationTests"
```

### Recording New Tests

To record new tests, you must either

- set the RecordTestMode in the ctor

  `public MyTestClass(bool isAsync) : base(isAsync, RecordedTestMode.Record)`
- or set the Test Mode environment variable

  `$env:AZURE_TEST_MODE = 'Record'`

### Prerequisites

### Install the package

### Authenticate the client

## Key concepts

## Examples

## Troubleshooting

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on contribution process.
