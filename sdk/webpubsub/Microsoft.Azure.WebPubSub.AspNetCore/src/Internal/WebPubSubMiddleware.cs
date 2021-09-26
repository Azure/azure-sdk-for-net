// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class WebPubSubMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ServiceRequestHandlerAdapter _handler;

        public WebPubSubMiddleware(
            RequestDelegate next,
            ServiceRequestHandlerAdapter handler)
        {
            _next = next;
            _handler = handler;
        }

        public Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments(_handler.Path) ||
                !context.Request.Headers.ContainsKey(Constants.Headers.CloudEvents.WebPubSubVersion))
            {
                return _next(context);
            }

            return _handler.HandleRequest(context);
        }
    }
}
