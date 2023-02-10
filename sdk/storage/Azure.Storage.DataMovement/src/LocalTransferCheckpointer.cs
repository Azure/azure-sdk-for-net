// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
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
    internal class LocalTransferCheckpointer : TransferCheckpointer
    {
        internal string _pathToCheckpointer;
        /// <summary>
        /// Stores references to the memory mapped files stored by IDs.
        /// </summary>
        internal Dictionary<string, Dictionary<int, MemoryMappedPlanFile>> _memoryMappedFiles;

        /// <summary>
        /// Initializes a new instance of <see cref="LocalTransferCheckpointer"/> class.
        /// </summary>
        /// <param name="folderPath">Path to the folder containing the checkpointing information to resume from.</param>
        public LocalTransferCheckpointer(string folderPath)
        {
            Argument.CheckNotNullOrEmpty(folderPath, nameof(folderPath));
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"The following directory path, \"{folderPath}\" was not found.");
            }
            FileAttributes attributes = File.GetAttributes(folderPath);
            if (attributes != FileAttributes.Directory)
            {
                throw new DirectoryNotFoundException($"The following directory path, \"{folderPath}\" was not found not to have the attributes of a Directory but of ${attributes}");
            }
            _pathToCheckpointer = folderPath;

            _memoryMappedFiles = new Dictionary<string, Dictionary<int, MemoryMappedPlanFile>>();
        }

        /// <summary>
        /// Adds a new transfer to the checkpointer.
        ///
        /// If the transfer ID already exists, this method will throw an exception.
        /// </summary>
        /// <param name="id">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public override Task TryAddTransferAsync(string id, CancellationToken cancellationToken = default)
        {
            if (!_memoryMappedFiles.ContainsKey(id))
            {
                // Create empty list of memory mapped job parts
                Dictionary<int, MemoryMappedPlanFile> tempJobParts = new Dictionary<int, MemoryMappedPlanFile>();
                _memoryMappedFiles.Add(id, tempJobParts);
            }
            else
            {
                throw new ArgumentException($"Transfer id {id} already has existing checkpoint information associated with the id. Consider cleaning out where the transfer information is stored.");
            }
            return Task.CompletedTask;
        }

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
        public override Task<Stream> ReadCheckPointStreamAsync(
            string id,
            int partNumber,
            CancellationToken cancellationToken = default)
        {
            if (_memoryMappedFiles.TryGetValue(id, out Dictionary<int, MemoryMappedPlanFile> jobPartFiles))
            {
                if (!jobPartFiles.ContainsKey(partNumber))
                {
                    throw new ArgumentException($"Checkpointer information from Transfer id \"{id}\", at part number \"{partNumber}\" was not found. Cannot read from plan file");
                }
                return Task.FromResult<Stream>(jobPartFiles[partNumber].MemoryMappedFileReference.CreateViewStream());
            }
            else
            {
                throw new ArgumentException($"Checkpointer information from Transfer id \"{id}\", at part number \"{partNumber}\" was not found. Cannot read from plan file");
            }
        }

        /// <summary>
        /// Writes to the checkpointer and stores the checkpointing information.
        ///
        /// Creates the checkpoint file for the respective ID if it does not currently exist.
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
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal override async Task WriteToCheckpointAsync(
            string id,
            int partNumber,
            long offset,
            byte[] buffer,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotDefault(ref partNumber, nameof(partNumber));
            if (buffer?.Length == 0)
            {
                throw new ArgumentException("Buffer cannot be empty");
            }
            if (_memoryMappedFiles.TryGetValue(id, out Dictionary<int, MemoryMappedPlanFile> jobPartFiles))
            {
                if (!jobPartFiles.ContainsKey(partNumber))
                {
                    MemoryMappedPlanFile mappedFile = new MemoryMappedPlanFile(id, partNumber);
                    _memoryMappedFiles[id].Add(partNumber, mappedFile);
                }
                else
                {
                    // partNumber file already exists
                    // lock file
                    await _memoryMappedFiles[id][partNumber].Semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                    using (MemoryMappedViewAccessor accessor = _memoryMappedFiles[id][partNumber].MemoryMappedFileReference
                    .CreateViewAccessor(offset, buffer.Length, MemoryMappedFileAccess.Write))
                    {
                        accessor.WriteArray(0, buffer, 0, buffer.Length);
                        // to flush to the underlying file that supports the mmf
                        accessor.Flush();
                    }
                    // unlock file
                    _memoryMappedFiles[id][partNumber].Semaphore.Release();
                }
            }
            else
            {
                throw new ArgumentException($"Checkpointer information from Transfer id \"{id}\" was not found. Call TryAddTransferAsync before attempting to add transfer information");
            }
        }

        /// <summary>
        /// Removes transfer information of the respective IDs.
        /// </summary>
        /// <param name="id">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns a bool that is true if operation is successful, otherwise is false.</returns>
        public override Task<bool> TryRemoveStoredTransferAsync(string id, CancellationToken cancellationToken = default)
        {
            bool result = true;
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            if (!_memoryMappedFiles.TryGetValue(id, out Dictionary<int, MemoryMappedPlanFile> jobPartFiles))
            {
                throw new ArgumentException($"Checkpointer information from Transfer id \"{id}\" was not found. Call TryAddTransferAsync before attempting to add transfer information");
            }
            foreach (MemoryMappedPlanFile jobPartPair in jobPartFiles.Values)
            {
                try
                {
                    File.Delete(jobPartPair.FilePath);
                }
                catch (FileNotFoundException)
                {
                    // If we cannot find the file, it's either we deleted
                    // we have not created this job part yet.
                }
                catch
                {
                    // If we run into an issue attempting to delete we should
                    // keep track that we could not at least delete one of files
                    // TODO: change return type to better show which files we
                    // were unable to remove
                    result = false;
                }
            }
            return Task.FromResult(result);
        }

        /// <summary>
        /// Lists all the transfers contained in the checkpointer.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The list of all the transfers contained in the checkpointer.</returns>
        public override Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_memoryMappedFiles.Keys.ToList());
        }
    }
}
