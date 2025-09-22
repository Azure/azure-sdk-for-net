# Azure Identity client library for .NET

The Azure Identity library provides [Microsoft Entra ID](https://learn.microsoft.com/entra/fundamentals/whatis) token-based authentication support across the Azure SDK. It provides a set of [`TokenCredential`](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) implementations that can be used to construct Azure SDK clients that support Microsoft Entra token authentication.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][identity_api_docs] | [Microsoft Entra ID documentation][entraid_doc]

## Getting started

### Install the package

Install the Azure Identity client library for .NET with NuGet:

```dotnetcli
dotnet add package Azure.Identity
```

### Prerequisites

* An [Azure subscription][azure_sub].
* The [Azure CLI][azure_cli] can also be useful for authenticating in a development environment, creating accounts, and managing account roles.

### Authenticate the client

When debugging and executing code locally, it's typical for a developer to use their own account for authenticating calls to Azure services. There are several developer tools that can be used to perform this authentication in your development environment.

#### Authenticate via Visual Studio

Developers using Visual Studio 2017 or later can authenticate a Microsoft Entra account through the IDE. Apps using `DefaultAzureCredential` or `VisualStudioCredential` can then use this account to authenticate calls in their app when running locally.

To authenticate in Visual Studio, select the **Tools** > **Options** menu to launch the **Options** dialog. Then navigate to the **Azure Service Authentication** options to sign in with your Microsoft Entra account.

![Visual Studio Account Selection][vs_login_image]

#### Authenticate via the Azure CLI

Developers coding outside of an IDE can also use the [Azure CLI][azure_cli] to authenticate. Apps using `DefaultAzureCredential` or `AzureCliCredential` can then use this account to authenticate calls in their app when running locally.

To authenticate with the Azure CLI, run the command `az login`. For users running on a system with a default web browser, the Azure CLI launches the browser to authenticate the user.

![Azure CLI Account Sign In][azure_cli_login_image]

For systems without a default web browser, the `az login` command uses the device code authentication flow. The user can also force the Azure CLI to use the device code flow rather than launching a browser by specifying the `--use-device-code` argument.

![Azure CLI Account Device Code Sign In][azure_cli_login_device_code_image]

#### Authenticate via the Azure Developer CLI

Developers coding outside of an IDE can also use the [Azure Developer CLI][azure_developer_cli] to authenticate. Apps using `DefaultAzureCredential` or `AzureDeveloperCliCredential` can then use this account to authenticate calls in their app when running locally.

To authenticate with the Azure Developer CLI, run the command `azd auth login`. For users running on a system with a default web browser, the Azure Developer CLI launches the browser to authenticate the user. For systems without a default web browser, the `azd auth login --use-device-code` command uses the device code authentication flow.

#### Authenticate via Azure PowerShell

Developers coding outside of an IDE can also use [Azure PowerShell][azure_powerShell] to authenticate. Apps using `DefaultAzureCredential` or `AzurePowerShellCredential` can then use this account to authenticate calls in their app when running locally.

To authenticate with Azure PowerShell, run the command `Connect-AzAccount`. For users running on a system with a default web browser and version 5.0.0 or later of Azure PowerShell, it launches the browser to authenticate the user. For systems without a default web browser, the `Connect-AzAccount` command uses the device code authentication flow. The user can also force Azure PowerShell to use the device code flow rather than launching a browser by specifying the `UseDeviceAuthentication` argument.

## Key concepts

### Credentials

A credential is a class that contains or can obtain the data needed for a service client to authenticate requests. Service clients across the Azure SDK accept credentials when they're constructed. Service clients use those credentials to authenticate requests to the service.

The Azure Identity library focuses on OAuth authentication with Microsoft Entra ID. It offers numerous credentials capable of acquiring a Microsoft Entra token to authenticate service requests. Each credential in this library is an implementation of the `TokenCredential` abstract class in [Azure.Core][azure_core_library], and any of them can be used to construct service clients capable of authenticating with a `TokenCredential`.

See [Credential classes](#credential-classes) for a complete listing of available credential types.

### DefaultAzureCredential

`DefaultAzureCredential` simplifies authentication while developing apps that deploy to Azure by combining credentials used in Azure hosting environments with credentials used in local development. For more information, see [DefaultAzureCredential overview][dac_overview].

#### Continuation policy

As of version 1.10.1, `DefaultAzureCredential` attempts to authenticate with all developer tool credentials until one succeeds, regardless of any errors previous developer tool credentials experienced. For example, a developer tool credential may attempt to get a token and fail, so `DefaultAzureCredential` will continue to the next credential in the flow. Deployed service credentials stop the flow with a thrown exception if they're able to attempt token retrieval but don't receive one. Prior to version 1.10.1, developer tool credentials would similarly stop the authentication flow if token retrieval failed.

This behavior allows for trying all of the developer tool credentials on your machine while having predictable deployed behavior.

## Examples

### Specify a user-assigned managed identity with `DefaultAzureCredential`

Many Azure hosts allow the assignment of a user-assigned managed identity. The following examples demonstrate configuring `DefaultAzureCredential` to authenticate a user-assigned managed identity when deployed to an Azure host. The sample code uses the credential to authenticate a `BlobClient` from the [Azure.Storage.Blobs][blobs_client_library] client library. It also demonstrates how you can specify a user-assigned managed identity either by a client ID or a resource ID.

#### Client ID

To use a client ID, take one of the following approaches:

1. Set the [DefaultAzureCredentialOptions.ManagedIdentityClientId](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredentialoptions.managedidentityclientid?view=azure-dotnet) property. For example:

```C# Snippet:UserAssignedManagedIdentityWithClientId
// When deployed to an Azure host, DefaultAzureCredential will authenticate the specified user-assigned managed identity.

string userAssignedClientId = "<your managed identity client ID>";
var credential = new DefaultAzureCredential(
    new DefaultAzureCredentialOptions
    {
        ManagedIdentityClientId = userAssignedClientId
    });

var blobClient = new BlobClient(
    new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
    credential);
```

2. Set the `AZURE_CLIENT_ID` environment variable.

#### Resource ID

To use a resource ID, set the [DefaultAzureCredentialOptions.ManagedIdentityResourceId](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredentialoptions.managedidentityresourceid?view=azure-dotnet) property. The resource ID takes the form `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}`. Because resource IDs can be built by convention, they can be more convenient when there are a large number of user-assigned managed identities in your environment. For example:

```C# Snippet:UserAssignedManagedIdentityWithResourceId
string userAssignedResourceId = "<your managed identity resource ID>";
var credential = new DefaultAzureCredential(
    new DefaultAzureCredentialOptions
    {
        ManagedIdentityResourceId = new ResourceIdentifier(userAssignedResourceId)
    });

var blobClient = new BlobClient(
    new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
    credential);
```

### Define a custom authentication flow with `ChainedTokenCredential`

While `DefaultAzureCredential` is generally the quickest way to authenticate apps for Azure, you can create a customized chain of credentials to be considered. `ChainedTokenCredential` enables users to combine multiple credential instances to define a customized chain of credentials. For more information, see [ChainedTokenCredential overview][ctc_overview].

## Managed identity support

[Managed identity authentication](https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/overview) is supported either indirectly via `DefaultAzureCredential` or directly via `ManagedIdentityCredential` for the following Azure services:

* [Azure App Service and Azure Functions](https://learn.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet)
* [Azure Arc](https://learn.microsoft.com/azure/azure-arc/servers/managed-identity-authentication)
* [Azure Cloud Shell](https://learn.microsoft.com/azure/cloud-shell/msi-authorization)
* [Azure Kubernetes Service](https://learn.microsoft.com/azure/aks/use-managed-identity)
* [Azure Service Fabric](https://learn.microsoft.com/azure/service-fabric/concepts-managed-identity)
* [Azure Virtual Machines](https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/how-to-use-vm-token)
* [Azure Virtual Machines Scale Sets](https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/qs-configure-powershell-windows-vmss)

As of version 1.8.0, `ManagedIdentityCredential` supports [token caching](#token-caching).

## Sovereign cloud configuration

By default, credentials authenticate to the Microsoft Entra endpoint for the Azure Public Cloud. To access resources in other clouds, such as Azure US Government or a private cloud, use one of the following solutions:

1. Configure credentials with the [AuthorityHost](https://learn.microsoft.com/dotnet/api/azure.identity.tokencredentialoptions.authorityhost?view=azure-dotnet#azure-identity-tokencredentialoptions-authorityhost) property. For example:

```C# Snippet:AuthenticatingWithAuthorityHost
var credential = new DefaultAzureCredential(
    new DefaultAzureCredentialOptions
    {
        AuthorityHost = AzureAuthorityHosts.AzureGovernment
    });
```

[AzureAuthorityHosts](https://learn.microsoft.com/dotnet/api/azure.identity.azureauthorityhosts?view=azure-dotnet) defines authorities for well-known clouds.

2. Set the `AZURE_AUTHORITY_HOST` environment variable to the appropriate authority host URL. For example, `https://login.microsoftonline.us/`. Note that this setting affects all credentials in the environment. Use the previous solution to set the authority host on a specific credential.

Not all credentials require this configuration. Credentials that authenticate through a developer tool, such as `AzureCliCredential`, use that tool's configuration.

## Credential classes

### Credential chains

|Credential | Usage | Reference|
|-|-|-|
|[`DefaultAzureCredential`][ref_DefaultAzureCredential]|Provides a simplified authentication experience to quickly start developing apps run in Azure.|[DefaultAzureCredential overview][dac_overview]|
|[`ChainedTokenCredential`][ref_ChainedTokenCredential]|Allows users to define custom authentication flows comprised of multiple credentials.|[ChainedTokenCredential overview][ctc_overview]|

### Authenticate Azure-hosted apps

|Credential | Usage | Reference|
|-|-|-|
|[`EnvironmentCredential`][ref_EnvironmentCredential]|Authenticates a service principal or user via credential information specified in [environment variables](#environment-variables).||
|[`ManagedIdentityCredential`][ref_ManagedIdentityCredential]|Authenticates the managed identity of an Azure resource.|[user-assigned managed identity][uami_doc]<br>[system-assigned managed identity][sami_doc]|
|[`WorkloadIdentityCredential`][ref_WorkloadIdentityCredential]|Supports [Microsoft Entra Workload ID](https://learn.microsoft.com/azure/aks/workload-identity-overview) on Kubernetes.||

### Authenticate service principals

|Credential | Usage | Reference|
|-|-|-|
|[`AzurePipelinesCredential`][ref_AzurePipelinesCredential]|Supports [Microsoft Entra Workload ID](https://learn.microsoft.com/azure/devops/pipelines/release/configure-workload-identity?view=azure-devops) on Azure Pipelines.| [example](https://aka.ms/azsdk/net/identity/azurepipelinescredential/usage)|
|[`ClientAssertionCredential`][ref_ClientAssertionCredential]|Authenticates a service principal using a signed client assertion.||
|[`ClientCertificateCredential`][ref_ClientCertificateCredential]|Authenticates a service principal using a certificate. | [Service principal authentication](https://learn.microsoft.com/entra/identity-platform/app-objects-and-service-principals)|
|[`ClientSecretCredential`][ref_ClientSecretCredential]|Authenticates a service principal using a secret. | [Service principal authentication](https://learn.microsoft.com/entra/identity-platform/app-objects-and-service-principals)|

### Authenticate users

|Credential | Usage | Reference|
|-|-|-|
|[`AuthorizationCodeCredential`][ref_AuthorizationCodeCredential]|Authenticates a user with a previously obtained authorization code. | [OAuth2 authorization code](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)|
|[`DeviceCodeCredential`][ref_DeviceCodeCredential]|Interactively authenticates a user on devices with limited UI. | [Device code authentication](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-device-code)|
|[`InteractiveBrowserCredential`][ref_InteractiveBrowserCredential]|Interactively authenticates a user with the default system browser. | [Interactive browser authentication](https://aka.ms/azsdk/net/identity/interactivebrowsercredential/usage)|
|[`OnBehalfOfCredential`][ref_OnBehalfOfCredential]|Propagates the delegated user identity and permissions through the request chain. | [On-behalf-of authentication](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-on-behalf-of-flow)|

### Authenticate via development tools

|Credential | Usage | Reference|
|-|-|-|
|[`AzureCliCredential`][ref_AzureCliCredential]|Authenticates in a development environment with the Azure CLI. | [Azure CLI authentication](https://learn.microsoft.com/cli/azure/authenticate-azure-cli)|
|[`AzureDeveloperCliCredential`][ref_AzureDeveloperCliCredential]|Authenticates in a development environment with the Azure Developer CLI. | [Azure Developer CLI Reference](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference)|
|[`AzurePowerShellCredential`][ref_AzurePowerShellCredential]|Authenticates in a development environment with the Azure PowerShell. | [Azure PowerShell authentication](https://learn.microsoft.com/powershell/azure/authenticate-azureps)|
|[`VisualStudioCredential`][ref_VisualStudioCredential]|Authenticates in a development environment with Visual Studio. | [Visual Studio configuration](https://learn.microsoft.com/dotnet/azure/configure-visual-studio)|
|[`VisualStudioCodeCredential`][ref_VisualStudioCodeCredential]|Authenticates in a development environment with Visual Studio Code. | [Visual Studio Code configuration](https://learn.microsoft.com/dotnet/azure/configure-vs-code)|

> __Note:__ All credential implementations in the Azure Identity library are threadsafe, and a single credential instance can be used by multiple service clients.

## Environment variables

[`DefaultAzureCredential`][ref_DefaultAzureCredential] and [`EnvironmentCredential`][ref_EnvironmentCredential] can be configured with environment variables. Each type of authentication requires values for specific variables. Configuration is attempted in the order in which these environment variables are listed. For example, if values for a client secret and certificate are both present, the client secret is used by `EnvironmentCredential`.

### Service principal with secret

|Variable name|Value
|-|-
|`AZURE_CLIENT_ID`|ID of a Microsoft Entra application
|`AZURE_TENANT_ID`|ID of the application's Microsoft Entra tenant
|`AZURE_CLIENT_SECRET`|one of the application's client secrets

### Service principal with certificate

|Variable name|Value
|-|-
|`AZURE_CLIENT_ID`|ID of a Microsoft Entra application
|`AZURE_TENANT_ID`|ID of the application's Microsoft Entra tenant
|`AZURE_CLIENT_CERTIFICATE_PATH`|path to a PFX or PEM-encoded certificate file including private key
|`AZURE_CLIENT_CERTIFICATE_PASSWORD`|(optional) the password protecting the certificate file (currently only supported for PFX (PKCS12) certificates)
|`AZURE_CLIENT_SEND_CERTIFICATE_CHAIN`|(optional) send certificate chain in x5c header to support subject name / issuer based authentication

### Workload identity (`DefaultAzureCredential`)

|Variable name|Value
|-|-
|`AZURE_CLIENT_ID`|The client ID of the application the workload identity will authenticate. If defined, used as the default value for `WorkloadIdentityClientId` in `DefaultAzureCredentialOptions`.

### Managed identity (`DefaultAzureCredential`)

|Variable name|Value
|-|-
|`AZURE_CLIENT_ID`|The client ID for the user-assigned managed identity. If defined, used as the default value for `ManagedIdentityClientId` in `DefaultAzureCredentialOptions`.

## Continuous Access Evaluation

As of version 1.10.0, accessing resources protected by [Continuous Access Evaluation (CAE)][cae] is possible on a per-request basis. This behavior can be enabled by setting the `IsCaeEnabled` property of `TokenRequestContext` via its constructor. CAE isn't supported for developer credentials.

## Token caching

*Token caching* is a feature provided by the Azure Identity library. The feature allows apps to:

* Cache tokens in memory (default) or on disk (opt-in).
* Improve resilience and performance.
* Reduce the number of requests made to Microsoft Entra ID to obtain access tokens.

The Azure Identity library offers both in-memory and persistent disk caching. For more information, see the [token caching documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/samples/TokenCache.md).

## Brokered authentication

An authentication broker is an app that runs on a user's machine and manages the authentication handshakes and token maintenance for connected accounts. To enable support, use the [Azure.Identity.Broker](https://www.nuget.org/packages/Azure.Identity.Broker) package.

## Troubleshooting

See the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

### Error handling

Errors arising from authentication can be raised on any service client method that makes a request to the service. This is because the first time the token is requested from the credential is on the first call to the service. Any subsequent calls might need to refresh the token. To distinguish these failures from failures in the service client, Azure Identity classes raise the `AuthenticationFailedException` with details on the error source in the exception message and possibly the error message. Depending upon the app, these errors may or may not be recoverable.

``` c#
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

// Create a secret client using the DefaultAzureCredential
var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), new DefaultAzureCredential());

try
{
    KeyVaultSecret secret = await client.GetSecretAsync("secret1");
}
catch (AuthenticationFailedException e)
{
    Console.WriteLine($"Authentication Failed. {e.Message}");
}
```

For more information on handling errors from failed requests to Microsoft Entra ID or managed identity endpoints, see the Microsoft Entra ID [documentation on authorization error codes][entraid_err_doc].

### Logging

See [Enable and configure logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md#enable-and-configure-logging).

### Thread safety

We guarantee that all credential instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing credential instances is always safe, even across threads.

### Additional concepts

[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)

## Next steps

### Client libraries supporting authentication with Azure Identity

Many of [Azure.Core-dependent client libraries](https://learn.microsoft.com/dotnet/azure/sdk/packages#libraries-using-azurecore) support authenticating with `TokenCredential` and therefore the Azure Identity library. To learn more, see the library-specific docs.

### Known issues

This library doesn't currently support scenarios relating to the [Azure AD B2C](https://learn.microsoft.com/azure/active-directory-b2c/overview) service.

Open issues for the `Azure.Identity` library can be found [here](https://github.com/Azure/azure-sdk-for-net/issues?q=is%3Aissue+is%3Aopen+label%3AAzure.Identity).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You'll only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information, see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_developer_cli]:https://aka.ms/azure-dev
[azure_powerShell]: https://learn.microsoft.com/powershell/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/src
[package]: https://www.nuget.org/packages/Azure.Identity
[entraid_doc]: https://learn.microsoft.com/entra/identity/
[entraid_err_doc]: https://learn.microsoft.com/entra/identity-platform/reference-error-codes
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[blobs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs
[azure_core_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core
[identity_api_docs]: https://learn.microsoft.com/dotnet/api/azure.identity?view=azure-dotnet
[vs_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/VsLoginDialog.png
[azure_cli_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/AzureCliLogin.png
[azure_cli_login_device_code_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/AzureCliLoginDeviceCode.png
[ctc_overview]: https://aka.ms/azsdk/net/identity/credential-chains#chainedtokencredential-overview
[dac_overview]: https://aka.ms/azsdk/net/identity/credential-chains#defaultazurecredential-overview
[ref_AuthorizationCodeCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential?view=azure-dotnet
[ref_AzureCliCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.azureclicredential?view=azure-dotnet
[ref_AzureDeveloperCliCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.azuredeveloperclicredential?view=azure-dotnet
[ref_AzurePipelinesCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.azurepipelinescredential?view=azure-dotnet
[ref_AzurePowerShellCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.azurepowershellcredential?view=azure-dotnet
[ref_ChainedTokenCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.chainedtokencredential?view=azure-dotnet
[ref_ClientAssertionCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.clientassertioncredential?view=azure-dotnet
[ref_ClientCertificateCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.clientcertificatecredential?view=azure-dotnet
[ref_ClientSecretCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential?view=azure-dotnet
[ref_DefaultAzureCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[ref_DeviceCodeCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.devicecodecredential?view=azure-dotnet
[ref_EnvironmentCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.environmentcredential?view=azure-dotnet
[ref_InteractiveBrowserCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet
[ref_ManagedIdentityCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.managedidentitycredential?view=azure-dotnet
[ref_OnBehalfOfCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.onbehalfofcredential?view=azure-dotnet
[ref_VisualStudioCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.visualstudiocredential?view=azure-dotnet
[ref_VisualStudioCodeCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.visualstudiocodecredential?view=azure-dotnet
[ref_WorkloadIdentityCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.workloadidentitycredential?view=azure-dotnet
[cae]: https://learn.microsoft.com/entra/identity/conditional-access/concept-continuous-access-evaluation
[sami_doc]: https://learn.microsoft.com/dotnet/azure/sdk/authentication/system-assigned-managed-identity
[uami_doc]: https://learn.microsoft.com/dotnet/azure/sdk/authentication/user-assigned-managed-identity
