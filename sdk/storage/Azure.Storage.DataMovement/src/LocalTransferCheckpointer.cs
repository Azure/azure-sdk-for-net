// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Common;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Shared;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Creates a checkpointer which uses a locally stored file to obtain
    /// the information in order to resume transfers in the future.
    /// </summary>
    internal class LocalTransferCheckpointer : SerializerTransferCheckpointer
    {
        internal string _pathToCheckpointer;

        /// <summary>
        /// Stores references to the memory mapped files stored by IDs.
        /// </summary>
        internal readonly ConcurrentDictionary<string, JobPlanFile> _transferStates;

        /// <summary>
        /// Initializes a new instance of <see cref="LocalTransferCheckpointer"/> class.
        /// </summary>
        /// <param name="folderPath">Path to the folder containing the checkpointing information to resume from.</param>
        public LocalTransferCheckpointer(string folderPath)
        {
            _transferStates = new ConcurrentDictionary<string, JobPlanFile>();
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
            }
        }

        private bool TryGetJobPlanFile(string transferId, out JobPlanFile result)
        {
            if (!_transferStates.TryGetValue(transferId, out result))
            {
                RefreshCache(transferId);
                if (!_transferStates.TryGetValue(transferId, out result))
                {
                    return false;
                }
            }
            return true;
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
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

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
                new TransferStatus(),
                source.Uri.ToSanitizedString(),
                destination.Uri.ToSanitizedString(),
                source.GetSourceCheckpointDetails(),
                destination.GetDestinationCheckpointDetails());

            using (Stream headerStream = new MemoryStream())
            {
                header.Serialize(headerStream);
                headerStream.Position = 0;
                JobPlanFile jobPlanFile = await JobPlanFile.CreateJobPlanFileAsync(
                    _pathToCheckpointer,
                    transferId,
                    headerStream,
                    cancellationToken).ConfigureAwait(false);
                AddToTransferStates(transferId, jobPlanFile);
            }
        }

        public override async Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            JobPartPlanHeader header,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNull(partNumber, nameof(partNumber));
            Argument.AssertNotNull(header, nameof(header));
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (!_transferStates.ContainsKey(transferId))
            {
                // We should never get here because AddNewJobAsync should
                // always be called first.
                throw Errors.MissingTransferIdAddPartCheckpointer(transferId, partNumber);
            }

            JobPartPlanFile mappedFile = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                _pathToCheckpointer,
                transferId,
                partNumber,
                header,
                cancellationToken).ConfigureAwait(false);

            // Add the job part into the current state
            if (!_transferStates[transferId].JobParts.TryAdd(partNumber, mappedFile))
            {
                throw Errors.CollisionJobPart(transferId, partNumber);
            }
        }

        public override Task<int> CurrentJobPartCountAsync(
            string transferId,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (!TryGetJobPlanFile(transferId, out JobPlanFile result))
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
            return Task.FromResult(result.JobParts.Count);
        }

        public override async Task<Stream> ReadJobPlanFileAsync(
            string transferId,
            int offset,
            int length,
            CancellationToken cancellationToken = default)
        {
            int bufferSize = length > 0 ? length : DataMovementConstants.DefaultStreamCopyBufferSize;
            Stream copiedStream = new PooledMemoryStream(ArrayPool<byte>.Shared, bufferSize);

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (!TryGetJobPlanFile(transferId, out JobPlanFile jobPlanFile))
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }

            await jobPlanFile.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPlanFile.FilePath))
                using (MemoryMappedViewStream mmfStream = mmf.CreateViewStream(offset, length, MemoryMappedFileAccess.Read))
                {
                    await mmfStream.CopyToAsync(copiedStream, bufferSize, cancellationToken).ConfigureAwait(false);
                }

                copiedStream.Position = 0;
                return copiedStream;
            }
            finally
            {
                jobPlanFile.WriteLock.Release();
            }
        }

        public override async Task<Stream> ReadJobPartPlanFileAsync(
            string transferId,
            int partNumber,
            int offset,
            int length,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (!TryGetJobPlanFile(transferId, out JobPlanFile jobPlanFile))
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
            if (!jobPlanFile.JobParts.TryGetValue(partNumber, out JobPartPlanFile jobPartPlanFile))
            {
                throw Errors.MissingPartNumberCheckpointer(transferId, partNumber);
            }

            int bufferSize = length > 0 ? length : DataMovementConstants.DefaultStreamCopyBufferSize;
            Stream copiedStream = new PooledMemoryStream(ArrayPool<byte>.Shared, bufferSize);

            await jobPartPlanFile.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPartPlanFile.FilePath))
                using (MemoryMappedViewStream mmfStream = mmf.CreateViewStream(offset, length, MemoryMappedFileAccess.Read))
                {
                    await mmfStream.CopyToAsync(copiedStream, bufferSize, cancellationToken).ConfigureAwait(false);
                }

                copiedStream.Position = 0;
                return copiedStream;
            }
            finally
            {
                jobPartPlanFile.WriteLock.Release();
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
                await jobPlanFile.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPlanFile.FilePath, FileMode.Open))
                    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(fileOffset, length, MemoryMappedFileAccess.Write))
                    {
                        accessor.WriteArray(0, buffer, bufferOffset, length);
                        accessor.Flush();
                    }
                }
                finally
                {
                    jobPlanFile.WriteLock.Release();
                }
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

            if (TryGetJobPlanFile(transferId, out JobPlanFile jobPlanFile))
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

            _transferStates.TryRemove(transferId, out _);
            return Task.FromResult(result);
        }

        public override Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
        {
            RefreshCache();
            return Task.FromResult(_transferStates.Keys.ToList());
        }

        public override async Task SetJobTransferStatusAsync(
            string transferId,
            TransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.IntSizeInBytes;
            int offset = DataMovementConstants.JobPlanFile.JobStatusIndex;

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (!TryGetJobPlanFile(transferId, out JobPlanFile jobPlanFile))
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }

            // if completed successfully, get rid of all checkpointing info
            if (status.HasCompletedSuccessfully)
            {
                await TryRemoveStoredTransferAsync(transferId, cancellationToken).ConfigureAwait(false);
                return;
            }

            // if paused or other completion state, remove the memory cache but still write state to the plan file for later resume
            if (status.State == TransferState.Completed || status.State == TransferState.Paused)
            {
                // If TryRemove fails, it's fine it may be because it does not already exist or already has been removed
                _transferStates.TryRemove(transferId, out _);
            }

            await jobPlanFile.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(jobPlanFile.FilePath, FileMode.Open))
                using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length))
                {
                    accessor.Write(0, (int)status.ToJobPlanStatus());
                    accessor.Flush();
                }
            }
            finally
            {
                jobPlanFile.WriteLock.Release();
            }
        }

        public override async Task SetJobPartTransferStatusAsync(
            string transferId,
            int partNumber,
            TransferStatus status,
            CancellationToken cancellationToken = default)
        {
            long length = DataMovementConstants.IntSizeInBytes;
            int offset = DataMovementConstants.JobPartPlanFile.JobPartStatusIndex;

            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (!TryGetJobPlanFile(transferId, out JobPlanFile jobPlanFile))
            {
                throw Errors.MissingTransferIdCheckpointer(transferId);
            }
            if (!jobPlanFile.JobParts.TryGetValue(partNumber, out JobPartPlanFile file))
            {
                throw Errors.MissingPartNumberCheckpointer(transferId, partNumber);
            }
            await file.WriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(file.FilePath, FileMode.Open))
                using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(offset, length))
                {
                    accessor.Write(0, (int)status.ToJobPlanStatus());
                    accessor.Flush();
                }
            }
            finally
            {
                file.WriteLock.Release();
            }
        }

        /// <summary>
        /// Clears cached transfer states and repopulates by enumerating directory.
        /// </summary>
        private void RefreshCache()
        {
            _transferStates.Clear();

            // First, retrieve all valid job plan files
            foreach (string path in Directory.EnumerateFiles(_pathToCheckpointer)
                .Where(p => Path.GetExtension(p) == DataMovementConstants.JobPlanFile.FileExtension))
            {
                // TODO: Should we check for valid schema version inside file now?
                JobPlanFile jobPlanFile = JobPlanFile.LoadExistingJobPlanFile(path);
                if (!_transferStates.ContainsKey(jobPlanFile.Id))
                {
                    AddToTransferStates(jobPlanFile.Id, jobPlanFile);
                }
                else
                {
                    throw Errors.CollisionTransferIdCheckpointer(jobPlanFile.Id);
                }
            }

            // Retrieve all valid job part plan files stored in the checkpointer path.
            foreach (string path in Directory.EnumerateFiles(_pathToCheckpointer)
                .Where(p => Path.GetExtension(p) == DataMovementConstants.JobPartPlanFile.FileExtension))
            {
                // Ensure each file has the correct format
                if (JobPartPlanFileName.TryParseJobPartPlanFileName(path, out JobPartPlanFileName partPlanFileName))
                {
                    // Job plan file should already exist since we already iterated job plan files
                    if (_transferStates.TryGetValue(partPlanFileName.Id, out JobPlanFile jobPlanFile))
                    {
                        jobPlanFile.JobParts.TryAdd(
                            partPlanFileName.JobPartNumber,
                            JobPartPlanFile.CreateExistingPartPlanFile(partPlanFileName));
                    }
                }
            }
        }

        /// <summary>
        /// Clears cache for a given transfer ID and repopulates from disk if any.
        /// </summary>
        private void RefreshCache(string transferId)
        {
            // If TryRemove fails, it's fine it may be because it does not already exist or already has been removed
            _transferStates.TryRemove(transferId, out _);
            JobPlanFile jobPlanFile = JobPlanFile.LoadExistingJobPlanFile(_pathToCheckpointer, transferId);
            if (!File.Exists(jobPlanFile.FilePath))
            {
                return;
            }
            AddToTransferStates(transferId, jobPlanFile);
            foreach (string path in Directory.EnumerateFiles(_pathToCheckpointer)
                .Where(p => Path.GetExtension(p) == DataMovementConstants.JobPartPlanFile.FileExtension))
            {
                // Ensure each file has the correct format
                if (JobPartPlanFileName.TryParseJobPartPlanFileName(path, out JobPartPlanFileName partPlanFileName) &&
                    partPlanFileName.Id == transferId)
                {
                    jobPlanFile.JobParts.TryAdd(
                        partPlanFileName.JobPartNumber,
                        JobPartPlanFile.CreateExistingPartPlanFile(partPlanFileName));
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

        private void AddToTransferStates(string transferId, JobPlanFile jobPlanFile)
        {
            if (!_transferStates.TryAdd(transferId, jobPlanFile))
            {
                throw Errors.CollisionJobPlanFile(transferId);
            }
        }
    }
}
