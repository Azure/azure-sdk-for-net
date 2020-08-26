// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Blob;
using Azure.Storage.Queues;

namespace Microsoft.Azure.WebJobs
{
    internal static class MoreStorageExtensions
    {
        public static StorageAccount GetStorageAccount(this IHost host)
        {
            var provider = host.Services.GetRequiredService<StorageAccountProvider>(); // $$$ ok?
            return provider.GetHost();
        }

        public static async Task<QueueClient> CreateQueueAsync(this StorageAccount account, string queueName)
        {
            var client = account.CreateQueueServiceClient();
            var queue = client.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }

        public static IWebJobsBuilder UseStorage(this IWebJobsBuilder builder, StorageAccount account)
        {
            builder.AddAzureStorage();
            builder.Services.Add(ServiceDescriptor.Singleton<StorageAccountProvider>(new FakeStorageAccountProvider(account)));

            return builder;
        }


        public static string DownloadText(this ICloudBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            using (Stream stream = blob.OpenReadAsync(CancellationToken.None).GetAwaiter().GetResult())
            using (TextReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static async Task UploadEmptyPageAsync(this CloudPageBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            using (CloudBlobStream stream = await blob.OpenWriteAsync(512))
            {
                await stream.CommitAsync();
            }
        }
    }
}
