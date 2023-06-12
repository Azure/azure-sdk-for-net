# Troubleshooting Azure Key Vault Certificates SDK Issues

The `Azure.Security.KeyVault.Certificates` package provides APIs for operations on Azure Key Vault for the
`CertificateClient` class. This troubleshooting guide contains steps for diagnosing issues specific to the
`Azure.Security.KeyVault.Keys` package.

See our [Azure Key Vault SDK Troubleshooting Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/TROUBLESHOOTING.md)
to troubleshoot issues common to the Azure Key Vault SDKs for .NET.

## Table of Contents

* [Troubleshooting Azure.Security.KeyVault.Certificates Issues](#troubleshooting-azuresecuritykeyvaultcertificates-issues)
  * [No Certificate with Private Key Found](#no-certificate-with-private-key-found)

## Troubleshooting Azure.Security.KeyVault.Certificates Issues

### No Certificate with Private Key Found

You may see an error similar to the following when using `CertificateClient.ImportCertificate` or
`CertificateClient.ImportCertificateAsync`:

```text
Azure.RequestFailedException: No certificate with private key found in the specified X.509 certificate content. Please specify X.509 certificate content with only one certificate containing private key.
Status: 400 (Bad Request)
ErrorCode: BadParameter

Content:
{"error":{"code":"BadParameter","message":"No certificate with private key found in the specified X.509 certificate content. Please specify X.509 certificate content with only one certificate containing private key."}}

```

Check that your certificate contains a private key using `X509Certificate2.HasPrivateKey`, for example. If it was `true`
but you still see this error, check that you do not use `X509Certificate2.RawData`, which does not contain the
private key. Instead use `X509Certificate2.Export(X509CertificateType.Pkcs12)` method (inheritted from `X509Certificate`)
to export a PKCS12 (PFX)-encoded buffer. If you want to import a PEM file, read the file into a `byte[]` buffer and call
`CertificateClient.ImportCertificate` or `CertificateClient.ImportCertificateAsync` with the buffer directly.

See [`X509Certificate2` documentation](https://learn.microsoft.com/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)
for more information.
