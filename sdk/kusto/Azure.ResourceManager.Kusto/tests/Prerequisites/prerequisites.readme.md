# Prerequisites

## Install

- Install the latest [Powershell 7](https://github.com/PowerShell/PowerShell/releases)
- Install the latest [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest])
- Install `Az.Kusto` module by running `Install-Module Az.Kusto` in PowerShell

## Usage

We have created several scripts to make testing process easier
All scripts should be triggered from this path `azure-sdk-for-net\sdk\kusto\Azure.ResourceManager.Kusto`
For example `.\tests\Prerequisites\Scripts\CreateTestResources.ps1`

- CreateTestResources: create all the required resource for testing, EventHub, Storage and so on
- RunTestsInRecordMode: run the test in record mode and create recording for all kusto calls
- RunTestsInPlaybackMode: run the test in playback mode instead of "real" calls reuse the calls from the recording
- CleanupTestResources: clean up all the resource created in "CreateTestResources" step

## Maintenance

1. Change Data folder and test-resources.bicep file to meet test resource and environment variable requirements
2. Make sure this document stays updated.

## Useful Resources

- [Test Environment and Test Resources](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md#test-environment-and-live-test-resources)
- [Test Resource Management](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md)
- [New-TestResources](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/TestResources/New-TestResources.ps1.md)
