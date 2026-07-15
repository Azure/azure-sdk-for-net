# Securely wrapping and unwrapping a key

This sample demonstrates how to securely wrap a key generated inside a Managed HSM trusted execution environment (TEE) and securely unwrap it into a target TEE.

Secure wrap and unwrap are only supported on Managed HSM with service version `2026-01-01-preview` or newer. Unlike ordinary wrap/unwrap, these operations are **remote-only** (they cannot be performed locally) and release the key only into a target environment that can prove its identity with a Microsoft Azure Attestation (MAA) token.

To get started, you'll need a URI to an Azure Managed HSM. See the [README][] for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create keys, you need the endpoint to an Azure Managed HSM and credentials.
You can use the [DefaultAzureCredential][] to try a number of common authentication methods optimized for both running as a service deployed to Azure and development.

In the sample below, you can set `managedHsmUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample10KeyClient
var keyClient = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Creating a wrapping key

Secure wrap/unwrap keys must be created with the `SecureWrapKey` and `SecureUnwrapKey` operations and a release policy. The release policy governs which target environments (TEEs) the wrapping key may be released into, identified by the attestation authority it trusts.

```C# Snippet:KeysSample10CreateKey
// Secure wrap/unwrap keys must be created on a Managed HSM with the SecureWrapKey and SecureUnwrapKey
// operations and a release policy. The release policy governs which target environments (TEEs) the
// wrapping key may be released into.
string keyName = $"SecureWrapKey-{Guid.NewGuid()}";
BinaryData releasePolicyData = BinaryData.FromObjectAsJson(new
{
    anyOf = new[]
    {
        new
        {
            anyOf = new[] { new { claim = "sdk-test", equals = "true" } },
            authority = attestationUrl,
        },
    },
    version = "1.0.0",
});

var createOptions = new CreateRsaKeyOptions(keyName, hardwareProtected: true)
{
    KeySize = 2048,
    KeyOperations = { KeyOperation.SecureWrapKey, KeyOperation.SecureUnwrapKey },
    ReleasePolicy = new KeyReleasePolicy(releasePolicyData),
};

KeyVaultKey wrappingKey = keyClient.CreateRsaKey(createOptions);
Debug.WriteLine($"Wrapping key created with name {wrappingKey.Name} and type {wrappingKey.KeyType}");
```

## Creating a CryptographyClient

Then, create the `CryptographyClient` bound to the wrapping key. Secure wrap and unwrap are remote-only, so the client must be created from the key identifier and a credential (not from a local `JsonWebKey`).

```C# Snippet:KeysSample10CryptographyClient
var cryptoClient = new CryptographyClient(wrappingKey.Id, new DefaultAzureCredential());
```

## Securely wrapping a key

Secure wrap asks the Managed HSM to generate a fresh key inside its trusted execution environment and wrap it under the wrapping key. The returned `SecureWrapResult` contains the wrapped key bytes.

```C# Snippet:KeysSample10SecureWrapKey
// Securely wrap a key generated inside the Managed HSM trusted execution environment.
SecureWrapResult wrapResult = cryptoClient.SecureWrapKey(SecureKeyWrapAlgorithm.RsaOaep256);
Debug.WriteLine($"Securely wrapped a key for {wrapResult.KeyId} using {wrapResult.Algorithm}.");
```

## Securely unwrapping a key

Secure unwrap releases the wrapped key into a target TEE. This requires a valid Microsoft Azure Attestation (MAA) token that proves the identity of the target environment. The token is opaque to the SDK; obtain it from your TEE / attestation flow and pass it as `targetAttestationToken`. Note that the same algorithm must be used for both wrap and unwrap.

```C# Snippet:KeysSample10SecureUnwrapKey
// Unwrap the key into the target TEE proven by the attestation token. The same algorithm used to wrap
// must be used to unwrap.
SecureUnwrapResult unwrapResult = cryptoClient.SecureUnwrapKey(
    wrapResult.Algorithm,
    wrapResult.EncryptedKey,
    targetAttestationToken);
Debug.WriteLine($"Securely unwrapped the key for {unwrapResult.KeyId} using {unwrapResult.Algorithm}.");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md
