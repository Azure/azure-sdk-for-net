using Azure.Identity;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Blobs;
using Azure.Core;
using System.Diagnostics;
using Azure.Storage.Blobs.Models;
using ConcurrencyTunerTest;

string location = "C:/Users/t-davidbrown/Documents/temp_for_testing(really_small_files)/";
//Create empty files
//CreateEmptyFiles(60_000, 500, 1000, location);

string url = "https://davidbrowntest.blob.core.windows.net/testcontainer3";
TokenCredential credential = new DefaultAzureCredential();

await DeleteAllBlobsInContainerAsync(credential, url);
await RunDataMovement(credential, url, location);

// Delete all blobs in the container after transfer is complete
//await DeleteAllBlobsInContainerAsync(credential, url);





















static void CreateEmptyFiles(int numOfFiles, int minSize, int maxSize, string location)
{
    EmptyFileCreator emptyFileCreator = new EmptyFileCreator();
    emptyFileCreator.Location(location)
        .NumberOfFiles(numOfFiles)
        .RangeOfFileSizeInKB(minSize, maxSize)
        .Build();
}



static async Task DeleteAllBlobsInContainerAsync(TokenCredential credential, string url)
{
    BlobContainerClient containerClient = new BlobContainerClient(
        new Uri(url), credential);

    var deleteTasks = new List<Task>();
    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
    {
        deleteTasks.Add(containerClient.DeleteBlobAsync(blobItem.Name));
    }

    await Task.WhenAll(deleteTasks);
    Console.WriteLine("All blobs in the container have been deleted.");
}

static async Task RunDataMovement(TokenCredential credential, string url, string location)
{

    Stopwatch stopwatch = Stopwatch.StartNew();

    // Authenticate
    BlobsStorageResourceProvider blobsStorageResourceProvider = new BlobsStorageResourceProvider(credential);

    // Fix for CS0029 and CA2012: Directly await the ValueTask returned by FromContainerAsync
    StorageResource destinationResource = await blobsStorageResourceProvider.FromContainerAsync(
            new Uri(url));

    // Instantiate Transfer Manager
    TransferManagerOptions transferManagerOptions = new TransferManagerOptions
    {
        MaximumConcurrency = Environment.ProcessorCount * 8
    };
    TransferManager tm = new TransferManager(transferManagerOptions);
    //TransferManager tm = new();
    var concurrencyTuner = tm._concurrencyTuner;
    var throughputMonitor = concurrencyTuner.ThroughputMonitor;

#pragma warning disable CS4014
    Task.Run(async () =>
    {
        while (true)
        {
            await Task.Delay(1000);
            Console.Clear();
            Console.WriteLine($"# of Cores: {Environment.ProcessorCount}");
            Console.WriteLine($"Total MBs transferred: {(throughputMonitor.TotalBytesTransferred) / 1024 / 1024}");
            Console.WriteLine($"Throughput in Mbps: {(throughputMonitor.ThroughputInMb) * 8}");
            Console.WriteLine($"Current Max Concurrency in Program.cs: {tm._chunksProcessor.MaxConcurrentProcessing}");
            Console.WriteLine($"Average Throughput in Mbps: {throughputMonitor.AvgThroughput * 8 / 1024 / 1024}");
            Console.WriteLine($"Concurrency Recommendations: {tm._concurrencyTuner.ConcurrencyRecommendationCount}");
            Console.WriteLine($"Current Concurrency recommendation sum: {tm._concurrencyTuner.ConcurrencyRecommendationSum}");
        }
    });
#pragma warning restore CS4014

    TransferOperation transferOperation = await tm.StartTransferAsync(
        sourceResource: LocalFilesStorageResourceProvider.FromDirectory(location),
        destinationResource: destinationResource);
    await transferOperation.WaitForCompletionAsync();
    stopwatch.Stop();

    Console.WriteLine($"Total Time Elapsed: {stopwatch.Elapsed.TotalSeconds}");
}