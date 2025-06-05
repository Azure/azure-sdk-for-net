# Utilizing `TransferManager.StartTransfer`

Most of the following examples reuse the same `TransferManager` instance, and therefore only need to be configured once. We recommend this singleton approach, as each instance uses its own concurrency pool, checkpointer path and other resources.

For other advanced `TransferManager` samples see [TransferManager Advanced Examples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement/samples/TransferManager.md).

## Monitoring Transfers

Transfers can be observed through several mechanisms, depending on your needs.

### With `TransferOperation`

Simple observation can be done through a `TransferOperation` instance representing an individual transfer. This is obtained on transfer start. You can also enumerate through all transfers on a `TransferManager.GetTransfersAsync()`. See [Enumerate Through Transfers](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement/samples/TransferManager.md#Enumerating through Transfers).

`TransferOperation` contains property `TransferStatus`. You can read this to determine the state of the transfer. States include queued for transfer, in progress, paused, completed, and more. It also contains whether or not the transfer has failed, skipped or has successfully completed.

`TransferOperation` also exposes a task for transfer completion, `TransferOperation.WaitForCompletionAsync()`. See the last line of the code snippet below.

```C# Snippet:SimpleBlobUpload_BasePackage
TokenCredential defaultTokenCredential = new DefaultAzureCredential();
BlobsStorageResourceProvider blobs = new BlobsStorageResourceProvider(defaultTokenCredential);

// Create simple transfer single blob upload job
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalPath),
    destinationResource: await blobs.FromBlobAsync(destinationBlobUri));
await transferOperation.WaitForCompletionAsync();
```

### With Events via `TransferOptions`

When starting a transfer, `TransferOptions` contains multiple events that can be subscribed to for observation. Below demonstrates listening to the event for individual file completion and logging the result.

A function that listens to status events for a given transfer:

```C# Snippet:ListenToTransferEvents
async Task<TransferOperation> ListenToTransfersAsync(TransferManager transferManager,
    StorageResource source, StorageResource destination)
{
    TransferOptions transferOptions = new();
    transferOptions.ItemTransferCompleted += (TransferItemCompletedEventArgs args) =>
    {
        using StreamWriter logStream = File.AppendText(logFile);
        logStream.WriteLine($"File Completed Transfer: {args.Source.Uri.LocalPath}");
        return Task.CompletedTask;
    };
    return await transferManager.StartTransferAsync(
        source,
        destination,
        transferOptions);
}
```

The same can be done when a transfer has completed, failed or has been skipped.

## With IProgress via `TransferOptions`

When starting a transfer, `TransferOptions` allows setting a progress handler that contains the progress information for the overall transfer. Granular progress updates will be communicated to the provided `IProgress` instance.

A function that listens to progress updates for a given transfer with a supplied `IProgress<TStorageTransferProgress>`:

```C# Snippet:ListenToProgress
async Task<TransferOperation> ListenToProgressAsync(TransferManager transferManager, IProgress<TransferProgress> progress,
    StorageResource source, StorageResource destination)
{
    TransferOptions transferOptions = new()
    {
        ProgressHandlerOptions = new()
        {
            ProgressHandler = progress,
            // optionally include the below if progress updates on bytes transferred are desired
            TrackBytesTransferred = true,
        }
    };
    return await transferManager.StartTransferAsync(
        source,
        destination,
        transferOptions);
}
```

## Handling/Monitoring Failed Transfers

Transfer failure can be observed by checking the `TransferOperation` status upon completion, or by listening to failure events on the transfer. While checking the `TransferOperation` may be sufficient for handling single-file transfer failures, event listening is recommended for container transfers.

Below logs failure for a single transfer by checking its status after completion.

```C# Snippet:LogTotalTransferFailure
await dataTransfer2.WaitForCompletionAsync();
if (dataTransfer2.Status.State == TransferState.Completed
    && dataTransfer2.Status.HasFailedItems)
{
    using (StreamWriter logStream = File.AppendText(logFile))
    {
        logStream.WriteLine($"Failure for TransferId: {dataTransfer2.Id}");
    }
}
```

Below logs individual failures in a container transfer via `TransferOptions` events.

```C# Snippet:LogIndividualTransferFailures
transferOptions.ItemTransferFailed += (TransferItemFailedEventArgs args) =>
{
    using (StreamWriter logStream = File.AppendText(logFile))
    {
        // Specifying specific resources that failed, since its a directory transfer
        // maybe only one file failed out of many
        logStream.WriteLine($"Exception occurred with TransferId: {args.TransferId}," +
            $"Source Resource: {args.Source.Uri.AbsoluteUri}, +" +
            $"Destination Resource: {args.Destination.Uri.AbsoluteUri}," +
            $"Exception Message: {args.Exception.Message}");
    }
    return Task.CompletedTask;
};
```

## Transfer Creation Mode

By default, if a transfer that fails to transfer an individual transfer item, it will bring the entire transfer to a stopped completion state that contains failures.

To overwrite if a transfer item already exists set the `TransferOptions.CreationMode` to `StorageResourceCreationMode.OverwriteIfExists`.

```C# Snippet:TransferOptionsOverwrite
TransferOptions optionsOverwriteIfExists = new TransferOptions()
{
    CreationMode = StorageResourceCreationMode.OverwriteIfExists,
};
```

To skip when a failure is seen during a transfer of an item set the `TransferOptions.CreationMode` to `StorageResourceCreationMode.Skip`.

```C# Snippet:TransferOptionsSkipIfExists
TransferOptions optionsSkipIfExists = new TransferOptions()
{
    CreationMode = StorageResourceCreationMode.SkipIfExists,
};
```



