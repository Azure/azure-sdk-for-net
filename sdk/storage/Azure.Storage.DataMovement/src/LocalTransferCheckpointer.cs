// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;
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
        /// Stores references to the memory mapped files stored by ids
        /// </summary>
        internal Dictionary<string, MemoryMappedPlanFile> _memoryMappedFiles;

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
            if (_memoryMappedFiles.TryGetValue(id, out MemoryMappedPlanFile idMappedFile))
            {
                return Task.FromResult<Stream>(idMappedFile.MemoryMappedFileReference.CreateViewStream());
            }
            else
            {
                throw new ArgumentException($"Checkpointer information from Transfer id {id}, was not found. Cannot read from plan file");
            }
        }

        /// <summary>
        /// Writes to the checkpointer to the stored memory checkpointing information.
        ///
        /// Creates the checkpoint file for the respective id if it does not currently exist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="offset"></param>
        /// <param name="buffer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public override async Task WriteToCheckpointAsync(string id, long offset, byte[] buffer, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            if (buffer?.Length == 0)
            {
                throw new ArgumentException("Buffer cannot be null or empty");
            }

            if (!_memoryMappedFiles.ContainsKey(id))
            {
                // Memory mapped file does not yet exist.
                MemoryMappedPlanFile idMappedFile = new MemoryMappedPlanFile(id);
                _memoryMappedFiles.Add(id, idMappedFile);
            }
            await _memoryMappedFiles[id].Semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

            using (MemoryMappedViewAccessor accessor = _memoryMappedFiles[id].MemoryMappedFileReference
                .CreateViewAccessor(offset, buffer.Length, MemoryMappedFileAccess.Write))
            {
                accessor.WriteArray(0, buffer, 0, buffer.Length);
            }
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
