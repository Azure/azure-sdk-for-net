# Azure Key Vault Key client library for .NET
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
In order to interact with the Key Vault service, you'll need to create an instance of the [KeyClient][key_client_class] class. You would need a **vault url** and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object. 

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity].

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

* Grant the above mentioned application authorization to perform key operations on the key vault:
    ```PowerShell
    az keyvault set-policy --name <your-key-vault-name> --spn $AZURE_CLIENT_ID --key-permissions backup delete get list create
    ```
    > --key-permissions:
    > Accepted values: backup, create, decrypt, delete, encrypt, get, import, list, purge, recover, restore, sign, unwrapKey, update, verify, wrapKey

* Use the above mentioned Key Vault name to retrieve details of your Vault which also contains your Key Vault URL:
    ```PowerShell
    az keyvault show --name <your-key-vault-name> 
    ```

#### Create KeyClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** with the above returned URI, you can create the [KeyClient][key_client_class]:

```C# CreateKeyClient
// Create a new key client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
var client = new KeyClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

// Create a new key using the key client
Key key = client.CreateKey("key-name", KeyType.Rsa);
```

#### Create CryptographyClient
Once you've created a `Key` in the key vault, you can also create the [CryptographyClient][crypto_client_class]:

```C# CreateCryptographyClient
// Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
var cryptoClient = new CryptographyClient(keyId: key.Id, credential: new DefaultAzureCredential());
```

## Key concepts

### Keys
Azure Key Vault supports multiple key types and algorithms, and enables the use of Hardware Security Modules (HSM) for high value keys.

### Key Client:
A KeyClient providing both synchronous and asynchronous operations exists in the SDK allowing for selection of a client based on an application's use case. Once you've initialized a KeyClient, you can interact with the primary resource types in Key Vault.

### Cryptography Client:
A CryptographyClient providing both synchronous and asynchronous operations exists in the SDK allowing for selection of a client based on an application's use case. Once you've initialized a CryptographyClient, you can use it to perform cryptographic operations with keys stored in Key Vault.

## Examples
The Azure.Security.KeyVault.Keys package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the [above created](#create-keyclient) `client`, covering some of the most common Azure Key Vault Key service related tasks:

### Sync examples
* [Create a Key](#create-a-key)
* [Retrieve a Key](#retrieve-a-key)
* [Update an existing Key](#update-an-existing-key)
* [Delete a Key](#delete-a-key)
* [List Keys](#list-keys)
* [Encrypt and Decrypt](#encrypt-and-decrypt)
### Async examples
* [Create a Key](#async-create-a-key)

### Create a Key
Create a Key to be stored in the Azure Key Vault. If a key with the same name already exists, then a new version of the key is created.

```C# CreateKey
// Create a key. Note that you can specify the type of key
// i.e. Elliptic curve, Hardware Elliptic Curve, RSA
Key key = client.CreateKey("key-name", KeyType.Rsa);

Console.WriteLine(key.Name);
Console.WriteLine(key.KeyMaterial.KeyType);

// Create a software RSA key
var rsaCreateKey = new RsaKeyCreateOptions("rsa-key-name", hsm: false);
Key rsaKey = client.CreateRsaKey(rsaCreateKey);

Console.WriteLine(rsaKey.Name);
Console.WriteLine(rsaKey.KeyMaterial.KeyType);

// Create a hardware Elliptic Curve key
var echsmkey = new EcKeyCreateOptions("ec-key-name", hsm: true);
Key ecKey = client.CreateEcKey(echsmkey);

Console.WriteLine(ecKey.Name);
Console.WriteLine(ecKey.KeyMaterial.KeyType);
```

### Retrieve a Key
`GetKey` retrieves a key previously stored in the Key Vault.

```C# RetrieveKey
Key key = client.GetKey("key-name");

Console.WriteLine(key.Name);
Console.WriteLine(key.KeyMaterial.KeyType);
```

### Update an existing Key
`UpdateKey` updates a key previously stored in the Key Vault.

```C# UpdateKey
Key key = client.CreateKey("key-name", KeyType.Rsa);

// You can specify additional application-specific metadata in the form of tags.
key.Properties.Tags["foo"] = "updated tag";

Key updatedKey = client.UpdateKeyProperties(key.Properties, key.KeyMaterial.KeyOps);

Console.WriteLine(updatedKey.Name);
Console.WriteLine(updatedKey.Properties.Version);
Console.WriteLine(updatedKey.Properties.Updated);
```

### Delete a Key
`DeleteKey` deletes a key previously stored in the Key Vault. When [soft-delete][soft_delete] is not enabled for the Key Vault, this operation permanently deletes the key.

```C# DeleteKey
DeletedKey key = client.DeleteKey("key-name");

Console.WriteLine(key.Name);
Console.WriteLine(key.DeletedDate);
```

### List Keys
This example lists all the keys in the specified Key Vault.

```C# ListKeys
Pageable<KeyProperties> allKeys = client.GetKeys();

foreach (KeyProperties key in allKeys)
{
    Console.WriteLine(key.Name);
}
```

### Encrypt and Decrypt
This example creates a CryptographyClient and uses it to encrypt and decrypt with a key in Key Vault.

```C# EncryptDecrypt
byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

// encrypt the data using the algorithm RSAOAEP
EncryptResult encryptResult = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep, plaintext);

// decrypt the encrypted data.
DecryptResult decryptResult = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep, encryptResult.Ciphertext);
```

### Async create a Key
Async APIs are identical to their synchronous counterparts. Note that all methods end with `Async`.

```C# CreateKeyAsync
// Create a key of any type
Key key = await client.CreateKeyAsync("key-name", KeyType.Rsa);

Console.WriteLine(key.Name);
Console.WriteLine(key.KeyMaterial.KeyType);

// Create a software RSA key
var rsaCreateKey = new RsaKeyCreateOptions("rsa-key-name", hsm: false);
Key rsaKey = await client.CreateRsaKeyAsync(rsaCreateKey);

Console.WriteLine(rsaKey.Name);
Console.WriteLine(rsaKey.KeyMaterial.KeyType);

// Create a hardware Elliptic Curve key
var echsmkey = new EcKeyCreateOptions("ec-key-name", hsm: true);
Key ecKey = await client.CreateEcKeyAsync(echsmkey);

Console.WriteLine(ecKey.Name);
Console.WriteLine(ecKey.KeyMaterial.KeyType);
```

## Troubleshooting

### General
When you interact with the Azure Key Vault Key client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a Key that doesn't exist in your Key Vault, a `404` error is returned, indicating `Not Found`.

```C# NotFound
try
{
    Key key = await client.GetKeyAsync("some_key");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the Client Request ID of the operation.

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
Several Key Vault Keys client library samples are available to you in this GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Key Vault:
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
[API_reference]: https://azure.github.io/azure-sdk-for-net/api/Azure.Security.KeyVault.Keys.html
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
