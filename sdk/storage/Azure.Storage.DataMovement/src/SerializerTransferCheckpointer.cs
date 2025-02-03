// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Base Checkpointer class to create the checkpointing logic
    /// to resume from.
    /// </summary>
    internal abstract class SerializerTransferCheckpointer : ITransferCheckpointer
    {
        /// <summary>
        /// The protected constructor for the abstract TransferCheckpointer class (to allow for mocking).
        /// </summary>
        protected SerializerTransferCheckpointer()
        {
        }

        /// <summary>
        /// Adds a new transfer to the checkpointer.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="source">The source resource.</param>
        /// <param name="destination">The destination resource.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task AddNewJobAsync(
            string transferId,
            StorageResource source,
            StorageResource destination,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new transfer job part to the checkpointer.
        ///
        /// If the transfer ID already exists, this method will throw an exception.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="header">A <see cref="Stream"/> to the job part plan header.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            JobPartPlanHeader header,
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
        /// Reads the specified part of the job plan file and returns it in a Stream.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="offset">The offset to start reading the job plan file at.</param>
        /// <param name="length">
        /// The maximum number of bytes to read.
        /// Specify 0 (zero) to create a stream over teh whole file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>A Stream of the requested part of the Job Plan File.</returns>
        public abstract Task<Stream> ReadJobPlanFileAsync(
            string transferId,
            int offset,
            int length,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Reads the specified part of the job part plan file and returns it in a Stream.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="offset">The offset to start reading the job part plan file at.</param>
        /// <param name="length">
        /// The size of how many bytes to read.
        /// Specify 0 (zero) to create a stream that ends approximately at the end of the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        /// <returns>The Stream to the checkpoint of the respective job ID and part number.</returns>
        public abstract Task<Stream> ReadJobPartPlanFileAsync(
            string transferId,
            int partNumber,
            int offset,
            int length,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Writes to the job plan file at the given offset.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="fileOffset">The offset into the job plan file to start writing at.</param>
        /// <param name="buffer">The data to write.</param>
        /// <param name="bufferOffset">The offset into the given buffer to start reading from.</param>
        /// <param name="length">The length of data to read from the buffer and write to the job plan file.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task WriteToJobPlanFileAsync(
            string transferId,
            int fileOffset,
            byte[] buffer,
            int bufferOffset,
            int length,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the Job Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="status">The <see cref="TransferStatus"/> of the job.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task SetJobTransferStatusAsync(
            string transferId,
            TransferStatus status,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the Job Part Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The job part number.</param>
        /// <param name="status">The <see cref="TransferStatus"/> of the job part.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be canceled.
        /// </param>
        public abstract Task SetJobPartTransferStatusAsync(
            string transferId,
            int partNumber,
            TransferStatus status,
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

        Task<bool> ITransferCheckpointer.IsEnumerationCompleteAsync(string transferId, CancellationToken cancellationToken)
            => CheckpointerExtensions.IsEnumerationCompleteAsync(this, transferId, cancellationToken);

        Task ITransferCheckpointer.SetEnumerationCompleteAsync(string transferId, CancellationToken cancellationToken)
            => CheckpointerExtensions.OnEnumerationCompleteAsync(this, transferId, cancellationToken);

        Task<int> ITransferCheckpointer.GetCurrentJobPartCountAsync(string transferId, CancellationToken cancellationToken)
            => this.CurrentJobPartCountAsync(transferId, cancellationToken);

        Task<TransferStatus> ITransferCheckpointer.GetJobStatusAsync(string transferId, CancellationToken cancellationToken)
            => CheckpointerExtensions.GetJobStatusAsync(this, transferId, cancellationToken);

        Task<TransferProperties> ITransferCheckpointer.GetTransferPropertiesAsync(string transferId, CancellationToken cancellationToken)
            => CheckpointerExtensions.GetTransferPropertiesAsync(this, transferId, cancellationToken);

        async Task<JobPartPlanHeader> ITransferCheckpointer.GetJobPartAsync(string transferId, int partNumber, CancellationToken cancellationToken)
        {
            using Stream stream = await ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                length: 0,
                cancellationToken: cancellationToken).ConfigureAwait(false);
           return JobPartPlanHeader.Deserialize(stream);
        }

        Task ITransferCheckpointer.SetJobStatusAsync(string transferId, TransferStatus status, CancellationToken cancellationToken)
        {
            return this.SetJobTransferStatusAsync(transferId, status, cancellationToken);
        }

        Task ITransferCheckpointer.SetJobPartStatusAsync(string transferId, int partNumber, TransferStatus status, CancellationToken cancellationToken)
        {
            return this.SetJobPartTransferStatusAsync(transferId, partNumber, status, cancellationToken);
        }
    }
}
