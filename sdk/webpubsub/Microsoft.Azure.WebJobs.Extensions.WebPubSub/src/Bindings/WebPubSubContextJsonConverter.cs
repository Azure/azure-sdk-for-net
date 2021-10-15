// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var jobj = new JObject();
            if (value.Request != null)
            {
                jobj.Add(new JProperty(WebPubSubContext.RequestPropertyName, JObject.Parse(request)));
            }
            if (value.Response != null)
            {
                jobj.Add(new JProperty(WebPubSubContext.ResponsePropertyName, JObject.FromObject(value.Response, serializer)));
            }
            jobj.Add(WebPubSubContext.ErrorMessagePropertyName, value.ErrorMessage);
            jobj.Add(WebPubSubContext.HasErrorPropertyName, value.HasError);
            jobj.Add(WebPubSubContext.IsPreflightPropertyName, value.IsPreflight);
            jobj.WriteTo(writer);
        }

        private static string ConvertString(WebPubSubEventRequest request) =>
            request switch
            {
                ConnectedEventRequest connected => SystemJson.JsonSerializer.Serialize<ConnectedEventRequest>(connected),
                ConnectEventRequest connect => SystemJson.JsonSerializer.Serialize<ConnectEventRequest>(connect),
                UserEventRequest userEvent => SystemJson.JsonSerializer.Serialize<UserEventRequest>(userEvent),
                DisconnectedEventRequest disconnected => SystemJson.JsonSerializer.Serialize<DisconnectedEventRequest>(disconnected),
                PreflightRequest validation => SystemJson.JsonSerializer.Serialize<PreflightRequest>(validation),
                _ => null
            };
    }
}
