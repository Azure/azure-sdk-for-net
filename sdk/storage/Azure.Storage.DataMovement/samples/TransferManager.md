# Utilizing the `TransferManager` 

Most of the following examples reuse the same `TransferManager` instance, and therefore only need to be configured once. We recommend this singleton approach, as each instance uses its own concurrency pool, checkpointer path and other resources.

## Configuring `TransferManager` with `TransferManagerOptions`

To configuration the `TransferManager` for specific needs, this can be set through `TransferManagerOptions` at initialization of the `TransferManager`.

```C# Snippet:CreateTransferManagerSimple_BasePackage
TransferManager transferManager = new TransferManager(new TransferManagerOptions());
```

## Setting Checkpointer

The checkpointer options (`TransferCheckpointStoreOptions`) is set through the `TransferManagerOptions`. For more information about checkpointing see [Resume through Checkpointing](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/samples/PauseResumeCheckpointing.md).

The example below shows how to set the checkpointer to a specific local path.
```csharp
string localCheckpointerPath = "C://user//checkpointer-folder"
TransferManagerOptions options = new TransferManagerOptions()
{
    CheckpointerOptions = TransferCheckpointStoreOptions.Local(localCheckpointerPath)
};
```

## Enumerating through Transfers

To enumerate through all transfers on a `TransferManager`.

A function that writes the status of each transfer to console:

```C# Snippet:EnumerateTransfers
async Task CheckTransfersAsync(TransferManager transferManager)
{
    await foreach (TransferOperation transfer in transferManager.GetTransfersAsync())
    {
        using StreamWriter logStream = File.AppendText(logFile);
        logStream.WriteLine(Enum.GetName(typeof(TransferStatus), transfer.Status));
    }
}
```

To list transfers based on `TransferStatus` value:

```C# Snippet:EnumerateTransfersStatus
public async Task CheckTransfersStatusAsync(TransferManager transferManager)
{
    string logFile = CreateTempPath();
    await foreach (TransferOperation transfer in transferManager.GetTransfersAsync())
    {
        using StreamWriter logStream = File.AppendText(logFile);
        logStream.WriteLine(Enum.GetName(typeof(TransferStatus), transfer.Status));
    }
}
```