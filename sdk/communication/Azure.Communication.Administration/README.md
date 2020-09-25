# Azure Communication Administration client library for .NET

> Server Version: 
Identity client: 2020-07-20-preview2

Azure Communication Administration is managing tokens and phone numbers for Azure Communication Services.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]

## Getting started

### Install the package
Install the Azure Communication Administration client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.Administration --version 1.0.0-beta.1
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal] or the [.NET management client library][communication_resource_create_net].

<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Authenticate the client

Administration clients can be authenticated using connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateCommunicationIdentityClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationIdentityClient(connectionString);
```

### Key concepts
`CommunicationIdentityClient` provides the functionalities to manage user access tokens: creating new ones, renewing and revoking them.

## Examples

### Create a new identity
```C# Snippet:CreateCommunicationUserAsync
Response<CommunicationUser> userResponse = await client.CreateUserAsync();
CommunicationUser user = userResponse.Value;
Console.WriteLine($"User id: {user.Id}");
```

### Issuing or Refreshing a token for an existing identity
```C# Snippet:CreateCommunicationTokenAsync
Response<CommunicationUserToken> tokenResponse = await client.IssueTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat });
string token = tokenResponse.Value.Token;
DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
Console.WriteLine($"Token: {token}");
Console.WriteLine($"Expires On: {expiresOn}");
```

### Revoking a user's tokens
In case a user's tokens are compromised or need to be revoked:
```C# Snippet:RevokeCommunicationUserToken
Response revokeResponse = client.RevokeTokens(
    user,
    issuedBefore: DateTimeOffset.UtcNow.AddDays(-1) /* optional */);
```

### Deleting a user
```C# Snippet:DeleteACommunicationUser
Response deleteResponse = client.DeleteUser(user);
```

## Troubleshooting
All User token service operations will throw a RequestFailedException on failure.

```C# Snippet:CommunicationIdentityClient_Troubleshooting
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationIdentityClient(connectionString);

try
{
    Response<CommunicationUser> response = await client.CreateUserAsync();
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Next steps
[Read more about Communication user access tokens][user_access_token]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Administration/src
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[package]: https://www.nuget.org/packages/Azure.Communication.Administration
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[user_access_token]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net

