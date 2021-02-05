# Azure Identity client library for .NET
 The Azure Identity library provides Azure Active Directory token authentication support across the Azure SDK. It provides a set of TokenCredential implementations which can be used to construct Azure SDK clients which support AAD token authentication.  
 
 This library currently supports:
  - [Service principal authentication](https://docs.microsoft.com/azure/active-directory/develop/app-objects-and-service-principals)
  - [Managed identity authentication](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview)
  - [User principal authentication](https://docs.microsoft.com/azure/active-directory/develop/scenario-web-app-sign-user-overview)

  [Source code][source] | [Package (nuget)][package] | [API reference documentation][identity_api_docs] | [Azure Active Directory documentation][aad_doc]



## Getting started

### Install the package

Install the Azure Identity client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Identity
```

### Prerequisites
* An [Azure subscription][azure_sub].
* The [Azure CLI][azure_cli] can also be useful for authenticating in a development environment, creating accounts, and managing account roles.

### Authenticate the client

When debugging and executing code locally it is typical for a developer to use their own account for authenticating calls to Azure services. There are several developer tools which can be used to perform this authentication in your development environment.

#### Authenticating via Visual Studio 

Developers using Visual Studio 2017 or later can authenticate an Azure Active Directory account through the IDE. Applications using the `DefaultAzureCredential` or the `VisualStudioCredential` can then use this account to authenticate calls in their application when running locally.

To authenticate in Visual Studio select the `Tools > Options` menu to launch the Options dialog. Then navigate to the `Azure Service Authentication` options to sign in with your Azure Active Directory account.

![Visual Studio Account Selection][vs_login_image]

#### Authenticating via Visual Studio Code
Developers using Visual Studio Code can use the [Azure Account Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account), to authenticate via the IDE. Applications using the `DefaultAzureCredential` or the `VisualStudioCodeCredential` can then use this account to authenticate calls in their application when running locally.

To authenticate in Visual Studio Code, first ensure the [Azure Account Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account) is installed. Once the extension is installed, press `F1` to open the command palette and run the `Azure: Sign In` command.

![Visual Studio Code Account Sign In][vs_code_login_image]

#### Authenticating via the Azure CLI
Developers coding outside of an IDE can also use the [Azure CLI][azure_cli] to authenticate. Applications using the `DefaultAzureCredential` or the `AzureCliCredential` can then use this account to authenticate calls in their application when running locally.

To authenticate with the [Azure CLI][azure_cli] users can run the command `az login`. For users running on a system with a default web browser the azure cli will launch the browser to authenticate the user.

![Azure CLI Account Sign In][azure_cli_login_image]

For systems without a default web browser, the `az login` command will use the device code authentication flow. The user can also force the Azure CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

![Azure CLI Account Device Code Sign In][azure_cli_login_device_code_image]

## Key concepts
### Credentials

A credential is a class which contains or can obtain the data needed for a service client to authenticate requests. Service clients across Azure SDK accept credentials when they are constructed, and service clients use those credentials to authenticate requests to the service. 

The Azure Identity library focuses on OAuth authentication with Azure Active directory, and it offers a variety of credential classes capable of acquiring an AAD token to authenticate service requests. All of the credential classes in this library are implementations of the `TokenCredential` abstract class in [Azure.Core][azure_core_library], and any of them can be used to construct service clients capable of authenticating with a `TokenCredential`. 

See [Credential Classes](#credential-classes) for a complete listing of available credential types.

### DefaultAzureCredential
The `DefaultAzureCredential` is appropriate for most scenarios where the application is intended to ultimately be run in the Azure Cloud. This is because the `DefaultAzureCredential` combines credentials commonly used to authenticate when deployed, with credentials used to authenticate in a development environment. The `DefaultAzureCredential` will attempt to authenticate via the following mechanisms in order.

![DefaultAzureCredential authentication flow][default_azure_credential_authflow_image]

 - Environment - The `DefaultAzureCredential` will read account information specified via [environment variables](#environment-variables) and use it to authenticate.
 - Managed Identity - If the application is deployed to an Azure host with Managed Identity enabled, the `DefaultAzureCredential` will authenticate with that account.
 - Visual Studio - If the developer has authenticated via Visual Studio, the `DefaultAzureCredential` will authenticate with that account.
 - Visual Studio Code - If the developer has authenticated via the Visual Studio Code Azure Account plugin, the `DefaultAzureCredential` will authenticate with that account.
 - Azure CLI - If the developer has authenticated an account via the Azure CLI `az login` command, the `DefaultAzureCredential` will authenticate with that account.
 - Interactive - If enabled the `DefaultAzureCredential` will interactively authenticate the developer via the current system's default browser.

## Examples

### Authenticating with the `DefaultAzureCredential`

This example demonstrates authenticating the `SecretClient` from the [Azure.Security.KeyVault.Secrets][secrets_client_library] client library using the `DefaultAzureCredential`.

```C# Snippet:AuthenticatingWithDefaultAzureCredential
// Create a secret client using the DefaultAzureCredential
var client = new SecretClient(new Uri("https://myvault.azure.vaults.net/"), new DefaultAzureCredential());
```

### Enabling the interactive authentication with the `DefaultAzureCredential`

Interactive authentication is disabled in the `DefaultAzureCredential` by default. This example demonstrates two ways of enabling the interactive authentication portion of the `DefaultAzureCredential`. When enabled the `DefaultAzureCredential` will fall back to interactively authenticating the developer via the system's default browser if when no other credentials are available. This example then authenticates an `EventHubProducerClient` from the [Azure.Messaging.EventHubs][eventhubs_client_library] client library using the `DefaultAzureCredential` with interactive authentication enabled.

```C# Snippet:EnableInteractiveAuthentication
// the includeInteractiveCredentials constructor parameter can be used to enable interactive authentication
var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

var eventHubClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);
```

### Specifying a user assigned managed identity with the `DefaultAzureCredential`
Many Azure hosts allow the assignment of a user assigned managed identity. This example demonstrates configuring the `DefaultAzureCredential` to authenticate a user assigned identity when deployed to an azure host. It then authenticates a `BlobClient` from the [Azure.Storage.Blobs][blobs_client_library] client library with credential.

```C# Snippet:UserAssignedManagedIdentity
// when deployed to an azure host the default azure credential will authenticate the specified user assigned managed identity
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });

