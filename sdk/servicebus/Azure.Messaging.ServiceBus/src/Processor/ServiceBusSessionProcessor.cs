// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceBusSessionProcessor : ServiceBusProcessor
    {
        internal ServiceBusSessionProcessor(
            ServiceBusConnection connection,
            string entityPath,
            ServiceBusProcessorOptions options,
            string sessionId = default) :
            base(
                connection,
                entityPath,
                true,
                options,
                sessionId)
        {
        }

        /// <summary>
        /// The event responsible for processing messages received from the Queue or Subscription. Implementation
        /// is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public new event Func<ProcessSessionMessageEventArgs, Task> ProcessMessageAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processSessionMessage != default)
                {
                    throw new NotSupportedException(Resources1.HandlerHasAlreadyBeenAssigned);
                }
                EnsureNotRunningAndInvoke(() => _processSessionMessage = value);

            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processSessionMessage != value)
                {
                    throw new ArgumentException(Resources1.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processSessionMessage = default);
            }
        }

        internal Func<ProcessSessionMessageEventArgs, Task> _processSessionMessage;

    }
}
