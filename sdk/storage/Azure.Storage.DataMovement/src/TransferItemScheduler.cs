// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;

namespace Azure.Storage.DataMovement
{
    internal class TransferItemScheduler
    {
        /// <summary>
        /// The maximum number of simultaneous workers.
        /// </summary>
        private readonly int _maxWorkerCount;

        /// <summary>
        /// The size of the first range requested (which can be larger than the
        /// other ranges).
        /// </summary>
        private readonly long _initialDownloadRangeSize;

        /// <summary>
        /// The size of subsequent ranges.
        /// </summary>
        private readonly long _rangeSize;

        /// <summary>
        /// The size we use to determine whether to upload as a one-off request or
        /// a partitioned/committed upload
        /// </summary>
        private readonly long _singleUploadThreshold;

        // TaskScheduler
        //
        // To manage something like this that will eventually exit when the queue empties
        // We might have to consider making a custom TaskScheduler to start a new one, once
        // the queue has something to process.
        //private TaskScheduler taskScheduler;

        /// <summary>
        /// The queue we hold onto as the finished scanned items are added. This is the
        /// waiting list of items ready to execute (upload, download, copy)
        /// </summary>
        public AsyncQueue<StorageTransferJob> itemsToProcess;

        /// <summary>
        /// TransferItemScheduler Constructor
        /// </summary>
        /// <param name="transferOptions"></param>
        public TransferItemScheduler(StorageTransferOptions transferOptions = default)
        {
            // Set _maxWorkerCount
            if (transferOptions.MaximumConcurrency.HasValue
                && transferOptions.MaximumConcurrency > 0)
            {
                _maxWorkerCount = transferOptions.MaximumConcurrency.Value;
            }
            else
            {
                _maxWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }

            // Set _rangeSize
            if (transferOptions.MaximumTransferSize.HasValue
                && transferOptions.MaximumTransferSize.Value > 0)
            {
                _rangeSize = Math.Min(transferOptions.MaximumTransferSize.Value, Constants.Blob.Block.MaxDownloadBytes);
            }
            else
            {
                _rangeSize = Constants.DefaultBufferSize;
            }

            // Set _initialRangeSize
            if (transferOptions.InitialTransferSize.HasValue
                && transferOptions.InitialTransferSize.Value > 0)
            {
                _initialDownloadRangeSize = transferOptions.InitialTransferSize.Value;
            }
            else
            {
                _initialDownloadRangeSize = Constants.Blob.Block.DefaultInitalDownloadRangeSize;
            }

            // Set _singleUploadThreshold
            if (transferOptions.InitialTransferSize.HasValue
                && transferOptions.InitialTransferSize.Value > 0)
            {
                _singleUploadThreshold = Math.Min(transferOptions.InitialTransferSize.Value, Constants.Blob.Block.MaxUploadBytes);
            }
            else
            {
                _singleUploadThreshold = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes;
            }
        }

        /// <summary>
        /// Adds job to the queue that has already been scanned.
        /// </summary>
        /// <param name="job"></param>
        public void AddJob(StorageTransferJob job)
        {
            itemsToProcess.Enqueue(job);
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
            while (!itemsToProcess.IsEmpty)
            {
                StorageTransferJob currentJob = await itemsToProcess.DequeueAsync().ConfigureAwait(false);

                // Create Task from given job type
                // TODO: remove this and call the according job type to create the task
                // Add Task
                runningTasks.Add(currentJob.CreateTransferTaskAsync());

                // If we run out of workers
                if (runningTasks.Count >= _maxWorkerCount)
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

            // Wait for all the remaining blocks to finish staging and then
            // commit the block list to complete the upload
            await Task.WhenAll(runningTasks).ConfigureAwait(false);
        }
    }
}
