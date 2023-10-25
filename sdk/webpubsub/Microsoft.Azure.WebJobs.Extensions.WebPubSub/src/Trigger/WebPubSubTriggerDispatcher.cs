// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging;

using NewtonsoftJsonLinq = Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerDispatcher : IWebPubSubTriggerDispatcher
    {
        private readonly Dictionary<string, WebPubSubListener> _listeners = new(StringComparer.InvariantCultureIgnoreCase);
        private readonly ILogger _logger;
        private readonly WebPubSubFunctionsOptions _options;

        public WebPubSubTriggerDispatcher(ILogger logger, WebPubSubFunctionsOptions options)
        {
            _logger = logger;
            _options = options;
        }

        public void AddListener(string key, WebPubSubListener listener)
        {
            if (_listeners.ContainsKey(key))
            {
                throw new ArgumentException($"Duplicated binding attribute find: {string.Join(",", key.Split('.'))}");
            }
            _listeners.Add(key, listener);
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req,
            CancellationToken token = default)
        {
            if (req.IsValidationRequest(out var requestHosts))
            {
                return RespondToServiceAbuseCheck(requestHosts, new WebPubSubValidationOptions(_options.ConnectionString));
            }

            if (!TryParseCloudEvents(req, out var context))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            var function = GetFunctionName(context);

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

                BinaryData data = null;
                WebPubSubDataType dataType = WebPubSubDataType.Text;
                IDictionary<string, string[]> claims = null;
                IDictionary<string, string[]> query = null;
                IList<string> subprotocols = null;
                IList<WebPubSubClientCertificate> certificates = null;
                string reason = null;
                WebPubSubEventRequest eventRequest = null;

                var requestType = Utilities.GetRequestType(context.EventType, context.EventName);
                switch (requestType)
                {
                    case RequestType.Connect:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonSerializer.Deserialize<ConnectEventRequest>(content);
                            eventRequest = new ConnectEventRequest(context, request.Claims, request.Query, request.Subprotocols, request.ClientCertificates, request.Headers);
                            break;
                        }
                    case RequestType.Disconnected:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonSerializer.Deserialize<DisconnectedEventRequest>(content);
                            eventRequest = new DisconnectedEventRequest(context, request.Reason);
                            break;
                        }
                    case RequestType.User:
                        {
                            if (!Utilities.ValidateMediaType(req.Content.Headers.ContentType.MediaType, out dataType))
                            {
                                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                                {
                                    Content = new StringContent($"{Constants.ErrorMessages.NotSupportedDataType}{req.Content.Headers.ContentType.MediaType}")
                                };
                            }

                            var payload = await req.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                            data = BinaryData.FromBytes(payload);
                            eventRequest = new UserEventRequest(context, data, dataType);
                            break;
                        }
                    case RequestType.Connected:
                        {
                            eventRequest = new ConnectedEventRequest(context);
                            break;
                        }
                    default:
                        break;
                }

                var triggerEvent = new WebPubSubTriggerEvent
                {
                    ConnectionContext = context,
                    Data = data,
                    DataType = dataType,
                    Claims = claims,
                    Query = query,
                    Subprotocols = subprotocols,
                    ClientCertificates = certificates,
                    Reason = reason,
                    Request = eventRequest,
                    TaskCompletionSource = tcs
                };
                await executor.Executor.TryExecuteAsync(new TriggeredFunctionData
                {
                    TriggerValue = triggerEvent
                }, token).ConfigureAwait(false);

                // After function processed, return on-hold event reponses.
                if (requestType == RequestType.Connect || requestType == RequestType.User)
                {
                    try
                    {
                        using (token.Register(() => tcs.TrySetCanceled()))
                        {
                            var response = await tcs.Task.ConfigureAwait(false);

                            // Skip no returns
                            if (response != null)
                            {
                                if (response is WebPubSubEventResponse wpsResponse)
                                {
                                    return Utilities.BuildValidResponse(wpsResponse, requestType, context);
                                }
                                if (response is NewtonsoftJsonLinq.JToken jResponse)
                                {
                                    return Utilities.BuildValidResponse(jResponse, requestType, context);
                                }

                                _logger.LogWarning($"Invalid response type {response.GetType()} regarding current request: {requestType}");
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

        private static bool TryParseCloudEvents(HttpRequestMessage request, out WebPubSubConnectionContext context)
        {
            try
            {
                var connectionId = request.Headers.GetValues(Constants.Headers.CloudEvents.ConnectionId).SingleOrDefault();
                var hub = request.Headers.GetValues(Constants.Headers.CloudEvents.Hub).SingleOrDefault();
                var eventType = Utilities.GetEventType(request.Headers.GetValues(Constants.Headers.CloudEvents.Type).SingleOrDefault());
                var eventName = request.Headers.GetValues(Constants.Headers.CloudEvents.EventName).SingleOrDefault();
                var origin = string.Join(",", request.Headers.GetValues(Constants.Headers.WebHookRequestOrigin));
                var headers = request.Headers.ToDictionary(x => x.Key, v => v.Value.ToArray(), StringComparer.OrdinalIgnoreCase);
                string signature = null;
                // Signature is optional and binding with validation parameter.
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.Signature, out var val))
                {
                    signature = string.Join(",", val);
                }
                string userId = null;
                // UserId is optional, e.g. connect
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.UserId, out var values))
                {
                    userId = values.SingleOrDefault();
                }
                Dictionary<string, BinaryData> states = null;
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var connectionStates))
                {
                    states = connectionStates.SingleOrDefault().DecodeConnectionStates();
                }

                context = new WebPubSubConnectionContext(eventType, eventName, hub, connectionId, userId, signature, origin, states, headers);
                return true;
            }
            catch
            {
                context = null;
                return false;
            }
        }

        private static string GetFunctionName(WebPubSubConnectionContext context)
        {
            return $"{context.Hub}.{context.EventType}.{context.EventName}";
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
    }
}
