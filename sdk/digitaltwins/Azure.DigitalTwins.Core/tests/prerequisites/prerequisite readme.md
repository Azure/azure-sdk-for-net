# Prerequisites

## Install

### Install the latest Powershell 7

- Make sure you run the script using the latest stable version of [powershell 7](https://github.com/PowerShell/PowerShell/releases)

### Install the latest Azure CLI package

- If already installed, check latest version:
  - Run `az --version` to make sure `azure-cli` is at least **version 2.3.1**
  - If it isn't, update it
- Use this link to install [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest])

## Delete

To delete the digital twins instance, you need to first delete the endpoint added by the script (the service doesn't yet support cascading delete).

1. To do this, run the command `az dt endpoint delete -n <dt name> -g <rg name> --en someEventHubEndpoint`.
1. If you have other endpoints that have been added outside this script, you can discover them with the command `az dt endpoint list -n <dt name> -g <rg name>`.
1. Then delete them with the same command in step 1.

## Maintenance

In order to maintain the functionality of the Setup.ps1 file, make sure this document stays updated with all the required changes if you run/alter this script.
