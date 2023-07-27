# Azure Identity Brokered Authentication client library for .NET
 The library extends the Azure.Identity library to provide authentication broker support. It includes the necessary dependencies, and provides the `InteractiveBrowserCredentialBrokerOptions` class. This options class can be used to create an `InteractiveBrowserCredential` capable of using the system authentication broker in lieu of the system browser when available.  

  [Source code][source] | [Package (nuget)][package] | [API reference documentation][identity_api_docs] | [Azure Active Directory documentation][aad_doc]

## Getting started

### Install the package

Install the Azure Identity client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Identity.BrokeredAuthentication --prerelease
```

### Prerequisites
* The [Azure.Identity][azure_identity] library is a dependency of Azure.Identity.BrokeredAuthentication.

### Authenticate the client

## Key concepts

## Examples

### Configuring the `InteractiveBrowserCredential` to use the system authentication broker

This example demonstrates configuring the `InteractiveBrowserCredential` with the specialized options type `InteractiveBrowserCredentialBrokerOptions` to enable brokered authentication.

```C# Snippet:ConfigureInteractiveBrowserToUseBroker
IntPtr parentWindowHandle = GetForegroundWindow();

// Create an interactive browser credential which will use the system authentication broker
var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

// Use the credential to authenticate a secret client
var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
```

## Troubleshooting

See the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md) for details on how to diagnose various failure scenarios.

### Error Handling
Errors arising from authentication can be raised on any service client method which makes a request to the service. This is because the first time the token is requested from the credential is on the first call to the service, and any subsequent calls might need to refresh the token. In order to distinguish these failures from failures in the service client Azure Identity classes raise the `AuthenticationFailedException` with details to the source of the error in the exception message as well as possibly the error message. Depending on the application these errors may or may not be recoverable.

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

For more details on dealing with errors arising from failed requests to Azure Active Directory, or managed identity endpoints please refer to the Azure Active Directory [documentation on authorization error codes][aad_err_doc].

### Logging

The Azure Identity library provides the same [logging capabilities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) as the rest of the Azure SDK.

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

### Thread safety
We guarantee that all credential instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)).
This ensures that the recommendation of reusing credential instances is always safe, even across threads.

### Additional concepts
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)

## Next steps

### Client libraries supporting authentication with Azure Identity

Many of the client libraries listed [here](https://azure.github.io/azure-sdk/releases/latest/dotnet.html) support authenticating with `TokenCredential` and the Azure Identity library.
There you will also find links where you can learn more about their use, including additional documentation and samples.

### Known Issues

This library does not currently support scenarios relating to the [AAD B2C](https://docs.microsoft.com/azure/active-directory-b2c/overview) service.

Currently open issues for the Azure.Identity library can be found [here](https://github.com/Azure/azure-sdk-for-net/issues?q=is%3Aissue+is%3Aopen+label%3AAzure.Identity).

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_powerShell]: https://docs.microsoft.com/powershell/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity.BrokeredAuthentication/src
[package]: https://www.nuget.org/packages?q=Azure.Identity.BrokeredAuthentication
[aad_doc]: https://docs.microsoft.com/azure/active-directory/
[aad_err_doc]: https://docs.microsoft.com/azure/active-directory/develop/reference-aadsts-error-codes
[certificates_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Certificates
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[nuget]: https://www.nuget.org/
[keys_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Keys
[secrets_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Secrets
[blobs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs
[queues_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Queues
[eventhubs_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs
[azure_core_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core
[identity_api_docs]: https://docs.microsoft.com/dotnet/api/azure.identity?view=azure-dotnet
[vs_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/VsLoginDialog.png
[azure_cli_login_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/AzureCliLogin.png
[azure_cli_login_device_code_image]: https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/identity/Azure.Identity/images/AzureCliLoginDeviceCode.png
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
[ref_AzurePowerShellCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/src/AzurePowerShellCredential.cs
[ref_VisualStudioCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.visualstudiocredential?view=azure-dotnet
[ref_VisualStudioCodeCredential]: https://docs.microsoft.com/dotnet/api/azure.identity.visualstudiocodecredential?view=azure-dotnet

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fidentity%2FAzure.Identity%2FREADME.png)
