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
    /// to resume from
    /// </summary>
    public abstract class TransferCheckpointer
    {
        internal List<string> _ids;

        /// <summary>
        /// For mocking.
        /// </summary>
        protected TransferCheckpointer() { }

        /// <summary>
        /// Adds a new transfer to the checkpointer.
        ///
        /// If the transfer id already exists, this method will throw.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task TryAddTransferAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<Stream> ReadCheckPointStreamAsync(string id, int partNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Writes to the memory mapped file to store the checkpointing information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partNumber"></param>
        /// <param name="offset"></param>
        /// <param name="buffer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal abstract Task WriteToCheckpointAsync(string id, int partNumber, long offset, byte[] buffer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes transfer checkpoint information from checkpointer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<bool> TryRemoveStoredTransferAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all the transfers contained in the checkpointer.
        /// </summary>
        /// <returns></returns>
        public abstract Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default);
    }
}
