# Encrypting and decrypt keys

This sample demonstrates how to encrypt and decrypt a single block of plain text with an RSA key.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault or Managed HSM and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample4KeyClient
var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a key

First, we create a RSA key which will be used to encrypt and decrypt.

```C# Snippet:KeysSample4CreateKey
// Let's create a RSA key which will be used to encrypt and decrypt
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
};

KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
```

## Creating a CryptographyClient

We create the `CryptographyClient` which can perform cryptographic operations with the key we just created using the same credential created above.

```C# Snippet:KeysSample4CryptographyClient
var cryptoClient = new CryptographyClient(cloudRsaKey.Id, new DefaultAzureCredential());
```

## Encrypting a key

Next, we'll encrypt some arbitrary plaintext with the key using the CryptographyClient.
Note that RSA encryption algorithms have no chaining so they can only encrypt a single block of plaintext securely.

```C# Snippet:KeysSample4EncryptKey
byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
EncryptResult encryptResult = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep256, plaintext);
Debug.WriteLine($"Encrypted data using the algorithm {encryptResult.Algorithm}, with key {encryptResult.KeyId}. The resulting encrypted data is {Convert.ToBase64String(encryptResult.Ciphertext)}");
```

## Decrypting a key

Now decrypt the encrypted data. Note that the same algorithm must always be used for both encrypt and decrypt.

```C# Snippet:KeysSample4DecryptKey
DecryptResult decryptResult = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep256, encryptResult.Ciphertext);
Debug.WriteLine($"Decrypted data using the algorithm {decryptResult.Algorithm}, with key {decryptResult.KeyId}. The resulting decrypted data is {Encoding.UTF8.GetString(decryptResult.Plaintext)}");
```

## Encrypting and decrypting with symmetric keys

Managed HSM allows you to encrypt and decrypt using AES symmetric keys and largely works the same as encrypting and decrypting with RSA.

As above, you first need to create a symmetric key in Managed HSM using a `KeyClient`:

```C# Snippet:OctKeysSample4CreateKey
var managedHsmClient = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());

var octKeyOptions = new CreateOctKeyOptions($"CloudOctKey-{Guid.NewGuid()}")
{
    KeySize = 256,
};

KeyVaultKey cloudOctKey = managedHsmClient.CreateOctKey(octKeyOptions);
```

When using AES encryption algorithms, more information is needed. To help you understand what information is required and optional for different algorithms,
you can create `EncryptParameters` and `DecryptParameter` using their static methods as shown below:

```C# Snippet:OctKeySample4Encrypt
var cryptoClient = new CryptographyClient(cloudOctKey.Id, new DefaultAzureCredential());

byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
byte[] aad = Encoding.UTF8.GetBytes("additional authenticated data");

EncryptParameters encryptParams = EncryptParameters.A256GcmParameters(plaintext, aad);
EncryptResult encryptResult = cryptoClient.Encrypt(encryptParams);
```

In this example, the `aad` variable, or additional authenticated data, is data that is authenticated and must be passed back when decrypting but is not actually encrypted.
It is conveniently passed back in the `EncryptResult` which you can pass back in `DecryptParameters` when decrypting:

```C# Snippet:OctKeySample4Decrypt
DecryptParameters decryptParams = DecryptParameters.A256GcmParameters(
    encryptResult.Ciphertext,
    encryptResult.Iv,
    encryptResult.AuthenticationTag,
    encryptResult.AdditionalAuthenticatedData);

DecryptResult decryptResult = cryptoClient.Decrypt(decryptParams);
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
