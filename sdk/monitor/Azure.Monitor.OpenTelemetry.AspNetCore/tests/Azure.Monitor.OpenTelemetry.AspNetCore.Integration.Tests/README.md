# Azure Monitor Distro client library for .NET

This project is the Integration tests using the [Azure SDK TestFramework](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md).

Multi-tenant trace and log routing is tested in the separate [multi-tenant integration test project](../Azure.Monitor.OpenTelemetry.AspNetCore.MultiTenant.Integration.Tests/README.md). It enables the process-wide routing switch and verifies real Azure ingestion, tenant isolation, and outage recovery using dedicated resources.

## Getting started

### First time setup

To run these tests locally you must first create your test resources.

1. Connect to an Azure Subscription. This command requires the [Azure PowerShell module](https://learn.microsoft.com/powershell/azure/install-az-ps).

    ```powershell
    Connect-AzAccount -Subscription 'YOUR SUBSCRIPTION ID'
    ```

2. Then run the New-TestResources cmd which will create the required test resources.

    ```powershell
    eng\common\TestResources\New-TestResources.ps1 -ServiceDirectory monitor -SubscriptionId 'YOUR SUBSCRIPTION ID' -ResourceGroupName 'YOUR RESOURCE GROUP NAME'
    ```

    If this script fails, it should instruct you to install any missing dependencies.

    The script deploys the checked-in `sdk/monitor/test-resources.bicep` template.
    On Windows, it normally writes encrypted settings to `sdk/monitor/test-resources.bicep.env`.
    This generated environment file is not checked in and represents your unique test environment.

3. You should log into your Azure subscription and confirm that a new resource group was created with an Application Insights resource.
When running the tests locally, this is the Application Insights resource that telemetry will be published to.

### Running in CI

The existing [tests.yml](../../tests.yml) uses the repository's Azure Pipelines Live Test templates to deploy resources, run tests, remove resources, and publish TRX results. CI does not use your local `Connect-AzAccount` session or environment file. Deployment authentication comes from the authorized Azure Resource Manager service connection; query authentication is supplied through the SDK test framework's pipeline credential flow.

The multi-tenant scenarios run in an additional Windows/.NET 8 matrix job with opt-in resources and strict result checks. Existing matrix jobs retain their tests and exclude these dedicated scenarios. See the [multi-tenant CI setup and prerequisites](../Azure.Monitor.OpenTelemetry.AspNetCore.MultiTenant.Integration.Tests/README.md#automation).

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
