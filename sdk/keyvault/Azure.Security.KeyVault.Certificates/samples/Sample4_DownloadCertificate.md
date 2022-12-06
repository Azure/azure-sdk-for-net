# Download a certificate containing the private key

Though Key Vault recommends you do not download private keys and instead perform all cryptographic operations within Key Vault,
there may be times you need to download both the certificate and private key to create an `X509Certificate2` and use that to
decrypt or sign data in your application.

If you only need a certificate to perform public key operations like encrypting or verifying signatures, you can create
an `X509Certificate2` using the `KeyVaultCertificate.Cer` property. Getting the `KeyVaultCertificate.Cer` property requires
only the certificates/get permission, while downloading the certificate and private key requires both the
certificates/get and secrets/get permissions.

To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md) for links and instructions.

## Creating a CertificateClient

To create a new `CertificateClient` to download certificates, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:CertificatesSample4CertificateClient
CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Download a certificate

Assuming you have already created a certificate you want to download, you can specify it by name and, optionally, a specific version:

```C# Snippet:CertificatesSample4DownloadCertificate
X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.MachineKeySet;
if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    keyStorageFlags |= X509KeyStorageFlags.EphemeralKeySet;
}

DownloadCertificateOptions options = new DownloadCertificateOptions(certificateName)
{
    KeyStorageFlags = keyStorageFlags
};

using X509Certificate2 certificate = client.DownloadCertificate(options);
using RSA key = certificate.GetRSAPrivateKey();

byte[] signature = key.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Debug.WriteLine($"Signature: {Convert.ToBase64String(signature)}");
```

You can optionally pass a `DownloadCertificateOptions` object to customize creation of the `X509Certificate2`. For example,
`X509KeyStorageFlags.EphemeralKeySet | X509KeyStorageFlags.MachineKeySet` is common in applications such as Azure Functions
but will not work in all cases or on all platforms. The default is `X509KeyStorageFlags.DefaultKeySet`. Behavior of the `X509KeyStorageFlags` may
vary across platforms.

### Downloading a certificate asynchronously

You can also do this asynchronously, which is generally recommended for most applications:

```C# Snippet:CertificatesSample4DownloadCertificateAsync
X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.MachineKeySet;
if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    keyStorageFlags |= X509KeyStorageFlags.EphemeralKeySet;
}

DownloadCertificateOptions options = new DownloadCertificateOptions(certificateName)
{
    KeyStorageFlags = keyStorageFlags
};

using X509Certificate2 certificate = await client.DownloadCertificateAsync(options);
using RSA key = certificate.GetRSAPrivateKey();

byte[] signature = key.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Debug.WriteLine($"Signature: {Convert.ToBase64String(signature)}");
```

## Performing public key operations

If you only need to encrypt data or verify signatures, you do not need to download the private key. By keeping the private key
in Key Vault you reduce risk of leaking secret information.

```C# Snippet:CertificatesSample4PublicKey
Response<KeyVaultCertificateWithPolicy> certificateResponse = client.GetCertificate(certificateName);
using X509Certificate2 publicCertificate = new X509Certificate2(certificateResponse.Value.Cer);
using RSA publicKey = publicCertificate.GetRSAPublicKey();

bool verified = publicKey.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
Debug.WriteLine($"Signature verified: {verified}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
