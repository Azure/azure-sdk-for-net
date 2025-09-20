// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.DataMovement.JobPlan;
using static Azure.Storage.DataMovement.TransferInternalState;

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
        ValidateTransferOptions(transferOptions);

        TransferOperation transferOperation = new(id: transferId);
        TransferJobInternal transferJobInternal;

        // For single item transfers, wrap in single item container
        if (sourceResource is StorageResourceItem sourceItem &&
            destinationResource is StorageResourceItem destinationItem)
        {
            sourceResource = new SingleItemStorageResourceContainer(sourceItem);
            destinationResource = new SingleItemStorageResourceContainer(destinationItem);
        }

        if (sourceResource is StorageResourceContainer sourceContainer &&
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

    private async Task<TransferJobInternal> BuildContainerTransferJob(
        StorageResourceContainer sourceResource,
        StorageResourceContainer destinationResource,
        TransferOptions transferOptions,
        ITransferCheckpointer checkpointer,
        TransferOperation transferOperation,
        bool resumeJob,
        CancellationToken cancellationToken)
    {
        TransferJobInternal.CreateJobPartAsync createPart;
        Func<TransferJobInternal, JobPartPlanHeader, StorageResourceContainer, StorageResourceContainer, JobPartInternal> rehydrate;
        if (sourceResource.IsLocalResource() && !destinationResource.IsLocalResource())
        {
            createPart = StreamToUriJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToStreamToUriJobPartAsync;
        }
        else if (!sourceResource.IsLocalResource() && destinationResource.IsLocalResource())
        {
            createPart = UriToStreamJobPart.CreateJobPartAsync;
            rehydrate = DataMovementExtensions.ToUriToStreamJobPartAsync;
        }
        else if (!sourceResource.IsLocalResource() && !destinationResource.IsLocalResource())
        {
            createPart = ServiceToServiceJobPart.CreateJobPartAsync;
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
            createPart,
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
