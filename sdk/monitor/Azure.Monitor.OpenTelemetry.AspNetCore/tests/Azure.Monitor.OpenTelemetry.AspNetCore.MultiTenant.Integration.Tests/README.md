# Multi-tenant Trace and Log Live Tests

These tests verify multi-tenant trace and log export from a local ASP.NET Core application to Application Insights. They use `Azure.Core.TestFramework` credentials to query Log Analytics and verify that telemetry reaches the intended resources.

The project enables `Azure.Monitor.OpenTelemetry.EnableMultiTenantExport` in a separate test process because the exporter caches this switch for the lifetime of the process. The runner defaults to .NET 8 and also supports .NET 9 and .NET 10.

## Coverage

- One trace exporter and one log exporter share a host connection string and route records to at least three other resources, including two tenants sharing an endpoint and another endpoint in a different region.
- Requests, dependencies, correlated logs, exception logs, and logs without an ambient Activity arrive at the intended resource. Operation and parent IDs are checked.
- Missing, invalid, and non-string routing attributes are dropped. Logs must not inherit their route from an Activity or logging scope.
- Each run and record has a unique ID. Every configured workspace is queried, including the host resource, and `_ResourceId` is checked even when resources share a workspace.
- A test-only transport returns HTTP 503 for one endpoint. Other endpoints must still ingest telemetry. The failed endpoint's requests, dependencies, logs, and exceptions must be on disk, then arrive in Azure after recovery and shutdown drain or lease-recovery retries.

Only the ingestion failure is simulated; successful ingestion and all queries use Azure. Separate local tests use mock ingestion to exercise the same export and storage workflow without Azure.

## Resource Setup

Use dedicated test resources, not production resources. Telemetry ingestion and Log Analytics queries can incur charges.

### Standard Monitor Provisioner

From the repository root:

```powershell
Connect-AzAccount -Subscription 'YOUR SUBSCRIPTION ID'
eng\common\TestResources\New-TestResources.ps1 `
  -ServiceDirectory monitor `
  -SubscriptionId 'YOUR SUBSCRIPTION ID' `
  -ResourceGroupName 'YOUR RESOURCE GROUP NAME' `
  -AdditionalParameters @{
    enableMultiTenantExport = $true
    multiTenantPrincipalType = 'User'
    multiTenantPrimaryLocation = 'westus2'
    multiTenantSecondaryLocation = 'eastus2'
  }
```

This deploys the existing Monitor resources plus four Application Insights components and two Log Analytics workspaces. The host, tenant-a, and tenant-b use `westus2`; tenant-c uses `eastus2`. The template grants Log Analytics Reader on both dedicated workspaces to the signed-in user. Deployment requires permission to create resources and role assignments; the standard provisioner also attempts to grant the test identity Owner on the resource group.

When updating an existing group, pass its original `-BaseName` and resource-group `-Location` to retain baseline resource names and locations. The dedicated regions above are independent of the baseline location. Use `multiTenantPrincipalType = 'ServicePrincipal'` for service-principal authentication; this remains the CI default. The topology is opt-in so other Live jobs do not create these additional resources.

On Windows, the provisioner normally writes encrypted settings to `sdk/monitor/test-resources.bicep.env`. The test framework loads this file automatically. Keep the generated file out of source control. Configure query authentication separately as described below.

### Standalone Alternative

To deploy only the dedicated resources, use [multi-tenant-resources.bicep](multi-tenant-resources.bicep).

From this directory, using Azure PowerShell:

```powershell
Connect-AzAccount -Subscription '<subscription-id>'
$resourceGroup = '<dedicated-test-resource-group>'
New-AzResourceGroup -Name $resourceGroup -Location westus2
$deployment = New-AzResourceGroupDeployment `
    -Name multi-tenant-export-tests `
    -ResourceGroupName $resourceGroup `
    -TemplateFile ./multi-tenant-resources.bicep `
    -testApplicationOid '<query-identity-object-id>' `
    -principalType User `
    -primaryLocation westus2 `
    -secondaryLocation eastus2
