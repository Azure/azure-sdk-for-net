# Prerequisites

## Install

### Install the latest Azure CLI package

- If already installed, check latest version:
  - Run `az --version` to make sure `azure-cli` is at least **version 2.3.1**
  - If it isn't, update it
- Use this link to install [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest])

### Install the Azure IoT extension

- Open a powershell window in admin mode.
- Run `az extension list`
  - If you don't see the azure-iot extension, install it by running `az extension add --name azure-iot`
  - If you see azure-iot extension, update the extension by running `az extension update --name azure-iot`
    - Make sure the latest version is at least **0.9.4**.
- See the top-level IoT commands with `az iot -h`

## Delete

To delete the digital twins instance, you need to first delete the endpoint added by the script (the service doesn't yet support cascading delete).

1. To do this, run the command `az dt endpoint delete -n <dt name> -g <rg name> --en someEventHubEndpoint`.
1. If you have other endpoints that have been added outside this script, you can discover them with the command `az dt endpoint list -n <dt name> -g <rg name>`.
  - Then delete them with the same command in step 1.

## Maintenance

In order to maintain the functionality of the Setup.ps1 file, make sure this document stays updated with all the required changes if you run/alter this script.
