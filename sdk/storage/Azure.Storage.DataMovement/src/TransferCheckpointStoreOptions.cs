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
        /// Whether checkpointing should be enabled or not.
        /// </summary>
        internal bool Enabled { get; private set; }

        /// <summary>
        /// The folder where the checkpoint information will be stored.
        /// </summary>
        internal string CheckpointerPath { get; private set; }

        /// <summary>
        /// Sets the checkpoint options to disable transfer checkpointing.
        /// <para>NOTE: All pause/resume functionality will be disabled.</para>
        /// </summary>
        /// <returns></returns>
        public static TransferCheckpointStoreOptions Disabled()
        {
            return new TransferCheckpointStoreOptions(false, default);
        }

        /// <summary>
        /// Sets the checkpointer options to use a Local Checkpointer where
        /// the checkpoint information is stored at a local folder.
        /// </summary>
        /// <param name="localCheckpointerPath">
        /// The local folder where the checkpoint information will be stored.
        /// </param>
        public static TransferCheckpointStoreOptions Local(string localCheckpointerPath)
        {
            return new TransferCheckpointStoreOptions(true, localCheckpointerPath);
        }

        internal TransferCheckpointStoreOptions(bool enabled, string localCheckpointerPath)
        {
            Enabled = enabled;
            CheckpointerPath = localCheckpointerPath;
        }
    }
}
