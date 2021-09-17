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
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Helper methods to parse upstream requests.
    /// </summary>
    public static class ServiceRequestExtensions
    {
        /// <summary>
        /// Parse upstream request headers following CloudEvents.
        /// </summary>
        /// <param name="request">Upstream HttpRequest.</param>
        /// <param name="connection">Parsed connection context from request.</param>
        /// <returns>True if request is an valid Web PubSub request, otherwise, false.</returns>
        public static bool TryParseCloudEvents(this HttpRequest request, out ConnectionContext connection)
        {
            // ConnectionId is required in upstream request, and method is POST.
            if (!request.Headers.ContainsKey(Constants.Headers.CloudEvents.ConnectionId)
                || ! HttpMethods.IsPost(request.Method))
            {
                connection = null;
                return false;
            }

            connection = new ConnectionContext();
            try
            {
                connection.ConnectionId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.ConnectionId);
                connection.Hub = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Hub);
                connection.EventType = GetEventType(request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Type));
                connection.EventName = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.EventName);
                connection.Signature = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Signature);
                connection.Origin = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.WebHookRequestOrigin);
                connection.Headers = request.Headers.ToDictionary(x => x.Key, v => new StringValues(v.Value.ToArray()), StringComparer.OrdinalIgnoreCase);

                // UserId is optional, e.g. connect
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.UserId))
                {
                    connection.UserId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.UserId);
                }

                // connection states.
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.State))
                {
                    connection.States = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.State).DecodeConnectionStates();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check whether request is validation request of abuse protection.
        /// </summary>
        /// <param name="request">Upstream HttpRequest.</param>
        /// <param name="requestHosts">Parsed upstream request hosts from request.</param>
        /// <returns>True if the request is abuse protection request, otherwise, false.</returns>
        public static bool IsValidationRequest(this HttpRequest request, out List<string> requestHosts)
        {
            if (HttpMethods.IsOptions(request.Method))
            {
                request.Headers.TryGetValue(Constants.Headers.WebHookRequestOrigin, out StringValues requestOrigin);
                if (requestOrigin.Any())
                {
                    requestHosts = requestOrigin.ToList();
                    return true;
                }
            }
            requestHosts = null;
            return false;
        }

        /// <summary>
        /// Validate request signature by connection-id and service key.
        /// </summary>
        /// <param name="connectionContext">Current connection context</param>
        /// <param name="options">Validation options contains validation metadata.</param>
        /// <returns>True if the signature check passes, otherwise, false.</returns>
        public static bool IsValidSignature(this ConnectionContext connectionContext, WebPubSubValidationOptions options)
        {
            // no options skip validation.
            if (options == null || !options.ContainsHost())
            {
                return true;
            }

            if (options.TryGetKey(connectionContext.Origin, out var accessKey))
            {
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

        /// <summary>
        /// Parse request to system/user type ServiceRequest, Abuse Protection ValidationRequest should use <see cref="IsValidSignature"/> to handle separately.
        /// </summary>
        /// <param name="request">Upstream HttpRequest.</param>
        /// <param name="context"></param>
        /// <returns>Deserialize <see cref="ServiceRequest"/></returns>
        public static async Task<ServiceRequest> ToServiceRequest(this HttpRequest request, ConnectionContext context = null)
        {
            if (context != null || request.TryParseCloudEvents(out context))
            {
                var requestType = context.GetRequestType();
                switch (requestType)
                {
                    case RequestType.Connect:
                        {
                            var content = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
                            var eventRequest = JsonSerializer.Deserialize<ConnectEventRequest>(content);
                            eventRequest.ConnectionContext = context;
                            return eventRequest;
                        }
                    case RequestType.User:
                        {
                            using var ms = new MemoryStream();
                            await request.Body.CopyToAsync(ms).ConfigureAwait(false);
                            var message = BinaryData.FromBytes(ms.ToArray());
                            if (!MediaTypeHeaderValue.Parse(request.ContentType).MediaType.IsValidMediaType(out var dataType))
                            {
                                return new InvalidRequest($"ContentType is not supported: {request.ContentType}");
                            }
                            return new MessageEventRequest(context, message, dataType);
                        }
                    case RequestType.Connected:
                        {
                            return new ConnectedEventRequest(context);
                        }
                    case RequestType.Disconnected:
                        {
                            var content = await new StreamReader(request.Body).ReadToEndAsync().ConfigureAwait(false);
                            var eventRequest = JsonSerializer.Deserialize<DisconnectedEventRequest>(content);
                            eventRequest.ConnectionContext = context;
                            return eventRequest;
                        }
                    default:
                        break;
                }
            }
            return new InvalidRequest($"Unknown upstream request, type: {context.EventType}, name: {context.EventName}");
        }

        /// <summary>
        /// Convert WebPubSubErrorCode to <see cref="StatusCodes"/>.
        /// </summary>
        /// <param name="errorCode">The <see cref="WebPubSubErrorCode"/></param>
        /// <returns>Equivalent <see cref="StatusCodes"/></returns>
        public static int ToStatusCode(this WebPubSubErrorCode errorCode) =>
            errorCode switch
            {
                WebPubSubErrorCode.UserError => StatusCodes.Status400BadRequest,
                WebPubSubErrorCode.Unauthorized => StatusCodes.Status401Unauthorized,
                // default and server error returns 500
                _ => StatusCodes.Status500InternalServerError
            };

        /// <summary>
        /// Convert MessageDataType to request ContentType.
        /// </summary>
        /// <param name="dataType">The <see cref="MessageDataType"/></param>
        /// <returns>Equivalent content type.</returns>
        public static string ToContentType(this MessageDataType dataType) =>
            dataType switch
            {
                MessageDataType.Text => $"{Constants.ContentTypes.PlainTextContentType}; {Constants.ContentTypes.CharsetUTF8}",
                MessageDataType.Json => $"{Constants.ContentTypes.JsonContentType}; {Constants.ContentTypes.CharsetUTF8}",
                _ => Constants.ContentTypes.BinaryContentType
            };

        /// <summary>
        /// Decode connection state.
        /// </summary>
        /// <param name="connectionStates">The raw string value get from Web PubSub upstream request header.</param>
        /// <returns>A dictionary of decoded connection states.</returns>
        public static Dictionary<string, object> DecodeConnectionStates(this string connectionStates)
        {
            if (!string.IsNullOrEmpty(connectionStates))
            {
                var states = new Dictionary<string, object>();
                var parsedStates = Encoding.UTF8.GetString(Convert.FromBase64String(connectionStates));
                var statesObj = JsonDocument.Parse(parsedStates);
                foreach (var item in statesObj.RootElement.EnumerateObject())
                {
                    // Use ToString() to set pure value without ValueKind.
                    states.Add(item.Name, item.Value.ToString());
                }
                return states;
            }
            return null;
        }

        /// <summary>
        /// Merge connection state
        /// </summary>
        /// <param name="connectionContext">Get existing connection state from upstream request connection context.</param>
        /// <param name="response">Get updated connection state from user set response.</param>
        /// <returns>A dictionary of  merged conection state, and null represents states are not in use or cleared by user.</returns>
        public static Dictionary<string,object> UpdateStates(this ConnectionContext connectionContext, ServiceResponse response)
        {
            // states cleared.
            if (response.States == null)
            {
                return null;
            }

            if (connectionContext.States?.Count > 0 || response.States.Count > 0)
            {
                var states = new Dictionary<string, object>();
                if (connectionContext.States?.Count > 0)
                {
                    states = connectionContext.States;
                }

                // response states keep empty is no change.
                if (response.States.Count == 0)
                {
                    return states;
                }
                foreach (var item in response.States)
                {
                    states[item.Key] = item.Value;
                }
                return states;
            }

            return null;
        }

        internal static RequestType GetRequestType(this ConnectionContext context)
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

        internal static string EncodeConnectionStates(this Dictionary<string, object> value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value)));
        }

        private static string GetFirstHeaderValueOrDefault(this IHeaderDictionary header, string key)
        {
            return header.TryGetValue(key, out StringValues values) && values.Count > 0 ? values[0] : null;
        }

        private static bool IsValidMediaType(this string mediaType, out MessageDataType dataType)
        {
            try
            {
                dataType = mediaType.GetMessageDataType();
                return true;
            }
            catch (Exception)
            {
                dataType = MessageDataType.Binary;
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

        private static MessageDataType GetMessageDataType(this string mediaType) =>
            mediaType.ToLowerInvariant() switch
            {
                Constants.ContentTypes.PlainTextContentType => MessageDataType.Text,
                Constants.ContentTypes.BinaryContentType => MessageDataType.Binary,
                Constants.ContentTypes.JsonContentType => MessageDataType.Json,
                _ => throw new ArgumentException($"Invalid content type: {mediaType}")
            };
    }
}
