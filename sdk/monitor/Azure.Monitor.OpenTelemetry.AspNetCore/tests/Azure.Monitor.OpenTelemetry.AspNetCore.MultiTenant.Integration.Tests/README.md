# Multi-tenant Trace and Log Live Tests

Task 39601050: verify multi-tenant export through a local ASP.NET Core application, the real Azure Monitor exporters, and real Application Insights ingestion. Like the neighboring integration tests, these tests use `Azure.Core.TestFramework` credentials and query Log Analytics for delivered telemetry.

The project runs in a separate test process. Its runtime configuration enables `Azure.Monitor.OpenTelemetry.EnableMultiTenantExport` before the first exporter is constructed. Do not move these fixtures into the ordinary integration test assembly: the exporter caches this switch for the lifetime of the process. Tests run on modern .NET only.

## Coverage

- One trace exporter and one log exporter share a host connection string and route records to at least three other resources, including two tenants sharing an endpoint and another endpoint in a different region.
- Requests, dependencies, correlated logs, exception logs, and logs without an ambient Activity arrive at the intended resource. Operation and parent IDs are checked.
- Missing, invalid, and non-string routing attributes are dropped. Logs must not inherit their route from an Activity or logging scope.
- Each run and record has a unique ID. Every configured workspace is queried, including the host resource, and `_ResourceId` is checked even when resources share a workspace.
- A test-only transport returns HTTP 503 for one endpoint. Other endpoints must still ingest telemetry. The failed endpoint's requests, dependencies, logs, and exceptions must be on disk, then arrive in Azure after recovery and shutdown drain or lease-recovery retries.

Only the failure is simulated; successful ingestion and all queries in the Live tests use Azure. The tests do not disable or alter any Azure service. Separate local pipeline tests use mock ingestion to check the same WebApp/export/storage workflow without Azure.

## Resource Setup

Use dedicated test resources. Telemetry ingestion and Log Analytics queries can incur charges. Do not route these tests to production resources.

### Standard Monitor Provisioner

Use the same resource provisioner as the existing Live tests. From the repository root, authenticate and enable the dedicated topology:

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

This deploys the existing Monitor resources plus four dedicated Application Insights components and two dedicated Log Analytics workspaces. The host, tenant-a, and tenant-b use `westus2`; tenant-c uses `eastus2`. The host/control resource must receive none of the marked telemetry. The template grants Log Analytics Reader on both dedicated workspaces to the signed-in user. Deployment requires permission to create resources and role assignments; the standard provisioner also attempts to grant the test identity Owner on the resource group and sets a `DeleteAfter` tag.

When updating an existing group, pass its original `-BaseName` and resource-group `-Location` to retain baseline resource names and locations. The dedicated regions above are independent of the baseline location. Use `multiTenantPrincipalType = 'ServicePrincipal'` for service-principal authentication; this remains the CI default. The topology is opt-in so other Live jobs do not create these additional resources.

On Windows, the provisioner normally writes encrypted settings, including `MONITOR_MULTI_TENANT_RESOURCES`, to `sdk/monitor/test-resources.bicep.env`. The SDK test framework loads this file when the runner starts the tests; there is no need to copy its contents into an environment variable or chat. Keep the generated file out of source control. Provisioning authentication is separate from test query authentication; the latter must use a credential supported by the test framework.

### Standalone Alternative

The [multi-tenant-resources.bicep](multi-tenant-resources.bicep) module can also deploy only the dedicated resources. Its name deliberately avoids `test-resources.bicep` so the standard provisioner does not discover and deploy it separately from the opt-in Monitor module.

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

Use an approved subscription and identity. The standard Monitor template's `MULTI_TENANT_RESOURCES` output is a JSON string, whereas the standalone template above returns an array.

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

Use workspace GUIDs, not workspace ARM resource IDs. Use full connection strings with explicit HTTPS ingestion endpoints. Each component must have a distinct instrumentation key and ARM resource ID. Local authentication must be enabled for ingestion; the multi-tenant exporter intentionally does not accept Entra credentials. Query authentication still uses the normal SDK test-framework credential, with Log Analytics Reader access to every workspace. For local development, authenticate the query identity through a credential supported by the test framework, such as Azure CLI. Allow time for newly assigned permissions to propagate.

## Run

From this directory, after setting the resource configuration and authenticating:

```powershell
./Run-LiveTests.ps1
```

Or use an existing resource configuration file outside the repository:

```powershell
./Run-LiveTests.ps1 -ResourcesFile '<path-to-resources.json>' -Framework net8.0
```

The runner sets `AZURE_TEST_MODE=Live` and `MONITOR_MULTI_TENANT_REQUIRED=true`, runs only the Live fixtures, writes TRX results to a new temporary directory, checks both required scenarios passed, and restores the caller's environment. Use `-ResultsDirectory` to select a new directory explicitly. Existing directories are rejected to prevent stale results from satisfying the gate. Configuration can come from the SDK test framework's generated environment file, process environment, or `-ResourcesFile`. Without configuration the required fixtures fail during setup instead of skipping. An ordinary test run skips these fixtures outside Live mode, or when optional resource configuration is absent. Missing resources in required CI mode fail; malformed configuration always fails.

