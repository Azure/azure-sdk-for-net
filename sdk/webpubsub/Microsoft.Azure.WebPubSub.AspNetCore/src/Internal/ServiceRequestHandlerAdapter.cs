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
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal class ServiceRequestHandlerAdapter
    {
        private readonly WebPubSubOptions _options;
        private readonly IServiceProvider _provider;

        // <hubName, HubImpl>
        private readonly Dictionary<string, WebPubSubHub> _hubRegistry = new(StringComparer.OrdinalIgnoreCase);

        public ServiceRequestHandlerAdapter(IServiceProvider provider, IOptions<WebPubSubOptions> options)
        {
            _provider = provider;
            _options = options.Value;
        }

        // for tests.
        internal ServiceRequestHandlerAdapter(WebPubSubOptions options, WebPubSubHub hub)
        {
            _options = options;
            _hubRegistry.Add(hub.GetType().Name, hub);
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
                var serviceRequest = await request.ReadWebPubSubEventAsync(_options.ValidationOptions, context.RequestAborted);

                switch (serviceRequest)
                {
                    // should not hit.
                    case PreflightRequest preflightRequest:
                        {
                            if (preflightRequest.IsValid)
                            {
                                context.Response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
                                return;
                            }
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Abuse Protection validation failed.").ConfigureAwait(false);
                            return;
                        }
                    case ConnectEventRequest connectEventRequest:
                        {
                            var response = await hub.OnConnectAsync(connectEventRequest, context.RequestAborted).ConfigureAwait(false);
                            if (response is EventErrorResponse error)
                            {
                                context.Response.StatusCode = ConvertToStatusCode(error.Code);
                                context.Response.ContentType = Constants.ContentTypes.PlainTextContentType;
                                await context.Response.WriteAsync(error.ErrorMessage).ConfigureAwait(false);
                                return;
                            }
                            else if (response is ConnectEventResponse connectResponse)
                            {
                                SetConnectionState(ref context, connectEventRequest.ConnectionContext, connectResponse.States);
                                await context.Response.WriteAsync(JsonSerializer.Serialize(connectResponse)).ConfigureAwait(false);
                                return;
                            }
                            // other response is invalid, igonre.
                            return;
                        }
                    case UserEventRequest messageRequest:
                        {
                            var response = await hub.OnMessageReceivedAsync(messageRequest, context.RequestAborted).ConfigureAwait(false);
                            if (response is EventErrorResponse error)
                            {
                                context.Response.StatusCode = ConvertToStatusCode(error.Code);
                                context.Response.ContentType = Constants.ContentTypes.PlainTextContentType;
                                await context.Response.WriteAsync(error.ErrorMessage).ConfigureAwait(false);
                                return;
                            }
                            else if (response is UserEventResponse msgResponse)
                            {
                                SetConnectionState(ref context, messageRequest.ConnectionContext, msgResponse.States);
                                context.Response.ContentType = ConvertToContentType(msgResponse.DataType);
                                var payload = msgResponse.Message.ToArray();
                                await context.Response.Body.WriteAsync(payload, 0, payload.Length).ConfigureAwait(false);
                                return;
                            }
                            // other response is invalid, igonre.
                            return;
                        }
                    case ConnectedEventRequest connectedEvent:
                        {
                            _ = hub.OnConnectedAsync(connectedEvent).ConfigureAwait(false);
                            return;
                        }
                    case DisconnectedEventRequest disconnectedEvent:
                        {
                            _ = hub.OnDisconnectedAsync(disconnectedEvent).ConfigureAwait(false);
                            return;
                        }
                    default:
                        return;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(ex.Message).ConfigureAwait(false);
                return;
            }
        }

        private static void SetConnectionState(ref HttpContext context, WebPubSubConnectionContext connectionContext, Dictionary<string, object> newStates)
        {
            var updatedStates = connectionContext.UpdateStates(newStates);
            if (updatedStates != null)
            {
                context.Response.Headers.Add(Constants.Headers.CloudEvents.State, updatedStates.EncodeConnectionStates());
            }
        }

        private static int ConvertToStatusCode(WebPubSubErrorCode errorCode) =>
            errorCode switch
            {
                WebPubSubErrorCode.UserError => StatusCodes.Status400BadRequest,
                WebPubSubErrorCode.Unauthorized => StatusCodes.Status401Unauthorized,
                // default and server error returns 500
                _ => StatusCodes.Status500InternalServerError
            };

        private static string ConvertToContentType(MessageDataType dataType) =>
            dataType switch
            {
                MessageDataType.Text => $"{Constants.ContentTypes.PlainTextContentType}; {Constants.ContentTypes.CharsetUTF8}",
                MessageDataType.Json => $"{Constants.ContentTypes.JsonContentType}; {Constants.ContentTypes.CharsetUTF8}",
                _ => Constants.ContentTypes.BinaryContentType
            };

        private THub Create<THub>() where THub : WebPubSubHub
        {
            var hub = _provider.GetService<THub>();
            if (hub == null)
            {
                hub = ActivatorUtilities.CreateInstance<THub>(_provider);
            }

            if (_hubRegistry.TryGetValue(nameof(hub), out _))
            {
                Debug.Assert(true, $"{typeof(THub)} must not be reused.");
            }
            return hub;
        }
    }
}
