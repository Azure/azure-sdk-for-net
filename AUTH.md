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
AzureCredentials credentials = AzureCredentials.fromServicePrincipal(client, key, tenant, AzureEnvironment.AZURE);
Azure azure = Azure.authenticate(credentials).withSubscription(subscriptionId);
```

where `client`, `tenant`, `key` and `subscriptionId` are strings with the required pieces of information about your service principal and subscription. The last parameter, `AzureEnvironment.AZURE` represents the Azure worldwide public cloud. You can use a different value out of the currently supported alternatives in the `AzureEnvironment` enum.

## Creating a Service Principal in Azure

In order for your application to log into your Azure subscription without requiring the user to log in manually, you can take advantage of credentials based on the Azure Active Directory *service principal* functionality. A service principal is analogous to a user account, but it is intended for applications to authenticate themselves without human intervention.

If you save such service principal-based credentials as a file, or store them in environment variables, this can simplify and speed up your coding process.

>:warning: Note: exercise caution when saving credentials in a file. Anyone that gains access to that file will have the same access privileges to Azure as your application. In general, file-based authentication is not recommended in production scenarios and should only be used as a quick shortcut to getting started in dev/test scenarios.

You can easily create a service principal and grant it access privileges for a given subscription through Azure CLI 2.0.

1. Create a new blank text file with the format described in section [Using an authentication file](#using-an-authentication-file).
1. Install Azure CLI by following the [README](https://github.com/Azure/azure-cli/blob/master/README.rst).
1. Login by running command `az login`.
1. Select the subscription you want your service principal to have access to by running `az account set <subscription name>`. You can view your subscriptions by `az account list --out jsonc`. Copy the subscription id into `subscription` field in the file.
1. Create a service principal by `az ad sp create-for-rbac`. Copy the **client_id** value into `client` field in the file, and **client_secret** value into `key` field.
1. Assign a role to the service principal. You can find the command to execute in the "Assign a role" section from the output of the previous command. It should look like `az role assignment create --assignee <client id> --role Contributor`. The role can be "Owner", "Contributer", "Reader", etc. For more information about roles in Azure, please refer to https://azure.microsoft.com/en-us/documentation/articles/role-based-access-control-what-is/. 
1. Put your email domain into the `tenant` field, e.g., contoso.com.
1. Assuming you are using the Azure worldwide public cloud, also add the following to your text file: \(Note that this file follows the .NET properties file format, so certain characters, such as colons, need to be escaped with a backslash\)<br/>
    `managementURI=https\://management.core.windows.net/`<br/>
    `baseURL=https\://management.azure.com/`</br>
    `authURL=https\://login.windows.net/`<br/>
    `graphURL=https\://graph.windows.net/`<br/> 
  For other environments, please refer to [AzureEnvironment.cs](https://github.com/Azure/azure-sdk-for-net/blob/Fluent/src/ResourceManagement/ResourceManager/Microsoft.Azure.Management.Fluent.ResourceManager/AzureEnvironment.cs) for their corresponding values. 

Now all the pieces are in place to enable authenticating your code without requiring an interactive login nor the need to manage access tokens.

