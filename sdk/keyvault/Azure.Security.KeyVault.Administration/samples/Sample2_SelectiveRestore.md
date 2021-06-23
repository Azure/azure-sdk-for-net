# Performing a selective key restore

Using the `KeyVaultBackupClient`, you can restore a single key from backup by key name. The data source for a 
selective key restore is a storage blob accessed using Shared Access Signature authentication. 
For more details on creating a SAS token using the `BlobServiceClient`, see the 
[Azure Storage Blobs client README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/README.md) 
and the [authentication samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/samples/Sample02_Auth.cs).
Alternatively, it is possible to [generate a SAS token in Storage Explorer](https://docs.microsoft.com/azure/vs-azure-tools-storage-manage-with-storage-explorer?tabs=windows#generate-a-shared-access-signature-in-storage-explorer)

```C# Snippet:SelectiveRestoreAsync
string keyName = "<key name to restore>";

// Start the restore for a specific key that was previously backed up using the backupBlobUri returned from a previous BackupOperation.
KeyVaultSelectiveKeyRestoreOperation restoreOperation = await Client.StartSelectiveKeyRestoreAsync(keyName, folderUri, sasToken);

// Wait for completion of the RestoreOperation.
KeyVaultSelectiveKeyRestoreResult restoreResult = await restoreOperation.WaitForCompletionAsync();
```
