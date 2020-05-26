# Back up and restore a secret

This sample demonstrates how to back up and restore a secret from Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](../README.md) for links and instructions.

## Creating a SecretClient

To create a new `SecretClient` to create, get, update, or delete secrets, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:SecretsSample2SecretClient
var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a secret

Let's next create a secret holding a storage account password valid for 1 year.
If the secret already exists in the Azure Key Vault, a new version of the secret is created.

```C# Snippet:SecretsSample2CreateSecret
string secretName = $"StorageAccountPassword{Guid.NewGuid()}";

var secret = new KeyVaultSecret(secretName, "f4G34fMh8v");
secret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

KeyVaultSecret storedSecret = client.SetSecret(secret);
```

## Backing up a secret

You might make backups in case keys get accidentally deleted. For long term storage, it is ideal to write the backup to a file.

```C# Snippet:SecretsSample2BackupSecret
string backupPath = Path.GetTempFileName();
byte[] secretBackup = client.BackupSecret(secretName);

File.WriteAllBytes(backupPath, secretBackup);
```

## Restoring a secret

If the secret is deleted for any reason, you can restore it from the backup back into Azure Key Vault.

```C# Snippet:SecretsSample2RestoreSecret
byte[] secretBackupToRestore = File.ReadAllBytes(backupPath);

SecretProperties restoreSecret = client.RestoreSecretBackup(secretBackupToRestore);
```

## Source

To see the full example source, see:

* [Synchronous Sample2_BackupAndRestore.cs](../tests/samples/Sample2_BackupAndRestore.cs)
* [Asynchronous Sample2_BackupAndRestore.cs](../tests/samples/Sample2_BackupAndRestoreAsync.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md
