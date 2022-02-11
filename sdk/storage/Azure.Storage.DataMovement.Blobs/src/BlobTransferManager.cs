// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage;
using Azure.Storage.DataMovement.Blobs.Models;
using System.IO;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement.Blobs
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
    public class BlobTransferManager : StorageTransferManager
    {
        internal BlobVirtualDirectoryClient TransferStateDirectoryClient;
        /// <summary>
        /// Total Transfer Jobs
        ///
        /// Indexed by the job id
        /// </summary>
        private IDictionary<string, BlobTransferJobInternal> _totalTransferJobs { get; set; }

        /// <summary>
        /// internal job transfer to scan for job sand schedule requests accordingly
        /// </summary>
        private BlobJobTransferScheduler _jobTransferScheduler { get; set; }

        /// <summary>
        /// Task Factory
        /// </summary>
        private TaskFactory _taskFactory { get; set; }

        /// <summary>
        /// The current state of the StorageTransferMangager
        /// </summary>
        internal StorageManagerTransferStatus _managerTransferStatus;

        /// <summary>
        /// Constructor for mocking
        /// </summary>
        protected internal BlobTransferManager()
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class.
        /// </summary>
        /// <param name="options">Directory path where transfer state is kept.</param>
        public BlobTransferManager(StorageTransferManagerOptions options)
            : base(options)
        {
            _jobTransferScheduler = new BlobJobTransferScheduler(options?.ConcurrencyForLocalFilesystemListing, options?.ConcurrencyForServiceListing);
            _taskFactory = new TaskFactory(_jobTransferScheduler);
            _managerTransferStatus = StorageManagerTransferStatus.Idle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
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
            : base(transferStateDirectoryPath, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTransferManager"/>
        /// class and specifying a local directory path to store the transfer state file.
        /// </summary>
        /// <param name="transferStateDirectoryClient">
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
        public BlobTransferManager(BlobVirtualDirectoryClient transferStateDirectoryClient, StorageTransferManagerOptions options)
            : this(options)
        {
            TransferStateDirectoryClient = transferStateDirectoryClient;
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
        public string ScheduleUpload(
            string sourceLocalPath,
            BlobClient destinationClient,
            BlobUploadOptions uploadOptions = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists

            BlobUploadTransferJob transferJob = new BlobUploadTransferJob(jobId, sourceLocalPath, destinationClient, uploadOptions);
            _totalTransferJobs.Add(jobId, transferJob);
            Task uploadTask = _taskFactory.StartNew(
                action: transferJob.ProcessUploadTransfer(),
                cancellationToken: transferJob.CancellationTokenSource.Token,
                creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.
                scheduler: _jobTransferScheduler);

            // TODO: remove stub
            return jobId;
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
        public string ScheduleDownload(
            BlobClient sourceClient,
            string destinationLocalPath,
            BlobDownloadToOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobDownloadTransferJob transferJob = new BlobDownloadTransferJob(jobId, sourceClient, destinationLocalPath, options);
            Task downloadTask = _taskFactory.StartNew(
                action: transferJob.ProcessDownloadTransfer(),
                cancellationToken: transferJob.CancellationTokenSource.Token,
                creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.None would be better if the transfer is small
                scheduler: _jobTransferScheduler);
            return jobId;
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
        public string ScheduleUploadDirectory(
            string sourceLocalPath,
            BlobVirtualDirectoryClient destinationClient,
            bool overwrite = false,
            BlobDirectoryUploadOptions options = default)
        {
            //TODO: if check the local path exists and not a directory
            // or we can go and check at the start of the job, to prevent
            // having to check the existence of the path twice.
            string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
            BlobUploadDirectoryTransferJob transferJob = new BlobUploadDirectoryTransferJob(jobId, sourceLocalPath, overwrite, destinationClient, options);
            _totalTransferJobs.Add(jobId, transferJob);

            // Queue task to scan the local directory for paths to upload
            // As each local path is found, it is added to the queue as well.
            Task uploadDirectoryTask = _taskFactory.StartNew(
                action: () => {
                    /* TODO: move this to Core.Diagnostics Logger
                    transferJob.Logger.LogAsync(
                        logLevel: DataMovementLogLevel.Information,
                        message: $"Begin enumerating files within source directory: {transferJob.SourceLocalPath}",
                        false).EnsureCompleted();
                    */
                    PathScannerFactory scannerFactory = new PathScannerFactory(transferJob.SourceLocalPath);
                    PathScanner scanner = scannerFactory.BuildPathScanner();
                    IEnumerable<FileSystemInfo> pathList = scanner.Scan();
                    /* TODO: move this to Core.Diagnostics Logger
                    transferJob.Logger.LogAsync(
                        logLevel: DataMovementLogLevel.Information,
                        message: $"Completed enumerating files within source directory: {transferJob.SourceLocalPath}\n",
                        false).EnsureCompleted();
                    */

                    List<Task> fileUploadTasks = new List<Task>();
                    foreach (FileSystemInfo path in pathList)
                    {
                        if (path.GetType() == typeof(FileInfo))
                        {
                            Task singleUploadTask = _taskFactory.StartNew(
                                transferJob.ProcessSingleUploadTransfer(path.FullName),
                                cancellationToken: transferJob.CancellationTokenSource.Token,
                                creationOptions: TaskCreationOptions.LongRunning,
                                scheduler: _jobTransferScheduler);
                            fileUploadTasks.Add(singleUploadTask);
                        }
                    }
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Created all upload tasks for the source directory: {transferJob.SourceLocalPath} to upload to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                    false).EnsureCompleted();
                */

                // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
                Task.WhenAll(fileUploadTasks).Wait();

                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                logLevel: DataMovementLogLevel.Information,
                message: $"Completed all upload tasks for the source directory: {transferJob.SourceLocalPath} and uploaded to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                false).EnsureCompleted();
                */
        },
        cancellationToken: transferJob.CancellationTokenSource.Token,
        creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.None would be better if the transfer is small
        scheduler: _jobTransferScheduler);
    return jobId;
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
public string ScheduleDownloadDirectory(
    BlobVirtualDirectoryClient sourceClient,
    string destinationLocalPath,
    BlobDirectoryDownloadOptions options = default)
{
    //TODO: if check the local path exists and not a directory
    // or we can go and check at the start of the job, to prevent
    // having to check the existence of the path twice.
    string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
    BlobDownloadDirectoryTransferJob transferJob = new BlobDownloadDirectoryTransferJob(jobId, sourceClient, destinationLocalPath, options);
    _totalTransferJobs.Add(jobId, transferJob);
    // Queue task to scan the remote directory for paths to download
    // As each blob is found, it is added to the queue as well.
    Task uploadDirectoryTask = _taskFactory.StartNew(
        action: () => {
        /* TODO: move this to Core.Diagnostics Logger
        transferJob.Logger.LogAsync(
            logLevel: DataMovementLogLevel.Information,
            message: $"Begin enumerating files within source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath}",
            false).EnsureCompleted();
        */
        Pageable<BlobItem> blobs = transferJob.SourceBlobDirectoryClient.GetBlobs();
        /* TODO: move this to Core.Diagnostics Logger
        transferJob.Logger.LogAsync(
            logLevel: DataMovementLogLevel.Information,
            message: $"Completed enumerating files within source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath}\n",
            false).EnsureCompleted();
        */
        List<Task> fileUploadTasks = new List<Task>();
        foreach (BlobItem blob in blobs)
        {
            Task singleDownloadTask = _taskFactory.StartNew(
                transferJob.ProcessSingleDownloadTransfer(blob.Name),
                cancellationToken: transferJob.CancellationTokenSource.Token,
                creationOptions: TaskCreationOptions.LongRunning,
                scheduler: _jobTransferScheduler);
            fileUploadTasks.Add(singleDownloadTask);
        }
        /* TODO: move this to Core.Diagnostics Logger
        transferJob.Logger.LogAsync(
            logLevel: DataMovementLogLevel.Information,
            message: $"Created all upload tasks for the source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath} to upload to the destination directory: {transferJob.DestinationLocalPath}",
            false).EnsureCompleted();
        */
        // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
        Task.WhenAll(fileUploadTasks).Wait();
        /* TODO: move this to Core.Diagnostics Logger
        transferJob.Logger.LogAsync(
            logLevel: DataMovementLogLevel.Information,
            message: $"Completed all upload tasks for the source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath} and uploaded to the destination directory: {transferJob.DestinationLocalPath}",
            false).EnsureCompleted();
        */
    },
    cancellationToken: transferJob.CancellationTokenSource.Token,
    creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.None would be better if the transfer is small
    scheduler: _jobTransferScheduler);

return jobId;
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
public string ScheduleCopy(
Uri sourceUri,
BlobClient destinationClient,
BlobCopyMethod copyMethod,
BlobCopyFromUriOptions copyOptions = default)
{
//TODO: if check the local path exists and not a directory
// or we can go and check at the start of the job, to prevent
// having to check the existence of the path twice.
string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists

BlobServiceCopyTransferJob transferJob = new BlobServiceCopyTransferJob(
    jobId,
    sourceUri,
    destinationClient,
    copyMethod,
    copyOptions);
_totalTransferJobs.Add(jobId, transferJob);
Task downloadTask = _taskFactory.StartNew(
    action: transferJob.ProcessCopyTransfer(),
    cancellationToken: transferJob.CancellationTokenSource.Token,
    creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.None would be better if the transfer is small
    scheduler: _jobTransferScheduler);

// TODO: remove stub
return jobId;
}

/// <summary>
/// Add Blob Copy Job to perform
///
/// TODO: Better description and param comments.
/// </summary>
/// <param name="sourceUri">
/// The Source directory Uri to copy blobs from.
/// The source must allow permissions to list in the container.
/// TODO: add minimum SAS permissions requirements (e.g. permissions for both contaner and blob level, rl permissions)</param>
/// <param name="destinationClient"></param>
/// <param name="copyMethod">Copy Method</param>
/// <param name="copyOptions"></param>
/// <returns>A guid of the job id</returns>
public string ScheduleCopyDirectory(
Uri sourceUri,
BlobVirtualDirectoryClient destinationClient,
BlobCopyMethod copyMethod,
BlobDirectoryCopyFromUriOptions copyOptions = default)
{
//TODO: if check the local path exists and not a directory
// or we can go and check at the start of the job, to prevent
// having to check the existence of the path twice.
string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
BlobServiceCopyDirectoryTransferJob transferJob = new BlobServiceCopyDirectoryTransferJob(jobId, sourceUri, destinationClient, copyMethod, copyOptions);
_totalTransferJobs.Add(jobId, transferJob);
// Queue task to scan the remote directory for paths to download
// As each blob is found, it is added to the queue as well.
Task copyDirectoryTask = _taskFactory.StartNew(
    action: () => {
        BlobVirtualDirectoryClient sourceVirtualDirectoryClient = new BlobVirtualDirectoryClient(transferJob.SourceDirectoryUri);
    /* TODO: move this to Core.Diagnostics Logger
    transferJob.Logger.LogAsync(
        logLevel: DataMovementLogLevel.Information,
        message: $"Begin enumerating files within source directory: {transferJob.SourceDirectoryUri.AbsoluteUri}",
        false).EnsureCompleted();
    */
    Pageable<BlobItem> blobs = sourceVirtualDirectoryClient.GetBlobs();
    /* TODO: move this to Core.Diagnostics Logger
    transferJob.Logger.LogAsync(
    logLevel: DataMovementLogLevel.Information,
    message: $"Completed enumerating files within source directory: {transferJob.SourceDirectoryUri.AbsoluteUri}\n",
    false).EnsureCompleted();
    */

List<Task> fileUploadTasks = new List<Task>();
foreach (BlobItem blob in blobs)
{
    Task singleDownloadTask = _taskFactory.StartNew(
        transferJob.ProcessSingleCopyTransfer(blob.Name),
        cancellationToken: transferJob.CancellationTokenSource.Token,
        creationOptions: TaskCreationOptions.LongRunning,
        scheduler: _jobTransferScheduler);
    fileUploadTasks.Add(singleDownloadTask);
}
    /* TODO: move this to Core.Diagnostics Logger
    transferJob.Logger.LogAsync(
        logLevel: DataMovementLogLevel.Information,
        message: $"Created all upload tasks for the source directory: {transferJob.SourceDirectoryUri.AbsoluteUri} to upload to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
        false).EnsureCompleted();
    */

    // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
    Task.WhenAll(fileUploadTasks).Wait();

    /* TODO: move this to Core.Diagnostics Logger
    transferJob.Logger.LogAsync(
        logLevel: DataMovementLogLevel.Information,
        message: $"Completed all upload tasks for the source directory: {transferJob.SourceDirectoryUri.AbsoluteUri} and uploaded to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
        false).EnsureCompleted();
    */
    },
    cancellationToken: transferJob.CancellationTokenSource.Token,
    creationOptions: TaskCreationOptions.LongRunning, //TODO: look into if setting this to TaskCreationOptions.None would be better if the transfer is small
    scheduler: _jobTransferScheduler);
    return jobId;
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
    string jobId = Guid.NewGuid().ToString(); // TODO; update the way we generate job ids, to also check if the job id already exists
    return jobId;
    }
    */

    /// <summary>
    /// Returns storage job information if provided jobId.
    /// </summary>
    /// <param name="jobId"></param>
    /// <returns></returns>
    public BlobTransferJobProperties GetJobProperties(string jobId)
        {
            if (!_totalTransferJobs.ContainsKey(jobId))
            {
                BlobTransferJobInternal job = _totalTransferJobs[jobId];
                if (job.CancellationTokenSource.IsCancellationRequested)
                {
                    throw Errors.JobCancelledOrPaused(jobId);
                }
                else
                {
                    return job.GetJobDetails();
                }
            }
            else
            {
                throw Errors.InvalidJobId(nameof(GetJobProperties), jobId);
            }
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="jobId"></param>
        public override async Task PauseTransferJobAsync(string jobId)
        {
            if (!_totalTransferJobs.ContainsKey(jobId))
            {
                BlobTransferJobInternal job = _totalTransferJobs[jobId];
                if (job.CancellationTokenSource.IsCancellationRequested)
                {
                    throw Errors.JobCancelledOrPaused(jobId);
                }
                else
                {
                    await job.PauseTransferJob().ConfigureAwait(false);
                }
            }
            else
            {
                throw Errors.InvalidJobId(nameof(PauseTransferJobAsync), jobId);
            }
        }

        /// <summary>
        /// Returns storage job information if provided jobId.
        /// </summary>
        /// <param name="jobId"></param>
        public override async Task ResumeTransferJobAsync(string jobId)
        {
            if (!_totalTransferJobs.ContainsKey(jobId))
            {
                BlobTransferJobInternal job = _totalTransferJobs[jobId];
                if (job.CancellationTokenSource.IsCancellationRequested)
                {
                    // The job is currently getting cancelled or paused
                    throw Errors.JobCancelledOrPaused(jobId);
                }
                else
                {
                    await job.ResumeTransferJob().ConfigureAwait(false);
                }
            }
            else
            {
                throw Errors.InvalidJobId(nameof(ResumeTransferJobAsync), jobId);
            }
        }

        /// <summary>
        /// Resumes transfers that are currently being processed.
        /// Does not allow any other transfer start.
        /// </summary>
        /// TODO: Returns actual object, or at least in a designated log
        /// file we have a place where people can continue transfers
        public override async Task ResumeAllTransferJobsAsync()
        {
            _managerTransferStatus = StorageManagerTransferStatus.InProgress;

            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _totalTransferJobs)
            {
                await job.Value.ResumeTransferJob().ConfigureAwait(false);
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
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task PauseAllTransferJobsAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _managerTransferStatus = StorageManagerTransferStatus.Pausing;

            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _totalTransferJobs)
            {
                if (!job.Value.CancellationTokenSource.IsCancellationRequested)
                {
                    job.Value.CancellationTokenSource.Cancel(true);
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
        public override async Task CancelAllTransferJobsAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // This would remove all transfers from the queue and not log the current progress
            // to the file. Maybe we would also remove the file too as a part of cleanup.
            _managerTransferStatus = StorageManagerTransferStatus.Cancelling;
            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _totalTransferJobs)
            {
                // Probably look to do this in parallel.
                // TODO: catch any errors that fly up the stack and attempt
                // to delete the other log or plan files, but throw the proper exception
                // or list of files that could not be deleted.
                job.Value.PlanJobWriter.RemovePlanFile();
            }
        }

        /// <summary>
        /// Removes all plan files/ DataTransferState Transfer files.
        /// Removes all logs
        /// </summary>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task CleanAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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
            foreach (KeyValuePair<string, BlobTransferJobInternal> job in _totalTransferJobs)
            {
                // Probably look to do this in parallel.
                // TODO: catch any errors that fly up the stack and attempt
                // to delete the other log or plan files, but throw the proper exception
                // or list of files that could not be deleted.

                //TODO: do we have to remove log files?
                //job.Value.Logger.removeLogFile();
                job.Value.PlanJobWriter.RemovePlanFile();
            }
        }
    }
}
