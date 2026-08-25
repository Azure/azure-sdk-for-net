using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Storage.Blobs;

/// <summary>
/// Manual benchmark that reproduces the customer scenario:
/// - Concurrent uploads (MaxDegreeOfParallelism = 10)
/// - Small XML-like payloads via BinaryData.FromString
/// - BlobClient.UploadAsync with overwrite: true
///
/// Usage:
///   1. Set environment variable AZURE_STORAGE_BLOB_ENDPOINT to your blob service URL
///      (e.g. https://youraccount.blob.core.windows.net)
///   2. Ensure you're authenticated (az login, DefaultAzureCredential, or set connection string)
///   3. Run with 12.29.1 package, then switch to 12.29.2 and compare output.
///
/// Alternatively set AZURE_STORAGE_CONNECTION_STRING for connection-string auth.
/// </summary>
class Program
{
    // Configuration - adjust as needed
    const int TotalUploads = 500;
    const int MaxDegreeOfParallelism = 10;
    const int PayloadSizeBytes = 8 * 1024; // 8 KB typical small XML response
    const string ContainerName = "perf-regression-test";

    static async Task<int> Main(string[] args)
    {
        Console.WriteLine($"Azure.Storage.Blobs version: {typeof(BlobClient).Assembly.GetName().Version}");
        Console.WriteLine($"Assembly location: {typeof(BlobClient).Assembly.Location}");
        Console.WriteLine($"Total uploads: {TotalUploads}");
        Console.WriteLine($"MaxDegreeOfParallelism: {MaxDegreeOfParallelism}");
        Console.WriteLine($"Payload size: {PayloadSizeBytes} bytes");
        Console.WriteLine();

        BlobServiceClient serviceClient = CreateServiceClient();
        string guid = Guid.NewGuid().ToString();
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(ContainerName + "-" + guid);
        await containerClient.CreateIfNotExistsAsync();

        // Generate payload (simulates XML response from SOAP API)
        string payload = GenerateXmlPayload(PayloadSizeBytes);

        // Warmup - single upload to establish connection
        Console.WriteLine("Warming up (single upload)...");
        var warmupBlob = containerClient.GetBlobClient("_warmup");
        await warmupBlob.UploadAsync(BinaryData.FromString(payload), overwrite: true);
        await warmupBlob.DeleteIfExistsAsync();
        Console.WriteLine("Warmup complete.");
        Console.WriteLine();

        // Run the benchmark multiple iterations
        const int iterations = 5;
        double[] iterationTimes = new double[iterations];
        double[][] perUploadTimes = new double[iterations][];

        for (int iter = 0; iter < iterations; iter++)
        {
            Console.WriteLine($"--- Iteration {iter + 1}/{iterations} ---");
            var (totalMs, uploadTimesMs) = await RunConcurrentUploads(containerClient, payload, iter);
            iterationTimes[iter] = totalMs;
            perUploadTimes[iter] = uploadTimesMs;

            Array.Sort(uploadTimesMs);
            Console.WriteLine($"  Total wall-clock time: {totalMs:F1} ms");
            Console.WriteLine($"  Per-upload: min={uploadTimesMs[0]:F1} ms, " +
                            $"median={uploadTimesMs[uploadTimesMs.Length / 2]:F1} ms, " +
                            $"p95={uploadTimesMs[(int)(uploadTimesMs.Length * 0.95)]:F1} ms, " +
                            $"max={uploadTimesMs[^1]:F1} ms");
            Console.WriteLine();
        }

        // Summary
        Console.WriteLine("=== SUMMARY ===");
        Console.WriteLine($"Wall-clock times (ms): {string.Join(", ", iterationTimes.Select(t => t.ToString("F1")))}");
        Console.WriteLine($"Average wall-clock: {iterationTimes.Average():F1} ms");
        Console.WriteLine($"Median wall-clock: {iterationTimes.OrderBy(x => x).ElementAt(iterations / 2):F1} ms");

        var allUploads = perUploadTimes.SelectMany(x => x).OrderBy(x => x).ToArray();
        Console.WriteLine($"All uploads - median: {allUploads[allUploads.Length / 2]:F1} ms, " +
                        $"p95: {allUploads[(int)(allUploads.Length * 0.95)]:F1} ms, " +
                        $"p99: {allUploads[(int)(allUploads.Length * 0.99)]:F1} ms, " +
                        $"max: {allUploads[^1]:F1} ms");

        // Cleanup
        Console.WriteLine();
        Console.WriteLine("Cleaning up...");
        await containerClient.DeleteIfExistsAsync();
        Console.WriteLine("Done.");

        return 0;
    }

    static async Task<(double TotalMs, double[] UploadTimesMs)> RunConcurrentUploads(
        BlobContainerClient container, string payload, int iteration)
    {
        double[] uploadTimes = new double[TotalUploads];
        int[] indices = Enumerable.Range(0, TotalUploads).ToArray();

        var totalSw = Stopwatch.StartNew();

        await Parallel.ForEachAsync(indices, new ParallelOptions
        {
            MaxDegreeOfParallelism = MaxDegreeOfParallelism
        }, async (index, ct) =>
        {
            string blobName = $"iter{iteration}/blob-{index:D4}";
            var blobClient = container.GetBlobClient(blobName);

            var sw = Stopwatch.StartNew();
            await blobClient.UploadAsync(
                BinaryData.FromString(payload),
                overwrite: true,
                ct);
            sw.Stop();

            uploadTimes[index] = sw.Elapsed.TotalMilliseconds;
        });

        totalSw.Stop();
        return (totalSw.Elapsed.TotalMilliseconds, uploadTimes);
    }

    static BlobServiceClient CreateServiceClient()
    {
        string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        if (!string.IsNullOrEmpty(connectionString))
        {
            return new BlobServiceClient(connectionString);
        }

        // Try to read from TestConfigurations.xml (ProductionTenant)
        string configPath = FindTestConfigurationsXml();
        if (configPath != null)
        {
            Console.WriteLine($"Using TestConfigurations.xml: {configPath}");
            var doc = XDocument.Load(configPath);
            var tenant = doc.Descendants("TenantConfiguration")
                .FirstOrDefault(t => (string)t.Element("TenantName") == "ProductionTenant");
            if (tenant != null)
            {
                connectionString = (string)tenant.Element("ConnectionString");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    return new BlobServiceClient(connectionString);
                }
            }
        }

        Console.Error.WriteLine("ERROR: Could not find credentials. Set AZURE_STORAGE_CONNECTION_STRING or ensure TestConfigurations.xml is accessible.");
        Environment.Exit(1);
        return null!;
    }

    static string FindTestConfigurationsXml()
    {
        // Search relative to this project's typical locations
        string[] searchPaths = new[]
        {
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Azure.Storage.Common", "tests", "Shared", "TestConfigurations.xml"),
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "sdk", "storage", "Azure.Storage.Common", "tests", "Shared", "TestConfigurations.xml"),
            @"C:\azure-sdk-for-net\sdk\storage\Azure.Storage.Common\tests\Shared\TestConfigurations.xml",
        };

        foreach (var path in searchPaths)
        {
            string full = Path.GetFullPath(path);
            if (File.Exists(full))
                return full;
        }
        return null;
    }

    static string GenerateXmlPayload(int approximateBytes)
    {
        // Simulate a SOAP API XML response
        const string template = "<Record><Id>{0}</Id><Timestamp>{1}</Timestamp><Data>{2}</Data></Record>";
        string data = new string('X', Math.Max(0, approximateBytes - 100));
        return string.Format(template, Guid.NewGuid(), DateTime.UtcNow.ToString("O"), data);
    }
}
