# Rotate keys

This sample demonstrates how to set key rotation policies and manually rotate keys in Key Vault to create a new key version.

To get started, you'll need a URI to an Azure Key Vault or Managed HSM. See the [README][] for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][] to try a number of common authentication methods optimized for both running as a service deployed to Azure and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample8KeyClient
var keyClient = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a key

First, create an RSA key which will be used to wrap and unwrap another key.

```C# Snippet:KeysSample8CreateKey
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
};

KeyVaultKey cloudRsaKey = keyClient.CreateRsaKey(rsaKey);
Debug.WriteLine($"{cloudRsaKey.KeyType} key is returned with name {cloudRsaKey.Name} and version {cloudRsaKey.Properties.Version}");
```

## Set key rotation policy

To set a key rotation policy, you create a new `KeyRotationPolicy` with 1 or more lifetime actions and an expiration date
for the key that will be created when rotated. The format for `ExpiresIn`, `TimeAfterCreate`, and `TimeBeforeExpiry` are all ISO 8601 durations, such as "P90D" meaning "90 days".

```C# Snippet:KeysSample8UpdateRotationPolicy
KeyRotationPolicy policy = new KeyRotationPolicy()
{
    ExpiresIn = "P90D",
    LifetimeActions =
    {
        new KeyRotationLifetimeAction(KeyRotationPolicyAction.Rotate)
        {
            TimeBeforeExpiry = "P30D"
        }
    }
};

keyClient.UpdateKeyRotationPolicy(rsaKeyName, policy);
```

## Rotate a key

You can manually rotate a key at any time, which will use the current key rotation policy.

```C# Snippet:KeysSample8RotateKey
KeyVaultKey newRsaKey = keyClient.RotateKey(rsaKeyName);
Debug.WriteLine($"Rotated key {newRsaKey.Name} with version {newRsaKey.Properties.Version}");
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md
