// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for Checkpointer used for saving transfer state to allow for
    /// resuming a transfer.
    /// </summary>
    public class TransferCheckpointStoreOptions
    {
        /// <summary>
        /// The local folder where the checkpoint information will be stored.
        /// </summary>
        public string CheckpointerPath { get; private set; }

        /// <summary>
        /// Sets the checkpointer options to use a Local Checkpointer where
        /// the checkpoint information is stored at a local folder.
        /// </summary>
        /// <param name="localCheckpointerPath">
        /// The local folder where the checkpoint information will be stored.
        /// </param>
        public TransferCheckpointStoreOptions(string localCheckpointerPath)
        {
            CheckpointerPath = localCheckpointerPath;
        }

        internal TransferCheckpointStoreOptions(TransferCheckpointStoreOptions options)
        {
            CheckpointerPath = options.CheckpointerPath;
        }
    }
}
