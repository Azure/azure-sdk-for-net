// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Executors;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    public class SessionMessageProcessor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SessionMessageProcessor"/>.
        /// </summary>
        /// <param name="processor">The <see cref="ServiceBusSessionProcessor"/> to use for processing messages from Service Bus.</param>
        protected internal SessionMessageProcessor(ServiceBusSessionProcessor processor)
        {
            Processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        /// <summary>
        /// Gets the <see cref="ServiceBusSessionProcessor"/> that will be used by the <see cref="SessionMessageProcessor"/>.
        /// </summary>
        protected internal ServiceBusSessionProcessor Processor { get; }

        /// <summary>
        /// This method is called when there is a new message to process, before the job function is invoked.
        /// This allows any preprocessing to take place on the message before processing begins.
        /// </summary>
        /// <param name="actions">The set of actions that can be performed on a <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to process.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A <see cref="Task"/> that returns true if the message processing should continue, false otherwise.</returns>
        protected internal virtual Task<bool> BeginProcessingMessageAsync(ServiceBusSessionMessageActions actions, ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
            return Task.FromResult<bool>(true);
        }

        /// <summary>
        /// This method completes processing of the specified message, after the job function has been invoked.
        /// </summary>
        /// <remarks>
        /// The message is completed by the ServiceBus SDK based on how the <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages"/> option
        /// is configured. E.g. if <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages"/> is false, it is up to the job function to complete
        /// the message.
        /// </remarks>
        /// <param name="actions">The set of actions that can be performed on a <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to process.</param>
        /// <param name="result">The <see cref="FunctionResult"/> from the job invocation.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use</param>
        /// <returns>A <see cref="Task"/> that will complete the message processing.</returns>
        protected internal virtual Task CompleteProcessingMessageAsync(ServiceBusSessionMessageActions actions, ServiceBusReceivedMessage message, FunctionResult result, CancellationToken cancellationToken)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (!result.Succeeded)
            {
                // if the invocation failed, we must propagate the
                // exception back to SB so it can handle message state
                // correctly
                throw result.Exception;
            }

            return Task.CompletedTask;
        }
    }
}
