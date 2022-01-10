// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Azure;
using Microsoft.VisualStudio.Threading;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Job Transfer Scheduler.
    ///
    /// Performs scanning or queues up scanning of the jobs in the queue
    /// Adds the job items to the queue
    /// </summary>
    public class BlobJobTransferScheduler
    {
        /// <summary>
        /// The maximum number of simultaneous workers for making service side list calls. Handles the amount of scanning
        /// allowed at the same time.
        /// </summary>
        private readonly int _maxListServiceRequestWorkerCount;

        /// <summary>
        /// The maximum number of simultaneous workers for making local side list calls. Handles the amount of scanning
        /// allowed at the same time.
        /// </summary>
        private readonly int _maxLocalListWorkerCount;

        // TaskScheduler
        //
        // To manage something like this that will eventually exit when the queue empties
        // We might have to consider making a custom TaskScheduler to start a new one, once
        // the queue has something to process.
        //private TaskScheduler taskScheduler;

        internal ConcurrentQueue<Task> tasksToProcess;

        /// <summary>
        /// Task Throttler to mananage thread performing list calls to the service.
        /// </summary>
        private TaskThrottler _storageServiceTaskThrottler;

        /// <summary>
        /// Task Throttler to manage the threads performing list calls.
        /// </summary>
        internal TaskThrottler StorageServiceTaskThrottler => _storageServiceTaskThrottler;

        /// <summary>
        /// Task Throttler to mananage thread performing list calls to the local filesystem
        ///
        /// TODO: look to see if there's a limit that should be on performng list calls to the filesystem
        /// </summary>
        private TaskThrottler _localTaskThrottler;

        /// <summary>
        /// Task Throttler to manage the threads performing list calls.
        /// </summary>
        internal TaskThrottler LocalTaskThrottler => _localTaskThrottler;

        /// <summary>
        /// BlobJobTransferScheduler Constructor
        /// </summary>
        /// <param name="maxListServiceRequestWorkerCount">The maximum number of simultaneous workers for making requests to the service.</param>
        /// <param name="maxLocalListWorkerCount">The maximum number of simultaneous workes for max Local List work count.</param>
        public BlobJobTransferScheduler(int? maxListServiceRequestWorkerCount = default, int? maxLocalListWorkerCount = default)
        {
            // Set _maxWorkerCount
            if (maxListServiceRequestWorkerCount.HasValue && maxListServiceRequestWorkerCount > 0)
            {
                _maxListServiceRequestWorkerCount = (int)maxListServiceRequestWorkerCount;
            }
            else
            {
                // TODO: come up with an optimal amount to set the default
                // amount of workers. For now it will be 5, which is the current
                // constant amount of block blob transfer.
                _maxListServiceRequestWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }
            _storageServiceTaskThrottler = new TaskThrottler(_maxListServiceRequestWorkerCount);

            // Set _maxWorkerCount
            if (maxLocalListWorkerCount.HasValue && maxLocalListWorkerCount > 0)
            {
                _maxLocalListWorkerCount = (int)maxLocalListWorkerCount;
            }
            else
            {
                // TODO: come up with an optimal amount to set the default
                // amount of workers. For now it will be 5, which is the current
                // constant amount of block blob transfer.
                _maxLocalListWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }
            _localTaskThrottler = new TaskThrottler(_maxLocalListWorkerCount);

            tasksToProcess = new ConcurrentQueue<Task>();
        }

        /// <summary>
        /// Adds job to the queue that has already been scanned.
        /// </summary>
        /// <param name="job"></param>
        internal void AddJob(BlobUploadTransferJob job)
        {
            // Just because this job would only be a single job, we need to queue
            // it in the case that other jobs are currently being scanned
            // that way we're not adding scans out of order

            // TODO: look into possiblity of sending requests based on different priority
            // because if the job is for a different storage account
            // it might be worth sending that requests anyways cause it wouldn't slow down traffic for that storage account per say
            tasksToProcess.Enqueue(job.StartTransferTaskAsync());
        }

        /// <summary>
        /// Adds job to the queue that has already been scanned.
        /// </summary>
        /// <param name="job"></param>
        internal void AddJob(BlobDownloadTransferJob job)
        {
            // Just because this job would only be a single job, we need to queue
            // it in the case that other jobs are currently being scanned
            // that way we're not adding scans out of order

            // TODO: look into possiblity of sending requests based on different priority
            // because if the job is for a different storage account
            // it might be worth sending that requests anyways cause it wouldn't slow down traffic for that storage account per say
            tasksToProcess.Enqueue(job.StartTransferTaskAsync());
        }

        /// <summary>
        /// Adds job to the queue that has already been scanned.
        /// </summary>
        /// <param name="job"></param>
        internal void AddJob(BlobUploadDirectoryTransferJob job)
        {
            // TODO: set error scanning here from the StorageTransferConfigurations
            PathScannerFactory scannerFactory = new PathScannerFactory(job.SourceLocalPath);
            PathScanner scanner = scannerFactory.BuildPathScanner();
            StorageServiceTaskThrottler.AddTask(async () =>
            {
                //await Task.FromResult<IEnumerable<FileSystemInfo>>(scanner.Scan()).ConfigureAwait(false);
                await Task.Run(() => ScanLocalDirectory(job, scanner)).ConfigureAwait(false);
            });
            StorageServiceTaskThrottler.Wait();
        }

        private void ScanLocalDirectory(BlobUploadDirectoryTransferJob job, PathScanner scanner)
        {
            IEnumerable<FileSystemInfo> pathList = scanner.Scan();

            foreach (FileSystemInfo path in pathList)
            {
                if (path.GetType() == typeof(FileInfo))
                {
                    tasksToProcess.Enqueue(job.GetSingleUploadTaskAsync(path.FullName));
                }
            }
        }

        /// <summary>
        /// Adds job to the queue that has already been scanned.
        /// </summary>
        /// <param name="job"></param>
        internal void AddJob(BlobDownloadDirectoryTransferJob job)
        {
            // TODO: Need to replace this with the async method so that we can enumerate based on the continuation token
            // in the case that the customer decides to pause the job, and wants to resume later we have the continuation token
            // or we're getting throttled and we should take a break and continue later.

            Pageable<BlobItem> blobs = job.SourceBlobClient.GetBlobs(cancellationToken: job.CancellationToken);

            foreach (BlobItem blob in blobs)
            {
                tasksToProcess.Enqueue(job.GetSingleDownloadTaskAsync(blob.Name));
            }
        }

        /// <summary>
        /// Runs jobs on the multiple threads given.
        ///
        /// This will be called once there's one job on the queue, if there are no items in the queue then we exit.
        /// </summary>
        private async Task RunJobsAsync()
        {
            // Create a list of tasks that will each run each Transfer Item
            // of a Job.  The queue maintains the order of the Tasks
            // so we can keep appending to the end of the destination
            // stream when each segment finishes.
            var runningTasks = new List<Task>();
            while (!tasksToProcess.IsEmpty)
            {
                Task currentTask;
                if (tasksToProcess.TryDequeue(out currentTask))
                {
                    // Create Task from given job type
                    // TODO: remove this and call the according job type to create the task
                    // Add Task
                    runningTasks.Add(currentTask);

                    // If we run out of workers
                    if (runningTasks.Count >= _maxListServiceRequestWorkerCount)
                    {
                        // Wait for at least one of them to finish
                        await Task.WhenAny(runningTasks).ConfigureAwait(false);

                        // Clear any completed blocks from the task list
                        for (int i = 0; i < runningTasks.Count; i++)
                        {
                            Task runningTask = runningTasks[i];
                            if (!runningTask.IsCompleted)
                            {
                                continue;
                            }

                            await runningTask.ConfigureAwait(false);
                            runningTasks.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            // Wait for all the remaining blocks to finish staging and then
            // commit the block list to complete the upload
            await Task.WhenAll(runningTasks).ConfigureAwait(false);
        }
    }
}
