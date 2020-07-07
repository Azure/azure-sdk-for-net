// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Dispatch
{
    /// <summary>
    /// Wrapper around <see cref="SharedQueueHandler"/>
    /// </summary>
    /// <remarks>
    /// The main purpose of this class is to encapsulate the function ID
    /// so that when the user enqueues an invocation they only need to
    /// worry about the message content.
    /// </remarks>
    internal class DispatchQueueHandler : IDispatchQueueHandler
    {
        private readonly SharedQueueHandler _sharedQueue;
        private readonly string _functionId;

        internal DispatchQueueHandler(SharedQueueHandler sharedQueue, string functionId)
        {
            _sharedQueue = sharedQueue;
            _functionId = functionId;
        }

        public Task EnqueueAsync(JObject message, CancellationToken cancellationToken)
        {
            return _sharedQueue.EnqueueAsync(message, _functionId, cancellationToken);
        }
    }
}
