// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    internal static class IWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder UseBlobService(this IWebJobsBuilder builder, BlobServiceClient blobServiceClient)
        {
            builder.Services.Add(ServiceDescriptor.Singleton<BlobServiceClientProvider>(new FakeBlobServiceClientProvider(blobServiceClient)));
            return builder;
        }
    }
}
