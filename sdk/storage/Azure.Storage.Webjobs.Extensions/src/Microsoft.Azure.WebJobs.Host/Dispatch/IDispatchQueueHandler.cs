// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Dispatch
{
    /// <summary>
    /// Queue where user can add their function triggering messages,
    /// these messages will be distributed to multiple worker instance
    /// for later processing
    /// </summary>
    internal interface IDispatchQueueHandler
    {
        /// <summary> Add a message to the shared queue.</summary>
        /// <param name="message"> A JObject to be later processed by IMessageHandler </param>
        /// <param name="cancellationToken"></param>
        Task EnqueueAsync(JObject message, CancellationToken cancellationToken);
    }
}
