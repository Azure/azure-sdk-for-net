# Azure Communication Identity client library for .NET

Azure Communication Identity is managing tokens for Azure Communication Services.

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Identity client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Identity
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

The identity client can be authenticated using a connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateCommunicationIdentityClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationIdentityClient(connectionString);
```

Or alternatively using the endpoint and access key acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateCommunicationIdentityFromAccessKey
var endpoint = new Uri("https://my-resource.communication.azure.com");
var accessKey = "<access_key>";
var client = new CommunicationIdentityClient(endpoint, new AzureKeyCredential(accessKey));
```

Clients also have the option to authenticate using a valid Active Directory token.

```C# Snippet:CreateCommunicationIdentityFromToken
var endpoint = new Uri("https://my-resource.communication.azure.com");
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new CommunicationIdentityClient(endpoint, tokenCredential);
```

### Key concepts

`CommunicationIdentityClient` provides the functionalities to manage user access tokens: creating new ones and revoking them.

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

### Creating a new user

```C# Snippet:CreateCommunicationUserAsync
Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
CommunicationUserIdentifier user = userResponse.Value;
Console.WriteLine($"User id: {user.Id}");
```

### Getting a token for an existing user

```C# Snippet:CreateCommunicationTokenAsync
Response<AccessToken> tokenResponse = await client.GetTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat });
string token = tokenResponse.Value.Token;
DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
Console.WriteLine($"Token: {token}");
Console.WriteLine($"Expires On: {expiresOn}");
```

The `GetToken` function takes in a list of `CommunicationTokenScope`. Scope options include:
- `Chat` (Use this for full access to Chat APIs)
- `VoIP` (Use this for full access to Calling APIs)
- `ChatJoin` (Access to Chat APIs but without the authorization to create, delete or update chat threads)
- `ChatJoinLimited` (A more limited version of ChatJoin that doesn't allow to add or remove participants)
- `VoIPJoin` (Access to Calling APIs but without the authorization to start new calls)


It's also possible to create a Communication Identity access token by customizing the expiration time. Validity period of the token must be within [1,24] hours range. If not provided, the default value of 24 hours will be used.

```C# Snippet:CreateCommunicationTokenAsyncWithCustomExpiration
TimeSpan tokenExpiresIn = TimeSpan.FromHours(1);
Response<AccessToken> tokenResponse = await client.GetTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn);
string token = tokenResponse.Value.Token;
DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
Console.WriteLine($"Token: {token}");
Console.WriteLine($"Expires On: {expiresOn}");
```

### Creating a user and a token in the same request
```C# Snippet:CreateCommunicationUserAndToken
Response<CommunicationUserIdentifierAndToken> response = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat });
var (user, token) = response.Value;
Console.WriteLine($"User id: {user.Id}");
Console.WriteLine($"Token: {token.Token}");
```

It's also possible to create a Communication Identity access token by customizing the expiration time. Validity period of the token must be within [1,24] hours range. If not provided, the default value of 24 hours will be used.

```C# Snippet:CreateCommunicationUserAndTokenWithCustomExpirationAsync
TimeSpan tokenExpiresIn = TimeSpan.FromHours(1);
Response<CommunicationUserIdentifierAndToken> response = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn);
var (user, token) = response.Value;
Console.WriteLine($"User id: {user.Id}");
Console.WriteLine($"Token: {token.Token}");
```

### Revoking a user's tokens

In case a user's tokens are compromised or need to be revoked:

```C# Snippet:RevokeCommunicationUserTokenAsync
Response revokeResponse = await client.RevokeTokensAsync(user);
```

### Deleting a user

```C# Snippet:DeleteACommunicationUserAsync
Response deleteResponse = await client.DeleteUserAsync(user);
```

### Exchanging Azure AD access token of a Teams User for a Communication Identity access token
The `CommunicationIdentityClient` can be used to exchange an Azure AD access token of a Teams user for a new Communication Identity access token with a matching expiration time.

The `GetTokenForTeamsUser` function accepts the following parameters wrapped into the `GetTokenForTeamsUserOptions` option bag:
- `teamsUserAadToken` Azure Active Directory access token of a Teams user
- `clientId` Client ID of an Azure AD application to be verified against the appId claim in the Azure AD access token
- `userObjectId` Object ID of an Azure AD user (Teams User) to be verified against the OID claim in the Azure AD access token

```C# Snippet:GetTokenForTeamsUserAsync
Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(teamsUserAadToken, clientId, userObjectId));
string token = tokenResponse.Value.Token;
Console.WriteLine($"Token: {token}");
```

## Troubleshooting

All User token service operations will throw a RequestFailedException on failure.

```C# Snippet:CommunicationIdentityClient_Troubleshooting
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationIdentityClient(connectionString);

try
{
    Response<CommunicationUserIdentifier> response = await client.CreateUserAsync();
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

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Identity/src
[source_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Identity/samples
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
<!--[package]: https://www.nuget.org/packages/Azure.Communication.Identity-->
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[user_access_token]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
