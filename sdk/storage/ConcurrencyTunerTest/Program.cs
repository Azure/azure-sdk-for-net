using Azure.Identity;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Blobs;
using Azure.Core;
using System.Diagnostics;

Stopwatch stopwatch = Stopwatch.StartNew();


// Transfer a couple thousand files at 10s of gigs for uploads
// Create print statements for now to see throughput
// Heartbeat log might be good for future

// Create empty files for transport
//ConcurrencyTunerTest.EmptyFileCreator fileCreator = new();

//fileCreator.Location("C:/Users/t-davidbrown/Documents/temp_for_testing").NumberOfFiles(200).RangeOfFileSizeInMB(30, 50).Build();

// Authenticate
TokenCredential credential = new DefaultAzureCredential();

BlobsStorageResourceProvider blobsStorageResourceProvider = new BlobsStorageResourceProvider(credential);

//BlobContainerClient containerClient = service.GetBlobContainerClient("testcontainer");
//await containerClient.CreateIfNotExistsAsync();
//containerClient.

// Fix for CS0029 and CA2012: Directly await the ValueTask returned by FromContainerAsync
StorageResource destinationResource = await blobsStorageResourceProvider.FromContainerAsync(
        new Uri("https://davidbrowntest.blob.core.windows.net/testcontainer"));



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
        Console.WriteLine($"Total MBs transferred: {(throughputMonitor.TotalBytesTransferred) / 1024 / 1024}");
        Console.WriteLine($"Throughput in Mbps: {(throughputMonitor.Throughput) * 8 / 1024 / 1024}");
        Console.WriteLine($"Current Max Concurrency in Program.cs: {tm._chunksProcessor.MaxConcurrentProcessing}");
        Console.WriteLine($"Average Throughput in Mbps: {throughputMonitor.AvgThroughput * 8 / 1024 / 1024}");
    }
});


TransferOperation transferOperation = await tm.StartTransferAsync(
 sourceResource: LocalFilesStorageResourceProvider.FromDirectory("C:/Users/t-davidbrown/Documents/temp_for_testing/"),
 destinationResource: destinationResource);
await transferOperation.WaitForCompletionAsync();
stopwatch.Stop();

Console.WriteLine($"Total Time Elapsed: {stopwatch.Elapsed.TotalSeconds}");

