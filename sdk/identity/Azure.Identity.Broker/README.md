# Azure Identity brokered authentication client library for .NET

The library extends the Azure Identity library to provide authentication broker support. It includes the necessary dependencies and provides the `InteractiveBrowserCredentialBrokerOptions` class. This options class can be used to create an `InteractiveBrowserCredential` capable of using the system authentication broker in lieu of an embedded web view or the system browser.

An authentication broker is an application that runs on a user's machine and manages the authentication handshakes and token maintenance for connected accounts. Currently, the following authentication brokers are supported:

- **Windows**: [Web Account Manager (WAM)](https://learn.microsoft.com/windows/uwp/security/web-account-manager)
- **macOS**: Microsoft broker (via `Microsoft.Identity.Client.Broker`)
- **Linux / WSL**: Microsoft broker (see [Enable SSO in native Linux apps using MSAL.NET](https://learn.microsoft.com/entra/msal/dotnet/acquiring-tokens/desktop-mobile/linux-dotnet-sdk) for prerequisites)

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][identity_api_docs] | [Microsoft Entra ID documentation][entraid_doc]

## Getting started

### Install the package

Install the Azure Identity brokered authentication extension for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Identity.Broker
```

### Prerequisites

* An [Azure subscription][azure_sub].
* The [Azure.Core][azure_core] package (1.53.0 or later) or the [Azure.Identity][azure_identity] package (1.21.0 or later).

> [!IMPORTANT]
> `Azure.Identity.Broker` version 1.6.0 or later is **required** when using `Azure.Core` 1.53.0+ or `Azure.Identity` 1.21.0+. Older `Azure.Identity.Broker` versions are not compatible with the type consolidation introduced in those releases. See the [migration guide][migration_guide] for details.

### Authenticate the client

See the end-to-end instructions at [Use a broker](https://aka.ms/azsdk/net/identity/broker).

## Key concepts

This package enables authentication broker support via [InteractiveBrowserCredentialBrokerOptions][broker_options_api], in combination with `InteractiveBrowserCredential` in the `Azure.Identity` package.

### Supported platforms

Starting with version 1.3.0, `Azure.Identity.Broker` supports brokered authentication on **Windows**, **macOS**, and **Linux / WSL**. On Linux, the Microsoft broker requires additional prerequisites; see [Enable SSO in native Linux apps using MSAL.NET](https://learn.microsoft.com/entra/msal/dotnet/acquiring-tokens/desktop-mobile/linux-dotnet-sdk) for details.

### Microsoft account (MSA) passthrough

Microsoft accounts (MSA) are personal accounts created by users to access Microsoft services. MSA passthrough is a legacy configuration which enables users to get tokens to resources which normally don't accept MSA logins. This feature is only available to first-party applications. Users authenticating with an application that is configured to use MSA passthrough can set the `InteractiveBrowserCredentialBrokerOptions.IsLegacyMsaPassthroughEnabled` property to `true` to allow these personal accounts to be listed by WAM.

### Default broker account

The `UseDefaultBrokerAccount` property allows the credential to authenticate with the currently signed-in operating system account without prompting the user with a login dialog.

### Configuration and dependency injection

Starting with version 1.4.0, `Azure.Identity.Broker` includes experimental support for `Microsoft.Extensions.Configuration` and `Microsoft.Extensions.DependencyInjection` integration. For details, see the [Configuration and Dependency Injection][config_di_doc] documentation.

### JSON schema for appsettings.json

Starting with version 1.5.0, this package includes a JSON schema segment that enables IntelliSense and validation for broker credential configuration in `appsettings.json` files when used with the configuration integration above.

## Examples

### Authenticate using `InteractiveBrowserCredential` with broker

The simplest scenario is authenticating a client using the system authentication broker. A parent window handle (HWND) is required so the broker dialog can be docked to the application window.

```C#
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = GetForegroundWindow(); // Obtain the parent window handle

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
```

### Use the default broker account

To silently authenticate with the currently logged-in operating system account instead of prompting for credentials, set `UseDefaultBrokerAccount` to `true`:

```C#
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = GetForegroundWindow();

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
    {
        UseDefaultBrokerAccount = true
    });

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
```

## Troubleshooting

See the [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md) for details on how to diagnose various failure scenarios.

### Error handling

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

For more details on dealing with errors arising from failed requests to Microsoft Entra ID, or managed identity endpoints please refer to the Microsoft Entra ID [documentation on authorization error codes][entraid_err_doc].

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

### Samples

For more detailed usage examples, see the [samples][samples] directory.

### Client libraries supporting authentication with Azure Identity

Many of the client libraries listed [here](https://azure.github.io/azure-sdk/releases/latest/dotnet.html) support authenticating with `TokenCredential` and the Azure Identity library.
There you will also find links where you can learn more about their use, including additional documentation and samples.

### Known issues

This library does not currently support scenarios relating to the [AAD B2C](https://learn.microsoft.com/azure/active-directory-b2c/overview) service.

Currently open issues for the Azure.Identity library can be found [here](https://github.com/Azure/azure-sdk-for-net/issues?q=is%3Aissue+is%3Aopen+label%3AAzure.Identity).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_core]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/README.md
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity.Broker/src
[package]: https://www.nuget.org/packages/Azure.Identity.Broker
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity.Broker/samples
[entraid_doc]: https://learn.microsoft.com/entra/identity/
[entraid_err_doc]: https://learn.microsoft.com/entra/identity-platform/reference-error-codes
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[nuget]: https://www.nuget.org/
[identity_api_docs]: https://learn.microsoft.com/dotnet/api/azure.identity.broker?view=azure-dotnet
[broker_options_api]: https://learn.microsoft.com/dotnet/api/azure.identity.broker.interactivebrowsercredentialbrokeroptions
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/MigrationGuide.md#azureidentitybroker-compatibility
[config_di_doc]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ConfigurationAndDependencyInjection.md
