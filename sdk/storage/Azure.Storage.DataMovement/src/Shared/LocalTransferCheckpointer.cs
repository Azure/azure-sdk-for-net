// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.JobPlan;

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
        internal Dictionary<string, Dictionary<int, JobPartPlanFile>> _transferStates;

        /// <summary>
        /// Initializes a new instance of <see cref="LocalTransferCheckpointer"/> class.
        /// </summary>
        /// <param name="folderPath">Path to the folder containing the checkpointing information to resume from.</param>
        public LocalTransferCheckpointer(string folderPath)
        {
            _transferStates = new Dictionary<string, Dictionary<int, JobPartPlanFile>>();
            if (string.IsNullOrEmpty(folderPath))
            {
                _pathToCheckpointer = Path.Combine(Environment.CurrentDirectory, DataMovementConstants.DefaultCheckpointerPath);
                if (!Directory.Exists(_pathToCheckpointer))
                {
                    // If it does not already exist, create the default folder.
                    Directory.CreateDirectory(_pathToCheckpointer);
                }
            }
            else if (!Directory.Exists(folderPath))
            {
                throw Errors.MissingCheckpointerPath(folderPath);
            }
            else
            {
                _pathToCheckpointer = folderPath;
                InitializeExistingCheckpointer();
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override async Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            int chunksTotal,
            Stream headerStream,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNull(partNumber, nameof(partNumber));
            Argument.AssertNotNull(chunksTotal, nameof(chunksTotal));
            Argument.AssertNotNull(headerStream, nameof(headerStream));
            headerStream.Position = 0;

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

        /// <inheritdoc/>
        public override Task AddExistingJobAsync(
            string transferId,
            CancellationToken cancellationToken = default)
        {
            // Check if the transfer id already exists, if it does, then we don't
            // have to go through all these checks.
            if (!_transferStates.ContainsKey(transferId))
            {
                // Keep track of the correlating job part plan files
                List<JobPartPlanFileName> fileNames = new List<JobPartPlanFileName>();
                string searchPattern = string.Concat(transferId, '*');

                // Enumerate all the job parts with the transfer id
                foreach (string path in Directory.EnumerateFiles(_pathToCheckpointer, searchPattern, SearchOption.TopDirectoryOnly)
                    .Where(f => Path.HasExtension(string.Concat(
                        DataMovementConstants.JobPartPlanFile.FileExtension,
                        DataMovementConstants.JobPartPlanFile.SchemaVersion))))
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
                Dictionary<int, JobPartPlanFile> jobParts = new Dictionary<int, JobPartPlanFile>();
                foreach (JobPartPlanFileName partFileName in fileNames)
                {
                    // Grab the header info
                    JobPartPlanHeader header = partFileName.GetJobPartPlanHeader();

                    // Add to list of job parts
                    JobPartPlanFile jobFile = JobPartPlanFile.CreateExistingPartPlanFile(partFileName);
                    jobParts.Add(partFileName.JobPartNumber, jobFile);
                }

                // Add new transfer id to the list of memory mapped files
                _transferStates.Add(transferId, jobParts);
            }
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override async Task<Stream> ReadableStreamAsync(
            string transferId,
            int partNumber,
            long offset,
            long readSize,
            CancellationToken cancellationToken = default)
        {
            if (_transferStates.TryGetValue(transferId, out Dictionary<int, JobPartPlanFile> jobPartFiles))
            {
                Stream copiedStream = new MemoryStream(DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes);
                // MMF lock
                await jobPartFiles[partNumber].WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                // Open up MemoryMappedFile
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(
                    path: jobPartFiles[partNumber].FilePath,
                    mode: FileMode.Open,
                    mapName: null,
                    capacity: DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
                {
                    using (MemoryMappedViewStream mmfStream = mmf.CreateViewStream(offset, readSize, MemoryMappedFileAccess.Read))
                    {
                        await mmfStream.CopyToAsync(copiedStream).ConfigureAwait(false);
                    }
                }
                // MMF release
                jobPartFiles[partNumber].WriteLock.Release();
                copiedStream.Position = 0;
                return copiedStream;
            }
            else
            {
                throw new ArgumentException($"Checkpointer information from Transfer id \"{transferId}\", at part number \"{partNumber}\" was not found. Cannot read from plan file");
            }
        }

        /// <inheritdoc/>
        public override async Task WriteToCheckpointAsync(
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
                        mapName: null,
                        capacity: DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_transferStates.Keys.ToList());
        }

        /// <inheritdoc/>
        public override async Task SetJobTransferStatusAsync(
            string transferId,
            DataTransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.OneByte;
            int offset = DataMovementConstants.JobPartPlanFile.AtomicJobStatusIndex;
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
                            mapName: null,
                            capacity: DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
                    {
                        using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length))
                        {
                            accessor.Write(
                                position: 0,
                                value: (byte)status);
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

        /// <inheritdoc/>
        public override async Task SetJobPartTransferStatusAsync(
            string transferId,
            int partNumber,
            DataTransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.OneByte;
            int offset = DataMovementConstants.JobPartPlanFile.AtomicPartStatusIndex;
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
                                mapName: null,
                                capacity: DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
                    {
                        using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length))
                        {
                            accessor.Write(
                                position: 0,
                                value: (byte)status);
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

        /// <summary>
        /// Takes the path of the checkpointer reads all the files in the top directory level
        /// and populates the _transferStates
        /// </summary>
        private void InitializeExistingCheckpointer()
        {
            // Retrieve all valid checkpointer files stored in the checkpointer path.
            foreach (string path in Directory.EnumerateFiles(_pathToCheckpointer, "*", SearchOption.TopDirectoryOnly)
                .Where(f => Path.HasExtension(string.Concat(
                    DataMovementConstants.JobPartPlanFile.FileExtension,
                    DataMovementConstants.JobPartPlanFile.SchemaVersion))))
            {
                // Ensure each file has the correct format
                if (JobPartPlanFileName.TryParseJobPartPlanFileName(path, out JobPartPlanFileName partPlanFileName))
                {
                    // Check if the transfer Id already exists
                    if (_transferStates.ContainsKey(partPlanFileName.Id))
                    {
                        // If the transfer Id already exists, then add the job part plan file
                        // with the rest of the job part plan files in the respective
                        // transfer id.
                        _transferStates[partPlanFileName.Id].Add(
                            partPlanFileName.JobPartNumber,
                            JobPartPlanFile.CreateExistingPartPlanFile(partPlanFileName));
                    }
                    else
                    {
                        // If the transfer id has not been seen yet, add it and add
                        // the job part plan file as well.
                        Dictionary<int, JobPartPlanFile> newTransfer = new Dictionary<int, JobPartPlanFile>
                    {
                        {
                            partPlanFileName.JobPartNumber,
                            JobPartPlanFile.CreateExistingPartPlanFile(partPlanFileName)
                        }
                    };
                        _transferStates.Add(
                            partPlanFileName.Id,
                            newTransfer);
                    }
                }
            }
        }
    }
}
