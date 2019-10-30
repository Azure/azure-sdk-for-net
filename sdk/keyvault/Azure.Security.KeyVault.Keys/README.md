# Azure Key Vault key client library for .NET
Azure Key Vault is a cloud service that provides secure storage of keys for encrypting your data. Multiple keys, and multiple versions of the same key, can be kept in the Key Vault. Cryptographic keys in Key Vault are represented as [JSON Web Key (JWK)][JWK] objects.

The Azure Key Vault keys library client supports RSA keys and Elliptic Curve (EC) keys, each with corresponding support in hardware security modules (HSM). It offers operations to create, retrieve, update, delete, purge, backup, restore and list the keys and its versions.

[Source code][key_client_src] | [Package (NuGet)][key_client_nuget_package] | [API reference documentation][API_reference] | [Product documentation][keyvault_docs] | [Samples][key_client_samples]

## Getting started

### Install the package
Install the Azure Key Vault Keys client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Security.KeyVault.Keys -IncludePrerelease
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Key Vault. If you need to create a Key Vault, you can use the Azure Portal or [Azure CLI][azure_cli].

If you use the Azure CLI, replace `<your-resource-group-name>` and `<your-key-vault-name>` with your own, unique names:

```PowerShell
az keyvault create --resource-group <your-resource-group-name> --name <your-key-vault-name>
```

### Authenticate the client
In order to interact with the Key Vault service, you'll need to create an instance of the [KeyClient][key_client_class] class. You would need a **vault url**, which you may see as "DNS Name" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the `DefaultAzureCredential` provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

 #### Create/Get credentials
Use the [Azure CLI][azure_cli] snippet below to create/get client secret credentials.

 * Create a service principal and configure its access to Azure resources:
    ```PowerShell
    az ad sp create-for-rbac -n <your-application-name> --skip-assignment
    ```
    Output:
    ```json
    {
        "appId": "generated-app-ID",
        "displayName": "dummy-app-name",
        "name": "http://dummy-app-name",
        "password": "random-password",
        "tenant": "tenant-ID"
    }
    ```
* Use the returned credentials above to set  **AZURE_CLIENT_ID**(appId), **AZURE_CLIENT_SECRET**(password) and **AZURE_TENANT_ID**(tenant) environment variables. The following example shows a way to do this in Powershell:
    ```PowerShell
    $Env:AZURE_CLIENT_ID="generated-app-ID"
    $Env:AZURE_CLIENT_SECRET="random-password"
    $Env:AZURE_TENANT_ID="tenant-ID"
    ```

* Grant the above mentioned application authorization to perform key operations on the Key Vault:
    ```PowerShell
    az keyvault set-policy --name <your-key-vault-name> --spn $AZURE_CLIENT_ID --key-permissions backup delete get list create encrypt decrypt update
    ```
    > --key-permissions:
    > Accepted values: backup, create, decrypt, delete, encrypt, get, import, list, purge, recover, restore, sign, unwrapKey, update, verify, wrapKey

* Use the above mentioned Key Vault name to retrieve details of your Vault which also contains your Key Vault URL:
    ```PowerShell
    az keyvault show --name <your-key-vault-name> 
    ```

#### Create KeyClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** with the above returned URI, you can create the [KeyClient][key_client_class]:

```C# Snippet:CreateKeyClient
// Create a new key client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
var client = new KeyClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

// Create a new key using the key client.
KeyVaultKey key = client.CreateKey("key-name", KeyType.Rsa);

// Retrieve a key using the key client.
key = client.GetKey("key-name");
```

#### Create CryptographyClient
Once you've created a `KeyVaultKey` in the Key Vault, you can also create the [CryptographyClient][crypto_client_class]:

```C# Snippet:CreateCryptographyClient
// Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
var cryptoClient = new CryptographyClient(keyId: key.Id, credential: new DefaultAzureCredential());
```

## Key concepts

