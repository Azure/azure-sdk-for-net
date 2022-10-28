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
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <returns></returns>
        public abstract Task<Stream> ReadCheckPointStreamAsync(string id);

        /// <summary>
        /// Writes to the memory mapped file to store the checkpointing information.
        /// </summary>
        /// <returns></returns>
        public abstract Task WriteToCheckpointAsync(string id, long offset, byte[] buffer, CancellationToken cancellationToken);

        /// <summary>
        /// Removes transfer checkpoint information from checkpointer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task<bool> TryRemoveStoredTransferAsync(string id);

        /// <summary>
        /// Lists all the transfers contained in the checkpointer.
        /// </summary>
        /// <returns></returns>
        public abstract Task<List<string>> GetStoredTransfersAsync();
    }
}
