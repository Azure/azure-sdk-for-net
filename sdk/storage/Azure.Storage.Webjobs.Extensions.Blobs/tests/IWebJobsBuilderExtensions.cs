// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    internal static class IWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder UseStorageServices(this IWebJobsBuilder builder, BlobServiceClient blobServiceClient, QueueServiceClient queueServiceClient)
        {
            builder.Services.Add(ServiceDescriptor.Singleton<BlobServiceClientProvider>(new FakeBlobServiceClientProvider(blobServiceClient)));
            builder.Services.Add(ServiceDescriptor.Singleton<QueueServiceClientProvider>(new FakeQueueServiceClientProvider(queueServiceClient)));
            return builder;
        }
    }
}
