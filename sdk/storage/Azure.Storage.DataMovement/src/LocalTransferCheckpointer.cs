// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.JobPlanModels;

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
        /// Stores references to the memory mapped files stored by IDs.
        /// </summary>
        internal Dictionary<string, Dictionary<int, JobPartPlanFile>> _transferStates;

        /// <summary>
        /// Initializes a new instance of <see cref="LocalTransferCheckpointer"/> class.
        /// </summary>
        /// <param name="folderPath">Path to the folder containing the checkpointing information to resume from.</param>
        public LocalTransferCheckpointer(string folderPath = default)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                _pathToCheckpointer = Path.Combine(Environment.CurrentDirectory, "/", DataMovementConstants.DefaultCheckpointerPath);
                if (!Directory.Exists(_pathToCheckpointer))
                {
                    // If it does not already exist, create the default folder.
                    Directory.CreateDirectory(_pathToCheckpointer);
                }
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                throw Errors.MissingCheckpointerPath(folderPath);
            }
            _pathToCheckpointer = folderPath;
            _transferStates = new Dictionary<string, Dictionary<int, JobPartPlanFile>>();
        }

        /// <summary>
        /// Adds a new transfer to the checkpointer.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        public override Task AddNewJobAsync(
            string transferId,
            CancellationToken cancellationToken = default)
        {
            if (!_transferStates.ContainsKey(transferId))
            {
                // Add new transfer id to the list of memory mapped files
                Dictionary<int, JobPartPlanFile> tempJobParts = new Dictionary<int, JobPartPlanFile>();
                _transferStates.Add(transferId, tempJobParts);
            }
            else
            {
                throw Errors.CollisionTransferIdCheckpointer(transferId);
            }
            return Task.CompletedTask;
        }

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
        public override async Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            int chunksTotal,
            Stream headerStream,
            CancellationToken cancellationToken = default)
        {
            JobPartPlanFile mappedFile = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                _pathToCheckpointer,
                transferId,
                partNumber,
                headerStream).ConfigureAwait(false);

            // Add the job part in the spec
            if (_transferStates.ContainsKey(transferId))
            {
                // If the part number already exists
                if (_transferStates[transferId].ContainsKey(partNumber))
                {
                    throw Errors.CollisionJobPart(transferId, partNumber);
                }
                _transferStates[transferId][partNumber] = mappedFile;
            }
            else
            {
                // We should never get here because AddNewJobAsync should
                // always be called first.
                throw Errors.MissingTransferIdAddPartCheckpointer(transferId, partNumber);
            }
        }

        /// <summary>
        /// Add existing job to the checkpointer with verification. This function will throw
        /// if no existing job plan files exist in the checkpointer, and the job plan files have
        /// mismatch information from the information to resume from.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task AddExistingJobAsync(
            string transferId,
            CancellationToken cancellationToken = default)
        {
            // Check if the transfer id already exists, if it does, then we don't
            // have to go through all these checks.
            if (!_transferStates.ContainsKey(transferId))
            {
                // Keep track of the correlating job part plan files
                List<JobPartPlanFileName> fileNames = new List<JobPartPlanFileName>();

                // Search for existing plan files with the correlating transfer id
                string searchPattern = string.Concat(transferId, '*');
                foreach (string path in Directory.EnumerateFiles(_pathToCheckpointer, searchPattern, SearchOption.TopDirectoryOnly)
                    .Where(f => Path.HasExtension(string.Concat(
                        DataMovementConstants.PlanFile.FileExtension,
                        DataMovementConstants.PlanFile.SchemaVersion))))
                {
                    // Ensure each file has the matching header
                    if (JobPartPlanFileName.TryParseJobPartPlanFileName(path, out JobPartPlanFileName partPlanFileName))
                    {
                        fileNames.Add(partPlanFileName);
                    }
                }
                if (fileNames.Count == 0)
                {
                    // If no files exist, there's nothing to resume from
                    throw Errors.PlanFilesMissing(_pathToCheckpointer, transferId);
                }

                // Verify each existing file and then add it to our transfer states.
                // TODO: move verification to transfer manager to prevent from opening job plan file
                // more than once.
                Dictionary<int, JobPartPlanFile> jobParts = new Dictionary<int, JobPartPlanFile>();
                foreach (JobPartPlanFileName partFileName in fileNames)
                {
                    // Grab the header info
                    JobPartPlanHeader header = partFileName.GetJobPartPlanHeader();

                    // Verify the job part plan header
                    CheckInputWithHeader(transferId, header);

                    // Add to list of job parts
                    JobPartPlanFile jobFile;
                    using (Stream stream = new MemoryStream())
                    {
                        header.Serialize(stream);
                        jobFile = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                            fileName: partFileName,
                            headerStream: stream).ConfigureAwait(false);
                    }
                    jobParts.Add(partFileName.JobPartNumber, jobFile);
                }

                // Add new transfer id to the list of memory mapped files
                _transferStates.Add(transferId, jobParts);
            }
        }

        /// <summary>
        /// Gets the current number of chunk counts stored in the job part with the
        /// respective transfer id.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> CurrentJobPartCountAsync(
            string transferId,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (_transferStates.TryGetValue(transferId, out var result))
            {
                return Task.FromResult<int>(result.Count);
            }
            throw Errors.MissingTransferIdCheckpointer(transferId);
        }

        /// <summary>
        /// Creates a stream to the stored memory stored checkpointing information.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The part number of the current transfer.</param>
        /// <param name="readSize">
        /// The size of how many bytes to read.
        /// Specify 0 (zero) to create a stream that ends approximately at the end of the file.
        /// </param>
        /// <param name="offset">The offset of the current transfer.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The Stream to the checkpoint of the respective job ID and part number.</returns>
        public override async Task<Stream> ReadableStreamAsync(
            string transferId,
            int partNumber,
            long offset,
            long readSize,
            CancellationToken cancellationToken = default)
        {
            if (_transferStates.TryGetValue(transferId, out Dictionary<int, JobPartPlanFile> jobPartFiles))
            {
                Stream copiedStream = new MemoryStream(DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes);
                // MMF lock
                await jobPartFiles[partNumber].WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                // Open up MemoryMappedFile
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
                    path: jobPartFiles[partNumber].FilePath,
                    mode: FileMode.Open,
                    mapName: jobPartFiles[partNumber].MapName,
                    capacity: DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes,
                    access: MemoryMappedFileAccess.Read))
                {
                    using (MemoryMappedViewStream mmfStream = mmf.CreateViewStream(offset, readSize, MemoryMappedFileAccess.Read))
                    {
                        await mmfStream.CopyToAsync(copiedStream).ConfigureAwait(false);
                    }
                }
                // MMF release
                jobPartFiles[partNumber].WriteLock.Release();
                return copiedStream;
            }
            else
            {
                throw new ArgumentException($"Checkpointer information from Transfer id \"{transferId}\", at part number \"{partNumber}\" was not found. Cannot read from plan file");
            }
        }

        /// <summary>
        /// Writes to the checkpointer and stores the checkpointing information.
        ///
        /// Creates the checkpoint file for the respective ID if it does not currently exist.
        ///
        /// TODO: decide if we want to make this public, does not have a huge use to us currently.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="partNumber">The part number of the current transfer.</param>
        /// <param name="chunkIndex">The offset of the current transfer.</param>
        /// <param name="buffer">The buffer to write data from to the checkpoint.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        internal override async Task WriteToCheckpointAsync(
            string transferId,
            int partNumber,
            long chunkIndex,
            byte[] buffer,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotDefault(ref partNumber, nameof(partNumber));
            if (buffer?.Length == 0)
            {
                throw new ArgumentException("Buffer cannot be empty");
            }
            if (_transferStates.TryGetValue(transferId, out Dictionary<int, JobPartPlanFile> jobPartFiles))
            {
                if (jobPartFiles[partNumber] == default)
                {
                    // TODO: better exception message.
                    throw new ArgumentException("Missing job part file call add job part file instead");
                }
                else
                {
                    // partNumber file already exists

                    // Lock MMF
                    await jobPartFiles[partNumber].WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
                        path: jobPartFiles[partNumber].FilePath,
                        mode: FileMode.Open,
                        mapName: jobPartFiles[partNumber].MapName,
                        capacity: DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes,
                        access: MemoryMappedFileAccess.Read))
                    {
                        using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(chunkIndex, buffer.Length, MemoryMappedFileAccess.Write))
                        {
                            accessor.WriteArray(0, buffer, 0, buffer.Length);
                            // to flush to the underlying file that supports the mmf
                            accessor.Flush();
                        }
                    }

                    // Release MMF
                    jobPartFiles[partNumber].WriteLock.Release();
                }
            }
            else
            {
                throw new ArgumentException($"Checkpointer information from Transfer id \"{transferId}\" was not found. Call TryAddTransferAsync before attempting to add transfer information");
            }
        }

        /// <summary>
        /// Removes transfer information of the respective IDs.
        /// </summary>
        /// <param name="transferId">The transfer ID.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>Returns a bool that is true if operation is successful, otherwise is false.</returns>
        public override Task<bool> TryRemoveStoredTransferAsync(string transferId, CancellationToken cancellationToken = default)
        {
            bool result = true;
            Argument.AssertNotNullOrWhiteSpace(transferId, nameof(transferId));
            if (!_transferStates.TryGetValue(transferId, out Dictionary<int, JobPartPlanFile> jobPartFiles))
            {
                return Task.FromResult(false);
            }
            foreach (KeyValuePair<int,JobPartPlanFile> jobPartPair in jobPartFiles)
            {
                try
                {
                    File.Delete(jobPartPair.Value.FilePath);
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
            _transferStates.Remove(transferId);
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
            return Task.FromResult(_transferStates.Keys.ToList());
        }

        /// <summary>
        /// Sets the Job Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="status"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task SetJobTransferStatusAsync(
            string transferId,
            StorageTransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.PlanFile.OneByte;
            int offset = DataMovementConstants.PlanFile.AtomicJobStatusIndex;
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (_transferStates.TryGetValue(transferId, out Dictionary<int, JobPartPlanFile> jobPartFiles))
            {
                foreach (KeyValuePair<int, JobPartPlanFile> jobPartPair in jobPartFiles)
                {
                    CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
                    // Lock MMF
                    await jobPartPair.Value.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);
                    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
                            path: jobPartPair.Value.FilePath,
                            mode: FileMode.Open,
                            mapName: jobPartPair.Value.MapName,
                            capacity: DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes,
                            access: MemoryMappedFileAccess.Read))
                    {
                        using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length, MemoryMappedFileAccess.Write))
                        {
                            accessor.Write(0, (int)status);
                            // to flush to the underlying file that supports the mmf
                            accessor.Flush();
                        }
                    }
                    // Release MMF
                    jobPartPair.Value.WriteLock.Release();
                }
            }
            else
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
        }

        /// <summary>
        /// Sets the Job Part Transfer Status in the Job Part Plan files.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="partNumber"></param>
        /// <param name="status"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task SetJobPartTransferStatusAsync(
            string transferId,
            int partNumber,
            StorageTransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.PlanFile.OneByte;
            int offset = DataMovementConstants.PlanFile.AtomicPartStatusIndex;
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (_transferStates.TryGetValue(transferId, out Dictionary<int, JobPartPlanFile> jobPartFiles))
            {
                if (jobPartFiles.TryGetValue(partNumber, out JobPartPlanFile file))
                {
                    // Lock MMF
                    await file.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
                                path: file.FilePath,
                                mode: FileMode.Open,
                                mapName: file.MapName,
                                capacity: DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes,
                                access: MemoryMappedFileAccess.Read))
                    {
                        using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length, MemoryMappedFileAccess.Write))
                        {
                            accessor.Write(0, (int)status);
                            // to flush to the underlying file that supports the mmf
                            accessor.Flush();
                        }
                    }
                    // Release MMF
                    file.WriteLock.Release();
                }
                else
                {
                    throw Errors.MissingPartNumberCheckpointer(transferId, partNumber);
                }
            }
            else
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
        }
    }
}
