// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Contains information about the entity whose processing threw an exception,
    /// as well as the exception that has been thrown.
    /// </summary>
    public sealed class ProcessErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessErrorEventArgs" /> class.
        /// </summary>
        ///
        /// <param name="exception">The exception that triggered the call to the error event handler.</param>
        /// <param name="errorSource">The source associated with the error.</param>
        /// <param name="fullyQualifiedNamespace">The endpoint used when this exception occurred.</param>
        /// <param name="entityPath">The entity path used when this exception occurred.</param>
        /// <param name="cancellationToken">The processor's <see cref="System.Threading.CancellationToken"/> instance which will be cancelled
        /// in the event that <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.</param>
        public ProcessErrorEventArgs(
            Exception exception,
            ServiceBusErrorSource errorSource,
            string fullyQualifiedNamespace,
            string entityPath,
            CancellationToken cancellationToken)
        {
            Exception = exception;
            ErrorSource = errorSource;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EntityPath = entityPath;
            CancellationToken = cancellationToken;
        }

        /// <summary>Gets the exception that triggered the call to the error event handler.</summary>
        public Exception Exception { get; }

        /// <summary>Gets the source associated with the error.</summary>
        ///
        /// <value>The source associated with the error.</value>
        public ServiceBusErrorSource ErrorSource { get; }

        /// <summary>Gets the namespace name associated with the error event.
        /// This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</summary>
        public string FullyQualifiedNamespace { get; }

        /// <summary>Gets the entity path associated with the error event.</summary>
        public string EntityPath { get; }

        /// <summary>
        /// Gets the processor's <see cref="System.Threading.CancellationToken"/> instance which will be
        /// cancelled when <see cref="ServiceBusProcessor.StopProcessingAsync"/> is called.
        /// </summary>
        public CancellationToken CancellationToken { get; }
    }
}
