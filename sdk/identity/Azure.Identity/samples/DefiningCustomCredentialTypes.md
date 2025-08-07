# Defining Custom Credential types
The Azure.Identity library covers a broad range of Microsoft Entra authentication scenarios. However, it's possible the credential implementations in Azure.Identity might not meet the specific needs your application, or an application might want to avoid taking a dependency on the Azure.Identity library.

## Authenticating with a prefetched access token

For scenarios where you need to authenticate with a prefetched access token, the `TokenCredential.Create` static method is available.

The following example shows an how an application already using some other mechanism for acquiring tokens (in this case the hypothetical method `AquireTokenForScope`) could use the `TokenCredential.Create` to authenticate a `BlobClient`.

```C# Snippet:TokenCredentialCreateUsage
AccessToken token = GetTokenForScope("https://storage.azure.com/.default");

var credential = DelegatedTokenCredential.Create((_, _) => token);

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
