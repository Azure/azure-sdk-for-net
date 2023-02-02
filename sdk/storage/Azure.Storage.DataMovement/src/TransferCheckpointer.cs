// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
        internal List<string> _ids;

        /// <summary>
        /// The protected constructor for the abstract TransferCheckpointer class (to allow for mocking).
        /// </summary>
        protected TransferCheckpointer() { }

        /// <summary>
        /// Adds a new transfer to the checkpointer and returns the associated
        /// DataTransfer object to go with it.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public abstract Task<DataTransfer> AddNewTransferAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <param name="id">The transfer ID.</param>
        /// <param name="partNumber">The part number of the current transfer.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The Stream to the checkpoint of the respective job ID and part number.</returns>
        public abstract Task<Stream> OpenReadCheckPointStreamAsync(string id, int partNumber, CancellationToken cancellationToken = default);

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
    }
}
