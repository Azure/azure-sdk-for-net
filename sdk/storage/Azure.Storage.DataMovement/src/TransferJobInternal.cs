﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        #region Delegates
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
        internal TransferCheckpointer _checkpointer { get; set; }

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
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferStatusEventArgs> TransferStatusEventHandler { get; internal set; }

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public SyncAsyncEventHandler<TransferFailedEventArgs> TransferFailedEventHandler { get; internal set; }

        /// <summary>
        /// Array pools for reading from streams to upload
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        public List<JobPartInternal> _jobParts;

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
            TransferCheckpointer checkPointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool,
            SyncAsyncEventHandler<TransferStatusEventArgs> statusEventHandler,
            SyncAsyncEventHandler<TransferFailedEventArgs> failedEventHandler)
        {
            _dataTransfer = dataTransfer ?? throw Errors.ArgumentNull(nameof(dataTransfer));
            _errorHandling = errorHandling;
            _checkpointer = checkPointer;
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
            _jobParts = new List<JobPartInternal>();

            TransferStatusEventHandler = statusEventHandler;
            TransferFailedEventHandler = failedEventHandler;
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
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : this(dataTransfer,
                  transferOptions.MaximumTransferChunkSize,
                  transferOptions.InitialTransferSize,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed())
        {
            _sourceResource = sourceResource;
            _destinationResource = destinationResource;
            _isSingleResource = true;
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
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : this(dataTransfer,
                  transferOptions.MaximumTransferChunkSize,
                  transferOptions.InitialTransferSize,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  transferOptions.GetTransferStatus(),
                  transferOptions.GetFailed())
        {
            _sourceResourceContainer = sourceResource;
            _destinationResourceContainer = destinationResource;
            _isSingleResource = false;
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
