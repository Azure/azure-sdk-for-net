# Azure Communication Common client library for .NET

This package contains common code for Azure Communication Service libraries.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication Common client library for .NET with [NuGet][nuget].

```Powershell
dotnet add package Azure.Communication.Common --version 1.0.0-beta.3
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

`CommunicationTokenCredential` authenticates a user with Communication Services, such as Chat or Calling. It optionally provides an auto-refresh mechanism to ensure a continuously stable authentication state during communications.

It is up to you the developer to first create valid user tokens with the Communication Administration SDK. Then you use these tokens with the `CommunicationTokenCredential`.

## Examples

### Create a credential with a static token

For a short-lived clents when refreshing token upon expiry is not needed, `CommunicationTokenCredential` can be instantited with a static token.

```C# Snippet:CommunicationTokenCredential_CreateWithStaticToken
string token = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
using var tokenCredential = new CommunicationTokenCredential(token);
```

Alternatively, you can create a `CommunicationTokenCredential` with callback to renew tokens if expired.
Here we pass two imagined functions that make network requests to retrieve token strings for user Bob.
If callbacks are passed, upon requests (sending a chat message), `CommunicationTokenCredential` ensures
that a valid token is acquired prior to executing the request.

Optionally, you can enable proactive token refreshing where a fresh token will be acquired as soon as the
previous token approaches expiry. Using this method, your requests are less likely to be blocked to acquire a fresh token:

```C# Snippet:CommunicationTokenCredential_CreateRefreshableWithoutInitialToken
using var tokenCredential = new CommunicationTokenCredential(
    new CommunicationTokenRefreshOptions(
        refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
        tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
        asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken)
        )
    );
```

If you already have a token, you can optimize the token refreshing even further by passing that initial token:

```C# Snippet:CommunicationTokenCredential_CreateRefreshableWithInitialToken
string initialToken = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
using var tokenCredential = new CommunicationTokenCredential(
    new CommunicationTokenRefreshOptions(
        refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
        tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
        asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken),
        initialToken)
    );
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
[azure_sub]: https://azure.microsoft.com/free/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Common/src
[package]: https://www.nuget.org/packages/Azure.Communication.Common/
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[user_access_token]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net


