// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Base Checkpointer class to create the checkpointing logic
    /// to resume from.
    /// </summary>
    public abstract class TransferCheckpointer
    {
        /// <summary>
        /// The protected constructor for the abstract TransferCheckpointer class (to allow for mocking).
        /// </summary>
        protected TransferCheckpointer()
        {
        }

        /// <summary>
        /// Adds a new transfer to the checkpointer and returns the associated
        /// DataTransfer object to go with it.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public abstract Task AddNewJobAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new transfer to the checkpointer.
        ///
        /// If the transfer ID already exists, this method will throw an exception.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="partNumber"></param>
        /// <param name="chunksTotal"></param>
        /// <param name="headerStream"></param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
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
        /// <param name="transferId"></param>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task AddExistingJobAsync(
            string transferId,
            string sourcePath,
            string destinationPath,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the current number of chunk counts stored in the job part with the
        /// respective transfer id.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract int CurrentJobPartCount(
            string transferId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <param name="id">The transfer ID.</param>
        /// <param name="partNumber">The part number of the current transfer.</param>
        /// <param name="offset">The offset of the current transfer.</param>
        /// <param name="readSize">
        /// The size of how many bytes to read.
        /// Specify 0 (zero) to create a stream that ends approximately at the end of the file.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The Stream to the checkpoint of the respective job ID and part number.</returns>
        public abstract Task<Stream> ReadableStreamAsync(string id, int partNumber, long offset, long readSize, CancellationToken cancellationToken = default);

        /// <summary>
        /// Writes to the memory mapped file to store the checkpointing information.
        /// </summary>
        /// <param name="id">The transfer ID.</param>
        /// <param name="partNumber">The part number of the current transfer.</param>
        /// <param name="offset">The offset of the current transfer.</param>
        /// <param name="buffer">The buffer to write data from to the checkpoint.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public abstract Task WriteToCheckpointAsync(string id, int partNumber, long offset, byte[] buffer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the Job Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="status"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task SetJobTransferStatus(
            string transferId,
            StorageTransferStatus status,
            CancellationToken cancellationToken);

        /// <summary>
        /// Sets the Job Part Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="partNumber"></param>
        /// <param name="status"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task SetJobPartTransferStatus(
            string transferId,
            int partNumber,
            StorageTransferStatus status,
            CancellationToken cancellationToken);

        /// <summary>
        /// Removes transfer checkpoint information from checkpointer.
        /// </summary>
        /// <param name="id">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns a bool that is true if operation is successful, otherwise is false.</returns>
        public abstract Task<bool> TryRemoveStoredTransferAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all the transfers contained in the checkpointer.
        /// </summary>
        /// <returns>The list of all the transfers contained in the checkpointer.</returns>
        public abstract Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Compares the job plan header with the inputted source and destination to
        /// ensure the source and destination are the same, or else throw.
        /// </summary>
        internal static void CheckInputWithHeader(
            string sourcePath,
            string destinationPath,
            string transferId,
            JobPartPlanHeader header)
        {
            string schemaVersion = Encoding.UTF8.GetString(header.Version);
            if (!DataMovementConstants.PlanFile.SchemaVersion.Equals(schemaVersion))
            {
                throw Errors.MismatchSchemaVersion(schemaVersion);
            }

            if (!header.TransferId.Equals(transferId))
            {
                throw Errors.MismatchTransferId(transferId, header.TransferId);
            }

            string sourcePathHeader = Encoding.UTF8.GetString(header.SourceRoot);
            if (!sourcePathHeader.Equals(sourcePath))
            {
                throw Errors.MismatchStorageResource(nameof(sourcePath), sourcePath, sourcePathHeader);
            }
            string destinationPathHeader = Encoding.UTF8.GetString(header.DestinationRoot);
            if (!destinationPathHeader.Equals(destinationPath))
            {
                throw Errors.MismatchStorageResource(nameof(destinationPath), destinationPath, destinationPathHeader);
            }
        }
    }
}
