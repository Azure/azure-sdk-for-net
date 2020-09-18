// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Azure.Storage.Queues;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs
{
    internal static class MoreStorageExtensions
    {
        public static StorageAccount GetStorageAccount(this IHost host)
        {
            var provider = host.Services.GetRequiredService<StorageAccountProvider>(); // $$$ ok?
            return provider.GetHost();
        }

        public static IWebJobsBuilder UseStorage(this IWebJobsBuilder builder, StorageAccount account)
        {
            builder.AddAzureStorageBlobs().AddAzureStorageQueues();
            builder.Services.Add(ServiceDescriptor.Singleton<StorageAccountProvider>(new FakeStorageAccountProvider(account)));

            return builder;
        }
    }
}
