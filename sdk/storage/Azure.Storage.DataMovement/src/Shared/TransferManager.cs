// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
using System.Buffers;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Base class for data cotnroller
    /// </summary>
    public class TransferManager
    {
        // Indicates whether the current thread is processing Jobs.
        private static Task _currentTaskIsProcessingJob;

        // Indicates whether the current thread is processing Jobs Parts.
        private static Task _currentTaskIsProcessingJobPart;

        // Indicates whether the current thread is processing Jobs Chunks.
        private static Task _currentTaskIsProcessingJobChunk;

        /// <summary>
        /// Channel of Jobs waiting to divided into job parts/files.
        ///
        /// Limit 1 task to convert jobs to job parts.
        /// </summary>
        private Channel<TransferJobInternal> _jobsToProcessChannel { get; set; }

        /// <summary>
        /// Channel of Job parts / files to be divided into chunks / requests
        ///
        /// Limit 64 tasks to convert job parts to chunks.
        /// </summary>
        private Channel<JobPartInternal> _partsToProcessChannel { get; set; }

        /// <summary>
        /// Channel of Job chunks / requests to send to the service.
        ///
        /// Limit 4-300/Max amount of tasks allowed to process chunks
        /// </summary>
        private Channel<Func<Task>> _chunksToProcessChannel { get; set; }

        /// <summary>
        /// This value can fluctuate depending on if we've reached max capacity
        /// Future capability for it to flucate based on throttling and bandwidth
        /// </summary>
        internal int _maxJobChunkTasks;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private TransferManagerOptions _options;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        internal TransferManagerOptions Options => _options;

        /// <summary>
        /// Ongoing transfers
        /// </summary>
        internal List<DataTransfer> _dataTransfers;

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        internal ArrayPool<byte> UploadArrayPool => _arrayPool;
        private ArrayPool<byte> _arrayPool;

        /// <summary>
        /// Constructor
        /// </summary>
        protected TransferManager()
        { }

        /// <summary>
        /// Constructor to create a DataController
        /// </summary>
        /// <param name="options"></param>
        public TransferManager(TransferManagerOptions options)
        {
            _jobsToProcessChannel = Channel.CreateUnbounded<TransferJobInternal>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                    SingleReader = true, // To limit the task of processing one job at a time.
                    // Allow single writers
                });
            _partsToProcessChannel = Channel.CreateUnbounded<JobPartInternal>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                });
            _chunksToProcessChannel = Channel.CreateUnbounded<Func<Task>>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                });
            _currentTaskIsProcessingJob = Task.Run(() => NotifyOfPendingJobProcessing());
            _currentTaskIsProcessingJobPart = Task.Run(() => NotifyOfPendingJobPartProcessing());
            _currentTaskIsProcessingJobChunk = Task.Run(() => NotifyOfPendingJobChunkProcessing());
            _options = options == default ? new TransferManagerOptions() : options;
            _maxJobChunkTasks = options?.MaximumConcurrency ?? Constants.DataMovement.MaxJobChunkTasks;
            _dataTransfers = new List<DataTransfer>();
            _arrayPool = ArrayPool<byte>.Shared;
        }

        #region Job Channel Management
        internal async Task QueueJobAsync(TransferJobInternal job)
        {
            await _jobsToProcessChannel.Writer.WriteAsync(job).ConfigureAwait(false);
        }

        // Inform the Reader that there's work to be executed for this Channel.
        private async Task NotifyOfPendingJobProcessing()
        {
            // Process all available items in the queue.
            while (await _jobsToProcessChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                TransferJobInternal item = await _jobsToProcessChannel.Reader.ReadAsync().ConfigureAwait(false);
                // Execute the task we pulled out of the queue
                await foreach (JobPartInternal partItem in item.ProcessJobToJobPartAsync().ConfigureAwait(false))
                {
                    await QueueJobPartAsync(partItem).ConfigureAwait(false);
                }
            }
        }
        #endregion Job Channel Management

        #region Job Part Channel Management
        internal async Task QueueJobPartAsync(JobPartInternal part)
        {
            await _partsToProcessChannel.Writer.WriteAsync(part).ConfigureAwait(false);
        }

        // Inform the Reader that there's work to be executed for this Channel.
        private async Task NotifyOfPendingJobPartProcessing()
        {
            List<Task> chunkRunners = new List<Task>(Constants.DataMovement.MaxJobPartReaders);
            while (await _partsToProcessChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                JobPartInternal item = await _partsToProcessChannel.Reader.ReadAsync().ConfigureAwait(false);
                if (chunkRunners.Count >= Constants.DataMovement.MaxJobPartReaders)
                {
                    // Clear any completed blocks from the task list
                    int removedRunners = chunkRunners.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    // If no runners have finished..
                    if (removedRunners == 0)
                    {
                        // Wait for at least one runner to finish
                        await Task.WhenAny(chunkRunners).ConfigureAwait(false);
                        chunkRunners.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                }
                // Execute the task we pulled out of the queue
                item.SetQueueChunkDelegate(async (item) => await QueueJobChunkAsync(item).ConfigureAwait(false));
                Task task = item.ProcessPartToChunkAsync();

                // Add task to Chunk Runner to keep track of how many are running
                chunkRunners.Add(task);
            }
        }
        #endregion Job Part Channel Management

        #region Job Chunk Management
        internal async Task QueueJobChunkAsync(Func<Task> item)
        {
            await _chunksToProcessChannel.Writer.WriteAsync(item).ConfigureAwait(false);
        }

        private async Task NotifyOfPendingJobChunkProcessing()
        {
            List<Task> _currentChunkTasks = new List<Task>(Constants.DataMovement.MaxJobChunkTasks);
            while (await _chunksToProcessChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                Func<Task> item = await _chunksToProcessChannel.Reader.ReadAsync().ConfigureAwait(false);
                // If we run out of workers
                if (_currentChunkTasks.Count >= _maxJobChunkTasks)
                {
                    if (_currentChunkTasks.Exists(x => x.IsCompleted || x.IsCanceled || x.IsFaulted))
                    {
                        // Clear any completed blocks from the task list
                        _currentChunkTasks.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                    else
                    {
                        await Task.WhenAny(_currentChunkTasks).ConfigureAwait(false);
                        _currentChunkTasks.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                }

                // Execute the task we pulled out of the queue
                Task task = Task.Run(item);
                _currentChunkTasks.Add(task);
            }
        }
        #endregion Job Chunk Management

        #region Transfer Job Management
        /// <summary>
        /// Attempts to pause the transfer of the respective id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> TryPauseTransferAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attempts to all the ongoing transfers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> TryPauseAllTransfersAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attempts to remove the transfer of the respective id. Will remove it does exist and has not completed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> TryRemoveTransferAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion Transfer Job Management

        #region Start Transfer

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="transferOptions"></param>
        /// <returns></returns>
        public async Task<DataTransfer> StartTransferAsync(
            StorageResource sourceResource,
            StorageResource destinationResource,
            SingleTransferOptions transferOptions = default)
        {
            if (sourceResource == default)
            {
                throw Errors.ArgumentNull(nameof(sourceResource));
            }
            if (destinationResource == default)
            {
                throw Errors.ArgumentNull(nameof(destinationResource));
            }

            transferOptions = transferOptions == default ? new SingleTransferOptions() : transferOptions;

            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            DataTransfer dataTransfer = new DataTransfer();
            TransferJobInternal transferJobInternal;
            if (sourceResource.CanProduceUri == ProduceUriType.NoUri)
            {
                if (destinationResource.CanProduceUri == ProduceUriType.ProducesUri)
                {
                    // Stream to Uri job (Upload Job)
                    transferJobInternal = new StreamToUriTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        queueChunkTask: QueueJobChunkAsync,
                        CheckPointFolderPath: Options?.Checkpointer,
                        errorHandling: Options?.ErrorHandling ?? ErrorHandlingOptions.StopOnAllFailures,
                        arrayPool: _arrayPool);
                    // Queue Job
                    await QueueJobAsync(transferJobInternal).ConfigureAwait(false);
                    _dataTransfers.Add(dataTransfer);
                }
                else // Invalid argument that both resources do not produce a Uri
                {
                    throw Errors.InvalidSourceDestinationParams();
                }
            }
            else if (sourceResource.CanProduceUri == ProduceUriType.ProducesUri)
            {
                // Source is remote
                if (destinationResource.CanProduceUri == ProduceUriType.ProducesUri)
                {
                    // Most likely a copy operation.
                    throw new NotImplementedException();
                }
                else
                {
                    // Download to local operation
                    // BlobDownloadJob();
                    throw new NotImplementedException();
                }
            }
            return dataTransfer;
        }

        /// <summary>
        /// Intiate transfer
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="transferOptions"></param>
        /// <returns></returns>
        public async Task<DataTransfer> StartTransferAsync(
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            ContainerTransferOptions transferOptions = default)
        {
            if (sourceResource == default)
            {
                throw Errors.ArgumentNull(nameof(sourceResource));
            }
            if (destinationResource == default)
            {
                throw Errors.ArgumentNull(nameof(destinationResource));
            }

            transferOptions = transferOptions == default ? new ContainerTransferOptions() : transferOptions;

            // If the resource cannot produce a Uri, it means it can only produce a local path
            // From here we only support an upload job
            DataTransfer dataTransfer = new DataTransfer();
            TransferJobInternal transferJobInternal;
            if (sourceResource.CanProduceUri == ProduceUriType.NoUri)
            {
                if (destinationResource.CanProduceUri == ProduceUriType.ProducesUri)
                {
                    // Stream to Uri job (Upload Job)
                    transferJobInternal = new StreamToUriTransferJob(
                        dataTransfer: dataTransfer,
                        sourceResource: sourceResource,
                        destinationResource: destinationResource,
                        transferOptions: transferOptions,
                        queueChunkTask: QueueJobChunkAsync,
                        checkpointer:Options?.Checkpointer,
                        errorHandling: Options?.ErrorHandling ?? ErrorHandlingOptions.StopOnAllFailures,
                        arrayPool: _arrayPool);
                    // Queue Job
                    await QueueJobAsync(transferJobInternal).ConfigureAwait(false);
                    _dataTransfers.Add(dataTransfer);
                }
                else // Invalid argument that both resources do not produce a Uri
                {
                    throw Errors.InvalidSourceDestinationParams();
                }
            }
            else if (sourceResource.CanProduceUri == ProduceUriType.ProducesUri)
            {
                // Source is remote
                if (destinationResource.CanProduceUri == ProduceUriType.ProducesUri)
                {
                    // Most likely a copy operation.
                    throw new NotImplementedException();
                }
                else
                {
                    // Download to local operation
                    // BlobDownloadJob();
                    throw new NotImplementedException();
                }
            }
            return dataTransfer;
        }
        #endregion
    }
}
