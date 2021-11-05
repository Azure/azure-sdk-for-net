## Troubleshooting Azure Identity Authentication Issues

The Azure Identity SDK offers various `TokenCredential` implementations. The most common exceptions observed for failure scenarios
are `CredentialUnavailableException`
and `AuthenticationFailedException`.

- `CredentialUnavailableException` indicates that the credential cannot execute in the current environment setup due to lack of required configuration.
- `AuthenticationFailedException` indicates that the credential was able to run/execute but ran into an authentication issue from the server's end. This can happen
  due to invalid configuration/details passed in to the credential at construction time.

This troubleshooting guide covers mitigation steps to resolve these exceptions thrown by various `TokenCredential` implementations in the Azure Identity .NET client
library.

## Table of contents

- [Troubleshooting Default Azure Credential Authentication Issues](#troubleshooting-default-azure-credential-authentication-issues)
- [Troubleshooting Environment Credential Authentication Issues](#troubleshooting-environment-credential-authentication-issues)
- [Troubleshooting Service Principal Authentication Issues](#troubleshooting-service-principal-authentication-issues)
- [Troubleshooting Username Password Authentication Issues](#troubleshooting-username-password-authentication-issues)
- [Troubleshooting Mananged Identity Authenticaiton Issues](#troubleshooting-mananged-identity-authenticaiton-issues)
- [Troubleshooting Visual Studio Code Authenticaiton Issues](#troubleshooting-visual-studio-code-authenticaiton-issues)
- [Troubleshooting Visual Studio Authenticaiton Issues](#troubleshooting-visual-studio-authenticaiton-issues)
- [Troubleshooting Azure CLI Authenticaiton Issues](#troubleshooting-azure-cli-authenticaiton-issues)
- [Troubleshooting Azure Powershell Authenticaiton Issues](#troubleshooting-azure-powershell-authenticaiton-issues)

## Troubleshooting Default Azure Credential Authentication Issues.

### Credential Unavailable Exception

The first time `DefaultAzureCredential` attempts to retrieve an access token it does so by sequentially invoking a chain of credentials.
The `CredentialUnavailableException` in this scenario signifies that all the credentials in the chain failed to retrieve the token in the current environment
setup/configuration. You need to follow the configuration instructions for the respective credential you're looking to use via `DefaultAzureCredential` chain, so
that the credential can work in your environment.

Please follow the configuration instructions in the `Credential Unvavailable` section of the troubleshooting guidelines below for the respective
credential/authentication type you're looking to use via `DefaultAzureCredential`:

| Credential Type |    Troubleshooting Guide |
| --- | --- |
| Environment Credential |    [Environment Credential Troubleshooting Guide](#troubleshooting-environment-credential-authentication-issues) |
| Managed Identity Credential |    [Managed Identity Troubleshooting Guide](#troubleshooting-managed-identity-authentication-issues) |
| Visual Studio Code Credential |    [Visual Studio Code Troubleshooting Guide](#troubleshooting-visual-studio-code-authenticaiton-issues) |
| Visual Studio Credential |    [Visual Studio Troubleshooting Guide](#troubleshooting-visual-studio-authenticaiton-issues) |
| Azure CLI Credential |    [Azure CLI Troubleshooting Guide](#troubleshooting-azure-cli-authenticaiton-issues) |
| Azure Powershell Credential |    [Azure Powershell Troubleshooting Guide](#troubleshooting-azure-powershell-authentication-issues) |

## Troubleshooting Environment Credential Authentication Issues.

### Credential Unavailable Exception

#### Environment variables not configured

The `EnvironmentCredential` supports Service Principal authentication and Username + Password Authentication. It requires that the environment variables below are
properly configured and available to the application. This can mean that an application or its execution environment needs to be restarted to pick up changes to the
environment.

##### Service principal with secret

| Variable Name |    Value |
| --- | --- |
AZURE_CLIENT_ID |    ID of an Azure Active Directory application. |
AZURE_TENANT_ID     |ID of the application's Azure Active Directory tenant. |
AZURE_CLIENT_SECRET |    One of the application's client secrets. |

##### Service principal with certificate

| Variable name    | Value |
| --- | --- |
AZURE_CLIENT_ID    | ID of an Azure Active Directory application. |
AZURE_TENANT_ID    | ID of the application's Azure Active Directory tenant. |
AZURE_CLIENT_CERTIFICATE_PATH |    Path to a PEM-encoded certificate file including private key (must be without password protection). |

##### Username and password

| Variable name |    Value |
| --- | --- |
AZURE_CLIENT_ID |    ID of an Azure Active Directory application. |
AZURE_USERNAME |    A username (usually an email address). |
AZURE_PASSWORD | The associated password for the given username. |

### Client Authentication Exception

The `EnvironmentCredential` supports Service Principal authentication and Username + Password Authentication. Please follow the troubleshooting guidelines below for
the respective authentication method.

| Authentication Type |    Trobuleshoot Guide |
| --- | --- |
| Service Principal |    [Service Principal Auth Troubleshooting Guide](#troubleshooting-username-password-authentication-issues) |
| Username Password |    [Username Password Auth Troubleshooting Guide](#troubleshooting-username-password-authentication-issues) |

## Troubleshooting Username Password Authentication Issues

### Two Factor Authentication Required Error

The `UsernamePassword` credential works only for users whose two factor authentication has been disabled in Azure Active Directory. You can change the multi-factor
authentication requirements in Azure Portal by following the
steps [here](https://docs.microsoft.com/azure/active-directory/authentication/howto-mfa-userstates#change-the-status-for-a-user).

## Troubleshooting Service Principal Authentication Issues

### Invalid Argument Issues

#### Client Id

The Client Id is the application Id of the registered application / service principal in Azure Active Directory. It is a required parameter
for `ClientSecretCredential` and `ClientCertificateCredential`. If you have already created your service principal then you can retrieve the client/app id by
following the
instructions [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#get-tenant-and-app-id-values-for-signing-in). .

#### Tenant Id

The tenant id is a Globally Unique Identifier (GUID) that identifies your organization. It is a required parameter for `ClientSecretCredential`
and `ClientCertificateCredential`. If you have already created your service principal then you can retrieve the client or application id by following the
instructions [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#get-tenant-and-app-id-values-for-signing-in). .

### Client Secret Credential Issues

#### Client Secret Argument

The client secret is the secret string that the application uses to prove its identity when requesting a token. This can also can be referred to as an application
password. If you have already created a service principal you can follow the
instructions [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#option-2-create-a-new-application-secret)
to get the client secret for your application.

### Client Certificate Credential Issues

#### Client Certificate Argument

The `Client Certificate Credential` accepts a `pfx` or `pem` certificate which is associated with your registered application/service principal. To create and
associate a certificate with your registered app. please follow the
instructions [here](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal#option-1-upload-a-certificate).

### Create a new service principal

Follow tne instructions [here](https://docs.microsoft.com/cli/azure/create-an-azure-service-principal-azure-cli) to create a new service principal.

## Troubleshooting Managed Identity Authentication Issues

### Credential Unavailable

#### Connection Timed Out / Connection could not be established / Target Environment could not be determined.

The endpoints required to support the Managed Identity credential are only available on Azure Hosted machines/servers. So ensure that you are running your
application on an Azure Hosted resource. Currently Azure Identity SDK
supports [Managed Identity Authentication](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview)
in the below listed Azure Services. Ensure you're running your application in one of these environments and have enabled a Managed Identity on them by following the
instructions at their configuration links below.

Azure Service | Managed Identity Configuration
--- | --- |
[Azure Virtual Machines](https://docs.microsoft.com/azure/virtual-machines/) | [Configuration Instructions](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/qs-configure-portal-windows-vm)
[Azure App Service](https://docs.microsoft.com/azure/app-service/overview) | [Configuration Instructions](https://docs.microsoft.com/azure/app-service/overview-managed-identity)
[Azure Kubernetes Service](https://docs.microsoft.com/azure/aks) | [Configuration Instructions](https://docs.microsoft.com/azure/aks/use-managed-identity)
[Azure Cloud Shell](https://docs.microsoft.com/azure/cloud-shell) | [Configuration Instructions](https://docs.microsoft.com/azure/cloud-shell/msi-authorization) |
[Azure Arc](https://docs.microsoft.com/azure/azure-arc/) | [Configuration Instructions](https://docs.microsoft.com/azure/azure-arc/servers/security-overview#using-a-managed-identity-with-arc-enabled-servers)
[Azure Service Fabric](https://docs.microsoft.com/azure/service-fabric) | [Configuration Instructions](https://docs.microsoft.com/azure/service-fabric/configure-existing-cluster-enable-managed-identity-token-service)

## Troubleshooting Visual Studio Code Authentication Issues

### Credential Unavailable

#### Failed To Read VS Code Credentials / Authenticate via Azure Tools plugin in VS Code.

The `VisualStudioCodeCredential` failed to read the credential details from the cache.

The Visual Studio Code authentication is handled by an integration with the Azure Account extension. To use this form of authentication, ensure that you have
installed the Azure Account extension, then use **View > Command Palette** to execute the **Azure: Sign In** command. This command opens a browser window and
displays a page that allows you to sign in to Azure. After you've completed the login process, you can close the browser as directed. Running your application
(either in the debugger or anywhere on the development machine) will use the credential from your sign-in.

If you already had the Azure Account extension installed and had logged in to your account, try logging out and logging in again as that will re-populate the cache
on the disk and potentially mitigate the error you're getting.

#### Msal Interaction Required Error

The `VisualStudioCodeCredential` was able to read the cached credentials from the cache but the cached token is likely expired. Log into the Azure Account extension
via **View > Command Palette** to execute the **Azure: Sign In** command in the VS Code IDE.

#### ADFS Tenant Not Supported

The ADFS Tenants are not supported via the Azure Account extension in VS Code currently. The supported clouds are:

Azure Cloud | Cloud Authority Host
--- | --- | 
AZURE PUBLIC CLOUD | https://login.microsoftonline.com/
AZURE GERMANY | https://login.microsoftonline.de/
AZURE CHINA | https://login.chinacloudapi.cn/
AZURE GOVERNMENT | https://login.microsoftonline.us/

## Troubleshooting Visual Studio Authentication Issues

### Credential Unavailable

#### Failed To Read Credentials / Authenticate via Azure Service Authentication

The `VisualStudioCredential` failed to read the credential details from the cache.

The Visual Studio authentication is handled by helper utility called Microsoft.Asal.TokenService.exe. To use this form of authentication, ensure that you have signed
in to your Azure account. To do so, select the `Tools > Options` menu to launch the Options dialog. Then navigate to the `Azure Service Authentication` options to
sign in with your Azure Active Directory account. Running your application (either in the debugger or anywhere on the development machine) will use the credential
from your sign-in.

If you already had logged in to your account previously, try logging out and logging in again as that will re-populate the cache on the disk and potentially mitigate
the error you're getting.

#### Msal Interaction Required Error

The `VisualStudioCredential` was able to read the cached credentials from the cache but the cached token is likely expired. Log into the Azure Account extension
via **View > Command Palette** to execute the **Azure: Sign In** command in the VS Code IDE.

#### ADFS Tenant Not Supported

The ADFS Tenants are not supported via the Azure Account extension in VS Code currently. The supported clouds are:

Azure Cloud | Cloud Authority Host
--- | --- | 
AZURE PUBLIC CLOUD | https://login.microsoftonline.com/
AZURE GERMANY | https://login.microsoftonline.de/
AZURE CHINA | https://login.chinacloudapi.cn/
AZURE GOVERNMENT | https://login.microsoftonline.us/

## Troubleshooting Azure CLI Authentication Issues

### Credential Unavailable

#### Azure CLI Not Installed.

The `AzureCliCredential` failed to execute as Azure CLI command line tool is not installed. To use Azure CLI credential, the Azure CLI needs to be installed, please
follow the instructions [here](https://docs.microsoft.com/cli/azure/install-azure-cli) to install it for your platform and then try running the credential again.

#### Azure account not logged in.

The `AzureCliCredential` utilizes the current logged in Azure user in Azure CLI to fetch an access token. You need to login to your account in Azure CLI
via `az login` command. You can further read instructions to [Sign in with Azure CLI](https://docs.microsoft.com/cli/azure/authenticate-azure-cli). Once logged in
try running the credential again.

## Troubleshooting Azure Powershell Authenticaiton Issues

### Credential Unavailable

#### Powershell not installed.

The `AzurePowerShellCredential` utilizes the locally installed `Powershell` command line tool to fetch an access token. Please ensure it is installed on your
platform by following the instructions [here](https://docs.microsoft.com/powershell/scripting/install/installing-powershell) and then run the
credential again.

#### Azure Az Module Not Installed.

The `AzurePowerShellCredential` failed to execute as Azure az module is not installed. To use Azure Powershell credential, the Azure az module needs to be
installed, please follow the instructions [here](https://docs.microsoft.com/powershell/azure/install-az-ps)
to install it for your platform and then try running the credential again.

#### Azure account not logged in.

The `AzurePowerShellCredential` utilizes the current logged in Azure user in Azure Powershell to fetch an access token. You need to login to your account in Azure
Powershell via `Connect-AzAccount` command. You can further read instructions
to [Sign in with Azure Powershell](https://docs.microsoft.com/powershell/azure/authenticate-azureps). Once logged in try running the credential again.

#### Deserialization error.

The `AzurePowerShellCredential` was able to retrieve a response from the Azure Powershell when attempting to get an access token but failed to parse that response.
In your local powershell window, run the following command to ensure that Azure PowerShell is returning an access token in correct format.

```pwsh
Get-AzAccessToken -ResourceUrl "<Scopes-Url>"
```

In the event above command is not working properly, follow the instructions to resolve the Azure Powershell issue being faced and then try running the credential
again.
