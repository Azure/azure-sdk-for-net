// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Contains diagnostic information that can be used for troubleshooting purposes. To enable diagnostics,
    /// set <see cref="ServiceBusProcessorOptions.EnableDiagnostics"/> to <value>true</value> when creating your processor./>
    /// </summary>
    public class ServiceBusProcessorDiagnostics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessorDiagnostics"/> class for mocking.
        /// </summary>
        protected internal ServiceBusProcessorDiagnostics()
        {
        }

        /// <summary>
        /// The time that the processor last attempted to receive a message from the Service Bus queue or subscription.
        /// </summary>
        public DateTimeOffset? LastReceiveAttemptedTime => _lastReceiveAttemptedTime;
        private DateTimeOffset? _lastReceiveAttemptedTime;

        /// <summary>
        /// The time that the processor last successfully received a message from the Service Bus queue or subscription.
        /// </summary>
        public DateTimeOffset? LastReceiveSucceededTime => _lastReceiveSucceededTime;
        private DateTimeOffset? _lastReceiveSucceededTime;

        /// <summary>
        /// The number of messages currently being processed by the processor. This includes messages that are actively being processed in the user
        /// handler as well as messages that have just been received, or are in the process of being autocompleted or abandoned.
        /// </summary>
        public int MessagesBeingProcessed => _messagesBeingProcessed;
        private volatile int _messagesBeingProcessed;

        // centralize the updating methods to avoid duplicating logic and needing to make private fields internal
        internal void IncrementMessageCount() => Interlocked.Increment(ref _messagesBeingProcessed);

        internal void DecrementMessageCount() => Interlocked.Decrement(ref _messagesBeingProcessed);

        internal void UpdateLastReceiveSucceededTime() => _lastReceiveSucceededTime = DateTimeOffset.Now;

        internal void UpdateLastReceiveAttemptedTime() => _lastReceiveAttemptedTime = DateTimeOffset.Now;
    }
}