var blobClient = new BlobClient(new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"), credential);
```

### Define a custom authentication flow with the `ChainedTokenCredential`
While the `DefaultAzureCredential` is generally the quickest way to get started developing applications for Azure, more advanced users may want to customize the credentials considered when authenticating. The `ChainedTokenCredential` enables users to combine multiple credential instances to define a customized chain of credentials. This example demonstrates creating a `ChainedTokenCredential` which will attempt to authenticate using managed identity, and fall back to authenticating via the Azure CLI if managed identity is unavailable in the current environment. The credential is then used to authenticate an `EventHubProducerClient` from the [Azure.Messaging.EventHubs][eventhubs_client_library] client library.

```C# Snippet:CustomChainedTokenCredential
// authenticate using managed identity if it is available otherwise use the Azure CLI to auth
var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());

var eventHubProducerClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);
```

## Credential Classes
### Authenticating Azure Hosted Applications
|credential  | usage
|-|-
|[`DefaultAzureCredential`][ref_DefaultAzureCredential]|provides a simplified authentication experience to quickly start developing applications run in the Azure cloud
|[`ChainedTokenCredential`][ref_ChainedTokenCredential]|allows users to define custom authentication flows composing multiple credentials
|[`ManagedIdentityCredential`][ref_ManagedIdentityCredential]|authenticates the managed identity of an azure resource
|[`EnvironmentCredential`][ref_EnvironmentCredential]|authenticates a service principal or user via credential information specified in environment variables

### Authenticating Service Principals
|credential  | usage
|-|-
|[`ClientSecretCredential`][ref_ClientSecretCredential]|authenticates a service principal using a secret
|[`ClientCertificateCredential`][ref_ClientCertificateCredential]|authenticates a service principal using a certificate


### Authenticating Users
|credential  | usage
|-|-
|[`InteractiveBrowserCredential`][ref_InteractiveBrowserCredential]|interactively authenticates a user with the default system browser
|[`DeviceCodeCredential`][ref_DeviceCodeCredential]|interactively authenticates a user on devices with limited UI
|[`UsernamePasswordCredential`][ref_UsernamePasswordCredential]|authenticates a user with a username and password
|[`AuthorizationCodeCredential`][ref_AuthorizationCodeCredential]|authenticate a user with a previously obtained authorization code

### Authenticating via Development Tools
|credential  | usage
|-|-
|[`AzureCliCredential`][ref_AzureCliCredential]|authenticate in a development environment with the Azure CLI
|[`VisualStudioCredential`][ref_VisualStudioCredential]|authenticate in a development environment with Visual Studio
|[`VisualStudioCodeCredential`][ref_VisualStudioCodeCredential]|authenticate in a development environment with Visual Studio Code

> __Note:__ All credential implementations in the Azure Identity library are threadsafe, and a single credential instance can be used by multiple service clients.

## Environment Variables
[`DefaultAzureCredential`][ref_DefaultAzureCredential] and [`EnvironmentCredential`][ref_EnvironmentCredential] can be configured with environment variables. Each type of authentication requires values for specific variables:

#### Service principal with secret
|variable name|value
|-|-
|`AZURE_CLIENT_ID`|id of an Azure Active Directory application
|`AZURE_TENANT_ID`|id of the application's Azure Active Directory tenant
|`AZURE_CLIENT_SECRET`|one of the application's client secrets

#### Service principal with certificate
|variable name|value
|-|-
|`AZURE_CLIENT_ID`|id of an Azure Active Directory application
|`AZURE_TENANT_ID`|id of the application's Azure Active Directory tenant
|`AZURE_CLIENT_CERTIFICATE_PATH`|path to a PEM-encoded certificate file including private key (without password protection)

#### Username and password
|variable name|value
|-|-
|`AZURE_CLIENT_ID`|id of an Azure Active Directory application
|`AZURE_USERNAME`|a username (usually an email address)
|`AZURE_PASSWORD`|that user's password

Configuration is attempted in the above order. For example, if values for a
client secret and certificate are both present, the client secret will be used.

## Troubleshooting

### Error Handling
Errors arising from authentication can be raised on any service client method which makes a request to the service. This is because the first time the token is requested from the credential is on the first call to the service, and any subsequent calls might need to refresh the token. In order to distinguish these failures from failures in the service client Azure Identity classes raise the `AuthenticationFailedException` with details to the source of the error in the exception message as well as possibly the error message. Depending on the application these errors may or may not be recoverable.

``` c#
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

