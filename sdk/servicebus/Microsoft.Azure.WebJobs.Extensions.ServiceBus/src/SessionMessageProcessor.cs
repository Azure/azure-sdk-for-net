// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Executors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    public class SessionMessageProcessor
    {
        public SessionMessageProcessor(ClientEntity clientEntity, SessionHandlerOptions sessionHandlerOptions)
        {
            ClientEntity = clientEntity ?? throw new ArgumentNullException(nameof(clientEntity));
            SessionHandlerOptions = sessionHandlerOptions ?? throw new ArgumentNullException(nameof(sessionHandlerOptions));
        }

        /// <summary>
        /// Gets the <see cref="SessionHandlerOptions"/> that will be used by the <see cref="SessionMessageProcessor"/>.
        /// </summary>
        public SessionHandlerOptions SessionHandlerOptions { get; }

        /// <summary>
        /// Gets or sets the <see cref="ClientEntity"/> that will be used by the <see cref="SessionMessageProcessor"/>.
        /// </summary>
        protected ClientEntity ClientEntity { get; set; }

        /// <summary>
        /// This method is called when there is a new message to process, before the job function is invoked.
        /// This allows any preprocessing to take place on the message before processing begins.
        /// </summary>
        /// <param name="session">The session associated with the message.</param>
        /// <param name="message">The message to process.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>A <see cref="Task"/> that returns true if the message processing should continue, false otherwise.</returns>
        public virtual Task<bool> BeginProcessingMessageAsync(IMessageSession session, Message message, CancellationToken cancellationToken)
        {
            return Task.FromResult<bool>(true);
        }

        /// <summary>
        /// This method completes processing of the specified message, after the job function has been invoked.
        /// </summary>
        /// <remarks>
        /// The message is completed by the ServiceBus SDK based on how the <see cref="SessionHandlerOptions.AutoComplete"/> option
        /// is configured. E.g. if <see cref="SessionHandlerOptions.AutoComplete"/> is false, it is up to the job function to complete
        /// the message.
        /// </remarks>
        /// <param name="session">The session associated with the message.</param>
        /// <param name="message">The message to complete processing for.</param>
        /// <param name="result">The <see cref="FunctionResult"/> from the job invocation.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use</param>
        /// <returns>A <see cref="Task"/> that will complete the message processing.</returns>
        public virtual Task CompleteProcessingMessageAsync(IMessageSession session, Message message, FunctionResult result, CancellationToken cancellationToken)
        {
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
