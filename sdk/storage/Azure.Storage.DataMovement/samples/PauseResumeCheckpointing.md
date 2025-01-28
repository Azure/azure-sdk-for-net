# Resuming through Checkpointing

By persisting transfer progress to disk, DataMovement allows resuming of transfers that failed partway through, or were otherwise paused. To resume a transfer, the transfer manager needs to be setup in the first place with `StorageResourceProvider` instances (the same ones used above in [Starting New Transfers](#starting-new-transfers)) which are capable of reassembling the transfer components from persisted data.

By default Data Movement SDK will create a folder called `.azstoragedml` at the path where the SDK is being run.

## Setting Checkpointer Folder Local Location

The location of persisted transfer data will be different than the default location if `TransferCheckpointStoreOptions` were set in `TransferManagerOptions`. To resume transfers recorded in a non-default location, the transfer manager resuming the transfer will also need the appropriate checkpoint store options.

To specify the checkpoint folder directory:
```csharp
string localCheckpointerPath = "C://user//checkpointer-folder"
TransferManagerOptions options = new TransferManagerOptions()
{
    CheckpointerOptions = TransferCheckpointStoreOptions.Local(localCheckpointerPath)
};
```

## Disable checkpointing

> **WARNING:** If checkpointer is disabled, you will not be able to pause and/or resume any transfer.

To disable checkpointing see the code snippet below. This will disable the checkpointer from writing to disk on default to store the checkpointer information.

```csharp
TransferManagerOptions options = new TransferManagerOptions()
{
    CheckpointerOptions = TransferCheckpointStoreOptions.Disabled()
};
```

## Resuming Existing Transfers
 
By persisting transfer progress to disk, DataMovement allows resuming of transfers that failed partway through, or were otherwise paused. To resume a transfer, the transfer manager needs to be setup in the first place with `StorageResourceProvider` instances (the same ones used above in [Starting New Transfers](#starting-new-transfers)) which are capable of reassembling the transfer components from persisted data.

The below sample initializes the `TransferManager` such that it's capable of resuming transfers between the local filesystem and Azure Blob Storage, using the Azure.Storage.DataMovement.Blobs package.

> **Important:** Credentials to storage providers are not persisted. Storage access which requires credentials will need its appropriate `StorageResourceProvider` to be configured with those credentials. Below uses an `Azure.Core` token credential with permission to the appropriate resources.

```C# Snippet:SetupTransferManagerForResume
TokenCredential tokenCredential = new DefaultAzureCredential();
BlobsStorageResourceProvider blobs = new(tokenCredential);
TransferManager transferManager = new(new TransferManagerOptions()
{
    ProvidersForResuming = new List<StorageResourceProvider>() { blobs },
});
```

To resume a transfer, provide the transfer's ID, as shown below. In the case where your application does not have the desired transfer ID available, use `TransferManager.GetTransfersAsync()` to find that transfer and it's ID.

```C# Snippet:DataMovement_ResumeSingle
TransferOperation resumedTransfer = await transferManager.ResumeTransferAsync(transferId);
```

## Pausing transfers

Transfers can be paused either by a given `DataTransfer` or through the `TransferManager` handling the transfer by referencing the transfer ID. The ID can be found on the `DataTransfer` object you received upon transfer start.

```C# Snippet:PauseFromTransfer
await transferOperation.PauseAsync();
```

```C# Snippet:PauseFromManager
await transferManager.PauseTransferAsync(transferId);
```