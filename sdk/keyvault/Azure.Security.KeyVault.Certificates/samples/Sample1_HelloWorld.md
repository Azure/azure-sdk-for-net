# Setting, getting, updating, and deleting certificates

This sample demonstrates how to set, get, update, and delete a certificate.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md) for links and instructions.

## Creating a CertificateClient

To create a new `CertificateClient` to create, get, update, or delete certificates, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:CertificatesSample1CertificateClient
CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a certificate

Let's create a self-signed certificate with Subject Alternative Names (SANs) that include DNS names, IP addresses, and URIs.
If the certificate already exists in the Azure Key Vault, then a new version of the key is created.

```C# Snippet:CertificatesSample1CreateCertificate
string certName = $"defaultCert-{Guid.NewGuid()}";

// Create Subject Alternative Names (SANs) with DNS names, IP addresses, and URIs.
var sans = new SubjectAlternativeNames();
sans.DnsNames.Add("sdk.azure-int.net");
sans.IpAddresses.Add("10.0.0.1");
sans.IpAddresses.Add("2001:db8::1");
sans.UniformResourceIdentifiers.Add("https://mydomain.com");

var policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=SelfSignedCert", sans);
CertificateOperation certOp = client.StartCreateCertificate(certName, policy);

while (!certOp.HasCompleted)
{
    certOp.UpdateStatus();

    Thread.Sleep(TimeSpan.FromSeconds(1));
}
```

## Getting a certificate with policy

We can now get the created certificate along with its policy from the Azure Key Vault.

```C# Snippet:CertificatesSample1GetCertificateWithPolicy
Response<KeyVaultCertificateWithPolicy> certificateResponse = client.GetCertificate(certName);
KeyVaultCertificateWithPolicy certificate = certificateResponse.Value;

Debug.WriteLine($"Certificate was returned with name {certificate.Name} which expires {certificate.Properties.ExpiresOn}");
```

## Updating a certificate

We find that the certificate has been compromised and we want to disable it so applications will no longer be able to access the compromised version of the certificate.

```C# Snippet:CertificatesSample1UpdateCertificate
CertificateProperties certificateProperties = certificate.Properties;
certificateProperties.Enabled = false;

Response<KeyVaultCertificate> updatedCertResponse = client.UpdateCertificateProperties(certificateProperties);
Debug.WriteLine($"Certificate enabled set to '{updatedCertResponse.Value.Properties.Enabled}'");
```

## Creating a certificate with a new version

We need to create a new version of the certificate that applications can use to replace the compromised certificate.
We can create a new certificate with the same name and policy as the compromised certificate will create another version of the certificate with similar properties to the original certificate.

```C# Snippet:CertificatesSample1CreateCertificateWithNewVersion
CertificateOperation newCertOp = client.StartCreateCertificate(certificate.Name, certificate.Policy);

while (!newCertOp.HasCompleted)
{
    newCertOp.UpdateStatus();

    Thread.Sleep(TimeSpan.FromSeconds(1));
}
```

## Deleting a certificate

The certificate is no longer needed, so delete it from the Azure Key Vault.

```C# Snippet:CertificatesSample1DeleteCertificate
DeleteCertificateOperation operation = client.StartDeleteCertificate(certName);

// You only need to wait for completion if you want to purge or recover the certificate.
while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
