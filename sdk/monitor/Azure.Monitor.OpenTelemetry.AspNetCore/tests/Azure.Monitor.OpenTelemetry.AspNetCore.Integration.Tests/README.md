# Azure Monitor Distro client library for .NET

This project is the Integration tests using the [Azure SDK TestFramework](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md).

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

    When this script is finished, it will create a file called `test-resources.bicep` in your `monitor` directory.
    This file is not checked-in and represents your unique test environment.

3. You should log into your Azure subscription and confirm that a new resource group was created with an Application Insights resource.
When running the tests locally, this is the Application Insights resource that telemetry will be published to.

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
