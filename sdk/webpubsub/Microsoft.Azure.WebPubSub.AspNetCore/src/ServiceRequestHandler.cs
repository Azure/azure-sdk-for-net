// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Service request handler.
    /// </summary>
    public abstract class ServiceRequestHandler
    {
        /// <summary>
        /// Handle request with methods defined by ServiceHub.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="hub"></param>
        /// <returns></returns>
        public abstract Task HandleRequest<THub>(HttpContext context, THub hub) where THub : ServiceHub;
    }
}
