# Azure Communication Identity client library for .NET

Azure Communication Identity is managing tokens for Azure Communication Services.

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Identity client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.Identity --version 1.0.0
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
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
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

### Creating a user and a token in the same request
```C# Snippet:CreateCommunicationUserAndToken
Response<CommunicationUserIdentifierAndToken> response = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat });
var (user, token) = response.Value;
Console.WriteLine($"User id: {user.Id}");
Console.WriteLine($"Token: {token.Token}");
```

### Revoking a user's tokens

In case a user's tokens are compromised or need to be revoked:

```C# Snippet:RevokeCommunicationUserToken
Response revokeResponse = client.RevokeTokens(user);
```

### Deleting a user

```C# Snippet:DeleteACommunicationUser
Response deleteResponse = client.DeleteUser(user);
```

### Exchange access token

```C# Snippet:ExchangeTeamsToken
Response<AccessToken> tokenResponse = await client.ExchangeTeamsTokenAsync(teamsToken);
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

[azure_sub]: https://azure.microsoft.com/free/
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
