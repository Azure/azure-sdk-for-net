// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    internal class TaskThrottler
    {
        private int _maxConcurrency;

        private int _activeThreadCount;

        private Queue<Func<Task>> _taskQueue = new Queue<Func<Task>>();

        internal TaskThrottler(int maxConcurrency)
        {
            _maxConcurrency = maxConcurrency;
        }

        public void AddTask(Func<Task> task)
        {
            lock (_taskQueue)
            {
                _taskQueue.Enqueue(task);
                if (_activeThreadCount < _maxConcurrency)
                {
                    ++_activeThreadCount;
                    ProcessTasks();
                }
            }
        }

        public void ProcessTasks()
        {
            ThreadPool.QueueUserWorkItem(async _ =>
            {
                try
                {
                    while (_taskQueue.Count > 0)
                    {
                        Func<Task> task;
                        lock (_taskQueue)
                        {
                            task = _taskQueue.Dequeue();
                        }
                        await Task.Run(task).ConfigureAwait(false);
                    }
                }
                // We're done processing items on the current thread
                finally
                {
                    --_activeThreadCount;
                }
            }, null);
        }

        public void Wait()
        {
            SpinWait.SpinUntil(() => _taskQueue.Count == 0 && _activeThreadCount == 0);
        }

        public async Task WaitAsync()
        {
            await Task.Run(() =>
            {
                Wait();
            }).ConfigureAwait(false);
        }
    }
}
