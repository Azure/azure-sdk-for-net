// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// This class defines a strategy used for processing Service Bus messages.
    /// </summary>
    public class MessageProcessor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MessageProcessor"/>.
        /// </summary>
        /// <param name="processor">The <see cref="ServiceBusProcessor"/> to use.</param>
        public MessageProcessor(ServiceBusProcessor processor)
        {
            Processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        /// <summary>
        /// Gets or sets the <see cref="ServiceBusProcessor"/> that will be used by the <see cref="Processor"/>.
        /// </summary>
        internal ServiceBusProcessor Processor { get; set; }

        /// <summary>
        /// This method is called when there is a new message to process, before the job function is invoked.
        /// This allows any preprocessing to take place on the message before processing begins.
        /// </summary>
        /// <param name="messageActions">The set of actions that can be performed on a <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to process.</param>
        /// <param name="cancellationToken">A cancellation token that will be cancelled when the processor is shutting down.</param>
        /// <returns>A <see cref="Task"/> that returns true if the message processing should continue, false otherwise.</returns>
        public virtual Task<bool> BeginProcessingMessageAsync(ServiceBusMessageActions messageActions, ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
            return Task.FromResult<bool>(true);
        }

        /// <summary>
        /// This method completes processing of the specified message, after the job function has been invoked.
        /// </summary>
        /// <remarks>
        /// The message is completed by the ServiceBus SDK based on how the <see cref="ServiceBusProcessorOptions.AutoCompleteMessages"/> option
        /// is configured. E.g. if <see cref="ServiceBusProcessorOptions.AutoCompleteMessages"/> is false, it is up to the job function to complete
        /// the message.
        /// </remarks>
        /// <param name="messageActions">The set of actions that can be performed on a <see cref="ServiceBusReceivedMessage"/>.</param>
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to process.</param>
        /// <param name="result">The <see cref="FunctionResult"/> from the job invocation.</param>
        /// <param name="cancellationToken">A cancellation token that will be cancelled when the processor is shutting down.</param>
        /// <returns>A <see cref="Task"/> that will complete the message processing.</returns>
        public virtual Task CompleteProcessingMessageAsync(ServiceBusMessageActions messageActions, ServiceBusReceivedMessage message, FunctionResult result, CancellationToken cancellationToken)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            cancellationToken.ThrowIfCancellationRequested();

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
