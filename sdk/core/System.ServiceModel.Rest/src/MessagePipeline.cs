// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract class MessagePipeline
    {
        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task SendAsync(RestMessage message, CancellationToken cancellationToken);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        public abstract void Send(RestMessage message, CancellationToken cancellationToken);
    }
}
