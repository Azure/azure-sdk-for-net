# Prerequisites

### Install the latest Powershell 7

- Make sure you run the script using the latest stable version of [powershell 7](https://github.com/PowerShell/PowerShell/releases)

### Install the latest Azure CLI package

- If already installed, check latest version:
  - Run `az --version` to make sure `azure-cli` is at least **version 2.3.1**
  - If it isn't, update it
- Use this link to install [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest])

### Install Bicep

- Install using the instructions in [bicep](https://learn.microsoft.com/azure/azure-resource-manager/bicep/install#install-manually)
- Note that to deploy Bicep files, use Bicep CLI version 0.4.1124 or later. To check your Bicep CLI version, run:

```bash
bicep --version
```

### Run the setup script

The script creates required resources in your azure subscription that allows you to run live tests against them. Run the following command:

- `.\setup.ps1 -Region [YOUR REGION] -ResourceGroup [YOUR DESIRED RESOURCE GROUP NAME] -SubscriptionId [YOUR SUBSCRIPTION ID] -DigitalTwinName [YOUR DESIRED DIGITAL TWIN INSTANCE NAME] -AppRegistrationName [YOUR APP REGISTRATION] -Verbose`

### Generate the ARM template

The ARM template is generated from the [test-resources.bicep](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/digitaltwins/test-resources.bicep) file by running the following script

- `.\generateArmTemplate.ps1`

> **Note**: Do not update the ARM template (test-resources.json) manually. Any changes should be made only to the test-resources.bicep file and the ARM template (test-resources.json) should be generated using the above command.

## Maintenance

In order to maintain the functionality of the Setup.ps1 file, make sure this document stays updated with all the required changes if you run/alter this script.
