﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job for single transfer
        /// </summary>
        internal ServiceToServiceTransferJob(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            TransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer CheckPointFolderPath,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  CheckPointFolderPath,
                  errorHandling,
                  arrayPool)
        {
        }

        /// <summary>
        /// Create Storage Transfer Job for container transfer
        /// </summary>
        internal ServiceToServiceTransferJob(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            TransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            ErrorHandlingOptions errorHandling,
            ArrayPool<byte> arrayPool)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool)
        {
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public override async IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync()
        {
            await OnJobStatusChangedAsync(StorageTransferStatus.InProgress).ConfigureAwait(false);
            int partNumber = 0;

            if (_jobParts.Count == 0)
            {
                // Starting brand new job
                if (_isSingleResource)
                {
                    ServiceToServiceJobPart part = default;
                    try
                    {
                        // Single resource transfer, we can skip to chunking the job.
                        part = await ServiceToServiceJobPart.CreateJobPartAsync(
                            job: this,
                            partNumber: partNumber,
                            isFinalPart: true).ConfigureAwait(false);
                        _jobParts.Add(part);
                    }
                    catch (Exception ex)
                    {
                        await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                        yield break;
                    }
                    yield return part;
                }
                else
                {
                    await foreach (JobPartInternal part in GetStorageResourcesAsync().ConfigureAwait(false))
                    {
                        yield return part;
                    }
                }
            }
            else
            {
                // Resuming old job with existing job parts
                bool isFinalPartFound = false;
                foreach (JobPartInternal part in _jobParts)
                {
                    if (part.JobPartStatus != StorageTransferStatus.Completed)
                    {
                        part.JobPartStatus = StorageTransferStatus.Queued;
                        yield return part;

                        if (part.IsFinalPart)
                        {
                            // If we found the final part then we don't have to relist the container.
                            isFinalPartFound = true;
                        }
                    }
                }
                if (!isFinalPartFound)
                {
                    await foreach (JobPartInternal jobPartInternal in GetStorageResourcesAsync().ConfigureAwait(false))
                    {
                        yield return jobPartInternal;
                    }
                }
            }
            _enumerationComplete = true;
            await OnEnumerationComplete().ConfigureAwait(false);
        }

        private async IAsyncEnumerable<JobPartInternal> GetStorageResourcesAsync()
        {
            // Start the partNumber based on the last part number. If this is a new job,
            // the count will automatically be at 0 (the beginning).
            int partNumber = _jobParts.Count;
            List<string> existingSources = GetJobPartSourceResourcePaths();
            // Call listing operation on the source container
            IAsyncEnumerator<StorageResourceBase> enumerator;

            // Obtain enumerator and check for any point of failure before we attempt to list
            // and fail gracefully.
            try
            {
                enumerator = _sourceResourceContainer.GetStorageResourcesAsync(
                        cancellationToken: _cancellationToken).GetAsyncEnumerator();
            }
            catch (Exception ex)
            {
                await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                yield break;
            }

            // List the container keep track of the last job part in order to store it properly
            // so we know we finished enumerating/listed.
            bool enumerationCompleted = false;
            StorageResourceBase lastResource = default;
            while (!enumerationCompleted)
            {
                try
                {
                    if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        enumerationCompleted = true;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }

                StorageResourceBase current = enumerator.Current;
                if (lastResource != default)
                {
                    string sourceName = string.IsNullOrEmpty(_sourceResourceContainer.Path)
                        ? lastResource.Path
                        : lastResource.Path.Substring(_sourceResourceContainer.Path.Length + 1);

                    if (!existingSources.Contains(sourceName))
                    {
                        // Because AsyncEnumerable doesn't let us know which storage resource is the last resource
                        // we only yield return when we know this is not the last storage resource to be listed
                        // from the container.
                        ServiceToServiceJobPart part;
                        try
                        {
                            part = await ServiceToServiceJobPart.CreateJobPartAsync(
                                job: this,
                                partNumber: partNumber,
                                sourceResource: (StorageResource)lastResource,
                                destinationResource: _destinationResourceContainer.GetChildStorageResource(sourceName),
                                isFinalPart: false).ConfigureAwait(false);
                            _jobParts.Add(part);
                        }
                        catch (Exception ex)
                        {
                            await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                            yield break;
                        }
                        yield return part;
                        partNumber++;
                    }
                }
                lastResource = current;
            }

            // It's possible to have no job parts in a job
            if (lastResource != default)
            {
                ServiceToServiceJobPart lastPart;
                try
                {
                    // Return last part but enable the part to be the last job part of the entire job
                    // so we know that we've finished listing in the container
                    string lastSourceName = string.IsNullOrEmpty(_sourceResourceContainer.Path)
                        ? lastResource.Path
                        : lastResource.Path.Substring(_sourceResourceContainer.Path.Length + 1);

                    lastPart = await ServiceToServiceJobPart.CreateJobPartAsync(
                            job: this,
                            partNumber: partNumber,
                            sourceResource: (StorageResource)lastResource,
                            destinationResource: _destinationResourceContainer.GetChildStorageResource(lastSourceName),
                            isFinalPart: true).ConfigureAwait(false);
                    _jobParts.Add(lastPart);
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }
                yield return lastPart;
            }
        }
    }
}
