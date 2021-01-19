# Azure Mixed Reality Authentication client library for .NET

Mixed Reality services, like Azure Spatial Anchors, Azure Remote Rendering, and others, use the Mixed Reality security
token service (STS) for authentication. This package supports exchanging Mixed Reality account credentials for an access
token from the STS that can be used to access Mixed Reality services.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/mixedreality/Azure.MixedReality.Authentication) | NuGet

![Mixed Reality service authentication diagram](https://docs.microsoft.com/azure/spatial-anchors/concepts/media/spatial-anchors-authentication-overview.png)

- [Azure Mixed Reality Authentication client library for .NET](#azure-mixed-reality-authentication-client-library-for-net)
  - [Getting started](#getting-started)
    - [Install the package](#install-the-package)
    - [Prerequisites](#prerequisites)
    - [Authenticate the client](#authenticate-the-client)
      - [Authentication examples](#authentication-examples)
        - [Authenticating with account key authentication](#authenticating-with-account-key-authentication)
        - [Authenticating with an AAD client secret](#authenticating-with-an-aad-client-secret)
        - [Authenticating a user using device code authentication](#authenticating-a-user-using-device-code-authentication)
        - [Interactive authentication with DefaultAzureCredential](#interactive-authentication-with-defaultazurecredential)
  - [Key concepts](#key-concepts)
    - [MixedRealityStsClient](#mixedrealitystsclient)
  - [Examples](#examples)
    - [Retrieve an access token](#retrieve-an-access-token)
  - [Troubleshooting](#troubleshooting)
  - [Next steps](#next-steps)
    - [Client libraries supporting authentication with Mixed Reality Authentication](#client-libraries-supporting-authentication-with-mixed-reality-authentication)
  - [Contributing](#contributing)

## Getting started

### Install the package

Install the Azure Mixed Reality Authentication client library for .NET using one of the following methods.

From Visual Studio Package Manager:

```powershell
Install-Package Azure.MixedReality.Authentication
```

From .NET CLI

```dotnetcli
dotnet add package Azure.MixedReality.Authentication
```

Add a package reference:

```xml
<PackageReference Include="Azure.MixedReality.Authentication" Version="1.0.0-preview.1" />
```

### Prerequisites

- You must have an [Azure subscription](https://azure.microsoft.com/free/).
- You must have an account with an [Azure Mixed Reality service](https://azure.microsoft.com/topic/mixed-reality/):
  - [Azure Remote Rendering](https://docs.microsoft.com/azure/remote-rendering/)
  - [Azure Spatial Anchors](https://docs.microsoft.com/azure/spatial-anchors/)
- Familiarity with the authentication and credential concepts from [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md).

### Authenticate the client

Mixed Reality services support a few different forms of authentication:

- Account Key authentication
  - Account keys enable you to get started quickly with using Mixed Reality services. But before you deploy your application
    to production, we recommend that you update your app to use Azure AD authentication.
- Azure Active Directory (AD) token authentication
  - If you're building an enterprise application and your company is using Azure AD as its identity system, you can use
    user-based Azure AD authentication in your app. You then grant access to your Mixed Reality accounts by using your
    existing Azure AD security groups. You can also grant access directly to users in your organization.
  - Otherwise, we recommend that you obtain Azure AD tokens from a web service that supports your app. We recommend this
    method for production applications because it allows you to avoid embedding the credentials for access to a Mixed
    Reality service in your client application.

See [here](https://docs.microsoft.com/azure/spatial-anchors/concepts/authentication) for detailed instructions and information.

#### Authentication examples

Below are some examples of some common authentication scenarios, but more examples and information can be found at
[Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md).

##### Authenticating with account key authentication

Use the `MixedRealityStsClient` constructor overload accepting an `AzureKeyCredential` to configure account key
authentication with the Mixed Reality STS:

```csharp
AzureKeyCredential keyCredential = new AzureKeyCredential(accountKey);
MixedRealityStsClient client = new MixedRealityStsClient(accountId, accountDomain, keyCredential);
```

> Note: Account key authentication is **not recommended** for production applications.

##### Authenticating with an AAD client secret

```csharp
TokenCredential aadCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
{
    AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
});

MixedRealityStsClient client = new MixedRealityStsClient(accountId, accountDomain, aadCredential);
```

##### Authenticating a user using device code authentication

```csharp
Task deviceCodeCallback(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
{
    Debug.WriteLine(deviceCodeInfo.Message);
    Console.WriteLine(deviceCodeInfo.Message);
    return Task.FromResult(0);
}

TokenCredential deviceCodeCredential = new DeviceCodeCredential(deviceCodeCallback, tenantId, clientId, new TokenCredentialOptions
{
    AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}"),
});

MixedRealityStsClient client = new MixedRealityStsClient(accountId, accountDomain, deviceCodeCredential);

AccessToken token = await client.GetTokenAsync(accountId);
```

See [here](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Device-Code-Flow) for more
information about using device code authentication flow.

##### Interactive authentication with DefaultAzureCredential

Use the `DefaultAzureCredential` object with `includeInteractiveCredentials: true` to use default interactive authentication
flow:

```csharp
TokenCredential credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

MixedRealityStsClient client = new MixedRealityStsClient(accountId, accountDomain, credential);
```

## Key concepts

### MixedRealityStsClient

The `MixedRealityStsClient` is the client library used to access the Mixed Reality STS to get an access token.

Tokens obtained from the Mixed Reality STS have a lifetime of **24 hours**.

## Examples

### Retrieve an access token

```csharp
AzureKeyCredential keyCredential = new AzureKeyCredential(accountKey);
MixedRealityStsClient client = new MixedRealityStsClient(accountId, accountDomain, keyCredential);

AccessToken token = await client.GetTokenAsync(accountId);
```

See the authentication examples [above](#authenticate-the-client) for more complex authentication scenarios.

## Troubleshooting

- See [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#error-handling) for Azure.Identity.
- See [Logging](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#logging) for Azure.Identity.

## Next steps

### Client libraries supporting authentication with Mixed Reality Authentication

Libraries supporting the Mixed Reality Authentication are coming soon.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License
Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the
PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this
once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact
[opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
