# Azure Remote Rendering client library for .NET

Azure Remote Rendering (ARR) is a service that enables you to render high-quality, interactive 3D content in the cloud and stream it in real time to devices, such as the HoloLens 2.


TODO: .Client in the URLs here (and .Client elsewhere in doc)
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
    - [Convert an asset](#convert-an-asset)
    - [Query the status of a conversion](#query-the-status-of-a-conversion)
    - [Create a session](#create-a-session)
    - [Query the status of a session](#query-the-status-of-a-session)
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

### RemoteRenderingClient

The `RemoteRenderingClient` is the client library used to access the RemoteRenderingService.
It provides methods to create and manage asset conversions and rendering sessions.

## Examples

- [Convert an asset](#convert-an-asset)
- [Query the status of a conversion](#query-the-status-of-a-conversion)
- [Create a session](#create-a-session)
- [Query the status of a session](#query-the-status-of-a-session)

### Convert an asset

We assume that a RemoteRenderingClient has been constructed as described in the [Authenticate the Client](#authenticate-the-client) section.
The following snippet describes how to request that an asset, stored in blob storage at the given input container URI, gets converted.

```csharp Snippet:ConvertAnAsset
    ConversionInputSettings input = new ConversionInputSettings("MyInputContainer", "box.fbx");
    ConversionOutputSettings output = new ConversionOutputSettings("MyOutputContainer");
    ConversionSettings settings = new ConversionSettings(input, output);

    string conversionId = "ConversionId1";

    client.CreateConversion(conversionId, settings);
```

### Query the status of a conversion

```csharp Snippet:QueryConversionStatus
    // Poll every 10 seconds completion every ten seconds.
    while (true)
    {
        Thread.Sleep(10000);

        ConversionInformation conversion = client.GetConversion(conversionId).Value;
        if (conversion.Status == CreatedByType.Succeeded)
        {
            Console.WriteLine($"Conversion succeeded: Output written to {conversion.Settings.OutputLocation}");
            break;
        }
        else if (conversion.Status == CreatedByType.Failed)
        {
            Console.WriteLine($"Conversion failed: {conversion.Error.Code} {conversion.Error.Message}");
            break;
        }
    }
```

### Create a session

We assume that a RemoteRenderingClient has been constructed as described in the [Authenticate the Client](#authenticate-the-client) section.
The following snippet describes how to request that a new rendering session be started.

```csharp Snippet:CreateASession
    string sessionId = "SessionId1";

    CreateSessionBody settings = new CreateSessionBody(10, SessionSize.Standard);

    client.CreateSession(sessionId, settings);
```

### Query the status of a session

```csharp Snippet:QuerySessionStatus
    // Poll every 10 seconds until the session is ready.
    while (true)
    {
        Thread.Sleep(10000);

        SessionProperties properties = client.GetSession(sessionId).Value;
        if (properties.Status == SessionStatus.Ready)
        {
            Console.WriteLine($"The session is ready. The session hostname is: {properties.Hostname}");
            break;
        }
        else if (properties.Status == SessionStatus.Error)
        {
            Console.WriteLine($"Session creation encountered an error: {properties.Error.Code} {properties.Error.Message}");
            break;
        }
    }
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
