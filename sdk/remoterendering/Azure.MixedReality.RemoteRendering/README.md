# Azure Remote Rendering client library for .NET

Azure Remote Rendering (ARR) is a service that enables you to render high-quality, interactive 3D content in the cloud and stream it in real time to devices, such as the HoloLens 2.

This SDK offers functionality to convert assets to the format expected by the runtime, and also to manage
the lifetime of remote rendering sessions.

> NOTE: Once a session is running, a client application will connect to it using one of the "runtime SDKs".
> These SDKs are designed to best support the needs of an interactive application doing 3d rendering.
> They are available in ([.net](https://learn.microsoft.com/dotnet/api/microsoft.azure.remoterendering)
> or ([C++](https://learn.microsoft.com/cpp/api/remote-rendering/)).

[Product documentation](https://learn.microsoft.com/azure/remote-rendering/)

## Getting started

### Install the package

Install the Azure Mixed Reality ARR client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.MixedReality.RemoteRendering
```

Add a package reference:

```xml
<PackageReference Include="Azure.MixedReality.RemoteRendering" Version="1.0.0" />
```

### Prerequisites

You will need an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an [Azure Remote Rendering account](https://learn.microsoft.com/azure/remote-rendering/how-tos/create-an-account) to use this package.

### Authenticate the client

Constructing a remote rendering client requires an authenticated account, and a remote rendering endpoint.
For an account created in the eastus region, the account domain will have the form "eastus.mixedreality.azure.com".
There are several different forms of authentication:

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

See [here](https://learn.microsoft.com/azure/remote-rendering/how-tos/authentication) for detailed instructions and information.

In all the following examples, the client is constructed with a `remoteRenderingEndpoint` Uri object.
The available endpoints correspond to regions, and the choice of endpoint determines the region in which the service performs its work.
An example is `https://remoterendering.eastus2.mixedreality.azure.com`.

> NOTE: For converting assets, it is preferable to pick a region close to the storage containing the assets.

> NOTE: For rendering, it is strongly recommended that you pick the closest region to the devices using the service.
> The time taken to communicate with the server impacts the quality of the experience.

#### Authenticating with account key authentication

Use the `AccountKeyCredential` object to use an account identifier and account key to authenticate:

```C# Snippet:CreateAClient
AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);

RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, accountKeyCredential);
```

#### Authenticating with an AAD client secret

Use the `ClientSecretCredential` object to perform client secret authentication.

```C# Snippet:CreateAClientWithAAD
TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
{
    AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
});

RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, credential);
```

#### Authenticating a user using device code authentication

Use the `DeviceCodeCredential` object to perform device code authentication.

```C# Snippet:CreateAClientWithDeviceCode
Task deviceCodeCallback(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
{
    Console.WriteLine(deviceCodeInfo.Message);
    return Task.FromResult(0);
}

TokenCredential credential = new DeviceCodeCredential(deviceCodeCallback, tenantId, clientId, new TokenCredentialOptions
{
    AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}"),
});

RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, credential);
```

See [here](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Device-Code-Flow) for more
information about using device code authentication flow.

#### Interactive authentication with DefaultAzureCredential

Use the `DefaultAzureCredential` object with `includeInteractiveCredentials: true` to use default interactive authentication
flow:

```C# Snippet:CreateAClientWithAzureCredential
TokenCredential credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, credential);
```

#### Authenticating with a static access token

You can pass a Mixed Reality access token as an `AccessToken` previously retrieved from the
[Mixed Reality STS service](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/mixedreality/Azure.MixedReality.Authentication)
to be used with a Mixed Reality client library:

```C# Snippet:CreateAClientWithStaticAccessToken
// GetMixedRealityAccessTokenFromWebService is a hypothetical method that retrieves
// a Mixed Reality access token from a web service. The web service would use the
// MixedRealityStsClient and credentials to obtain an access token to be returned
// to the client.
AccessToken accessToken = GetMixedRealityAccessTokenFromWebService();

RemoteRenderingClient client = new RemoteRenderingClient(remoteRenderingEndpoint, accountId, accountDomain, accessToken);
```

## Key concepts

### RemoteRenderingClient

The `RemoteRenderingClient` is the client library used to access the RemoteRenderingService.
It provides methods to create and manage asset conversions and rendering sessions.

## Examples

- [Convert a simple asset](#convert-a-simple-asset)
- [Convert a more complex asset](#convert-a-more-complex-asset)
- [Get the output when an asset conversion has finished](#get-the-output-when-an-asset-conversion-has-finished)
- [List conversions](#list-conversions)
- [Create a session](#create-a-session)
- [Extend the lease time of a session](#extend-the-lease-time-of-a-session)
- [List sessions](#list-sessions)
- [Stop a session](#stop-a-session)

### Convert a simple asset

We assume that a RemoteRenderingClient has been constructed as described in the [Authenticate the Client](#authenticate-the-client) section.
The following snippet describes how to request that "box.fbx", found at the root of the blob container at the given URI, gets converted.

```C# Snippet:StartAnAssetConversion
AssetConversionInputOptions inputOptions = new AssetConversionInputOptions(storageUri, "box.fbx");
AssetConversionOutputOptions outputOptions = new AssetConversionOutputOptions(storageUri);
AssetConversionOptions conversionOptions = new AssetConversionOptions(inputOptions, outputOptions);

// A randomly generated GUID is a good choice for a conversionId.
string conversionId = Guid.NewGuid().ToString();

AssetConversionOperation conversionOperation = client.StartConversion(conversionId, conversionOptions);
```

The output files will be placed beside the input asset.

### Convert a more complex asset

Assets can reference other files, and blob containers can contain files belonging to many different assets.
In this example, we show how prefixes can be used to organize your blobs and how to convert an asset to take account of that organization.
Assume that the blob container at `inputStorageUri` contains many files, including "Bicycle/bicycle.gltf", "Bicycle/bicycle.bin" and "Bicycle/saddleTexture.jpg".
(So the prefix "Bicycle" is acting very like a folder.)
We want to convert the gltf so that it has access to the other files which share the prefix, without requiring the conversion service to access any other files.
To keep things tidy, we also want the output files to be written to a different storage container and given a common prefix: "ConvertedBicycle".
The code is as follows:

```C# Snippet:StartAComplexAssetConversion
AssetConversionInputOptions inputOptions = new AssetConversionInputOptions(inputStorageUri, "bicycle.gltf")
{
    BlobPrefix = "Bicycle"
};
AssetConversionOutputOptions outputOptions = new AssetConversionOutputOptions(outputStorageUri)
{
    BlobPrefix = "ConvertedBicycle"
};
AssetConversionOptions conversionOptions = new AssetConversionOptions(inputOptions, outputOptions);

string conversionId = Guid.NewGuid().ToString();

AssetConversionOperation conversionOperation = client.StartConversion(conversionId, conversionOptions);
```

> NOTE: when a prefix is given in the input options, then the input file parameter is assumed to be relative to that prefix.
> The same applies to the output file parameter in output options.

### Get the output when an asset conversion has finished

Converting an asset can take anywhere from seconds to hours.
This code uses an existing conversionOperation and polls regularly until the conversion has finished or failed.
The default polling period is 10 seconds.
Note that a conversionOperation can be constructed from the conversionId of an existing conversion and a client.

```C# Snippet:QueryConversionStatus
AssetConversion conversion = conversionOperation.WaitForCompletionAsync().Result;
if (conversion.Status == AssetConversionStatus.Succeeded)
{
    Console.WriteLine($"Conversion succeeded: Output written to {conversion.Output.OutputAssetUri}");
}
else if (conversion.Status == AssetConversionStatus.Failed)
{
    Console.WriteLine($"Conversion failed: {conversion.Error.Code} {conversion.Error.Message}");
}
```

### List conversions

You can get information about your conversions using the `getConversions` method.
This method may return conversions which have yet to start, conversions which are running and conversions which have finished.
In this example, we just list the output URIs of successful conversions started in the last day.

```C# Snippet:GetConversions
foreach (var conversion in client.GetConversions())
{
    if ((conversion.Status == AssetConversionStatus.Succeeded) && (conversion.CreatedOn > DateTimeOffset.Now.AddDays(-1)))
    {
        Console.WriteLine($"output asset URI: {conversion.Output.OutputAssetUri}");
    }
}
```

### Create a session

We assume that a RemoteRenderingClient has been constructed as described in the [Authenticate the Client](#authenticate-the-client) section.
The following snippet describes how to request that a new rendering session be started.

```C# Snippet:CreateASession
RenderingSessionOptions options = new RenderingSessionOptions(TimeSpan.FromMinutes(30), RenderingServerSize.Standard);

// A randomly generated GUID is a good choice for a sessionId.
string sessionId = Guid.NewGuid().ToString();

StartRenderingSessionOperation startSessionOperation = client.StartSession(sessionId, options);

RenderingSession newSession = startSessionOperation.WaitForCompletionAsync().Result;
if (newSession.Status == RenderingSessionStatus.Ready)
{
    Console.WriteLine($"Session {sessionId} is ready.");
}
else if (newSession.Status == RenderingSessionStatus.Error)
{
    Console.WriteLine($"Session {sessionId} encountered an error: {newSession.Error.Code} {newSession.Error.Message}");
}
```

### Extend the lease time of a session

If a session is approaching its maximum lease time, but you want to keep it alive, you will need to make a call to increase
its maximum lease time.
This example shows how to query the current properties and then extend the lease if it will expire soon.

> NOTE: The runtime SDKs also offer this functionality, and in many typical scenarios, you would use them to
> extend the session lease.

```C# Snippet:UpdateSession
RenderingSession currentSession = client.GetSession(sessionId);

if (currentSession.MaxLeaseTime - DateTimeOffset.Now.Subtract(currentSession.CreatedOn.Value) < TimeSpan.FromMinutes(2))
{
    TimeSpan newLeaseTime = currentSession.MaxLeaseTime.Value.Add(TimeSpan.FromMinutes(30));

    UpdateSessionOptions longerLeaseSettings = new UpdateSessionOptions(newLeaseTime);

    client.UpdateSession(sessionId, longerLeaseSettings);
}
```

### List sessions

You can get information about your sessions using the `getSessions` method.
This method may return sessions which have yet to start and sessions which are ready.

```C# Snippet:ListSessions
foreach (var properties in client.GetSessions())
{
    if (properties.Status == RenderingSessionStatus.Starting)
    {
        Console.WriteLine($"Session \"{properties.SessionId}\" is starting.");
    }
    else if (properties.Status == RenderingSessionStatus.Ready)
    {
        Console.WriteLine($"Session \"{properties.SessionId}\" is ready at host {properties.Host}");
    }
}
```

### Stop a session

The following code will stop a running session with given id.

```C# Snippet:StopSession
client.StopSession(sessionId);
```

## Troubleshooting

For general troubleshooting advice concerning Azure Remote Rendering, see [the Troubleshoot page](https://learn.microsoft.com/azure/remote-rendering/resources/troubleshoot) for remote rendering at learn.microsoft.com.

The client methods will throw exceptions if the request cannot be made.
However, in the case of both conversions and sessions, the requests can succeed but the requested operation may not be successful.
In this case, no exception will be thrown, but the returned objects can be inspected to understand what happened.

If the asset in a conversion is invalid, the conversion operation will return an AssetConversion object
with a Failed status and carrying a RemoteRenderingServiceError with details.
Once the conversion service is able to process the file, a &lt;assetName&gt;.result.json file will be written to the output container.
If the input asset is invalid, then that file will contain a more detailed description of the problem.

Similarly, sometimes when a session is requested, the session ends up in an error state.
The startSessionOperation method will return a RenderingSession object, but that object will have an Error status and carry a
RemoteRenderingServiceError with details.

## Next steps

- Read the [Product documentation](https://learn.microsoft.com/azure/remote-rendering/)
- Learn about the runtime SDKs:
  - .NET: https://learn.microsoft.com/dotnet/api/microsoft.azure.remoterendering
  - C++: https://learn.microsoft.com/cpp/api/remote-rendering/

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
