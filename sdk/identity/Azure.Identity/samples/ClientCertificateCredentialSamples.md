# Using the ClientCertificateCredential

Applications which execute in a protected environment can authenticate using a client assertion signed by a private key whose public key or root certificate is registered with Microsoft Entra ID. The Azure.Identity library provides the [`ClientCertificateCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.clientcertificatecredential) for applications choosing to authenticate this way. Below are some examples of how applications can utilize `ClientCertificateCredential` to authenticate clients.

`ClientCertificateCredential` can also be used via [`EnvironmentCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.environmentcredential), or [`DefaultAzureCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential) - see [README#credential-classes](https://github.com/azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credential-classes).

## Loading certificates from disk

Applications commonly need to load a client certificate from disk. One approach is for the application to construct the `ClientCertificateCredential` by specifying the application's tenant ID, client ID, and filesystem path to the certificate.

```C# Snippet:Identity_CertificateCredential_CreateWithPath_File
var credential = new ClientCertificateCredential(tenantId, clientId, "./certs/cert.pfx");
```

Alternatively, the application can construct the [`X509Certificate2`](https://learn.microsoft.com/dotnet/api/system.security.cryptography.x509certificates.x509certificate2) themselves, such as in the following example, where the certificate key is password protected.

```C# Snippet:Identity_CertificateCredential_CreateWithX509Cert
var certificate = new X509Certificate2("./certs/cert-password-protected.pfx", "password");

var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
```

## Loading certificates from the certificate store

`ClientCertificateCredential` supports loading a certificate directly from the platform certificate store by specifying a path in the form `cert:/StoreLocation/StoreName/Thumbprint`. This is a simpler alternative to manually opening an `X509Store`.

> [!Important]
> Password-protected certificates cannot be loaded from the certificate store using this method.

```C# Snippet:Identity_CertificateCredential_CreateWithStorePath
// Load a certificate from the platform certificate store (Windows Certificate Store or macOS Keychain)
// by specifying the path in the format: cert:/StoreLocation/StoreName/Thumbprint
// Windows-style backslash separators `\` are also accepted
var credential = new ClientCertificateCredential(
    tenantId,
    clientId,
    "cert:/CurrentUser/My/E661583E8FABEF4C0BEF694CBC41C28FB81CD870");
```

## Rolling Certificates

Long running applications may have the need to roll certificates during process execution. Certificate rotation is not currently supported by the `ClientCertificateCredential` which treats the certificate used to construct the credential as immutable. This means that any clients constructed with an `ClientCertificateCredential` using a particular cert would fail to authenticate requests after that cert has been rolled and the original is no longer valid.

However, if an application wants to roll this certificate without creating new service clients, it can accomplish this by creating its own `TokenCredential` implementation which wraps the `ClientCertificateCredential`. The implementation of this custom credential `TokenCredential` would somewhat depend on how the application handles certificate rotation.

### Explicit rotation

If the application get's notified of certificate rotations and it can directly respond, it might choose to wrap the `ClientCertificateCredential` in a custom credential which provides a means for rotating the certificate.

```C# Snippet:Identity_CertificateCredential_RotatableCredential
public class RotatableCertificateCredential : TokenCredential
{
    private readonly string _tenantId;
    private readonly string _clientId;
    private ClientCertificateCredential _credential;

    public RotatableCertificateCredential(string tenantId, string clientId, X509Certificate2 certificate)
    {
        _tenantId = tenantId;
        _clientId = clientId;
        _credential = new ClientCertificateCredential(_tenantId, _clientId, certificate);
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return _credential.GetToken(requestContext, cancellationToken);
    }

    public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return await _credential.GetTokenAsync(requestContext, cancellationToken);
    }

    public void RotateCertificate(X509Certificate2 certificate)
    {
        _credential = new ClientCertificateCredential(_tenantId, _clientId, certificate);
    }
}
```

The above example shows a custom credential type `RotatableCertificateCredential` which provides a `RotateCertificateMethod`. The implementation internally relies on a `ClientCertificateCredential` instance `_credential`, and `RotateCertificate` simply replaces this instance with a new instance using the updated certificate.

### Implicit rotation
Some applications might want to respond to certificate rotations which are external to the application, for instance a separate process rotates the certificate by updating it on disk. Here the application create a custom credential which checks for certificate updates when tokens are requested.

```C# Snippet:Identity_CertificateCredential_RotatingCredential
public class RotatingCertificateCredential : TokenCredential
{
    private readonly string _tenantId;
    private readonly string _clientId;
    private readonly string _path;
    private readonly object _refreshLock = new object();
    private DateTimeOffset _credentialLastModified;
    private ClientCertificateCredential _credential;

    public RotatingCertificateCredential(string tenantId, string clientId, string path)
    {
        _tenantId = tenantId;
        _clientId = clientId;
        _path = path;

        RefreshCertificate();
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        RefreshCertificate();

        return _credential.GetToken(requestContext, cancellationToken);
    }

    public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        RefreshCertificate();

        return await _credential.GetTokenAsync(requestContext, cancellationToken);
    }

    public void RefreshCertificate()
    {
        lock (_refreshLock)
        {
            var certificateLastModified = File.GetLastWriteTimeUtc(_path);

            if (_credentialLastModified < certificateLastModified)
            {
                var certificate = new X509Certificate2(_path);
                _credential = new ClientCertificateCredential(_tenantId, _clientId, certificate);

                _credentialLastModified = certificateLastModified;
            }
        }
    }
}
```

In this example the custom credential type `RotatingCertificateCredential` again uses a `ClientCertificateCredential` instance `_credential` to retrieve tokens. However, in this case it will attempt to refresh the certificate prior to obtaining the token. The method `RefreshCertificate` will query to see if the certificate has changed, and if so it will replace the instance `_credential` with a new instance using the new certificate.
