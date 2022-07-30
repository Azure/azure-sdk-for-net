// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using Azure.Core;
using System.Buffers;
using System.Linq;
using Azure.Storage.Blob.Experiemental;
using Azure.Core.Pipeline;
using Microsoft;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Blob Directory Upload Job
    /// </summary>
    internal class BlobFolderUploadTransferJob : BlobTransferJobInternal
    {
        private string _sourceLocalPath;

        /// <summary>
        /// Gets the local path of the source file.
        /// </summary>
        public string SourceLocalPath => _sourceLocalPath;

        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// The destination blob client.
        /// </summary>
        internal BlobFolderClient DestinationBlobDirectoryClient;

        internal BlobFolderUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobFolderUploadOptions UploadOptions => _uploadOptions;

        private bool _overwrite;

        /// <summary>
        /// Defines whether to overwrite the blobs within the Blob Virtual Directory if they already exist.
        ///
        /// If the blob already exist and the Overwrite value is set to false
        /// then we will follow error handling based on what the user has set.
        ///
        /// If this value is not defined it is defaulted false.
        /// </summary>
        public bool Overwrite => _overwrite;

        private ClientDiagnostics _diagnostics;

        /// <summary>
        /// Client Diagnostics
        /// </summary>
        public ClientDiagnostics Diagnostics => _diagnostics;

        /// <summary>
        /// Creates Upload Transfer Job.
        ///
        /// TODO: better decription and parameters descriptions
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="overwrite"></param>
        /// <param name="uploadOptions"></param>
        /// <param name="errorOption"></param>
        public BlobFolderUploadTransferJob(
            string transferId,
            string sourceLocalPath,
            bool overwrite,
            BlobFolderClient destinationClient,
            BlobFolderUploadOptions uploadOptions,
            ErrorHandlingOptions errorOption)
            : base(transferId: transferId,
                  errorHandling: errorOption)
        {
            _sourceLocalPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            DestinationBlobDirectoryClient = destinationClient;
            DestinationBlobConfiguration = new BlobBaseConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.DirectoryPrefix
            };
            _uploadOptions = uploadOptions;
            _overwrite = overwrite;
            _diagnostics = new ClientDiagnostics(BlobFolderClientInternals.GetClientOptions(destinationClient));
        }

        /// <summary>
        /// Gets the Task for calling upload on a single blob
        /// </summary>
        /// <param name="fullPathName"></param>
        /// <returns></returns>
        internal async Task<Response<BlobContentInfo>> GetSingleUploadTaskAsync(string fullPathName)
        {
            // Replace backward slashes meant to be directory name separators
            string blobName = fullPathName.Substring(SourceLocalPath.Length + 1);
            blobName = blobName.Replace(@"\", "/");

            BlobBaseClient blobClient = DestinationBlobDirectoryClient.GetBlobBaseClient(blobName);
            BlockBlobClient blockBlobClient = (BlockBlobClient) blobClient;

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                AccessTier = UploadOptions.AccessTier,
                TransferOptions = UploadOptions.TransferOptions,
                ImmutabilityPolicy = UploadOptions.ImmutabilityPolicy,
                LegalHold = UploadOptions.LegalHold
            };

            Response<BlobContentInfo> response;

            // This would not support PIPE or FIFO files, that require to be open from both ends
            using (FileStream uploadStream = new FileStream(fullPathName, FileMode.Open, FileAccess.Read))
            {
                response = await blockBlobClient.UploadAsync(
                    uploadStream,
                    blobUploadOptions,
                    CancellationTokenSource.Token).ConfigureAwait(false);
            }
            return response;
        }

        /*
        public async IAsyncEnumerable<Task> ProcessDirectoryTransfer()
        {
            await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
            PathScannerFactory scannerFactory = new PathScannerFactory(SourceLocalPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<FileSystemInfo> pathList = scanner.Scan();

            List<Task> fileUploadTasks = new List<Task>();
            foreach (FileSystemInfo path in pathList)
            {
                if (path.GetType() == typeof(FileInfo))
                {
                    Task task = ProcessSingleUploadTransfer(path.FullName);
                    fileUploadTasks.Add(task);
                    yield return task;
                }
            }

            // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
            Task.WhenAll(fileUploadTasks).Wait();
            await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
        }
        */

        /*
        public IAsyncEnumerable<Task> ProcessSingleUploadTransfer(string fullPathName)
        {
            // Replace backward slashes meant to be directory name separators
            string blobName = fullPathName.Substring(SourceLocalPath.Length + 1);
            blobName = blobName.Replace(@"\", "/");

            BlobBaseClient destinationBlobClient = DestinationBlobDirectoryClient.GetBlobBaseClient(blobName);
            BlockBlobClient blockBlobClient = (BlockBlobClient) destinationBlobClient;

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                AccessTier = UploadOptions.AccessTier,
                TransferOptions = UploadOptions.TransferOptions,
                ImmutabilityPolicy = UploadOptions.ImmutabilityPolicy,
                LegalHold = UploadOptions.LegalHold
            };
            // Do only blockblob upload for now for now
            try
            {
                // This would not support PIPE or FIFO files, that require to be open from both ends
                using (FileStream uploadStream = new FileStream(fullPathName, FileMode.Open, FileAccess.Read))
                {
                    Response<BlobContentInfo> response = blockBlobClient.Upload(
                    uploadStream,
                    blobUploadOptions,
                    CancellationTokenSource.Token);
                    if (response != null && response.Value != null)
                    {
                    }
                    else
                    {
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                UploadOptions.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                fullPathName,
                                blockBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                if (!ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                {
                    PauseTransferJob();
                }
            }
            catch (IOException ex)
            {
                UploadOptions.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                fullPathName,
                                blockBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                if (!ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                {
                    PauseTransferJob();
                }
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
            }
            catch (Exception ex)
            {
                // Unexpected exception
                UploadOptions.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                fullPathName,
                                blockBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                PauseTransferJob();
            }
            throw new NotImplementedException();
        }
        */

        /// <summary>
        /// Translates job details
        /// </summary>
        public override BlobTransferJobProperties GetJobDetails()
        {
            return this.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Resumes respective job
        /// </summary>
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential">
        /// If a string is passed it is assumed that the value is the connection string to the destination.
        /// </param>
        public override void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default)
        {
            // Source Credentails are not necessary for this operation.
            if (destinationCredential != default)
            {
                // Connection String
                if (destinationCredential.GetType() == typeof(string))
                {
                    string connectionString = (string) destinationCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobConfiguration.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        DestinationBlobDirectoryClient = new BlobFolderClient(
                            connectionString,
                            DestinationBlobConfiguration.BlobContainerName,
                            DestinationBlobConfiguration.Name,
                            BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                    }
                    else
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                }
                else if (destinationCredential.GetType() == typeof(AzureSasCredential))
                {
                    AzureSasCredential sasCredential = (AzureSasCredential)destinationCredential;
                    DestinationBlobDirectoryClient = new BlobFolderClient(
                        DestinationBlobConfiguration.Uri,
                        sasCredential,
                        BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else if (destinationCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential sharedKeyCredential = (StorageSharedKeyCredential)destinationCredential;
                    DestinationBlobDirectoryClient = new BlobFolderClient(
                        DestinationBlobConfiguration.Uri,
                        sharedKeyCredential,
                        BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else if (destinationCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)destinationCredential;
                    DestinationBlobDirectoryClient = new BlobFolderClient(
                        DestinationBlobConfiguration.Uri,
                        tokenCredential,
                        BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(destinationCredential));
                }
            }
            // else
            // If no credentials are passed or default is passed then we will just use the
            // credentials that are currently cached (or if none, then we assume it's public access)

            // Read in Job Plan File
            // JobPlanReader.Read(file)
            OnTransferStatusChanged(StorageTransferStatus.Queued, false).EnsureCompleted();
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferStatus"></param>
        /// <param name="async"></param>
        /// <returns></returns>
        public async Task OnTransferStatusChanged(StorageTransferStatus transferStatus, bool async)
        {
            if (transferStatus != TransferStatus)
            {
                TransferStatus = transferStatus;
                if (async)
                {
                    await UploadOptions.GetTransferStatus().RaiseAsync(
                            new StorageTransferStatusEventArgs(
                                TransferId,
                                transferStatus,
                                true,
                                CancellationTokenSource.Token),
                            nameof(BlobFolderUploadOptions),
                            nameof(BlobFolderUploadOptions.TransferStatusEventHandler),
                            Diagnostics).ConfigureAwait(false);
                }
                else
                {
                    UploadOptions.GetTransferStatus()?.Invoke(new StorageTransferStatusEventArgs(
                                TransferId,
                                transferStatus,
                                true,
                                CancellationTokenSource.Token));
                }
            }
        }

        #region PartitionedBlockUploader
        internal static PartitionedFolderUploader<BlobFolderUploadOptions, BlobContentInfo> GetPartitionedUploader(
            BlobFolderUploadTransferJob job,
            BlockBlobClient destinationClient,
            string sourcePath,
            StorageTransferOptions transferOptions,
            // TODO #27253
            //UploadTransactionalHashingOptions validationOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            => new PartitionedFolderUploader<BlobFolderUploadOptions, BlobContentInfo>(
                GetPartitionedUploaderBehaviors(job, destinationClient, sourcePath),
                transferOptions,
                //validationOptions,
                arrayPool,
                operationName);

        internal static PartitionedFolderUploader<BlobFolderUploadOptions, BlobContentInfo>.Behaviors GetPartitionedUploaderBehaviors(
            BlobFolderUploadTransferJob job,
            BlockBlobClient destinationClient,
            string sourcePath)
        {
            return new PartitionedFolderUploader<BlobFolderUploadOptions, BlobContentInfo>.Behaviors
            {
                // TODO #27253
                SingleUpload = async (stream, args, progressHandler, /*hashingOptions,*/ operationName, async, cancellationToken)
                    =>
                {
                    BlobUploadOptions uploadOptions = new BlobUploadOptions()
                    {
                        AccessTier = args?.AccessTier,
                        ImmutabilityPolicy = args?.ImmutabilityPolicy,
                        LegalHold = args?.LegalHold,
                    };
                    try
                    {
                        Response<BlobContentInfo> contentInfo;
                        if (async)
                        {
                            // Check for overwrite conditions.
                            contentInfo = await BlockBlobClientInternals.PutBlobCallAsync(
                               destinationClient,
                               stream,
                               uploadOptions,
                               operationName,
                               cancellationToken).ConfigureAwait(false);
                            args?.GetUploadCompleted()?.Invoke(new BlobUploadSuccessEventArgs(
                                job.TransferId,
                                sourcePath,
                                destinationClient,
                                contentInfo.GetRawResponse(),
                                false,
                                cancellationToken));
                            await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                        }
                        else
                        {
                            // Check for overwrite conditions.
                            contentInfo = BlockBlobClientInternals.PutBlobCall(
                               destinationClient,
                               stream,
                               uploadOptions,
                               operationName,
                               cancellationToken);
                            args?.GetUploadCompleted()?.Invoke(new BlobUploadSuccessEventArgs(
                                job.TransferId,
                                sourcePath,
                                destinationClient,
                                contentInfo.GetRawResponse(),
                                false,
                                cancellationToken));
                            job.OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                        }
                        return contentInfo;
                    }
                    catch (RequestFailedException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                        {
                            job.PauseTransferJob();
                        }
                    }
                    catch (IOException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                        {
                            job.PauseTransferJob();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Job was cancelled
                    }
                    catch (Exception ex)
                    {
                        // Unexpected exception
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        job.PauseTransferJob();
                    }
                    return default;
                },
                // TODO #27253
                UploadPartition = async (stream, offset, args, progressHandler, /*validationOptions,*/ async, cancellationToken)
                    =>
                {
                    // Stage Block only accepts LeaseId.
                    //blobrequestconditions conditions = null;
                    //if (args?.conditions != null)
                    //{
                    //    conditions = new blobrequestconditions
                    //    {
                    //        leaseid = args.conditions.leaseid
                    //    };
                    //}
                    try
                    {
                        if (async)
                        {
                            await destinationClient.StageBlockAsync(
                                Shared.StorageExtensions.GenerateBlockId(offset),
                                stream,
                                // TODO #27253
                                //new BlockBlobStageBlockOptions()
                                //{
                                //    TransactionalHashingOptions = hashingOptions,
                                //    Conditions = conditions,
                                //    ProgressHandler = progressHandler
                                //},
                                transactionalContentHash: default,
                                default,
                                progressHandler,
                                cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            destinationClient.StageBlock(
                                    Shared.StorageExtensions.GenerateBlockId(offset),
                                    stream,
                                    // TODO #27253
                                    //new BlockBlobStageBlockOptions()
                                    //{
                                    //    TransactionalHashingOptions = hashingOptions,
                                    //    Conditions = conditions,
                                    //    ProgressHandler = progressHandler
                                    //},
                                    transactionalContentHash: default,
                                    default,
                                    progressHandler,
                                    cancellationToken);
                        }
                    }
                    // If we fail to stage a block, we need to make sure the rest of the stage blocks are cancelled
                    // (Core already performs the retry policy on the one stage block request which means the rest are not worth to continue)
                    catch (RequestFailedException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                        {
                            job.PauseTransferJob();
                        }
                    }
                    catch (IOException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                        {
                            job.PauseTransferJob();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Job was cancelled
                    }
                    catch (Exception ex)
                    {
                        // Unexpected exception
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        job.PauseTransferJob();
                    }
                },
                CommitPartitionedUpload = async (partitions, args, async, cancellationToken)
                =>
                {
                    CommitBlockListOptions options = new CommitBlockListOptions()
                    {
                        AccessTier = args?.AccessTier,
                        ImmutabilityPolicy = args?.ImmutabilityPolicy,
                        LegalHold = args?.LegalHold,
                    };
                    try
                    {
                        if (async)
                        {
                            return await destinationClient.CommitBlockListAsync(
                             partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                             options,
                             cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            return destinationClient.CommitBlockList(
                              partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                              options,
                              cancellationToken);
                        }
                    }
                    catch (RequestFailedException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                        {
                            job.PauseTransferJob();
                        }
                    }
                    catch (IOException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                        {
                            job.PauseTransferJob();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Job was cancelled
                    }
                    catch (Exception ex)
                    {
                        // Unexpected exception
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        sourcePath,
                                        destinationClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        job.PauseTransferJob();
                    }
                    return default;
                },
                Scope = operationname =>
                {
                    StorageClientDiagnostics diagnostics = new StorageClientDiagnostics(BlobBaseClientInternals.GetClientOptions(destinationClient));
                    return diagnostics.CreateScope(operationname);
                }
            };
        }
        #endregion

        public override IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
        {
            throw new NotImplementedException();
        }

        public override IAsyncEnumerable<Func<Task>> ProcessPartToChunkAsync()
        {
            throw new NotImplementedException();
        }
    }
}
