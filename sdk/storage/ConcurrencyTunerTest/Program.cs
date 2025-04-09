using Azure.Identity;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Blobs;
using Azure.Core;


// Transfer a couple thousand files at 10s of gigs for uploads
// Create print statements for now to see throughput
// Heartbeat log might be good for future


// Authenticate

TokenCredential credential = new DefaultAzureCredential();

BlobsStorageResourceProvider blobsStorageResourceProvider = new BlobsStorageResourceProvider(credential);

//BlobContainerClient containerClient = service.GetBlobContainerClient("testcontainer");
//await containerClient.CreateIfNotExistsAsync();
//containerClient.

// Fix for CS0029 and CA2012: Directly await the ValueTask returned by FromContainerAsync
StorageResource destinationResource = await blobsStorageResourceProvider.FromContainerAsync(
        new Uri("https://davidbrowntest.blob.core.windows.net/testcontainer2"));



// Instantiate Transfer Manager
TransferManager tm = new TransferManager();
var concurrencyTuner = tm._concurrencyTuner;
var throughputMonitor = concurrencyTuner.ThroughputMonitor;

Task.Run(async () =>
{
    while (true)
    {
        await Task.Delay(1000);
        Console.Clear();
        Console.WriteLine($"Total bytes transferred: {throughputMonitor.TotalBytesTransferred}");
        Console.WriteLine($"Throughput: {throughputMonitor.Throughput}");
        Console.WriteLine($"Current Max Concurrency{concurrencyTuner.MaxConcurrency}");
    }
});

TransferOperation transferOperation = await tm.StartTransferAsync(
 sourceResource: LocalFilesStorageResourceProvider.FromDirectory("C:/Users/t-davidbrown/Documents/temp_for_testing/"),
 destinationResource: destinationResource);
await transferOperation.WaitForCompletionAsync();

