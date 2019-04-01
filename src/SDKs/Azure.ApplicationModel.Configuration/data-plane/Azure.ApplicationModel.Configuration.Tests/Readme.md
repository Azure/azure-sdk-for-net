# Enable Tests against Live Server

## Prerequisites
- Get [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
- Have an [Azure subscription](https://docs.microsoft.com/azure/guides/developer/azure-developer-guide#understanding-accounts-subscriptions-and-billing). More information about how to create a [free account](https://azure.microsoft.com/free/?ref=microsoft.com&utm_source=microsoft.com&utm_medium=docs&utm_campaign=visualstudio).

## Usage
Create or use an existing [Configuration Store](https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-dotnet-core-app#create-an-app-configuration-store).

For users that have access to the `Azure SDK Developer Playground` subscription, run:
1. `az login`
2. `az extension add --source https://azconfigextensions.blob.core.windows.net/azconfigextension/azconfig-0.3.0-py2.py3-none-any.whl`
3. `az azconfig credential list -n azconfig`

    **Note**: If you see the error similar to: `InvalidResourceNamespace - The resource namespace 'Microsoft.Azconfig' is invalid.` make sure to add the subscription `Azure SDK Developer Playground` as your active subscription. To do this:
    1. Check your active subscription value by doing `az account show`
    2. Set default `az account set --subscription {Name or ID of subscription}`
    3. Double check your active subscription value by doing `az account show`
5. From the output, get the first connection string and add it as `AZ_CONFIG_CONNECTION` environment variable's value.
6. Make sure to restart VS or the environment where the tests are running.


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsrc%2FSDKs%2FAzure.ApplicationModel.Configuration%2Fdata-plane%2FAzure.Configuration.Tests%2FReadme.png)
