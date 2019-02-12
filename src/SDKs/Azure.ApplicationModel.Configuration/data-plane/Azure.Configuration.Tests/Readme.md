# Enable Tests against Live Server

1. Get [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

Run:

2. `az login`
3. `az extension add --source https://azconfigextensions.blob.core.windows.net/azconfigextension/azconfig-0.3.0-py2.py3-none-any.whl`
4. `az azconfig credential list -n azconfig`

    **Note**: If you see the error similar to: `InvalidResourceNamespace - The resource namespace 'Microsoft.Azconfig' is invalid.` make sure to add the subscription `Azure SDK Developer Playground` as your active subscription. To do this:
    1. Check your active subscription value by doing `az account show`
    2. Set default `az account set --subscription {Name or ID of subscription}`
    3. Double check your active subscription value by doing `az account show`
5. From the output, get the first connection string and add it as `AZ_CONFIG_CONNECTION` environment variable's value.
6. Make sure to restart VS or the environment where the tests are running.
