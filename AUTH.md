# Authentication in Azure Management Libraries for .NET

To use the APIs in the Azure Management Libraries for .NET, as the first step you need to 
create an authenticated client. There are several possible approaches to authentication. This document illustrates a couple of the simpler ones

## Using an authentication file

> ​:warning: Note, file-based authentication is an experimental feature that may or may not be available in later releases. The file format it relies on is subject to change as well.

To create an authenticated Azure client:

```csharp
Azure azure = Azure.Authenticate("my.azureauth").WithDefaultSubscription();
```

The authentication file, referenced as "my.azureauth" in the example above, contains the information of a service principal. You can generate this file using [Azure CLI 2.0](https://github.com/Azure/azure-cli) through the following command. Make sure you selected your subscription by `az account set --subscription <name or id>` and you have the privileges to create service principals.

```bash
az ad sp create-for-rbac --sdk-auth > my.azureauth
```

If you don't have Azure CLI installed, you can also do this in the [cloud shell](https://docs.microsoft.com/en-us/azure/cloud-shell/quickstart). Alternatively, you can login to Fluent SDK through other ways of authentication and create an auth file by following [this sample](https://github.com/Azure/azure-sdk-for-net/blob/Fluent/Samples/GraphRbac/ManageServicePrincipal.cs). For detailed explanations of the content in this auth file, or directions to create the auth file manually, please see [Auth file formats](#auth-file-formats).

## Using `AzureCredentials`

Similarly to the [file-based approach](#using-an-authentication-file), this method requires a [service principal registration](#creating-a-service-principal-in-azure), but instead of storing the credentials in a local file, the required inputs can be supplied directly via an instance of the `AzureCredentials` class:

```csharp
var creds = new AzureCredentialsFactory().FromServicePrincipal(client, key, tenant, AzureEnvironment.AzureGlobalCloud);
var azure = Azure.Authenticate(creds).WithSubscription(subscriptionId);
```

or

```csharp
var creds = new AzureCredentialsFactory().FromServicePrincipal(client, pfxCertificatePath, password, tenant, AzureEnvironment.AzureGlobalCloud);
var azure = Azure.Authenticate(creds).WithSubscription(subscriptionId);
```

where `client`, `tenant`, `subscriptionId`, and `key` or `pfxCertificatePath` and `password` are strings with the required pieces of information about your service principal and subscription. The last parameter, `AzureEnvironment.AzureGlobalCloud` represents the Azure worldwide public cloud. You can use a different value out of the currently supported alternatives in the `AzureEnvironment` enum.

## Auth file formats

Prior to this release, we've been using Java properties file format containing the following information:

```
subscription=########-####-####-####-############
client=########-####-####-####-############
tenant=########-####-####-####-############
key=XXXXXXXXXXXXXXXX
managementURI=https\://management.core.windows.net/
baseURL=https\://management.azure.com/
authURL=https\://login.windows.net/
graphURL=https\://graph.windows.net/
```

or certificate based format:

```
subscription=########-####-####-####-############
client=########-####-####-####-############
tenant=########-####-####-####-############
certificate=<path to certificate file>
certificatePassword=XXXXXXXXXXXXXXXX
managementURI=https\://management.core.windows.net/
baseURL=https\://management.azure.com/
authURL=https\://login.windows.net/
graphURL=https\://graph.windows.net/
```

This format is still supported for backward compatibility at least until 2.0 release of the SDK. Meanwhile, the new JSON based auth file format is introduced and supported across the the fluent .NET SDK, the Java SDK and the Python SDK (more coming!):

```json
{
  "clientId": "b52dd125-9272-4b21-9862-0be667bdf6dc",
  "clientSecret": "ebc6e170-72b2-4b6f-9de2-99410964d2d0",
  "subscriptionId": "ffa52f27-be12-4cad-b1ea-c2c241b6cceb",
  "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
```

or certificate based format:

```json
{
  "clientId": "b52dd125-9272-4b21-9862-0be667bdf6dc",
  "clientCertificate": "<path to certificate file>",
  "clientCertificatePassword": "XXXXXXXXXXXXXXXX",
  "subscriptionId": "ffa52f27-be12-4cad-b1ea-c2c241b6cceb",
  "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
```

If you are using the default Azure public cloud, you can leave all the URL fields blank. 

The `clientId` and `tenantId` are from your service principal registration. If your service principal uses key authentication, `clientSecret` is the password credential added to the service principal. If your service principal uses certificate authentication, `clientCertificate` is the path to your pfx certificate. You also need to provide the `clientCertificatePassword` for the PFX certificate.

This approach enables unattended authentication for your application (i.e. no interactive user login, no token management needed).  The `subscription` represents the subscription ID you want to use as the default subscription. The remaining URIs and URLs represent the end points for the needed Azure services, defaulted to Azure public cloud.
