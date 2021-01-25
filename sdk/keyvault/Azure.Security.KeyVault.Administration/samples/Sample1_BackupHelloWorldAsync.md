# Performing a full key backup and restore (Async)

This sample demonstrates how to a perform full key backup and restore in Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Creating a KeyVaultBackupClient

To create a new `KeyVaultBackupClient`, you'll need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:HelloCreateKeyVaultBackupClient
KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Performing a full key backup

Using the `KeyVaultBackupClient`, you can back up your entire collection of keys. The backing store for full key backups is a blob storage container using Shared Access Signature authentication. 
For more details on creating a SAS token using the `BlobServiceClient`, see the [Azure Storage Blobs client README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/README.md) and the [authentication samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/samples/Sample02_Auth.cs).
Alternatively, it is possible to [generate a SAS token in Storage Explorer](https://docs.microsoft.com/azure/vs-azure-tools-storage-manage-with-storage-explorer?tabs=windows#generate-a-shared-access-signature-in-storage-explorer)

To ensure you have some keys for backup, you may want to first create a key using the `KeyClient`.
To create a new `KeyClient` to create a key, see the [Creating a KeyClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample1_HelloWorld.md#creating-a-keyclientkeyvault) and [Creating a key](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample1_HelloWorld.md#creating-a-key) samples.

In the sample below, you can set `blobStorageUrl`, `blobContainerName`, and `sasToken` based on a environment variables, configuration settings, or any way that works for your application.

```C# Snippet:HelloFullBackupAsync
// Create a Uri with the storage container
UriBuilder builder = new UriBuilder(blobStorageUrl)
{
    Path = blobContainerName,
};

// Start the backup.
BackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);

// Wait for completion of the BackupOperation.
Response<BackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

// Get the Uri for the location of you backup blob.
Uri folderUri = backupResult.Value.FolderUri;
```

## Performing a full key restore

Using the `KeyVaultBackupClient`, you can restore your entire collection of keys from backup. The data source for full key restore is a storage blob accessed using Shared Access Signature authentication. 
For more details on creating a SAS token using the `BlobServiceClient`, see the [Azure Storage Blobs client README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/README.md) and the [authentication samples](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/storage/Azure.Storage.Blobs/samples/Sample02_Auth.cs).
Alternatively, it is possible to [generate a SAS token in Storage Explorer](https://docs.microsoft.com/azure/vs-azure-tools-storage-manage-with-storage-explorer?tabs=windows#generate-a-shared-access-signature-in-storage-explorer)

```C# Snippet:HelloFullRestoreAsync
// Start the restore using the backupBlobUri returned from a previous BackupOperation.
RestoreOperation restoreOperation = await Client.StartRestoreAsync(folderUri, sasToken);

// Wait for completion of the RestoreOperation.
Response<RestoreResult> restoreResult = await restoreOperation.WaitForCompletionAsync();
```

<!-- LINKS -->
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
