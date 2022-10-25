// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Creates a checkpointer which uses a locally stored file to obtain
    /// the information in order to resume transfers in the future.
    /// </summary>
    public class LocalTransferCheckpointer : TransferCheckpointer
    {
        internal string _pathToCheckpointer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="folderPath">Path to the file containing the checkpointing information to resume from.</param>
        public LocalTransferCheckpointer(string folderPath)
        {
            Argument.CheckNotNullOrEmpty(folderPath, nameof(folderPath));
            if (!Directory.Exists(_pathToCheckpointer))
            {
                throw new IOException($"Cannot find local path, \"{_pathToCheckpointer}\" to access to checkpoint information.");
            }
            _pathToCheckpointer = folderPath;
        }

        /// <summary>
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<Stream> ReadCheckPointStreamAsync(string id)
        {
            // TODO: Replace to open with MMF
            return Task.FromResult<Stream>(File.OpenRead(_pathToCheckpointer));
        }

        /// <summary>
        /// Writes to the checkpointer to the stored memory checkpointing information.
        ///
        /// Creates the checkpoint file for the respective id if it does not currently exist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="offset"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task WriteToCheckpointAsync(string id, long offset, byte[] buffer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes transfer information of the respective id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<bool> TryRemoveStoredTransferAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists all the transfers contained in the checkpointer.
        /// </summary>
        /// <returns></returns>
        public override Task<List<string>> GetStoredTransfersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
