// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.WebPubSub.Common;

using SystemJson = System.Text.Json;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubContextJsonConverter : JsonConverter<WebPubSubContext>
    {
        public override WebPubSubContext ReadJson(JsonReader reader, Type objectType, WebPubSubContext existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, WebPubSubContext value, JsonSerializer serializer)
        {
            serializer.Converters.Add(new HttpResponseMessageJsonConverter());
            // Request is using System.Json, use string as bridge to convert.
            var request = ConvertString(value.Request);
            JObject jobj = new JObject();
            if (value.Request != null)
            {
                jobj.Add(new JProperty("request", JObject.Parse(request)));
            }
            if (value.Response != null)
            {
                jobj.Add(new JProperty("response", JObject.FromObject(value.Response, serializer)));
            }
            jobj.Add("errorMessage", value.ErrorMessage);
            jobj.Add("errorCode", value.ErrorCode);
            jobj.Add("isValidationRequest", value.IsValidationRequest);
            jobj.WriteTo(writer);
        }

        private static string ConvertString(WebPubSubEventRequest request)
        {
            switch (request)
            {
                case ConnectedEventRequest connected:
                    return SystemJson.JsonSerializer.Serialize<ConnectedEventRequest>(connected);
                case ConnectEventRequest connect:
                    return SystemJson.JsonSerializer.Serialize<ConnectEventRequest>(connect);
                case UserEventRequest userEvent:
                    return SystemJson.JsonSerializer.Serialize<UserEventRequest>(userEvent);
                case DisconnectedEventRequest disconnected:
                    return SystemJson.JsonSerializer.Serialize<DisconnectedEventRequest>(disconnected);
                case ValidationRequest validation:
                    return SystemJson.JsonSerializer.Serialize<ValidationRequest>(validation);
                default:
                    return null;
            }
        }
    }
}
