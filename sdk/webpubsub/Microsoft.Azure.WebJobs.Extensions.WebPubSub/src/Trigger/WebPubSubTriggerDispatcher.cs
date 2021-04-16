// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerDispatcher : IWebPubSubTriggerDispatcher
    {
        private Dictionary<string, WebPubSubListener> _listeners = new Dictionary<string, WebPubSubListener>();

        public void AddListener(string key, WebPubSubListener listener)
        {
            if (_listeners.ContainsKey(key))
            {
                throw new ArgumentException($"Duplicated binding attribute find: {string.Join(",", key.Split('.'))}");
            }
            _listeners.Add(key, listener);
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage req, 
            HashSet<string> allowedHosts, 
            HashSet<string> accessKeys,
            CancellationToken token = default)
        {
            // Handle service abuse check.
            if (RespondToServiceAbuseCheck(req, allowedHosts, out var abuseResponse))
            {
                return abuseResponse;
            }

            if (!TryParseRequest(req, out var context))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (!ValidateSignature(context.ConnectionId, context.Signature, accessKeys))
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            var function = GetFunctionName(context);

            if (_listeners.TryGetValue(function, out var executor))
            {
                WebPubSubMessage message = null;
                MessageDataType dataType = MessageDataType.Text;
                IDictionary<string, string[]> claims = null;
                IDictionary<string, string[]> query = null;
                string[] subprotocols = null;
                ClientCertificateInfo[] certificates = null;
                string reason = null;

                var requestType = Utilities.GetRequestType(context.EventType, context.EventName);
                switch (requestType)
                {
                    case RequestType.Connect:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonConvert.DeserializeObject<ConnectEventRequest>(content);
                            claims = request.Claims;
                            subprotocols = request.Subprotocols;
                            query = request.Query;
                            certificates = request.ClientCertificates;
                            break;
                        }
                    case RequestType.Disconnect:
                        {
                            var content = await req.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var request = JsonConvert.DeserializeObject<DisconnectEventRequest>(content);
                            reason = request.Reason;
                            break;
                        }
                    case RequestType.User:
                        {
                            if (!ValidateContentType(req.Content.Headers.ContentType.MediaType, out dataType))
                            {
                                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                                {
                                    Content = new StringContent($"{Constants.ErrorMessages.NotSupportedDataType}{req.Content.Headers.ContentType.MediaType}")
                                };
                            }

                            var payload = await req.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                            message = new WebPubSubMessage(payload);
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
                    ClientCertificaties = certificates,
                    Reason = reason,
                    TaskCompletionSource = tcs
                };
                await executor.Executor.TryExecuteAsync(new TriggeredFunctionData
                {
                    TriggerValue = triggerEvent
                }, token);

                // After function processed, return on-hold event reponses.
                if (requestType.IsSyncMethod())
                {
                    try
                    {
                        using (token.Register(() => tcs.TrySetCanceled()))
                        {
                            var response = await tcs.Task.ConfigureAwait(false);
                            if (response is ErrorResponse error)
                            {
                                return Utilities.BuildErrorResponse(error);
                            }
                            else if (requestType == RequestType.Connect && response is ConnectResponse connect)
                            {
                                return Utilities.BuildResponse(connect);
                            }
                            else if (requestType == RequestType.User && response is MessageResponse msgResponse)
                            {
                                return Utilities.BuildResponse(msgResponse);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var error = new ErrorResponse(WebPubSubErrorCode.ServerError, ex.Message);
                        return Utilities.BuildErrorResponse(error);
                    }
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            // No function map to current request
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private static bool TryParseRequest(HttpRequestMessage request, out ConnectionContext context)
        {
            // ConnectionId is required in upstream request, and method is POST.
            if (!request.Headers.Contains(Constants.Headers.CloudEvents.ConnectionId)
                || request.Method != HttpMethod.Post)
            {
                context = null;
                return false;
            }

            context = new ConnectionContext();
            try
            {
                context.ConnectionId = request.Headers.GetValues(Constants.Headers.CloudEvents.ConnectionId).FirstOrDefault();
                context.Hub = request.Headers.GetValues(Constants.Headers.CloudEvents.Hub).FirstOrDefault();
                context.EventType = Utilities.GetEventType(request.Headers.GetValues(Constants.Headers.CloudEvents.Type).FirstOrDefault());
                context.EventName = request.Headers.GetValues(Constants.Headers.CloudEvents.EventName).FirstOrDefault();
                context.Signature = request.Headers.GetValues(Constants.Headers.CloudEvents.Signature).FirstOrDefault();
                context.Headers = request.Headers.ToDictionary(x => x.Key, v => new StringValues(v.Value.ToArray()), StringComparer.OrdinalIgnoreCase);

                // UserId is optional, e.g. connect
                if (request.Headers.TryGetValues(Constants.Headers.CloudEvents.UserId, out var values))
                {
                    context.UserId = values.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static bool ValidateSignature(string connectionId, string signature, HashSet<string> accessKeys)
        {
            foreach (var accessKey in accessKeys)
            {
                var signatures = Utilities.GetSignatureList(signature);
                if (signatures == null)
                {
                    continue;
                }
                using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey)))
                {
                    var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionId));
                    var hash = "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
                    if (signatures.Contains(hash, StringComparer.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return false;
        }

        private static bool ValidateContentType(string mediaType, out MessageDataType dataType)
        {
            try
            {
                dataType = Utilities.GetDataType(mediaType);
                return true;
            }
            catch (Exception)
            {
                dataType = MessageDataType.Binary;
                return false;
            }
        }

        private static string GetFunctionName(ConnectionContext context)
        {
            return $"{context.Hub}.{context.EventType}.{context.EventName}".ToLower();
        }

        private static bool RespondToServiceAbuseCheck(HttpRequestMessage req, HashSet<string> allowedHosts, out HttpResponseMessage response)
        {
            response = new HttpResponseMessage();
            // TODO: remove Get when function core is fully supported and AWPS service is updated.
            if (req.Method == HttpMethod.Options || req.Method == HttpMethod.Get)
            {
                var hosts = req.Headers.GetValues(Constants.Headers.WebHookRequestOrigin);
                if (hosts != null && hosts.Count() > 0)
                {
                    foreach (var item in allowedHosts)
                    {
                        if (hosts.Contains(item))
                        {
                            response.Headers.Add(Constants.Headers.WebHookAllowedOrigin, hosts);
                            return true;
                        }
                    }
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                return true;
            }
            return false;
        }
    }
}
