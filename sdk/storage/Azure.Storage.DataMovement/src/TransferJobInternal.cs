// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal abstract class TransferJobInternal
    {
        #region QueueChannelTasks
        public delegate Task QueueChunkTaskInternal(Func<Task> uploadTask);
        #endregion
        public QueueChunkTaskInternal QueueChunkTask { get; internal set; }

        /// <summary>
        /// DataTransfer communicate when the transfer has finished and the progress
        /// </summary>
        internal DataTransfer _dataTransfer { get; set; }

        /// <summary>
        /// Cancellation Token Source
        ///
        /// Will be initialized when the tasks are running.
        ///
        /// Will be disposed of once all tasks of the job have completed or have been cancelled.
        /// </summary>
        internal CancellationTokenSource _cancellationTokenSource { get; set; }

        /// <summary>
        /// Plan file writer for the respective job
        /// </summary>
        internal PlanJobWriter PlanJobWriter { get; set; }

        /// <summary>
        /// Source resource
        /// </summary>
        internal StorageResource _sourceResource;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResource _destinationResource;

        /// <summary>
        /// Source resource
        /// </summary>
        internal StorageResourceContainer _sourceResourceContainer;

        /// <summary>
        /// Destination Resource
        /// </summary>
        internal StorageResourceContainer _destinationResourceContainer;

        /// <summary>
        /// The maximum length of an transfer in bytes.
        ///
        /// On uploads, if the value is not set, it will be set at 4 MB if the total size is less than 100MB
        /// or will default to 8 MB if the total size is greater than or equal to 100MB.
        /// </summary>
        internal long? _maximumTransferChunkSize { get; set; }

        /// <summary>
        /// The size of the first range request in bytes. Single Transfer sizes smaller than this
        /// limit will be Uploaded or Downloaded in a single request.
        /// Transfers larger than this limit will continue being downloaded or uploaded
        /// in chunks of size <see cref="_maximumTransferChunkSize"/>.
        ///
        /// On Uploads, if the value is not set, it will set at 256 MB.
        /// </summary>
        internal long _initialTransferSize { get; set; }

        /// <summary>
        /// Defines whether the transfer will be only a single transfer, or
        /// a container transfer
        /// </summary>
        internal bool _isSingleResource;

        /// <summary>
        /// The error handling options
        /// </summary>
        internal ErrorHandlingOptions _errorHandling;

        /// <summary>
        /// Stores the delegates to invoke the transfer handlers
        /// </summary>
        internal TransferEventsInternal _events;

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        internal protected TransferJobInternal()
        {
        }

        internal TransferJobInternal(
            DataTransfer dataTransfer,
            long? maximumTransferChunkSize,
            long? initialTransferSize,
            QueueChunkTaskInternal queueChunkTask,
            string CheckPointFolderPath,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
        {
            _dataTransfer = dataTransfer ?? throw Errors.ArgumentNull(nameof(dataTransfer));
            _errorHandling = errorHandling;
            PlanJobWriter = new PlanJobWriter(_dataTransfer.Id, CheckPointFolderPath);
            QueueChunkTask = queueChunkTask;
            _isSingleResource = true;

            _initialTransferSize = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes;
            if (initialTransferSize.HasValue && initialTransferSize > 0)
            {
                _initialTransferSize = Math.Min(initialTransferSize.Value, Constants.Blob.Block.MaxUploadBytes);
            }
            // If the maximum chunk size is not set, we will determine the chunk size
            // based on the file length later
            if (maximumTransferChunkSize.HasValue && maximumTransferChunkSize > 0)
            {
                _maximumTransferChunkSize = Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    maximumTransferChunkSize.Value);
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _arrayPool = arrayPool;
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            SingleTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            string CheckPointFolderPath,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : this(dataTransfer,
                  transferOptions.MaximumTransferChunkSize,
                  transferOptions.InitialTransferSize,
                  queueChunkTask,
                  CheckPointFolderPath,
                  errorHandling,
                  arrayPool)
        {
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _isSingleResource = true;
            _events = new TransferEventsInternal();
            _events.InvokeTransferStatus += (args) => transferOptions?.GetTransferStatus().Invoke(args);
            _events.InvokeFailedArg += (args) => transferOptions?.GetFailed().Invoke(args);
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal TransferJobInternal(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            ContainerTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            string CheckPointFolderPath,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : this(dataTransfer,
                  transferOptions.MaximumTransferChunkSize,
                  transferOptions.InitialTransferSize,
                  queueChunkTask,
                  CheckPointFolderPath,
                  errorHandling,
                  arrayPool)
        {
            _sourceResourceContainer = sourceResource;
            _destinationResourceContainer = destinationResource;
            _isSingleResource = false;
            _events = new TransferEventsInternal();
            if (transferOptions != default)
            {
                _events.InvokeTransferStatus = (args) => transferOptions.GetTransferStatus().Invoke(args);
                _events.InvokeFailedArg = (args) => transferOptions.GetFailed().Invoke(args);
            }
        }

        /// <summary>
        /// Gets the status of the transfer job
        /// </summary>
        /// <returns>StorageTransferStatus with the value of the status of the job</returns>
        public abstract Task PauseTransferJobAsync();

        /// <summary>
        /// Resume respective job
        /// </summary>
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential"></param>
        public abstract void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default);

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public abstract IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync();

        public void TriggerJobCancellation()
        {
            if (!_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
