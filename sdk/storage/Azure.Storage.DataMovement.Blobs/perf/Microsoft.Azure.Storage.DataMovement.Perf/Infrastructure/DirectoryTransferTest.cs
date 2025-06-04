// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Test.Perf;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.Storage.DataMovement.Perf
{
    public abstract class DirectoryTransferTest<TOptions> : PerfTest<TOptions> where TOptions : DirectoryTransferOptions
    {
        protected CloudBlobClient BlobClient;

        protected static DirectoryTransferContext DefaultTransferContext => new()
        {
            ShouldOverwriteCallbackAsync = DirectoryTransferContext.ForceOverwrite
        };

        public DirectoryTransferTest(TOptions options) : base(options)
        {
            StorageCredentials credentials = new(
                PerfTestEnvironment.Instance.StorageAccountName,
                PerfTestEnvironment.Instance.StorageAccountKey);

            CloudStorageAccount account = new(credentials, PerfTestEnvironment.Instance.StorageEndpointSuffix, useHttps: true);
            BlobClient = account.CreateCloudBlobClient();

            if (Options.ChunkSize.HasValue)
            {
                TransferManager.Configurations.BlockSize = (int)Options.ChunkSize.Value;
            }
            if (Options.Concurrency.HasValue)
            {
                TransferManager.Configurations.ParallelOperations = Options.Concurrency.Value;
            }
        }

        protected string CreateLocalDirectory(bool populate = false)
        {
            string directory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(directory);

            if (populate)
            {
                foreach (int i in Enumerable.Range(0, Options.Count))
                {
                    string filePath = Path.Combine(directory, $"file{i}");
                    using (Stream stream = RandomStream.Create(Options.Size))
                    using (FileStream file = System.IO.File.Open(filePath, FileMode.Create))
                    {
                        stream.CopyTo(file);
                    }
                }
            }

            return directory;
        }

        protected async Task<CloudBlobContainer> CreateBlobContainerAsync(bool populate = false)
        {
            string containerName = $"test-{Guid.NewGuid()}".ToLowerInvariant();
            CloudBlobContainer container = BlobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            if (populate)
            {
                foreach (int i in Enumerable.Range(0, Options.Count))
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference($"blob{i}");
                    using (Stream stream = RandomStream.Create(Options.Size))
                    {
                        await blob.UploadFromStreamAsync(stream);
                    }
                }
            }

            return container;
        }

        protected void AssertTransferStatus(TransferStatus status)
        {
            if (status.NumberOfFilesSkipped > 0)
            {
                throw new Exception($"Transfer contained {status.NumberOfFilesSkipped} skipped files.");
            }
            if (status.NumberOfFilesFailed > 0)
            {
                throw new Exception($"Transfer contaiend {status.NumberOfFilesFailed} failed files.");
            }
        }
    }
}
