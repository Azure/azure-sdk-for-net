// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Test.Perf;

namespace Azure.Storage.DataMovement.Blobs.Perf
{
    public abstract class DirectoryTransferTest<TOptions> : PerfTest<TOptions> where TOptions : DirectoryTransferOptions
    {
        protected BlobServiceClient BlobServiceClient { get; }
        protected BlobsStorageResourceProvider BlobResourceProvider { get; }

        private TransferManager _transferManager;
        private TimeSpan _transferTimeout;

        public DirectoryTransferTest(TOptions options) : base(options)
        {
            BlobServiceClient = new BlobServiceClient(PerfTestEnvironment.Instance.StorageEndpoint, PerfTestEnvironment.Instance.Credential);
            BlobResourceProvider = new BlobsStorageResourceProvider(PerfTestEnvironment.Instance.Credential);
            _transferTimeout = TimeSpan.FromSeconds(Options.Duration);

            TransferManagerOptions managerOptions = new()
            {
                ErrorMode = TransferErrorMode.StopOnAnyFailure,
                CheckpointStoreOptions = Options.DisableCheckpointer ? TransferCheckpointStoreOptions.DisableCheckpoint() : default,
                MaximumConcurrency = Options.Concurrency
            };
            _transferManager = new TransferManager(managerOptions);
        }

        public override async Task CleanupAsync()
        {
            await ((IAsyncDisposable)_transferManager).DisposeAsync();
            await base.CleanupAsync();
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
                    using (Stream stream = RandomStream.Create(Options.Size))
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
            TransferOptions options = new()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists,
                InitialTransferSize = Options.InitialTransferSize,
                MaximumTransferChunkSize = Options.ChunkSize,
            };
            options.ItemTransferFailed += HandleFailure;
            TransferOperation transfer = await _transferManager.StartTransferAsync(
                source, destination, options, cancellationToken);

            // The test runs for a specified duration and then cancels the token.
            // When canceled, pause the currently running transfer so it can be cleaned up.
            cancellationToken.Register(async () =>
            {
                // Don't pass cancellation token since its already cancelled.
                await transfer.PauseAsync();
            });

            // The cancellation token we specify for WaitForCompletion should not
            // be the one passed to the test as we don't want this code to exit until
            // the transfer is complete or paused so it can be properly cleaned up.
            // However, we pass a token with a generous time to prevent the transfer
            // from hanging forever if there is an issue.
            CancellationTokenSource ctx = new(_transferTimeout);
            await transfer.WaitForCompletionAsync(ctx.Token);

            if (!transfer.Status.HasCompletedSuccessfully &&
                transfer.Status.State != TransferState.Paused)
            {
                throw new Exception("A failure occurred during the transfer.");
            }
        }

        private Task HandleFailure(TransferItemFailedEventArgs args)
        {
            Console.WriteLine($"Transfer failure event - {args.Exception}");
            return Task.CompletedTask;
        }
    }
}
