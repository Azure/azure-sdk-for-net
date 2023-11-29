// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Shared;

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
        private Dictionary<string, JobPlanFile> _transferStates;

        /// <summary>
        /// Initializes a new instance of <see cref="LocalTransferCheckpointer"/> class.
        /// </summary>
        /// <param name="folderPath">Path to the folder containing the checkpointing information to resume from.</param>
        public LocalTransferCheckpointer(string folderPath)
        {
            _transferStates = new Dictionary<string, JobPlanFile>();
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

        public override async Task AddNewJobAsync(
            string transferId,
            StorageResource source,
            StorageResource destination,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNull(source, nameof(source));
            Argument.AssertNotNull(destination, nameof(destination));

            if (_transferStates.ContainsKey(transferId))
            {
                throw Errors.CollisionTransferIdCheckpointer(transferId);
            }

            bool isContainer = source is StorageResourceContainer;
            JobPlanHeader header = new(
                DataMovementConstants.JobPlanFile.SchemaVersion,
                transferId,
                DateTimeOffset.UtcNow,
                GetOperationType(source, destination),
                source.ProviderId,
                destination.ProviderId,
                isContainer,
                false, /* enumerationComplete */
                new DataTransferStatus(),
                source.Uri.ToSanitizedString(),
                destination.Uri.ToSanitizedString(),
                source.GetSourceCheckpointData(),
                destination.GetDestinationCheckpointData());

            using (Stream headerStream = new MemoryStream())
            {
                header.Serialize(headerStream);
                headerStream.Position = 0;
                JobPlanFile jobPlanFile = await JobPlanFile.CreateJobPlanFileAsync(
                    _pathToCheckpointer,
                    transferId,
                    headerStream).ConfigureAwait(false);
                _transferStates.Add(transferId, jobPlanFile);
            }
        }

        public override async Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            Stream headerStream,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNull(partNumber, nameof(partNumber));
            Argument.AssertNotNull(headerStream, nameof(headerStream));
            headerStream.Position = 0;

            JobPartPlanFile mappedFile = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                _pathToCheckpointer,
                transferId,
                partNumber,
                headerStream).ConfigureAwait(false);

            // Add the job part into the current state
            if (_transferStates.ContainsKey(transferId))
            {
                _transferStates[transferId].JobParts.Add(partNumber, mappedFile);
            }
            else
            {
                // We should never get here because AddNewJobAsync should
                // always be called first.
                throw Errors.MissingTransferIdAddPartCheckpointer(transferId, partNumber);
            }
        }

        public override Task<int> CurrentJobPartCountAsync(
            string transferId,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (_transferStates.TryGetValue(transferId, out JobPlanFile result))
            {
                return Task.FromResult(result.JobParts.Count);
            }
            throw Errors.MissingTransferIdCheckpointer(transferId);
        }

        public override async Task<Stream> ReadJobPlanFileAsync(
            string transferId,
            int offset,
            int length,
            CancellationToken cancellationToken = default)
        {
            int maxArraySize = length > 0 ? length : DataMovementConstants.DefaultArrayPoolArraySize;
            Stream copiedStream = new PooledMemoryStream(ArrayPool<byte>.Shared, maxArraySize);

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (_transferStates.TryGetValue(transferId, out JobPlanFile jobPlanFile))
            {
                // Lock MMF
                await jobPlanFile.WriteLock.WaitAsync().ConfigureAwait(false);

                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPlanFile.FilePath))
                using (MemoryMappedViewStream mmfStream = mmf.CreateViewStream(offset, length, MemoryMappedFileAccess.Read))
                {
                    await mmfStream.CopyToAsync(copiedStream).ConfigureAwait(false);
                }

                // Release MMF
                jobPlanFile.WriteLock.Release();
                copiedStream.Position = 0;
                return copiedStream;
            }
            else
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
        }

        public override async Task<Stream> ReadJobPartPlanFileAsync(
            string transferId,
            int partNumber,
            int offset,
            int length,
            CancellationToken cancellationToken = default)
        {
            if (_transferStates.TryGetValue(transferId, out JobPlanFile jobPlanFile))
            {
                if (jobPlanFile.JobParts.TryGetValue(partNumber, out JobPartPlanFile jobPartPlanFile))
                {
                    int maxArraySize = length > 0 ? length : DataMovementConstants.DefaultArrayPoolArraySize;
                    Stream copiedStream = new PooledMemoryStream(ArrayPool<byte>.Shared, maxArraySize);

                    // MMF lock
                    await jobPartPlanFile.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                    // Open up MemoryMappedFile
                    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPartPlanFile.FilePath))
                    using (MemoryMappedViewStream mmfStream = mmf.CreateViewStream(offset, length, MemoryMappedFileAccess.Read))
                    {
                        await mmfStream.CopyToAsync(copiedStream).ConfigureAwait(false);
                    }

                    // MMF release
                    jobPartPlanFile.WriteLock.Release();
                    copiedStream.Position = 0;
                    return copiedStream;
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

        public override async Task WriteToJobPlanFileAsync(
            string transferId,
            int fileOffset,
            byte[] buffer,
            int bufferOffset,
            int length,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (_transferStates.TryGetValue(transferId, out JobPlanFile jobPlanFile))
            {
                // Lock MMF
                await jobPlanFile.WriteLock.WaitAsync().ConfigureAwait(false);

                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPlanFile.FilePath, FileMode.Open))
                using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(fileOffset, length, MemoryMappedFileAccess.Write))
                {
                    accessor.WriteArray(0, buffer, bufferOffset, length);
                    accessor.Flush();
                }

                // Release MMF
                jobPlanFile.WriteLock.Release();
            }
            else
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
        }

        public override Task<bool> TryRemoveStoredTransferAsync(string transferId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(transferId, nameof(transferId));

            List<string> filesToDelete = new List<string>();

            if (_transferStates.TryGetValue(transferId, out JobPlanFile jobPlanFile))
            {
                filesToDelete.Add(jobPlanFile.FilePath);
            }
            else
            {
                return Task.FromResult(false);
            }

            foreach (KeyValuePair<int,JobPartPlanFile> jobPartPair in jobPlanFile.JobParts)
            {
                filesToDelete.Add(jobPartPair.Value.FilePath);
            }

            bool result = true;
            foreach (string file in filesToDelete)
            {
                try
                {
                    File.Delete(file);
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

        public override Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_transferStates.Keys.ToList());
        }

        public override async Task SetJobTransferStatusAsync(
            string transferId,
            DataTransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.IntSizeInBytes;
            int offset = DataMovementConstants.JobPlanFile.JobStatusIndex;

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (_transferStates.TryGetValue(transferId, out JobPlanFile jobPlanFile))
            {
                // Lock MMF
                await jobPlanFile.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPlanFile.FilePath, FileMode.Open))
                using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length))
                {
                    accessor.Write(0, (int)status.ToJobPlanStatus());
                    accessor.Flush();
                }

                // Release MMF
                jobPlanFile.WriteLock.Release();
            }
            else
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
        }

        public override async Task SetJobPartTransferStatusAsync(
            string transferId,
            int partNumber,
            DataTransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.IntSizeInBytes;
            int offset = DataMovementConstants.JobPartPlanFile.JobPartStatusIndex;

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (_transferStates.TryGetValue(transferId, out JobPlanFile jobPlanFile))
            {
                if (jobPlanFile.JobParts.TryGetValue(partNumber, out JobPartPlanFile file))
                {
                    // Lock MMF
                    await file.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

                    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(file.FilePath, FileMode.Open))
                    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length))
                    {
                        accessor.Write(0, (int)status.ToJobPlanStatus());
                        accessor.Flush();
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
        /// and populates the _transferStates.
        /// </summary>
        private void InitializeExistingCheckpointer()
        {
            // Enumerate the filesystem
            IEnumerable<string> checkpointFiles = Directory.EnumerateFiles(_pathToCheckpointer);

            // First, retrieve all valid job plan files
            foreach (string path in checkpointFiles
                .Where(p => Path.GetExtension(p) == DataMovementConstants.JobPlanFile.FileExtension))
            {
                // TODO: Should we check for valid schema version inside file now?
                JobPlanFile jobPlanFile = JobPlanFile.LoadExistingJobPlanFile(path);
                if (!_transferStates.ContainsKey(jobPlanFile.Id))
                {
                    _transferStates.Add(jobPlanFile.Id, jobPlanFile);
                }
                else
                {
                    throw Errors.CollisionTransferIdCheckpointer(jobPlanFile.Id);
                }
            }

            // Retrieve all valid job part plan files stored in the checkpointer path.
            foreach (string path in checkpointFiles
                .Where(p => Path.GetExtension(p) == DataMovementConstants.JobPartPlanFile.FileExtension))
            {
                // Ensure each file has the correct format
                if (JobPartPlanFileName.TryParseJobPartPlanFileName(path, out JobPartPlanFileName partPlanFileName))
                {
                    // Job plan file should already exist since we already iterated job plan files
                    if (_transferStates.TryGetValue(partPlanFileName.Id, out JobPlanFile jobPlanFile))
                    {
                        jobPlanFile.JobParts.Add(
                            partPlanFileName.JobPartNumber,
                            JobPartPlanFile.CreateExistingPartPlanFile(partPlanFileName));
                    }
                }
            }
        }

        private static JobPlanOperation GetOperationType(StorageResource source, StorageResource destination)
        {
            if (source.IsLocalResource() && !destination.IsLocalResource())
            {
                return JobPlanOperation.Upload;
            }
            else if (!source.IsLocalResource() && destination.IsLocalResource())
            {
                return JobPlanOperation.Download;
            }
            else if (!source.IsLocalResource() && !destination.IsLocalResource())
            {
                return JobPlanOperation.ServiceToService;
            }
            else
            {
                throw Errors.InvalidSourceDestinationParams();
            }
        }
    }
}
