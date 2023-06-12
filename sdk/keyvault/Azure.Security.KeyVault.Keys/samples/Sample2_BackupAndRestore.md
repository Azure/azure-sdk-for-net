# Back up and restore a key

This sample demonstrates how to back up and restore a Key from Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to create, get, update, or delete keys, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample2KeyClient
var client = new KeyClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a key

Let's create a RSA key valid for 1 year.
If the key already exists in the Azure Key Vault, then a new version of the key is created.

```C# Snippet:KeysSample2CreateKey
string rsaKeyName = $"CloudRsaKey-{Guid.NewGuid()}";
var rsaKey = new CreateRsaKeyOptions(rsaKeyName, hardwareProtected: false)
{
    KeySize = 2048,
    ExpiresOn = DateTimeOffset.Now.AddYears(1)
};

KeyVaultKey storedKey = client.CreateRsaKey(rsaKey);
```

## Backing up a key

You might make backups in case keys get accidentally deleted.
For long term storage, it is ideal to write the backup to a file, disk, database, etc.
For the purposes of this sample, we are storing the back up in a temporary memory area.

```C# Snippet:KeysSample2BackupKey
byte[] backupKey = client.BackupKey(rsaKeyName);
```

## Restoring a key

If the key is deleted for any reason, we can use the backup value to restore it in the Azure Key Vault.

```C# Snippet:KeysSample2RestoreKey
KeyVaultKey restoredKey = client.RestoreKeyBackup(memoryStream.ToArray());
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
