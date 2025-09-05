# Azure Communication Common client library for .NET

This package contains common code for Azure Communication Service libraries.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication Common client library for .NET with [NuGet][nuget].

```dotnetcli
dotnet add package Azure.Communication.Common
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Authenticate the client
This module does not contain a client and instead libraries that help other Azure Communication clients authenticate.

### Key concepts

### CommunicationTokenCredential

The `CommunicationTokenCredential` object is used to authenticate a user with Communication Services, such as Chat or Calling. It optionally provides an auto-refresh mechanism to ensure a continuously stable authentication state during communications.

Depending on your scenario, you may want to initialize the `CommunicationTokenCredential` with:

- a static token (suitable for short-lived clients used to e.g. send one-off Chat messages) or
- a callback function that ensures a continuous authentication state (ideal e.g. for long Calling sessions).
- a token credential capable of obtaining an Entra user token. You can provide any implementation of [Azure.Core.TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet). It is suitable for scenarios where Entra user access tokens are needed to authenticate with Communication Services.

The tokens supplied to the `CommunicationTokenCredential` either through the constructor or via the token refresher callback can be obtained using the Azure Communication Identity library.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Create a credential with a static token

For short-lived clients, refreshing the token upon expiry is not necessary and `CommunicationTokenCredential` may be instantiated with a static token.

```C# Snippet:CommunicationTokenCredential_CreateWithStaticToken
string token = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
using var tokenCredential = new CommunicationTokenCredential(token);
```

### Create a credential with a callback

Alternatively, for long-lived clients, you can create a `CommunicationTokenCredential` with a callback to renew tokens if expired.
Here we pass two imagined functions that make network requests to retrieve token strings for user Bob.
If callbacks are passed, upon requests (sending a chat message), `CommunicationTokenCredential` ensures
that a valid token is acquired prior to executing the request.
It's necessary that the `FetchTokenForUserFromMyServer` method returns a valid token (with an expiration date set in the future) at all times.

Optionally, you can enable proactive token refreshing where a fresh token will be acquired as soon as the
previous token approaches expiry. Using this method, your requests are less likely to be blocked to acquire a fresh token:

```C# Snippet:CommunicationTokenCredential_CreateRefreshableWithoutInitialToken
using var tokenCredential = new CommunicationTokenCredential(
    new CommunicationTokenRefreshOptions(
        refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
        tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken))
    {
        AsyncTokenRefresher = cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken)
    });
```

If you already have a token, you can optimize the token refreshing even further by passing that initial token:

```C# Snippet:CommunicationTokenCredential_CreateRefreshableWithInitialToken
string initialToken = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
using var tokenCredential = new CommunicationTokenCredential(
    new CommunicationTokenRefreshOptions(
       refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
       tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken))
    {
        AsyncTokenRefresher = cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken),
        InitialToken = initialToken
    });
```

### Create a credential with a token credential capable of obtaining an Entra user token

For scenarios where an Entra user can be used with Communication Services, you need to initialize any implementation of [Azure.Core.TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) and provide it to the ``EntraCommunicationTokenCredentialOptions``.
Along with this, you must provide the URI of the Azure Communication Services resource and the scopes required for the Entra user token. These scopes determine the permissions granted to the token.

This approach needs to be used for authorizing an Entra user with a Teams license to use Teams Phone Extensibility features through your Azure Communication Services resource.
This requires providing the `https://auth.msft.communication.azure.com/TeamsExtension.ManageCalls` scope.
```C# 
var options = new InteractiveBrowserCredentialOptions
    {
        TenantId = "<your-tenant-id>",
        ClientId = "<your-client-id>",
        RedirectUri = new Uri("<your-redirect-uri>")
    };
var entraTokenCredential = new InteractiveBrowserCredential(options);

var entraTokenCredentialOptions = new EntraCommunicationTokenCredentialOptions(
    resourceEndpoint: "https://<your-resource>.communication.azure.com",
    entraTokenCredential: entraTokenCredential)
    )
    {
      Scopes = new[] { "https://auth.msft.communication.azure.com/TeamsExtension.ManageCalls" }
    };

var credential = new CommunicationTokenCredential(entraTokenCredentialOptions);

```

Other scenarios for Entra users to utilize Azure Communication Services are currently in the **preview stage only and should not be used in production**.
The scopes for these scenarios follow the format `https://communication.azure.com/clients/<Azure Communication Services Clients API permission>`.
If specific scopes are not provided, the default scopes will be set to `https://communication.azure.com/clients/.default`.
```C# 
var options = new InteractiveBrowserCredentialOptions
    {
        TenantId = "<your-tenant-id>",
        ClientId = "<your-client-id>",
        RedirectUri = new Uri("<your-redirect-uri>")
    };
var entraTokenCredential = new InteractiveBrowserCredential(options);

var entraTokenCredentialOptions = new EntraCommunicationTokenCredentialOptions(
    resourceEndpoint: "https://<your-resource>.communication.azure.com",
    entraTokenCredential: entraTokenCredential)
    {
      Scopes = new[] { "https://communication.azure.com/clients/VoIP" }
    };

var credential = new CommunicationTokenCredential(entraTokenCredentialOptions);

```

## Troubleshooting
The proactive refreshing failures happen in a background thread and to avoid crashing your app the exceptions will be silently handled.
All the other failures will happen during your request using other clients such as chat where you can catch the exception using `RequestFailedException`.

## Next steps
[Read more about Communication user access tokens][user_access_token]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Common/src
[package]: https://www.nuget.org/packages/Azure.Communication.Common/
[product_docs]: https://learn.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[user_access_token]: https://learn.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net

