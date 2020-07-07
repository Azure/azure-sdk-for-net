// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Dispatch
{
    /// <summary>
    /// Defines the contract for executing a triggered function using a dispatch queue.
    /// <see cref="ListenerFactoryContext.GetDispatchQueue(IMessageHandler)"/>
    /// </summary>
    internal interface IMessageHandler
    {
        /// <summary>
        /// Try to invoke the triggered function using the values specified.
        /// This is similar to <see cref="ITriggeredFunctionExecutor.TryExecuteAsync(TriggeredFunctionData, CancellationToken)"/>
        /// except that data is the JObject that user enqueued using
        /// <see cref="IDispatchQueueHandler.EnqueueAsync(JObject, CancellationToken)"/>
        /// </summary>
        /// <param name="data">The trigger invocation details.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A <see cref="FunctionResult"/> describing the results of the invocation.</returns>
        Task<FunctionResult> TryExecuteAsync(JObject data, CancellationToken cancellationToken);
    }
}