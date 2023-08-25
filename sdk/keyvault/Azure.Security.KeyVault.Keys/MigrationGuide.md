# Migrate from Microsoft.Azure.KeyVault to Azure.Security.KeyVault.Keys

This guide is intended to assist in the migration to version 4 of the Key Vault client library [`Azure.Security.KeyVault.Keys`](https://www.nuget.org/packages/Azure.Security.KeyVault.Keys) from [deprecated] version 3 of [`Microsoft.Azure.KeyVault`](https://www.nuget.org/packages/Microsoft.Azure.KeyVault). It will focus on side-by-side comparisons for similar operations between the two packages.

Familiarity with the `Microsoft.Azure.KeyVault` library is assumed. For those new to the Key Vault client library for .NET, please refer to the [`Azure.Security.KeyVault.Keys` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) and [`Azure.Security.KeyVault.Keys` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples) for the `Azure.Security.KeyVault.Keys` library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Separate clients](#separate-clients)
  - [Client constructors](#client-constructors)
  - [Creating keys](#creating-keys)
  - [Listing keys](#listing-keys)
  - [Deleting keys](#deleting-keys)
  - [Encrypting data](#encrypting-data)
  - [Wrapping keys](#wrapping-keys)
- [Additional samples](#additional-samples)
- [Support](#support)

## Migration benefits

> Note: `Microsoft.Azure.KeyVault` has been [deprecated]. Please upgrade to `Azure.Security.KeyVault.Keys` for continued support.

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Key Vault, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Key Vault keys library `Azure.Security.KeyVault.Keys` provides the ability to share in some of the cross-service improvements made to the Azure development experience, such as using the new `Azure.Identity` library to share a single authentication between clients and a unified diagnostics pipeline offering a common view of the activities across each of the client libraries.

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

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Create
AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
KeyVaultClient client = new KeyVaultClient(
    new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
```

Now in `Azure.Security.KeyVault.Keys`, you create a `KeyClient` along with the `DefaultAzureCredential` from the package `Azure.Identity`:

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Create
KeyClient client = new KeyClient(
    new Uri("https://myvault.vault.azure.net"),
    new DefaultAzureCredential());

CryptographyClient cryptoClient = new CryptographyClient(
    new Uri("https://myvault.vault.azure.net"),
    new DefaultAzureCredential());
```

[`DefaultAzureCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential) is optimized for both production and development environments without having to change your source code.

#### Sharing an HttpClient

In `Microsoft.Azure.KeyVault` with `KeyVaultClient`, a new `HttpClient` was created with each instance but could be shared to prevent connection starvation:

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions
using (HttpClient httpClient = new HttpClient())
{
    AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
    KeyVaultClient client = new KeyVaultClient(
        new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback),
        httpClient);
}
```

In `Azure.Security.KeyVault.Keys` by default, all client libraries built on `Azure.Core` that communicate over HTTP share a single `HttpClient`. If you want to share an your own `HttpClient` instance with Azure client libraries and other clients you use or implement in your projects, you can pass it via `KeyClientOptions`:

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_CreateWithOptions
using (HttpClient httpClient = new HttpClient())
{
    KeyClientOptions options = new KeyClientOptions
    {
        Transport = new HttpClientTransport(httpClient)
    };

    KeyClient client = new KeyClient(
        new Uri("https://myvault.vault.azure.net"),
        new DefaultAzureCredential(),
        options);

    CryptographyClientOptions cryptoOptions = new CryptographyClientOptions
    {
        Transport = new HttpClientTransport(httpClient)
    };

    CryptographyClient cryptoClient = new CryptographyClient(
        new Uri("https://myvault.vault.azure.net"),
        new DefaultAzureCredential(),
        cryptoOptions);
}
```

[`ClientOptions`](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-usage-options) classes are another common feature of Azure client libraries to configure clients, including diagnostics, retry options, and transport options including your pipeline policies.

### Creating keys

Previously in `Microsoft.Azure.KeyVault`, you could create keys using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_CreateKey
// Create RSA key.
NewKeyParameters createRsaParameters = new NewKeyParameters
{
    Kty = JsonWebKeyType.Rsa,
    KeySize = 4096
};

KeyBundle rsaKey = await client.CreateKeyAsync("https://myvault.vault.azure.net", "rsa-key-name", createRsaParameters);

// Create Elliptic-Curve key.
NewKeyParameters createEcParameters = new NewKeyParameters
{
    Kty = JsonWebKeyType.EllipticCurve,
    CurveName = "P-256"
};

KeyBundle ecKey = await client.CreateKeyAsync("https://myvault.vault.azure.net", "ec-key-name", createEcParameters);
```

Now in `Azure.Security.KeyVault.Keys`, you can create keys in the Key Vault you specified when constructing the `KeyClient`. There are different methods for different key types to help identify which properties are relevant to the key type:

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_CreateKeys
// Create RSA key.
CreateRsaKeyOptions createRsaOptions = new CreateRsaKeyOptions("rsa-key-name")
{
    KeySize = 4096
};

KeyVaultKey rsaKey = await client.CreateRsaKeyAsync(createRsaOptions);

// Create Elliptic-Curve key.
CreateEcKeyOptions createEcOptions = new CreateEcKeyOptions("ec-key-name")
{
    CurveName = KeyCurveName.P256
};

KeyVaultKey ecKey = await client.CreateEcKeyAsync(createEcOptions);
```

Synchronous methods are also available on `KeyClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Listing keys

Previously in `Microsoft.Azure.KeyVault`, you could list keys' properties using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_ListKeys
IPage<KeyItem> page = await client.GetKeysAsync("https://myvault.vault.azure.net");
foreach (KeyItem item in page)
{
    KeyIdentifier keyId = item.Identifier;
    KeyBundle key = await client.GetKeyAsync(keyId.Vault, keyId.Name);
}

while (page.NextPageLink != null)
{
    page = await client.GetKeysNextAsync(page.NextPageLink);
    foreach (KeyItem item in page)
    {
        KeyIdentifier keyId = item.Identifier;
        KeyBundle key = await client.GetKeyAsync(keyId.Vault, keyId.Name);
    }
}
```

Now in `Azure.Security.KeyVault.Keys`, you list keys' properties in the Key Vault you specified when constructing the `KeyClient`. This returns an enumerable that enumerates all keys across any number of pages. If you want to enumerate pages, call the `AsPages` method on the returned enumerable.

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_ListKeys
// List all keys asynchronously.
await foreach (KeyProperties item in client.GetPropertiesOfKeysAsync())
{
    KeyVaultKey key = await client.GetKeyAsync(item.Name);
}

// List all keys synchronously.
foreach (KeyProperties item in client.GetPropertiesOfKeys())
{
    KeyVaultKey key = client.GetKey(item.Name);
}
```

### Deleting keys

Previously in `Microsoft.Azure.KeyVault`, you could delete a key using the `KeyVaultClient` and a specific Key Vault endpoint:

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_DeleteKey
// Delete the key.
DeletedKeyBundle deletedKey = await client.DeleteKeyAsync("https://myvault.vault.azure.net", "key-name");

// Purge or recover the deleted key if soft delete is enabled.
if (deletedKey.RecoveryId != null)
{
    DeletedKeyIdentifier deletedKeyId = deletedKey.RecoveryIdentifier;

    // Deleting a key does not happen immediately. Wait a while and check if the deleted key exists.
    while (true)
    {
        try
        {
            await client.GetDeletedKeyAsync(deletedKeyId.Vault, deletedKeyId.Name);

            // Finally deleted.
            break;
        }
        catch (KeyVaultErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
        {
            // Not yet deleted...
        }
    }

    // Purge the deleted key.
    await client.PurgeDeletedKeyAsync(deletedKeyId.Vault, deletedKeyId.Name);

    // You can also recover the deleted key using RecoverDeletedKeyAsync.
}
```

Now in `Azure.Security.KeyVault.Keys`, you delete a key in the Key Vault you specified when constructing the `KeyClient` and succinctly await or poll status on an operation to complete:

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_DeleteKey
// Delete the key.
DeleteKeyOperation deleteOperation = await client.StartDeleteKeyAsync("key-name");

// Purge or recover the deleted key if soft delete is enabled.
if (deleteOperation.Value.RecoveryId != null)
{
    // Deleting a key does not happen immediately. Wait for the key to be deleted.
    DeletedKey deletedKey = await deleteOperation.WaitForCompletionAsync();

    // Purge the deleted key.
    await client.PurgeDeletedKeyAsync(deletedKey.Name);

    // You can also recover the deleted key using StartRecoverDeletedKeyAsync,
    // which returns RecoverDeletedKeyOperation you can await like DeleteKeyOperation above.
}
```

Synchronous methods are also available on `KeyClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Encrypting data

Previously in `Microsoft.Azure.KeyVault`, you could encrypt and decrypt data using the `KeyVaultClient` and a specific Key Vault endpoint. The constants you could use for the various `string` parameters are not obvious and you may have had to resort to samples or REST API documentation to find what is supported:

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Encrypt
// Encrypt a message. The plaintext must be small enough for the chosen algorithm.
byte[] plaintext = Encoding.UTF8.GetBytes("Small message to encrypt");
KeyOperationResult encrypted = await client.EncryptAsync("rsa-key-name", JsonWebKeyEncryptionAlgorithm.RSAOAEP256, plaintext);

// Decrypt the message.
KeyOperationResult decrypted = await client.DecryptAsync("rsa-key-name", JsonWebKeyEncryptionAlgorithm.RSAOAEP256, encrypted.Result);
string message = Encoding.UTF8.GetString(decrypted.Result);
```

Now in `Azure.Security.KeyVault.Keys`, you can encrypt and decrypt data using the Key Vault and key name you specified when constructing the `CryptographyClient`. Encrypting and other operations that require only the public key attempt to download the public key and perform the operations locally if supported by the machine for increased throughput:

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Encrypt
// Encrypt a message. The plaintext must be small enough for the chosen algorithm.
byte[] plaintext = Encoding.UTF8.GetBytes("Small message to encrypt");
EncryptResult encrypted = await cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep256, plaintext);

// Decrypt the message.
DecryptResult decrypted = await cryptoClient.DecryptAsync(encrypted.Algorithm, encrypted.Ciphertext);
string message = Encoding.UTF8.GetString(decrypted.Plaintext);
```

Synchronous methods are also available on `CryptographyClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

### Wrapping keys

Previously in `Microsoft.Azure.KeyVault`, you could wrap and unwrap keys using the `KeyVaultClient` and a specific Key Vault endpoint. This is useful for wrapping a symmetric key used for encrypting large amounts of data, possibly while streaming. The constants you could use for the various `string` parameters are not obvious and you may have had to resort to samples or REST API documentation to find what is supported:

```C# Snippet:Microsoft_Azure_KeyVault_Keys_Snippets_MigrationGuide_Wrap
using (Aes aes = Aes.Create())
{
    // Use a symmetric key to encrypt large amounts of data, possibly streamed...

    // Now wrap the key and store the encrypted key and plaintext IV to later decrypt the key to decrypt the data.
    KeyOperationResult wrapped = await client.WrapKeyAsync(
        "https://myvault.vault.azure.net",
        "rsa-key-name",
        null,
        JsonWebKeyEncryptionAlgorithm.RSAOAEP256,
        aes.Key);

    // Read the IV and the encrypted key from the payload, then unwrap the key.
    KeyOperationResult unwrapped = await client.UnwrapKeyAsync(
        "https://myvault.vault.azure.net",
        "rsa-key-name",
        null,
        JsonWebKeyEncryptionAlgorithm.RSAOAEP256,
        wrapped.Result);

    aes.Key = unwrapped.Result;

    // Decrypt the payload with the symmetric key.
}
```

Now in `Azure.Security.KeyVault.Keys`, you can wrap and unwrap keys using the Key Vault and key name you specified when constructing the `CryptographyClient`. Wrapping keys and other operations that require only the public key attempt to download the public key and perform the operations locally if supported by the machine for increased throughput:

```C# Snippet:Azure_Security_KeyVault_Keys_Snippets_MigrationGuide_Wrap
using (Aes aes = Aes.Create())
{
    // Use a symmetric key to encrypt large amounts of data, possibly streamed...

    // Now wrap the key and store the encrypted key and plaintext IV to later decrypt the key to decrypt the data.
    WrapResult wrapped = await cryptoClient.WrapKeyAsync(KeyWrapAlgorithm.RsaOaep256, aes.Key);

    // Read the IV and the encrypted key from the payload, then unwrap the key.
    UnwrapResult unwrapped = await cryptoClient.UnwrapKeyAsync(wrapped.Algorithm, wrapped.EncryptedKey);
    aes.Key = unwrapped.Key;

    // Decrypt the payload with the symmetric key.
}
```

Synchronous methods are also available on `CryptographyClient`, though we recommend you use asynchronous methods throughout your projects when possible for better performing applications.

## Additional samples

- [Key Vault keys samples for .NET](https://learn.microsoft.com/samples/azure/azure-sdk-for-net/azuresecuritykeyvaultkeys-samples/)
- [All Key Vault samples for .NET](https://learn.microsoft.com/samples/browse/?products=azure-key-vault&languages=csharp)

## Support

If you have migrated your code base and are experiencing errors, see our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/TROUBLESHOOTING.md).
For additional support, please search our [existing issues](https://github.com/Azure/azure-sdk-for-net/issues) or [open a new issue](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
You may also find existing answers on community sites like [Stack Overflow](https://stackoverflow.com/questions/tagged/azure-keyvault+.net).

[deprecated]: https://aka.ms/azsdk/deprecated
