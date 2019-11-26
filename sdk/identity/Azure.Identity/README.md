# Azure Identity client library for .NET
 The Azure Identity library provides Azure Active Directory token authentication support across the Azure SDK. It provides a set of TokenCredential implementations which can be used to construct Azure SDK clients which support AAD token authentication.  
 
 This library currently supports:
  - [Service principal authentication](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals)
  - [Managed identity authentication](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview)
  - [User principal authentication](https://docs.microsoft.com/en-us/azure/active-directory/develop/scenario-web-app-sign-user-overview)

  [Source code][source] | [Package (nuget)][package] | [API reference documentation][identity_api_docs] | [Azure Active Directory documentation][aad_doc]



## Getting started

### Install the package

Install the Azure Identity client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Identity
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure Active Directory service principal. If you need to create a service principal, you can use the Azure Portal or [Azure CLI][azure_cli].

#### Creating a Service Principal with the Azure CLI
Use the [Azure CLI][azure_cli] snippet below to create/get client secret credentials.

 * Create a service principal and configure its access to Azure resources:
    ```bash
    az ad sp create-for-rbac -n <your-application-name> --skip-assignment
    ```
    Output:
    ```json
    {
        "appId": "generated-app-ID",
        "displayName": "dummy-app-name",
        "name": "http://dummy-app-name",
        "password": "random-password",
        "tenant": "tenant-ID"
    }
    ```
* Use the returned credentials above to set  **AZURE_CLIENT_ID**(appId), **AZURE_CLIENT_SECRET**(password) and **AZURE_TENANT_ID**(tenant) [environment variables](#environment-variables).

## Key concepts
### Credentials

A credential is a class which contains or can obtain the data needed for a service client to authenticate requests. Service clients across Azure SDK accept credentials when they are constructed and use those credentials to authenticate requests to the service. Azure Identity offers a variety of credential classes in the `Azure.Identity` namespace capable of acquiring an AAD token. All of these credential classes are implementations of the `TokenCredential` abstract class in [Azure.Core][azure_core_library], and can be used by any service client which can be constructed with a `TokenCredential`. 

The credential types in Azure Identity differ in the types of AAD identities they can authenticate and how they are configured: 

|credential class|identity|configuration
|-|-|-
|`DefaultAzureCredential`|service principal or managed identity|none for managed identity; [environment variables](#environment-variables) for service principal
|`ManagedIdentityCredential`|managed identity|constructor parameters
|`EnvironmentCredential`|service principal|[environment variables](#environment-variables)
|`ClientSecretCredential`|service principal|constructor parameters
|`CertificateCredential`|service principal|constructor parameters
|`UserPasswordCredential`|user principal|constructor parameters
|`DeviceCodeCredential`|user principal|constructor parameters / interactive
|`InteractiveBrowserCredential`|user principal|constructor parameters / interactive

Credentials can be chained together to be tried in turn until one succeeds using the `ChainedTokenCredential`; see [chaining credentials](#chaining-credentials) for details.

__Note:__ All credential implementations in the Azure Identity library are threadsafe, and a single credential instance can be used to create multiple service clients.

### DefaultAzureCredential
`DefaultAzureCredential` is appropriate for most scenarios where the application is intended to run in the Azure Cloud. This is because the `DefaultAzureCredential` determines the appropriate credential type based of the environment it is executing in. It supports authenticating both as a service principal or managed identity, and can be configured so that it will work both in a local development environment or when deployed to the cloud. 

The `DefaultAzureCredential` will first attempt to authenticate using credentials provided in the environment. In a development environment you can authenticate as a service principal with the `DefaultAzureCredential` by providing configuration in environment variables as described in the next section.

If the environment configuration is not present or incomplete, the `DefaultAzureCredential` will then determine if a managed identity is available in the current environment.  Authenticating as a managed identity requires no configuration, but does
require platform support. See the
[managed identity documentation](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities) for more details on this.

### Environment variables

`DefaultAzureCredential` and `EnvironmentCredential` are configured for service
principal authentication with these environment variables:

|variable name|value
|-|-
|`AZURE_CLIENT_ID`|service principal's app id
|`AZURE_TENANT_ID`|id of the principal's Azure Active Directory tenant
|`AZURE_CLIENT_SECRET`|one of the service principal's client secrets


## Examples

Following examples are provided below:

* Authenticating with `DefaultAzureCredential`
* Chaining Credentials
* Authenticating a service principal with a client secret
* Authenticating a service principal with a certificate
* Authenticating a user with the default browser
* Authenticating a user with the device code flow

### Authenticating with `DefaultAzureCredential`

This example demonstrates authenticating the `SecretClient` from the [Azure.Security.KeyVault.Secrets][secrets_client_library] client library using the `DefaultAzureCredential`.
```c#
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

// Create a secret client using the DefaultAzureCredential
var client = new SecretClient(new Uri("https://myvault.azure.vaults.net/"), new DefaultAzureCredential());
```
When executing this in a development machine you need to first [configure the environment](#environment-variables) setting the variables `AZURE_CLIENT_ID`, `AZURE_TENANT_ID` and `AZURE_CLIENT_SECRET` to the appropriate values for your service principal.

### Chaining Credentials

The `ChainedTokenCredential` class provides the ability to link together multiple credential instances to be tried sequentially when authenticating. The following example demonstrates creating a credential which will attempt to authenticate using managed identity, and fall back to certificate authentication if a managed identity is unavailable in the current environment.  This example authenticates an `EventHubClient` from the [Azure.Messaging.EventHubs][eventhubs_client_library] client library using the `ChainedTokenCredential`.
```c#
using Azure.Identity;
using Azure.Messaging.EventHubs;

var managedCredential = new ManagedIdentityCredential(clientId);

var certCredential = new CertificateCredential(tenantId, clientId, certificate);

// authenticate using managed identity if it is available otherwise use certificate auth
var credential = new ChainedTokenCredential(managedCredential, certCredential);

var eventHubClient = new EventHubClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);
```

### Authenticating a service principal with a client secret
This example demonstrates authenticating the `BlobClient` from the [Azure.Storage.Blobs][blobs_client_library] client library using the `ClientSecretCredential`.
```c#
using Azure.Identity;
using Azure.Storage.Blobs;

// authenticating a service principal with a client secret
var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

var blobClient = new BlobClient(new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"), credential);
```

### Authenticating a service principal with a certificate
This example demonstrates authenticating the `KeyClient` from the [Azure.Security.KeyVault.Keys][keys_client_library] client library using the `CertificateCredential`.
```c#
using Azure.Identity;
using Azure.Security.KeyVault.Keys;

// authenticating a service principal with a certificate
var certificate = new X509Certificate2("./app/certs/certificate.pfx");

var credential = new CertificateCredential(tenantId, clientId, certificate);

var keyClient = new KeyClient(new Uri("https://myvault.azure.vaults.net/"), credential);
```
### Authenticating a user with the default browser
The `InteractiveBrowserCredential` allows an application to authenticate a user by launching the system's default browser. This example demonstrates authenticating the `BlobClient` from the [Azure.Storage.Blobs][blobs_client_library] client library using the `InteractiveBrowserCredential`.

```c#
using Azure.Identity;
using Azure.Storage.Blobs;

// authenticating a service principal with a client secret
var credential = new InteractiveBrowserCredential(clientId);

var blobClient = new BlobClient(new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"), credential);
```
__Note:__ If a default browser is not available in the system, or the current application does not have permissions to create a process authentication with the `DefaultBrowserCredential` will fail with an `AuthenticationFailedException`.
### Authenticating a user with the device code flow

The device code authentication flow allows an application to display a device code to a user, and then the user will authenticate using this code through a browser, typically on another client.  This authentication flow is most often used on clients that have limited UI and no available browser, such as terminal clients and certain IoT devices.  

This example demonstrates authenticating the `SecretClient` from the [Azure.Security.KeyVault.Secrets][secrets_client_library] client library using the `DeviceCodeCredential`. The sample constructs a `DeviceCodeCredential` with an application client id, and a callback which prints the device code.
```c#
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Threading.Tasks;

Func<DeviceCodeInfo, Task> PrintDeviceCode = code => 
{ 
    Console.WriteLine(code.Message);

    return Task.CompletedTask;
}

// Create a secret client using the DefaultAzureCredential
var client = new SecretClient(new Uri("https://myvault.azure.vaults.net/"), new DeviceCodeCredential(clientId, PrintDeviceCode));
```
## Troubleshooting

Errors arising from authentication can be raised on any service client method which makes a request to the service. This is because the first time the token is requested from the credential is on the first call to the service, and any subsequent calls might need to refresh the token. In order to distinguish these failures from failures in the service client Azure Identity classes raise the `AuthenticationFailedException` with details to the source of the error in the exception message as well as possibly the error message.

For more details on dealing with errors arising from failed requests to Azure Active Directory, or managed identity endpoints please refer to the Azure Active Directory [documentation on authorization error codes][aad_err_doc].

## Next steps
Currently the following client libraries support authenticating with `TokenCredential` and the Azure Identity library.  You can learn more about their use, and find additional documentation on use of these client libraries along samples with can be found in the links below.

- [Azure.Messaging.EventHubs][eventhubs_client_library]
- [Azure.Security.KeyVault.Keys][keys_client_library]
- [Azure.Security.KeyVault.Secrets][secrets_client_library]
- [Azure.Storage.Blobs][blobs_client_library]
- [Azure.Storage.Queues][queues_client_library]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[package]: https://www.nuget.org/packages/Azure.Identity
[aad_doc]: https://docs.microsoft.com/en-us/azure/active-directory/
[aad_err_doc]: https://docs.microsoft.com/en-us/azure/active-directory/develop/reference-aadsts-error-codes
[certificates_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[nuget]: https://www.nuget.org/
[keys_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys
[secrets_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets
[blobs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs
[queues_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues
[eventhubs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs
[azure_core_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core
[identity_api_docs]: https://azure.github.io/azure-sdk-for-net/identity.html
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fidentity%2FAzure.Identity%2FREADME.png)
