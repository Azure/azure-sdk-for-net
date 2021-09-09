// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerEvent
    {
        /// <summary>
        /// SignalR Context that gets from HTTP request and pass the Function parameters
        /// </summary>
        public InvocationContext Context { get; set; }

        /// <summary>
        /// A TaskCompletionSource will set the return value when the function invocation is finished.
        /// </summary>
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }
    }
}