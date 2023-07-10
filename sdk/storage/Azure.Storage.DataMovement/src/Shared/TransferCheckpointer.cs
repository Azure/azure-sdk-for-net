// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models.JobPlan;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Base Checkpointer class to create the checkpointing logic
    /// to resume from.
    /// </summary>
    internal abstract class TransferCheckpointer
    {
        /// <summary>
        /// The protected constructor for the abstract TransferCheckpointer class (to allow for mocking).
        /// </summary>
        protected TransferCheckpointer()
        {
        }

        /// <summary>
        /// Adds a new transfer to the checkpointer.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task AddNewJobAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new transfer job part to the checkpointer.
        ///
        /// If the transfer ID already exists, this method will throw an exception.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="chunksTotal">The total chunks for the part.</param>
        /// <param name="headerStream">A <see cref="Stream"/> to the job part plan header.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            int chunksTotal,
            Stream headerStream,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Add existing job to the checkpointer with verification. This function will throw
        /// if no existing job plan files exist in the checkpointer, and the job plan files have
        /// mismatch information from the information to resume from.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task AddExistingJobAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the current number of chunk counts stored in the job part with the
        /// respective transfer id.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>The number of chunks in the job part.</returns>
        public abstract Task<int> CurrentJobPartCountAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="offset">The offset of the current transfer.</param>
        /// <param name="readSize">
        /// The size of how many bytes to read.
        /// Specify 0 (zero) to create a stream that ends approximately at the end of the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>The Stream to the checkpoint of the respective job ID and part number.</returns>
        public abstract Task<Stream> ReadableStreamAsync(
            string transferId,
            int partNumber,
            long offset,
            long readSize,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Writes to the memory mapped file to store the checkpointing information.
        ///
        /// Creates the file for the respective ID if it does not currently exist.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="offset">The offset of the current transfer.</param>
        /// <param name="buffer">The buffer to write data from to the checkpoint.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns></returns>
        public abstract Task WriteToCheckpointAsync(
            string transferId,
            int partNumber,
            long offset,
            byte[] buffer,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the Job Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="status">The <see cref="StorageTransferStatus"/> of the job.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task SetJobTransferStatusAsync(
            string transferId,
            StorageTransferStatus status,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the Job Part Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="status">The <see cref="StorageTransferStatus"/> of the job part.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task SetJobPartTransferStatusAsync(
            string transferId,
            int partNumber,
            StorageTransferStatus status,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes transfer checkpoint information from checkpointer.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>Returns a bool that is true if operation is successful, otherwise is false.</returns>
        public abstract Task<bool> TryRemoveStoredTransferAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all the transfers contained in the checkpointer.
        /// </summary>
        /// <returns>The list of all the transfers contained in the checkpointer.</returns>
        public abstract Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default);
    }
}
