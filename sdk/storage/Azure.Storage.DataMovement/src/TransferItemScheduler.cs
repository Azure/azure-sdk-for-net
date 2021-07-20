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
        /// The maximum number of simultaneous workers. Handles the amount of items
        /// allowed to transfer at the same time.
        /// </summary>
        private readonly int _maxWorkerCount;

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
        /// <param name="maxWorkerCount">The maximum number of simultaneous workers.</param>
        public TransferItemScheduler(int? maxWorkerCount = default)
        {
            // Set _maxWorkerCount
            if (maxWorkerCount.HasValue && maxWorkerCount > 0)
            {
                _maxWorkerCount = (int) maxWorkerCount;
            }
            else
            {
                // TODO: come up with an optimal amount to set the default
                // amount of workers. For now it will be 5, which is the current
                // constant amount of block blob transfer.
                _maxWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
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
                runningTasks.Add(currentJob.StartTransferTaskAsync());

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
