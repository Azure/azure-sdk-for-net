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
    public static class WebPubSubRequestExtensions
    {
        /// <summary>
        /// Parse request to system/user type ServiceRequest.
        /// </summary>
        /// <param name="request">Upstream HttpRequest.</param>
        /// <param name="options"></param>
        /// <returns>Deserialize <see cref="WebPubSubRequest"/></returns>
        public static async Task<WebPubSubRequest> ParseServiceRequest(this HttpRequest request, WebPubSubValidationOptions options)
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
                    return new ValidationRequest(true);
                }
                else
                {
                    foreach (var item in requestHosts)
                    {
                        if (options.ContainsHost(item))
                        {
                            return new ValidationRequest(true);
                        }
                    }
                }
                return new ValidationRequest(false);
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
                            throw new ArgumentException($"ContentType is not supported: {request.ContentType}");
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
                    requestHosts = requestOrigin.ToList();
                    return true;
                }
            }
            requestHosts = null;
            return false;
        }

        internal static bool IsValidSignature(this ConnectionContext connectionContext, WebPubSubValidationOptions options)
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

        internal static Dictionary<string, object> DecodeConnectionStates(this string connectionStates)
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

        internal static Dictionary<string,object> UpdateStates(this ConnectionContext connectionContext, Dictionary<string, object> newStates) 
        {
            // states cleared.
            if (newStates == null)
            {
                return null;
            }

            if (connectionContext.States?.Count > 0 || newStates.Count > 0)
            {
                var states = new Dictionary<string, object>();
                if (connectionContext.States?.Count > 0)
                {
                    states = connectionContext.States.ToDictionary(x => x.Key, y => y.Value);
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

        internal static Dictionary<string, object> UpdateStates(this ConnectionContext connectionContext, MessageResponse response)
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
                    states = connectionContext.States.ToDictionary(x => x.Key, v => v.Value);
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

        internal static string EncodeConnectionStates(this Dictionary<string, object> value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value)));
        }

        private static bool TryParseCloudEvents(this HttpRequest request, out ConnectionContext connectionContext)
        {
            try
            {
                connectionContext = new ();
                connectionContext.ConnectionId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.ConnectionId);
                connectionContext.Hub = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Hub);
                connectionContext.EventType = GetEventType(request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Type));
                connectionContext.EventName = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.EventName);
                connectionContext.Signature = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.Signature);
                connectionContext.Origin = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.WebHookRequestOrigin);
                connectionContext.InitHeaders(request.Headers.ToDictionary(x => x.Key, v => new StringValues(v.Value.ToArray()), StringComparer.OrdinalIgnoreCase));

                // UserId is optional, e.g. connect
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.UserId))
                {
                    connectionContext.UserId = request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.UserId);
                }

                // connection states.
                if (request.Headers.ContainsKey(Constants.Headers.CloudEvents.State))
                {
                    connectionContext.InitStates(request.Headers.GetFirstHeaderValueOrDefault(Constants.Headers.CloudEvents.State).DecodeConnectionStates());
                }
            }
            catch (Exception)
            {
                connectionContext = null;
                return false;
            }

            return true;
        }

        private static RequestType GetRequestType(this ConnectionContext context)
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
