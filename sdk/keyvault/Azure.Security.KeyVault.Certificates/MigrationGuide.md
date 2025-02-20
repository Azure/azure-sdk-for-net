# Migrate from Microsoft.Azure.KeyVault to Azure.Security.KeyVault.Certificates

This guide is intended to assist in the migration to version 4 of the Key Vault client library [`Azure.Security.KeyVault.Certificates`](https://www.nuget.org/packages/Azure.Security.KeyVault.Certificates) from [deprecated] version 3 of [`Microsoft.Azure.KeyVault`](https://www.nuget.org/packages/Microsoft.Azure.KeyVault). It will focus on side-by-side comparisons for similar operations between the two packages.

Familiarity with the `Microsoft.Azure.KeyVault` library is assumed. For those new to the Key Vault client library for .NET, please refer to the [`Azure.Security.KeyVault.Certificates` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md) and [`Azure.Security.KeyVault.Certificates` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/samples) for the `Azure.Security.KeyVault.Certificates` library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Separate clients](#separate-clients)
  - [Client constructors](#client-constructors)
  - [Creating certificate policies](#creating-certificate-policies)
  - [Creating certificates](#creating-certificates)
  - [Importing certificates](#importing-certificates)
  - [Listing certificates](#listing-certificates)
  - [Deleting certificates](#deleting-certificates)
- [Additional samples](#additional-samples)
- [Support](#support)

## Migration benefits

> Note: `Microsoft.Azure.KeyVault` has been [deprecated]. Please upgrade to `Azure.Security.KeyVault.Certificates` for continued support.

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Key Vault, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Key Vault certificates library `Azure.Security.KeyVault.Certificates` provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Services]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Key Vault, the modern client libraries have packages and namespaces that begin with `Azure.Security.KeyVault` and were released beginning with version 4. The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.KeyVault` and a version of 3.x.x or below.

### Separate clients

In the interest of simplifying the API we've split `KeyVaultClient` into separate packages and clients:

- `Azure.Security.KeyVault.Certificates` contains `CertificateClient` for working with certificates.
- `Azure.Security.KeyVault.Keys` contains `KeyClient` for working with keys and `CryptographyClient` for performing cryptographic operations.
- `Azure.Security.KeyVault.Secrets` contains `SecretClient` for working with secrets.

These clients also share a single connection pool by default despite being separated, resolving an issue with the old `KeyVaultClient` that created a new connection pool with each new instance and could exhaust socket connections.

### Client constructors

Across all new Azure client libraries, clients consistently take an endpoint or connection string along with token credentials. This differs from `KeyVaultClient` that took an authentication delegate and could be used for multiple Key Vault endpoints.

#### Authenticating

Previously in `Microsoft.Azure.KeyVault`, you could create a `KeyVaultClient` along with the `AzureServiceTokenProvider` from the package `Microsoft.Azure.Services.AppAuthentication`:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_Create
AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
KeyVaultClient client = new KeyVaultClient(
    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
```

Now in `Azure.Security.KeyVault.Certificates`, you create a `CertificateClient` along with the `DefaultAzureCredential` from the package `Azure.Identity`:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_Create
CertificateClient client = new CertificateClient(
    new Uri("https://myvault.vault.azure.net"),
    new DefaultAzureCredential());
```

[`DefaultAzureCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential) is optimized for both production and development environments without having to change your source code.

#### Sharing an HttpClient

In `Microsoft.Azure.KeyVault` with `KeyVaultClient`, a new `HttpClient` was created with each instance but could be shared to prevent connection starvation:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions
using (HttpClient httpClient = new HttpClient())
{
    AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
    KeyVaultClient client = new KeyVaultClient(
        new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
        httpClient);
}
```

In `Azure.Security.KeyVault.Certificates` by default, all client libraries built on `Azure.Core` that communicate over HTTP share a single `HttpClient`. If you want to share an your own `HttpClient` instance with Azure client libraries and other clients you use or implement in your projects, you can pass it via `CertificateClientOptions`:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateWithOptions
using (HttpClient httpClient = new HttpClient())
{
    CertificateClientOptions options = new CertificateClientOptions
    {
        Transport = new HttpClientTransport(httpClient)
    };

    CertificateClient client = new CertificateClient(
        new Uri("https://myvault.vault.azure.net"),
        new DefaultAzureCredential(),
        options);
}
```

[`ClientOptions`](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-usage-options) classes are another common feature of Azure client libraries to configure clients, including diagnostics, retry options, and transport options including your pipeline policies.

### Creating certificate policies

Before creating or importing a certificate, you need to define a certificate policy that defines the subject (e.g. web site, email address), lifetime management properties, and [more](https://learn.microsoft.com/azure/key-vault/certificates/about-certificates#certificate-policy). You can define your own policy or, as is common in testing applications, use a self-signed certificate policy.

#### Custom policy

Previously in `Microsoft.Azure.KeyVault`, you could create a custom policy if you also knew all the various string values you needed:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateCustomPolicy
CertificatePolicy policy = new CertificatePolicy
{
    IssuerParameters = new IssuerParameters("issuer-name"),
    SecretProperties = new SecretProperties("application/x-pkcs12"),
    KeyProperties = new KeyProperties
    {
        KeyType = "RSA",
        KeySize = 2048,
        ReuseKey = true
    },
    X509CertificateProperties = new X509CertificateProperties("CN=customdomain.com")
    {
        KeyUsage = new[]
        {
          KeyUsageType.CRLSign,
          KeyUsageType.DataEncipherment,
          KeyUsageType.DigitalSignature,
          KeyUsageType.KeyEncipherment,
          KeyUsageType.KeyAgreement,
          KeyUsageType.KeyCertSign
        },
        ValidityInMonths = 12
    },
    LifetimeActions = new[]
    {
        new LifetimeAction(
            new Trigger
            {
                DaysBeforeExpiry = 90
            },
            new Models.Action(ActionType.AutoRenew))
    }
};
```

Now in `Azure.Security.KeyVault.Certificates`, you can create a custom policy using more enumerations and less code:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateCustomPolicy
CertificatePolicy policy = new CertificatePolicy("issuer-name", "CN=customdomain.com")
{
    ContentType = CertificateContentType.Pkcs12,
    KeyType = CertificateKeyType.Rsa,
    ReuseKey = true,
    KeyUsage =
    {
        CertificateKeyUsage.CrlSign,
        CertificateKeyUsage.DataEncipherment,
        CertificateKeyUsage.DigitalSignature,
        CertificateKeyUsage.KeyEncipherment,
        CertificateKeyUsage.KeyAgreement,
        CertificateKeyUsage.KeyCertSign
    },
    ValidityInMonths = 12,
    LifetimeActions =
    {
        new LifetimeAction(CertificatePolicyAction.AutoRenew)
        {
            DaysBeforeExpiry = 90,
        }
    }
};
```

#### Self-signed policy

Previously in `Microsoft.Azure.KeyVault`, you could create a self-signed policy much like a custom policy but with the right value for the issuer name:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
CertificatePolicy policy = new CertificatePolicy
{
    IssuerParameters = new IssuerParameters("Self"),
    X509CertificateProperties = new X509CertificateProperties("CN=DefaultPolicy")
};
```

Now in `Azure.Security.KeyVault.Certificates`, you can get a copy of the default policy simply:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateSelfSignedPolicy
CertificatePolicy policy = CertificatePolicy.Default;
```

### Creating certificates

Previously in `Microsoft.Azure.KeyVault`, you could create a certificate and poll for status using the `KeyVaultClient`, a specific key Vault endpoint, and a certificate policy you created earlier:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_CreateCertificate
CertificateBundle certificate = null;

// Start certificate creation.
// Depending on the policy and your business process, this could even take days for manual signing.
CertificateOperation createOperation = await client.CreateCertificateAsync("https://myvault.vault.azure.net", "certificate-name", policy);
while (true)
{
    if ("InProgress".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
    {
        await Task.Delay(TimeSpan.FromSeconds(20));

        createOperation = await client.GetCertificateOperationAsync("https://myvault.vault.azure.net", "certificate-name");
        continue;
    }

    if ("Completed".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
    {
        certificate = await client.GetCertificateAsync(createOperation.Id);
        break;
    }

    throw new Exception(string.Format(
        CultureInfo.InvariantCulture,
        "Polling on pending certificate returned an unexpected result. Error code = {0}, Error message = {1}",
        createOperation.Error.Code,
        createOperation.Error.Message));
}

// If you need to restart the application you can recreate the operation and continue awaiting.
do
{
    createOperation = await client.GetCertificateOperationAsync("https://myvault.vault.azure.net", "certificate-name");

    if ("InProgress".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
    {
        await Task.Delay(TimeSpan.FromSeconds(20));
        continue;
    }

    if ("Completed".Equals(createOperation.Status, StringComparison.OrdinalIgnoreCase))
    {
        certificate = await client.GetCertificateAsync(createOperation.Id);
        break;
    }

    throw new Exception(string.Format(
        CultureInfo.InvariantCulture,
        "Polling on pending certificate returned an unexpected result. Error code = {0}, Error message = {1}",
        createOperation.Error.Code,
        createOperation.Error.Message));
} while (true);
```

Now in `Azure.Security.KeyVault.Certificates`, you can create a certificate and await or poll status on an operation to complete:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_CreateCertificate
// Start certificate creation.
// Depending on the policy and your business process, this could even take days for manual signing.
CertificateOperation createOperation = await client.StartCreateCertificateAsync("certificate-name", policy);
KeyVaultCertificateWithPolicy certificate = await createOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(20), CancellationToken.None);

// If you need to restart the application you can recreate the operation and continue awaiting.
createOperation = new CertificateOperation(client, "certificate-name");
certificate = await createOperation.WaitForCompletionAsync(TimeSpan.FromSeconds(20), CancellationToken.None);
```

Synchronous methods are also available on `CertificateClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Importing certificates

Previously in `Microsoft.Azure.KeyVault`, you could import a certificate and poll for status using the `KeyVaultClient`, a specific key Vault endpoint, and a certificate policy you created earlier:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_ImportCertificate
byte[] cer = File.ReadAllBytes("certificate.pfx");
string cerBase64 = Convert.ToBase64String(cer);

CertificateBundle certificate = await client.ImportCertificateAsync(
    "https://myvault.vault.azure.net",
    "certificate-name",
    cerBase64,
    certificatePolicy: policy);
```

Now in `Azure.Security.KeyVault.Certificates`, you can import a certificate and await or poll status on an operation to complete:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_ImportCertificate
byte[] cer = File.ReadAllBytes("certificate.pfx");
ImportCertificateOptions importCertificateOptions = new ImportCertificateOptions("certificate-name", cer)
{
    Policy = policy
};

KeyVaultCertificateWithPolicy certificate = await client.ImportCertificateAsync(importCertificateOptions);
```

Synchronous methods are also available on `CertificateClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Listing certificates

Previously in `Microsoft.Azure.KeyVault`, you could list certificates' properties using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_ListCertificates
IPage<CertificateItem> page = await client.GetCertificatesAsync("https://myvault.vault.azure.net");
foreach (CertificateItem item in page)
{
    CertificateIdentifier certificateId = item.Identifier;
    CertificateBundle certificate = await client.GetCertificateAsync(certificateId.Vault, certificateId.Name);
}

while (page.NextPageLink != null)
{
    page = await client.GetCertificatesNextAsync(page.NextPageLink);
    foreach (CertificateItem item in page)
    {
        CertificateIdentifier certificateId = item.Identifier;
        CertificateBundle certificate = await client.GetCertificateAsync(certificateId.Vault, certificateId.Name);
    }
}
```

Now in `Azure.Security.KeyVault.Certificates`, you list certificates' properties in the Key Vault you specified when constructing the `CertificateClient`. This returns an enumerable that enumerates all certificates across any number of pages. If you want to enumerate pages, call the `AsPages` method on the returned enumerable.

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_ListCertificates
// List all certificates asynchronously.
await foreach (CertificateProperties item in client.GetPropertiesOfCertificatesAsync())
{
    KeyVaultCertificateWithPolicy certificate = await client.GetCertificateAsync(item.Name);
}

// List all certificates synchronously.
foreach (CertificateProperties item in client.GetPropertiesOfCertificates())
{
    KeyVaultCertificateWithPolicy certificate = client.GetCertificate(item.Name);
}
```

### Deleting certificates

Previously in `Microsoft.Azure.KeyVault`, you could delete a certificate using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Certificates_Snippets_MigrationGuide_DeleteCertificate
// Delete the certificate.
DeletedCertificateBundle deletedCertificate = await client.DeleteCertificateAsync("https://myvault.vault.azure.net", "certificate-name");

// Purge or recover the deleted certificate if soft delete is enabled.
if (deletedCertificate.RecoveryId != null)
{
    DeletedCertificateIdentifier deletedCertificateId = deletedCertificate.RecoveryIdentifier;

    // Deleting a certificate does not happen immediately. Wait a while and check if the deleted certificate exists.
    while (true)
    {
        try
        {
            await client.GetDeletedCertificateAsync(deletedCertificateId.Vault, deletedCertificateId.Name);

            // Finally deleted.
            break;
        }
        catch (KeyVaultErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
        {
            // Not yet deleted...
        }
    }

    // Purge the deleted certificate.
    await client.PurgeDeletedCertificateAsync(deletedCertificateId.Vault, deletedCertificateId.Name);

    // You can also recover the deleted certificate using RecoverDeletedCertificateAsync.
}
```

Now in `Azure.Security.KeyVault.Certificates`, you delete a certificate in the Key Vault you specified when constructing the `CertificateClient` and succinctly await or poll status on an operation to complete:

```C# Snippet:Azure_Security_KeyVault_Certificates_Snippets_MigrationGuide_DeleteCertificate
// Delete the certificate.
DeleteCertificateOperation deleteOperation = await client.StartDeleteCertificateAsync("certificate-name");

// Purge or recover the deleted certificate if soft delete is enabled.
if (deleteOperation.Value.RecoveryId != null)
{
    // Deleting a certificate does not happen immediately. Wait for the certificate to be deleted.
    DeletedCertificate deletedCertificate = await deleteOperation.WaitForCompletionAsync();

    // Purge the deleted certificate.
    await client.PurgeDeletedCertificateAsync(deletedCertificate.Name);

    // You can also recover the deleted certificate using StartRecoverDeletedCertificateAsync,
    // which returns RecoverDeletedCertificateOperation you can await like DeleteCertificateOperation above.
}
```

Synchronous methods are also available on `CertificateClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

## Additional samples

- [Key Vault certificates samples for .NET](https://learn.microsoft.com/samples/azure/azure-sdk-for-net/azuresecuritykeyvaultcertificates-samples/)
- [All Key Vault samples for .NET](https://learn.microsoft.com/samples/browse/?products=azure-key-vault&languages=csharp)

## Support

If you have migrated your code base and are experiencing errors, see our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/TROUBLESHOOTING.md).
For additional support, please search our [existing issues](https://github.com/Azure/azure-sdk-for-net/issues) or [open a new issue](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
You may also find existing answers on community sites like [Stack Overflow](https://stackoverflow.com/questions/tagged/azure-keyvault+.net).

[deprecated]: https://aka.ms/azsdk/deprecated
