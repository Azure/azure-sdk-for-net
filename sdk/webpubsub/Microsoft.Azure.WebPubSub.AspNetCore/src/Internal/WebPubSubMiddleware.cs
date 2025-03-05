// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class WebPubSubMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ServiceRequestHandlerAdapter _handler;
        private readonly RequestValidator _requestValidator;
        private readonly ILogger _logger;

        public WebPubSubMiddleware(
            RequestDelegate next,
            ServiceRequestHandlerAdapter handler,
            RequestValidator requestValidator,
            ILogger<WebPubSubMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _requestValidator = requestValidator ?? throw new ArgumentNullException(nameof(requestValidator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Not Web PubSub requests.
            if (!context.Request.Headers.ContainsKey(Constants.Headers.CloudEvents.WebPubSubVersion))
            {
                await _next(context).ConfigureAwait(false);
                return;
            }

            // Handle Abuse Protection
            if (context.Request.IsPreflightRequest(out var requestOrigins))
            {
                Log.ReceivedAbuseProtectionRequest(_logger);
                if (_requestValidator.IsValidOrigin(requestOrigins))
                {
                    context.Response.Headers.Append(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }

                return;
            }

            // Not upstream business request.
            if (!context.Request.Headers.TryGetValue(Constants.Headers.CloudEvents.Hub, out var hubName))
            {
                await _next(context).ConfigureAwait(false);
                return;
            }
            else
            {
                // From web pubsub, but hub not register in server.
                var hub = _handler.GetHub(hubName);
                if (hub == null)
                {
                    Log.HubNotRegistered(_logger, hubName);
                    await _next(context).ConfigureAwait(false);
                    return;
                }
            }

            await _handler.HandleRequest(context).ConfigureAwait(false);
        }

        private static class Log
        {
            private static readonly Action<ILogger, Exception> _receivedAbuseProtectionRequest =
                LoggerMessage.Define(LogLevel.Debug, new EventId(1, "ReceivedAbuseProtectionRequest"), "Received abuse protection request.");

            private static readonly Action<ILogger, string, Exception> _hubNotRegistered =
                LoggerMessage.Define<string>(LogLevel.Information, new EventId(2, "HubNotRegistered"), "Received web pubsub request while target hub not registered. {hub}");

            public static void ReceivedAbuseProtectionRequest(ILogger logger)
            {
                _receivedAbuseProtectionRequest(logger, null);
            }

            public static void HubNotRegistered(ILogger logger, string hub)
            {
                _hubNotRegistered(logger, hub, null);
            }
        }
    }
}