### KeyVaultKey
Azure Key Vault supports multiple key types and algorithms, and enables the use of hardware security modules (HSM) for high value keys.

### KeyClient
A `KeyClient` providing both synchronous and asynchronous operations exists in the SDK allowing for selection of a client based on an application's use case. Once you've initialized a `KeyClient`, you can interact with the primary resource types in Key Vault.

### Cryptography Client:
A `CryptographyClient` providing both synchronous and asynchronous operations exists in the SDK allowing for selection of a client based on an application's use case. Once you've initialized a `CryptographyClient`, you can use it to perform cryptographic operations with keys stored in Key Vault.

## Examples
The Azure.Security.KeyVault.Keys package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the `client` [created above](#create-keyclient), covering some of the most common Azure Key Vault key service related tasks:

### Async examples
* [Create a key](#create-a-key)
* [Retrieve a key](#retrieve-a-key)
* [Update an existing key](#update-an-existing-key)
* [Delete a key](#delete-a-key)
* [Delete and purge a key](#delete-and-purge-a-key)
* [List keys](#list-keys)
* [Encrypt and Decrypt](#encrypt-and-decrypt)

### Sync examples
* [Create a key synchronously](#create-a-key-synchronously)
* [Delete a key synchronously](#delete-a-key-synchronously)

### Create a key
Create a key to be stored in the Azure Key Vault. If a key with the same name already exists, then a new version of the key is created.

```C# Snippet:CreateKey
// Create a key. Note that you can specify the type of key
// i.e. Elliptic curve, Hardware Elliptic Curve, RSA
KeyVaultKey key = await client.CreateKeyAsync("key-name", KeyType.Rsa);

Console.WriteLine(key.Name);
Console.WriteLine(key.KeyType);

// Create a software RSA key
var rsaCreateKey = new CreateRsaKeyOptions("rsa-key-name", hardwareProtected: false);
KeyVaultKey rsaKey = await client.CreateRsaKeyAsync(rsaCreateKey);

Console.WriteLine(rsaKey.Name);
Console.WriteLine(rsaKey.KeyType);

// Create a hardware Elliptic Curve key
// Because only premium key vault supports HSM backed keys , please ensure your key vault
// SKU is premium when you set "hardwareProtected" value to true
var echsmkey = new CreateEcKeyOptions("ec-key-name", hardwareProtected: true);
KeyVaultKey ecKey = await client.CreateEcKeyAsync(echsmkey);

Console.WriteLine(ecKey.Name);
Console.WriteLine(ecKey.KeyType);
```

### Retrieve a key
`GetKeyAsync` retrieves a key previously stored in the Key Vault.

```C# Snippet:RetrieveKey
KeyVaultKey key = await client.GetKeyAsync("key-name");

Console.WriteLine(key.Name);
Console.WriteLine(key.KeyType);
```

### Update an existing key
`UpdateKeyAsync` updates a key previously stored in the Key Vault.

```C# Snippet:UpdateKey
KeyVaultKey key = await client.CreateKeyAsync("key-name", KeyType.Rsa);

// You can specify additional application-specific metadata in the form of tags.
key.Properties.Tags["foo"] = "updated tag";

KeyVaultKey updatedKey = await client.UpdateKeyPropertiesAsync(key.Properties);

Console.WriteLine(updatedKey.Name);
Console.WriteLine(updatedKey.Properties.Version);
Console.WriteLine(updatedKey.Properties.UpdatedOn);
```

### Delete a key
`StartDeleteKeyAsync` starts a long-running operation to delete a key previously stored in the Key Vault.
You can retrieve the key immediately without waiting for the operation to complete.
When [soft-delete][soft_delete] is not enabled for the Key Vault, this operation permanently deletes the key.

```C# Snippet:DeleteKey
DeleteKeyOperation operation = await client.StartDeleteKeyAsync("key-name");

DeletedKey key = operation.Value;
Console.WriteLine(key.Name);
Console.WriteLine(key.DeletedOn);
```

### Delete and purge a key
You will need to wait for the long-running operation to complete before trying to purge or recover the key.

```C# Snippet:DeleteAndPurgeKey
DeleteKeyOperation operation = await client.StartDeleteKeyAsync("key-name");

// You only need to wait for completion if you want to purge or recover the key.
await operation.WaitForCompletionAsync();

DeletedKey key = operation.Value;
await client.PurgeDeletedKeyAsync(key.Name);
```

### List Keys
This example lists all the keys in the specified Key Vault.

```C# Snippet:ListKeys
AsyncPageable<KeyProperties> allKeys = client.GetPropertiesOfKeysAsync();

await foreach (KeyProperties keyProperties in allKeys)
{
    Console.WriteLine(keyProperties.Name);
}
```

### Encrypt and Decrypt
This example creates a `CryptographyClient` and uses it to encrypt and decrypt with a key in Key Vault.

```C# Snippet:EncryptDecrypt
byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

// encrypt the data using the algorithm RSAOAEP
EncryptResult encryptResult = await cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep, plaintext);

// decrypt the encrypted data.
DecryptResult decryptResult = await cryptoClient.DecryptAsync(EncryptionAlgorithm.RsaOaep, encryptResult.Ciphertext);
```

### Create a key synchronously
Synchronous APIs are identical to their asynchronous counterparts, but without the typical "Async" suffix for asynchronous methods.

```C# Snippet:CreateKeySync
// Create a key of any type
KeyVaultKey key = client.CreateKey("key-name", KeyType.Rsa);

Console.WriteLine(key.Name);
Console.WriteLine(key.KeyType);

// Create a software RSA key
var rsaCreateKey = new CreateRsaKeyOptions("rsa-key-name", hardwareProtected: false);
KeyVaultKey rsaKey = client.CreateRsaKey(rsaCreateKey);

Console.WriteLine(rsaKey.Name);
Console.WriteLine(rsaKey.KeyType);

// Create a hardware Elliptic Curve key
// Because only premium key vault supports HSM backed keys , please ensure your key vault
// SKU is premium when you set "hardwareProtected" value to true
var echsmkey = new CreateEcKeyOptions("ec-key-name", hardwareProtected: true);
KeyVaultKey ecKey = client.CreateEcKey(echsmkey);

Console.WriteLine(ecKey.Name);
Console.WriteLine(ecKey.KeyType);
```

### Delete a key synchronously
When deleting a key synchronously before you purge it, you need to call `UpdateStatus` on the returned operation periodically.
You could do this in a loop as shown in the example, or periodically within other operations in your program.

```C# Snippet:DeleteKeySync
DeleteKeyOperation operation = client.StartDeleteKey("key-name");

while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}

DeletedKey key = operation.Value;
client.PurgeDeletedKey(key.Name);
```

## Troubleshooting

### General
When you interact with the Azure Key Vault key client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a key that doesn't exist in your Key Vault, a `404` error is returned, indicating "Not Found".

```C# Snippet:KeyNotFound
try
{
    KeyVaultKey key = await client.GetKeyAsync("some_key");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```
Message:
    Azure.RequestFailedException : Service request failed.
    Status: 404 (Not Found)
Content:
    {"error":{"code":"KeyNotFound","message":"Key not found: some_key"}}

Headers:
    Cache-Control: no-cache
    Pragma: no-cache
    Server: Microsoft-IIS/10.0
    x-ms-keyvault-region: westus
    x-ms-request-id: 625f870e-10ea-41e5-8380-282e5cf768f2
    x-ms-keyvault-service-version: 1.1.0.866
    x-ms-keyvault-network-info: addr=131.107.174.199;act_addr_fam=InterNetwork;
    X-AspNet-Version: 4.0.30319
    X-Powered-By: ASP.NET
    Strict-Transport-Security: max-age=31536000;includeSubDomains
    X-Content-Type-Options: nosniff
    Date: Tue, 18 Jun 2019 16:02:11 GMT
    Content-Length: 75
    Content-Type: application/json; charset=utf-8
    Expires: -1
```

## Next steps
Several Key Vault key client library samples are available to you in this GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Key Vault:
* [HelloWorld.cs][hello_world_sync] and [HelloWorldAsync.cs][hello_world_async] - for working with Azure Key Vault, including:
  * Create a key
  * Get an existing key
  * Update an existing key
  * Delete a key

* [BackupAndRestore.cs][backup_and_restore_sync] and [BackupAndRestoreAsync.cs][backup_and_restore_async] - Contains the code snippets working with Key Vault keys, including:
  * Backup and recover a key

* [GetKeys.cs][get_secrets_sync] and [GetKeysAsync.cs][get_secrets_async] - Example code for working with Key Vault keys, including:
  * Create keys
  * List all keys in the Key Vault
  * Update keys in the Key Vault
  * List versions of a specified key
  * Delete keys from the Key Vault
  * List deleted keys in the Key Vault

* [EncryptDecrypt.cs][encrypt_decrypt_sync] and [EncryptDecryptAsync.cs][encrypt_decrypt_async] - Example code for performing cryptographic operations with Key Vault keys, including:
  * Encrypt and Decrypt data with the CryptographyClient

* [SignVerify.cs][sign_verify_sync] and [SignVerifyAsync.cs][sign_verify_async] - Example code for working with Key Vault keys, including:
  * Sign a precalculated digest and verify the signature with Sign and Verify
  * Sign raw data and verify the signature with SignData and VerifyData

* [WrapUnwrap.cs][wrap_unwrap_sync] and [WrapUnwrapAsync.cs][wrap_unwrap_async] - Example code for working with Key Vault keys, including:
  * Wrap and Unwrap a symmetric key

 ###  Additional Documentation
* For more extensive documentation on Azure Key Vault, see the [API reference documentation][keyvault_rest].
* For Secrets client library see [Secrets client library][secrets_client_library].
* For Certificates client library see [Certificates client library][certificates_client_library].

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[API_reference]: https://azure.github.io/azure-sdk-for-net/keyvault.html
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[azure_sub]: https://azure.microsoft.com/free/
[backup_and_restore_async]:samples/Sample2_BackupAndRestoreAsync.cs
[backup_and_restore_sync]:samples/Sample2_BackupAndRestore.cs
[certificates_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[get_secrets_async]: samples/Sample3_GetKeysAsync.cs
[get_secrets_sync]: samples/Sample3_GetKeys.cs
[encrypt_decrypt_async]: samples/Sample4_EncryptDecryptAsync.cs
[encrypt_decrypt_sync]: samples/Sample4_EncryptDecrypt.cs
[sign_verify_async]: samples/Sample5_SignVerifyAsync.cs
[sign_verify_sync]: samples/Sample5_SignVerify.cs
[wrap_unwrap_async]: samples/Sample6_WrapUnwrapAsync.cs
[wrap_unwrap_sync]: samples/Sample6_WrapUnwrap.cs
[hello_world_async]: samples/Sample1_HelloWorldAsync.cs
[hello_world_sync]: samples/Sample1_HelloWorld.cs
[key_client_class]: src/KeyClient.cs
[crypto_client_class]: src/Cryptography/CryptographyClient.cs
[key_client_nuget_package]: https://www.nuget.org/packages/Azure.Security.KeyVault.Keys/
[key_client_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys/samples
[key_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys/src
[keyvault_docs]: https://docs.microsoft.com/en-us/azure/key-vault/
[keyvault_rest]: https://docs.microsoft.com/en-us/rest/api/keyvault/
[JWK]: https://tools.ietf.org/html/rfc7517
[nuget]: https://www.nuget.org/
[secrets_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets
[soft_delete]: https://docs.microsoft.com/en-us/azure/key-vault/key-vault-ovw-soft-delete

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fkeyvault%2FAzure.Security.KeyVault.Keys%2FFREADME.png)
