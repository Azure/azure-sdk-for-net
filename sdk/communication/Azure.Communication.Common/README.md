# Azure Communication Common client library for .NET

This package contains common code for Azure Communication Service libraries.

<!-- [Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs] -->
## Getting started

### Install the package
Install the Azure Communication Common client library for .NET with [NuGet][nuget].

```Powershell
dotnet add package Azure.Communication.Common --version 1.0.0-beta.1
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a Communication Service resource to use this package.
<!--[Communication Service Resource][communication_resource_docs]-->

<!--To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal],
[Azure PowerShell][communication_resource_create_ps], or the [Azure CLI][communication_resource_create_cli].-->

<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Authenticate the client
This module does not contain a client and instead libraries that help other Azure Communication clients authenticate.

### Key concepts

### CommunicationUserCredential

`CommunicationUserCredential` authenticates a user with Communication Services, such as Chat or Calling. It optionally provides an auto-refresh mechanism to ensure a continuously stable authentication state during communications.

It is up to you the developer to first create valid user tokens with the Communication Administration SDK. Then you use these tokens with the `CommunicationUserCredential`.

## Examples

### Create a credential with a static token

For a short-lived clents when refreshing token upon expiry is not needed, `CommunicationUserCredential` can be instantited with a static token.

```C# Snippet:CommunicationUserCredential_CreateWithStaticToken
string token = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
using var userCredential = new CommunicationUserCredential(token);
```

Alternatively, you can create a `CommunicationUserCredential` with callback to renew tokens if expired.
Here we pass two imagined functions that make network requests to retrieve token strings for user Bob.
If callbacks are passed, upon requests (sending a chat message), `CommunicationUserCredential` ensures
that a valid token is acquired prior to executing the request.

Optionally, you can enable proactive token refreshing where a fresh token will be acquired as soon as the
previous token approaches expiry. Using this method, your requests are less likely to be blocked to acquire a fresh token:

```C# Snippet:CommunicationUserCredential_CreateRefreshableWithoutInitialToken
using var userCredential = new CommunicationUserCredential(
    refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
    tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
    asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken));
```

If you already have a token, you can optimize the token refreshing even further by passing that initial token:

```C# Snippet:CommunicationUserCredential_CreateRefreshableWithInitialToken
string initialToken = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_USER_TOKEN");
using var userCredential = new CommunicationUserCredential(
    refreshProactively: true, // Indicates if the token should be proactively refreshed in the background or only on-demand
    tokenRefresher: cancellationToken => FetchTokenForUserFromMyServer("bob@contoso.com", cancellationToken),
    asyncTokenRefresher: cancellationToken => FetchTokenForUserFromMyServerAsync("bob@contoso.com", cancellationToken),
    initialToken);
```

## Troubleshooting
The proactive refreshing failures happen in a background thread and to avoid crashing your app the exceptions will be silently handled.
All the other failures will happen during your request using other clients such as chat where you can catch the exception using `RequestFailedException`.

## Next steps
* [Read more about Communication user access tokens][user_access_token]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[azure_sub]: https://azure.microsoft.com/free/
[source]: src
<!-- TODO: [package]: https://www.nuget.org/packages/Azure.Communication.Common/ -->
<!-- TODO: [product_docs]: -->
[nuget]: https://www.nuget.org/
<!-- [user_access_token]: -->
<!-- [communication_resource_docs]:  -->
<!-- [communication_resource_create_portal]:  -->
<!-- [communication_resource_create_ps]:  -->
<!-- [communication_resource_create_cli]:  -->
