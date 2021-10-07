// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class WebhookHookParameterPatch
    {
        public IDictionary<string, string> Headers { get; internal set; }

        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullStringValue("endpoint", Endpoint);
            writer.WriteNullStringValue("username", Username);
            writer.WriteNullStringValue("password", Password);
            if (Optional.IsCollectionDefined(Headers))
            {
                writer.WritePropertyName("headers");
                writer.WriteStartObject();
                foreach (var item in Headers)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteNullStringValue("certificateKey", CertificateKey);
            writer.WriteNullStringValue("certificatePassword", CertificatePassword);
            writer.WriteEndObject();
        }
    }
}
