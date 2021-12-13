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
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Helper methods to parse upstream requests.
    /// </summary>
    internal static class WebPubSubRequestExtensions
    {
        private static JsonSerializerOptions _innerSerializer => CreateSystemTextJsonSerializer();
        /// <summary>
        /// Parse request to system/user type ServiceRequest.
        /// </summary>
        /// <param name="request">Upstream HttpRequest.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Deserialize <see cref="WebPubSubEventRequest"/></returns>
        internal static async Task<WebPubSubEventRequest> ReadWebPubSubEventAsync(this HttpRequest request, WebPubSubValidationOptions options = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // validation request.
            if (request.IsPreflightRequest(out var requestHosts))
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
                        var eventRequest = JsonSerializer.Deserialize<ConnectEventRequest>(content);
                        return new ConnectEventRequest(context, eventRequest.Claims, eventRequest.Query, eventRequest.Subprotocols, eventRequest.ClientCertificates);
                    }
                case RequestType.User:
                    {
                        const int bufferSize = 4096;
                        using var ms = new MemoryStream();
                        await request.Body.CopyToAsync(ms, bufferSize, cancellationToken).ConfigureAwait(false);
                        var message = BinaryData.FromBytes(ms.ToArray());
                        if (!MediaTypeHeaderValue.Parse(request.ContentType).MediaType.IsValidMediaType(out var dataType))
                        {
                            throw new ArgumentException($"ContentType is not supported: {request.ContentType}");
                        }
                        return new UserEventRequest(context, message, dataType);
                    }
                case RequestType.Connected:
                    {
                        return new ConnectedEventRequest(context);
                    }
                case RequestType.Disconnected:
                    {
                        var content = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
                        var eventRequest = JsonSerializer.Deserialize<DisconnectedEventRequest>(content);
                        return new DisconnectedEventRequest(context, eventRequest.Reason);
                    }
                default:
                    return null;
            }
        }

        internal static bool IsPreflightRequest(this HttpRequest request, out List<string> requestHosts)
        {
            if (HttpMethods.IsOptions(request.Method))
            {
                request.Headers.TryGetValue(Constants.Headers.WebHookRequestOrigin, out StringValues requestOrigin);
                if (requestOrigin.Count > 0)
                {
                    requestHosts = requestOrigin.ToList();
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

            // TODO: considering add cache to improve.
            if (options.TryGetKey(connectionContext.Origin, out var accessKey))
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
            return false;
        }

        internal static Dictionary<string, BinaryData> DecodeConnectionStates(this string connectionStates)
        {
            if (!string.IsNullOrEmpty(connectionStates))
            {
                var strongTyped = JsonSerializer.Deserialize<IReadOnlyDictionary<string, BinaryData>>(Convert.FromBase64String(connectionStates), _innerSerializer);
                return new Dictionary<string, BinaryData>(strongTyped);
            }
            return null;
        }

        internal static Dictionary<string, BinaryData> UpdateStates(this WebPubSubConnectionContext connectionContext, IReadOnlyDictionary<string, BinaryData> newStates)
        {
            // states cleared.
            if (newStates == null)
            {
                return null;
            }

            if (connectionContext.ConnectionStates?.Count > 0 || newStates.Count > 0)
            {
                var states = new Dictionary<string, BinaryData>();
                if (connectionContext.ConnectionStates?.Count > 0)
                {
                    states = connectionContext.ConnectionStates.ToDictionary(x => x.Key, y => y.Value);
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

        internal static string EncodeConnectionStates(this IReadOnlyDictionary<string, BinaryData> value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _innerSerializer)));
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

                connectionContext = new WebPubSubConnectionContext(eventType, eventName, hub, connectionId, userId, signature, origin, states, headers);
                return true;
            }
            catch (Exception)
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
            catch (Exception)
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

        private static JsonSerializerOptions CreateSystemTextJsonSerializer()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ConnectionStatesConverter());
            return options;
        }
    }
}
