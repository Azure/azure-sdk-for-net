# Prerequisites

## Install

### Install the latest Powershell 7

- Make sure you run the script using the latest stable version of [powershell 7](https://github.com/PowerShell/PowerShell/releases)

### Install the latest Azure CLI package

- If already installed, check latest version:
  - Run `az --version` to make sure `azure-cli` is at least **version 2.3.1**
  - If it isn't, update it
- Use this link to install [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest])

### Install Bicep

- Install using the instructions in [bicep](https://github.com/Azure/bicep/blob/main/docs/installing.md)

### Generate the ARM template

The ARM template [test-resources.json](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/timeseriesinsights/test-resources.json) is generated from the [test-resources.bicep](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/timeseriesinsights/test-resources.bicep) file by running the following script

- `.\generateArmTemplate.ps1`

> **Note**: Do not update the ARM template (test-resources.json) manually. Any changes should be made only to the test-resources.bicep file and the ARM template (test-resources.json) should be generated using the above command.

### Run the setup script

- `.\setup.ps1`

## Maintenance

In order to maintain the functionality of the Setup.ps1 file, make sure this document stays updated with all the required changes if you run/alter this script.
