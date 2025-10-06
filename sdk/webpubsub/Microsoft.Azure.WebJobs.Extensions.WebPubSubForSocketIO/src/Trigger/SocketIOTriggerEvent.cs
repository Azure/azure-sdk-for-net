// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class SocketIOTriggerEvent
    {
        /// <summary>
        /// Socket request context from cloud event headers.
        /// </summary>
        public SocketIOSocketContext ConnectionContext { get; set; }

        public SocketIOEventHandlerRequest Request { get; set; }

        /// <summary>
        /// A TaskCompletionSource will set result when the function invocation has finished.
        /// </summary>
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }
    }
}
