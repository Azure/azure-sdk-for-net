# Serializing and encrypting with a JWK

This sample demonstrates how to serialize a [JSON web key (JWK)][JWK] and use it in a `CryptographyClient` to perform
cryptographic operations requiring only the public key. We subsequently verify the operation by decrypting the
ciphertext in Key Vault or Managed HSM using the same key.

To get started, you'll need a URI to an Azure Key Vault or Managed HSM. See the [README][] for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample7KeyClient
var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a key

First, create an RSA key which will be used to wrap and unwrap another key.

```C# Snippet:KeysSample7CreateKey
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
};

KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
Debug.WriteLine($"Key is returned with name {cloudRsaKey.Name} and type {cloudRsaKey.KeyType}");
```

## Serialize the JWK

The `KeyVaultKey.Key` property is the JSON web key (JWK) which can be serialized using `System.Text.Json`. You might
serialize the JWK to save it for future sessions or use it with other libraries.

```C# Snippet:KeysSample7Serialize
using FileStream file = File.Create(path);
using (Utf8JsonWriter writer = new Utf8JsonWriter(file))
{
    JsonSerializer.Serialize(writer, cloudRsaKey.Key);
}

Debug.WriteLine($"Saved JWK to {path}");
```

## Encrypting with the JWK

Assuming you had saved the serialized JWK for future sessions, you can decrypt it before you need to use it:

```C# Snippet:KeysSamples7Deserialize
byte[] buffer = File.ReadAllBytes(path);
JsonWebKey jwk = JsonSerializer.Deserialize<JsonWebKey>(buffer);

Debug.WriteLine($"Read JWK from {path} with ID {jwk.Id}");
```

You can then create a new `CryptographyClient` from the JWK to perform cryptographic operations using what public
key information is contained within the JWK:

```C# Snippet:KeysSample7Encrypt
var encryptClient = new CryptographyClient(jwk);

byte[] plaintext = Encoding.UTF8.GetBytes(content);
EncryptResult encrypted = encryptClient.Encrypt(EncryptParameters.RsaOaepParameters(plaintext));

Debug.WriteLine($"Encrypted: {Encoding.UTF8.GetString(plaintext)}");
```

## Decrypting with Key Vault or Managed HSM

Because Key Vault and Managed HSM do not return the private key material, you can decrypt the ciphertext encrypted above
remotely in the Key Vault or Managed HSM. We'll get a `CryptographyClient` from our original `KeyClient` that shares
the same policy, including any customized pipeline policies, diagnostic information, and more.

```C# Snippet:KeysSample7Decrypt
CryptographyClient decryptClient = keyClient.GetCryptographyClient(cloudRsaKey.Name, cloudRsaKey.Properties.Version);
DecryptResult decrypted = decryptClient.Decrypt(DecryptParameters.RsaOaepParameters(ciphertext));

Debug.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted.Plaintext)}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[JWK]: https://datatracker.ietf.org/doc/html/rfc7517
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md
