// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>This class is attached to each function that calls into our authentication event trigger.</summary>
    internal class AuthenticationEventListener : IListener
    {
        /// <summary>Gets or sets the function executor.</summary>
        /// <value>The function executor that would execute the attached function.</value>
        /// <seealso cref="ITriggeredFunctionExecutor" />
        internal ITriggeredFunctionExecutor FunctionExecutor { get; private set; }

        /// <summary>Gets or sets the attribute.</summary>
        /// <value>The event trigger attribute assigned to the function that the listener is attached to.</value>
        internal WebJobsAuthenticationEventsTriggerAttribute Attribute { get; set; }

        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventListener" /> class.</summary>
        /// <param name="executor">The executor.</param>
        /// <param name="attribute">The attribute to assign to the listener.</param>
        internal AuthenticationEventListener(ITriggeredFunctionExecutor executor, WebJobsAuthenticationEventsTriggerAttribute attribute)
        {
            FunctionExecutor = executor;
            Attribute = attribute;
        }

        /// <summary>Cancels this instance.</summary>
        public void Cancel()
        { }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>Starts the asynchronous listener, we do not do anything here as all we need is the reference to the executor.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task flagged as completed with the value as true.</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>Stops the asynchronous listener, we do not do anything here as all we need is the reference to the executor.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task flagged as completed with the value true.</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
