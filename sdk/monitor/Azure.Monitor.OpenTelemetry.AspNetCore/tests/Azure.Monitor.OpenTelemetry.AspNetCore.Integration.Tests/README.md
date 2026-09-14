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
