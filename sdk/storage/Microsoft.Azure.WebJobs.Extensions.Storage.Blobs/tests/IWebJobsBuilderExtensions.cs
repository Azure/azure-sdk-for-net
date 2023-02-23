// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class IWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder UseStorageServices(this IWebJobsBuilder builder, BlobServiceClient blobServiceClient, QueueServiceClient queueServiceClient)
        {
            builder.Services.AddSingleton<BlobServiceClientProvider>(new FakeBlobServiceClientProvider(blobServiceClient));
            builder.Services.AddSingleton<QueueServiceClientProvider>(new FakeQueueServiceClientProvider(queueServiceClient));
            return builder;
        }
    }
}
