// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job for single transfer
        /// </summary>
        internal ServiceToServiceTransferJob(
            DataTransfer dataTransfer,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer CheckPointFolderPath,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  CheckPointFolderPath,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }

        /// <summary>
        /// Create Storage Transfer Job for container transfer
        /// </summary>
        internal ServiceToServiceTransferJob(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            DataTransferOptions transferOptions,
            QueueChunkTaskInternal queueChunkTask,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  transferOptions,
                  queueChunkTask,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>An IEnumerable that contains the job parts</returns>
        public override async IAsyncEnumerable<JobPartInternal> ProcessJobToJobPartAsync()
        {
            await OnJobStateChangedAsync(DataTransferState.InProgress).ConfigureAwait(false);
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
                            partNumber: partNumber).ConfigureAwait(false);
                        AppendJobPart(part);
                        await OnAllResourcesEnumerated().ConfigureAwait(false);
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
                foreach (JobPartInternal part in _jobParts)
                {
                    if (!part.JobPartStatus.HasCompletedSuccessfully)
                    {
                        part.JobPartStatus.TrySetTransferStateChange(DataTransferState.Queued);
                        yield return part;
                    }
                }

                if (!await _checkpointer.IsEnumerationCompleteAsync(_dataTransfer.Id, _cancellationToken).ConfigureAwait(false))
                {
                    await foreach (JobPartInternal jobPartInternal in GetStorageResourcesAsync().ConfigureAwait(false))
                    {
                        yield return jobPartInternal;
                    }
                }
            }

            // Call regardless of the outcome of enumeration so job can pause/finish
            await OnEnumerationComplete().ConfigureAwait(false);
        }

        private async IAsyncEnumerable<JobPartInternal> GetStorageResourcesAsync()
        {
            // Start the partNumber based on the last part number. If this is a new job,
            // the count will automatically be at 0 (the beginning).
            int partNumber = _jobParts.Count;
            HashSet<Uri> existingSources = GetJobPartSourceResourcePaths();
            // Call listing operation on the source container
            IAsyncEnumerator<StorageResource> enumerator;

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

            // List the container in this specific way because MoveNext needs to be separately wrapped
            // in a try/catch as we can't yield return inside a try/catch.
            bool enumerationCompleted = false;
            while (!enumerationCompleted)
            {
                try
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                    if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        await OnAllResourcesEnumerated().ConfigureAwait(false);
                        enumerationCompleted = true;
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                    yield break;
                }

                StorageResource current = enumerator.Current;

                if (current.IsContainer)
                {
                    // Create sub-container
                    string containerUriPath = _sourceResourceContainer.Uri.GetPath();
                    string subContainerPath = string.IsNullOrEmpty(containerUriPath)
                        ? current.Uri.GetPath()
                        : current.Uri.GetPath().Substring(containerUriPath.Length + 1);
                    StorageResourceContainer subContainer =
                        _destinationResourceContainer.GetChildStorageResourceContainer(subContainerPath);

                    try
                    {
                        await subContainer.CreateIfNotExistsAsync(_cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        await InvokeFailedArgAsync(ex).ConfigureAwait(false);
                        yield break;
                    }
                }
                else
                {
                    if (!existingSources.Contains(current.Uri))
                    {
                        string containerUriPath = _sourceResourceContainer.Uri.GetPath();
                        string sourceName = string.IsNullOrEmpty(containerUriPath)
                            ? current.Uri.GetPath()
                            : current.Uri.GetPath().Substring(containerUriPath.Length + 1);

                        ServiceToServiceJobPart part;
                        try
                        {
                            part = await ServiceToServiceJobPart.CreateJobPartAsync(
                                job: this,
                                partNumber: partNumber,
                                sourceResource: (StorageResourceItem)current,
                                destinationResource: _destinationResourceContainer.GetStorageResourceReference(sourceName))
                                .ConfigureAwait(false);
                            AppendJobPart(part);
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
            }
        }
    }
}