// Create a secret client using the DefaultAzureCredential
var client = new SecretClient(new Uri("https://myvault.azure.vaults.net/"), new DefaultAzureCredential());

try
{
    KeyVaultSecret secret = await client.GetSecretAsync("secret1");
}
catch (AuthenticationFailedException e)
{
    Console.WriteLine($"Authentication Failed. {e.Message}");
}
```

For more details on dealing with errors arising from failed requests to Azure Active Directory, or managed identity endpoints please refer to the Azure Active Directory [documentation on authorization error codes][aad_err_doc].

### Logging

The Azure Identity library provides the same [logging capabilities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging) as the rest of the Azure SDK.

The simplest way to see the logs to help debug authentication issues is to enable the console logging.

``` c#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

All credentials can be configured with diagnostic options, in the same way as other clients in the SDK.

``` c#
DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
{
    Diagnostics =
    {
        LoggedHeaderNames = { "x-ms-request-id" },
        LoggedQueryParameters = { "api-version" },
        IsLoggingContentEnabled = true
    }
};
```

> CAUTION: Requests and responses in the Azure Identity library contain sensitive information. Precaution must be taken to protect logs when customizing the output to avoid compromising account security.

## Next steps

### Client libraries supporting authentication with Azure Identity
Currently the following client libraries support authenticating with `TokenCredential` and the Azure Identity library.  You can learn more about their use, and find additional documentation on use of these client libraries along samples with can be found in the links below.

- [Azure.Messaging.EventHubs][eventhubs_client_library]
- [Azure.Security.KeyVault.Keys][keys_client_library]
- [Azure.Security.KeyVault.Secrets][secrets_client_library]
- [Azure.Storage.Blobs][blobs_client_library]
- [Azure.Storage.Queues][queues_client_library]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/src
[package]: https://www.nuget.org/packages/Azure.Identity
[aad_doc]: https://docs.microsoft.com/azure/active-directory/
[aad_err_doc]: https://docs.microsoft.com/azure/active-directory/develop/reference-aadsts-error-codes
[certificates_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[nuget]: https://www.nuget.org/
[keys_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys
[secrets_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets
[blobs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs
[queues_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues
[eventhubs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs
[azure_core_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core
[identity_api_docs]: https://docs.microsoft.com/dotnet/api/azure.identity?view=azure-dotnet
[vs_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/identity/Azure.Identity/images/VsLoginDialog.png
[vs_code_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/identity/Azure.Identity/images/VsCodeLoginCommand.png
[azure_cli_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/identity/Azure.Identity/images/AzureCliLogin.png
[azure_cli_login_device_code_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/identity/Azure.Identity/images/AzureCliLoginDeviceCode.png
[default_azure_credential_authflow_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/identity/Azure.Identity/images/DefaultAzureCredentialAuthenticationFlow.png
[ref_DefaultAzureCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[ref_ChainedTokenCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.chainedtokencredential?view=azure-dotnet
[ref_EnvironmentCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.environmentcredential?view=azure-dotnet
[ref_ManagedIdentityCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.managedidentitycredential?view=azure-dotnet
[ref_ClientSecretCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.clientsecretcredential?view=azure-dotnet
[ref_ClientCertificateCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.clientcertificatecredential?view=azure-dotnet
[ref_InteractiveBrowserCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet
[ref_DeviceCodeCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.devicecodecredential?view=azure-dotnet
[ref_UsernamePasswordCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.usernamepasswordcredential?view=azure-dotnet
[ref_AuthorizationCodeCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential?view=azure-dotnet
[ref_AzureCliCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.azureclicredential?view=azure-dotnet
[ref_VisualStudioCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.visualstudiocredential?view=azure-dotnet
[ref_VisualStudioCodeCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.visualstudiocodecredential?view=azure-dotnet

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fidentity%2FAzure.Identity%2FREADME.png)
