// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Copied from Microsoft.Azure.WebPubSub.AspNetCore.
    /// </summary>
    internal static class WebPubSubRequestExtensions
    {
        public static async Task<WebPubSubEventRequest> ReadWebPubSubRequestAsync(this HttpRequest request, WebPubSubValidationOptions options)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // validation request.
            if (request.IsValidationRequest(out var requestHosts))
            {
                if (options == null || !options.ContainsHost())
                {
                    return new PreflightRequest(true);
                }
                else
                {
                    foreach (var item in requestHosts)
                    {
                        if (options.ContainsHost(item))
                        {
                            return new PreflightRequest(true);
                        }
                    }
                }
                return new PreflightRequest(false);
            }

            if (!request.TryParseCloudEvents(out var context))
            {
                throw new ArgumentException("Invalid Web PubSub upstream request missing required fields in header.");
            }

            if (!context.IsValidSignature(options))
            {
                throw new UnauthorizedAccessException("Signature validation failed.");
            }

            var requestType = context.GetRequestType();
            switch (requestType)
            {
                case RequestType.Connect:
                    {
                        var content = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
                        if (context is MqttConnectionContext mqttContext)
                        {
                            var requestBody = JsonSerializer.Deserialize<MqttConnectEventRequestContent>(content);
                            return new MqttConnectEventRequest(mqttContext, requestBody.Claims, requestBody.Query, requestBody.ClientCertificates, requestBody.Headers, requestBody.Mqtt);
                        }
                        else
                        {
                            var requestBody = JsonSerializer.Deserialize<ConnectEventRequest>(content);
                            return new ConnectEventRequest(context, requestBody.Claims, requestBody.Query, requestBody.Subprotocols, requestBody.ClientCertificates, requestBody.Headers);
                        }
                    }
                case RequestType.User:
                    {
                        using var ms = new MemoryStream();
                        await request.Body.CopyToAsync(ms).ConfigureAwait(false);
                        var data = BinaryData.FromBytes(ms.ToArray());
                        if (!MediaTypeHeaderValue.Parse(request.ContentType).MediaType.IsValidMediaType(out var dataType))
                        {
                            throw new ArgumentException($"ContentType is not supported: {request.ContentType}");
                        }
                        return new UserEventRequest(context, data, dataType);
                    }
                case RequestType.Connected:
                    {
                        return new ConnectedEventRequest(context);
                    }
                case RequestType.Disconnected:
                    {
                        var content = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
                        if (context is MqttConnectionContext mqttContext)
                        {
                            var requestBody = JsonSerializer.Deserialize<MqttDisconnectedEventRequestContent>(content);
                            return new MqttDisconnectedEventRequest(mqttContext, requestBody.Reason, requestBody.Mqtt);
                        }
                        else
                        {
                            var requestBody = JsonSerializer.Deserialize<DisconnectedEventRequest>(content);
                            return new DisconnectedEventRequest(context, requestBody.Reason);
                        }
                    }
                default:
                    return null;
            }
        }

        internal static bool IsValidationRequest(this HttpRequest request, out List<string> requestHosts)
        {
            if (HttpMethods.IsOptions(request.Method))
            {
                request.Headers.TryGetValue(Constants.Headers.WebHookRequestOrigin, out StringValues requestOrigin);
                if (requestOrigin.Any())
                {
                    requestHosts = requestOrigin.SelectMany(x => x.Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries)).ToList();
                    return true;
                }
            }
            requestHosts = null;
            return false;
        }

        internal static bool IsValidSignature(this WebPubSubConnectionContext connectionContext, WebPubSubValidationOptions options)
        {
            // no options skip validation.
            if (options == null || !options.ContainsHost())
            {
                return true;
            }
            foreach (var origin in connectionContext.Origin.ToHeaderList())
            {
                if (options.TryGetKey(origin, out var accessKey))
                {
                    // server side disable signature checks.
                    if (string.IsNullOrEmpty(accessKey))
                    {
                        return true;
                    }

                    var signatures = connectionContext.Signature.ToHeaderList();
                    if (signatures == null)
                    {
                        return false;
                    }
                    using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey));
                    var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionContext.ConnectionId));
                    var hash = "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
                    if (signatures.Contains(hash, StringComparer.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static Dictionary<string, BinaryData> DecodeConnectionStates(this string connectionStates)
        {
            if (!string.IsNullOrEmpty(connectionStates))
            {
                var states = new Dictionary<string, object>();
                return JsonSerializer.Deserialize<IReadOnlyDictionary<string, BinaryData>>(Convert.FromBase64String(connectionStates), ConnectionStatesConverter.Options)
                    .ToDictionary(k => k.Key, v => v.Value);
            }
            return null;
        }

        internal static Dictionary<string, object> UpdateStates(this WebPubSubConnectionContext connectionContext, IReadOnlyDictionary<string, BinaryData> newStates)
        {
            // states cleared.
            if (newStates == null)
            {
                return null;
            }

            if (connectionContext.ConnectionStates?.Count > 0 || newStates.Count > 0)
            {
                var states = new Dictionary<string, object>();
                if (connectionContext.ConnectionStates?.Count > 0)
                {
                    foreach (var state in connectionContext.ConnectionStates)
                    {
                        states.Add(state.Key, state.Value);
                    }
                }

                // response states keep empty is no change.
                if (newStates.Count == 0)
                {
                    return states;
                }
                foreach (var item in newStates)
                {
                    states[item.Key] = item.Value;
                }
                return states;
            }

            return null;
        }

        internal static string EncodeConnectionStates(this Dictionary<string, object> value)
        {
            IReadOnlyDictionary<string, BinaryData> readOnlyDict = value.ToDictionary(x => x.Key, y => y.Value is BinaryData data ? data : FromObjectAsJsonExtended(y.Value));
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(readOnlyDict, ConnectionStatesConverter.Options)));
        }

        private static bool TryParseCloudEvents(this HttpRequest request, out WebPubSubConnectionContext connectionContext)
        {
            try
            {
                var connectionId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.ConnectionId);
                var hub = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Hub);
                var eventType = GetEventType(request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Type));
                var eventName = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.EventName);
                var signature = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Signature);
                var origin = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.WebHookRequestOrigin);
                var headers = request.Headers.ToDictionary(x => x.Key, v => v.Value.ToArray(), StringComparer.OrdinalIgnoreCase);

                string userId = null;
                // UserId is optional, e.g. connect
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.UserId))
                {
                    userId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.UserId);
                }

                Dictionary<string, BinaryData> states = null;
                // connection states.
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.State))
                {
                    states = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.State).DecodeConnectionStates();
                }

                if (Constants.MqttWebSocketSubprotocolValue.Equals(request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Subprotocol)))
                {
                    var physicalConnectionId = request.Headers[Constants.Headers.CloudEvents.MqttPhysicalConnectionId];
                    if (physicalConnectionId.Count != 0)
                    {
                        var sessionId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.MqttSessionId);
                        connectionContext = new MqttConnectionContext(eventType, eventName, hub, connectionId, physicalConnectionId.First(), sessionId, userId, signature, origin, states, headers);
                        return true;
                    }
                }
                connectionContext = new WebPubSubConnectionContext(eventType, eventName, hub, connectionId, userId, signature, origin, states, headers);
                return true;
            }
            catch
            {
                connectionContext = null;
                return false;
            }
        }

        private static RequestType GetRequestType(this WebPubSubConnectionContext context)
        {
            if (context.EventType == WebPubSubEventType.User)
            {
                return RequestType.User;
            }
            if (context.EventName.Equals(Constants.Events.ConnectEvent, StringComparison.OrdinalIgnoreCase))
            {
                return RequestType.Connect;
            }
            if (context.EventName.Equals(Constants.Events.DisconnectedEvent, StringComparison.OrdinalIgnoreCase))
            {
                return RequestType.Disconnected;
            }
            if (context.EventName.Equals(Constants.Events.ConnectedEvent, StringComparison.OrdinalIgnoreCase))
            {
                return RequestType.Connected;
            }
            return RequestType.Ignored;
        }

        private static string GetFirstHeaderValueOrDefault(this IHeaderDictionary header, string key)
        {
            return header.TryGetValue(key, out StringValues values) && values.Count > 0 ? values[0] : null;
        }

        private static bool IsValidMediaType(this string mediaType, out WebPubSubDataType dataType)
        {
            try
            {
                dataType = mediaType.GetDataType();
                return true;
            }
            catch
            {
                dataType = WebPubSubDataType.Binary;
                return false;
            }
        }

        private static IReadOnlyList<string> ToHeaderList(this string signatures)
        {
            if (string.IsNullOrEmpty(signatures))
            {
                return default;
            }

            return signatures.Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries);
        }

        private static WebPubSubEventType GetEventType(this string ceType)
        {
            return ceType.StartsWith(Constants.Headers.CloudEvents.TypeSystemPrefix, StringComparison.OrdinalIgnoreCase) ?
                WebPubSubEventType.System :
                WebPubSubEventType.User;
        }

        private static WebPubSubDataType GetDataType(this string mediaType) =>
            mediaType.ToLowerInvariant() switch
            {
                Constants.ContentTypes.PlainTextContentType => WebPubSubDataType.Text,
                Constants.ContentTypes.BinaryContentType => WebPubSubDataType.Binary,
                Constants.ContentTypes.JsonContentType => WebPubSubDataType.Json,
                _ => throw new ArgumentException($"Invalid content type: {mediaType}")
            };

        // support JToken for backward compatiblity.
        private static BinaryData FromObjectAsJsonExtended<T>(T item, JsonSerializerOptions? options = null)
        {
            if (item is JToken)
            {
                return BinaryData.FromString(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            }
            else
            {
                return BinaryData.FromObjectAsJson(item, options);
            }
        }
    }
}
