// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Contains diagnostic information that can be used for troubleshooting purposes. To enable diagnostics,
    /// set <see cref="ServiceBusSessionProcessorOptions.EnableDiagnostics"/> to <value>true</value> when creating your processor./>
    /// </summary>
    public class ServiceBusSessionProcessorDiagnostics
    {
        private readonly ServiceBusProcessorDiagnostics _diagnostics;

        /// <inheritdoc cref="ServiceBusProcessorDiagnostics.LastReceiveAttemptedTime"/>
        public DateTimeOffset? LastReceiveAttemptedTime => _diagnostics.LastReceiveAttemptedTime;

        /// <inheritdoc cref="ServiceBusProcessorDiagnostics.LastReceiveSucceededTime"/>
        public DateTimeOffset? LastReceiveSucceededTime => _diagnostics.LastReceiveSucceededTime;

        /// <inheritdoc cref="ServiceBusProcessorDiagnostics.MessagesBeingProcessed"/>
        public int MessagesBeingProcessed => _diagnostics.MessagesBeingProcessed;

        internal ServiceBusSessionProcessorDiagnostics(ServiceBusProcessorDiagnostics diagnostics)
        {
            _diagnostics = diagnostics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionProcessorDiagnostics"/> class for mocking.
        /// </summary>
        protected ServiceBusSessionProcessorDiagnostics()
        {
        }
    }
}