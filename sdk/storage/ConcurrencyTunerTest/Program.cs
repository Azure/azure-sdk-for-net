
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;


TokenCredential tokenCredential = new DefaultAzureCredential();
ShareFilesStorageResourceProvider shares = new(tokenCredential);
TransferManager transferManager = new TransferManager(new TransferManagerOptions());
TransferManager tm = new TransferManager();

// Transfer a couple thousand files at 10s of gigs for uploads
// Create print statements for now to see throughput
// Heartbeat log might be good for future

var concurrencyTunerField = typeof(TransferManager).GetField("_concurrencyTuner", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
if (concurrencyTunerField != null)
{
    var concurrencyTuner = concurrencyTunerField.GetValue(tm) as ConcurrencyTuner;
    if (concurrencyTuner != null)
    {
        var throughputMonitor = concurrencyTuner.ThroughputMonitor;

        await Task.Run(() =>
        {
            Task.Delay(1000);
            Console.Clear();
            Console.WriteLine($"Total bytes transferred: {throughputMonitor.TotalBytesTransferred}");
            Console.WriteLine(throughputMonitor.Throughput);

        });
    }
}

// Use the static methods to create instances of StorageResource
LocalFilesStorageResourceProvider files = new();
// Use the static methods to create instances of StorageResource
StorageResource fileResource = LocalFilesStorageResourceProvider.FromFile("C:/path/to/file.txt");
StorageResource directoryResource = LocalFilesStorageResourceProvider.FromDirectory("C:/path/to/dir");


TransferOperation fileTransfer = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalFile),
    destinationResource: await shares.FromFileAsync(destinationFileUri));
await fileTransfer.WaitForCompletionAsync();
