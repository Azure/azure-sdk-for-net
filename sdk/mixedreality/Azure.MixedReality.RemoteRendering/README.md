# Azure Remote Rendering client library for .NET

Remote Rendering is a cross-platform developer service that allows you to create mixed reality experiences using objects that persist their location across devices over time.

TODO: .Client in the URLs here.
[Source code](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/spatialanchors/Azure.MixedReality.RemoteRendering.Client) | [NuGet](https://www.nuget.org/packages/Azure.MixedReality.RemoteRendering.Client) | [Product documentation](https://docs.microsoft.com/azure/remote-rendering/)

- [Azure Remote Rendering client library for .NET](#azure-remote-rendering-client-library-for-net)
  - [Getting started](#getting-started)
    - [Install the package](#install-the-package)
    - [Prerequisites](#prerequisites)
    - [Authenticate the client](#authenticate-the-client)
      - [Authenticating with account key authentication](#authenticating-with-account-key-authentication)
      - [Authenticating with an AAD client secret](#authenticating-with-an-aad-client-secret)
      - [Authenticating a user using device code authentication](#authenticating-a-user-using-device-code-authentication)
      - [Interactive authentication with DefaultAzureCredential](#interactive-authentication-with-defaultazurecredential)
      - [Authenticating with a static access token](#authenticating-with-a-static-access-token)
  - [Key concepts](#key-concepts)
  - [Examples](#examples)
    - [Create the thing](#create-the-thing)
    - [Get the thing](#get-the-thing)
  - [Troubleshooting](#troubleshooting)
  - [Next steps](#next-steps)
  - [Contributing](#contributing)

## Getting started

### Install the package

Install the Azure Mixed Reality ARR client library for .NET using one of the following methods.

From Visual Studio Package Manager:

```powershell
Install-Package Azure.MixedReality.RemoteRendering.Client
```

From .NET CLI

```dotnetcli
dotnet add package Azure.MixedReality.RemoteRendering.Client
```

Add a package reference:

```xml
<PackageReference Include="Azure.MixedReality.RemoteRendering.Client" Version="1.0.0-preview.1" />
```

### Prerequisites

TODO:
Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/), [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

### Authenticate the client

Azure Remote Rendering supports a few different forms of authentication:

- Account Key authentication
  - Account keys enable you to get started quickly with using Azure Remote Rendering. But before you deploy your application
    to production, we recommend that you update your app to use Azure AD authentication.
- Azure Active Directory (AD) token authentication
  - If you're building an enterprise application and your company is using Azure AD as its identity system, you can use
    user-based Azure AD authentication in your app. You then grant access to your Azure Remote Rendering accounts by using
    your existing Azure AD security groups. You can also grant access directly to users in your organization.
  - Otherwise, we recommend that you obtain Azure AD tokens from a web service that supports your app. We recommend this
    method for production applications because it allows you to avoid embedding the credentials for access to Azure Spatial
    Anchors in your client application.

See [here](https://docs.microsoft.com/en-us/azure/remote-rendering/how-tos/authentication) for detailed instructions and information.

#### Authenticating with account key authentication

Use the `AccountKeyCredential` object to use an account identifier and account key to authenticate:

```csharp
RemoteRenderingAccount account = new RemoteRenderingAccount(accountId, accountDomain);
AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);

RemoteRenderingClient client = new RemoteRenderingClient(account, accountKeyCredential);
```

#### Authenticating with an AAD client secret

Use the `ClientSecretCredential` object to perform client secret authentication.

```csharp
RemoteRenderingAccount account = new RemoteRenderingAccount(accountId, accountDomain);

TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
{
    AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
});

RemoteRenderingClient client = new RemoteRenderingClient(account, credential);
```

#### Authenticating a user using device code authentication

Use the `DeviceCodeCredential` object to perform device code authentication.

```csharp
RemoteRenderingAccount account = new RemoteRenderingAccount(accountId, accountDomain);

Task deviceCodeCallback(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
{
    Debug.WriteLine(deviceCodeInfo.Message);
    Console.WriteLine(deviceCodeInfo.Message);
    return Task.FromResult(0);
}

TokenCredential credential = new DeviceCodeCredential(deviceCodeCallback, tenantId, clientId, new TokenCredentialOptions
{
    AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}"),
});

RemoteRenderingClient client = new RemoteRenderingClient(account, credential);
```

See [here](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Device-Code-Flow) for more
information about using device code authentication flow.

#### Interactive authentication with DefaultAzureCredential

Use the `DefaultAzureCredential` object with `includeInteractiveCredentials: true` to use default interactive authentication
flow:

```csharp
RemoteRenderingAccount account = new RemoteRenderingAccount(accountId, accountDomain);
TokenCredential credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

RemoteRenderingClient client = new RemoteRenderingClient(account, credential);
```

#### Authenticating with a static access token

You can pass a Mixed Reality access token as an `AccessToken` previously retrieved from the Mixed Reality STS service
to be used with a Mixed Reality client library:

```csharp
RemoteRenderingAccount account = new RemoteRenderingAccount(accountId, accountDomain);

// GetMixedRealityAccessTokenFromWebService is a hypothetical method that retrieves
// a Mixed Reality access token from a web service. The web service would use the
// MixedRealityStsClient and credentials to obtain an access token to be returned
// to the client.
AccessToken accessToken = GetMixedRealityAccessTokenFromWebService();

RemoteRenderingClient client = new RemoteRenderingClient(account, accessToken);
```

## Key concepts

TODO

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

## Examples

Include code snippets and short descriptions for each task you listed in the [Introduction](#introduction) (the bulleted list). Briefly explain each operation, but include enough clarity to explain complex or otherwise tricky operations.

If possible, use the same example snippets that your in-code documentation uses. For example, use the snippets in your `examples.py` that Sphinx ingests via its [literalinclude](https://www.sphinx-doc.org/en/1.5/markup/code.html?highlight=code%20examples#includes) directive. The `examples.py` file containing the snippets should reside alongside your package's code, and should be tested in an automated fashion.

Each example in the *Examples* section starts with an H3 that describes the example. At the top of this section, just under the *Examples* H2, add a bulleted list linking to each example H3. Each example should deep-link to the types and/or members used in the example.

- [Create the thing](#create-the-thing)
- [Get the thing](#get-the-thing)
- [List the things](#list-the-things)

### Create the thing

Use the `create_thing` method to create a Thing reference; this method does not make a network call. To persist the Thing in the service, call `Thing.save`.

```Python
thing = client.create_thing(id, name)
thing.save()
```

### Get the thing

The `get_thing` method retrieves a Thing from the service. The `id` parameter is the unique ID of the Thing, not its "name" property.

```C# Snippet:GetSecret
var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

SecretBundle secret = client.GetSecret("TestSecret");

Console.WriteLine(secret.Value);
```Python
things = client.list_things()
```

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

- Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
- If appropriate, point users to other packages that might be useful.
- If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