For local validation without Azure:

```powershell
dotnet test ./Azure.Monitor.OpenTelemetry.AspNetCore.MultiTenant.Integration.Tests.csproj -f net8.0 --filter 'TestCategory!=Live'
./Test-LiveTestInfrastructure.ps1
```

Ingestion is polled every 30 seconds for up to ten minutes per phase. After all expected records appear, queries continue for a one-minute negative-observation window. Cross-tenant delivery, host fallback, unexpected records, partial query results, and correlation mismatches fail immediately. Duplicate copies with the same record ID are tolerated because delivery is not an exactly-once guarantee. Absence checks cover only the configured workspaces and bounded observation window, not arbitrarily late ingestion.

Storage assertions include both `.blob` and leased `.lock` files. Shutdown gets a one-minute drain budget; replay allows up to seven additional minutes for a three-minute lease and periodic retries. Even the local outage test can take several minutes if the eager drain acquires a lease. Each scenario is bounded to 35 minutes and reports its run ID for investigation. Temporary storage is removed after provider disposal.

## Automation

The existing `net - Azure.Monitor.OpenTelemetry.AspNetCore - tests` pipeline uses [AspNetCore tests.yml](../../tests.yml) and adds [one dedicated matrix entry](../multi-tenant-matrix.json) through the standard Live Test templates. No new Azure DevOps pipeline definition is needed. The separate Exporter tests pipeline is unchanged: the AspNetCore pipeline already hosts WebApp-based exporter ingestion tests and discovers this sibling assembly through `eng/service.proj`. The existing matrix remains in place; its jobs exclude these Live scenarios. The additional Public-cloud Windows/.NET 8 job uses project references, enables `enableMultiTenantExport`, and explicitly selects Live mode and these fixtures. The job timeout is 100 minutes, including resource provisioning and cleanup.

For the first real run, publish the changes through the normal review process to a trusted revision the existing pipeline can read, then use its manual or authorized PR run mechanism. Uncommitted local changes cannot be tested by a remote agent. Confirm the selected revision includes this YAML and that `MultiTenantExport_Windows_NET8` appears in the generated matrix. Do not exclude it with `jobMatrixFilter`: a gate inside a job cannot detect that the whole job was filtered out. Record the run URL, commit SHA, two synchronous scenario results, and cleanup evidence. No separate local runner is invoked by CI.

The Monitor resource template passes the pipeline identity to the dedicated module and exposes its configuration as `MONITOR_MULTI_TENANT_RESOURCES`. The standard resource tooling masks deployment output values and passes them to subsequent tasks. The dedicated job sets `MONITOR_MULTI_TENANT_REQUIRED=true` so missing outputs fail instead of skipping. No developer-created resource file is needed in CI.

The default service connection is `azure-sdk-tests-public`; the pipeline parameter `publicTestServiceConnection` can select another approved connection for both deployment and cleanup verification. The standard template uses workload identity federation. `TestEnvironment.Credential` uses `AzurePipelinesCredential` with the job token and service connection identifiers for queries, unless an explicitly configured client-secret credential takes precedence. Do not configure an ingestion credential for the multi-tenant exporters.

The inherited agent subnet setup also uses the existing `azure-sdk-tests` service connection. Reuse the established pipeline authorization for both connections and the agent pool; do not create new credentials or bypass approval checks to resolve access failures.

TRX files go to a build/attempt-specific directory under `artifacts/multi-tenant-results`. The standard job publishes test results even after failures. A post-step requires both synchronous scenarios to pass; zero tests, missing results, skipped required cases, or failures cannot satisfy the gate. The framework's separate asynchronous variants are excluded by `[SyncOnly]` and are not required cases. `Test-LiveTestInfrastructure.ps1` checks this gate using synthetic XML fixtures, not Azure results.

The standard removal step attempts to delete the resource group even after deployment/test failure. An additional check fails if the group remains and is not in `Deleting` state. Deletion may be asynchronous; this check verifies acceptance, not guaranteed completion. Agent loss or cancellation can prevent cleanup steps from finishing. A maintainer must confirm the scheduled cleanup process that honors the standard `DeleteAfter` tag; Azure does not automatically delete resources merely because that tag exists.

The additional job participates in existing scheduled and manual runs when the chosen revision includes these changes. Preserve the generator-managed schedules and comment-authorized PR rules. The YAML also enables relevant `main` push triggers and declares `pr: none`, but ADO definition overrides can take precedence; that declaration does not disable the generator's authorized PR mechanism. Before relying on immediate post-merge coverage, maintainers must confirm the existing definition's effective CI trigger. A working push trigger is not a prerequisite for the first authorized Live run. Service connection authorization and trusted-branch controls must prevent untrusted PR/fork code from using the cloud identity. Required subscription permissions include resource creation/deletion and role assignments, with allowed regions `westus2` and `eastus2` by default. No secrets should be placed in source control or chat.

Cloud validation is still pending: local tests and template checks do not establish successful Azure ingestion, cleanup completion, or automatic triggering. Acceptance requires an actual CI run on the intended revision with both scenarios passing and resource lifecycle evidence. For standalone local deployment, remove the dedicated group through your subscription's approved cleanup process when finished.