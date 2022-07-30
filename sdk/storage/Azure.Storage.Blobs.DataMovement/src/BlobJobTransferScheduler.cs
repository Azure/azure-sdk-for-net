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

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Blob Job Transfer Scheduler.
    ///
    /// Performs scanning or queues up scanning of the jobs in the queue
    /// Adds the job items to the queue
    /// </summary>
    internal class BlobJobTransferScheduler : TaskScheduler
    {
        // Indicates whether the current thread is processing work items.
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        // Indicates whether the scheduler is currently processing work items.
        private long _delegatesQueuedOrRunning;

        /// <summary>
        /// Total amount of workers
        /// </summary>
        private readonly int _totalWorkerCount;

        // TaskScheduler
        //
        // To manage something like this that will eventually exit when the queue empties
        // We might have to consider making a custom TaskScheduler to start a new one, once
        // the queue has something to process.
        //private TaskScheduler taskScheduler;

        internal ConcurrentQueue<Task> _tasksToProcess;

        /// <summary>
        /// Task Throttler to mananage thread performing list calls to the service.
        /// </summary>
        private TaskThrottler _storageServiceTaskThrottler;

        /// <summary>
        /// Task Throttler to manage the threads performing list calls.
        /// </summary>
        internal TaskThrottler StorageServiceTaskThrottler => _storageServiceTaskThrottler;

        /// <summary>
        /// BlobJobTransferScheduler Constructor
        /// </summary>
        /// <param name="maxTransferWorkerCount"></param>
        public BlobJobTransferScheduler(
            int? maxTransferWorkerCount = default)
        {
            // Set max number of transfer workers
            if (maxTransferWorkerCount.HasValue && maxTransferWorkerCount > 0)
            {
                _totalWorkerCount = maxTransferWorkerCount.Value;
            }
            else
            {
                _totalWorkerCount = Constants.Blob.Block.DefaultConcurrentTransfersCount;
            }
            _storageServiceTaskThrottler = new TaskThrottler(_totalWorkerCount);

            _delegatesQueuedOrRunning = 0;
            _currentThreadIsProcessingItems = false;

            _tasksToProcess = new ConcurrentQueue<Task>();
        }

        /// <summary>
        /// Adds job to the queue that has already been scanned.
        /// </summary>
        /// <param name="task"></param>
        protected override void QueueTask(Task task)
        {
            // Add the task to the list of tasks to be processed.  If there aren't enough
            // delegates currently queued or running to process tasks, schedule another.
            lock (_tasksToProcess)
            {
                _tasksToProcess.Enqueue(task);
                if (_delegatesQueuedOrRunning < _totalWorkerCount)
                {
                    ++_delegatesQueuedOrRunning;
                    NotifyThreadPoolOfPendingWork();
                }
            }
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
                    while (true)
                    {
                        Task item;
                        lock (_tasksToProcess)
                        {
                            // When there are no more items to be processed,
                            // note that we're done processing, and get out.
                            if (_tasksToProcess.IsEmpty)
                            {
                                --_delegatesQueuedOrRunning;
                                break;
                            }

                            // Tries to get the next item from the queue
                            _tasksToProcess.TryDequeue(out item);
                        }

                        // Execute the task we pulled out of the queue
                        base.TryExecuteTask(item);
                    }
                }
                // We're done processing items on the current thread
                finally
                {
                    _currentThreadIsProcessingItems = false;
                }
            }, null);
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasksToProcess, ref lockTaken);
                if (lockTaken)
                    return _tasksToProcess;
                else
                    throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(_tasksToProcess);
            }
        }

        // Attempts to execute the specified task on the current thread.
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If this thread isn't already processing a task, we don't support inlining
            if (!_currentThreadIsProcessingItems)
                return false;

            // If the task was previously queued, remove it from the queue
            if (taskWasPreviouslyQueued)
                // Try to run the task.
                if (TryDequeue(task))
                    return base.TryExecuteTask(task);
                else
                    return false;
            else
                return base.TryExecuteTask(task);
        }
    }
}
