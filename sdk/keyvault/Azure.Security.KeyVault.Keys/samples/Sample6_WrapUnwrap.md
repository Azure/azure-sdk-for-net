# Wrapping and unwrap a key

This sample demonstrates how to wrap and unwrap a symmetric key with an RSA key.
To get started, you'll need a URI to an Azure Key Vault or Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample6KeyClient
var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a key

First, create an RSA key which will be used to wrap and unwrap another key.

```C# Snippet:KeysSample6CreateKey
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
};

KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
```

## Creating a CryptographyClient

Then, we create the `CryptographyClient` which can perform cryptographic operations with the key we just created using the same credential created above.

```C# Snippet:KeysSample6CryptographyClient
var cryptoClient = new CryptographyClient(cloudRsaKey.Id, new DefaultAzureCredential());
```

## Generating a symmetric key

Next, we'll generate a symmetric key which we will wrap.

```C# Snippet:KeysSample6GenerateKey
byte[] keyData = Aes.Create().Key;
Debug.WriteLine($"Generated Key: {Convert.ToBase64String(keyData)}");
```

## Wrapping a key

Wrap the key using RSAOAEP with the created key.

```C# Snippet:KeysSample6WrapKey
WrapResult wrapResult = cryptoClient.WrapKey(KeyWrapAlgorithm.RsaOaep, keyData);
Debug.WriteLine($"Encrypted data using the algorithm {wrapResult.Algorithm}, with key {wrapResult.KeyId}. The resulting encrypted data is {Convert.ToBase64String(wrapResult.EncryptedKey)}");
```

## Unwrapping a key

Now unwrap the encrypted key. Note that the same algorithm must always be used for both wrap and unwrap.

```C# Snippet:KeysSample6UnwrapKey
UnwrapResult unwrapResult = cryptoClient.UnwrapKey(KeyWrapAlgorithm.RsaOaep, wrapResult.EncryptedKey);
Debug.WriteLine($"Decrypted data using the algorithm {unwrapResult.Algorithm}, with key {unwrapResult.KeyId}. The resulting decrypted data is {Convert.ToBase64String(unwrapResult.Key)}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
