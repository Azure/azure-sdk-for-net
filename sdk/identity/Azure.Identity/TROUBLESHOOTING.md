﻿# Troubleshoot Azure Identity Authentication Issues

This troubleshooting guide covers failure investigation techniques, common errors for the credential types in the Azure Identity .NET client library, and mitigation steps to resolve these errors.

## Table of contents
- [Handle Azure Identity Exceptions](#handle-azure-identity-exceptions)
  - [AuthenticationFailedException](#authenticationfailedexception)
  - [CredentialUnavailableException](#credentialunavailableexception)
  - [Permission Issues](#permission-issues)
- [Find Relevant Information in Exception Messages](#find-relevant-information-in-exception-messages)
- [Enable and Configure Logging](#enable-and-configure-logging)
- [Troubleshoot DefaultAzureCredential Authentication Issues](#troubleshoot-defaultazurecredential-authentication-issues)
- [Troubleshoot EnvironmentCredential Authentication Issues](#troubleshoot-environmentcredential-authentication-issues)
- [Troubleshoot ClientSecretCredential Authentication Issues](#troubleshoot-clientsecretcredential-authentication-issues)
- [Troubleshoot ClientCertificateCredential Authentication Issues](#troubleshoot-clientcertificatecredential-authentication-issues)
- [Troubleshoot UsernamePasswordCredential Authentication Issues](#troubleshoot-usernamepasswordcredential-authentication-issues)
- [Troubleshoot ManagedIdentityCredential Authentication Issues](#troubleshoot-managedidentitycredential-authentication-issues)
  - [Azure Virtual Machine Managed Identity](#azure-virtual-machine-managed-identity)
  - [Azure App Service and Azure Functions Managed Identity](#azure-app-service-and-azure-functions-managed-identity)
- [Troubleshoot VisualStudioCodeCredential Authentication Issues](#troubleshoot-visualstudiocodecredential-authentication-issues)
- [Troubleshoot VisualStudioCredential Authentication Issues](#troubleshoot-visualstudiocredential-authenticaton-issues)
- [Troubleshoot AzureCliCredential Authentication Issues](#troubleshoot-azureclicredential-authentication-issues)
- [Troubleshoot AzurePowerShellCredential Authentication Issues](#troubleshoot-azurepowershellcredential-authentication-issues)
- [Get Additional Help](#get-additional-help)

## Handle Azure Identity Exceptions

### AuthenticationFailedException
Exceptions arising from authentication errors can be raised on any service client method that makes a request to the service. This is because the token is requested from the credential on the first call to the service and on any subsequent requests to the service that need to refresh the token. 

To distinguish these failures from failures in the service client, Azure Identity classes raise the `AuthenticationFailedException` with details describing the source of the error in the exception message and possibly the error message. Depending on the application, these errors may or may not be recoverable.

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
### CredentialUnavailableException

The `CredentialUnavailableExcpetion` is a special exception type derived from `AuthenticationFailedException`. This exception type is used to indicate that the credential can’t authenticate in the current environment, due to lack of required configuration or setup. This exception is also used as a signal to chained credential types, such as `DefaultAzureCredential` and `ChainedTokenCredential`, that the chained credential should continue to try other credential types later in the chain.

### Permission Issues

Calls to service clients resulting in `RequestFailedException` with a `StatusCode` of 401 or 403 often indicate the caller doesn't have sufficient permissions for the specified API. Check the service documentation to determine which RBAC roles are needed for the specific request, and ensure the authenticated user or service principal have been granted the appropriate roles on the resource.

## Find Relevant Information in Exception Messages

`AuthenticationFailedException` is thrown when unexpected errors occurred while a credential is authenticating. This can include errors received from requests to the AAD STS and often contains information helpful to diagnosis. Consider the following `AuthenticationFailedException` message.

![AuthenticationFailedException Message Example](https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/AuthFailedErrorMessageExample.png)

This error contains several pieces of information:

- __Failing Credential Type__: The type of credential that failed to authenticate. This can be helpful when diagnosing issues with chained credential types such as `DefaultAzureCredential` or `ChainedTokenCredential`.

- __STS Error Code and Message__: The error code and message returned from the Azure AD STS. This can give insight into the specific reason the request failed. For instance, in this specific case because the provided client secret is incorrect. More information on STS error codes can be found [here](https://docs.microsoft.com/azure/active-directory/develop/reference-aadsts-error-codes#aadsts-error-codes).

- __Correlation ID and Timestamp__: The correlation ID and call Timestamp used to identify the request in server-side logs. This information can be useful to support engineers when diagnosing unexpected STS failures.

### Enable and Configure Logging

The Azure Identity library provides the same [logging capabilities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) as the rest of the Azure SDK.

The simplest way to see the logs to help debug authentication issues is to enable the console logger.

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

## Troubleshoot `DefaultAzureCredential` Authentication Issues

| Error |Description| Mitigation |
|---|---|---|
|`CredentialUnavailableException` raised with message. "DefaultAzureCredential failed to retrieve a token from the included credentials."|All credentials in the `DefaultAzureCredential` chain failed to retrieve a token, each throwing a `CredentialUnavailableException`|<ul><li>[Enable logging](#enabling-and-configuring-logging) to verify the credentials being tried, and get further diagnostic information.</li><li>Consult the troubleshooting guide for underlying credential types for more information.</li><ul><li>[EnvironmentCredential](#troubleshoot-environmentcredential-authentication-issues)</li><li>[ManagedIdentityCredential](#troubleshoot-managedidentitycredential-authentication-issues)</li><li>[VisualStudioCodeCredential](#troubleshoot-visualstudiocodecredential-authentication-issues)</li><li>[VisualStudioCredential](#troubleshoot-visualstudiocredential-authentication-issues)</li><li>[AzureCLICredential](#troubleshoot-azureclicredential-authentication-issues)</li><li>[AzurePowershellCredential](#troubleshoot-azurepowershellcredential-authentication-issues)</li></ul>|
|`RequestFailedExcpetion` raised from the client with a status code of 401 or 403|Authentication succeeded but the authorizing Azure service responded with a 401 (Authenticate), or 403 (Forbidden) status code. This can often be caused by the `DefaultAzureCredential` authenticating an account other than the intended or that the intended account does not have the correct permissions or roles assigned.|<ul><li>[Enable logging](#enabling-and-configuring-logging) to determine which credential in the chain returned the authenticating token.</li><li>In the case a credential other than the expected is returning a token, bypass this by either signing out of the corresponding development tool, or excluding the credential with the ExcludeXXXCredential property in the `DefaultAzureCredentialOptions`</li><li>Ensure that the correct role is assigned to the account being used. For example, a service specific role rather than the subscription Owner role.</li></ul>|

## Troubleshoot `EnvironmentCredential` Authentication Issues
`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|Environment variables aren't fully configured.|A valid combination of environment variables wasn't set.|Ensure the appropriate environment variables are set **prior to application startup** for the intended authentication method.</p><ul><li>To authenticate a service principal using a client secret, ensure the variables `AZURE_CLIENT_ID`, `AZURE_TENANT_ID` and `AZURE_CLIENT_SECRET` are properly set.</li><li>To authenticate a service principal using a certificate, ensure the variables `AZURE_CLIENT_ID`, `AZURE_TENANT_ID` and `AZURE_CLIENT_CERTIFICATE_PATH` are properly set.</li><li>To authenticate a user using a password, ensure the variables `AZURE_USERNAME` and `AZURE_PASSWORD` are properly set.</li><ul>|

## Troubleshoot `ClientSecretCredential` Authentication Issues
`AuthenticationFailedException`
  | Error Code | Issue | Mitigation |
  |---|---|---|
  |AADSTS7000215|An invalid client secret was provided.|Ensure the `clientSecret` provided when constructing the credential is valid. If unsure, create a new client secret using the Azure portal. Details on creating a new client secret can be found [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#option-2-create-a-new-application-secret).|
  |AADSTS7000222|An expired client secret was provided.|Create a new client secret using the Azure portal. Details on creating a new client secret can be found [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#option-2-create-a-new-application-secret).| 
  |AADSTS700016|The specified application wasn't found in the specified tenant.|Ensure the specified `clientId` and `tenantId` are correct for your application registration.  For multi-tenant apps, ensure the application has been added to the desired tenant by a tenant admin. To add a new application in the desired tenant, follow the instructions [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal).|

## Troubleshoot `ClientCertificateCredential` Authentication Issues
`AuthenticationFailedException`
  | Error Code | Description | Mitigation |
  |---|---|---|
  |AADSTS700027|Client assertion contains an invalid signature.|Ensure the specified certificate has been uploaded to the AAD application registration. Instructions for uploading certificates to the application registration can be found [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#option-1-upload-a-certificate).|
  |AADSTS700016|The specified application wasn’t found in the specified tenant.| Ensure the specified `clientId` and `tenantId` are correct for your application registration. For multi-tenant apps, ensure the application has been added to the desired tenant by a tenant admin. To add a new application in the desired tenant, follow the instructions [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal).


## Troubleshoot `UsernamePasswordCredential` Authentication Issues
`AuthenticationFailedException`
| Error Code | Issue | Mitigation |
|---|---|---|
|AADSTS50126|The provided username or password is invalid|Ensure the `username` and `password` provided when constructing the credential are valid.|

## Troubleshoot `ManagedIdentityCredential` Authentication Issues

The `ManagedIdentityCredential` is designed to work on a variety of Azure hosts that provide managed identity. Configuring the managed identity and troubleshooting failures varies from hosts. The below table lists the Azure hosts that can be assigned a managed identity, and are supported by the `ManagedIdentityCredential`.

|Host Environment| | |
|---|---|---|
|Azure Virtual Machines and Scale Sets|[Configuration](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/qs-configure-portal-windows-vm)|[Troubleshooting](#azure-virtual-machine-managed-identity)|
|Azure App Service and Azure Functions|[Configuration](https://docs.microsoft.com/azure/app-service/overview-managed-identity)|[Troubleshooting](#azure-app-service-and-azure-functions-managed-identity)|
|Azure Kubernetes Service|[Configuration](https://azure.github.io/aad-pod-identity/docs/)|[Troubleshooting](#azure-kubernetes-service-managed-identity)|
|Azure Arc|[Configuration](https://docs.microsoft.com/azure/azure-arc/servers/managed-identity-authentication)||
|Azure Service Fabric|[Configuration](https://docs.microsoft.com/azure/service-fabric/concepts-managed-identity)||
### Azure Virtual Machine Managed Identity

`CredentialUnavailableException`

| Error Message |Description| Mitigation |
|---|---|---|
|The requested identity hasn’t been assigned to this resource.|The IMDS endpoint responded with a status code of 400, indicating the requested identity isn’t assigned to the VM.|If using a user assigned identity, ensure the specified `clientId` is correct.<p/><p/>If using a system assigned identity, make sure it has been enabled properly. Instructions to enable the system assigned identity on an Azure VM can be found [here](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/qs-configure-portal-windows-vm#enable-system-assigned-managed-identity-on-an-existing-vm).|
|The request failed due to a gateway error.|The request to the IMDS endpoint failed due to a gateway error, 502 or 504 status code.|Calls via proxy or gateway aren’t supported by IMDS. Disable proxies or gateways running on the VM for calls to the IMDS endpoint `http://169.254.169.254/`|
|No response received from the managed identity endpoint.|No response was received for the request to IMDS or the request timed out.|<ul><li>Ensure managed identity has been properly configured on the VM. Instructions for configuring the manged identity can be found [here](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/qs-configure-portal-windows-vm).</li><li>Verify the IMDS endpoint is reachable on the VM, see [below](#verifying-imds-is-available-on-the-vm) for instructions.</li></ul>|
|Multiple attempts failed to obtain a token from the managed identity endpoint.|Retries to retrieve a token from the IMDS endpoint have been exhausted.|<ul><li>Refer to inner exception messages for more details on specific failures. If the data has been truncated, more detail can be obtained by [collecting logs](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#logging).</li><li>Ensure managed identity has been properly configured on the VM. Instructions for configuring the manged identity can be found [here](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/qs-configure-portal-windows-vm).</li><li>Verify the IMDS endpoint is reachable on the VM, see [below](#verify-imds-is-available-on-the-vm) for instructions.</li></ul>|

#### __Verify IMDS is available on the VM__

If you have access to the VM, you can verify the manged identity endpoint is available via the command line using curl. 

```bash
curl 'http://169.254.169.254/metadata/identity/oauth2/token?resource=https://management.core.windows.net&api-version=2018-02-01' -H "Metadata: true"
```
> Note that output of this command will contain a valid access token, and SHOULD NOT BE SHARED to avoid compromising account security.
### Azure App Service and Azure Functions Managed Identity
`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|ManagedIdentityCredential authentication unavailable.|The environment variables configured by the App Services host weren’t present.|<ul><li>Ensure the managed identity has been properly configured on the App Service. Instructions for configuring the managed identity can be found [here](https://docs.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet).</li><li>Verify the App Service environment is properly configured and the managed identity endpoint is available. See [below](#verify-the-app-service-managed-identity-endpoint-is-available) for instructions.</li></ul>|

#### __Verify the App Service managed identity endpoint is available__

If you have access to SSH into the App Service, you can verify managed identity is available in the environment. First ensure the environment variables `MSI_ENDPOINT` and `MSI_SECRET` have been set in the environment. Then you can verify the managed identity endpoint is available using curl.
```bash
curl 'http://169.254.169.254/metadata/identity/oauth2/token?resource=https://management.core.windows.net&api-version=2018-02-01' -H "Metadata: true"
```
> Note that the output of this command will contain a valid access token, and SHOULD NOT BE SHARED to avoid compromising account security.

### Azure Kubernetes Service Managed Identity 
#### Pod Identity For Kubernetes
`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|No Managed Identity endpoint found|The application attempted to authenticate before an identity was assigned to its pod|Verify the pod is labeled correctly. This also occurs when a correctly labeled pod authenticates before the identity is ready. To prevent initialization races, configure NMI to set the Retry-After header in its responses (see [Pod Identity documentation](https://azure.github.io/aad-pod-identity/docs/configure/feature_flags/#set-retry-after-header-in-nmi-response)).

## Troubleshoot `VisualStudioCodeCredential` Authentication Issues
`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|Failed To Read VS Code Credentials</p></p>OR</p>Authenticate via Azure Tools plugin in VS Code|No Azure account information was found in the VS Code configuration.|<ul><li>Ensure the [Azure Account plugin](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account) is properly installed</li><li>Use **View > Command Palette** to execute the **Azure: Sign In** command. This command opens a browser window and displays a page that allows you to sign in to Azure.</li><li>If you already had the Azure Account extension installed and had logged in to your account, try logging out and logging in again as that will repopulate the cache and potentially mitigate the error you're getting.</li></ul>|
|MSAL Interaction Required Error|The `VisualStudioCodeCredential` was able to read the cached credentials from the cache but the cached token is likely expired.|Log into the Azure Account extension via **View > Command Palette** to execute the **Azure: Sign In** command in the VS Code IDE.|
|ADFS tenant not supported|ADFS tenants are not currently supported by Visual Stuido `Azure Service Authentication`.|Use credentials from a supported cloud when authenticating with Visual Studio. The supported clouds are:</p><ul><li>AZURE PUBLIC CLOUD - https://login.microsoftonline.com/</li><li>AZURE GERMANY - https://login.microsoftonline.de/</li><li>AZURE CHINA - https://login.chinacloudapi.cn/</li><li>AZURE GOVERNMENT - https://login.microsoftonline.us/</li></ul>|

## Troubleshoot `VisualStudioCredential` Authentication Issues
`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|Failed To Read Credentials</p></p>OR</p>Authenticate via Azure Service Authentication|The `VisualStudioCredential` failed retrieve a token from the Visual Studio authentication utility `Microsoft.Asal.TokenService.exe`.|<ul><li>In Visual Studio select the `Tools > Options` menu to launch the Options dialog.</li><li>Navigate to the `Azure Service Authentication` options to sign in with your Azure Active Directory account.</li><li>If you already had logged in to your account, try logging out and logging in again as that will repopulate the cache and potentially mitigate the error you're getting.</li></ul>|
|ADFS tenant not supported|ADFS tenants are not currently supported by Visual Stuido `Azure Service Authentication`.|Use credentials from a supported cloud when authenticating with Visual Studio. The supported clouds are:</p><ul><li>AZURE PUBLIC CLOUD - https://login.microsoftonline.com/</li><li>AZURE GERMANY - https://login.microsoftonline.de/</li><li>AZURE CHINA - https://login.chinacloudapi.cn/</li><li>AZURE GOVERNMENT - https://login.microsoftonline.us/</li></ul>|

## Troubleshoot `AzureCliCredential` Authentication Issues
`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|Azure CLI not installed|The Azure CLI isn’t installed or couldn’t be found.|<ul><li>Ensure the Azure CLI is properly installed. Installation instructions can be found [here](https://docs.microsoft.com/cli/azure/install-azure-cli).</li><li>Validate the installation location has been added to the `PATH` environment variable.</li></ul>|
|Please run 'az login' to set up account|No account is currently logged into the Azure CLI, or the login has expired.|<ul><li>Log into the Azure CLI using the `az login` command. More information on authentication in the Azure CLI can be found [here](https://docs.microsoft.com/cli/azure/authenticate-azure-cli).</li><li>Validate that the Azure CLI can obtain tokens. See [below](#verify-the-azure-cli-can-obtain-tokens) for instructions.</li></ul>|
#### __Verify the Azure CLI can obtain tokens__
You can manually verify that the Azure CLI is properly authenticated, and can obtain tokens. First use the `account` command to verify the account which is currently logged in to the Azure CLI. 

```bash
az account show
```

Once you've verified the Azure CLI is using correct account, you can validate that it’s able to obtain tokens for this account.

```bash
az account get-access-token --output json --resource https://management.core.windows.net
```
>Note that output of this command will contain a valid access token, and SHOULD NOT BE SHARED to avoid compromising account security.

## Troubleshoot `AzurePowerShellCredential` Authentication Issues

`CredentialUnavailableException`
| Error Message |Description| Mitigation |
|---|---|---|
|PowerShell isn’t installed.|No local installation of PowerShell was found.|Ensure that PowerShell is properly installed on the machine. Instructions for installing PowerShell can be found [here](tps://docs.microsoft.com/powershell/scripting/install/installing-powershell).|
|Az.Account module >= 2.2.0 isn’t installed.|The Az.Account module needed for authentication in Azure PowerShell isn’t installed.|Install the latest Az.Account module. Installation instructions can be found [here](https://docs.microsoft.com/powershell/azure/install-az-ps).|
|Please run 'Connect-AzAccount' to set up account.|No account is currently logged into Azure PowerShell.|<ul><li>Login to Azure PowerShell using the `Connect-AzAccount` command. More instructions for authenticating Azure PowerShell can be found [here](https://docs.microsoft.com/powershell/azure/authenticate-azureps)</li><li>Validate that Azure PowerShell can obtain tokens. See [below](#verify-azure-powershell-can-obtain-tokens) for instructions.</li></ul>|

#### __Verify Azure PowerShell can obtain tokens__
You can manually verify that Azure PowerShell is properly authenticated, and can obtain tokens. First use the `Get-AzContext` command to verify the account which is currently logged in to the Azure CLI. 

```
PS C:\> Get-AzContext

Name                                     Account             SubscriptionName    Environment         TenantId
----                                     -------             ----------------    -----------         --------
Subscription1 (xxxxxxxx-xxxx-xxxx-xxx... test@outlook.com    Subscription1       AzureCloud          xxxxxxxx-x...
```

Once you've verified Azure PowerShell is using correct account, you can validate that it’s able to obtain tokens for this account.

```bash
Get-AzAccessToken -ResourceUrl "https://management.core.windows.net"
```
>Note that output of this command will contain a valid access token, and SHOULD NOT BE SHARED to avoid compromising account security.

## Get Additional Help

Additional information on ways to reach out for support can be found in the [SUPPORT.md](https://github.com/Azure/azure-sdk-for-net/blob/main/SUPPORT.md) at the root of the repo.