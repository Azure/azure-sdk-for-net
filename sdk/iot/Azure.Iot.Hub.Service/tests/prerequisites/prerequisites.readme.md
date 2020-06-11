# Prerequisites

## Install

### 1. Install the latest Azure CLI package

- If already installed, check latest version:
  - Run `az --version` to make sure `azure-cli` is at least **version 2.0.8**
  - If it isn't, update it
- Use this link to install [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest])

### 2. Install the Iot extension

- Open powershell window in admin mode.
- Run `az extension list`
  - If you see azure-iot extension, update the extension by running `az extension update --name azure-iot`
  - If you don't see the azure-iot extension, install it by running `az extension add --name azure-iot`
- See the top-level IoT commands with `az iot -h`

## Maintenance

In order to maintain the functionality of the Setup.ps1 file, make sure this document stays updated with all the required changes if you run/alter this script.
