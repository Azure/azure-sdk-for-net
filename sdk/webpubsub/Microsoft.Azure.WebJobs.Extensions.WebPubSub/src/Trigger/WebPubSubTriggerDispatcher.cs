// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
                return RespondToServiceAbuseCheck(requestHosts, _options.ValidationOptions);
            }

            if (!TryParseCloudEvents(req, out var context))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            var function = GetFunctionName(context);

            if (_listeners.TryGetValue(function, out var executor))
            {
                if (!context.IsValidSignature(_options.ValidationOptions))
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                // Upstream messaging is POST method
                if (req.Method != HttpMethod.Post)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                BinaryData message = null;
                MessageDataType dataType = MessageDataType.Text;
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
                            claims = request.Claims;
                            subprotocols = new List<string>(request.Subprotocols);
                            query = request.Query;
                            certificates = new List<WebPubSubClientCertificate>(request.ClientCertificates);
                            request.ConnectionContext = context;
                            eventRequest = request;
                            break;
                        }
                    case RequestType.Disconnected:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonSerializer.Deserialize<DisconnectedEventRequest>(content);
                            reason = request.Reason;
                            request.ConnectionContext = context;
                            eventRequest = request;
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
                            message = BinaryData.FromBytes(payload);
                            eventRequest = new UserEventRequest(context, message, dataType);
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
                    Message = message,
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
                                var validResponse = Utilities.BuildValidResponse(response, requestType);

                                if (validResponse != null)
                                {
                                    // built-in support on set states only applies .NET WebPubSubTrigger.
                                    if (response is ConnectEventResponse connectResponse)
                                    {
                                        AddStateHeader(ref validResponse, context, connectResponse.States);
                                    }
                                    if (response is UserEventResponse msgResponse)
                                    {
                                        AddStateHeader(ref validResponse, context, msgResponse.States);
                                    }
                                    return validResponse;
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
                context = new();
                context.ConnectionId = request.Headers.GetValues(Constants.Headers.CloudEvents.ConnectionId).SingleOrDefault();
                context.Hub = request.Headers.GetValues(Constants.Headers.CloudEvents.Hub).SingleOrDefault();
                context.EventType = Utilities.GetEventType(request.Headers.GetValues(Constants.Headers.CloudEvents.Type).SingleOrDefault());
                context.EventName = request.Headers.GetValues(Constants.Headers.CloudEvents.EventName).SingleOrDefault();
                context.Signature = request.Headers.GetValues(Constants.Headers.CloudEvents.Signature).SingleOrDefault();
                context.Origin = request.Headers.GetValues(Constants.Headers.WebHookRequestOrigin).SingleOrDefault();
                context.InitHeaders(request.Headers.ToDictionary(x => x.Key, v => v.Value.ToArray(), StringComparer.OrdinalIgnoreCase));

                // UserId is optional, e.g. connect
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.UserId, out var values))
                {
                    context.UserId = values.SingleOrDefault();
                }

                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.State, out var connectionStates))
                {
                    context.InitStates(connectionStates.SingleOrDefault().DecodeConnectionStates());
                }
            }
            catch (Exception)
            {
                context = null;
                return false;
            }

            return true;
        }

        private static string GetFunctionName(WebPubSubConnectionContext context)
        {
            return $"{context.Hub}.{context.EventType}.{context.EventName}";
        }

        public static void AddStateHeader(ref HttpResponseMessage response, WebPubSubConnectionContext context, Dictionary<string, object> newStates)
        {
            var updatedStates = context.UpdateStates(newStates);
            if (updatedStates != null)
            {
                response.Headers.Add(Constants.Headers.CloudEvents.State, updatedStates.EncodeConnectionStates());
            }
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
