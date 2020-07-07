// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Factory for host queue services. 
    /// </summary>
    /// $$$ Review this new public surface area
    [Obsolete("Not ready for public consumption.")]
    public interface ILoadBalancerQueue
    {
        IAsyncCollector<T> GetQueueWriter<T>(string queueName);

        IListener CreateQueueListenr(
            string queueName,
            string poisonQueueName,
            Func<string, CancellationToken, Task<FunctionResult>> callback);
    }

    internal class InMemoryLoadBalancerQueue : ILoadBalancerQueue
    {
        public IListener CreateQueueListenr(string queue, string poisonQueue, Func<string, CancellationToken, Task<FunctionResult>> callback)
        {
            return new Listener
            {
                Parent = this,
                Queue = queue,
                Callback = callback
            };
        }

        Dictionary<string, Queue<object>> _queues = new Dictionary<string, Queue<object>>();

        private Queue<object> GetQueue(string name)
        {
            lock (_queues)
            {
                Queue<object> q;
                if (!_queues.TryGetValue(name, out q))
                {
                    q = new Queue<object>();
                    _queues[name] = q;
                }
                return q;
            }
        }

        private void Add<T>(string queue, T item)
        {
            var q = GetQueue(queue);
            lock (q)
            {
                q.Enqueue(item);
            }
        }

        public IAsyncCollector<T> GetQueueWriter<T>(string queueName)
        {
            return new Writer<T>
            {
                 _parent = this,
                  _queue = queueName
            };
        }

        class Listener : IListener
        {
            internal InMemoryLoadBalancerQueue Parent;
            internal string Queue; // queue to listen on
            internal Func<string, CancellationToken, Task<FunctionResult>> Callback;

            public void Cancel()
            {
            }

            public void Dispose()
            {
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }

        class Writer<T> : IAsyncCollector<T>
        {
            internal string _queue;
            internal InMemoryLoadBalancerQueue _parent;

            public Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
            {
                _parent.Add(_queue, item);
                return Task.CompletedTask;
            }

            public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }
        }
    }
}
