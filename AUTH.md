#Authentication in Azure Management Libraries for .NET

To use the APIs in the Azure Management Libraries for .NET, as the first step you need to 
create an authenticated client. There are several possible approaches to authentication. This document illustrates a couple of the simpler ones.

## Using an authentication file

> :warning: Note, file-based authentication is an experimental feature that may or may not be available in later releases. The file format it relies on is subject to change as well.

To create an authenticated Azure client:

```csharp
Azure azure = Azure.Authenticate(new File("my.azureauth")).WithDefaultSubscription();
```

The authentication file, referenced as "my.azureauth" in the example above, uses the .NET properties file format and must contain the following information:
```
subscription=########-####-####-####-############
client=########-####-####-####-############
key=XXXXXXXXXXXXXXXX
tenant=########-####-####-####-############
managementURI=https\://management.core.windows.net/
baseURL=https\://management.azure.com/
authURL=https\://login.windows.net/
graphURL=https\://graph.windows.net/
```

This approach enables unattended authentication for your application (i.e. no interactive user login, no token management needed). The `client`, `key` and `tenant` are from [your service principal registration](#creating-a-service-principal-in-azure). The `subscription` represents the subscription ID you want to use as the default subscription. The remaining URIs and URLs represent the end points for the needed Azure services, and the example above assumes you are using the Azure worldwide cloud.

## Using `AzureCredentials`

Similarly to the [file-based approach](#using-an-authentication-file), this method requires a [service principal registration](#creating-a-service-principal-in-azure), but instead of storing the credentials in a local file, the required inputs can be supplied directly via an instance of the `AzureCredentials` class:

```
AzureCredentials credentials = AzureCredentials.FromServicePrincipal(client, key, tenant, AzureEnvironment.AZURE);
Azure azure = Azure.authenticate(credentials).withSubscription(subscriptionId);
```

where `client`, `tenant`, `key` and `subscriptionId` are strings with the required pieces of information about your service principal and subscription. The last parameter, `AzureEnvironment.AZURE` represents the Azure worldwide public cloud. You can use a different value out of the currently supported alternatives in the `AzureEnvironment` enum.

## Creating a Service Principal in Azure

In order for your application to log into your Azure subscription without requiring the user to log in manually, you can take advantage of credentials based on the Azure Active Directory *service principal* functionality. A service principal is analogous to a user account, but it is intended for applications to authenticate themselves without human intervention.

If you save such service principal-based credentials as a file, or store them in environment variables, this can simplify and speed up your coding process.

>:warning: Note: exercise caution when saving credentials in a file. Anyone that gains access to that file will have the same access privileges to Azure as your application. In general, file-based authentication is not recommended in production scenarios and should only be used as a quick shortcut to getting started in dev/test scenarios.

You can easily create a service principal and grant it access privileges for a given subscription through Azure CLI 2.0.

1. Install Azure CLI (>=0.1.0b11) by following the [README](https://github.com/Azure/azure-cli/blob/master/README.rst).
1. Install `jq` (>=1.5) by following the instructions here: https://stedolan.github.io/jq/download/.
1. Login as a user by running command `az login`. If you are not in Azure public cloud, use `az context create` command to switch to your cloud before login.
1. Select the subscription you want your service principal to have access to by running `az account set --subscription <subscription name>`. You can view your subscriptions by `az account list --out jsonc`.
1. Run the following command to create a service principal authentication file.

```
az ad sp create-for-rbac --expanded-view -o json --query "{subscription: subscriptionId, client: client, key: password, tenant: tenantId, managementURI: endpoints.management, baseURL: endpoints.resourceManager, authURL: endpoints.activeDirectory, graphURL: endpoints.activeDirectoryGraphResourceId}" | jq -r "to_entries|map(\"\(.key)=\(.value|sub(\"https:(?<x>.+[^/])/?$\";\"https\\\\:\(.x)/\"))\")|.[]"
```

Now all the pieces are in place to enable authenticating your code without requiring an interactive login nor the need to manage access tokens.

