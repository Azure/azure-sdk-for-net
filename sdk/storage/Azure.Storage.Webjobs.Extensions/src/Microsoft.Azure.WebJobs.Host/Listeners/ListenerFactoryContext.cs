// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    /// <summary>
    /// Context object used passed to <see cref="ITriggerBinding.CreateListenerAsync"/>.
    /// </summary>
    public class ListenerFactoryContext
    {
        private readonly SharedQueueHandler _sharedQueue;
        private IDispatchQueueHandler _dispatchQueue;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="descriptor">The <see cref="FunctionDescriptor"/> to create a listener for.</param>
        /// <param name="executor">The <see cref="ITriggeredFunctionExecutor"/> that should be used to invoke the
        /// target job function when the trigger fires.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        public ListenerFactoryContext(FunctionDescriptor descriptor, ITriggeredFunctionExecutor executor, CancellationToken cancellationToken)
        {
            if (descriptor == null)
            {
                throw new ArgumentNullException("descriptor");
            }

            Descriptor = descriptor;
            Executor = executor;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="descriptor">The <see cref="FunctionDescriptor"/> to create a listener for.</param>
        /// <param name="executor">The <see cref="ITriggeredFunctionExecutor"/> that should be used to invoke the
        /// target job function when the trigger fires.</param>
        /// <param name="sharedQueue">The shared queue.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        internal ListenerFactoryContext(FunctionDescriptor descriptor, ITriggeredFunctionExecutor executor, SharedQueueHandler sharedQueue, CancellationToken cancellationToken)
            : this(descriptor, executor, cancellationToken)
        {
            _sharedQueue = sharedQueue;
        }

        /// <summary>
        /// Gets the <see cref="FunctionDescriptor"/> to create a listener for.
        /// </summary>
        public FunctionDescriptor Descriptor { get; private set; }

        /// <summary>
        /// Gets the <see cref="ITriggeredFunctionExecutor"/> that should be used to invoke the
        /// target job function when the trigger fires.
        /// </summary>
        public ITriggeredFunctionExecutor Executor { get; private set; }

        /// <summary>
        /// Gets the <see cref="CancellationToken"/> to use.
        /// </summary>
        public CancellationToken CancellationToken { get; private set; }

        /// <summary>
        /// Return a queue that user can add function triggering messages,
        /// These messages will later be dequeued and processed by the registered handler
        /// </summary>
        /// <param name="handler">
        /// Call back function that handles messages in queue, an implementation of 
        /// <see cref="IMessageHandler.TryExecuteAsync(Newtonsoft.Json.Linq.JObject, System.Threading.CancellationToken)"/>
        /// If you have registered once, you can retrieve the same queue by passing a null to this function
        /// </param>
        /// <returns> The <see cref="IDispatchQueueHandler"/> is used to enqueue messages </returns>
        internal IDispatchQueueHandler GetDispatchQueue(IMessageHandler handler)
        {
            if (_dispatchQueue == null)
            {
                if (handler == null)
                {
                    throw new InvalidOperationException("Please provide a call back function");
                }

                if (_sharedQueue.RegisterHandler(Descriptor.Id, handler))
                {
                    _dispatchQueue = new DispatchQueueHandler(_sharedQueue, Descriptor.Id);
                }
                else
                {
                    // failed to register messageHandler, fall back to in memory implementation
                    _dispatchQueue = new InMemoryDispatchQueueHandler(handler);
                }
            }
            else if (handler != null)
            {
                throw new InvalidOperationException("Cannot register more than one handler with a single function");
            }

            return _dispatchQueue;
        }
    }
}
