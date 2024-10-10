// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Buffers;
using Azure.Core.Pipeline;
using System;

namespace Azure.Storage.DataMovement;

internal class JobBuilder
{
    private readonly ArrayPool<byte> _arrayPool;

    /// <summary>
    /// Defines the error handling method to follow when an error is seen. Defaults to
    /// <see cref="DataTransferErrorMode.StopOnAnyFailure"/>.
    ///
    /// See <see cref="DataTransferErrorMode"/>.
    /// </summary>
    private readonly DataTransferErrorMode _errorHandling;

    private ClientDiagnostics ClientDiagnostics { get; }

    /// <summary>
    /// Mocking constructor.
    /// </summary>
    protected JobBuilder()
    { }

    internal JobBuilder(
        ArrayPool<byte> arrayPool,
        DataTransferErrorMode errorHandling,
        ClientDiagnostics clientDiagnostics)
    {
        _arrayPool = arrayPool;
        _errorHandling = errorHandling;
        ClientDiagnostics = clientDiagnostics;
    }

    public virtual async Task<(DataTransfer Transfer, TransferJobInternal TransferInternal)> BuildJobAsync(
        StorageResource sourceResource,
        StorageResource destinationResource,
        DataTransferOptions transferOptions,
        TransferCheckpointer checkpointer,
        string transferId,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        DataTransfer dataTransfer = new(id: transferId);
        TransferJobInternal transferJobInternal;

        // Single transfer
        if (sourceResource is StorageResourceItem sourceItem &&
            destinationResource is StorageResourceItem destationItem)
        {
            transferJobInternal = await BuildSingleTransferJob(
                sourceItem,
                destationItem,
                transferOptions,
                checkpointer,
                dataTransfer,
                resumeJob,
                cancellationToken).ConfigureAwait(false);
        }
        // Container transfer
        else if (sourceResource is StorageResourceContainer sourceContainer &&
            destinationResource is StorageResourceContainer destinationContainer)
        {
            transferJobInternal = await BuildContainerTransferJob(
                sourceContainer,
                destinationContainer,
                transferOptions,
                checkpointer,
                dataTransfer,
                resumeJob,
                cancellationToken).ConfigureAwait(false);
        }
        // Invalid transfer
        else
        {
            throw Errors.InvalidTransferResourceTypes();
        }

        return (dataTransfer, transferJobInternal);
    }

    private async Task<TransferJobInternal> BuildSingleTransferJob(
        StorageResourceItem sourceResource,
        StorageResourceItem destinationResource,
        DataTransferOptions transferOptions,
        TransferCheckpointer checkpointer,
        DataTransfer dataTransfer,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        TransferJobInternal.CreateJobPartSingleAsync single;
        TransferJobInternal.CreateJobPartMultiAsync multi;
        Func<TransferJobInternal, Stream, StorageResourceItem, StorageResourceItem, JobPartInternal> rehydrate;
        if (sourceResource.IsLocalResource() && !destinationResource.IsLocalResource())
        {
            single = StreamToUriJobPart.CreateJobPartAsync;
            multi = StreamToUriJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToStreamToUriJobPartAsync;
        }
        else if (!sourceResource.IsLocalResource() && destinationResource.IsLocalResource())
        {
            single = UriToStreamJobPart.CreateJobPartAsync;
            multi = UriToStreamJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToUriToStreamJobPartAsync;
        }
        else if (!sourceResource.IsLocalResource() && !destinationResource.IsLocalResource())
        {
            single = ServiceToServiceJobPart.CreateJobPartAsync;
            multi = ServiceToServiceJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToServiceToServiceJobPartAsync;
        }
        else
        {
            throw Errors.InvalidSourceDestinationParams();
        }

        TransferJobInternal job = new(
            dataTransfer: dataTransfer,
            sourceResource: sourceResource,
            destinationResource: destinationResource,
            single,
            multi,
            transferOptions: transferOptions,
            checkpointer: checkpointer,
            errorHandling: _errorHandling,
            arrayPool: _arrayPool,
            clientDiagnostics: ClientDiagnostics);

        if (resumeJob)
        {
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: dataTransfer.Id,
                partNumber: 0,
                offset: 0,
                length: 0,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                job.AppendJobPart(
                    rehydrate(
                        job,
                        stream,
                        sourceResource,
                        destinationResource));
            }
        }
        return job;
    }

    private async Task<TransferJobInternal> BuildContainerTransferJob(
        StorageResourceContainer sourceResource,
        StorageResourceContainer destinationResource,
        DataTransferOptions transferOptions,
        TransferCheckpointer checkpointer,
        DataTransfer dataTransfer,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        TransferJobInternal.CreateJobPartSingleAsync single;
        TransferJobInternal.CreateJobPartMultiAsync multi;
        Func<TransferJobInternal, Stream, StorageResourceContainer, StorageResourceContainer, JobPartInternal> rehydrate;
        if (sourceResource.IsLocalResource() && !destinationResource.IsLocalResource())
        {
            single = StreamToUriJobPart.CreateJobPartAsync;
            multi = StreamToUriJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToStreamToUriJobPartAsync;
        }
        else if (!sourceResource.IsLocalResource() && destinationResource.IsLocalResource())
        {
            single = UriToStreamJobPart.CreateJobPartAsync;
            multi = UriToStreamJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToUriToStreamJobPartAsync;
        }
        else if (!sourceResource.IsLocalResource() && !destinationResource.IsLocalResource())
        {
            single = ServiceToServiceJobPart.CreateJobPartAsync;
            multi = ServiceToServiceJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToServiceToServiceJobPartAsync;
        }
        else
        {
            throw Errors.InvalidSourceDestinationParams();
        }

        TransferJobInternal job = new(
            dataTransfer: dataTransfer,
            sourceResource: sourceResource,
            destinationResource: destinationResource,
            single,
            multi,
            transferOptions: transferOptions,
            checkpointer: checkpointer,
            errorHandling: _errorHandling,
            arrayPool: _arrayPool,
            clientDiagnostics: ClientDiagnostics);

        if (resumeJob)
        {
            // Iterate through all job parts and append to the job
            int jobPartCount = await checkpointer.CurrentJobPartCountAsync(
                transferId: dataTransfer.Id,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            for (var currentJobPart = 0; currentJobPart < jobPartCount; currentJobPart++)
            {
                using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                    transferId: dataTransfer.Id,
                    partNumber: currentJobPart,
                    offset: 0,
                    length: 0,
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    job.AppendJobPart(
                        rehydrate(
                            job,
                            stream,
                            sourceResource,
                            destinationResource));
                }
            }
        }
        return job;
    }
}
