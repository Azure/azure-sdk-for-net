// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal static class Utilities
    {
        private const string Separator = "~";
        private const string NamespaceGroupType = "0";
        private const string statusCodeProperty = "statusCode";
        private const string ackProperty = "ack";

        public static string GetContentType(WebPubSubDataType dataType) =>
            dataType switch
            {
                WebPubSubDataType.Text => Constants.ContentTypes.PlainTextContentType,
                _ => throw new ArgumentException($"{Constants.ErrorMessages.NotSupportedDataType}{dataType}")
            };

        public static WebPubSubDataType GetDataType(string mediaType) =>
            mediaType.ToLowerInvariant() switch
            {
                Constants.ContentTypes.PlainTextContentType => WebPubSubDataType.Text,
                _ => throw new ArgumentException($"{Constants.ErrorMessages.NotSupportedDataType}{mediaType}")
            };

        public static WebPubSubEventType GetEventType(string ceType)
        {
            return ceType.StartsWith(Constants.Headers.CloudEvents.TypeSystemPrefix, StringComparison.OrdinalIgnoreCase) ?
                WebPubSubEventType.System :
                WebPubSubEventType.User;
        }

        public static HttpResponseMessage BuildErrorResponse(EventErrorResponse error)
        {
            return BuildErrorResponse(error.ErrorMessage, error.Code);
        }

        public static HttpResponseMessage BuildErrorResponse(string errorMessage, WebPubSubErrorCode code = WebPubSubErrorCode.ServerError)
        {
            HttpResponseMessage result = new();

            result.StatusCode = GetStatusCode(code);
            result.Content = new StringContent(errorMessage);
            return result;
        }

        public static HttpResponseMessage BuildValidResponse(SocketIOConnectResponse response)
        {
            HttpResponseMessage result = new();
            result.StatusCode = response.StatusCode;
            return result;
        }

        public static HttpResponseMessage BuildValidResponse(SocketIOMessageResponse response, string @namespace, int ackId)
        {
            HttpResponseMessage result = new();
            result.StatusCode = response.StatusCode;
            if (response.Parameters != null && response.Parameters.Count != 0)
            {
                result.Content = new StringContent(EngineIOProtocol.EncodePacketToString(
                    new SocketIOPacket(SocketIOPacketType.Ack, @namespace, JsonConvert.SerializeObject(response.Parameters)) { Id = ackId }));
            }
            return result;
        }

        public static HttpResponseMessage BuildValidResponse(
            JToken jResponse, RequestType requestType,
            SocketIOSocketContext context, int? ackId)
        {
            try
            {
                JObject response = jResponse is JObject jObj ? jObj : throw new ArgumentException("Response should be a JObject.");

                HttpStatusCode statusCode;
                if (response.TryGetValue(statusCodeProperty, out var code))
                {
                    statusCode = code.ToObject<HttpStatusCode>();
                }
                else
                {
                    statusCode = HttpStatusCode.OK;
                }

                if (requestType == RequestType.Connect)
                {
                    return BuildValidResponse(new SocketIOConnectResponse(statusCode));
                }
                else if (requestType == RequestType.User)
                {
                    IList<object> ackData = null;
                    if (response.TryGetValue(ackProperty, out var ack))
                    {
                        ackData = ack.ToObject<List<object>>();
                    }
                    return BuildValidResponse(new SocketIOMessageResponse(statusCode, ackData), context.Namespace, ackId.Value);
                }
            }
            catch (Exception ex)
            {
                return BuildErrorResponse(new EventErrorResponse(WebPubSubErrorCode.ServerError, ex.Message));
            }

            // should not hit.
            throw new ArgumentException($"Invalid request type, '{requestType}'.");
        }

        public static HttpStatusCode GetStatusCode(WebPubSubErrorCode errorCode) =>
            errorCode switch
            {
                WebPubSubErrorCode.UserError => HttpStatusCode.BadRequest,
                WebPubSubErrorCode.Unauthorized => HttpStatusCode.Unauthorized,
                WebPubSubErrorCode.ServerError => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.InternalServerError
            };

        public static PropertyInfo GetProperty(Type type, string name)
        {
            return type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static string FirstOrDefault(params string[] values)
        {
            return values.FirstOrDefault(v => !string.IsNullOrEmpty(v));
        }

        public static RequestType GetRequestType(WebPubSubEventType eventType, string eventName)
        {
            if (eventType == WebPubSubEventType.User)
            {
                return RequestType.User;
            }
            if (eventName.Equals(Constants.Events.ConnectEvent, StringComparison.OrdinalIgnoreCase))
            {
                return RequestType.Connect;
            }
            if (eventName.Equals(Constants.Events.DisconnectedEvent, StringComparison.OrdinalIgnoreCase))
            {
                return RequestType.Disconnected;
            }
            if (eventName.Equals(Constants.Events.ConnectedEvent, StringComparison.OrdinalIgnoreCase))
            {
                return RequestType.Connected;
            }
            return RequestType.Ignored;
        }

        public static bool ValidateMediaType(string mediaType, out WebPubSubDataType dataType)
        {
            try
            {
                dataType = GetDataType(mediaType);
                return true;
            }
            catch
            {
                dataType = WebPubSubDataType.Binary;
                return false;
            }
        }

        public static bool IsValidationRequest(this HttpRequestMessage req, out List<string> requestHosts)
        {
            if (req.Method == HttpMethod.Options || req.Method == HttpMethod.Get)
            {
                requestHosts = req.Headers.GetValues(Constants.Headers.WebHookRequestOrigin)
                    .SelectMany(x => x.Split(Constants.HeaderSeparator, StringSplitOptions.RemoveEmptyEntries))
                    .ToList();
                return true;
            }
            requestHosts = null;
            return false;
        }

        public static string GetGroupNameByNamespace(string @namespace)
        {
            return NamespaceGroupType + Separator + Base64UrlEncoder.Encode(@namespace) + Separator;
        }

        public static string GetGroupNameByNamespaceRoom(string @namespace, string room)
        {
            return $"{NamespaceGroupType}{Separator}{Base64UrlEncoder.Encode(@namespace)}{Separator}{Base64UrlEncoder.Encode(room)}";
        }

        public static string GenerateRoomFilter(string @namespace, string room, bool containsNamespace)
        {
            return GenerateRoomFilter(@namespace, new string[] { room }, null, containsNamespace);
        }

        public static string GenerateExceptRoomFilter(string @namespace, string exceptRoom, bool containsNamespace)
        {
            return GenerateRoomFilter(@namespace, null, new string[] { exceptRoom }, containsNamespace);
        }

        public static string GenerateRoomFilter(string @namespace, IList<string> rooms, IList<string> exceptRooms, bool containsNamespace)
        {
            var filter = containsNamespace ? $"'{GetGroupNameByNamespace(@namespace)}' in groups" : string.Empty;
            if ((rooms == null || rooms.Count == 0) && (exceptRooms == null || exceptRooms.Count == 0))
            {
                return filter;
            }

            if (rooms != null && rooms.Count > 0)
            {
                filter = $"'{GetGroupNameByNamespaceRoom(@namespace, rooms[0])}' in groups";
                for (int i = 1; i < rooms.Count; i++)
                {
                    filter += $" or '{GetGroupNameByNamespaceRoom(@namespace, rooms[i])}' in groups";
                }
            }

            var denyFilter = string.Empty;
            if (exceptRooms != null && exceptRooms.Count > 0)
            {
                denyFilter = $"not ('{GetGroupNameByNamespaceRoom(@namespace, exceptRooms[0])}' in groups)";
                for (int i = 1; i < exceptRooms.Count; i++)
                {
                    denyFilter += $" and not ('{GetGroupNameByNamespaceRoom(@namespace, exceptRooms[i])}' in groups)";
                }
            }

            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(denyFilter))
            {
                return $"{filter} and {denyFilter}";
            }
            else if (!string.IsNullOrEmpty(filter))
            {
                return filter;
            }
            else
            {
                return denyFilter;
            }
        }
    }
}
