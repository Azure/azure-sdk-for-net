# Using the ClientCertificateCredential

Applications which execute in a protected environment can authenticate using a client assertion signed by a private key whose public key or root certificate is registered with Microsoft Entra ID. The Azure.Identity library provides the `ClientCertificateCredential` for applications choosing to authenticate this way. Below are some examples of how applications can utilize the `ClientCertificateCredential` to authenticate clients.


## Loading certificates from disk

Applications commonly need to load a client certificate from disk. One approach is for the application to construct the `ClientCertificateCredential` by specifying the applications tenant id, client id, and the path to the certificate.

```C# Snippet:Identity_CertificateCredenetial_CreateWithPath
var credential = new ClientCertificateCredential(tenantId, clientId, "./certs/cert.pfx");
```
Alternatively, the application can construct the `X509Certificate2` themselves, such as in the following example, where the certificate key is password protected.

```C# Snippet:Identity_CertificateCredenetial_CreateWithX509Cert
var certificate = new X509Certificate2("./certs/cert-password-protected.pfx", "password");

var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
```

## Loading certificates from an X509Store

Applications running on platforms which provide a secure certificate store might prefer to store and retrieve certificates from there. While the `ClientCertificateCredential` doesn't directly provide a mechanism for this, the application can retrieve the appropriate certificate from the store and use it to construct the `ClientCertificateCredential`.

Consider the scenario where a pinned certificate used for development authentication is stored in the Personal certificate store. Since the certificate is pinned it can be identified by its thumbprint, which the application might read from configuration or the environment.

```C# Snippet:Identity_CertificateCredenetial_CreateFromStore
using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

store.Open(OpenFlags.ReadOnly);

var certificate = store.Certificates.Cast<X509Certificate2>().FirstOrDefault(cert => cert.Thumbprint == thumbprint);

var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
```

## Rolling Certificates

Long running applications may have the need to roll certificates during process execution. Certificate rotation is not currently supported by the `ClientCertificateCredential` which treats the certificate used to construct the credential as immutable. This means that any clients constructed with an `ClientCertificateCredential` using a particular cert would fail to authenticate requests after that cert has been rolled and the original is no longer valid.

However, if an application wants to roll this certificate without creating new service clients, it can accomplish this by creating its own `TokenCredential` implementation which wraps the `ClientCertificateCredential`. The implementation of this custom credential `TokenCredential` would somewhat depend on how the application handles certificate rotation.

### Explicit rotation

If the application get's notified of certificate rotations and it can directly respond, it might choose to wrap the `ClientCertificateCredential` in a custom credential which provides a means for rotating the certificate.

```C# Snippet:Identity_CertificateCredenetial_RotatableCredential
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

```C# Snippet:Identity_CertificateCredenetial_RotatingCredential
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
