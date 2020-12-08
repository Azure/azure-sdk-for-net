using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;

namespace GarbageCollector
{
    // Enable future APIs today
    public static class FutureExtensions
    {
        public static void AddPolicy(this BlobClientOptions options, HttpPipelinePolicy policy, HttpPipelinePosition position)
        {
            options.AddPolicy(policy, position);
        }
    }
}
