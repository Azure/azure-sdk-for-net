# Signing and verifying keys

This sample demonstrates how to sign data with both a RSA key and an EC key.
To get started, you'll need a URI to an Azure Key Vault or Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample5KeyClient
var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating keys

First, we'll create both an RSA key and an EC key which will be used to sign and verify.

```C# Snippet:KeysSample5CreateKey
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKeyOptions = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
};

string ecKeyName = $"CloudEcKey-{Guid.NewGuid()}";
var ecKeyOptions = new CreateEcKeyOptions(ecKeyName, hardwareProtected: false)
{
    CurveName = KeyCurveName.P256K,
};

KeyVaultKey rsaKey = keyClient.CreateRsaKey(rsaKeyOptions);
Debug.WriteLine($"Key is returned with name {rsaKey.Name} and type {rsaKey.KeyType}");

KeyVaultKey ecKey = keyClient.CreateEcKey(ecKeyOptions);
Debug.WriteLine($"Key is returned with name {ecKey.Name} and type {ecKey.KeyType}");
```

## Creating CryptographyClients

Then, we create the `CryptographyClient` which can perform cryptographic operations with the key we just created using the same credential created above.

```C# Snippet:KeysSample5CryptographyClient
var rsaCryptoClient = new CryptographyClient(rsaKey.Id, new DefaultAzureCredential());

var ecCryptoClient = new CryptographyClient(ecKey.Id, new DefaultAzureCredential());
```

## Signing keys with the Sign and Verify methods

Next, we'll sign some arbitrary data and verify the signatures using the `CryptographyClient` with both the EC and RSA keys we created.
The `Sign` and `Verify` methods expect a precalculated digest, and the digest needs to be calculated using the hash algorithm which matches the signature algorithm being used.
SHA256 is the hash algorithm used for both RS256 and ES256K which are the algorithms we'll be using in this sample.

```C# Snippet:KeysSample5SignKey
byte[] data = Encoding.UTF8.GetBytes("This is some sample data which we will use to demonstrate sign and verify");
byte[] digest = null;

using (HashAlgorithm hashAlgo = SHA256.Create())
{
    digest = hashAlgo.ComputeHash(data);
}

SignResult rsaSignResult = rsaCryptoClient.Sign(SignatureAlgorithm.RS256, digest);
Debug.WriteLine($"Signed digest using the algorithm {rsaSignResult.Algorithm}, with key {rsaSignResult.KeyId}. The resulting signature is {Convert.ToBase64String(rsaSignResult.Signature)}");

SignResult ecSignResult = ecCryptoClient.Sign(SignatureAlgorithm.ES256K, digest);
Debug.WriteLine($"Signed digest using the algorithm {ecSignResult.Algorithm}, with key {ecSignResult.KeyId}. The resulting signature is {Convert.ToBase64String(ecSignResult.Signature)}");
```

## Verifying signatures

Verify the digest by comparing the signature you created previously.

```C# Snippet:KeysSample5VerifySign
VerifyResult rsaVerifyResult = rsaCryptoClient.Verify(SignatureAlgorithm.RS256, digest, rsaSignResult.Signature);
Debug.WriteLine($"Verified the signature using the algorithm {rsaVerifyResult.Algorithm}, with key {rsaVerifyResult.KeyId}. Signature is valid: {rsaVerifyResult.IsValid}");

VerifyResult ecVerifyResult = ecCryptoClient.Verify(SignatureAlgorithm.ES256K, digest, ecSignResult.Signature);
Debug.WriteLine($"Verified the signature using the algorithm {ecVerifyResult.Algorithm}, with key {ecVerifyResult.KeyId}. Signature is valid: {ecVerifyResult.IsValid}");
```

## Signing keys with the SignData and VerifyData methods

The `SignData` and `VerifyData` methods take the raw data which is to be signed. The calculate the digest for the user so there is no need to compute the digest.

```C# Snippet:KeysSample5SignKeyWithSignData
SignResult rsaSignDataResult = rsaCryptoClient.SignData(SignatureAlgorithm.RS256, data);
Debug.WriteLine($"Signed data using the algorithm {rsaSignDataResult.Algorithm}, with key {rsaSignDataResult.KeyId}. The resulting signature is {Convert.ToBase64String(rsaSignDataResult.Signature)}");

SignResult ecSignDataResult = ecCryptoClient.SignData(SignatureAlgorithm.ES256K, data);
Debug.WriteLine($"Signed data using the algorithm {ecSignDataResult.Algorithm}, with key {ecSignDataResult.KeyId}. The resulting signature is {Convert.ToBase64String(ecSignDataResult.Signature)}");
```

## Verifying signatures with VerifyData methods

You can provide the same data for which you generated a signature above to `VerifyData` to generate and compare the digest. To be valid, the generated digest must match the given signature.

```C# Snippet:KeysSample5VerifyKeyWithData
VerifyResult rsaVerifyDataResult = rsaCryptoClient.VerifyData(SignatureAlgorithm.RS256, data, rsaSignDataResult.Signature);
Debug.WriteLine($"Verified the signature using the algorithm {rsaVerifyDataResult.Algorithm}, with key {rsaVerifyDataResult.KeyId}. Signature is valid: {rsaVerifyDataResult.IsValid}");

VerifyResult ecVerifyDataResult = ecCryptoClient.VerifyData(SignatureAlgorithm.ES256K, data, ecSignDataResult.Signature);
Debug.WriteLine($"Verified the signature using the algorithm {ecVerifyDataResult.Algorithm}, with key {ecVerifyDataResult.KeyId}. Signature is valid: {ecVerifyDataResult.IsValid}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
