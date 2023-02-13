# Checking the status of a previously started full key backup and restore

This sample demonstrates how to a check the status and get the result of previously started full key backup and restore operations in Azure Managed HSM.
To get started, you'll need a URI to an Azure Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Checking status of a full key backup operation

Using the `KeyVaultBackupClient` and a `KeyVaultBackupOperation`, you can check the status and retrieve the result of a previously started `KeyVaultBackupOperation`.
For example the `Id` from a started operation on one client can be saved to persistent storage instead of waiting for completion immediately.
At some later time, another client can retrieve the persisted operation Id and construct a `KeyVaultBackupOperation` using a `KeyVaultBackupClient` and the Id
and check for status or wait for completion.

```C# Snippet:ResumeBackupAsync
// Construct a new KeyVaultBackupClient or use an existing one.
KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(managedHsmUrl), new DefaultAzureCredential());

// Construct a BackupOperation using a KeyVaultBackupClient and the Id from a previously started operation.
KeyVaultBackupOperation backupOperation = new KeyVaultBackupOperation(client, backupOperationId);

// Wait for completion of the BackupOperation.
Response<KeyVaultBackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

// Get the Uri for the location of you backup blob.
Uri folderUri = backupResult.Value.FolderUri;
```

## Checking status of a full key restore operation

Using the `KeyVaultBackupClient` and a `KeyVaultRestoreOperation`, you can check the status and retrieve the result of a previously started `KeyVaultRestoreOperation`.
For example the `Id` from a started operation on one client can be saved to persistent storage instead of waiting for completion immediately.
At some later time, another client can retrieve the persisted operation Id and construct a `KeyVaultRestoreOperation` using a `KeyVaultBackupClient` and the Id
and check for status or wait for completion.

```C# Snippet:ResumeRestoreAsync
// Construct a RestoreOperation using a KeyVaultBackupClient and the Id from a previously started operation.
KeyVaultRestoreOperation restoreOperation = new KeyVaultRestoreOperation(client, restoreOperationId);

// Wait for completion of the RestoreOperation.
KeyVaultRestoreResult restoreResult = await restoreOperation.WaitForCompletionAsync();
```
