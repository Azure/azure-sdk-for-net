using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace GarbageCollector
{
    public static class Program
    {
        private static readonly Uri BlobServiceUri = new Uri("https://cloudclips.blob.core.windows.net/");

        public static async Task Main()
        {
            BlobClientOptions options = new BlobClientOptions();
            options.Retry.MaxRetries = 10;
            options.Retry.Delay = TimeSpan.FromSeconds(3);
            options.Diagnostics.IsLoggingEnabled = true;

            options.AddPolicy(new SimpleTracingPolicy(), HttpPipelinePosition.PerCall);

            BlobServiceClient serviceClient = new BlobServiceClient(BlobServiceUri, new DefaultAzureCredential(), options);
            await foreach (BlobContainerItem container in serviceClient.GetBlobContainersAsync())
            {
                BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(container.Name);
                await containerClient.DeleteAsync();
            }
        }
    }

    public class SimpleTracingPolicy : HttpPipelinePolicy
    {
        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Console.WriteLine($">> Request: {message.Request.Method} {message.Request.Uri}");
            await ProcessNextAsync(message, pipeline);
            Console.WriteLine($">> Response: {message.Response.Status} from {message.Request.Method} {message.Request.Uri}\n");
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            Console.WriteLine($">> Request: {message.Request.Uri}");
            ProcessNext(message, pipeline);
            Console.WriteLine($">> Response: {message.Response.Status} {message.Request.Method} {message.Request.Uri}");
        }
    }
}
