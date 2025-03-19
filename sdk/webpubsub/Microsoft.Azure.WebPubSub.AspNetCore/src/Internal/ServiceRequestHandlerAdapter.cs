// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Authentication;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            RegisterHub(hub.GetType().Name, hub);
        }

        public void RegisterHub<THub>(string hubName) where THub : WebPubSubHub
        {
            var hub = Create<THub>();
            RegisterHub(hubName, hub);
        }

        // For test only
        internal void RegisterHub(string hubName, WebPubSubHub hub)
        {
            if (string.IsNullOrWhiteSpace(hubName))
            {
                throw new ArgumentNullException(nameof(hubName));
            }

            _hubRegistry[hubName] = hub ?? throw new ArgumentNullException(nameof(hub));
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

            WebPubSubEventRequest serviceRequest = null;
            try
            {
                serviceRequest = await request.ReadWebPubSubEventAsync(_requestValidator, context.RequestAborted).ConfigureAwait(false);
                Log.StartToHandleRequest(_logger, serviceRequest.ConnectionContext);

                switch (serviceRequest)
                {
                    // should not hit.
                    case PreflightRequest preflightRequest:
                        {
                            if (preflightRequest.IsValid)
                            {
                                context.Response.Headers.Append(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
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
                                await context.Response.WriteAsync(JsonSerializer.Serialize(response, response.GetType())).ConfigureAwait(false);
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
            catch (Exception ex) when (ex is UnauthorizedAccessException or AuthenticationException)
            {
                Log.FailedToHandleRequest(_logger, ex.Message, ex);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                string responseBodyString;
                if (serviceRequest is MqttConnectEventRequest mqttConnect)
                {
                    var responseBody = mqttConnect.Mqtt.ProtocolVersion switch
                    {
                        MqttProtocolVersion.V311 => ex switch
                        {
                            UnauthorizedAccessException => mqttConnect.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.NotAuthorized, ex.Message),
                            AuthenticationException => mqttConnect.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.BadUsernameOrPassword, ex.Message),
                            // Should not reach here
                            _ => throw new NotSupportedException($"Exception {ex.GetType().Name} is not supported.")
                        },
                        MqttProtocolVersion.V500 => ex switch
                        {
                            UnauthorizedAccessException => mqttConnect.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.NotAuthorized, ex.Message),
                            AuthenticationException => mqttConnect.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.BadUserNameOrPassword, ex.Message),
                            // Should not reach here
                            _ => throw new NotSupportedException($"Exception {ex.GetType().Name} is not supported.")
                        },
                        // Should not reach here.
                        _ => throw new NotSupportedException($"MQTT protocol version {mqttConnect.Mqtt.ProtocolVersion} is not supported.")
                    };
                    responseBodyString = JsonSerializer.Serialize(responseBody);
                }
                else
                {
                    responseBodyString = ex.Message;
                }
                await context.Response.WriteAsync(responseBodyString).ConfigureAwait(false);
            }
            catch (MqttConnectionException mqttException)
            {
                Log.FailedToHandleRequest(_logger, mqttException.Message, mqttException);
                if (serviceRequest is MqttConnectEventRequest mqttConnect)
                {
                    context.Response.StatusCode = (int)MqttConnectCodeToHttpStatusCodeConverter.ToHttpStatusCode(mqttException.MqttErrorResponse.Mqtt.Code);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(mqttException.MqttErrorResponse)).ConfigureAwait(false);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync($"Exception of type '{nameof(MqttConnectionException)}' can only be thrown for MQTT clients.").ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Log.FailedToHandleRequest(_logger, ex.Message, ex);
                // logging to service.
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                string responseBodyString;
                if (serviceRequest is MqttConnectEventRequest mqttConnect)
                {
                    var responseBody = mqttConnect.Mqtt.ProtocolVersion switch
                    {
                        MqttProtocolVersion.V311 => mqttConnect.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.ServerUnavailable, ex.Message),
                        MqttProtocolVersion.V500 => mqttConnect.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.ServerUnavailable, ex.Message),
                        // Should not reach here.
                        _ => throw new NotSupportedException($"MQTT protocol version {mqttConnect.Mqtt.ProtocolVersion} is not supported.")
                    };
                    responseBodyString = JsonSerializer.Serialize(responseBody);
                }
                else
                {
                    responseBodyString = ex.Message;
                }
                await context.Response.WriteAsync(responseBodyString).ConfigureAwait(false);
            }
        }

        private static void SetConnectionState(ref HttpContext context, WebPubSubConnectionContext connectionContext, IReadOnlyDictionary<string, BinaryData> newStates)
        {
            var updatedStates = connectionContext.UpdateStates(newStates);
            if (updatedStates != null)
            {
                context.Response.Headers.Append(Constants.Headers.CloudEvents.State, updatedStates.EncodeConnectionStates());
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
