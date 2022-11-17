# Prerequisites

## Install

### Install the latest Powershell 7

- Make sure you run the script using the latest stable version of [powershell 7](https://github.com/PowerShell/PowerShell/releases)

### Install the latest Azure CLI package

- Use this link to install [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest])
- Install Az.Kusto module by running `Install-Module Az.Kusto` in PowerShell

### Run the setup script

- `.\setup.ps1`
- This file should be run before running tests in Record mode (no need to run in playback)

## Maintenance

In order to maintain the functionality of the setup.ps1 file, update the setup.ps1 file, Data folder, and test-resources.bicep file accordingly, and make sure this document stays updated.
Helpful maintenance resources:
    - [Test Environment and Test Resources](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#test-environment-and-live-test-resources)
    - [Test Resource Management](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md)
    - [New-TestResources](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/TestResources/New-TestResources.ps1.md)
