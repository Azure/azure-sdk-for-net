# Migrate from Microsoft.Azure.KeyVault to Azure.Security.KeyVault.Secrets

This guide is intended to assist in the migration to version 4 of the Key Vault client library [`Azure.Security.KeyVault.Secrets`](https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets) from [deprecated] version 3 of [`Microsoft.Azure.KeyVault`](https://www.nuget.org/packages/Microsoft.Azure.KeyVault). It will focus on side-by-side comparisons for similar operations between the two packages.

Familiarity with the `Microsoft.Azure.KeyVault` library is assumed. For those new to the Key Vault client library for .NET, please refer to the [`Azure.Security.KeyVault.Secrets` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md) and [`Azure.Security.KeyVault.Secrets` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples) for the `Azure.Security.KeyVault.Secrets` library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Separate clients](#separate-clients)
  - [Client constructors](#client-constructors)
  - [Setting secrets](#setting-secrets)
  - [Getting secrets](#getting-secrets)
  - [Listing secrets](#listing-secrets)
  - [Listing secret versions](#listing-secret-versions)
  - [Deleting secrets](#deleting-secrets)
  - [Managing shared access signatures](#managing-shared-access-signatures)
- [Additional samples](#additional-samples)
- [Support](#support)

## Migration benefits

> Note: `Microsoft.Azure.KeyVault` has been [deprecated]. Please upgrade to `Azure.Security.KeyVault.Secrets` for continued support.

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Key Vault, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Key Vault secrets library `Azure.Security.KeyVault.Secrets` provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries.

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

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_Create
AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
KeyVaultClient client = new KeyVaultClient(
    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
```

Now in `Azure.Security.KeyVault.Secrets`, you create a `SecretClient` along with the `DefaultAzureCredential` from the package `Azure.Identity`:

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_Create
SecretClient client = new SecretClient(
    new Uri("https://myvault.vault.azure.net"),
    new DefaultAzureCredential());
```

[`DefaultAzureCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential) is optimized for both production and development environments without having to change your source code.

#### Sharing an HttpClient

In `Microsoft.Azure.KeyVault` with `KeyVaultClient`, a new `HttpClient` was created with each instance but could be shared to prevent connection starvation:

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_CreateWithOptions
using (HttpClient httpClient = new HttpClient())
{
    AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
    KeyVaultClient client = new KeyVaultClient(
        new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
        httpClient);
}
```

In `Azure.Security.KeyVault.Secrets` by default, all client libraries built on `Azure.Core` that communicate over HTTP share a single `HttpClient`. If you want to share an your own `HttpClient` instance with Azure client libraries and other clients you use or implement in your projects, you can pass it via `SecretClientOptions`:

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_CreateWithOptions
using (HttpClient httpClient = new HttpClient())
{
    SecretClientOptions options = new SecretClientOptions
    {
        Transport = new HttpClientTransport(httpClient)
    };

    SecretClient client = new SecretClient(
        new Uri("https://myvault.vault.azure.net"),
        new DefaultAzureCredential(),
        options);
}
```

[`ClientOptions`](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-usage-options) classes are another common feature of Azure client libraries to configure clients, including diagnostics, retry options, and transport options including your pipeline policies.

### Setting secrets

Previously in `Microsoft.Azure.KeyVault`, you could set a secret value using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_SetSecret
SecretBundle secret = await client.SetSecretAsync("https://myvault.vault.azure.net", "secret-name", "secret-value");
```

Now in `Azure.Security.KeyVault.Secrets`, you set a secret value in the Key Vault you specified when constructing the `SecretClient`:

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_SetSecret
KeyVaultSecret secret = await client.SetSecretAsync("secret-name", "secret-value");
```

Setting an existing secret in both cases will create a new version of the secret.

Synchronous methods are also available on `SecretClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Getting secrets

Previously in `Microsoft.Azure.KeyVault`, you could get a secret value using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_GetSecret
// Get the latest secret value.
SecretBundle secret = await client.GetSecretAsync("https://myvault.vault.azure.net", "secret-name", null);

// Get a specific secret value.
SecretBundle secretVersion = await client.GetSecretAsync("https://myvault.vault.azure.net", "secret-name", "e43af03a7cbc47d4a4e9f11540186048");
```

Now in `Azure.Security.KeyVault.Secrets`, you get a secret value in the Key Vault you specified when constructing the `SecretClient`:

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_GetSecret
// Get the latest secret value.
KeyVaultSecret secret = await client.GetSecretAsync("secret-name");

// Get a specific secret value.
KeyVaultSecret secretVersion = await client.GetSecretAsync("secret-name", "e43af03a7cbc47d4a4e9f11540186048");
```

Synchronous methods are also available on `SecretClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Listing secrets

Previously in `Microsoft.Azure.KeyVault`, you could list secrets' properties using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_ListSecrets
IPage<SecretItem> page = await client.GetSecretsAsync("https://myvault.vault.azure.net");
foreach (SecretItem item in page)
{
    SecretIdentifier secretId = item.Identifier;
    SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name);
}

while (page.NextPageLink != null)
{
    page = await client.GetSecretsNextAsync(page.NextPageLink);
    foreach (SecretItem item in page)
    {
        SecretIdentifier secretId = item.Identifier;
        SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name);
    }
}
```

Now in `Azure.Security.KeyVault.Secrets`, you list secrets' properties in the Key Vault you specified when constructing the `SecretClient`. This returns an enumerable that enumerates all secrets across any number of pages. If you want to enumerate pages, call the `AsPages` method on the returned enumerable.

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_ListSecrets
// List all secrets asynchronously.
await foreach (SecretProperties item in client.GetPropertiesOfSecretsAsync())
{
    KeyVaultSecret secret = await client.GetSecretAsync(item.Name);
}

// List all secrets synchronously.
foreach (SecretProperties item in client.GetPropertiesOfSecrets())
{
    KeyVaultSecret secret = client.GetSecret(item.Name);
}
```

### Listing secret versions

Previously in `Microsoft.Azure.KeyVault`, you could list secret versions' properties using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_ListSecretVersions
IPage<SecretItem> page = await client.GetSecretVersionsAsync("https://myvault.vault.azure.net", "secret-name");
foreach (SecretItem item in page)
{
    SecretIdentifier secretId = item.Identifier;
    SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name, secretId.Version);
}

while (page.NextPageLink != null)
{
    page = await client.GetSecretVersionsNextAsync(page.NextPageLink);
    foreach (SecretItem item in page)
    {
        SecretIdentifier secretId = item.Identifier;
        SecretBundle secret = await client.GetSecretAsync(secretId.Vault, secretId.Name, secretId.Version);
    }
}
```

Now in `Azure.Security.KeyVault.Secrets`, you list secret versions' properties in the Key Vault you specified when constructing the `SecretClient`. This returns an enumerable that enumerates all secret versions across any number of pages. If you want to enumerate pages, call the `AsPages` method on the returned enumerable.

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_ListSecretVersions
// List all secrets asynchronously.
await foreach (SecretProperties item in client.GetPropertiesOfSecretVersionsAsync("secret-name"))
{
    KeyVaultSecret secret = await client.GetSecretAsync(item.Name, item.Version);
}

// List all secrets synchronously.
foreach (SecretProperties item in client.GetPropertiesOfSecretVersions("secret-name"))
{
    KeyVaultSecret secret = client.GetSecret(item.Name, item.Version);
}
```

### Deleting secrets

Previously in `Microsoft.Azure.KeyVault`, you could delete a secret using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Secrets_Snippets_MigrationGuide_DeleteSecret
// Delete the secret.
DeletedSecretBundle deletedSecret = await client.DeleteSecretAsync("https://myvault.vault.azure.net", "secret-name");

// Purge or recover the deleted secret if soft delete is enabled.
if (deletedSecret.RecoveryId != null)
{
    DeletedSecretIdentifier deletedSecretId = deletedSecret.RecoveryIdentifier;

    // Deleting a secret does not happen immediately. Wait a while and check if the deleted secret exists.
    while (true)
    {
        try
        {
            await client.GetDeletedSecretAsync(deletedSecretId.Vault, deletedSecretId.Name);

            // Finally deleted.
            break;
        }
        catch (KeyVaultErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
        {
            // Not yet deleted...
        }
    }

    // Purge the deleted secret.
    await client.PurgeDeletedSecretAsync(deletedSecretId.Vault, deletedSecretId.Name);

    // You can also recover the deleted secret using RecoverDeletedSecretAsync.
}
```

Now in `Azure.Security.KeyVault.Secrets`, you delete a secret in the Key Vault you specified when constructing the `SecretClient` and succinctly await or poll status on an operation to complete:

```C# Snippet:Azure_Security_KeyVault_Secrets_Snippets_MigrationGuide_DeleteSecret
// Delete the secret.
DeleteSecretOperation deleteOperation = await client.StartDeleteSecretAsync("secret-name");

// Purge or recover the deleted secret if soft delete is enabled.
if (deleteOperation.Value.RecoveryId != null)
{
    // Deleting a secret does not happen immediately. Wait for the secret to be deleted.
    DeletedSecret deletedSecret = await deleteOperation.WaitForCompletionAsync();

    // Purge the deleted secret.
    await client.PurgeDeletedSecretAsync(deletedSecret.Name);

    // You can also recover the deleted secret using StartRecoverDeletedSecretAsync,
    // which returns RecoverDeletedSecretOperation you can await like DeleteSecretOperation above.
}
```

Synchronous methods are also available on `SecretClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Managing shared access signatures

Because [Role-Based Access Control (RBAC)](https://learn.microsoft.com/azure/role-based-access-control/overview) is now recommended for storage account access control, the APIs for Key Vault-managed storage accounts are no longer available in version 4 of Key Vault client libraries. If you cannot use RBAC and must use [Shared Access Signatures (SAS)](https://learn.microsoft.com/azure/storage/common/storage-sas-overview), see [our sample](https://learn.microsoft.com/samples/azure/azure-sdk-for-net/share-link/) for source you can use in your own projects built on the same `Azure.Core` pipeline as the version 4 client libraries described above.

## Additional samples

- [Key Vault secrets samples for .NET](https://learn.microsoft.com/samples/azure/azure-sdk-for-net/azuresecuritykeyvaultsecrets-samples/)
- [All Key Vault samples for .NET](https://learn.microsoft.com/samples/browse/?products=azure-key-vault&languages=csharp)

## Support

If you have migrated your code base and experiencing errors, see our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/TROUBLESHOOTING.md).
For additional support, please search our [existing issues](https://github.com/Azure/azure-sdk-for-net/issues) or [open a new issue](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
You may also find existing answers on community sites like [Stack Overflow](https://stackoverflow.com/questions/tagged/azure-keyvault+.net).

[deprecated]: https://aka.ms/azsdk/deprecated
