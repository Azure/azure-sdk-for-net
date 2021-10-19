// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class WebPubSubMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ServiceRequestHandlerAdapter _handler;
        private readonly WebPubSubOptions _options;

        public WebPubSubMiddleware(
            RequestDelegate next,
            WebPubSubOptions options,
            ServiceRequestHandlerAdapter handler)
        {
            _next = next;
            _handler = handler;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Not Web PubSub requests.
            if (!context.Request.Headers.ContainsKey(Constants.Headers.CloudEvents.WebPubSubVersion))
            {
                await _next(context);
                return;
            }

            // Handle Abuse Protection
            if (context.Request.IsValidationRequest(out var requestHosts))
            {
                var isValid = false;
                if (_options == null || !_options.ValidationOptions.ContainsHost())
                {
                    isValid = true;
                }
                else
                {
                    foreach (var item in requestHosts)
                    {
                        if (_options.ValidationOptions.ContainsHost(item))
                        {
                            isValid = true;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    context.Response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }

                return;
            }

            // Not upstream business request.
            if ((!context.Request.Headers.TryGetValue(Constants.Headers.CloudEvents.Hub, out var hub) || _handler.GetHub(hub) == null))
            {
                await _next(context);
                return;
            }

            await _handler.HandleRequest(context);
        }
    }
}