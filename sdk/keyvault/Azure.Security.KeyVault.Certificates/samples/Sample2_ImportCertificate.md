# Importing PKCS#12 (PFX) and PEM-formatted certificates

This sample demonstrates how to import both PKCS#12 (PFX) and PEM-formatted certificates into Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md) for links and instructions.

## Creating a CertificateClient

To create a new `CertificateClient` to import certificates, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:CertificatesSample3CertificateClient
CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Import a PFX certificate

Assuming you already have a PFX containing your key pair, you can import it into Key Vault.
You can do this without setting a policy, but the policy is needed if you want the private key to be exportable
or to configure actions when a certificate is close to expiration:

```C# Snippet:CertificatesSample3ImportPfxCertificate
string name = $"cert-{Guid.NewGuid()}";
byte[] pfx = File.ReadAllBytes("certificate.pfx");
ImportCertificateOptions importOptions = new ImportCertificateOptions(name, pfx)
{
    Policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=contoso.com")
    {
        // Required when setting a policy; if no policy required, Pfx is assumed.
        ContentType = CertificateContentType.Pkcs12,

        // Optionally mark the private key exportable.
        Exportable = true
    }
};

client.ImportCertificate(importOptions);
```

## Import a PEM-formatted certificate

PEM-formatted certificates are more common when using tools like _openssl_. To import a PEM-formatted certificate,
you must set a `CertificatePolicy` that sets the `ContentType` to `CertificateContentType.Pem` or the certificate
will fail to import:

```C# Snippet:CertificatesSample3ImportPemCertificate
string name = $"cert-{Guid.NewGuid()}";
byte[] pem = File.ReadAllBytes("certificate.cer");
ImportCertificateOptions importOptions = new ImportCertificateOptions(name, pem)
{
    Policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=contoso.com")
    {
        // Required when the certificate bytes are a PEM-formatted certificate.
        ContentType = CertificateContentType.Pem,

        // Optionally mark the private key exportable.
        Exportable = true
    }
};

client.ImportCertificate(importOptions);
```

## Source

To see the full example source, see:

* [Synchronous Sample3_ImportCertificate.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/tests/samples/Sample3_ImportCertificate.cs)
* [Asynchronous Sample3_ImportCertificateAsync.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/tests/samples/Sample3_ImportCertificateAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
