# Listing certificates, certificate versions, and deleted certificates

This sample demonstrates how to list certificates, versions of given certificates, and list deleted certificates in a soft delete-enabled Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](../README.md) for links and instructions.

## Creating a CertificateClient

To create a new `CertificateClient` to create, get, update, or delete certificates, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:CertificatesSample2CertificateClient
var client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating certificates

Let's create two self-signed certificates using the default policy.

```C# Snippet:CertificatesSample2CreateCertificate
string certName1 = $"defaultCert-{Guid.NewGuid()}";
CertificateOperation certOp1 = client.StartCreateCertificate(certName1, CertificatePolicy.Default);

string certName2 = $"defaultCert-{Guid.NewGuid()}";
CertificateOperation certOp2 = client.StartCreateCertificate(certName2, CertificatePolicy.Default);

while (!certOp1.HasCompleted)
{
    certOp1.UpdateStatus();

    Thread.Sleep(TimeSpan.FromSeconds(1));
}

while (!certOp2.HasCompleted)
{
    certOp2.UpdateStatus();

    Thread.Sleep(TimeSpan.FromSeconds(1));
}
```

## Listing certificates

Let's list the certificates which exist in the vault along with their thumbprints.

```C# Snippet:CertificatesSample2ListCertificates
foreach (CertificateProperties cert in client.GetPropertiesOfCertificates())
{
    Debug.WriteLine($"Certificate is returned with name {cert.Name} and thumbprint {BitConverter.ToString(cert.X509Thumbprint)}");
}
```

## Creating a certificate with a new version

We need to create a new version of a certificate. Creating a certificate with the same name will create another version of the certificate.

```C# Snippet:CertificatesSample2CreateCertificateWithNewVersion
CertificateOperation newCertOp = client.StartCreateCertificate(certName1, CertificatePolicy.Default);

while (!newCertOp.HasCompleted)
{
    newCertOp.UpdateStatus();

    Thread.Sleep(TimeSpan.FromSeconds(1));
}
```

## Listing certificate versions

Let's print all the versions of this certificate.

```C# Snippet:CertificatesSample2ListCertificateVersions
foreach (CertificateProperties cert in client.GetPropertiesOfCertificateVersions(certName1))
{
    Debug.WriteLine($"Certificate {cert.Name} with name {cert.Version}");
}
```

## Deleting certificates

The certificates are no longer needed.
You need to delete them from the Azure Key Vault.

```C# Snippet:CertificatesSample2DeleteCertificates
DeleteCertificateOperation operation1 = client.StartDeleteCertificate(certName1);
DeleteCertificateOperation operation2 = client.StartDeleteCertificate(certName2);

// To ensure certificates are deleted on server side.
// You only need to wait for completion if you want to purge or recover the certificate.
while (!operation1.HasCompleted || !operation2.HasCompleted)
{
    Thread.Sleep(2000);

    operation1.UpdateStatus();
    operation2.UpdateStatus();
}
```

## Listing deleted certificates

You can list all the deleted and non-purged certificates, assuming Azure Key Vault is soft delete-enabled.

```C# Snippet:CertificatesSample2ListDeletedCertificates
foreach (DeletedCertificate deletedCert in client.GetDeletedCertificates())
{
    Debug.WriteLine($"Deleted certificate's recovery Id {deletedCert.RecoveryId}");
}
```

## Source

To see the full example source, see:

* [Synchronous Sample2_GetCertificates.cs](../tests/samples/Sample2_GetCertificates.cs)
* [Asynchronous Sample2_GetCertificatesAsync.cs](../tests/samples/Sample2_GetCertificatesAsync.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md
