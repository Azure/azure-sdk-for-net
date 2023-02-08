# Listing keys, key versions, and deleted keys

This sample demonstrates how to list keys and versions of a given key, and list deleted keys in a soft delete-enabled Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample3KeyClient
var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating keys

Let's create EC and RSA keys valid for 1 year.
If the key already exists in the Azure Key Vault, then a new version of the key is created.

```C# Snippet:KeysSample3CreateKey
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
    ExpiresOn = DateTimeOffset.Now.AddYears(1)
};

client.CreateRsaKey(rsaKey);

string ecKeyName = $"CloudECKey-{Guid.NewGuid()}";
var ecKey = new CreateEcKeyOptions(ecKeyName, hardwareProtected: false)
{
    ExpiresOn = DateTimeOffset.Now.AddYears(1)
};

client.CreateEcKey(ecKey);
```

## Listing keys

You need to check the type of keys that already exist in your Azure Key Vault.
Let's list the keys and print their types. List operations don't return the actual key, but only properties of the key.
So, for each returned key we call GetKey to get the actual key.

```C# Snippet:KeysSample3ListKeys
IEnumerable<KeyProperties> keys = client.GetPropertiesOfKeys();
foreach (KeyProperties key in keys)
{
    KeyVaultKey keyWithType = client.GetKey(key.Name);
    Debug.WriteLine($"Key is returned with name {keyWithType.Name} and type {keyWithType.KeyType}");
}
```

## Updating RSA key size

We need the cloud RSA key with bigger key size, so you want to update the key in Azure Key Vault to ensure it has the required size.
Calling `CreateRsaKey` on an existing key creates a new version of the key in the Azure Key Vault with the new specified size.

```C# Snippet:KeysSample3UpdateKey
var newRsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 4096,
    ExpiresOn = DateTimeOffset.Now.AddYears(1)
};

client.CreateRsaKey(newRsaKey);
```

## Listing key versions

You need to check all the different versions cloud RSA key had previously.
Lets print all the versions of this key.

```C# Snippet:KeysSample3ListKeyVersions
IEnumerable<KeyProperties> keysVersions = client.GetPropertiesOfKeyVersions(rsaKeyName);
foreach (KeyProperties key in keysVersions)
{
    Debug.WriteLine($"Key's version {key.Version} with name {key.Name}");
}
```

## Deleting keys

The cloud RSA Key and the cloud EC keys are no longer needed.
You need to delete them from the Azure Key Vault.

```C# Snippet:KeysSample3DeletedKeys
DeleteKeyOperation rsaKeyOperation = client.StartDeleteKey(rsaKeyName);
DeleteKeyOperation ecKeyOperation = client.StartDeleteKey(ecKeyName);

// You only need to wait for completion if you want to purge or recover the key.
while (!rsaKeyOperation.HasCompleted || !ecKeyOperation.HasCompleted)
{
    Thread.Sleep(2000);

    rsaKeyOperation.UpdateStatus();
    ecKeyOperation.UpdateStatus();
}
```

## Listing deleted keys

You can list all the deleted and non-purged keys, assuming Azure Key Vault is soft delete-enabled.

```C# Snippet:KeysSample3ListDeletedKeys
IEnumerable<DeletedKey> keysDeleted = client.GetDeletedKeys();
foreach (DeletedKey key in keysDeleted)
{
    Debug.WriteLine($"Deleted key's recovery Id {key.RecoveryId}");
}
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
