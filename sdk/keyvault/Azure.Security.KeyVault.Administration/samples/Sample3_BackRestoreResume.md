# Checking the status of a previously started full key backup and restore

This sample demonstrates how to a check the status and get the result of previously started full key backup and restore operations in Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Checking status of a full key backup operation

Using the `KeyVaultBackupClient` and a `BackupOperation`, you can check the status and retrieve the result of a previously started `BackupOperation`. 
For example the `Id` from a started operation on one client can be saved to persistent storage instead of waiting for completion immediately. 
At some later time, another client can retrieve the persisted operation Id and construct a `BackupOperation` using a `KeyVaultBackupClient` and the Id 
and check for status or wait for completion.

```C# Snippet:ResumeBackupAsync
// Construct a new KeyVaultBackupClient or use an existing one.
KeyVaultBackupClient Client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

// Construct a BackupOperation using a KeyVaultBackupClient and the Id from a previously started operation.
BackupOperation backupOperation = new BackupOperation(client, backupOperationId);

// Wait for completion of the BackupOperation.
Response<BackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

// Get the Uri for the location of you backup blob.
Uri folderUri = backupResult.Value.FolderUri;
```

## Checking status of a full key restore operation

Using the `KeyVaultBackupClient` and a `RestoreOperation`, you can check the status and retrieve the result of a previously started `RestoreOperation`. 
For example the `Id` from a started operation on one client can be saved to persistent storage instead of waiting for completion immediately. 
At some later time, another client can retrieve the persisted operation Id and construct a `RestoreOperation` using a `KeyVaultBackupClient` and the Id 
and check for status or wait for completion.

```C# Snippet:ResumeRestoreAsync
// Construct a new KeyVaultBackupClient or use an existing one.
KeyVaultBackupClient Client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

// Construct a RestoreOperation using a KeyVaultBackupClient and the Id from a previously started operation.
RestoreOperation restoreOperation = new RestoreOperation(client, restoreOperationId);

// Wait for completion of the RestoreOperation.
RestoreResult restoreResult = await restoreOperation.WaitForCompletionAsync();
```

<!-- LINKS -->
[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md
