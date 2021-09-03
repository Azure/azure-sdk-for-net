// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Connect event request.
    /// </summary>
    [JsonConverter(typeof(ConnectEventRequestJsonConverter))]
    public sealed class ConnectEventRequest : ServiceRequest
    {
        /// <summary>
        /// User Claims.
        /// </summary>
        public IDictionary<string, string[]> Claims { get; internal set; }

        /// <summary>
        /// Query.
        /// </summary>
        public IDictionary<string, string[]> Query { get; internal set; }

        /// <summary>
        /// Supported subprotocols.
        /// </summary>
        public string[] Subprotocols { get; internal set; }

        /// <summary>
        /// Client certificates.
        /// </summary>
        public ClientCertificateInfo[] ClientCertificates { get; internal set; }

        /// <summary>
        /// The name of the request.
        /// </summary>
        public override string Name => nameof(ConnectEventRequest);

        internal ConnectEventRequest()
            : base(null) { }

        internal partial class ConnectEventRequestJsonConverter : JsonConverter<ConnectEventRequest>
        {
            public override ConnectEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var request = new ConnectEventRequest();
                try
                {
                    using var document = JsonDocument.ParseValue(ref reader);
                    var elements = document.RootElement.EnumerateObject();
                    foreach (var item in elements)
                    {
                        if (item.Name.Equals(nameof(Claims), StringComparison.OrdinalIgnoreCase))
                        {
                            request.Claims = JsonSerializer.Deserialize<Dictionary<string, string[]>>(item.Value.ToString());
                        }
                        if (item.Name.Equals(nameof(Query), StringComparison.OrdinalIgnoreCase))
                        {
                            request.Query = JsonSerializer.Deserialize<Dictionary<string, string[]>>(item.Value.ToString());
                        }
                        if (item.Name.Equals(nameof(Subprotocols), StringComparison.OrdinalIgnoreCase))
                        {
                            request.Subprotocols = JsonSerializer.Deserialize<string[]>(item.Value.ToString());
                        }
                        if (item.Name.Equals(nameof(ClientCertificates), StringComparison.OrdinalIgnoreCase))
                        {
                            request.ClientCertificates = JsonSerializer.Deserialize<ClientCertificateInfo[]>(item.Value.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                }
                return request;
            }

            public override void Write(Utf8JsonWriter writer, ConnectEventRequest value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
