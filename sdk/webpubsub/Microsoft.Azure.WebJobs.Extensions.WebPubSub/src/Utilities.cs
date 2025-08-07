// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal static class Utilities
    {
        public static MediaTypeHeaderValue GetMediaType(WebPubSubDataType dataType) => new(GetContentType(dataType));

        public static string GetContentType(WebPubSubDataType dataType) =>
            dataType switch
            {
                WebPubSubDataType.Text => Constants.ContentTypes.PlainTextContentType,
                WebPubSubDataType.Json => Constants.ContentTypes.JsonContentType,
                // Default set binary type to align with service side logic
                _ => Constants.ContentTypes.BinaryContentType
            };

        public static WebPubSubDataType GetDataType(string mediaType) =>
            mediaType.ToLowerInvariant() switch
            {
                Constants.ContentTypes.BinaryContentType => WebPubSubDataType.Binary,
                Constants.ContentTypes.JsonContentType => WebPubSubDataType.Json,
                Constants.ContentTypes.PlainTextContentType => WebPubSubDataType.Text,
                _ => throw new ArgumentException($"{Constants.ErrorMessages.NotSupportedDataType}{mediaType}")
            };

        public static WebPubSubEventType GetEventType(string ceType)
        {
            return ceType.StartsWith(Constants.Headers.CloudEvents.TypeSystemPrefix, StringComparison.OrdinalIgnoreCase) ?
                WebPubSubEventType.System :
                WebPubSubEventType.User;
        }

        public static HttpResponseMessage BuildUserEventResponse(UserEventResponse response, Dictionary<string, object> mergedStates)
        {
            HttpResponseMessage result = new();

            if (response.Data != null)
            {
                result.Content = new StreamContent(response.Data.ToStream());
            }

            if (mergedStates?.Count > 0)
            {
                result.Headers.Add(Constants.Headers.CloudEvents.State, mergedStates.EncodeConnectionStates());
            }
            result.Content.Headers.ContentType = GetMediaType(response.DataType);

            return result;
        }

        public static HttpResponseMessage BuildConnectEventResponse(string response, Dictionary<string, object> mergedStates, WebPubSubDataType dataType = WebPubSubDataType.Json)
        {
            HttpResponseMessage result = new();
            if (mergedStates?.Count > 0)
            {
                result.Headers.Add(Constants.Headers.CloudEvents.State, mergedStates.EncodeConnectionStates());
            }

            result.Content = new StringContent(response);
            result.Content.Headers.ContentType = GetMediaType(dataType);

            return result;
        }

        public static HttpResponseMessage BuildErrorResponse(EventErrorResponse error)
        {
            return error switch
            {
                MqttConnectEventErrorResponse mqttConnectError => BuildErrorResponse(JsonConvert.SerializeObject(mqttConnectError, MqttConnectEventErrorResponseJsonConverter.Instance), mqttConnectError.Code),
                _ => BuildErrorResponse(error.ErrorMessage, error.Code)
            };
        }

        public static HttpResponseMessage BuildErrorResponse(string errorMessage, WebPubSubErrorCode code = WebPubSubErrorCode.ServerError)
        {
            HttpResponseMessage result = new();

            result.StatusCode = GetStatusCode(code);
            result.Content = new StringContent(errorMessage);
            return result;
        }

        public static HttpResponseMessage BuildValidResponse(
            WebPubSubEventResponse response, RequestType requestType,
            WebPubSubConnectionContext context)
        {
            // check error as top priority.
            if (response is EventErrorResponse errorResponse)
            {
                return BuildErrorResponse(errorResponse);
            }

            if (requestType == RequestType.Connect)
            {
                if (response is ConnectEventResponse connectResponse)
                {
                    var mergedStates = context.UpdateStates(connectResponse.ConnectionStates);
                    return BuildConnectEventResponse(JsonConvert.SerializeObject(response), mergedStates);
                }
                return BuildErrorResponse($"Invalid response type: '{response.GetType()}' in current request type '{requestType}'.");
            }
            if (requestType == RequestType.User)
            {
                if (response is UserEventResponse messageResponse)
                {
                    var mergedStates = context.UpdateStates(messageResponse.ConnectionStates);
                    return BuildUserEventResponse(messageResponse, mergedStates);
                }
                return BuildErrorResponse($"Invalid response type: '{response.GetType()}' in current request type '{requestType}'.");
            }
            // should not hit.
            throw new ArgumentException($"Invalid request type, {requestType}");
        }

        public static HttpResponseMessage BuildValidResponse(
            JToken jResponse, RequestType requestType,
            WebPubSubConnectionContext context)
        {
            try
            {
                JObject response = jResponse is JObject jObj ? jObj : throw new ArgumentException("Response should be a JObject.");

                // check error as top priority.
                if (
                    // General error response
                    response.TryGetValue("code", out var code)
                    && code.ToObject<WebPubSubStatusCode>() != WebPubSubStatusCode.Success ||

                    // MQTT connect error response
                    response.TryGetValue("mqtt", out var mqtt)
                    && mqtt is JObject mqttObject && mqttObject.TryGetValue("code", out _))
                {
                    if (context is MqttConnectionContext mqttContext)
                    {
                        var mqttErrorConnectResponse = response.ToObject<MqttConnectEventErrorResponseContent>();
                        return BuildErrorResponse(JsonConvert.SerializeObject(mqttErrorConnectResponse, MqttConnectEventErrorResponseJsonConverter.Instance), mqttErrorConnectResponse.Code);
                    }
                    var error = response.ToObject<EventErrorResponse>();
                    return BuildErrorResponse(error);
                }

                if (requestType == RequestType.Connect)
                {
                    var states = GetStatesFromJson(response);
                    var mergedStates = context.UpdateStates(states);
                    var formattedResponse = context switch
                    {
                        MqttConnectionContext => JsonConvert.SerializeObject(response.ToObject<MqttConnectEventResponse>()),
                        _ => JsonConvert.SerializeObject(response.ToObject<ConnectEventResponse>())
                    };
                    return BuildConnectEventResponse(formattedResponse, mergedStates);
                }
                if (requestType == RequestType.User)
                {
                    var states = GetStatesFromJson(response);
                    var mergedStates = context.UpdateStates(states);
                    return BuildUserEventResponse(response.ToObject<UserEventResponse>(), mergedStates);
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

        public static string GetFunctionKey(string hub, WebPubSubEventType type, string eventName, WebPubSubTriggerAcceptedClientProtocols clientProtocol = WebPubSubTriggerAcceptedClientProtocols.All) => $"{hub}.{type}.{eventName}.{clientProtocol}";

        private static Dictionary<string, BinaryData> GetStatesFromJson(JObject response)
        {
            if (response.TryGetValue("states", out var val))
            {
                // val should be a JSON object of <key,value> pairs
                if (val.Type == JTokenType.Object)
                {
                    return val.ToObject<IReadOnlyDictionary<string, BinaryData>>()
                        .ToDictionary(k => k.Key, v => v.Value);
                }
            }
            // We don't support clear states for JS
            return new Dictionary<string, BinaryData>();
        }

        private static MqttConnectEventErrorResponse ToMqttConnectErrorResponse(JObject jObject)
        {
            return jObject.ToObject<MqttConnectEventErrorResponseContent>();
        }
    }
}
