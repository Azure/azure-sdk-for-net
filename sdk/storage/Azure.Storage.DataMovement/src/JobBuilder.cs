// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Buffers;
using Azure.Core.Pipeline;
using System;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement;

internal class JobBuilder
{
    private readonly ArrayPool<byte> _arrayPool;

    /// <summary>
    /// Defines the error handling method to follow when an error is seen. Defaults to
    /// <see cref="TransferErrorMode.StopOnAnyFailure"/>.
    ///
    /// See <see cref="TransferErrorMode"/>.
    /// </summary>
    private readonly TransferErrorMode _errorHandling;

    private ClientDiagnostics ClientDiagnostics { get; }

    /// <summary>
    /// Mocking constructor.
    /// </summary>
    protected JobBuilder()
    { }

    internal JobBuilder(
        ArrayPool<byte> arrayPool,
        TransferErrorMode errorHandling,
        ClientDiagnostics clientDiagnostics)
    {
        _arrayPool = arrayPool;
        _errorHandling = errorHandling;
        ClientDiagnostics = clientDiagnostics;
    }

    public virtual async Task<(TransferOperation Transfer, TransferJobInternal TransferInternal)> BuildJobAsync(
        StorageResource sourceResource,
        StorageResource destinationResource,
        TransferOptions transferOptions,
        ITransferCheckpointer checkpointer,
        string transferId,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        JobBuilder.ValidateTransferOptions(transferOptions);

        TransferOperation transferOperation = new(id: transferId);
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
                transferOperation,
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
                transferOperation,
                resumeJob,
                cancellationToken).ConfigureAwait(false);
        }
        // Invalid transfer
        else
        {
            throw Errors.InvalidTransferResourceTypes();
        }

        return (transferOperation, transferJobInternal);
    }

    private async Task<TransferJobInternal> BuildSingleTransferJob(
        StorageResourceItem sourceResource,
        StorageResourceItem destinationResource,
        TransferOptions transferOptions,
        ITransferCheckpointer checkpointer,
        TransferOperation transferOperation,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        TransferJobInternal.CreateJobPartSingleAsync single;
        TransferJobInternal.CreateJobPartMultiAsync multi;
        Func<TransferJobInternal, JobPartPlanHeader, StorageResourceItem, StorageResourceItem, JobPartInternal> rehydrate;
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
            transferOperation: transferOperation,
            sourceResource: sourceResource,
            destinationResource: destinationResource,
            single,
            multi,
            transferOptions: transferOptions,
            checkpointer: checkpointer,
            errorHandling: _errorHandling,
            arrayPool: _arrayPool,
            clientDiagnostics: ClientDiagnostics);

        int jobPartCount = await checkpointer.GetCurrentJobPartCountAsync(
                transferId: transferOperation.Id,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        if (resumeJob && jobPartCount > 0)
        {
            JobPartPlanHeader part = await checkpointer.GetJobPartAsync(transferOperation.Id, partNumber: 0).ConfigureAwait(false);
            job.AppendJobPart(
                rehydrate(
                    job,
                    part,
                    sourceResource,
                    destinationResource));
        }
        return job;
    }

    private async Task<TransferJobInternal> BuildContainerTransferJob(
        StorageResourceContainer sourceResource,
        StorageResourceContainer destinationResource,
        TransferOptions transferOptions,
        ITransferCheckpointer checkpointer,
        TransferOperation transferOperation,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        TransferJobInternal.CreateJobPartSingleAsync single;
        TransferJobInternal.CreateJobPartMultiAsync multi;
        Func<TransferJobInternal, JobPartPlanHeader, StorageResourceContainer, StorageResourceContainer, JobPartInternal> rehydrate;
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
            transferOperation: transferOperation,
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
            int jobPartCount = await checkpointer.GetCurrentJobPartCountAsync(
                transferId: transferOperation.Id,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            for (var currentJobPart = 0; currentJobPart < jobPartCount; currentJobPart++)
            {
                JobPartPlanHeader part = await checkpointer.GetJobPartAsync(transferOperation.Id, currentJobPart).ConfigureAwait(false);
                job.AppendJobPart(
                    rehydrate(
                        job,
                        part,
                        sourceResource,
                        destinationResource));
            }
        }
        return job;
    }

    private static void ValidateTransferOptions(TransferOptions transferOptions)
    {
        if (transferOptions?.InitialTransferSize != default)
        {
            Argument.AssertInRange(transferOptions.InitialTransferSize.Value, 1, long.MaxValue, nameof(transferOptions.InitialTransferSize));
        }
        if (transferOptions?.MaximumTransferChunkSize != default)
        {
            Argument.AssertInRange(transferOptions.MaximumTransferChunkSize.Value, 1, long.MaxValue, nameof(transferOptions.MaximumTransferChunkSize));
        }
    }
}
