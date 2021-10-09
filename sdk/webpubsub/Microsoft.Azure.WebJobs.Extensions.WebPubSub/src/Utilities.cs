// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal static class Utilities
    {
        public static MediaTypeHeaderValue GetMediaType(MessageDataType dataType) => new(GetContentType(dataType));

        public static string GetContentType(MessageDataType dataType) =>
            dataType switch
            {
                MessageDataType.Text => Constants.ContentTypes.PlainTextContentType,
                MessageDataType.Json => Constants.ContentTypes.JsonContentType,
                // Default set binary type to align with service side logic
                _ => Constants.ContentTypes.BinaryContentType
            };

        public static MessageDataType GetDataType(string mediaType) =>
            mediaType.ToLowerInvariant() switch
            {
                Constants.ContentTypes.BinaryContentType => MessageDataType.Binary,
                Constants.ContentTypes.JsonContentType => MessageDataType.Json,
                Constants.ContentTypes.PlainTextContentType => MessageDataType.Text,
                _ => throw new ArgumentException($"{Constants.ErrorMessages.NotSupportedDataType}{mediaType}")
            };

        public static WebPubSubEventType GetEventType(string ceType)
        {
            return ceType.StartsWith(Constants.Headers.CloudEvents.TypeSystemPrefix, StringComparison.OrdinalIgnoreCase) ?
                WebPubSubEventType.System :
                WebPubSubEventType.User;
        }

        public static HttpResponseMessage BuildResponse(UserEventResponse response)
        {
            HttpResponseMessage result = new();

            if (response.Message != null)
            {
                result.Content = new StreamContent(response.Message.ToStream());
            }
            result.Content.Headers.ContentType = GetMediaType(response.DataType);

            return result;
        }

        public static HttpResponseMessage BuildResponse(ConnectEventResponse response)
        {
            return BuildResponse(JsonSerializer.Serialize(response), MessageDataType.Json);
        }

        public static HttpResponseMessage BuildResponse(string response, MessageDataType dataType = MessageDataType.Text)
        {
            HttpResponseMessage result = new();

            result.Content = new StringContent(response);
            result.Content.Headers.ContentType = GetMediaType(dataType);

            return result;
        }

        public static HttpResponseMessage BuildErrorResponse(EventErrorResponse error)
        {
            HttpResponseMessage result = new();

            result.StatusCode = GetStatusCode(error.Code);
            result.Content = new StringContent(error.ErrorMessage);
            return result;
        }

        public static HttpResponseMessage BuildValidResponse(object response, RequestType requestType)
        {
            JsonDocument converted = null;
            string originStr = null;
            bool needConvert = true;
            if (response is WebPubSubEventResponse)
            {
                needConvert = false;
            }
            else
            {
                // JObject or string type, use string to convert between JObject and JsonDocument.
                originStr = response.ToString();
                converted = JsonDocument.Parse(originStr);
            }

            try
            {
                // Check error, errorCode is required for json convert, otherwise, ignored.
                if (needConvert && converted.RootElement.TryGetProperty("code", out var code))
                {
                    var error = JsonSerializer.Deserialize<EventErrorResponse>(originStr);
                    return BuildErrorResponse(error);
                }
                else if (response is EventErrorResponse errorResponse)
                {
                    return BuildErrorResponse(errorResponse);
                }

                if (requestType == RequestType.Connect)
                {
                    if (needConvert)
                    {
                        return BuildResponse(originStr);
                    }
                    else if (response is ConnectEventResponse connectResponse)
                    {
                        return BuildResponse(connectResponse);
                    }
                }
                if (requestType == RequestType.User)
                {
                    if (needConvert)
                    {
                        return BuildResponse(JsonSerializer.Deserialize<UserEventResponse>(originStr));
                    }
                    else if (response is UserEventResponse messageResponse)
                    {
                        return BuildResponse(messageResponse);
                    }
                }
            }
            catch (Exception)
            {
                // Ignore invalid response.
            }

            return null;
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

        public static bool ValidateMediaType(string mediaType, out MessageDataType dataType)
        {
            try
            {
                dataType = GetDataType(mediaType);
                return true;
            }
            catch (Exception)
            {
                dataType = MessageDataType.Binary;
                return false;
            }
        }

        public static bool IsValidationRequest(this HttpRequestMessage req, out List<string> requestHosts)
        {
            if (req.Method == HttpMethod.Options || req.Method == HttpMethod.Get)
            {
                requestHosts = req.Headers.GetValues(Constants.Headers.WebHookRequestOrigin).ToList();
                return true;
            }
            requestHosts = null;
            return false;
        }
    }
}
