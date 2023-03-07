// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class ServiceRequestHandlerAdapter
    {
        private readonly RequestValidator _requestValidator;
        private readonly IServiceProvider _provider;
        private readonly ILogger _logger;

        // <hubName, HubImpl>
        private readonly Dictionary<string, WebPubSubHub> _hubRegistry = new(StringComparer.OrdinalIgnoreCase);

        public ServiceRequestHandlerAdapter(IServiceProvider provider, RequestValidator requestValidator, ILogger<ServiceRequestHandlerAdapter> logger)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _requestValidator = requestValidator ?? throw new ArgumentNullException(nameof(requestValidator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void RegisterHub<THub>() where THub : WebPubSubHub
        {
            var hub = Create<THub>();
            _hubRegistry[hub.GetType().Name] = hub;
        }

        public WebPubSubHub GetHub(string hubName)
        {
            if (_hubRegistry.TryGetValue(hubName, out var hub))
            {
                return hub;
            }
            return null;
        }

        public async Task HandleRequest(HttpContext context)
        {
            HttpRequest request = context.Request;

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Should check in middleware to skip not match calls.
            // And keep here for internal reference lib robustness and return as 400BadRequest.
            #region WebPubSubRequest Check
            // Not Web PubSub request.
            if (!context.Request.Headers.ContainsKey(Constants.Headers.CloudEvents.WebPubSubVersion)
                || !context.Request.Headers.TryGetValue(Constants.Headers.CloudEvents.Hub, out var hubName))
            {
                throw new ArgumentException("Invalid Web PubSub request.");
            }

            // Hub not registered
            var hub = GetHub(hubName);
            if (hub == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Hub is not registered.").ConfigureAwait(false);
                return;
            }
            #endregion

            try
            {
                var serviceRequest = await request.ReadWebPubSubEventAsync(_requestValidator, context.RequestAborted).ConfigureAwait(false);
                Log.StartToHandleRequest(_logger, serviceRequest.ConnectionContext);

                switch (serviceRequest)
                {
                    // should not hit.
                    case PreflightRequest preflightRequest:
                        {
                            if (preflightRequest.IsValid)
                            {
                                context.Response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
                                break;
                            }
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Abuse Protection validation failed.").ConfigureAwait(false);
                            break;
                        }
                    case ConnectEventRequest connectEventRequest:
                        {
                            var response = await hub.OnConnectAsync(connectEventRequest, context.RequestAborted).ConfigureAwait(false);
                            // default as null is allowed.
                            if (response != null)
                            {
                                SetConnectionState(ref context, connectEventRequest.ConnectionContext, response.ConnectionStates);
                                await context.Response.WriteAsync(JsonSerializer.Serialize(response)).ConfigureAwait(false);
                            }
                            break;
                        }
                    case UserEventRequest messageRequest:
                        {
                            var response = await hub.OnMessageReceivedAsync(messageRequest, context.RequestAborted).ConfigureAwait(false);
                            // default as null is allowed.
                            if (response != null)
                            {
                                SetConnectionState(ref context, messageRequest.ConnectionContext, response.ConnectionStates);
                            }
                            if (response.Data != null)
                            {
                                context.Response.ContentType = ConvertToContentType(response.DataType);
                                var payload = response.Data.ToArray();
                                await context.Response.Body.WriteAsync(payload).ConfigureAwait(false);
                            }
                            break;
                        }
                    case ConnectedEventRequest connectedEvent:
                        {
                            _ = hub.OnConnectedAsync(connectedEvent).ConfigureAwait(false);
                            break;
                        }
                    case DisconnectedEventRequest disconnectedEvent:
                        {
                            _ = hub.OnDisconnectedAsync(disconnectedEvent).ConfigureAwait(false);
                            break;
                        }
                    default:
                        break;
                }
                Log.SucceededToHandleRequest(_logger, serviceRequest.ConnectionContext);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.FailedToHandleRequest(_logger, ex.Message, ex);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(ex.Message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.FailedToHandleRequest(_logger, ex.Message, ex);
                // logging to service.
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.Message).ConfigureAwait(false);
            }
        }

        private static void SetConnectionState(ref HttpContext context, WebPubSubConnectionContext connectionContext, IReadOnlyDictionary<string, BinaryData> newStates)
        {
            var updatedStates = connectionContext.UpdateStates(newStates);
            if (updatedStates != null)
            {
                context.Response.Headers.Add(Constants.Headers.CloudEvents.State, updatedStates.EncodeConnectionStates());
            }
        }

        private static string ConvertToContentType(WebPubSubDataType dataType) =>
            dataType switch
            {
                WebPubSubDataType.Text => $"{Constants.ContentTypes.PlainTextContentType}; {Constants.ContentTypes.CharsetUTF8}",
                WebPubSubDataType.Json => $"{Constants.ContentTypes.JsonContentType}; {Constants.ContentTypes.CharsetUTF8}",
                _ => Constants.ContentTypes.BinaryContentType
            };

        private THub Create<THub>() where THub : WebPubSubHub
        {
            var hub = _provider.GetService<THub>() ?? ActivatorUtilities.CreateInstance<THub>(_provider);

            if (_hubRegistry.TryGetValue(nameof(hub), out _))
            {
                Debug.Assert(true, $"{typeof(THub)} must not be reused.");
            }
            return hub;
        }

        private static class Log
        {
            private static readonly Action<ILogger, string, string, string, Exception> _startToHandleRequest =
                LoggerMessage.Define<string, string, string>(LogLevel.Debug, new EventId(1, "StartToHandleRequest"), "Start to handle request, connectionId: {connectionId}, eventType: {eventType}, eventName: {eventName}");

            private static readonly Action<ILogger, string, string, string, Exception> _succeededToHandleRequest =
                LoggerMessage.Define<string, string, string>(LogLevel.Debug, new EventId(2, "SucceededToHandleRequest"), "Succeeded to handle request, connectionId: {connectionId}, eventType: {eventType}, eventName: {eventName}");

            private static readonly Action<ILogger, string, Exception> _failedToHandleRequest =
                LoggerMessage.Define<string>(LogLevel.Warning, new EventId(3, "FailedToHandleRequest"), "Handle request failed. {error}");

            public static void StartToHandleRequest(ILogger logger, WebPubSubConnectionContext context)
            {
                _startToHandleRequest(logger, context?.ConnectionId, context?.EventType.ToString(), context?.EventName, null);
            }

            public static void SucceededToHandleRequest(ILogger logger, WebPubSubConnectionContext context)
            {
                _succeededToHandleRequest(logger, context?.ConnectionId, context?.EventType.ToString(), context?.EventName, null);
            }

            public static void FailedToHandleRequest(ILogger logger, string error, Exception exception)
            {
                _failedToHandleRequest(logger, error, exception);
            }
        }
    }
}
