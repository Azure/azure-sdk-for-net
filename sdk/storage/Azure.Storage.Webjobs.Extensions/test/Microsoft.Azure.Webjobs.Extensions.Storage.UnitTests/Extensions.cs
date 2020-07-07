// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs
{
    static class MoreStorageExtensions
    {
        public static StorageAccount GetStorageAccount(this IHost host)
        {
            var provider = host.Services.GetRequiredService<StorageAccountProvider>(); // $$$ ok?
            return provider.GetHost();
        }

        public static async Task<CloudQueue> CreateQueueAsync(this StorageAccount account, string queueName)
        {
            CloudQueueClient client = account.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(queueName);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }

        // $$$ Rationalize with AddFakeStorageAccountProvider in FunctionTests.
        public static IWebJobsBuilder UseFakeStorage(this IWebJobsBuilder builder)
        {
            return builder.UseStorage(new FakeStorageAccount());
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
