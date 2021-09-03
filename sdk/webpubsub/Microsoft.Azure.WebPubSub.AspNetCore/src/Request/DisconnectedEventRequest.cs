// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Disconnected event request.
    /// </summary>
    [JsonConverter(typeof(DisconnectedEventRequestJsonConverter))]
    public sealed class DisconnectedEventRequest : ServiceRequest
    {
        /// <summary>
        /// Reason.
        /// </summary>
        public string Reason { get; internal set; }

        /// <summary>
        /// Name of the request.
        /// </summary>
        public override string Name => nameof(DisconnectedEventRequest);

        internal DisconnectedEventRequest()
            : base(null) { }

        internal partial class DisconnectedEventRequestJsonConverter : JsonConverter<DisconnectedEventRequest>
        {
            public override DisconnectedEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var request = new DisconnectedEventRequest();
                using var document = JsonDocument.ParseValue(ref reader);
                var elements = document.RootElement;
                if (elements.TryGetProperty("reason", out var value))
                {
                    request.Reason = value.ToString();
                }
                return request;
            }

            public override void Write(Utf8JsonWriter writer, DisconnectedEventRequest value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
