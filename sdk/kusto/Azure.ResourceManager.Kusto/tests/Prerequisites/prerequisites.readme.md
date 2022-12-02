# Prerequisites

## Install

- Install the latest [Powershell 7](https://github.com/PowerShell/PowerShell/releases)
- Install the latest [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest])
- Install `Az.Kusto` module by running `Install-Module Az.Kusto` in PowerShell

## Usage

The `.\setup.ps1` has two purposes:
1. Create all the resources that the tests require
2. Output environment variables which the tests can consume using `GetRecordedVariable` function as explained [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#test-environment-and-live-test-resources)

## Maintenance

1. Change Data folder and test-resources.bicep file to meet test resource and environment variable requirements
2. Make sure this document stays updated.

## Useful Resources

- [Test Environment and Test Resources](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#test-environment-and-live-test-resources)
- [Test Resource Management](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md)
- [New-TestResources](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/TestResources/New-TestResources.ps1.md)
