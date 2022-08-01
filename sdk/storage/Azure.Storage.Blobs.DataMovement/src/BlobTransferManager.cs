// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Microsoft;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// The <see cref="BlobTransferManager"/> allows you to manipulate
    /// Azure Storage Block Blobs by queueing up upload and download transfer
    /// items, manage those operations, track progress and pause and resume
    /// transfer processes.
    ///
    /// TODO: update description to include page blobs, append blobs, SMB Files
    /// and DataLake Files once added.
    /// </summary>
    public class BlobTransferManager
    {
        // Indicates whether the current thread is processing Jobs.
        private static Task _currentTaskIsProcessingJob;

        // Indicates whether the current thread is processing Jobs Parts.
        private static Task _currentTaskIsProcessingJobPart;

        // Indicates whether the current thread is processing Jobs Chunks.
        private static Task _currentTaskIsProcessingJobChunk;

        // This value can fluctuate depending on if we've reached max capacity
        // Future capability for it to flucate based on throttling and bandwidth
        private int _maxDownloaders;

        /// <summary>
        /// If set, store the transfer states for each job in the locally at the path specified
        /// </summary>
        private string _transferStateLocalDirectoryPath;

        /// <summary>
        /// If set, store the transfer states for each job in the locally at the path specified
        /// </summary>
        protected internal string TransferStateLocalDirectoryPath => _transferStateLocalDirectoryPath;

        //TODO: for future use of uploading the transfer plan files remotely to the service
        internal BlobFolderClient TransferStateDirectoryClient;

        /// <summary>
        /// Channel of Jobs waiting to divided into job parts/files.
        ///
        /// Limit 1 task to convert jobs to job parts.
        /// </summary>
        private Channel<BlobTransferJobInternal> _jobsToProcessChannel { get; set; }

        /// <summary>
        /// Channel of Job parts / files to be divided into chunks / requests
        ///
        /// Limit 64 tasks to convert job parts to chunks.
        /// </summary>
        private Channel<BlobJobPartInternal> _partsToProcessChannel { get; set; }

        /// <summary>
        /// Channel of Job chunks / requests to send to the service.
        ///
        /// Limit 4-300/Max amount of tasks allowed to process chunks
        /// </summary>
        private Channel<Func<Task>> _chunksToProcessChannel { get; set; }

        /// <summary>
        /// Total jobs indexed by the job id.
        ///
        /// Needed to keep track of jobs and communicate to each one or gather information form the job
        /// </summary>
        private IDictionary<string, BlobTransferJobInternal> _jobDictionary { get; set; }

        private long _currentOngoingTaskCount;

        /// <summary>
        /// Complete amount of concurrent threads
        /// </summary>
        internal int CurrentOngoingTaskCount
        {
            get
            {
                return (int) Interlocked.Read(ref _currentOngoingTaskCount);
            }
            set
            {
                Interlocked.Exchange(ref _currentOngoingTaskCount, value);
            }
        }

        /// <summary>
        /// The current state of the StorageTransferMangager
        /// </summary>
        internal StorageManagerTransferStatus _managerTransferStatus;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private StorageTransferManagerOptions _options;

        /// <summary>
        /// Transfer Manager options
        /// </summary>
        private StorageTransferManagerOptions Options => _options;

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        public BlobTransferManager()
        {
        }

        ///<summary>
        /// Initializes a new instance of the StorageTransferManager
        /// class.
        /// </summary>
        /// <param name="options">Directory path where transfer state is kept.</param>
        public BlobTransferManager(StorageTransferManagerOptions options)
            : this()
        {
            _jobDictionary = new Dictionary<string, BlobTransferJobInternal>();
            _managerTransferStatus = StorageManagerTransferStatus.Idle;
            _jobsToProcessChannel = Channel.CreateUnbounded<BlobTransferJobInternal>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                    SingleReader = true, // To limit the task of processing one job at a time.
                    // Allow single writers
                });
            _partsToProcessChannel = Channel.CreateUnbounded<BlobJobPartInternal>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                });
            _chunksToProcessChannel = Channel.CreateUnbounded<Func<Task>>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                });
            _options = options;
            _currentOngoingTaskCount = 0;
            _maxDownloaders = Constants.DataMovement.InitialDownloadFileThreads;
            _currentTaskIsProcessingJob = Task.Run(() => NotifyOfPendingJobProcessing());
            _currentTaskIsProcessingJobPart = Task.Run(() => NotifyOfPendingJobPartProcessing());
            _currentTaskIsProcessingJobChunk = Task.Run(() => NotifyOfPendingJobChunkProcessing());
        }

        /// <summary>
        /// Initializes a new instance of the StorageTransferManager
        /// class and specifying a local directory path to store the transfer state file.
        /// </summary>
        /// <param name="transferStateDirectoryPath">
        /// Optional path to set for the Transfer State File.
        ///
        /// If this file is not set and a transfer is started using
        /// the transfer manager, we will default to storing the file in
        /// %USERPROFILE%\.azstoragedml directory on Windows OS
        /// and $HOME$\.azstoragedml directory on Mac and Linux based OS.
        ///
        /// TODO: this will also hold the the information of all exceptions that
        /// have occured during the transfer state. In the case that too many
        /// exceptions happened during a transfer job and the customer wants
        /// to go through each exception and resolve each one.
        /// </param>
        /// <param name="options"></param>
        public BlobTransferManager(string transferStateDirectoryPath, StorageTransferManagerOptions options)
            : this(options)
        {
            _transferStateLocalDirectoryPath = transferStateDirectoryPath;
        }

        /// <summary>
        /// Initializes a new instance of the StorageTransferManager
        /// class and specifying a local directory path to store the transfer state file.
        /// </summary>
        /// <param name="transferStateFolderClient">
        /// Optional remote directory path to save the Transfer State Files.
        ///
        /// If this directory client is not set and a transfer is started using
        /// the transfer manager, we will default to storing the file locally in
        /// %USERPROFILE%\.azstoragedml directory on Windows OS
        /// and $HOME$\.azstoragedml directory on Mac and Linux based OS.
        ///
        /// TODO: this will also hold the the information of all exceptions that
        /// have occured during the transfer state. In the case that too many
        /// exceptions happened during a transfer job and the customer wants
        /// to go through each exception and resolve each one.
        /// </param>
        /// <param name="options"></param>
        internal BlobTransferManager(BlobFolderClient transferStateFolderClient, StorageTransferManagerOptions options)
            : this(options)
        {
            TransferStateDirectoryClient = transferStateFolderClient;
        }

        /// <summary>
        /// Add Blob Upload Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="uploadOptions"></param>
        /// <returns>A guid of the job id</returns>
        public async Task<BlobTransferJobProperties> ScheduleUploadAsync(
            string sourceLocalPath,
            BlockBlobClient destinationClient,
            BlobSingleUploadOptions uploadOptions = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists

            BlobUploadTransferJob transferJob = new BlobUploadTransferJob(
                transferId,
                sourceLocalPath,
                destinationClient,
                uploadOptions,
                Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures);
            await QueueJobAsync(transferJob).ConfigureAwait(false);
            _jobDictionary.Add(transferId, transferJob);
                //transferJob.ProcessUploadTransfer(_taskFactory, _jobTransferScheduler),

            return transferJob.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Add Blob Download Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<BlobTransferJobProperties> ScheduleDownloadAsync(
            BlobBaseClient sourceClient,
            string destinationLocalPath,
            BlobSingleDownloadOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobDownloadTransferJob transferJob = new BlobDownloadTransferJob(
                transferId,
                sourceClient,
                destinationLocalPath,
                options,
                Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures);
                await QueueJobAsync(transferJob).ConfigureAwait(false);
                //action: transferJob.ProcessDownloadTransfer(),
            return transferJob.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Add Upload Blob Directory Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="overwrite">
        /// Defines whether to overwrite the blobs within the Blob Virtual Directory if they already exist.
        /// If set to false, blobs will not be overwritten if they already exists. Blobs that are already exist,
        /// will be skipped. This will not end in a failure. If set to true, the blob will be overwritten if
        /// it already exists.
        ///
        /// Defaults to false.
        /// </param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// TODO: remove suppression
        public async Task<BlobTransferJobProperties> ScheduleFolderUploadAsync(
            string sourceLocalPath,
            BlobFolderClient destinationClient,
            bool overwrite = false,
            BlobFolderUploadOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobFolderUploadTransferJob transferJob = new BlobFolderUploadTransferJob(
                transferId,
                sourceLocalPath,
                overwrite,
                destinationClient,
                options,
                Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures);
                await QueueJobAsync(transferJob).ConfigureAwait(false);

            // Queue task to scan the local directory for paths to upload
            // As each local path is found, it is added to the queue as well.
            PathScannerFactory scannerFactory = new PathScannerFactory(transferJob.SourceLocalPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            IEnumerable<FileSystemInfo> pathList = scanner.Scan();

            List<Task> fileUploadTasks = new List<Task>();
            foreach (FileSystemInfo path in pathList)
            {
                if (path.GetType() == typeof(FileInfo))
                {
                    //transferJob.ProcessSingleUploadTransfer(path.FullName);
                    //fileUploadTasks.Add(singleUploadTask);
                }
            }

            // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
            Task.WhenAll(fileUploadTasks).Wait();
#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
            await options.GetTransferStatus().RaiseAsync(
                new StorageTransferStatusEventArgs(
                    transferId,
                    StorageTransferStatus.Completed,
                    true,
                    transferJob.CancellationTokenSource.Token),
                nameof(BlobTransferManager),
                nameof(BlobFolderUploadOptions.FolderCompletedEventHandler),
                transferJob.Diagnostics).ConfigureAwait(false);
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.
            return transferJob.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Add Download Blob Directory Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient"></param>
        /// <param name="destinationLocalPath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// TODO: remove suppression
        public async Task<BlobTransferJobProperties> ScheduleFolderDownloadAsync(
            BlobFolderClient sourceClient,
            string destinationLocalPath,
            BlobFolderDownloadOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobFolderDownloadTransferJob transferJob = new BlobFolderDownloadTransferJob(
                transferId,
                sourceClient,
                destinationLocalPath,
                options,
                Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures);
                await QueueJobAsync(transferJob).ConfigureAwait(false);
            _jobDictionary.Add(transferId, transferJob);
            // Queue task to scan the remote directory for paths to download
            // As each blob is found, it is added to the queue as well.
            Pageable<BlobItem> blobs = transferJob.SourceBlobDirectoryClient.GetBlobs();
            List<Task> fileUploadTasks = new List<Task>();
            foreach (BlobItem blob in blobs)
            {
                //transferJob.ProcessSingleDownloadTransfer(blob.Name);
                //fileUploadTasks.Add(singleDownloadTask);
            }
            // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
            Task.WhenAll(fileUploadTasks).Wait();

            return transferJob.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Add Blob Copy Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceUri"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod">Copy Method</param>
        /// <param name="copyOptions"></param>
        /// <returns>A guid of the job id</returns>
        public async Task<BlobTransferJobProperties> ScheduleCopyAsync(
            Uri sourceUri,
            BlobBaseClient destinationClient,
            BlobCopyMethod copyMethod,
            BlobCopyFromUriOptions copyOptions = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists

            BlobServiceCopyTransferJob transferJob = new BlobServiceCopyTransferJob(
                transferId,
                sourceUri,
                destinationClient,
                copyMethod,
                copyOptions,
                Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures);
                await QueueJobAsync(transferJob).ConfigureAwait(false);
            _jobDictionary.Add(transferId, transferJob);
            //transferJob.ProcessCopyTransfer();

            return transferJob.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Add Blob Copy Job to perform
        ///
        /// TODO: Better description and param comments.
        /// </summary>
        /// <param name="sourceClient">
        /// The Source folder Uri to copy blobs from.
        /// The source must allow permissions to list in the container.
        /// TODO: add minimum SAS permissions requirements (e.g. permissions for both contaner and blob level, rl permissions)</param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod">Copy Method</param>
        /// <param name="copyOptions"></param>
        /// <returns>A guid of the job id</returns>
        public async Task<BlobTransferJobProperties> ScheduleFolderCopyAsync(
        BlobFolderClient sourceClient,
        BlobFolderClient destinationClient,
        BlobCopyMethod copyMethod,
        BlobFolderCopyFromUriOptions copyOptions = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobFolderServiceCopyTransferJob transferJob = new BlobFolderServiceCopyTransferJob(
                transferId,
                sourceClient,
                destinationClient,
                copyMethod,
                copyOptions,
                Options?.ErrorHandling ?? ErrorHandlingOptions.PauseOnAllFailures);
                await QueueJobAsync(transferJob).ConfigureAwait(false);
            _jobDictionary.Add(transferId , transferJob);
            // Queue task to scan the remote directory for paths to download
            // As each blob is found, it is added to the queue as well.
            Pageable<BlobItem> blobs = sourceClient.GetBlobs();
            /* TODO: move this to Core.Diagnostics Logger
            transferJob.Logger.LogAsync(
            logLevel: DataMovementLogLevel.Information,
            message: $"Completed enumerating files within source directory: {transferJob.SourceDirectoryUri.AbsoluteUri}\n",
            false).EnsureCompleted();
            */

            List<Task> fileUploadTasks = new List<Task>();
            foreach (BlobItem blob in blobs)
            {
                //ProcessSingleCopyTransfer(blob.Name);
                //fileUploadTasks.Add(singleDownloadTask);
            }

            // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
            Task.WhenAll(fileUploadTasks).Wait();
            return transferJob.ToBlobTransferJobDetails();
        }

        /*
        /// <summary>
        /// For those who have existing transfers that were paused
        /// but now want to resume it can do so by passing the file path
        /// to the plan file.
        ///
        /// The file will be read to see where the transfer left off
        /// and continue from there.
        ///
        /// This Job will have the same job id as contained in the job file.
        /// </summary>
        /// <param name="planFilePath"></param>
        /// <returns></returns>
        public string ScheduleJobFromPlanFile(string planFilePath)
        {
        //TODO: stub
        string transferId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
        return transferId;
        }
        */

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public virtual BlobTransferJobProperties GetJobProperties(string transferId)
        {
            if (_jobDictionary.TryGetValue(transferId, out var currentJob))
            {
                return currentJob.GetJobDetails();
            }
            else
            {
                throw Errors.InvalidTransferId(nameof(GetJobProperties), transferId);
            }
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        public virtual void PauseTransferJob(string transferId)
        {
            PauseTransferJobInternal(transferId, false).EnsureCompleted();
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        public virtual async Task PauseTransferJobAsync(string transferId)
        {
            await PauseTransferJobInternal(transferId, true).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="async"></param>
        internal async Task PauseTransferJobInternal(string transferId, bool async)
        {
            if (_jobDictionary.TryGetValue(transferId, out var currentJob))
            {
                if (async)
                {
                    await currentJob.PauseTransferJobAsync().ConfigureAwait(false);
                }
                else
                {
                    currentJob.PauseTransferJob();
                }
            }
            else
            {
                throw Errors.InvalidTransferId(nameof(PauseTransferJobAsync), transferId);
            }
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceCredentials"></param>
        /// <param name="destinationCredentials"></param>
        public virtual void ResumeTransferJob(
            string transferId,
            object sourceCredentials = default,
            object destinationCredentials = default)
        {
            ResumeTransferJobInternal(
                transferId,
                sourceCredentials,
                destinationCredentials,
                false).EnsureCompleted();
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceCredentials"></param>
        /// <param name="destinationCredentials"></param>
        public virtual async Task ResumeTransferJobAsync(
            string transferId,
            object sourceCredentials = default,
            object destinationCredentials = default)
        {
            await ResumeTransferJobInternal(
                transferId,
                sourceCredentials,
                destinationCredentials,
                true).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceCredentials"></param>
        /// <param name="destinationCredentials"></param>
        /// <param name="async"></param>
        internal async Task ResumeTransferJobInternal(
            string transferId,
            object sourceCredentials,
            object destinationCredentials,
            bool async = false)
        {
            if (_jobDictionary.TryGetValue(transferId, out var currentJob))
            {
                if (currentJob.CancellationTokenSource.IsCancellationRequested)
                {
                    // The job is currently getting cancelled or paused
                    throw Errors.JobCancelledOrPaused(transferId);
                }
                else
                {
                    currentJob.ProcessResumeTransfer(sourceCredentials, destinationCredentials);
                    /*
                    Task singleDownloadTask = _taskFactory.StartNew(
                            action: currentJob.ProcessResumeTransfer(sourceCredentials, destinationCredentials),
                            cancellationToken: currentJob.CancellationTokenSource.Token,
                            creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.None would be better if the transfer is small
                            scheduler: _jobTransferScheduler);
                    */
                    if (async)
                    {
                        await currentJob.PlanJobWriter.SetTransferStatusAsync("Job Resume").ConfigureAwait(false);
                    }
                    else
                    {
                        currentJob.PlanJobWriter.SetTransferStatus("Job Resume");
                    }
                }
            }
            else
            {
                throw Errors.InvalidTransferId(nameof(ResumeTransferJobAsync), transferId);
            }
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="transferStatus">Resume job based on status</param>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task ResumeTransferJobStatusAsync(StorageTransferStatus transferStatus)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (transferStatus != StorageTransferStatus.Completed ||
                transferStatus != StorageTransferStatus.InProgress ||
                transferStatus != StorageTransferStatus.Queued)
            {
                foreach (KeyValuePair<string, BlobTransferJobInternal> currentJob in _jobDictionary)
                {
                    if (transferStatus.Equals(currentJob.Value.GetTransferStatus()))
                    {
                        if (!currentJob.Value.CancellationTokenSource.IsCancellationRequested)
                        {
                            currentJob.Value.ProcessResumeTransfer();
                        }
                    }
                    // TODO: do we have to throw an error if there are no jobs with this job status?
                }
            }
            else
            {
                throw Errors.JobStatusInvalidResume(transferStatus.ToString());
            }
        }

        /// <summary>
        /// Resumes transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public virtual void ResumeAllTransferJobs()
        {
            _managerTransferStatus = StorageManagerTransferStatus.InProgress;

            foreach (KeyValuePair<string,BlobTransferJobInternal> currentJob in _jobDictionary)
            {
                currentJob.Value.ProcessResumeTransfer();
                //TODO: log cancellation of job
                //Call job update transfer status
            }
            _managerTransferStatus = StorageManagerTransferStatus.Idle;
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public virtual void PauseAllTransferJobs()
        {
            PauseAllTransferJobsInternal(false).EnsureCompleted();
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public virtual async Task PauseAllTransferJobsAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            await PauseAllTransferJobsInternal(true).ConfigureAwait(false);
        }

        /// <summary>
        /// Pauses transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        internal async Task PauseAllTransferJobsInternal(bool async)
        {
            _managerTransferStatus = StorageManagerTransferStatus.Pausing;

            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _jobDictionary)
            {
                if (async)
                {
                    await job.Value.PauseTransferJobAsync().ConfigureAwait(false);
                }
                else
                {
                    job.Value.PauseTransferJob();
                }
                //TODO: log cancellation of job
                //Call job update transfer status
            }
            _managerTransferStatus = StorageManagerTransferStatus.Idle;
        }

        /// <summary>
        /// Cancel Transfers that are currently being processed.
        /// Removes all transfers that are being processed and waiting
        /// to be performed.
        ///
        /// In cancelling tasks, we are also removing all the transfer state
        /// plan files of all the jobs because we are removing all jobs.
        ///
        /// In order to rerun the job, the customer must readd the job back in.
        /// </summary>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task CancelAllTransferJobsAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // This would remove all transfers from the queue and not log the current progress
            // to the file. Maybe we would also remove the file too as a part of cleanup.
            _managerTransferStatus = StorageManagerTransferStatus.Cancelling;
            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _jobDictionary)
            {
                // Probably look to do this in parallel.
                // TODO: catch any errors that fly up the stack and attempt
                // to delete the other log or plan files, but throw the proper exception
                // or list of files that could not be deleted.
                job.Value.PlanJobWriter.RemovePlanFile();
            }
        }

        /// <summary>
        /// Removes all plan files/ DataTransferState Transfer files and any jobs and their information cached.
        /// </summary>
        public virtual void CleanTransferStateFolderPath()
        {
            if (_managerTransferStatus == StorageManagerTransferStatus.InProgress)
            {
                // TODO: throw proper exception
                throw new Exception("Please cancel or pause the transfer jobs before cleaning");
            }
            else if (_managerTransferStatus == StorageManagerTransferStatus.Pausing)
            {
                // TODO: throw proper exception
                throw new Exception("Please wait until all transfer jobs have paused");
            }
            else if (_managerTransferStatus == StorageManagerTransferStatus.Cancelling)
            {
                throw new Exception("Please wait until all transfer jobs have cancelled");
            }
            _managerTransferStatus = StorageManagerTransferStatus.Cleaning;
            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _jobDictionary)
            {
                // Probably look to do this in parallel.
                // TODO: catch any errors that fly up the stack and attempt
                // to delete the other log or plan files, but throw the proper exception
                // or list of files that could not be deleted.

                //TODO: do we have to remove log files?
                //job.Value.Logger.removeLogFile();
                job.Value.PlanJobWriter.RemovePlanFile();
            }
            _jobDictionary.Clear();
        }

        #region Job Channel Management
        private async Task QueueJobAsync(BlobTransferJobInternal job)
        {
            await _jobsToProcessChannel.Writer.WriteAsync(job).ConfigureAwait(false);
        }

        // Inform the Reader that there's work to be executed for this Channel.
        private async Task NotifyOfPendingJobProcessing()
        {
            // Process all available items in the queue.
            while (await _jobsToProcessChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                BlobTransferJobInternal item = await _jobsToProcessChannel.Reader.ReadAsync().ConfigureAwait(false);
                // Execute the task we pulled out of the queue
                await foreach (BlobJobPartInternal partItem in item.ProcessJobToJobPartAsync().ConfigureAwait(false))
                {
                    await QueueJobPartAsync(partItem).ConfigureAwait(false);
                }
            }
        }
        #endregion Job Channel Management

        #region Job Part Channel Management
        private async Task QueueJobPartAsync(BlobJobPartInternal part)
        {
            await _partsToProcessChannel.Writer.WriteAsync(part).ConfigureAwait(false);
        }

        // Inform the Reader that there's work to be executed for this Channel.
        private async Task NotifyOfPendingJobPartProcessing()
        {
            List<Task> chunkRunners = new List<Task>(Constants.DataMovement.MaxJobPartReaders);
            while (await _partsToProcessChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                BlobJobPartInternal item = await _partsToProcessChannel.Reader.ReadAsync().ConfigureAwait(false);
                if (chunkRunners.Count >= Constants.DataMovement.MaxJobPartReaders)
                {
                    // Clear any completed blocks from the task list
                    int removedRunners = chunkRunners.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    // If no runners have finished..
                    if (removedRunners == 0)
                    {
                        // Wait for at least one runner to finish
                        await Task.WhenAny(chunkRunners).ConfigureAwait(false);
                        chunkRunners.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                }
                // Execute the task we pulled out of the queue
                item.SetQueueChunkDelegate(async (item) => await QueueJobChunkAsync(item).ConfigureAwait(false));
                Task task = item.ProcessJobPartToJobChunk();

                // Add task to Chunk Runner to keep track of how many are running
                chunkRunners.Add(task);
            }
        }
        #endregion Job Part Channel Management

        #region Job Chunk Management
        private async Task QueueJobChunkAsync(Func<Task> item)
        {
            await _chunksToProcessChannel.Writer.WriteAsync(item).ConfigureAwait(false);
        }

        private async Task NotifyOfPendingJobChunkProcessing()
        {
            List<Task> _currentChunkTasks = new List<Task>(Constants.DataMovement.MaxJobChunkTasks);
            while (await _chunksToProcessChannel.Reader.WaitToReadAsync().ConfigureAwait(false))
            {
                Func<Task> item = await _chunksToProcessChannel.Reader.ReadAsync().ConfigureAwait(false);
                // If we run out of workers
                if (_currentChunkTasks.Count >= _maxDownloaders)
                {
                    if (_currentChunkTasks.Exists(x => x.IsCompleted || x.IsCanceled || x.IsFaulted))
                    {
                        // Clear any completed blocks from the task list
                        _currentChunkTasks.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                    else
                    {
                        await Task.WhenAny(_currentChunkTasks).ConfigureAwait(false);
                        _currentChunkTasks.RemoveAll(x => x.IsCompleted || x.IsCanceled || x.IsFaulted);
                    }
                }

                // Execute the task we pulled out of the queue
                Task task = Task.Run(item);
                _currentChunkTasks.Add(task);
            }
        }
        #endregion Job Chunk Management
    }
}
