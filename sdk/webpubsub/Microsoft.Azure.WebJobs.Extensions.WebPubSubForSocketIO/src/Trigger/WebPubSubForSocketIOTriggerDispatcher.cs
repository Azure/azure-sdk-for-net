// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOTriggerDispatcher : IWebPubSubForSocketIOTriggerDispatcher
    {
        private readonly Dictionary<SocketIOTriggerKey, WebPubSubForSocketIOListener> _listeners = new();
        private readonly ILogger _logger;
        private readonly SocketIOFunctionsOptions _options;

        public WebPubSubForSocketIOTriggerDispatcher(ILogger logger, SocketIOFunctionsOptions options)
        {
            _logger = logger;
            _options = options;
        }

        public void AddListener(SocketIOTriggerKey key, WebPubSubForSocketIOListener listener)
        {
            if (_listeners.ContainsKey(key))
            {
                throw new ArgumentException($"Duplicated binding attribute find: {key.ToString()}");
            }
            _listeners.Add(key, listener);
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req,
            CancellationToken token = default)
        {
            if (req.IsValidationRequest(out var requestHosts))
            {
                return RespondToServiceAbuseCheck(requestHosts, new WebPubSubValidationOptions(_options.DefaultConnectionInfo));
            }

            var (success, parseError) = TryParseCloudEvents(req, out var context);
            if (!success)
            {
                _logger.LogWarning($"Error parsing cloud event: {parseError}");
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            var function = GetFunctionTriggerKey(context);

            if (_listeners.TryGetValue(function, out var executor))
            {
                if (!context.IsValidSignature(executor.ValidationOptions))
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                // Upstream messaging is POST method
                if (req.Method != HttpMethod.Post)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                SocketIOEventHandlerRequest eventRequest = null;

                var requestType = Utilities.GetRequestType(context.EventType, context.EventName);
                int? ackId = null;
                switch (requestType)
                {
                    case RequestType.Connect:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonSerializer.Deserialize<ConnectEventRequest>(content);
                            eventRequest = new SocketIOConnectRequest(context.Namespace, context.SocketId, request.Claims, request.Query, request.ClientCertificates, request.Headers);
                            break;
                        }
                    case RequestType.Connected:
                        {
                            eventRequest = new SocketIOConnectedRequest(context.Namespace, context.SocketId);
                            break;
                        }
                    case RequestType.Disconnected:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonSerializer.Deserialize<DisconnectedEventRequest>(content);
                            eventRequest = new SocketIODisconnectedRequest(context.Namespace, context.SocketId, request.Reason);
                            break;
                        }
                    case RequestType.User:
                        {
                            if (!Utilities.ValidateMediaType(req.Content.Headers.ContentType.MediaType, out var dataType))
                            {
                                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                                {
                                    Content = new StringContent($"{Constants.ErrorMessages.NotSupportedDataType}{req.Content.Headers.ContentType.MediaType}")
                                };
                            }

                            var payload = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var packet = EngineIOProtocol.DecodePacket(payload);
                            ackId = packet.Id;
                            if (packet.Type != SocketIOPacketType.Event)
                            {
                                throw new InvalidDataException($"{Constants.ErrorMessages.InvalidSocketIOMessageType}{packet.Type}");
                            }
                            var (eventName, arguments) = SocketIOProtocol.ParseData(packet.Data);
                            if (eventName != context.EventName)
                            {
                                throw new InvalidDataException($"Event name dismatch. {context.EventName} from header but {eventName} from payload");
                            }
                            eventRequest = new SocketIOMessageRequest(context.Namespace, context.SocketId, payload, eventName, arguments);
                            break;
                        }
                    default:
                        break;
                }

                var triggerEvent = new SocketIOTriggerEvent
                {
                    ConnectionContext = context,
                    Request = eventRequest,
                    TaskCompletionSource = tcs,
                };
                await executor.Executor.TryExecuteAsync(new TriggeredFunctionData
                {
                    TriggerValue = triggerEvent
                }, token).ConfigureAwait(false);

                // After function processed, return on-hold event reponses.
                if (requestType == RequestType.Connect || (requestType == RequestType.User && ackId.HasValue))
                {
                    try
                    {
                        using (token.Register(() => tcs.TrySetCanceled()))
                        {
                            var response = await tcs.Task.ConfigureAwait(false);

                            // Skip no returns
                            if (response != null)
                            {
                                if (response is SocketIOConnectResponse connectResponse)
                                {
                                    return Utilities.BuildValidResponse(connectResponse);
                                }
                                if (response is SocketIOMessageResponse messageResponse)
                                {
                                    return Utilities.BuildValidResponse(messageResponse, context.Namespace, ackId.Value);
                                }
                                if (response is Newtonsoft.Json.Linq.JToken jResponse)
                                {
                                    return Utilities.BuildValidResponse(jResponse, requestType, context, ackId);
                                }
                                if (response is string responseAsString)
                                {
                                    // Python passes string here. Try to convert to JSON
                                    var jObj = Newtonsoft.Json.Linq.JObject.Parse(responseAsString);
                                    return Utilities.BuildValidResponse(jObj, requestType, context, ackId);
                                }

                                _logger.LogWarning($"Invalid response type {response.GetType()} regarding current request: RequestType.{requestType}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var error = new EventErrorResponse(WebPubSubErrorCode.ServerError, ex.Message);
                        return Utilities.BuildErrorResponse(error);
                    }
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // No function map to current request
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private static (bool Success, string Error) TryParseCloudEvents(HttpRequestMessage request, out SocketIOSocketContext context)
        {
            try
            {
                var connectionId = request.Headers.GetValues(Constants.Headers.CloudEvents.ConnectionId).Single();
                ThrowIfEmptyHeader(connectionId, Constants.Headers.CloudEvents.ConnectionId);
                var hub = request.Headers.GetValues(Constants.Headers.CloudEvents.Hub).Single();
                ThrowIfEmptyHeader(hub, Constants.Headers.CloudEvents.Hub);
                var eventType = Utilities.GetEventType(request.Headers.GetValues(Constants.Headers.CloudEvents.Type).Single());
                var eventName = request.Headers.GetValues(Constants.Headers.CloudEvents.EventName).Single();
                ThrowIfEmptyHeader(eventName, Constants.Headers.CloudEvents.EventName);
                var origin = string.Join(",", request.Headers.GetValues(Constants.Headers.WebHookRequestOrigin));
                var headers = request.Headers.ToDictionary(x => x.Key, v => v.Value.ToArray(), StringComparer.OrdinalIgnoreCase);
                string signature = null;
                // Signature is optional and binding with validation parameter.
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.Signature, out var val))
                {
                    signature = string.Join(",", val);
                }
                string? userId = null;
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.UserId, out var userIds))
                {
                    userId = userIds.FirstOrDefault();
                }
                string @namespace = request.Headers.GetValues(Constants.Headers.CloudEvents.Namespace).Single();
                ThrowIfEmptyHeader(@namespace, Constants.Headers.CloudEvents.Namespace);
                string socketId = request.Headers.GetValues(Constants.Headers.CloudEvents.SocketId).Single();
                ThrowIfEmptyHeader(socketId, Constants.Headers.CloudEvents.SocketId);

                context = new SocketIOSocketContext(eventType, eventName, hub, connectionId, userId, @namespace, socketId, signature, origin, headers);
                return (true, null);
            }
            catch (Exception ex)
            {
                context = null;
                return (false, ex.Message);
            }
        }

        private static SocketIOTriggerKey GetFunctionTriggerKey(SocketIOSocketContext context)
        {
            return new SocketIOTriggerKey(context.Hub, context.Namespace, context.EventType, context.EventName);
        }

        private static HttpResponseMessage RespondToServiceAbuseCheck(IList<string> requestHosts, WebPubSubValidationOptions options)
        {
            var response = new HttpResponseMessage();
            // skip validation and allow all.
            if (options == null || !options.ContainsHost())
            {
                response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, Constants.AllowedAllOrigins);
                return response;
            }
            else
            {
                foreach (var item in requestHosts)
                {
                    if (options.ContainsHost(item))
                    {
                        response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, item);
                        return response;
                    }
                }
            }
            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

        private static void ThrowIfEmptyHeader(string value, string headerName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidDataException("Missing required header or header is empty: " + headerName);
            }
        }
    }
}
