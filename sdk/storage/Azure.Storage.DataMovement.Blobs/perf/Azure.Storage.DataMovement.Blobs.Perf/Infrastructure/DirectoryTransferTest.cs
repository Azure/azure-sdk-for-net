// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Tests.Shared;
using Azure.Test.Perf;

namespace Azure.Storage.DataMovement.Blobs.Perf
{
    public abstract class DirectoryTransferTest<TOptions> : PerfTest<TOptions> where TOptions : DirectoryTransferOptions
    {
        protected Random Random { get; }
        protected BlobServiceClient BlobServiceClient { get; }
        protected LocalFilesStorageResourceProvider LocalFileResourceProvider { get; }
        protected BlobsStorageResourceProvider BlobResourceProvider { get; }

        public DirectoryTransferTest(TOptions options) : base(options)
        {
            Random = new Random();
            BlobServiceClient = new BlobServiceClient(PerfTestEnvironment.Instance.BlobStorageEndpoint, PerfTestEnvironment.Instance.Credential);
            LocalFileResourceProvider = new LocalFilesStorageResourceProvider();
            BlobResourceProvider = new BlobsStorageResourceProvider(PerfTestEnvironment.Instance.Credential);
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
                    using (RepeatingStream stream = new(1024 * 1024, Options.Size, true))
                    using (FileStream file = File.Open(filePath, FileMode.Create))
                    {
                        stream.CopyTo(file);
                    }
                }
            }

            return directory;
        }

        protected async Task<BlobContainerClient> CreateBlobContainerAsync(bool populate = false)
        {
            string containerName = $"test-{Guid.NewGuid()}".ToLowerInvariant();
            BlobContainerClient container = BlobServiceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync();

            if (populate)
            {
                foreach (int i in Enumerable.Range(0, Options.Count))
                {
                    BlobClient blob = container.GetBlobClient($"blob{i}");
                    using (RepeatingStream stream = new(1024 * 1024, Options.Size, true))
                    {
                        await blob.UploadAsync(stream);
                    }
                }
            }

            return container;
        }

        protected async Task RunAndVerifyTransferAsync(
            StorageResource source,
            StorageResource destination,
            CancellationToken cancellationToken)
        {
            TransferManagerOptions managerOptions = new()
            {
                ErrorHandling = DataTransferErrorMode.StopOnAnyFailure,
                CheckpointerOptions = Options.DisableCheckpointer ? TransferCheckpointStoreOptions.Disabled() : default
            };
            TransferManager transferManager = new(managerOptions);

            DataTransferOptions options = new()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
                InitialTransferSize = Options.InitialTransferSize,
                MaximumTransferChunkSize = Options.ChunkSize,
            };
            options.ItemTransferFailed += HandleFailure;
            DataTransfer transfer = await transferManager.StartTransferAsync(
                source, destination, options, cancellationToken);

            // The test runs for a specified duration and then cancels the token.
            // When canceled, pause the currently running transfer so it can be
            // cleaned up.
            cancellationToken.Register(async () =>
            {
                // Don't pass cancellation token since its already cancelled.
                await transfer.PauseAsync();
            });
            await transfer.WaitForCompletionAsync();

            if (!transfer.TransferStatus.HasCompletedSuccessfully &&
                transfer.TransferStatus.State != DataTransferState.Paused)
            {
                throw new Exception("A failure occurred during the transfer.");
            }
        }

        private Task HandleFailure(TransferItemFailedEventArgs args)
        {
            Console.WriteLine(args.Exception);
            return Task.CompletedTask;
        }
    }
}
