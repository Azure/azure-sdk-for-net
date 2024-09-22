// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Buffers;
using Azure.Core.Pipeline;

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

    public async Task<(DataTransfer Transfer, TransferJobInternal TransferInternal)> BuildJobAsync(
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
        // If the resource cannot produce a Uri, it means it can only produce a local path
        // From here we only support an upload job
        if (sourceResource.IsLocalResource())
        {
            if (!destinationResource.IsLocalResource())
            {
                // Stream to Uri job (Upload Job)
                StreamToUriTransferJob streamToUriJob = new StreamToUriTransferJob(
                    dataTransfer: dataTransfer,
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
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
                        streamToUriJob.AppendJobPart(
                            streamToUriJob.ToJobPartAsync(
                                stream,
                                sourceResource,
                                destinationResource));
                    }
                }
                return streamToUriJob;
            }
            else // Invalid argument that both resources do not produce a Uri
            {
                throw Errors.InvalidSourceDestinationParams();
            }
        }
        else
        {
            // Source is remote
            if (!destinationResource.IsLocalResource())
            {
                // Service to Service Job (Copy job)
                ServiceToServiceTransferJob serviceToServiceJob = new ServiceToServiceTransferJob(
                    dataTransfer: dataTransfer,
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
                    transferOptions: transferOptions,
                    CheckPointFolderPath: checkpointer,
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
                        serviceToServiceJob.AppendJobPart(
                            serviceToServiceJob.ToJobPartAsync(
                                stream,
                                sourceResource,
                                destinationResource));
                    }
                }
                return serviceToServiceJob;
            }
            else
            {
                // Download to local operation
                // Service to Local job (Download Job)
                UriToStreamTransferJob uriToStreamJob = new UriToStreamTransferJob(
                    dataTransfer: dataTransfer,
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
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
                        uriToStreamJob.AppendJobPart(
                            uriToStreamJob.ToJobPartAsync(
                                stream,
                                sourceResource,
                                destinationResource));
                    }
                }
                return uriToStreamJob;
            }
        }
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
        // If the resource cannot produce a Uri, it means it can only produce a local path
        // From here we only support an upload job
        if (sourceResource.IsLocalResource())
        {
            if (!destinationResource.IsLocalResource())
            {
                // Stream to Uri job (Upload Job)
                StreamToUriTransferJob streamToUriJob = new StreamToUriTransferJob(
                    dataTransfer: dataTransfer,
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
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
                            streamToUriJob.AppendJobPart(
                                streamToUriJob.ToJobPartAsync(
                                    stream,
                                    sourceResource,
                                    destinationResource));
                        }
                    }
                }
                return streamToUriJob;
            }
            else // Invalid argument that both resources do not produce a Uri
            {
                throw Errors.InvalidSourceDestinationParams();
            }
        }
        else
        {
            // Source is remote
            if (!destinationResource.IsLocalResource())
            {
                // Service to Service Job (Copy job)
                ServiceToServiceTransferJob serviceToServiceJob = new ServiceToServiceTransferJob(
                    dataTransfer: dataTransfer,
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
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
                            serviceToServiceJob.AppendJobPart(
                                serviceToServiceJob.ToJobPartAsync(
                                    stream,
                                    sourceResource,
                                    destinationResource));
                        }
                    }
                }
                return serviceToServiceJob;
            }
            else
            {
                // Download to local operation
                // Service to Local job (Download Job)
                UriToStreamTransferJob uriToStreamJob = new UriToStreamTransferJob(
                    dataTransfer: dataTransfer,
                    sourceResource: sourceResource,
                    destinationResource: destinationResource,
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
                            uriToStreamJob.AppendJobPart(
                                uriToStreamJob.ToJobPartAsync(
                                    stream,
                                    sourceResource,
                                    destinationResource));
                        }
                    }
                }
                return uriToStreamJob;
            }
        }
    }
}
