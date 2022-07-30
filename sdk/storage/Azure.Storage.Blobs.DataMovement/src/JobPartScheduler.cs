// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Azure;
using Microsoft.VisualStudio.Threading;
using Azure.Storage.Blobs.DataMovement.Models;
using System.Linq;
using System.Threading.Channels;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Blob Job Transfer Scheduler.
    ///
    /// Performs scanning or queues up scanning of the jobs in the queue
    /// Adds the job items to the queue
    /// </summary>
    internal class JobPartScheduler
    {
        // Indicates whether the current thread is processing work items.
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        /// <summary>
        /// Total amount of workers
        /// </summary>
        private readonly int _totalWorkerCount;

        /// <summary>
        /// To prevent an influx of tasks being created all at once, when there's not
        /// enough workers to go around. Keep a queue of jobs until we have worker(s) ready
        /// to being a job and create more tasks
        /// </summary>
        public Channel<BlobTransferJobInternal> JobsToProcess;

        /// <summary>
        /// BlobJobTransferScheduler Constructor
        /// </summary>
        /// <param name="maxTransferWorkerCount"></param>
        public JobPartScheduler(
            int? maxTransferWorkerCount = default)
        {
            // Set max number of transfer workers
            if (maxTransferWorkerCount.HasValue && maxTransferWorkerCount > 0)
            {
                _totalWorkerCount = maxTransferWorkerCount.Value;
            }
            else
            {
                _totalWorkerCount = Constants.DataMovement.InitialMainPoolSize;
            }

            _currentThreadIsProcessingItems = false;
            JobsToProcess = Channel.CreateUnbounded<BlobTransferJobInternal>(
                new UnboundedChannelOptions()
                {
                    AllowSynchronousContinuations = true,
                    SingleReader = true, // Single Reader to process one job at a time.
                });
        }

        /// <summary>
        /// Adds job to the queue
        /// </summary>
        /// <param name="job"></param>
        public async Task QueueJob(BlobTransferJobInternal job)
        {
            // Add the job to the channel of jobs to be processed. The channel
            // allows for multiple writes.
            //lock (_jobsToProcess)
            //{
                await JobsToProcess.Writer.WriteAsync(job).ConfigureAwait(false);
                if (!_currentThreadIsProcessingItems)
                {
                    NotifyThreadPoolOfPendingWork();
                }
            //}
        }

        // Inform the ThreadPool that there's work to be executed for this scheduler.
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Note that the current thread is now processing work items.
                // This is necessary to enable inlining of tasks into this thread.
                _currentThreadIsProcessingItems = true;
                try
                {
                    // Process all available items in the queue.
                    // We could endlessly wait to read, but we would rather let go of the
                    // thread if there are no more jobs to process
                    while (JobsToProcess.Reader.TryRead(out BlobTransferJobInternal item))
                    {
                        // Execute the task we pulled out of the queue
                        //base.TryExecuteTask(item);
                    }
                }
                // We're done processing items on the current thread
                finally
                {
                    _currentThreadIsProcessingItems = false;
                }
            }, null);
        }
    }
}