$env:MONITOR_MULTI_TENANT_RESOURCES = ConvertTo-Json -InputObject $deployment.Outputs.MULTI_TENANT_RESOURCES.Value -Depth 5 -Compress
$env:MONITOR_LOGS_ENDPOINT = $deployment.Outputs.LOGS_ENDPOINT.Value
```

Use `ServicePrincipal` for a CI identity. The regions must produce different ingestion endpoints; the test validates this and also requires at least two routed tenants to share an endpoint. For sovereign clouds, choose supported regions and set the appropriate `logsEndpoint` and Azure authentication authority. The automated matrix currently targets Azure Public cloud only.

Alternatively, set `MONITOR_MULTI_TENANT_RESOURCES` to a JSON array describing existing resources, or pass an external JSON file to the runner. Keep resource configuration out of source control:

```json
[
  {
    "name": "host",
    "connectionString": "InstrumentationKey=<host-guid>;IngestionEndpoint=https://<host-endpoint>/",
    "workspaceId": "<workspace-guid>",
    "resourceId": "/subscriptions/<subscription>/resourceGroups/<group>/providers/Microsoft.Insights/components/<host>"
  },
  {
    "name": "tenant-a",
    "connectionString": "InstrumentationKey=<tenant-a-guid>;IngestionEndpoint=https://<region-one-endpoint>/",
    "workspaceId": "<workspace-guid>",
    "resourceId": "/subscriptions/<subscription>/resourceGroups/<group>/providers/Microsoft.Insights/components/<tenant-a>"
  },
  {
    "name": "tenant-b",
    "connectionString": "InstrumentationKey=<tenant-b-guid>;IngestionEndpoint=https://<region-one-endpoint>/",
    "workspaceId": "<workspace-guid>",
    "resourceId": "/subscriptions/<subscription>/resourceGroups/<group>/providers/Microsoft.Insights/components/<tenant-b>"
  },
  {
    "name": "tenant-c",
    "connectionString": "InstrumentationKey=<tenant-c-guid>;IngestionEndpoint=https://<region-two-endpoint>/",
    "workspaceId": "<workspace-guid>",
    "resourceId": "/subscriptions/<subscription>/resourceGroups/<group>/providers/Microsoft.Insights/components/<tenant-c>"
  }
]
```

Use workspace GUIDs, not workspace ARM resource IDs. Use full connection strings with explicit HTTPS ingestion endpoints. Each component must have a distinct instrumentation key and ARM resource ID. Local authentication must be enabled for ingestion; the multi-tenant exporter intentionally does not accept Entra credentials. Query authentication still uses the normal SDK test-framework credential, with Log Analytics Reader access to every workspace. Allow time for newly assigned permissions to propagate.

### Local Query Authentication

To reuse your Azure PowerShell login instead of the framework's default developer credential (including Windows broker authentication), opt in before starting the tests:

```powershell
Connect-AzAccount -Tenant '<tenant-id>' -Subscription '<subscription-id>'
$env:MONITOR_USE_AZURE_POWERSHELL_CREDENTIAL = 'true'
./Run-LiveTests.ps1
```

The account must have Log Analytics Reader access to all test workspaces. `MONITOR_TENANT_ID`, normally loaded from the generated environment file, selects the query tenant; set it explicitly when using standalone resource configuration.

Configured client-secret and Azure Pipelines credentials take precedence over this flag. Leave it unset in CI. To return to the default developer credential, run `Remove-Item Env:MONITOR_USE_AZURE_POWERSHELL_CREDENTIAL`.

## Run

From this directory, after setting the resource configuration and authenticating:

```powershell
./Run-LiveTests.ps1
```

Or use an existing resource configuration file outside the repository:

```powershell
./Run-LiveTests.ps1 -ResourcesFile '<path-to-resources.json>' -Framework net8.0
```

The runner enables Live mode, requires resource configuration, and verifies that both scenarios pass. TRX results are written to a new temporary directory; use `-ResultsDirectory` to specify another directory that does not already exist. Resource configuration can come from the generated environment file, environment variables, or `-ResourcesFile`.

Ordinary test runs skip the Azure scenarios outside Live mode or when resource configuration is absent. Use the runner to treat missing configuration as a failure.

For local validation without Azure:

```powershell
dotnet test ./Azure.Monitor.OpenTelemetry.AspNetCore.MultiTenant.Integration.Tests.csproj -f net8.0 --filter 'TestCategory!=Live'
./Test-LiveTestInfrastructure.ps1
```

Tests poll ingestion every 30 seconds for up to ten minutes per phase, then observe for another minute to detect unexpected delivery. Duplicate records are tolerated. Each scenario has a 35-minute timeout and reports its run ID for troubleshooting.

The outage scenario checks persisted telemetry and retries after endpoint recovery. It can take several minutes even with mock ingestion because of storage leases and retry intervals. Temporary storage is removed after each scenario.

## CI

The [AspNetCore live-test pipeline](../../tests.yml) runs these scenarios in a dedicated [Windows/.NET 8 matrix job](../multi-tenant-matrix.json) in Azure Public cloud. The job builds with project references, provisions the dedicated resources, and runs the Live fixtures. Baseline matrix jobs exclude these scenarios.

The shared pipeline templates handle authentication, result publishing, and resource cleanup. Missing resource configuration fails the dedicated job. Two synchronous scenarios are expected to pass; the asynchronous fixture variants are skipped by `[SyncOnly]`.

The pipeline uses `trigger: none` and participates in existing scheduled and manual runs.

## Cleanup

Delete locally provisioned test resources when finished. The standard provisioner's `DeleteAfter` tag requires an external cleanup process; Azure does not automatically delete tagged resources.