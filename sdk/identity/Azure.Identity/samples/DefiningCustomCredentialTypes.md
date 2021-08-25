# Defining Custom Credential types
The Azure.Identity library covers a broad range of Azure Active Directory authentication scenarios. However, it's possible the credential implementations in Azure.Identity might not meet the specific needs your application, or an application might want to avoid taking a dependency on the Azure.Identity library.

## Authenticating with a prefetched access token
The Azure.Identity library does not contain a `TokenCredential` implementation which can be constructed directly with an `AccessToken`. This is intentionally omitted as a main line scenario as access tokens expire frequently and have constrained usage. However, there are some scenarios where authenticating a service client with a prefetched token is necessary.

In this example `StaticTokenCredential` implements the `TokenCredential` abstraction. It takes a prefetched access token in its constructor as a `string` or `AccessToken`, and simply returns that from its implementation of `GetToken` and `GetTokenAsync`.

```C# Snippet:StaticTokenCredential
public class StaticTokenCredential : TokenCredential
{
    private AccessToken _token;

    public StaticTokenCredential(string token) : this(new AccessToken(token, DateTimeOffset.MinValue)) { }

    public StaticTokenCredential(AccessToken token)
    {
        _token = token;
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return _token;
    }

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return new ValueTask<AccessToken>(_token);
    }
}
```

Once the application has defined this credential type instances of it can be used to authenticate Azure SDK clients. The following example shows an how an application already using some other mechanism for acquiring tokens (in this case the hypothetical method `AquireTokenForScope`) could use the `StaticTokenCredential` to authenticate a `BlobClient`.

```C# Snippet:StaticTokenCredentialUsage
string token = GetTokenForScope("https://storage.azure.com/.default");

var credential = new StaticTokenCredential(token);

var client = new BlobClient(new Uri("https://aka.ms/bloburl"), credential);
```

It should be noted when using this custom credential type, it is the responsibility of the caller to ensure that the token is valid, and contains the correct claims needed to authenticate calls from the particular service client. For instance in the above case the token must have the scope "https://storage.azure.com/.default" to authorize calls to Azure Blob Storage.

## Authenticating with MSAL Directly

Some applications already use the MSAL library's `IConfidentialClientApplication` or `IPublicClientApplication` to authenticate portions of their application. In these cases the application might want to use the same to authenticate Azure SDK clients so to take advantage of token caching the client application is doing and prevent unnecessary authentication calls or user prompting.

### Authenticating with the Confidential Client

In this example the `ConfidentialClientApplicationCredential` is constructed with an instance of `IConfidentialClientApplication` it then implements `GetToken` and `GetTokenAsync` using the `AcquireTokenForClient` method to acquire a token.

```C# Snippet:ConfidentialClientCredential
public class ConfidentialClientCredential : TokenCredential
{
    private readonly IConfidentialClientApplication _confidentialClient;

    public ConfidentialClientCredential(IConfidentialClientApplication confidentialClient)
    {
        _confidentialClient = confidentialClient;
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
    }

    public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        AuthenticationResult result = await _confidentialClient.AcquireTokenForClient(requestContext.Scopes).ExecuteAsync();

        return new AccessToken(result.AccessToken, result.ExpiresOn);
    }
}
```

The users could then use the `ConfidentialClientApplicationCredential` be used to authenticate a `BlobClient` with an `IConfidentialClientApplication` it has created to authenticate non Azure SDK calls.

```C# Snippet:ConfidentialClientCredentialUsage
IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder.Create(clientId).WithClientSecret(clientSecret).Build();

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), new ConfidentialClientCredential(confidentialClient));
```

## Authenticating with the On Behalf Of Flow
Currently the Azure.Identity library doesn't provide a credential type for clients which need to authenticate via the On Behalf Of flow. While future support for this is planned, users requiring this immediately will have to implement their own `TokenCredential` class.

In this example the `OnBehalfOfCredential` accepts a client id, client secret, and a user's access token. It then creates an instance of `IConfidentialClientApplication` from the Microsoft.Identity.Client library (MSAL) to obtain an OBO token which can be used to authenticate client requests.

```C# Snippet:OnBehalfOfCredential
public class OnBehalfOfCredential : TokenCredential
{
    private readonly IConfidentialClientApplication _confidentialClient;
    private readonly UserAssertion _userAssertion;

    public OnBehalfOfCredential(string clientId, string clientSecret, string userAccessToken)
    {
        _confidentialClient = ConfidentialClientApplicationBuilder.Create(clientId).WithClientSecret(clientSecret).Build();

        _userAssertion = new UserAssertion(userAccessToken);
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
    }

    public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        AuthenticationResult result = await _confidentialClient.AcquireTokenOnBehalfOf(requestContext.Scopes, _userAssertion).ExecuteAsync();

        return new AccessToken(result.AccessToken, result.ExpiresOn);
    }
}
```
The following example shows an how the `OnBehalfOfCredential` could be used to authenticate a `SecretClient`.


```C# Snippet:OnBehalfOfCredentialUsage
var oboCredential = new OnBehalfOfCredential(clientId, clientSecret, userAccessToken);

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), oboCredential);
```