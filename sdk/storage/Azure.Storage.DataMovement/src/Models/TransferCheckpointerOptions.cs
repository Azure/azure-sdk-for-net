// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Options for Checkpointer used for saving transfer state to allow for
    /// resuming a transfer.
    /// </summary>
    public class TransferCheckpointerOptions
    {
        internal string checkpointerPath;

        /// <summary>
        /// Sets the checkpointer options to use a Local Checkpointer where
        /// the checkpoint information is stored at a local folder.
        /// </summary>
        /// <param name="localCheckpointerPath">
        /// The local folder where the checkpoint information will be stored.
        /// </param>
        public TransferCheckpointerOptions(string localCheckpointerPath)
        {
            checkpointerPath = localCheckpointerPath;
        }

        /// <summary>
        /// Checks the specified checkpointer type the user specified in
        /// order to create the respective checkpointer.
        ///
        /// By default a local folder will be used to store the job transfer files
        /// and a <see cref="LocalTransferCheckpointer"/> will be used.
        /// </summary>
        /// <returns>
        /// A <see cref="TransferCheckpointer"/> as specified by the user will be
        /// returned.
        ///
        /// If no checkpointer type is specified by
        /// default a <see cref="LocalTransferCheckpointer"/> using the folder
        /// where the application is stored with and making a new folder called
        /// .azstoragedml to store all the job plan files.
        /// </returns>
        internal TransferCheckpointer CreateTransferCheckpointer()
        {
            if (!string.IsNullOrEmpty(checkpointerPath))
            {
                return new LocalTransferCheckpointer(checkpointerPath);
            }
            else
            {
                // Default TransferCheckpointer
                return new LocalTransferCheckpointer(default);
            }
        }
    }
}
